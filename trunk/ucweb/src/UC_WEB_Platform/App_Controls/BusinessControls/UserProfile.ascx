<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.ascx.cs"
    Inherits="UcentrikWeb.App_Controls.BusinessControls.UserProfile" %>
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
        <td colspan="2" valign="top">
            <asp:DetailsView ID="dvControl" runat="server" DataKeyNames="user_id" OnDataBound="dvControl_DataBound"
                OnItemUpdating="dvControl_ItemUpdating" OnItemInserting="dvControl_ItemInserting">
                <HeaderStyle Width="150px" />
                <RowStyle Height="30px" />
                <Fields>
                    <asp:TemplateField Visible="false">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfUserRoleId" runat="server" Value='<%# Bind("user_role_id") %>' />
                            <asp:HiddenField ID="hfTimeZone" runat="server" Value='<%# Bind("time_zone") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Username" SortExpression="username">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("username") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <InsertItemTemplate>
                            <asp:TextBox ID="txtUsername" runat="server" MaxLength="256" Text='<%# Bind("username") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rfvFullNameFormat" runat="server" ControlToValidate="txtUsername"
                                ValidationGroup="Edit" ValidationExpression="[\w\s\-\;\:\*\.\,\)\(\/\\]*" ErrorMessage="Format of User Name is not valid"
                                Text="Format of User Name is not valid" />
                        </InsertItemTemplate>
                        <EditItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" Text='<%# Bind("username") %>'>
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
                    <asp:TemplateField HeaderText="Role" Visible="true">
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlUserRoles" runat="server" AutoPostBack="true" Width="200"
                                DataTextField="user_role_name" DataValueField="user_role_id" OnSelectedIndexChanged="ddlUserRoles_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvUserRoles" runat="server" ControlToValidate="ddlUserRoles"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First name" SortExpression="first_name">
                        <ItemTemplate>
                            <asp:Label ID="lblFirstname" runat="server" Text='<%# Bind("first_name") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtFirstname" runat="server" MaxLength="20" Text='<%# Bind("first_name") %>'>
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
                            <asp:TextBox ID="txtLastname" runat="server" MaxLength="20" Text='<%# Bind("last_name") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvLastname" runat="server" ControlToValidate="txtLastname"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Password" SortExpression="password">
                        <ItemTemplate>
                            <asp:Label ID="lblPassword" runat="server" Text='<%# Bind("password") %>'>
                                        >
                            </asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="SingleLine" MaxLength="20"
                                Text='<%# Bind("password") %>'>
                            </asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                ValidationGroup="Edit" ErrorMessage="Required Field">
                                        Required
                            </asp:RequiredFieldValidator>
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
