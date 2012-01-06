<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PasswordRecovery.ascx.cs" Inherits="UCENTRIK.UserControls.Controls.PasswordRecovery" %>






<table width="480px" cellpadding="0" cellspacing="0" border="0">

    <tr>
        <td align="right">
PasswordRecovery
        </td>
    </tr>

    <tr>
        <td align="right">
            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
        </td>
    </tr>


    <tr>
        <td align="right">

            <asp:Button ID="btnSend" runat="server"
                Text="Button"
                OnClick="btnSend_Click"
            />
        </td>
    </tr>


</table>

