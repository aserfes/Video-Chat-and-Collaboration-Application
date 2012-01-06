<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Logout.ascx.cs" Inherits="UCENTRIK.UserControls.Controls.Logout" %>
<table width="480px" cellpadding="0" cellspacing="0" border="0">
    <tr height="20">
        <td align="right">
            <font color="red">
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </font>
        </td>
    </tr>
    <tr>
        <td>
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
                        <asp:Button ID="btnLogout" runat="server" Width="80" Text="Logout" UseSubmitBehavior="false"
                            OnClick="btnLogout_Click" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
