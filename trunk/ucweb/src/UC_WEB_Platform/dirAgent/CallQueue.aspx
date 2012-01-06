<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true"
    CodeBehind="CallQueue.aspx.cs" Inherits="UcentrikWeb.dirAgent.IncidentQueue" %>

<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Incident" Src="../App_Controls/BusinessControls/Incident.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="UCTXControls" Src="../App_Controls/ConferenceControls/UCTXControls.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="IncidentProfile" Src="../App_Controls/BusinessControls/IncidentProfile.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>
<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Call Queue" />
</asp:Content>
<asp:Content ID="ContentUCTXControls" ContentPlaceHolderID="UCTXControls" runat="server">
    <ucentrik:UCTXControls ID="uctxControls" runat="server" Visible="false" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    <asp:Panel ID="pnlIncident" runat="server" Visible="false">
        <ucentrik:Incident ID="ucIncident" runat="server" AllowDelete="false" AllowSort="false"
            AllowConference="true" ReadOnly="false" UcDataSourceSelectMethod="GetIncidentQueueList"
            SortExpression="" SortDirection="Descending" OnProfileOpen="ucIncident_IncidentOpen"
            OnBackToList="ucIncident_BackToList" />
    </asp:Panel>
    <asp:Panel ID="pnlIncidentProfile" runat="server" Visible="false">
        <ucentrik:IncidentProfile ID="ucIncidentProfile" runat="server" AllowDelete="false"
            AllowSort="false" AllowConference="true" ReadOnly="false" OnProfileSaveButton="view_Save"
            OnProfileBackButton="view_Back" />
    </asp:Panel>
    <asp:Panel ID="pnlError" runat="server" Visible="false">
        ERROR
    </asp:Panel>
</asp:Content>
