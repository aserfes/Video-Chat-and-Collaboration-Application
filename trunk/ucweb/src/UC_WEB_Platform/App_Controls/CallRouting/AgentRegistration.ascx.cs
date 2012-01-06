using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.AppSettings;
using UCENTRIK.ROUTING;



using UCENTRIK.DATASETS;
using UCENTRIK.LIB.CoreSystem;


namespace UcentrikWeb.App_Controls.CallRouting
{
    public partial class AgentRegistration : UcAppBaseControl
    {
        protected AgentPool agentPool;


        protected enum enumAgentStatus
        {
            NotDefined = 0,
            Available = 1,
            Unavailable = 2,
            Busy = 3,
            IncomingCall = 4
        }






        public bool IsOnline
        {
            get
            {
                return this.isOnline;
            }
        }
        protected bool isOnline
        {
            get
            {
                bool _isOnline = false;
                Object objViewStateIsOnline = this.ViewState[this.ID + "IsOnline"];
                if (objViewStateIsOnline != null)
                    _isOnline = Convert.ToBoolean(objViewStateIsOnline);

                return _isOnline;
            }
            set
            {
                this.ViewState.Remove(this.ID + "IsOnline");
                this.ViewState.Add(this.ID + "IsOnline", value);
            }
        }







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






        public Int32 CurrentIncidentId
        {
            get
            {
                return this.currentIncidentId;
            }
            set
            {
                this.currentIncidentId = value;
            }
        }
        protected Int32 currentIncidentId
        {
            get
            {
                Int32 _currentIncidentId = 0;
                Object objViewStateCurrentIncidentId = this.ViewState[this.ID + "CurrentIncidentId"];
                if (objViewStateCurrentIncidentId != null)
                    _currentIncidentId = Convert.ToInt32(objViewStateCurrentIncidentId);

                return _currentIncidentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "CurrentIncidentId");
                this.ViewState.Add(this.ID + "CurrentIncidentId", value);
            }
        }







        protected bool active = false;
        public bool Active
        {
            set
            {
                active = value;
                this.Visible = active;
            }
        }


