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
    public partial class SkillAgent : UcAppBaseLiteControl
    {
        protected Int32 skillId
        {
            get
            {
                Int32 _skillId = 0;
                Object objViewStateSkillId = this.ViewState[this.ID + "SkillId"];
                if (objViewStateSkillId != null)
                    _skillId = Convert.ToInt32(objViewStateSkillId);

                return _skillId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SkillId");
                this.ViewState.Add(this.ID + "SkillId", value);
            }
        }
        public Int32 SkillId
        {
            set
            {
                skillId = value;
                setSkill(skillId);
            }
        }

        public void UcDataBind()
        {
            SkillDS.SkillAgentDSDataTable dt = BllProxySkillAgent.GetAllSkillAgents(skillId);

            if (dt.Rows.Count != 0)
            {
                //lblSurvey.Text = dt[0].survey_name;

                objectdatasourceList.SelectParameters.Clear();
                objectdatasourceList.SelectParameters.Add("skill_id", skillId.ToString());

                gvList.Sort(sortExpression, sortDirection);
            }
            else
            {
                this.showErrorMessage("Skill does not exist!");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void setSkill(Int32 _skillId)
        {
            this.clearMessage();

            SkillDS.SkillDSDataTable dt = BllProxySkill.SelectSkill(_skillId);

            if (dt.Rows.Count > 0)
            {
                lblSkillName.Text = dt[0].skill_name;

                setSkillAgents(_skillId);
            }
            else
            {
                lblSkillName.Text = "ERROR: " + skillId.ToString();
            }
        }

        protected void setSkillAgents(Int32 _skillId)
        {
            //gvList.DataSource = BllProxySkillAgent.GetAllSkillAgents(_skillId);
            //gvList.DataBind();

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
                        bool inSkill = (key[1] is DBNull);

                        if (lb.CommandName == "Edit")
                        {
                            lb.Enabled = inSkill;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to add the agent?');");
                        }

                        if (lb.CommandName == "Delete")
                        {
                            lb.Enabled = !inSkill;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to remove the agent?');");
                        }
                    }

                }
            }
        }

        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;


            BllProxySkillAgent.SetSkillAgent(skillId, _id, true);

            setSkillAgents(skillId);
            this.showTextMessage("Agent has been added");

            e.Cancel = true;
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.RowIndex].Value;

            BllProxySkillAgent.SetSkillAgent(skillId, _id, false);

            setSkillAgents(skillId);
            this.showTextMessage("Agent has been removed");

            e.Cancel = true;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            this.back(this, args);
        }
    }
}

