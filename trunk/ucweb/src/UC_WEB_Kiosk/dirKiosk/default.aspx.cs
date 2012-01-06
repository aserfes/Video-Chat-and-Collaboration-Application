using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;
using UCENTRIK.Membership;
using System.Collections.Specialized;

namespace UCENTRIK.WEB.dirKiosk
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                NameValueCollection parameters = Request.QueryString;
                foreach (String key in parameters.AllKeys)
                {
                    Session.Add(key, parameters[key]);
                }
            }

            //Read
            String userName = (string)Session["userName"];
            String password = (string)Session["password"];

            if (Request.Cookies["UserName"] != null)
            {
                HttpCookie cookieUsername = Request.Cookies["UserName"];
                userName = Server.HtmlEncode(cookieUsername.Value);
            }
            if (Request.Cookies["Password"] != null)
            {
                HttpCookie cookiePassword = Request.Cookies["Password"];
                password = Server.HtmlEncode(cookiePassword.Value);
            }

            UserPool userPool = (UserPool)Application["UserPool"];
            if (userPool.RegisterUser(userName, password))
            {
                FormsAuthentication.SignOut();
                FormsAuthentication.SetAuthCookie(userName, false);

                Response.Redirect("UcKioskConnect.aspx");
            }
            else
            {
                Response.Redirect("UcKioskLogin.aspx");
            }
        }
    }
}
