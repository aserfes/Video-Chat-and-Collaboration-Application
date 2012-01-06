<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Agent.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.Agent" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentProfile" Src="AgentProfile.ascx" %>
<asp:ObjectDataSource ID="objectdatasourceList" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyAgent"
    SelectMethod="" DeleteMethod="DeleteAgent" OnSelected="dataSelected"></asp:ObjectDataSource>
<asp:MultiView ID="mvControl" runat="server" ActiveViewIndex="0">
    <asp:View ID="viewList" runat="server">
        <table width="100%" cellpadding="0" cellspacing="0" border="0">
            <tr height="25">
                <td align="left" colspan="2">
                    <asp:Label ID="lblMessage" runat="server" Text="">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td align="left">
                </td>
                <td align="right">
                    Agents:&nbsp;
                    <asp:Label ID="lblCount" runat="server" Text="">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:PlaceHolder ID="phControls" runat="server"></asp:PlaceHolder>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="2">
                    <asp:GridView ID="gvList" runat="server" DataKeyNames="agent_id" OnRowEditing="gvList_RowEditing">
                        <Columns>
                            <asp:TemplateField ConvertEmptyStringToNull="true" HeaderText="Agent" HeaderStyle-HorizontalAlign="Left"
                                SortExpression="full_name" Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbAgent" runat="server" CommandArgument='<%# Eval("agent_id")%>'
                                        OnClick="lbAgent_Click">
                                        <%# Eval("full_name")%>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="full_name" HeaderText="Agent" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="full_name" />
                            <asp:BoundField DataField="agent_guid" HeaderText="GUID" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="agent_guid" Visible="false" />
                            <asp:CommandField HeaderText="Command" ShowHeader="True" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50" ItemStyle-Width="50" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center"
                                ShowCancelButton="false" ShowEditButton="true" ShowDeleteButton="true" EditText="Edit"
                                DeleteText="Delete" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <br />
                    <br />
                </td>
            </tr>
            <asp:Panel ID="pnlAdd" runat="server" Visible="false">
                <tr>
                    <td align="left">
                    </td>
                    <td align="right">
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="100px" Height="24px" CssClass="UcButton"
                            OnClick="btnAdd_Click" Enabled="false" Visible="false"/>
                    </td>
                </tr>
            </asp:Panel>
        </table>
    </asp:View>
    <asp:View ID="viewEdit" runat="server">
        <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td valign="top">
                    <ucentrik:AgentProfile ID="profileControl" runat="server" OnManageGroups="sosAgent_ManageGroups"
                        OnManageSkills="sosAgent_ManageSkills" OnManageLanguages="sosAgent_ManageLanguages"
                        OnProfileSaveButton="view_Save" OnProfileBackButton="view_Back" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
