using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.Helpers;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.AppSettings;
using UCENTRIK.DATASETS;

using UCENTRIK.LIB.Model;

using UCENTRIK.ROUTING;
using UCENTRIK.LIB.CoreSystem;
using UCENTRIK.WEB.PLATFORM;


namespace UcentrikWeb.dirAgent
{
    public partial class followupincidents : UcAppBasePage
    {



        ///---------------------------------------------------------------------------------
        protected Int32 agentId
        {
            get
            {
                Int32 _agentId = 0;
                Object objViewStateAgentId = this.ViewState[this.ID + "AgentId"];
                if (objViewStateAgentId != null)
                    _agentId = Convert.ToInt32(objViewStateAgentId);

                return _agentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "AgentId");
                this.ViewState.Add(this.ID + "AgentId", value);
            }
        }


        ///---------------------------------------------------------------------------------
        protected Int32 incidentId
        {
            get
            {
                Int32 _incidentId = 0;
                Object objViewStateIncidentId = this.ViewState[this.ID + "IncidentId"];
                if (objViewStateIncidentId != null)
                    _incidentId = Convert.ToInt32(objViewStateIncidentId);

                return _incidentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IncidentId");
                this.ViewState.Add(this.ID + "IncidentId", value);
            }
        }








        protected override void updateContent()
        {
            pnlIncident.Visible = true;
            //pnlIncidentProfile.Visible = false;
            pnlError.Visible = false;

            filterIncidents();
        }




        protected void Page_Init(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                this.allowTimerUpdate = true;
        }



        protected void Page_Load(object sender, EventArgs e)
        {


            if (!this.Page.IsPostBack)
            {
                this.agentId = ProxyHelper.GetUserAgentId(this.UserId);


                //object obj = Request.QueryString["incidentId"];
                //if (obj != null)
                //{
                //    UcControlArgs args = new UcControlArgs();

                //    Int32 i = 0;
                //    if (Int32.TryParse(obj.ToString(), out i))
                //    {
                //        this.incidentId = i;
                //        string msg = "";
                //        bool success = openFollowUpIncident(this.incidentId, this.agentId, out msg);
                //        ucIncidentProfile.IncidentId = this.incidentId;
                //        pnlIncident.Visible = false;
                //        pnlIncidentProfile.Visible = true;
                //        pnlError.Visible = false;
                //    }
                //    else
                //    {
                //        this.incidentId = 0;

                //        pnlIncident.Visible = false;
                //        pnlIncidentProfile.Visible = false;
                //        pnlError.Visible = true;
                //    }

                //}
                //else
                //{
                //    pnlIncident.Visible = true;
                //    pnlIncidentProfile.Visible = false;
                //    pnlError.Visible = false;

                //    filterIncidents();
                //}


                pnlIncident.Visible = true;
                pnlError.Visible = false;
                filterIncidents();

            }
        }






        ///---------------------------------------------------------------------------------
        protected void Page_PreRender(object sender, EventArgs e)
        {

        }


        protected void filterIncidents()
        {
            Int32 statusId = 5; // Follow-Up

            ucIncident.UcDataBind(statusId, this.agentId);
            //ucIncident.UcDataBind(statusId, 0);
        }




















        protected void ucIncident_IncidentOpen(object sender, UcControlArgs e)
        {
            string msg = "";
            Int32 incidentId = e.Id;
            Int32 agentId = ProxyHelper.GetUserAgentId(this.UserId);


            bool success = openFollowUpIncident(incidentId, agentId, out msg);
            e.Cancel = !success;
            e.Message = msg;
        }




        protected void ucIncident_BackToList(object sender, EventArgs e)
        {
            Int32 agentId = ProxyHelper.GetUserAgentId(this.UserId);

            AgentPool agentPool = (AgentPool)Application["AgentPool"];
            agentPool.SetAgentBusy(agentId, false);

            //this.hideVideo();


            allowTimerUpdate = true;

        }








        protected void view_Save(object sender, EventArgs e)
        {
            AgentPool agentPool = (AgentPool)Application["AgentPool"];
            agentPool.SetAgentBusy(agentId, false);

            Response.Redirect("CallQueue.aspx");
        }
        protected void view_Back(object sender, EventArgs e)
        {
            Response.Redirect("CallQueue.aspx");
        }





//        protected void showVideo(Int32 incidentId)
//        {
//            Guid guid = new Guid();
//            string agentName = "";

//            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(incidentId);
//            if (dt.Rows.Count != 0)
//            {
//                guid = dt[0].incident_guid;
//                agentName = dt[0].agent_full_name;
//            }



//            String conferenceName = guid.ToString();




//            ((UcMasterPage)this.Master).ShowVideoChat(incidentId, conferenceName, agentName, "Agent");
//        }
//        protected void hideVideo()
//        {
//            Session[Utility.ConferenceStartupParametersSessionVariableName] = null;

//            //==========================================================================
//            //((SosMasterPage)this.SosPage.Master).ShowVideoChat(parameters);
//            ((UcMasterPage)this.Master).HideVideoChat();

//        }






        protected bool openFollowUpIncident(Int32 incidentId, Int32 agentId, out string msg)
        {
            bool success = IncidentPlatformHelper.OpenFollowUpIncident(incidentId, agentId, out msg);
            if (success)
            {
                //this.showVideo(incidentId);
                allowTimerUpdate = false;
                msg = "";
            }
            else
            {
                filterIncidents();
            }

            return success;
        }






        //---
    }
}

