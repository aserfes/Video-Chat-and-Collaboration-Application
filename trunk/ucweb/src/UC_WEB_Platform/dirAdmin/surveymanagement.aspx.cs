using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAdmin
{
    public partial class surveymanagement : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterSurveys();
        }



        protected void mvSurvey_ActiveViewChanged(object sender, EventArgs e)
        {
        }


        protected void filterSurveys()
        {
            sosSurvey.UcDataBind();
        }




        protected void filterSurveyQuestions(Int32 surveyId)
        {
            sosSurveyQuestion.SurveyId = surveyId;
            sosSurveyQuestion.UcDataBind();
        }










        protected void sosSurvey_ManageQuestions(object sender, UcControlArgs e)
        {
            Int32 surveyId = e.Id;
            filterSurveyQuestions(surveyId);

            //sosSurveyQuestion.SurveyId = surveyId;

            mvSurvey.ActiveViewIndex = 1;
        }



        protected void sosSurvey_Back(object sender, UcControlArgs e)
        {
            sosSurvey.UcDataBind();
            mvSurvey.ActiveViewIndex = 0;
        }


        protected void sosSurvey_Next(object sender, UcControlArgs e)
        {
            Int32 surveyId = e.Id;
            filterSurveyQuestions(surveyId);

//            sosSurveyQuestion.SurveyTitle = e.Message;

            mvSurvey.ActiveViewIndex = 1;
        }




    }
}

