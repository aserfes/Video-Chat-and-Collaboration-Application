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
    public partial class ContactProfile : UcAppBaseProfileDetailsControl
    {


        public Int32 ContactId
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
                    dvControl.ChangeMode(dvMode);

                    Parameter objContactIdParameter = new Parameter("contact_id", DbType.Int32);
                    objContactIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["contact_id"] = objContactIdParameter;
                }
            }
        }






        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            if (e.Keys["user_id"] == DBNull.Value) { e.Keys["user_id"] = 0; }
        } 






        protected override void save()
        {
            try
            {
                //--//Parameter objMemoParameter = new Parameter("memo", DbType.String);
                //--//objMemoParameter.DefaultValue = "";


                if (profileId == 0)
                {
                    Parameter objContactIdParameter = new Parameter("user_id", DbType.Int32);
                    objContactIdParameter.DefaultValue = "0";    // userId.ToString();
                    objectdatasourceEdit.InsertParameters["user_id"] = objContactIdParameter;

                    //--//objectdatasourceEdit.InsertParameters["memo"] = objMemoParameter;


                    this.dvControl.InsertItem(true);
                }
                else
                {
                    //--//objectdatasourceEdit.UpdateParameters["memo"] = objMemoParameter;

                    this.dvControl.UpdateItem(true);
                }
            }
            catch
            {
                this.showErrorMessage("Profile cannot be saved!");
            }


        }





        public override void ClearControlData()
        {
            string[] ssTxt = new string[] {
                "txtFirstname",
                "txtLastname",
                "txtEmail",
                "txtPhone",
                "txtMemo"
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

