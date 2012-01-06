<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="UCENTRIK.WEB.dirKioskEcoATM._default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Get Help</title>
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <script type="text/javascript">
        function PopupCenter(pageURL, title, w, h) {
            var left = (screen.width / 2) - (w / 2);
            var top = (screen.height / 2) - (h / 2);
            var targetWin = window.open(pageURL, title, 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=' + w + ', height=' + h + ', top=' + top + ', left=' + left);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table align="center" width="400px" height="200px" style="background-color: white;">
            <tr align="center" valign="middle">
                <td>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    <asp:Panel ID="PanelLogin" runat="server">
                        <table>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelUserName" runat="server" Text="UserName:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxUserName" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelPassword" runat="server" Text="Password:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" OnPreRender="TextBoxPassword_PreRender"
                                        Width="200" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="left">
                                    <asp:Button ID="ButtonLogIn" runat="server" Text="Login" 
                                        onclick="ButtonLogIn_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr align="center" valign="middle">
                <td>
                    <asp:Panel ID="PanelGetHelp" runat="server" Enabled="false">
                        <table>
                            <tr>
                                <td>
                                    <hr />
                                </td>
                                <td>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelSkill" runat="server" Text="Skill:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlSkill" runat="server" DataTextField="skill_name" DataValueField="skill_id" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelLanguage" runat="server" Text="Language:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlLanguage" runat="server" DataTextField="language_name" DataValueField="language_id" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelGroup" runat="server" Text="Group:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlGroup" runat="server" DataTextField="group_name" DataValueField="group_id" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <hr />
                                </td>
                                <td>
                                    <hr />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelKioskID" runat="server" Text="Kiosk ID:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxKioskID" runat="server" Text="33" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelKioskName" runat="server" Text="Kiosk Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxKioskName" runat="server" Text="Central" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelKioskLocation" runat="server" Text="Kiosk Location:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxKioskLocation" runat="server" Text="Ukraine" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="LabelKioskUser" runat="server" Text="Contact Name:"></asp:Label>
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxKioskUser" runat="server" Text="" />
                                </td>
                            </tr>
                            <tr align="center" valign="middle">
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="ButtonGetHelp" runat="server" Text="Get Help" OnClick="ButtonGetHelp_Click" />
                                    <asp:Button ID="ButtonChangeAccount" runat="server" Text="Change Account" 
                                        onclick="ButtonChangeAccount_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
