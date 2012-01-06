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
    public partial class SurveyQuestion : UcAppBaseLiteControl
    {



        protected Int32 surveyId
        {
            get
            {
                Int32 _surveyId = 0;
                Object objViewStateSurveyId = this.ViewState[this.ID + "SurveyId"];
                if (objViewStateSurveyId != null)
                    _surveyId = Convert.ToInt32(objViewStateSurveyId);

                return _surveyId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SurveyId");
                this.ViewState.Add(this.ID + "SurveyId", value);
            }
        }
        public Int32 SurveyId
        {
            set
            {
                surveyId = value;
                setSurvey(surveyId);
            }
        }











        public void UcDataBind()
        {
            SurveyDS.SurveyQuestionDSDataTable dt = BllProxySurveyQuestion.GetAllSurveyQuestions(surveyId);

            objectdatasourceList.SelectParameters.Clear();
            objectdatasourceList.SelectParameters.Add("survey_id", surveyId.ToString());

            gvList.Sort(sortExpression, sortDirection);


            if (dt.Rows.Count == 0)
            {
                this.showErrorMessage("There are no questions available!");
            }
        }







        //---------------------------------------------------------------------------------
        protected void Page_Init(object sender, EventArgs e)
        {
        }





        protected void setSurvey(Int32 _surveyId)
        {
            this.clearMessage();

            SurveyDS.SurveyDSDataTable dt = BllProxySurvey.SelectSurvey(_surveyId);

            if (dt.Rows.Count > 0)
            {
                lblSurveyName.Text = dt[0].survey_name;

            }
            else
            {
                lblSurveyName.Text = "ERROR: " + surveyId.ToString();
            }
        }


        protected void setSurveyQuestions(Int32 _surveyId)
        {
            this.UcDataBind();
        }











//        ///---------------------------------------------------------------------------------
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
                        bool inSurvey = (key[1] is DBNull);

                        if (lb.CommandName == "Edit")
                        {
                            lb.Enabled = inSurvey;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to add the question?');");
                        }

                        if (lb.CommandName == "Delete")
                        {
                            lb.Enabled = !inSurvey;
                            lb.Attributes.Add("onclick", "return confirm('Do you want to remove the question?');");
                        }
                    }

                }
            }
        }











        ///---------------------------------------------------------------------------------
        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;


            BllProxySurveyQuestion.SetSurveyQuestion(surveyId, _id, true);

            setSurveyQuestions(surveyId);
            this.showTextMessage("Question has been added");

            e.Cancel = true;
        }
        protected void gvList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.RowIndex].Value;

            BllProxySurveyQuestion.SetSurveyQuestion(surveyId, _id, false);
            
            setSurveyQuestions(surveyId);
            this.showTextMessage("Question has been removed");

            e.Cancel = true;
        }
        ///---------------------------------------------------------------------------------








        protected void btnBack_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            this.back(this, args);
        }

    }
}

