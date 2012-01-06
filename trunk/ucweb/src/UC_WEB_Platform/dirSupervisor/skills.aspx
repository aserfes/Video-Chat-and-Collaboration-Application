<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="skills.aspx.cs" Inherits="UCENTRIK.WEB.PLATFORM.dirAdmin.skills" %>

<%@ Register TagPrefix="ucentrik" TagName="Skill" Src="../App_Controls/BusinessControls/Skill.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="SkillAgent" Src="../App_Controls/BusinessControls/SkillAgent.ascx" %>

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
        <asp:View ID="ViewSkillList" runat="server">
            <ucentrik:Skill ID="Skill" runat="server"
                UcDataSourceSelectMethod="GetSkillList"
                AllowDelete="true"
                AllowManagement="true"
                ReadOnly="false"
                SortExpression="skill_name"
                SortDirection="Ascending"

                OnManageAgents="Skill_ManageAgents"
            />
        </asp:View>
        <asp:View ID="ViewSkillAgentList" runat="server">
            <ucentrik:SkillAgent ID="SkillAgent" runat="server"
                
                UcDataSourceSelectMethod="GetAllSkillAgents"
                
                SortExpression="full_name"
                SortDirection="Ascending"
                
                OnBackToList="Skill_Back"
            />
        </asp:View>
    </asp:MultiView> 
</asp:Content>
