<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="UCENTRIK.UserControls.Controls.Login" %>
<table width="480px" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td align="right">
            <table width="480px" cellpadding="0" cellspacing="0" border="0">
                <tr height="20px">
                    <td width="50%" align="left">
                        <font color="red">
                            <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
                        </font>
                    </td>
                    <td width="50%" align="right" class="UcLink">
                        <asp:HyperLink ID="hlSignIn" runat="server" NavigateUrl="../../dirCommon/ucSignIn.aspx"
                            Visible="false" CssClass="UcLink">
                            Sign in
                        </asp:HyperLink>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr height="40">
        <td>
            <asp:Panel ID="pnlWelcome" runat="server" Visible="false">
                <table width="480px" cellpadding="0" cellspacing="0" border="0">
                    <tr height="25px">
                        <td align="right" width="99%">
                            Welcome:
                        </td>
                        <td>
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="left" width="1%" nowrap>
                            <asp:Literal ID="ltDisplayName" runat="server"></asp:Literal>
                        </td>
                        <td width="1">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlLogin" runat="server" DefaultButton="btnLogin" Visible="false">
                <table width="480px" cellpadding="0" cellspacing="0" border="0">
                    <tr height="25px">
                        <td align="right">
                            Username:
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUserName" runat="server" Width="120" ValidationGroup="Login">
                            </asp:TextBox>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td class="ErrorMessage">
                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUserName"
                                ValidationGroup="Login" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td align="right">
                            Password:
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="120" ValidationGroup="Login">
                            </asp:TextBox>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td class="ErrorMessage">
                            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                                ValidationGroup="Login" ErrorMessage="*">
                            </asp:RequiredFieldValidator>
                        </td>
                        <td>
                            &nbsp;&nbsp;
                        </td>
                        <td align="right" width="1" valign="middle">
                            <table width="250px" height="22px" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnLogin" runat="server" ValidationGroup="Login" Width="100px" Height="24px"
                                            CssClass="UcButton" Text="Login" UseSubmitBehavior="true" OnClick="btnLogin_Click" />
                                    </td>
                                    <td align="right" class="UcLink">
                                        <asp:Panel ID="pnlPasswordRecovery" runat="server" Visible="false">
                                            <asp:HyperLink ID="hplPasswordRecovery" runat="server" NavigateUrl="../../dirCommon/ucPasswordRecovery.aspx"
                                                CssClass="UcLink">
                                    Forgotten Password?
                                            </asp:HyperLink>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlLogout" runat="server" Visible="false">
                <table width="480px" cellpadding="0" cellspacing="0" border="0">
                    <tr height="25px">
                        <td align="right">
                            Username:
                        </td>
                        <td width="1">
                            &nbsp;
                        </td>
                        <td align="left" width="1">
                            <asp:Literal ID="ltUsername" runat="server"></asp:Literal>
                        </td>
                        <td width="1">
                            &nbsp;&nbsp;&nbsp;
                        </td>
                        <td align="right" width="1">
                            <table width="100px" height="22px" cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:Button ID="btnLogout" runat="server" Width="100px" Height="24px" CssClass="UcButton"
                                            Text="Logout" UseSubmitBehavior="false" OnClick="btnLogout_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
