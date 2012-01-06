<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="Languages.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirAdmin.languages" %>

<%@ Register TagPrefix="ucentrik" TagName="Language" Src="../App_Controls/BusinessControls/Language.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="LanguageAgent" Src="../App_Controls/BusinessControls/LanguageAgent.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    <asp:MultiView ID="mvGroup" runat="server"
        ActiveViewIndex="0"
        >
        <asp:View ID="ViewLanguageList" runat="server">
            <ucentrik:Language ID="Language" runat="server"
                UcDataSourceSelectMethod="GetLanguageList"
                AllowDelete="true"
                AllowManagement="true"
                ReadOnly="false"
                SortExpression="language_name"
                SortDirection="Ascending"

                OnManageAgents="Language_ManageAgents"
            />
        </asp:View>
        <asp:View ID="ViewLanguageAgentList" runat="server">
            <ucentrik:LanguageAgent ID="LanguageAgent" runat="server"
                
                UcDataSourceSelectMethod="GetAllLanguageAgents"
                
                SortExpression="full_name"
                SortDirection="Ascending"
                
                OnBackToList="Language_Back"
            />
        </asp:View>
    </asp:MultiView> 
</asp:Content>
