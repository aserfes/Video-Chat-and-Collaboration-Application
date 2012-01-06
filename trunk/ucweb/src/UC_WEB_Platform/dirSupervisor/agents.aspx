<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="agents.aspx.cs" Inherits="UcentrikWeb.dirSupervisor.agents" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Agent" Src="../App_Controls/BusinessControls/Agent.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentGroup" Src="../App_Controls/BusinessControls/AgentGroup.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentSkills" Src="../App_Controls/BusinessControls/AgentSkills.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="AgentLanguages" Src="../App_Controls/BusinessControls/AgentLanguages.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Agents" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">

    <asp:MultiView ID="mvAgent" runat="server"
        ActiveViewIndex="0"
        OnActiveViewChanged="mvAgent_ActiveViewChanged"
        >

        <asp:View ID="ViewGroupList" runat="server">
            <ucentrik:Agent ID="sosAgent" runat="server"
                UcDataSourceSelectMethod="GetAllAgents"
                AllowDelete="true"
                AllowManagement="true"
                ReadOnly="false"
                SortExpression="full_name"
                SortDirection="Ascending"
                
                OnManageGroups="sosAgent_ManageGroups"
                OnManageSkills="sosAgent_ManageSkills"
                OnManageLanguages="sosAgent_ManageLanguages"
            />
        </asp:View>

        <asp:View ID="ViewAgentGroupList" runat="server">
            <ucentrik:AgentGroup ID="AgentGroup" runat="server"
                
                UcDataSourceSelectMethod="GetAllAgentGroups"

                AllowManagement="true"
                
                SortExpression="group_name"
                SortDirection="Ascending"
                
                OnBackToList="sosAgent_Back"
            />
        </asp:View>

        <asp:View ID="ViewAgentSkillList" runat="server">
            <ucentrik:AgentSkills ID="AgentSkills" runat="server"
                
                UcDataSourceSelectMethod="GetAllAgentSkills"

                AllowManagement="true"

                SortExpression="skill_name"
                SortDirection="Ascending"
                
                OnBackToList="sosAgent_Back"
            />
        </asp:View>

         <asp:View ID="View1" runat="server">
            <ucentrik:AgentLanguages ID="AgentLanguages" runat="server"
                
                UcDataSourceSelectMethod="GetAllAgentLanguages"

                AllowManagement="true"

                SortExpression="language_name"
                SortDirection="Ascending"
                
                OnBackToList="sosAgent_Back"
            />
        </asp:View>

        
    </asp:MultiView> 
    
</asp:Content>
