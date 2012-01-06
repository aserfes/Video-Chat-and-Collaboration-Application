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
    public partial class LanguageProfile : UcAppBaseProfileDetailsControl
    {
        public event UcControlEventHandler ManageAgents;
        protected void manageAgents(object sender, UcControlArgs e)
        {
            if (ManageAgents != null)
                ManageAgents(this, e);
        }

        public Int32 LanguageId
        {
            set
            {
                profileId = value;


                if (profileId == 0)
                {
                    this.dvControl.ChangeMode(DetailsViewMode.Insert);
                }
                else
                {
                    dvControl.ChangeMode(dvMode);

                    Parameter objLanguageIdParameter = new Parameter("language_id", DbType.Int32);
                    objLanguageIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["language_id"] = objLanguageIdParameter;
                }
            }
        }

        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;

            if (this.AllowManagement)
            {
                Control cntrl;
                LinkButton lb;

                //if (dv.Rows.Count >= 1)
                {
                    cntrl = dv.Rows[3].FindControl("lbManageAgents");
                    lb = cntrl as LinkButton;
                    if (lb != null)
                        lb.Visible = true;
                }
            }
        }

        protected override void save()
        {
            try
            {
                if (profileId == 0)
                {
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
            
        protected void lbManageAgents_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageAgents(this, args);
        }

        public override void ClearControlData()
        {
            TextBox txtLanguageName = dvControl.FindControl("txtLanguageName") as TextBox;

            if (txtLanguageName != null)
                txtLanguageName.Text = "";
        }
    }
}

