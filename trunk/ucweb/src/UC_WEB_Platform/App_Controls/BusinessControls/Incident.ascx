<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Incident.ascx.cs" Inherits="UcentrikWeb.App_Controls.BusinessControls.Incident" %>
<%@ Register TagPrefix="ucentrik" TagName="IncidentProfile" Src="IncidentProfile.ascx" %>
<asp:ObjectDataSource ID="objectdatasourceList" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyIncident"
    SelectMethod="" DeleteMethod="DeleteIncident" OnSelected="dataSelected"></asp:ObjectDataSource>
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
                    Calls:&nbsp;
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
                    <asp:GridView ID="gvList" runat="server" DataKeyNames="incident_id" OnRowEditing="gvList_RowEditing">
                        <Columns>
                            <asp:TemplateField ConvertEmptyStringToNull="true" HeaderText="Facility" HeaderStyle-HorizontalAlign="Left"
                                SortExpression="facility_name" Visible="true">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lbIncident" runat="server" CommandName='<%# Eval("facility_name")%>'
                                        CommandArgument='<%# Eval("incident_id")%>' OnPreRender="lbIncident_PreRender"
                                        OnClick="lbIncident_Click">
                                        
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="facility_name" HeaderText="Facility" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="facility_name" />
                            <asp:BoundField DataField="group_name" HeaderText="Group" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="group_name" />
                            <asp:BoundField DataField="skill_name" HeaderText="Skill" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="skill_name" />
                            <asp:BoundField DataField="language_name" HeaderText="Language" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="language_name" />
                            <asp:BoundField DataField="agent_full_name" HeaderText="Agent name" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="agent_full_name" />
                            <asp:BoundField DataField="consumer_name" HeaderText="User ID" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="consumer_name" />
                            <asp:BoundField DataField="incident_status_name" HeaderText="Status" HeaderStyle-HorizontalAlign="Left"
                                ReadOnly="true" SortExpression="incident_status_name" />
                            <asp:BoundField DataField="incident_id" HeaderText="Call ID" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="80" HeaderStyle-Wrap="false" ItemStyle-HorizontalAlign="Center"
                                ReadOnly="true" SortExpression="incident_id" />
                            <asp:TemplateField ConvertEmptyStringToNull="true" HeaderText="Reserved" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50" ItemStyle-HorizontalAlign="Center" SortExpression="reserved_agent_id"
                                Visible="false">
                                <ItemTemplate>
                                    <%# showIcon(DataBinder.Eval(Container.DataItem, "reserved_agent_id"))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:CommandField HeaderText="Command" ShowHeader="True" HeaderStyle-HorizontalAlign="Center"
                                HeaderStyle-Width="50" ItemStyle-Width="50" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center"
                                ShowCancelButton="false" ShowEditButton="true" ShowDeleteButton="true" EditText="Edit"
                                DeleteText="Delete" Visible="false" />
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
                            Visible="false" OnClick="btnAdd_Click" />
                    </td>
                </tr>
            </asp:Panel>
        </table>
    </asp:View>
    <asp:View ID="viewEdit" runat="server">
        <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td>
                    <ucentrik:IncidentProfile ID="profileControl" runat="server" OnProfileSaveButton="view_Save"
                        OnProfileBackButton="view_Back" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
