<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserAccount.ascx.cs"
    Inherits="UCENTRIK.WEB.LIB.App_Controls.CommonControls.UserAccount" %>
<asp:ObjectDataSource ID="objectdatasourceEdit" runat="server" TypeName="UCENTRIK.LIB.BllProxy.BllProxyUser"
    SelectMethod="SelectUser" InsertMethod="InsertUser" UpdateMethod="UpdateUser">
</asp:ObjectDataSource>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
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
        <td colspan="2">
            <br />
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:DetailsView ID="dvControl" runat="server" DataKeyNames="user_id, user_role_id"
                OnDataBound="dvControl_DataBound" OnItemUpdating="dvControl_ItemUpdating" OnItemUpdated="dvControl_ItemUpdated">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfTimeZone" runat="server" Value='<%# Bind("time_zone") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Username" SortExpression="username">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" CssClass="TextImportant" Text='<%# Bind("username") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("username") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" CssClass="TextImportant" Text='<%# Bind("username") %>'>
                                        >
                            </asp:Label>
                        </EditItemTemplate>
                    </asp:TemplateField>
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
                    <asp:TemplateField HeaderText="First name" SortExpression="first_name">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstname" runat="server" Text='<%# Bind("first_name") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstname" runat="server" Text='<%# Bind("first_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvFirstname" runat="server" ControlToValidate="txtFirstname"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last name" SortExpression="last_name">
                        <ItemTemplate>
                            <asp:Label ID="lblLastname" runat="server" Text='<%# Bind("last_name") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtLastname" runat="server" Text='<%# Bind("last_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastname"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Password" SortExpression="password">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" Text='<%# Bind("password") %>'>
                                    >
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword"
                                ValidationGroup="Edit" Display="Dynamic" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Confirm Password" SortExpression="password">
                        <EditItemTemplate>
                            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Text='<%# Bind("password") %>'>
                                    >
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                ValidationGroup="Edit" Display="Dynamic" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="cvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                                ControlToCompare="txtNewPassword" ValidationGroup="Edit" Display="Dynamic" ErrorMessage="Passwords do not match">
                            </asp:CompareValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="GUID" DataField="user_guid" ReadOnly="true" InsertVisible="false"
                        Visible="false" />
                    <asp:TemplateField HeaderText="TimeZone" Visible="true">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlTimeZone" runat="server" Width="425" OnSelectedIndexChanged="ddlTimeZone_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvTimeZone" runat="server" ControlToValidate="ddlTimeZone"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
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
        <td align="left">
            <asp:Button ID="btnBack" runat="server" Text="BACK" Width="50" UseSubmitBehavior="false"
                OnClick="btnBack_Click" />
        </td>
        <td align="right">
            <asp:Button ID="btnSave" runat="server" Text="SAVE" Width="50" ValidationGroup="Edit"
                UseSubmitBehavior="true" OnClick="btnSave_Click" />
        </td>
    </tr>
</table>
