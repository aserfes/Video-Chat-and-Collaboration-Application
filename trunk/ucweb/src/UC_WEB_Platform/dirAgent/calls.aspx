<%@ Page Title="" Language="C#" MasterPageFile="~/UcMasterPage.Master" AutoEventWireup="true" CodeBehind="calls.aspx.cs" Inherits="UcentrikWeb.dirAgent.incident" %>


<%@ Register TagPrefix="ucentrik" TagName="Title" Src="../App_Controls/CommonControls/PageTitle.ascx" %>
<%@ Register TagPrefix="ucentrik" TagName="Incident" Src="../App_Controls/BusinessControls/Incident.ascx" %>



<asp:Content ID="Content1" ContentPlaceHolderID="headContent" runat="server">
</asp:Content>


<asp:Content ID="phControls" ContentPlaceHolderID="ControlsPlaceHolder" runat="server">

    <asp:Panel ID="pnlPageHeader" runat="server">
	<table width="100%" height="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
			<tr>
			    <td>
			        Status:
			    </td>
				<td>
                    <asp:DropDownList ID="ddlIncidentStatus" Runat="server"
                        AutoPostBack="true"
                        Width="200"
                        DataTextField="incident_status_name"
                        DataValueField="incident_status_id"
                        OnSelectedIndexChanged="ddlIncident_SelectedIndexChanged"
                        >
                    </asp:DropDownList>
				</td>
			</tr>
    </table>
    </asp:Panel>

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <ucentrik:Title ID="PageTitle" runat="server" Title="Call History" />
</asp:Content>






<asp:Content ID="Content3" ContentPlaceHolderID="OperatingPlaceHolder" runat="server">
    
    <table width="100%" height="100%" align="center" cellSpacing="0" cellPadding="0" border="0">
        <tr>
            <td valign="top">

                <ucentrik:Incident ID="ucIncident" runat="server"
                    UcDataSourceSelectMethod="GetIncidentsByStatus"
                    AllowDelete="false"
                    ReadOnly="true"
                    
                    SortExpression="incident_id"
                    SortDirection="Descending"
                />

            </td>
        </tr>
    </table>

  
    
</asp:Content>
