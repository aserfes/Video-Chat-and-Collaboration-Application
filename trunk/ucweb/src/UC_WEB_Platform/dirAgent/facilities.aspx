<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="facilities.aspx.cs" Inherits="UcentrikWeb.dirAgent.facilities" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Facility" Src="../App_Controls/BusinessControls/Facility.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
	<script type="text/jscript">
	function ViewFacilityScreen( id )
	{
		window.open("scrs.aspx?id=" + id , "_blank", "status=yes,toolbar=no,menubar=no,location=no,scrollbars=no,resizable=yes");
	}
	</script>
</asp:Content>

<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Facilities" />
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    
    <ucentrik:Facility ID="sosFacility" runat="server"
        UcDataSourceSelectMethod="GetFacilitiesByAgent"
        AllowDelete="false"
        ReadOnly="true"
        SortExpression="facility_name"
        SortDirection="Descending"
    />
    
</asp:Content>
