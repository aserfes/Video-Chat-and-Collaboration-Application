<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="downloads.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirUser.downloads" %>



<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Downloads" />
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">


    <table width="100%" height="320px" align="center" cellSpacing="0" cellPadding="0" border="0">
        
        <tr>
            <td align="left" valign="top">
            
                <asp:HyperLink ID="hlDownloadDriver" runat="server"
                    Text="Ucentrik ViewCaster Adapter"
                    NavigateUrl="../downloads/setup.exe"
                >
                </asp:HyperLink>
                
            </td>
        </tr>
            
    </table>

    
</asp:Content>

