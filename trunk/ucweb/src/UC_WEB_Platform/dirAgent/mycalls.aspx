<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true"
    CodeBehind="myincidents.aspx.cs" Inherits="UcentrikWeb.dirAgent.myincidents" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Incident" Src="../App_Controls/BusinessControls/Incident.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="UCTXControls" Src="../App_Controls/ConferenceControls/UCTXControls.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentUCTXControls" ContentPlaceHolderID="UCTXControls" runat="server">
    <ucentrik:UCTXControls ID="uctxControls" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="My Calls" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    <table width="100%" height="100%" align="center" cellspacing="0" cellpadding="0"
        border="0">
        <tr>
            <td valign="top">
                <ucentrik:Incident ID="ucIncident" runat="server" UcDataSourceSelectMethod="GetIncidentsByStatus"
                    SortExpression="incident_id" SortDirection="Descending" AllowDelete="false" AllowSort="false"
                    AllowConference="true" ReadOnly="false" OnProfileOpen="ucIncident_IncidentOpen"
                    OnBackToList="ucIncident_BackToList" />
            </td>
        </tr>
    </table>
</asp:Content>
