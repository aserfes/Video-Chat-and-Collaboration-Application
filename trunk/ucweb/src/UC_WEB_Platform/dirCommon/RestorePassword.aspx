<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RestorePassword.aspx.cs"
    Inherits="UcentrikWeb.dirCommon.RestorePassword" %>

<%@ Register TagPrefix="ucentrik" TagName="RestorePassword" Src="../App_Controls/CommonControls/RestorePassword.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Restore Password</title>
    <link rel="stylesheet" type="text/css" href="<%= this.ResolveClientUrl("~/dirStyle/LogIn/style.css") %>" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <div id="logo">
            <img src="<%= this.ResolveClientUrl("~/dirStyle/LogIn/i/ucentrik-logo.png") %>" alt="logo" />
        </div>
    </div>
    <div id="content">
        <ucentrik:RestorePassword ID="ucRestorePasswordControl" runat="server" LoginPageUrl="~/dirCommon/LogIn.aspx" />
    </div>
    <div id="footer">
        <div id="copyright">
            Copyright Ucentrik Inc. 2011</div>
    </div>
    </form>
</body>
</html>
