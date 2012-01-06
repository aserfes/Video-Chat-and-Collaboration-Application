using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.Membership;



namespace UCENTRIK.UserControls.Controls
{
    public partial class Logout : UcKioskBaseControl
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            ltUsername.Text = this.UcPage.UserName;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            UserPool userPool = (UserPool)Application["UserPool"];
            userPool.RemoveUser(this.UcPage.UserName);

            killCookies();

            this.UcKioskPage.Refresh();
        }



        protected void killCookies()
        {
            DateTime expiration = DateTime.Now.AddDays(-1);

            HttpCookie aCookieUsername = Request.Cookies["UserName"];
            if (aCookieUsername != null)
            {
                aCookieUsername.Value = null;
                aCookieUsername.Expires = expiration;
                Response.AppendCookie(aCookieUsername);
            }

            HttpCookie aCookiePassword = Request.Cookies["Password"];
            if (aCookiePassword != null)
            {
                aCookiePassword.Value = null;
                aCookiePassword.Expires = expiration;
                Response.AppendCookie(aCookiePassword);
            }
        }


    }
}