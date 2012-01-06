using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

using UCENTRIK.WEB.KIOSK.Kiosk;


namespace UCENTRIK.WEB.KIOSK.Connect
{
    public partial class Survey : UcKioskConnectBaseControl
    {
        public void Start()
        {
            string script = "window.resizeTo( 550, 440 )";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SetSurveyScreenSize", script, true);

            Int32 surveyId = 0;
            startTime = DateTime.Now;


            FacilityDS.FacilityDSDataTable dtF = BllProxyFacility.SelectFacility(this.FacilityId);
            if (dtF.Rows.Count > 0)
            {
                if(!dtF[0].Issurvey_idNull())
                    surveyId = dtF[0].survey_id;
            }

            if (surveyId != 0)
            {
                QuestionDS.QuestionDSDataTable dt = BllProxyQuestion.GetQuestionsBySurvey(surveyId);
                rptSurveyQuestions.DataSource = dt;

                if (dt.Rows.Count != 0)
                {
                    rptSurveyQuestions.DataBind();
                }
                else
                {
                    UcControlArgs args = new UcControlArgs();
                    goNext(args);
                }
            }
            else
            {
                UcControlArgs args = new UcControlArgs();
                goNext(args);
            }
            

        }




        protected void Page_Load(object sender, EventArgs e)
        {
        }





        protected void timerRefresh_Tick(object sender, EventArgs e)
        {
            DateTime t = DateTime.Now;
            TimeSpan span = t.Subtract(startTime);

            ltTimeSpan.Text = string.Format("{0:00}:{1:00}:{2:00}", (int)span.TotalHours, span.Minutes, span.Seconds);

            TimeSpan max = new TimeSpan(0, 1, 0);

            if (TimeSpan.Compare(span, max) > 0)
            {
                UcControlArgs args = new UcControlArgs();
                goNext(args);
            }

        }





        protected void SurveyQuestion_AnswerEntered(object sender, UcControlArgs e)
        {
            startTime = DateTime.Now;
        }






        protected void btnFinish_Click(object sender, EventArgs e)
        {
            Int32 surveyId = 0;
            FacilityDS.FacilityDSDataTable dtF = BllProxyFacility.SelectFacility(this.FacilityId);
            if (dtF.Rows.Count > 0)
            {
                surveyId = dtF[0].survey_id;
            }









            bool isComplete = false;
            foreach (Control c in rptSurveyQuestions.Items)
            {
                UcKioskSurveyQuestion surveyQuestion = (UcKioskSurveyQuestion)c.FindControl("SurveyQuestion");

                if (surveyQuestion != null)
                    if (surveyQuestion.SurveyResponse != "")
                        isComplete = true;

            }




            if (isComplete)
            {
                foreach (Control c in rptSurveyQuestions.Items)
                {
                    UcKioskSurveyQuestion surveyQuestion = (UcKioskSurveyQuestion)c.FindControl("SurveyQuestion");

                    if (surveyQuestion != null)
                    {
                        Int32 questionId = surveyQuestion.QuestionId;
                        Int32 typeId = surveyQuestion.QuestionType;
                        string response = surveyQuestion.SurveyResponse;
                        
                            
                        //if ((typeId == 2)||(typeId == 3))
                        if (response == "")
                            response = null;


                        if (response != "")
                            BllProxySurvey.InsertSurveyResponse(incidentId, surveyId, questionId, response);

                    }
                }
            }

            UcControlArgs args = new UcControlArgs();
            goNext(args);
        }


    }
}