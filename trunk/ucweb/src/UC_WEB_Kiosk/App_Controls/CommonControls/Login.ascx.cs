using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.Membership;

namespace UCENTRIK.UserControls.Controls
{
    public partial class Login : UcBaseControl
    {


        //        ///---------------------------------------------------------------------------------
        public event UcUserEventHandler LoggedIn;
        protected void login(UcUserArgs args)
        {
            if (LoggedIn != null)
                LoggedIn(this, args);
        }
        public event UcUserEventHandler LoggingOut;
        protected void logout(UcUserArgs args)
        {
            if (LoggingOut != null)
                LoggingOut(this, args);
        }
        //        ///---------------------------------------------------------------------------------







        public string DisplayName
        {
            set
            {
                displayName = value;
            }
        }
        protected string displayName
        {
            get
            {
                string _displayName = "";
                Object objViewStateDisplayName = this.ViewState[this.ID + "DisplayName"];
                if (objViewStateDisplayName != null)
                    _displayName = Convert.ToString(objViewStateDisplayName);

                return _displayName;
            }
            set
            {
                this.ViewState.Remove(this.ID + "DisplayName");
                this.ViewState.Add(this.ID + "DisplayName", value);
            }
        }


        protected bool isLoginAllowed = true;
        public bool IsLoginAllowed
        {
            set
            {
                isLoginAllowed = value;
            }
        }



        protected bool isSignInAllowed = false;
        public bool IsSignInAllowed
        {
            set
            {
                isSignInAllowed = value;
            }
        }




        public void DoLogout(string message)
        {
            this.doLogout(message);
        }



        protected void Page_Init(object sender, EventArgs e)
        {
            //txtUserName.Text = "user";
//            txtUserName.Text = "agent";
            //txtUserName.Text = "admin";
            //txtUserName.Text = "contact";

//            txtPassword.TextMode = TextBoxMode.SingleLine;
//            txtPassword.Text = "welcome";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            pnlLogin.Visible = false;
            pnlLogout.Visible = false;
            //pnlSignIn.Visible = false;

            if (this.UcPage.UserName == "")
            {
                if (isLoginAllowed)
                {
                    pnlLogin.Visible = true;
                }
                else
                {
                    if (this.displayName != "")
                    {
                        pnlWelcome.Visible = true;
                        ltDisplayName.Text = this.displayName;
                    }
                }

                String userName = (string)Session["userName"];
                String password = (string)Session["password"];

                DoLogin(userName, password);

                //pnlWelcome.Visible = !isLoginAllowed;
                //pnlLogin.Visible = isLoginAllowed;

                //pnlSignIn.Visible = isSignInAllowed && isLoginAllowed;
            }
            else
            {
                pnlLogout.Visible = isLoginAllowed;
                ltUsername.Text = this.UcPage.UserName;
            }

            string url = Request.Url.ToString();
            if (url.Contains("dirCommon/ucPasswordRecovery.aspx"))
                hplPasswordRecovery.Visible = false;
            else
                hplPasswordRecovery.Visible = true;
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            //pnlLogin.DefaultButton = btnLogin.UniqueID;
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String username = txtUserName.Text;
            String password = txtPassword.Text;

            DoLogin(username, password);
        }

        private void DoLogin(String username, String password)
        {
            if (this.doLogin(username, password))
            {
                Response.Redirect("../default.aspx");
            }
            else
            {
                ltMessage.Text = "Invalid username or password";
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this.doLogout("Logged out");

            Response.Redirect("../default.aspx");
        }










        protected bool doLogin(String username, String password)
        {
            bool result = false;

            UserPool userPool = (UserPool)Application["UserPool"];
            if (userPool.RegisterUser(username, password))
            {
                ltMessage.Text = "";

                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(username, false);


                Int32 userId = userPool.GetUserId(username);
                Int32 userRoleId = userPool.GetUserRoleId(username);


                //----------------------------------------
                UcUserArgs args = new UcUserArgs();
                args.UserName = username;
                args.Password = password;
                args.UserId = userId;
                args.UserRoleId = userRoleId;
                login(args);
                //----------------------------------------

                if (!args.Cancel)
                {
                    result = true;
                }
                else
                {
                    result = false;
                    doLogout(args.Message);
                }
            }
            else
            {

            }

            return result;
        }

        protected void doLogout(string message)
        {

            //----------------------------------------
            UcUserArgs args = new UcUserArgs();
            args.UserName = "";
            args.Password = "";
            args.UserId = this.UcPage.UserId;
            args.UserRoleId = this.UcPage.UserRoleId;
            logout(args);
            //----------------------------------------


            FormsAuthentication.SignOut();

            UserPool userPool = (UserPool)Application["UserPool"];
            userPool.RemoveUser(ltUsername.Text);

            ltMessage.Text = message;
        }

    }
}
