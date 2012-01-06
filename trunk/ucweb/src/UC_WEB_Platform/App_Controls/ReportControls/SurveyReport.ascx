<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SurveyReport.ascx.cs" Inherits="SosWeb.App_Controls.ReportControls.SurveyReport" %>


<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<%@ Register TagPrefix="ucentrik" TagName="ReportHeader" Src="../Elements/ReportHeader.ascx" %>




<asp:Panel ID="pnlReport" runat="server"
    BorderWidth="1px"
    CssClass="Report"
>

    <table width="100%" height="100%" cellpadding="0" cellspacing="5" border="0">



          
        <tr height="10px">
            <td align="center" valign="middle" class="ReportHeader">
                
                <ucentrik:ReportHeader ID="reportHeader" runat="server"
                    OnGenerateReport="reportHeader_GenerateReport"
                />
                
            </td>
        </tr>
        
        

        <tr>
            <td align="center" valign="top" class="ReportBackground">

                <asp:Panel ID="pnlEmpty" runat="server"
                    height="800px"
                    Visible="false"
                >
                    <br />
                    <br />
                    <br />
                    <asp:Literal ID="ltEmpty" runat="server">
                        Select the Group, Start date and End date and click on "View Report" button to generate the report.
                    </asp:Literal>
                    <br />
                </asp:Panel>


                <asp:Panel ID="pnlReportViewer" runat="server"
                    height="800px"
                    Visible="false"
                >

                    <rsweb:ReportViewer ID="repviewIncidentDetails" runat="server"
                        Width="100%"
                        height="800px"

                        SizeToReportContent="true"
                        CssClass="ReportViewer"
                    >
                        <LocalReport
                            DisplayName="Survey Report"
                            ReportPath="App_Core/Reports/SurveyReport.rdlc"
                        >
                        </LocalReport>
                    </rsweb:ReportViewer>

                    
                </asp:Panel>                    

            </td>
        </tr>
        
    </table>

</asp:Panel>

