using System;
using System.Web.Security;
using UCENTRIK.LIB.Base;
using UCENTRIK.Membership;
using System.Threading;

namespace UcentrikWeb.App_Controls.CommonControls
{
    public partial class LogOnUser : UcBaseControl
    {
        #region Events

        public event UcUserEventHandler LoggingOut;
        protected void OnLoggingOut(UcUserArgs args)
        {
            if (LoggingOut != null)
                LoggingOut(this, args);
        }

        #endregion

        #region Event handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.DataBind();
            }
        }

        protected void lbLogOff_Click(object sender, EventArgs e)
        {
            Logout();

            if (!String.IsNullOrEmpty(this.RedirectOnLogOffUrl))
            {
                Response.Redirect(this.RedirectOnLogOffUrl, false);
                this.Context.ApplicationInstance.CompleteRequest();
            }
        }

        #endregion

        #region Private methods

        protected void Logout()
        {
            UcUserArgs args = new UcUserArgs();
            args.UserName = "";
            args.Password = "";
            args.UserId = this.UcPage.UserId;
            args.UserRoleId = this.UcPage.UserRoleId;
            OnLoggingOut(args);

            FormsAuthentication.SignOut();

            UserPool userPool = (UserPool)Application["UserPool"];
            userPool.RemoveUser(Page.User.Identity.Name);
        }

        #endregion

        #region Public properties

        public string LogOnUrl { get; set; }

        public string RedirectOnLogOffUrl { get; set; }

        public bool IsAuthorized
        {
            get
            {
                return ((UcBasePage)Page).IsAuthorized;
            }
        }

        public string UserName
        {
            get
            {
                return ((UcBasePage)Page).UserName;
            }
        }

        #endregion
    }
}