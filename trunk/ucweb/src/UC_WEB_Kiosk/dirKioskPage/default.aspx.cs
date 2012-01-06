using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using UCENTRIK.Membership;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.WEB.dirKioskEcoATM
{
    public partial class _default : System.Web.UI.Page
    {
        #region Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxPassword.Text))
            {
                if(!string.IsNullOrEmpty(TextBoxPassword.Attributes["value"]))
                {
                    TextBoxPassword.Text = TextBoxPassword.Attributes["value"];
                }
            }

            if (!IsPostBack)
            {
                TextBoxUserName.Text = "kiosk";
                TextBoxPassword.Text = "welcome";

				UCENTRIK.LIB.Helpers.UCTXHelper.AddUCTXObjectsToHeader( this );

                BindSkills();
                BindLanguages();
            }
        }
     
        protected void ButtonGetHelp_Click(object sender, EventArgs e)
        {
            Int32 skillID = 0;
            if (!string.IsNullOrEmpty(ddlSkill.SelectedValue))
            {
                skillID = Convert.ToInt32(ddlSkill.SelectedValue);
            }

            Int32 langID = 0;
            if (!string.IsNullOrEmpty(ddlLanguage.SelectedValue))
            {
                langID = Convert.ToInt32(ddlLanguage.SelectedValue);
            }

            Int32 groupID = 0;
            if (!string.IsNullOrEmpty(ddlGroup.SelectedValue))
            {
                groupID = Convert.ToInt32(ddlGroup.SelectedValue);
            }

            string sep = "&";
            string parameters = "skillID=" + skillID + sep +
                                "langID=" + langID + sep +
                                "groupID=" + groupID + sep +
                                "kioskID=" + TextBoxKioskID.Text + sep +
                                "kioskName=" + TextBoxKioskName.Text + sep +
                                "kioskLocation=" + TextBoxKioskLocation.Text + sep +
								"kioskUser=" + TextBoxKioskUser.Text + sep +
								"userName=" + TextBoxUserName.Text + sep +
                                "password=" + TextBoxPassword.Text;

            string script = "PopupCenter('../dirKiosk/default.aspx?" + parameters + "', 'CallFrom" + TextBoxUserName.Text + "', 500, 500);";
            this.ClientScript.RegisterClientScriptBlock(this.GetType(), "New Window", script, true);
        }

        protected void ButtonLogIn_Click(object sender, EventArgs e)
        {
            string userName = TextBoxUserName.Text;
            string password = TextBoxPassword.Text;
            UserAccount account = new UserAccount(userName);
            if (account.IsValid(userName, password))
            {
                PanelGetHelp.Enabled = true;
                PanelLogin.Enabled = false;

                BindGroups();
            }
        }

        protected void ButtonChangeAccount_Click(object sender, EventArgs e)
        {
            PanelGetHelp.Enabled = false;
            PanelLogin.Enabled = true;
        }

        protected void TextBoxPassword_PreRender(object sender, EventArgs e)
        {
            TextBoxPassword.Attributes["value"] = TextBoxPassword.Text;
        }

        #endregion

        #region Control Binding

        private void BindLanguages()
        {
            LanguageDS.LanguageDSDataTable dtLanguages = BllProxyLanguage.GetLanguageList(0);
            ddlLanguage.DataSource = dtLanguages.Rows;
            ddlLanguage.DataBind();
            if (ddlLanguage.Items.Count > 0)
            {
                ddlLanguage.Items[0].Selected = true;
            }
        }

        private void BindSkills()
        {
            SkillDS.SkillDSDataTable dtSkills = BllProxySkill.GetSkillList(0);
            ddlSkill.DataSource = dtSkills.Rows;
            ddlSkill.DataBind();
            if (ddlSkill.Items.Count > 0)
            {
                ddlSkill.Items[0].Selected = true;
            }
        }

        private void BindGroups()
        {
            string userName = TextBoxUserName.Text;
            string password = TextBoxPassword.Text;
            UserAccount account = new UserAccount(userName);
            if (account.IsValid(userName, password))
            {
                FacilityDS.FacilityDSDataTable dt = BllProxyFacility.GetFacilityByUser(account.UserId);
                if (dt.Rows.Count > 0)
                {
                    int facilityId = dt[0].facility_id;

                    FacilityDS.FacilityGroupDSDataTable facilityGroupdt = BllProxyFacilityGroup.GetAllFacilityGroups(facilityId);
                    FacilityDS.FacilityGroupDSRow[] rows = (FacilityDS.FacilityGroupDSRow[])facilityGroupdt.Select("facility_id is not NULL");
                    ddlGroup.DataSource = rows;
                    ddlGroup.DataBind();
                }
            }
        }

        #endregion
    }
}
