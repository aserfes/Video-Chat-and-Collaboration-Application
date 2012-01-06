using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.dirAdmin
{
    public partial class questions : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterQuestions();
        }




        protected void filterQuestions()
        {
            //sosQuestion.UcDataBind();
        }




        protected void filterQuestionQuestions(Int32 questionId)
        {
            //sosQuestionQuestion.QuestionId = questionId;
            //sosQuestionQuestion.UcDataBind();
        }











        protected void sosQuestionQuestion_ProfileBack(object sender, UcControlArgs e)
        {
            //mvQuestion.ActiveViewIndex = 0;
        }






    }
}

