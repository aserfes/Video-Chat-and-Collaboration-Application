using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.Membership;
using System.Threading;

namespace UcentrikWeb.App_Controls.CommonControls
{
    public partial class Login : UcBaseControl
    {
        #region Events

        public event UcUserEventHandler LoggedIn;
        protected void login(UcUserArgs args)
        {
            if (LoggedIn != null)
                LoggedIn(this, args);
        }

        #endregion

        #region Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                FormsAuthentication.SignOut();
                this.DataBind();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username = tbUserName.Text;
            String password = tbPassword.Text;

            if (this.DoLogin(username, password))
            {
                if (!string.IsNullOrEmpty(LogInUrl))
                {
                    Response.Redirect(LogInUrl, false);
                    this.Context.ApplicationInstance.CompleteRequest();
                }
            }
            else
            {
                plhLogInInvalid.Visible = true;
            }
        }

        #endregion

        #region Private methods

        private bool DoLogin(String username, String password)
        {
            UserPool userPool = (UserPool)Application["UserPool"];
            if (userPool.RegisterUser(username, password))
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(username, false);

                Int32 userId = userPool.GetUserId(username);
                Int32 userRoleId = userPool.GetUserRoleId(username);

                UcUserArgs args = new UcUserArgs();
                args.UserName = username;
                args.Password = password;
                args.UserId = userId;
                args.UserRoleId = userRoleId;
                login(args);

                return true;
            }

            return false;
        }

        #endregion

        #region Public properties

        public string RestorePasswordUrl { get; set; }
        public string LogInUrl { get; set; }

        #endregion
    }
}
