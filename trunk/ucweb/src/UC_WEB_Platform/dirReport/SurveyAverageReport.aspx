<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="SurveyAverageReport.aspx.cs" Inherits="SosWeb.dirReport.SurveyAverageReport" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="ReportSurveyAverage" Src="../App_Controls/ReportControls/SurveyAverageReport.ascx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>
 






<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Survey Average Report" />
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    <ucentrik:ReportSurveyAverage ID="ReportSurveyAverage" runat="server" />
</asp:Content>

