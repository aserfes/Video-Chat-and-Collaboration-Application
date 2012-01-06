using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;

using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

using UCENTRIK.LIB.App_Controls.ServerControls;



namespace UCENTRIK.WEB.PLATFORM.App_Controls.ASP
{
    public partial class TransferIncident : UcAppBaseProfileControl
    {




        public Int32 IncidentId
        {
            set
            {
                this.incidentId = value;


                this.agentId = 0;
                IncidentDS.IncidentDSDataTable dt = BllProxyIncident.SelectIncident(this.incidentId);
                if (dt.Rows.Count != 0)
                    if(!dt[0].Isagent_idNull())
                        this.agentId = dt[0].agent_id;


                this.clearMessage();
                this.Update();
            }
        }
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
        protected Int32 selectedAgentId
        {
            get
            {
                Int32 _selectedAgentId = 0;
                Object objViewStateSelectedAgentId = this.ViewState[this.ID + "SelectedAgentId"];
                if (objViewStateSelectedAgentId != null)
                    _selectedAgentId = Convert.ToInt32(objViewStateSelectedAgentId);

                return _selectedAgentId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SelectedAgentId");
                this.ViewState.Add(this.ID + "SelectedAgentId", value);
            }
        }



        public Int32 StatusId
        {
            set
            {
                this.statusId = value;
            }
        }

        protected new Int32 statusId
        {
            get
            {
                Int32 _statusId = 0;
                Object objViewStateStatusId = this.ViewState[this.ID + "StatusId"];
                if (objViewStateStatusId != null)
                    _statusId = Convert.ToInt32(objViewStateStatusId);

                return _statusId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "StatusId");
                this.ViewState.Add(this.ID + "StatusId", value);
            }
        }





        public bool Update()
        {
            PoolDS.PoolDSDataTable dt = BllProxyPool.GetAllPoolAgents();
            PoolDS.PoolDSRow[] rows = (PoolDS.PoolDSRow[])dt.Select("", "agent_full_name");

            
            rptAgentPool.DataSource = rows;
            rptAgentPool.DataBind();



            foreach (RepeaterItem item in rptAgentPool.Items)
            {
                UcGroupRadioButton ucGroupRadioButton = (UcGroupRadioButton)item.FindControl("ucGroupRadioButton");

                if (ucGroupRadioButton != null)
                {
                    ucGroupRadioButton.Checked = false;
 
                    HiddenField hfAgentId = (HiddenField)item.FindControl("hfAgentId");
                    if (hfAgentId != null)
                    {
                        Int32 id = Convert.ToInt32(hfAgentId.Value);

                        if (id == this.selectedAgentId)
                        {
                            ucGroupRadioButton.Checked = true;
                        }
                    }
                }
            }


            upWork.Update();
            return true;
        }











        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            bool isAutoPostBack = Convert.ToBoolean(Context.Items["IsAutoPostBack"]);

            if (isAutoPostBack)
                this.Update();
        }










        protected Int32 currentAgentId()
        {
            return ProxyHelper.GetUserAgentId(this.UcAppPage.UserId);
        }

        protected void rb_CheckedChanged(object sender, EventArgs e)
        {
            UcGroupRadioButton grb = (UcGroupRadioButton)sender;
            this.selectedAgentId = Convert.ToInt32(grb.UcValue);
        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            if (this.selectedAgentId != 0)
            {
                if (this.agentId != this.selectedAgentId)
                {

                    if(statusId == 5)   // Follow-Up
                        BllProxyIncidentHelper.TransferIncident(this.UcAppPage.UserId, this.incidentId, 5, this.agentId, this.selectedAgentId);
                    else
                        BllProxyIncidentHelper.TransferIncident(this.UcAppPage.UserId, this.incidentId, 1, this.agentId, this.selectedAgentId);




                    UcControlArgs args = new UcControlArgs();
                    args.Id = this.agentId;
                    args.Message = "The profile has been transferred.";
                    this.goNext(args);
                }
                else
                {
                    this.showErrorMessage("The target agent cannot be the same as the current agent!");
                }
            }
            else
            {
                this.showErrorMessage("The target agent is not selected!");
            }

        }

















    }
}
