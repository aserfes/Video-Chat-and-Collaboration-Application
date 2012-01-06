using System;
using Microsoft.Reporting.WebForms;


using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;





namespace SosWeb.App_Controls.ReportControls
{
    public partial class IncidentReport : UcAppReportBaseControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                pnlEmpty.Visible = true;
                pnlReportViewer.Visible = false;
            }
        }

        protected void generateReport(Int32 group, DateTime start, DateTime end)
        {
            TimeZone localZone = TimeZone.CurrentTimeZone;

            end = end.AddDays(1);

            ReportDS.ReportIncidentDSDataTable dt = BllProxyReport.GetIncidentReport(localZone, group, start, end);

            ReportDataSource reportDataSource = new ReportDataSource("ReportIncidentDS", dt.DefaultView);


            this.repviewIncidentDetails.LocalReport.DataSources.Clear();
            this.repviewIncidentDetails.LocalReport.DataSources.Add(reportDataSource);
            this.repviewIncidentDetails.LocalReport.Refresh();



            pnlEmpty.Visible = false;
            pnlReportViewer.Visible = true;
        }

        protected void reportHeader_GenerateReport(object sender, UcReportArgs e)
        {
            this.generateReport(e.Group, e.Start, e.End);
        }



    }
}
