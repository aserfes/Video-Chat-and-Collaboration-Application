using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;





using System.Collections.Generic;

using UCENTRIK.Helpers;
using UCENTRIK.AppSettings;
using UCENTRIK.DATASETS;

using UCENTRIK.LIB.Model;

using UCENTRIK.ROUTING;
using UCENTRIK.LIB.CoreSystem;
using UCENTRIK.WEB.PLATFORM;



namespace UcentrikWeb.dirAgent
{
    public partial class myincidents : UcAppBasePage
    {

        private Int32 _agentId;

        protected void Page_Init(object sender, EventArgs e)
        {
            _agentId = ProxyHelper.GetUserAgentId(this.UserId);
            //ucIncident.AgentId = Helper.GetUserAgentId(this.UserId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //object obj = Request.QueryString["alert"];
            //if (obj != null)
            //{
            //    string code = obj.ToString();
            //    if (code == "oi")
            //        lblAlert.Text = "You have open incidents!";
            //}


            if (!this.Page.IsPostBack)
            {
                filterIncidents();
            }
        }


        protected void filterIncidents()
        {
            Int32 statusId = 2; // In-Progress
            ucIncident.UcDataBind(statusId, _agentId);
        }

















        protected void ucIncident_IncidentOpen(object sender, UcControlArgs e)
        {
            Int32 agentId = ProxyHelper.GetUserAgentId(this.UserId);
            Int32 incidentId = e.Id;

            IncidentHelper.SetIncidentStateActive(incidentId);

            this.showVideo(incidentId);
        }




        protected void ucIncident_BackToList(object sender, EventArgs e)
        {
            Int32 agentId = ProxyHelper.GetUserAgentId(this.UserId);

            AgentPool agentPool = (AgentPool)Application["AgentPool"];
            agentPool.SetAgentBusy(agentId, false);

            this.hideVideo();
        }






        protected void showVideo(Int32 incidentId)
        {
            Guid guid = new Guid();
            string agentName = "";

            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(incidentId);
            if (dt.Rows.Count != 0)
            {
                guid = dt[0].incident_guid;
                agentName = dt[0].agent_full_name;
            }



            String conferenceName = guid.ToString();



            //ConferenceStartupParameters parameters = new ConferenceStartupParameters();
            //parameters.VideoTransmitterMode = true;
            //parameters.VideoReceiverMode = false;
            //parameters.UseJavascript = true;
            //parameters.VideoWidth = 640;
            //parameters.VideoHeight = 480;
            //parameters.VideoFPS = 20;
            //parameters.VideoBandwidth = 56000;
            //parameters.VideoQuality = 80;
            //parameters.ScreenVideoWidth = 100;
            //parameters.ScreenVideoHeight = 100;
            //parameters.ConferenceName = conferenceName;
            //parameters.UserType = "Coach";
            //parameters.UserName = agentName;
            //parameters.ShouldCreateConference = true;
            //parameters.ShouldStartAppShare = true;
            //==========================================================================


            //ConferenceStartupParameters parameters = ConferenceHelper.GetParametersForTransmitter(conferenceName, agentName);

            //==========================================================================
            //((UcMasterPage)this.Master).ShowVideoChat(parameters);
            ((UcMasterPage)this.Master).ShowVideoChat(incidentId, conferenceName, agentName, "Agent");
            uctxControls.ShowVideoChat(incidentId, conferenceName, agentName, "Agent");
        }


        protected void hideVideo()
        {
            Session[Utility.ConferenceStartupParametersSessionVariableName] = null;

            //==========================================================================
            //((SosMasterPage)this.SosPage.Master).ShowVideoChat(parameters);
            uctxControls.HideVideoChat();
            ((UcMasterPage)this.Master).HideVideoChat();
            

        }







    }
}

