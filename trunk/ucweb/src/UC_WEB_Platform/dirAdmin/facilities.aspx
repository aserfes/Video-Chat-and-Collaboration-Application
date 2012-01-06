<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="facilities.aspx.cs" Inherits="UcentrikWeb.dirAdmin.facilities" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Facility" Src="../App_Controls/BusinessControls/Facility.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="FacilityGroup" Src="../App_Controls/BusinessControls/FacilityGroup.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>

<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">

    <asp:CheckBox ID="chkboxActive" runat="server"
        Text="Active"
    />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Facilities" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">

    <asp:MultiView ID="mvFacility" runat="server"
        ActiveViewIndex="0"
        OnActiveViewChanged="mvFacility_ActiveViewChanged"
        >

        <asp:View ID="ViewGroupList" runat="server">
            <ucentrik:Facility ID="sosFacility" runat="server"
                UcDataSourceSelectMethod="GetAllFacilities"
                AllowDelete="true"
                AllowManagement="true"
                ReadOnly="false"
                SortExpression="facility_name"
                SortDirection="Descending"
                
                OnManageGroups="sosFacility_ManageGroups"
            />
        </asp:View>

        <asp:View ID="ViewFacilityGroupList" runat="server">
            <ucentrik:FacilityGroup ID="FacilityGroup" runat="server"
                
                UcDataSourceSelectMethod="GetAllFacilityGroups"
                
                SortExpression="group_name"
                SortDirection="Ascending"
                
                OnBackToList="sosFacility_Back"
            />
        </asp:View>
        
    </asp:MultiView> 

</asp:Content>

