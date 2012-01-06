<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pageConnect.aspx.cs" Inherits="UCENTRIK.WEB.KIOSK.dirMobile.pageConnect" %>



<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<html xmlns="http://www.w3.org/1999/xhtml" >




<head runat="server">
    <title>Ucentrik Mobile</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    


		<table width="320px" height="240px" align="center" cellSpacing="2" cellPadding="0" border="0">
			<tr>
				<td align="center" valign="middle" class="PageBody">


<%--<ucentrik:ConfVideo ID="ConfVideo" runat="server" />    --%>


				</td>
			</tr>
			
            <tr>
				<td align="center" valign="middle" class="PageBody">

                    <asp:button ID="btnDisconnect" runat="server"
                        text="Disconnect"
                        onclick="btnDisconnect_Click"
                    />
				
				</td>
			</tr>			
			
        </table>




    
    
    </div>
    </form>
</body>
</html>
