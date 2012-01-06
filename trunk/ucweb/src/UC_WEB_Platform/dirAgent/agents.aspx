<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="agents.aspx.cs" Inherits="UcentrikWeb.dirAgent.agents" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Agent" Src="../App_Controls/BusinessControls/Agent.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">


        <asp:DropDownList ID="ddlAgent" Runat="server"
            AutoPostBack="true"
            Width="200"
            DataTextField="user_role_name"
            DataValueField="user_role_id"
            OnSelectedIndexChanged="ddlAgentStatus_SelectedIndexChanged"
            >
        </asp:DropDownList>


</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Agent management" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    
    <ucentrik:Agent ID="sosAgent" runat="server"
        UcDataSourceSelectMethod="GetAllAgents"
        AllowDeleting="false"
        ReadOnly="true"
        SortExpression="date_last_login"
        SortDirection="Descending"
    />
    
</asp:Content>
