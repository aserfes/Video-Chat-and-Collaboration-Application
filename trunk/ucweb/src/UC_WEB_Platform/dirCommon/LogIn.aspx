<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="UcentrikWeb.dirCommon.LogIn" %>

<%@ Register TagPrefix="ucentrik" TagName="Login" Src="~/App_Controls/CommonControls/Login.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Log In</title>
    <link rel="stylesheet" type="text/css" href="<%= this.ResolveClientUrl("~/dirStyle/LogIn/style.css") %>" />
	<script type="text/jscript">
	window.onload = function(){ document.getElementById( "ucLogInControl_tbUserName" ).focus(); }
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <div id="logo">
            <img src="<%= this.ResolveClientUrl("~/dirStyle/LogIn/i/ucentrik-logo.png") %>" alt="logo" />
        </div>
    </div>
    <div id="content">
        <div id="content_title">
            <div id="content_title_left">
                <img src="<%= this.ResolveClientUrl("~/dirStyle/LogIn/i/castle.png") %>" alt="logo" /></div>
            <div id="content_title_right">
                Login</div>
        </div>
        <ucentrik:Login ID="ucLogInControl" runat="server" RestorePasswordUrl="~/dirCommon/RestorePassword.aspx"
            LogInUrl="~/dirCommon/default.aspx" OnLoggedIn="Login_LoggedIn" />
    </div>
    <div id="footer">
        <div id="copyright">
            Copyright Ucentrik Inc. 2011</div>
    </div>
    </form>
</body>
</html>
