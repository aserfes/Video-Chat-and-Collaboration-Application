using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class SurveyProfile : UcAppBaseProfileDetailsControl
    {







        //        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ManageQuestions;
        protected void manageQuestions(object sender, UcControlArgs e)
        {
            if (ManageQuestions != null)
                ManageQuestions(this, e);
        }
        //        ///----------------------



        //protected Int32 userId
        //{
        //    get
        //    {
        //        Int32 _userId = 0;
        //        Object objViewStateStatusId = this.ViewState[this.ID + "UserId"];
        //        if (objViewStateStatusId != null)
        //            _userId = Convert.ToInt32(objViewStateStatusId);

        //        return _userId;
        //    }
        //    set
        //    {
        //        this.ViewState.Remove(this.ID + "UserId");
        //        this.ViewState.Add(this.ID + "UserId", value);
        //    }
        //}



        public Int32 SurveyId
        {
            set
            {
                profileId = value;


                if (profileId == 0)
                {
                    dvControl.ChangeMode(DetailsViewMode.Insert);
                }
                else
                {
                    //dvControl.ChangeMode(DetailsViewMode.Edit);
                    dvControl.ChangeMode(dvMode);

                    Parameter objSurveyIdParameter = new Parameter("survey_id", DbType.Int32);
                    objSurveyIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["survey_id"] = objSurveyIdParameter;
                }
            }
        }






















        protected void lbManageQuestions_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageQuestions(this, args);
        }


        //protected override void save()
        //{
        //    this.dvControl.UpdateItem(true);
        //}


        protected override void save()
        {
            try
            {
                if (profileId == 0)
                {
                    //if (userId == 0)
                    //    userId = this.GetCurrentUserId();

                    //Parameter objSurveyIdParameter = new Parameter("user_id", DbType.Int32);
                    //objSurveyIdParameter.DefaultValue = userId.ToString();
                    //objectdatasourceEdit.InsertParameters["user_id"] = objSurveyIdParameter;

                    this.dvControl.InsertItem(true);
                }
                else
                {
                    this.dvControl.UpdateItem(true);
                }
            }
            catch
            {
                this.showErrorMessage("Profile cannot be saved!");
            }


        }




        //protected void objectdatasourceEdit_Inserted(object source, ObjectDataSourceStatusEventArgs e)
        //{
        //    Int32 id = Convert.ToInt32(e.ReturnValue);
        //}












        public override void ClearControlData()
        {
            string[] ssTxt = new string[] {
                "txtSurveyName",
                "txtSurveyId"
            };

            foreach (string s in ssTxt)
            {
                TextBox txt = dvControl.FindControl(s) as TextBox;
                if (txt != null)
                    txt.Text = "";
            }
        }



            //---
    }
}

