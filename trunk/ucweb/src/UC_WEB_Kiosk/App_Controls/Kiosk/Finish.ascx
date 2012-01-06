<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Finish.ascx.cs" Inherits="UCENTRIK.WEB.KIOSK.Connect.Finish" %>
<table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
    border="0">
    <tr height="50px">
        <td align="center" valign="middle">
            <asp:Label ID="Label1" runat="server" Text="A call if finished.<BR>
                                        We hope that our service was useful to you<BR>
Thank you for calling!" Width="300px"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="center" valign="middle">
            <input type="button" value="Exit" onclick="window.close()" />
        </td>
    </tr>
</table>
