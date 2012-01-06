<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsyncUploadFile.aspx.cs" Inherits="UcentrikWeb.dirAgent.AsyncUploadFile"
EnableTheming = "False" StylesheetTheme="" Theme=""
%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Async File Uploading</title>
	<style type="text/css">
		body
		{
			background-color:ThreeDFace;
		}
		div
		{
			font-family: Verdana, Tahoma;
			font-size: 10px;
		}
	</style>
</head>
<body>
    <form id="form1" runat="server">
		<div id="SpanPathFileUpload"></div>
		<div id="SpanStatus"></div>
    </form>
</body>
</html>
