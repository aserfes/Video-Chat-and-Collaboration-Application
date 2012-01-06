<%@ Page Title="" Language="C#" MasterPageFile="~/Kiosk.Master" AutoEventWireup="true"
    CodeBehind="UcKioskLogin.aspx.cs" Inherits="UCENTRIK.WEB.KIOSK.dirKiosk.UcKioskLogin" %>

<%@ Register TagPrefix="ucentrik" TagName="Logout" Src="../App_Controls/CommonControls/Logout.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="KioskContentPlaceHolder" runat="server">
    <ucentrik:Logout ID="sosLogout" runat="server" />
</asp:Content>
