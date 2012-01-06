<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="contacts.aspx.cs" Inherits="UcentrikWeb.dirAdmin.contacts" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Contact" Src="../App_Controls/BusinessControls/Contact.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">


        <asp:DropDownList ID="ddlContact" Runat="server"
            AutoPostBack="true"
            Width="200"
            DataTextField="user_role_name"
            DataValueField="user_role_id"
            OnSelectedIndexChanged="ddlContactStatus_SelectedIndexChanged"
            >
        </asp:DropDownList>


</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Contacts" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    
    <ucentrik:Contact ID="sosContact" runat="server"
        UcDataSourceSelectMethod="GetAllContacts"
        AllowDelete="true"
        ReadOnly="false"
        SortExpression="date_last_login"
        SortDirection="Descending"
        
        OnB
    />
    
</asp:Content>
