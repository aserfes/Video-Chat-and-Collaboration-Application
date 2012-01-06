<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="settings.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirAdmin.settings" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>

<%@ Register TagPrefix="ucentrik" TagName="Settings" Src="../App_Controls/ASP/Settings.ascx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Settings" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">


    <table width="100%" height="100px" cellpadding="0" cellspacing="0" border="0">

        <tr>
            <td>
            </td>
        </tr>
        
        <tr>
            <td>
                <ucentrik:Settings ID="Settings" runat="server" />            
            </td>
        </tr>

    </table>
        
        
            
    
    
</asp:Content>
