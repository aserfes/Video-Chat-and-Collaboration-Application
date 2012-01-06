using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.LIB.Model;
using UCENTRIK.Helpers;
using UCENTRIK.LIB.CoreSystem;




namespace UCENTRIK.WEB.KIOSK.dirMobile
{
    public partial class pageConnect : System.Web.UI.Page
    {

        protected Int32 incidentId = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

            object obj = Request.QueryString["id"];
            if (obj != null)
            {
                Int32 i = 0;
                if (Int32.TryParse(obj.ToString(), out i))
                    this.incidentId = i;
            }


            if (this.incidentId != 0)
            {

                string agentName = "";
                string facilityName = "";
                string conferenceName = "";

                IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(incidentId);
                if (dt.Rows.Count != 0)
                {
                    conferenceName = dt[0].incident_guid.ToString();
                    facilityName = dt[0].facility_name;
                    agentName = dt[0].agent_full_name;
                }

                ConferenceStartupParameters parameters = ConferenceHelper.GetParametersForReceiver(conferenceName, agentName, facilityName);

                //ConfVideo.Parameters = parameters;

            }
            else
            {
                //BllProxyIncidentHelper.SetIncidentStatus(this.incidentId, 4);   // 4:Closed
                Response.Redirect("default.aspx");
            }





        }



        protected void btnDisconnect_Click(object sender, EventArgs e)
        {
            BllProxyIncidentHelper.SetIncidentStatus(this.incidentId, 3);   // 3:Canceled

            Response.Redirect("default.aspx");
        }



    }
}
