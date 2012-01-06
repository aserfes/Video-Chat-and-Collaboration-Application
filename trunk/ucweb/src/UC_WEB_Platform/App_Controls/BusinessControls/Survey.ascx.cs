using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;


using System.Runtime.Serialization;
using System.Text;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class Survey : UcAppBaseOperationalControl
    {



        //        ///---------------------------------------------------------------------------------
        public event UcControlEventHandler ManageQuestions;
        protected void manageQuestions(object sender, UcControlArgs e)
        {
            if (ManageQuestions != null)
                ManageQuestions(this, e);
        }
        //        ///---------------------------------------------------------------------------------








        public Control UcHeaderControl
        {
            set
            {
                phControls.Controls.Add(value);
            }
        }




        public void UcDataBind()
        {
            if (mvControl.ActiveViewIndex == 0)
                gvList.Sort(sortExpression, sortDirection);
            else if (mvControl.ActiveViewIndex == 1)
                profileControl.Refresh();
        }






        //---------------------------------------------------------------------------------
        protected void Page_Init(object sender, EventArgs e)
        {
            profileControl.ReadOnly = this.readOnly;
        }






        ///---------------------------------------------------------------------------------
        protected void gvList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView gv = (GridView)sender;
            Int32 _id = (int)gv.DataKeys[e.NewEditIndex].Value;

            profileControl.SurveyId = _id;

            mvControl.ActiveViewIndex = 1;
            e.Cancel = true;
        }

        ///---------------------------------------------------------------------------------


        ///---------------------------------------------------------------------------------
        protected void lbSurvey_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Int32 _id = Convert.ToInt32(lb.CommandArgument);

            UcControlArgs args = new UcControlArgs();
            args.Id = _id;
            this.open(sender, args);

            profileControl.SurveyId = _id;
            mvControl.ActiveViewIndex = 1;
        }




        /////---------------------------------------------------------------------------------
        //protected void lbSurveyQuestions_Click(object sender, EventArgs e)
        //{
        //    LinkButton lb = (LinkButton)sender;
        //    Int32 _id = Convert.ToInt32(lb.CommandArgument);

        //    SosControlArgs args = new SosControlArgs();
        //    args.Id = _id;
        //    args.Message = lb.CommandName;
        //    this.openQuestions(sender, args);
        //}




        protected void sosSurvey_ManageQuestions(object sender, UcControlArgs e)
        {
            manageQuestions(this, e);
        }





















        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //ltTest.Text = "NEW";
            //mvSurvey.ActiveViewIndex = 1;
            //DetailsView1.ChangeMode(DetailsViewMode.Insert);

            //_id = 0;

            //objectdatasourceEdit.SelectParameters.Clear();
            //objectdatasourceEdit.SelectParameters.Add("survey_id", _id.ToString());


            mvControl.ActiveViewIndex = 1;
            profileControl.SurveyId = 0;
        }













        /////---------------------------------------------------------------------------------
    }
}