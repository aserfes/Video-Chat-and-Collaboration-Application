<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KioskAccessDenied.ascx.cs" Inherits="UCENTRIK.WEB.KIOSK.Controls.Common.KioskAccessDenied" %>


    <table width="100%" cellpadding="0" cellspacing="0" border="1">
        <tr height="125px" align="center">
            
            <td>ACCESS DENIED!</td>
            
        </tr>
        
        <tr align="center">
            
            <td>
                <asp:Button ID="btnLogin" runat="server" Text="Re-Login"
                    Width="100px"
                    onclick="btnLogin_Click" 
                    />
            </td>
            
        </tr>
        
    </table>
