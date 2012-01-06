using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;
using UCENTRIK.Utility;
using UCENTRIK.Extensions;
using UCENTRIK.Configuration;

namespace UcentrikWeb.App_Controls.CommonControls
{
    public partial class RestorePassword : UcBaseControl
    {
        #region Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DataBind();
                this.ShowRestoringState();
            }
        }

        protected void btnRestorePassword_Click(object sender, EventArgs e)
        {
            this.RestorePasswordByEmail();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.LoginPageUrl))
            {
                this.Response.Redirect(this.LoginPageUrl, false);
                this.Context.ApplicationInstance.CompleteRequest();
            }
        }

        #endregion

        #region Private methods

        private void RestorePasswordByEmail()
        {
            var email = tbEmail.Text;
            UserDS.UserDSRow user = GetUser(email);
            if (user == null)
            {
                this.plhAccountDoesNotExist.Show();
            }
            else
            {
                this.SendEmailWithPassword(email, user);
                this.ShowRestoredState();
            }
        }

        private UserDS.UserDSRow GetUser(string email)
        {
            AgentDS.AgentDSDataTable agentDT = BllProxyAgent.GetAgentByEmail(email);
            if (agentDT.Rows.Count != 0)
            {
                int userID = 0;
                int.TryParse(agentDT[0]["user_id"].ToString(), out userID);
                UserDS.UserDSDataTable userDT = BllProxyUser.SelectUser(userID);
                if (userDT.Rows.Count != 0)
                {
                    return userDT[0];
                }
            }
            return null;
        }

        private void SendEmailWithPassword(string email, UserDS.UserDSRow user)
        {
            var values = new Dictionary<string, string>();
            values.Add("FullName", user["username"].ToString());
            values.Add("Password", user["password"].ToString());

            MailSender.SendEmail(email, UcentrikConfiguration.RestorePasswordSubject,
                MailSender.EmailTemplate.RestorePassword, values);
        }

        private void ShowRestoringState()
        {
            this.plhPasswordRestoring.Show();
            this.plhPasswordRestored.Hide();
            this.plhAccountDoesNotExist.Hide();
        }

        private void ShowRestoredState()
        {
            this.plhPasswordRestoring.Hide();
            this.plhPasswordRestored.Show();
            this.plhAccountDoesNotExist.Hide();
        }

        #endregion

        #region Public properties

        public string LoginPageUrl { get; set; }

        #endregion
    }
}