<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirUser.account" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="UserAccount" Src="../App_Controls/CommonControls/UserAccount.ascx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="My Account" />
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">



    <table width="100%" cellpadding="0" cellspacing="0" border="0">

        <tr>
            <td>
            
                <ucentrik:UserAccount ID="ucUserAccount" runat="server"
                    ReadOnly="false"
                    ShowBackButton="false"
                    ShowFirstAndLastName="false"
                    
                    OnProfileSaveButton="view_Save"
                    OnProfileBackButton="view_Back"
                />
    
            </td>
        </tr>

    </table>
    
</asp:Content>






    
