using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


using UCENTRIK.LIB.Base;





namespace UCENTRIK.WEB.KIOSK.Kiosk
{
    public partial class UcKioskSurveyQuestion : UCENTRIK.LIB.Base.UcKioskBaseControl
    {


//        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler AnswerEntered;
        protected void resetTimer(UcControlArgs args)
        {
            if (AnswerEntered != null)
                AnswerEntered(this, args);
        }
//        ///---------------------------------------------------------------------------------




        protected Int32 questionId
        {
            get
            {
                Int32 _surveyQuestionId = 0;
                Object objViewStateQuestionId = this.ViewState[this.ID + "SurveyQuestionId"];
                if (objViewStateQuestionId != null)
                    _surveyQuestionId = Convert.ToInt32(objViewStateQuestionId);

                return _surveyQuestionId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SurveyQuestionId");
                this.ViewState.Add(this.ID + "SurveyQuestionId", value);
            }
        }
        public Int32 QuestionId
        {
            set
            {
                questionId = value;
            }
            get
            {
                return questionId;
            }
        }




        protected string surveyResponse
        {
            get
            {
                string _surveyResponse = "";
                Object objViewStateSurveyResponse = this.ViewState[this.ID + "SurveyResponse"];
                if (objViewStateSurveyResponse != null)
                    _surveyResponse = Convert.ToString(objViewStateSurveyResponse);

                return _surveyResponse;
            }
            set
            {
                this.ViewState.Remove(this.ID + "SurveyResponse");
                this.ViewState.Add(this.ID + "SurveyResponse", value);
            }
        }
        public string SurveyResponse
        {
            get
            {
                return surveyResponse;
            }
        }







        //private Int32 _questionType;
        protected Int32 questionType
        {
            get
            {
                Int32 _questionType = 0;
                Object objViewStateQuestionType = this.ViewState[this.ID + "QuestionType"];
                if (objViewStateQuestionType != null)
                    _questionType = Convert.ToInt32(objViewStateQuestionType);

                return _questionType;
            }
            set
            {
                this.ViewState.Remove(this.ID + "QuestionType");
                this.ViewState.Add(this.ID + "QuestionType", value);
            }
        }
        public Int32 QuestionType
        {
            set
            {
                questionType = value;


                pnlTypeText.Visible = false;
                pnlTypeYesNo.Visible = false;
                pnlTypeRank.Visible = false;


                switch (questionType)
                {
                    case 1:
                        pnlTypeText.Visible = true;
                        break;

                    case 2:
                        pnlTypeYesNo.Visible = true;
                        break;

                    case 3:
                        pnlTypeRank.Visible = true;
                        break;

                    default:
                        break;
                }
            }
            get
            {
                return questionType;
            }
        }













        public String QuestionTitle
        {
            set
            {
                lblQuestionTitle.Text = value;
            }
        }




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                surveyResponse = String.Empty;
            }
        }





        protected void btnYesNo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            btnYes.ForeColor = System.Drawing.Color.Gray;
            btnNo.ForeColor = System.Drawing.Color.Gray;

            btn.ForeColor = System.Drawing.Color.Red;

            surveyResponse = btn.CommandArgument;

            UcControlArgs args = new UcControlArgs();
            resetTimer(args);
        }

        protected void btnRank_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rank0 = Convert.ToInt32(btn.CommandArgument);

            foreach (Control c in pnlTypeRank.Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c as Button;
                    int rank = Convert.ToInt32(b.CommandArgument);

                    b.ForeColor = System.Drawing.Color.Gray;
                    if (rank <= rank0)
                        b.ForeColor = System.Drawing.Color.Red;
                }
            }

            surveyResponse = btn.CommandArgument;

            UcControlArgs args = new UcControlArgs();
            resetTimer(args);
        }

        protected void txtAnswer_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            surveyResponse = txt.Text;

            UcControlArgs args = new UcControlArgs();
            resetTimer(args);
        }






    }
}