using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.AppSettings;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;


namespace UcentrikWeb.App_Controls.BusinessControls
{
    public partial class AgentProfile : UcAppBaseProfileDetailsControl
    {
        #region Events

        public event UcControlEventHandler ManageGroups;
        protected void manageGroups(object sender, UcControlArgs e)
        {
            if (ManageGroups != null)
                ManageGroups(this, e);
        }

        public event UcControlEventHandler ManageSkills;
        protected void manageSkills(object sender, UcControlArgs e)
        {
            if (ManageSkills != null)
                ManageSkills(this, e);
        }

        public event UcControlEventHandler ManageLanguages;
        protected void manageLanguages(object sender, UcControlArgs e)
        {
            if (ManageLanguages != null)
                ManageLanguages(this, e);
        }

        protected void lbManageGroups_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageGroups(this, args);
        }

        protected void lbManageSkills_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageSkills(this, args);
        }

        protected void lbManageLanguages_Click(object sender, EventArgs e)
        {
            UcControlArgs args = new UcControlArgs();
            args.Id = profileId;

            manageLanguages(this, args);
        }


        #endregion

        protected Int32 userId
        {
            get
            {
                Int32 _userId = 0;
                Object objViewStateStatusId = this.ViewState[this.ID + "UserId"];
                if (objViewStateStatusId != null)
                    _userId = Convert.ToInt32(objViewStateStatusId);

                return _userId;
            }
            set
            {
                this.ViewState.Remove(this.ID + "UserId");
                this.ViewState.Add(this.ID + "UserId", value);
            }
        }
        public Int32 AgentId
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

                    Parameter objAgentIdParameter = new Parameter("agent_id", DbType.Int32);
                    objAgentIdParameter.DefaultValue = profileId.ToString();

                    objectdatasourceEdit.SelectParameters["agent_id"] = objAgentIdParameter;
                }
            }
        }

        #region DetailsView events

        protected void dvControl_DataBound(object sender, EventArgs e)
        {
            DetailsView dv = (DetailsView)sender;

            if (this.AllowManagement)
            {
                Control cntrl = dv.Rows[3].FindControl("lbManageGroups");
                LinkButton lb = cntrl as LinkButton;
                if (lb != null)
                    lb.Visible = true;

                cntrl = dv.Rows[4].FindControl("lbManageSkills");
                lb = cntrl as LinkButton;
                if (lb != null)
                    lb.Visible = true;

                cntrl = dv.Rows[5].FindControl("lbManageLanguages");
                lb = cntrl as LinkButton;
                if (lb != null)
                    lb.Visible = true;
            }


            dv.Rows[6].Visible = UcConfParameters.UcPublicCallEnabled;  // Public Enabled checkbox
        }

        protected void dvControl_ItemInserting(object sender, DetailsViewInsertEventArgs e)
        {
            e.Cancel = IsOtherAgentHasEmail(e.Values["email"].ToString());
        }

        protected void dvControl_ItemInserted(object sender, DetailsViewInsertedEventArgs e)
        {
            SaveComplete();
        }

        protected void dvControl_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
        {
            string oldEmail = e.OldValues["email"] as string;
            string newEmail = e.NewValues["email"] as string;
            if (!string.IsNullOrEmpty(newEmail) && oldEmail != newEmail)
            {
                e.Cancel = IsOtherAgentHasEmail(newEmail.ToString());
            }
        }

        protected void dvControl_ItemUpdated(object sender, DetailsViewUpdatedEventArgs e)
        {
            SaveComplete();
        }

        #endregion

        private bool IsOtherAgentHasEmail(string email)
        {
            AgentDS.AgentDSDataTable dt = BllProxyAgent.GetAgentByEmail(email);
            if (dt.Rows.Count != 0)
            {
                this.showErrorMessage("Agent with the same email already exists!");

                return true;
            }

            return false;
        }

        private void SaveComplete()
        {
            this.showTextMessage("Profile has been saved.");
        }

        public override void ClearControlData()
        {
            string[] ssTxt = new string[] {
                "txtFirstname",
                "txtLastname",
                "txtEmail",
                "txtPhone"
            };

            foreach (string s in ssTxt)
            {
                TextBox txt = dvControl.FindControl(s) as TextBox;
                if (txt != null)
                    txt.Text = "";
            }




            CheckBox chkboxPublicEnabled = dvControl.FindControl("chkboxPublicEnabled") as CheckBox;
            if (chkboxPublicEnabled != null)
                chkboxPublicEnabled.Checked = false;

        }

        protected override void save()
        {
            try
            {
                Parameter objAgentIdParameter = new Parameter("public_enabled", DbType.Boolean);
                objAgentIdParameter.DefaultValue = "True";
                

                if (profileId == 0)
                {
                    if (userId == 0)
                        //userId = this.GetCurrentUserId();
                        userId = this.UcPage.UserId;

                    objectdatasourceEdit.InsertParameters["public_enabled"] = objAgentIdParameter;

                    objAgentIdParameter = new Parameter("user_id", DbType.Int32);
                    objAgentIdParameter.DefaultValue = userId.ToString();
                    objectdatasourceEdit.InsertParameters["user_id"] = objAgentIdParameter;

                    this.dvControl.InsertItem(true);
                }
                else
                {
                    objectdatasourceEdit.UpdateParameters["public_enabled"] = objAgentIdParameter;

                    this.dvControl.UpdateItem(true);
                }
            }
            catch
            {
                this.showErrorMessage("Profile cannot be saved!");
            }
        }
    }
}

