<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true"
    CodeBehind="profile.aspx.cs" Inherits="UcentrikWeb.dirAgent.profile" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentProfile" Src="../App_Controls/BusinessControls/AgentProfile.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentGroup" Src="../App_Controls/BusinessControls/AgentGroup.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentSkills" Src="../App_Controls/BusinessControls/AgentSkills.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentLanguages" Src="../App_Controls/BusinessControls/AgentLanguages.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="My Profile" />
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    <asp:MultiView ID="mvProfile" runat="server" ActiveViewIndex="0">
        <asp:View ID="ViewAgentProfile" runat="server">
            <ucentrik:AgentProfile ID="sosProfile" runat="server" ReadOnly="false" ShowBackButton="false"
                AllowManagement="true" OnProfileSaveButton="view_Save" OnProfileBackButton="view_Back"
                OnManageGroups="sosAgent_ManageGroups" OnManageSkills="sosAgent_ManageSkills"
                OnManageLanguages="sosAgent_ManageLanguages" />
        </asp:View>
        <asp:View ID="ViewAgentGroupList" runat="server">
            <ucentrik:AgentGroup ID="AgentGroup" runat="server" UcDataSourceSelectMethod="GetAllAgentGroups"
                AllowManagement="false" SortExpression="group_name" SortDirection="Ascending"
                OnBackToList="sosAgent_Back" />
        </asp:View>
        <asp:View ID="ViewAgentSkillList" runat="server">
            <ucentrik:AgentSkills ID="AgentSkills" runat="server" UcDataSourceSelectMethod="GetAllAgentSkills"
                AllowManagement="false" SortExpression="skill_name" SortDirection="Ascending"
                OnBackToList="sosAgent_Back" />
        </asp:View>
        <asp:View ID="ViewAgentSkillLanguages" runat="server">
            <ucentrik:AgentLanguages ID="AgentLanguages" runat="server" UcDataSourceSelectMethod="GetAllAgentLanguages"
                AllowManagement="false" SortExpression="language_name" SortDirection="Ascending"
                OnBackToList="sosAgent_Back" />
        </asp:View>
    </asp:MultiView>
</asp:Content>