        public bool UpdateAgentStatus()
        {
            this.updateAgentStatus();

            return this.active;
        }





        
        protected void Page_Init(object sender, EventArgs e)
        {
            agentPool = (AgentPool)Application["AgentPool"];
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (active)
            {
                if ((!this.Page.IsPostBack) || (agentId == 0))
                    agentId = ProxyHelper.GetUserAgentId(this.UcAppPage.UserId);
                updateAgentStatus();
            }

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
        }
















        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (agentId == 0)
            {
                string path = AppHelper.GetApplicationPath("~/dirAgent/profile.aspx");
                Response.Redirect(path);
            }
            else
            {
                agentPool.RegisterAgent(agentId);
                updateAgentStatus();
            }
        }
        protected void btnTakeCall_Click(object sender, EventArgs e)
        {
            Int32 incidentId = agentPool.GetAgentIncident(agentId);
            
            agentPool.SetAgentBusy(agentId, true);

            updateAgentStatus();

            string path = AppHelper.GetApplicationPath("~/dirAgent/CallQueue.aspx?incidentId=" + incidentId.ToString());
            Response.Redirect(path);
        }
        protected void btnReset_Click(object sender, EventArgs e)
        {
            agentPool.UnRegisterAgent(agentId);
            updateAgentStatus();
        }
        protected void btnSetAvailable_Click(object sender, EventArgs e)
        {
            if (agentId == 0)
            {
                string path = AppHelper.GetApplicationPath("~/dirAgent/profile.aspx");
                Response.Redirect(path);
            }
            else
            {
                agentPool.SetAgentOn(agentId);

                enumAgentStatus agentStatus = updateAgentStatus();

                if (agentStatus == enumAgentStatus.Busy)
                {
                    //string pathRedirect = AppHelper.GetApplicationPath("~/dirAgent/myCalls.aspx");
                    //string path0 = AppHelper.GetApplicationPath("~/dirAgent/CallQueue.aspx");
                    //string path1 = AppHelper.GetApplicationPath("~/dirAgent/myCalls.aspx");
                    //string url = this.UcAppPage.Request.Url.ToString();
                    //if((!url.Contains(path0)) && (!url.Contains(path1)))
                    //    Response.Redirect(pathRedirect);


                    string path = AppHelper.GetApplicationPath("~/dirAgent/myCalls.aspx");
                    string url = this.UcAppPage.Request.Url.ToString();
                    if(!url.Contains(path))
                        Response.Redirect(path);
                }
            }
        }


        protected void btnUnRegister_Click(object sender, EventArgs e)
        {
            agentPool.SetAgentOff(agentId);
            updateAgentStatus();
        }





















        protected enumAgentStatus updateAgentStatus()
        {
            enumAgentStatus agentStatus = enumAgentStatus.NotDefined;



            if (this.active)
            {


                pnlNotRegistered.Visible = false;
                pnlIncomingCall.Visible = false;
                pnlUnavailable.Visible = false;
                pnlBusy.Visible = false;
                pnlConnected.Visible = false;
                pnlAvailable.Visible = false;


                btnRegister.Visible = false;
                btnTakeCall.Visible = false;
                btnSetAvailable.Visible = false;
                btnReset.Visible = false;
                btnUnRegister.Visible = false;





                if (agentId == 0)
                {
                    // Not Defined
                    agentStatus = enumAgentStatus.NotDefined;

                    pnlNotRegistered.Visible = true;
                    ltMessage.Text = "Not registered";
                    btnRegister.Visible = true;
                }
                else
                {

                    PoolDS.PoolDSDataTable dt = BllProxyPool.SelectPoolAgent(agentId);
                    if (dt.Rows.Count != 0)
                    {

                        if (dt[0].is_available)
                        {

                            if (dt[0].is_busy)
                            {

                                if (!dt[0].Isincident_idNull())
                                {
                                    // Incoming Call
                                    agentStatus = enumAgentStatus.IncomingCall;

                                    Int32 incidentId = dt[0].incident_id;
                                    IncidentDS.IncidentDSDataTable dtIncident = BllProxyIncident.SelectIncident(incidentId);
                                    
                                    string callName = "";
                                    if (!dtIncident[0].Isfacility_nameNull())
                                    {
                                        callName = dtIncident[0].facility_name;
                                    }
                                    else
                                    {
                                        if (!dtIncident[0].Iscontact_full_nameNull())
                                        {
                                            callName = dtIncident[0].contact_full_name;
                                        }
                                        else
                                        {
                                            callName = "UNKNOWN";
                                        }
                                    }


                                    //    Incident Assigned
                                    pnlIncomingCall.Visible = true;
                                    ltMessage.Text = "You’ve got a call : " + callName;
                                    
                                    btnTakeCall.Visible = true;

                                    

                                }
                                else
                                {
                                    //  Busy
                                    agentStatus = enumAgentStatus.Busy;


                                    if (this.checkOnline())
                                    {
                                        pnlConnected.Visible = true;
                                        pnlBusy.Visible = false;
                                        ltMessage.Text = "Online";
                                    }
                                    else
                                    {
                                        pnlBusy.Visible = true;
                                        pnlConnected.Visible = false;
                                        ltMessage.Text = "Offline";
                                        btnReset.Visible = true;
                                    }
                                }

                            }
                            else
                            {
                                //  Available
                                agentStatus = enumAgentStatus.Available;

                                pnlAvailable.Visible = true;
                                ltMessage.Text = "Available";
                                btnUnRegister.Visible = true;
                            }
                        }
                        else
                        {
                            //  Off
                            agentStatus = enumAgentStatus.Unavailable;

                            if (this.checkOnline())
                            {
                                pnlConnected.Visible = true;
                                ltMessage.Text = "Online";
                            }
                            else
                            {
                                pnlUnavailable.Visible = true;
                                ltMessage.Text = "Unavailable";
                                btnSetAvailable.Visible = true;
                            }
                            


                        }

                    }
                    else
                    {
                        //  Not Defined
                        agentStatus = enumAgentStatus.NotDefined;

                        pnlNotRegistered.Visible = true;
                        ltMessage.Text = "Not registered";
                        btnRegister.Visible = true;
                    }
                }
            }



            return agentStatus;
        }







        protected bool checkOnline()
        {
            bool _isOnline = false;

            if (this.currentIncidentId != 0)
            {
                bool checkState = BllProxyIncidentState.SetIncidentState0(this.currentIncidentId, UcConfParameters.UcPageRefreshInterval);
                if (checkState)
                    _isOnline = true;
            }

            this.isOnline = _isOnline;
            return this.isOnline;
        }


    }
}