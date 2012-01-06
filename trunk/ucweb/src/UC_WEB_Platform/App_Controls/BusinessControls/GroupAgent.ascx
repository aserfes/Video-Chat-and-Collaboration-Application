<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GroupAgent.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.BusinessControls.GroupAgent" %>
<asp:ObjectDataSource ID="objectdatasourceList" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyGroupAgent"
    SelectMethod="" DeleteMethod="" OnSelected="dataSelected"></asp:ObjectDataSource>
<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">
    <tr height="25">
        <td align="left">
            Group Agent management:&nbsp;
            <asp:Label ID="lblGroupName" runat="server" Text="">
            </asp:Label>
        </td>
    </tr>
    <tr height="15px">
        <td>
        </td>
    </tr>
    <tr height="25">
        <td align="left">
            <asp:Label ID="lblMessage" runat="server" Text="">
            </asp:Label>
        </td>
    </tr>
    <tr height="15px">
        <td>
        </td>
    </tr>
    <tr>
        <td align="center" valign="top" colspan="2">
            <asp:GridView ID="gvList" runat="server" DataKeyNames="agent_id, group_id" OnRowCreated="gvList_RowCreated"
                OnRowEditing="gvList_RowEditing" OnRowDeleting="gvList_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="full_name" HeaderText="Agent" HeaderStyle-HorizontalAlign="Left"
                        ReadOnly="true" SortExpression="full_name" />
                    <asp:TemplateField ConvertEmptyStringToNull="true" HeaderText="In Group" HeaderStyle-HorizontalAlign="Center"
                        HeaderStyle-Wrap="false" ItemStyle-Width="50" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center"
                        SortExpression="group_id" Visible="true">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkboxInGroup" runat="server" Enabled="false" Checked='<%# !(Eval("group_id") is System.DBNull) %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField HeaderText="Command" ShowHeader="True" HeaderStyle-HorizontalAlign="Center"
                        ItemStyle-Width="50" ItemStyle-Wrap="false" ItemStyle-HorizontalAlign="Center"
                        ShowCancelButton="false" ShowEditButton="true" ShowDeleteButton="true" EditText="Add"
                        DeleteText="Remove" />
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            <br />
        </td>
    </tr>
    <tr height="15px">
        <td>
        </td>
    </tr>
    <tr>
        <td valign="bottom" class="separator">
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
                    </td>
                    <td width="5px">
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
