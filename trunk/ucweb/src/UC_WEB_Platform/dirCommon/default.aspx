<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="UcentrikWeb.dirCommon._default" %>


<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Home" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">

    <table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0">

        
        <tr>
            <td align="center" valign="middle">
            
                <table width="640px" height="480px" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
            
                            <asp:Literal ID="ltHtml" runat="server"></asp:Literal>            
                
                        </td>
                    </tr>
                </table>        
                
                
            </td>
        </tr>
        
        
    </table>        
            
</asp:Content>
