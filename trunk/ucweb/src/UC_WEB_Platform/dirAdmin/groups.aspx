<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="groups.aspx.cs" Inherits="UcentrikWeb.dirAdmin.groups" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Group" Src="../App_Controls/BusinessControls/Group.ascx" %>

<%@ Register TagPrefix="ucentrik" TagName="GroupAgent" Src="../App_Controls/BusinessControls/GroupAgent.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="GroupFacility" Src="../App_Controls/BusinessControls/GroupFacility.ascx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">


</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Groups" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">



    <asp:MultiView ID="mvGroup" runat="server"
        ActiveViewIndex="0"
        OnActiveViewChanged="mvGroup_ActiveViewChanged"
        >

        <asp:View ID="ViewGroupList" runat="server">
            <ucentrik:Group ID="sosGroup" runat="server"
                UcDataSourceSelectMethod="GetGroupList"
                AllowDelete="true"
                AllowManagement="true"
                ReadOnly="false"
                SortExpression="group_name"
                SortDirection="Ascending"

                OnManageAgents="sosGroup_ManageAgents"
                OnManageFacilities="sosGroup_ManageFacilities"
            />
        </asp:View>

        <asp:View ID="ViewGroupAgentList" runat="server">
            <ucentrik:GroupAgent ID="GroupAgent" runat="server"
                
                UcDataSourceSelectMethod="GetAllGroupAgents"
                
                SortExpression="full_name"
                SortDirection="Ascending"
                
                OnBackToList="sosGroup_Back"
            />
        </asp:View>
        
        <asp:View ID="ViewGroupFacilityList" runat="server">
            <ucentrik:GroupFacility ID="GroupFacility" runat="server"
                
                UcDataSourceSelectMethod="GetAllGroupFacilities"
                
                SortExpression="facility_name"
                SortDirection="Ascending"
                
                OnBackToList="sosGroup_Back"
            />
            
        </asp:View>




    </asp:MultiView> 


    
    
</asp:Content>
