using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class AgentSkills : UcAppBaseLiteControl
    {
        private bool _allowManagement = false;
        public bool AllowManagement
        {
            set
            {
                _allowManagement = value;
            }
            get
            {
                return _allowManagement;
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

        public Int32 AgentId
        {
            set
            {
                agentId = value;
                setAgent(agentId);
            }
        }

        public void UcDataBind()
        {
            if (!this.AllowManagement)
            {
                gvList.Columns[2].Visible = false;
            }

            objectdatasourceList.SelectParameters.Clear();
            objectdatasourceList.SelectParameters.Add("agent_id", agentId.ToString());

            gvList.Sort(sortExpression, sortDirection);
        }

        protected void setAgent(Int32 _agentId)
        {
            this.clearMessage();

            UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt = BllProxyAgent.SelectAgent(_agentId);

            if (dt.Rows.Count > 0)
            {
                lblAgentName.Text = dt[0].full_name;

                setAgentSkills(_agentId);
            }
            else
            {
                lblAgentName.Text = "ERROR: " + _agentId.ToString();
            }
        }

        protected void setAgentSkills(Int32 _agentId)
        {
            this.UcDataBind();
        }

        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            GridView gv = (GridView)sender;

            GridViewRow row = e.Row;
            if (row.RowType == DataControlRowType.DataRow)
            {
                Int32 lastCell = row.Cells.Count - 1;
                foreach (Control cntrl in row.Cells[lastCell].Controls)
                {
                    LinkButton lb = cntrl as LinkButton;
                    if (lb != null)
                    {
                        DataKey key = gv.DataKeys[e.Row.RowIndex];
                        bool index = (key[1] is DBNull);

                        if (lb.CommandName == "Edit")
                        {
                            lb.Enabled = index;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to add the skill?');");
                        }

                        if (lb.CommandName == "Delete")
                        {
                            lb.Enabled = !index;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to remove the skill?');");
                        }
                    }

                }
            }
        }

        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;

            BllProxySkillAgent.SetSkillAgent(_id, agentId, true);

            setAgentSkills(agentId);
            this.showTextMessage("Skill has been added");

            e.Cancel = true;
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.RowIndex].Value;

            BllProxySkillAgent.SetSkillAgent(_id, agentId, false);

            setAgentSkills(agentId);
            this.showTextMessage("Skill has been removed");

            e.Cancel = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            this.back(this, args);
        }
    }
}

