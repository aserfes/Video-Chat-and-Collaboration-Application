<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="users.aspx.cs" Inherits="UcentrikWeb.dirAdmin.users" %>


<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="User" Src="../App_Controls/BusinessControls/User.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">

        <asp:DropDownList ID="ddlUserRoles" Runat="server"
            AutoPostBack="true"
            Width="200"
            DataTextField="user_role_name"
            DataValueField="user_role_id"
            OnSelectedIndexChanged="ddlUserRoles_SelectedIndexChanged"
            >
        </asp:DropDownList>

</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="User management" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    
    <ucentrik:User ID="sosUser" runat="server"
        UcDataSourceSelectMethod="GetUsersByRole"
        AllowDelete="true"
        ReadOnly="false"
        SortExpression="date_last_login"
        SortDirection="Descending"
    />
    
</asp:Content>
