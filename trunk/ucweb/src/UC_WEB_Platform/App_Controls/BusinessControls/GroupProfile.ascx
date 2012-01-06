<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupProfile.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.BusinessControls.GroupProfile" %>
<asp:ObjectDataSource ID="objectdatasourceEdit" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyGroup"
    SelectMethod="SelectGroup" InsertMethod="InsertGroup" UpdateMethod="UpdateGroup">
</asp:ObjectDataSource>
<table width="100%" height="320px" align="center" cellspacing="0" cellpadding="0"
    border="0">
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
        <td colspan="2" valign="top">
            <asp:DetailsView ID="dvControl" runat="server" DataKeyNames="group_id" OnDataBound="dvControl_DataBound">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
                    <asp:TemplateField HeaderText="Created" SortExpression="date_created" Visible="true">
                        <ItemTemplate>
                            <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_created"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Updated" SortExpression="date_updated" Visible="true">
                        <ItemTemplate>
                            <%# this.formatDateTime(DataBinder.Eval(Container.DataItem, "date_updated"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Group name" SortExpression="group_name">
                        <ItemTemplate>
                            <asp:Label ID="lblGroupName" runat="server" Text='<%# Bind("group_name") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtGroupName" runat="server" Text='<%# Bind("group_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvGroupName" runat="server" ControlToValidate="txtGroupName"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Agents" InsertVisible="false" SortExpression="agent_cnt">
                        <ItemTemplate>
                            <asp:Label ID="lblAgentCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "agent_cnt")%>'>
                            </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbManageAgents" runat="server" CommandArgument='<%# Eval("group_id")%>'
                                Visible="false" OnClick="lbManageAgents_Click">
                                        Click here to manage agents
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Facilities" InsertVisible="false" SortExpression="facility_cnt">
                        <ItemTemplate>
                            <asp:Label ID="lblFacilityCnt" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "facility_cnt")%>'>
                            </asp:Label>
                            &nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbManageFacilities" runat="server" CommandArgument='<%# Eval("group_id")%>'
                                Visible="false" OnClick="lbManageFacilities_Click">
                                        Click here to manage facilities
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Fields>
            </asp:DetailsView>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2" valign="bottom" class="separator">
            <table width="100%" height="100%" align="center" cellspacing="2" cellpadding="0"
                border="0">
                <tr>
                    <td width="5px">
                    </td>
                    <td align="left">
                        <asp:Button ID="btnBack" runat="server" Text="BACK" Width="100px" Height="24px" CssClass="UcButton"
                            UseSubmitBehavior="false" OnClick="btnBack_Click" />
                    </td>
                    <td align="right">
                        <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="100px" Height="24px" CssClass="UcButton"
                            ValidationGroup="Edit" UseSubmitBehavior="true" OnClick="btnSave_Click" />
                    </td>
                    <td width="5px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
