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
    public partial class LanguageAgent : UcAppBaseLiteControl
    {
        protected Int32 languageId
        {
            get
            {
                Int32 _languageId = 0;
                Object objViewStateLanguageId = this.ViewState[this.ID + "LanguageId"];
                if (objViewStateLanguageId != null)
                    _languageId = Convert.ToInt32(objViewStateLanguageId);

                return _languageId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "LanguageId");
                this.ViewState.Add(this.ID + "LanguageId", value);
            }
        }
        public Int32 LanguageId
        {
            set
            {
                languageId = value;
                setLanguage(languageId);
            }
        }

        public void UcDataBind()
        {
            LanguageDS.LanguageAgentDSDataTable dt = BllProxyLanguageAgent.GetAllLanguageAgents(languageId);

            if (dt.Rows.Count != 0)
            {
                //lblSurvey.Text = dt[0].survey_name;

                objectdatasourceList.SelectParameters.Clear();
                objectdatasourceList.SelectParameters.Add("language_id", languageId.ToString());

                gvList.Sort(sortExpression, sortDirection);
            }
            else
            {
                this.showErrorMessage("Language does not exist!");
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void setLanguage(Int32 _languageId)
        {
            this.clearMessage();

            LanguageDS.LanguageDSDataTable dt = BllProxyLanguage.SelectLanguage(_languageId);

            if (dt.Rows.Count > 0)
            {
                lblLanguageName.Text = dt[0].language_name;

                setLanguageAgents(_languageId);
            }
            else
            {
                lblLanguageName.Text = "ERROR: " + languageId.ToString();
            }
        }

        protected void setLanguageAgents(Int32 _languageId)
        {
            //gvList.DataSource = BllProxyLanguageAgent.GetAllLanguageAgents(_languageId);
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
                        bool inLanguage = (key[1] is DBNull);

                        if (lb.CommandName == "Edit")
                        {
                            lb.Enabled = inLanguage;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to add the agent?');");
                        }

                        if (lb.CommandName == "Delete")
                        {
                            lb.Enabled = !inLanguage;
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


            BllProxyLanguageAgent.SetLanguageAgent(languageId, _id, true);

            setLanguageAgents(languageId);
            this.showTextMessage("Agent has been added");

            e.Cancel = true;
        }

        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.RowIndex].Value;

            BllProxyLanguageAgent.SetLanguageAgent(languageId, _id, false);

            setLanguageAgents(languageId);
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

