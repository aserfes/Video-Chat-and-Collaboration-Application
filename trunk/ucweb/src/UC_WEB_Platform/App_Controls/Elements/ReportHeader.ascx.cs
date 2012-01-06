using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

using UCENTRIK.LIB.Base;





namespace UCENTRIK.WEB.PLATFORM.App_Controls.Elements
{
    public partial class ReportHeader : UcAppBaseControl
    {






//        ///---------------------------------------------------------------------------------
        public event UcReportEventHandler GenerateReport;
        protected void generateReport(object sender, UcReportArgs e)
        {
            if (GenerateReport != null)
                GenerateReport(this, e);
        }
//        ///---------------------------------------------------------------------------------









        //public string ReportMessage
        //{
        //    set
        //    {
        //        lblMessage.Text = value;
        //    }
        //}









        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            if (!this.IsPostBack)
            {
                datePickerStart.Date = DateTime.Now.AddMonths(-3);
                datePickerEnd.Date = DateTime.Now;
            }
        }






        protected void ddlGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

       

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            Int32 group = Convert.ToInt32(ddlGroup.SelectedValue);
            DateTime start = datePickerStart.Date;
            DateTime end = datePickerEnd.Date;


            if (start <= end)
            {
                if (end.Subtract(start).Days < 365)
                {
                    UcReportArgs args = new UcReportArgs();
                    args.Group = group;
                    args.Start = start;
                    args.End = end;
                    this.generateReport(this, args);
                }
                else
                {
                    lblMessage.Text = "The reporting period is too long";
                }
            }
            else
            {
                lblMessage.Text = "Start date cannot be greater than End date";
            }
        }
    

    }
}