<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="followupcalls.aspx.cs" Inherits="UcentrikWeb.dirAgent.followupincidents" %>




<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Incident" Src="../App_Controls/BusinessControls/Incident.ascx" %>




<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>



<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">
</asp:Content>







<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Follow-Up" />
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">



        <asp:Panel ID="pnlIncident" runat="server"
            Visible="false"
            >
                <ucentrik:Incident ID="ucIncident" runat="server"
                    AllowDelete="false"
                    AllowSort="false"
                    AllowConference="false"
                    ReadOnly="false"
                    
                    UcDataSourceSelectMethod="GetIncidentFollowUpList"
                    SortExpression=""
                    SortDirection="Descending"
                    
                    OnProfileOpen="ucIncident_IncidentOpen"
                    OnBackToList="ucIncident_BackToList"
                />
        </asp:Panel>


        
        <asp:Panel ID="pnlError" runat="server"
            Visible="false"
            >
            ERROR
        </asp:Panel>
        
        
                        
    

</asp:Content>
