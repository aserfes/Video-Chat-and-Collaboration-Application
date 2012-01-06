using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.Model;







namespace UCENTRIK.WEB
{
    public partial class MasterKiosk : System.Web.UI.MasterPage
    {



        public string FacilityName
        {
            set
            {
//                lblFacilityName.Text = value;
            }
        }


        public void ShowTheContent(bool show)
        {

            if (!show)
            {
                KioskContentPlaceHolder.Controls.Clear();

                UcKioskBasePage page = (UcKioskBasePage)this.Page;
                if (page.LoginAllowed)
                    KioskContentPlaceHolder.Controls.Add(ucLogin);
                else
                    KioskContentPlaceHolder.Controls.Add(AccessDenied);
            }


        }











        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        public void Start()
        {
            UcKioskBasePage page = (UcKioskBasePage)this.Page;


            //ConferenceStartupParameters parameters = ConferenceHelper.GetParametersForTransmitter(page.FacilityGuid.ToString(), page.FacilityName);
            //ConfVideo.Parameters = parameters;


            ////------------------------------------------------------------------------------------
            //ScreenCast.Parameters = parameters;

        }





        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------









        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                UcKioskBasePage page = (UcKioskBasePage)this.Page;

                this.Start();
                
                //lblKioskName.Text = page.FacilityName;
                //pnlKioskVideo.Visible = false;

            }
        }


        protected void Page_PreRender(object sender, EventArgs e)
        {
        }












        protected void ucLogin_LoggedIn(object sender, UcUserArgs e)
        {
            switch (e.UserRoleId)
            {
                case 3: // Manager
                    setCookies(e.UserName, e.Password);

                    break;

                default:
                    e.Cancel = true;
                    e.Message = "Invalid username/password";

                    break;
            }
        }



        protected void ucLogin_LoggingOut(object sender, UcUserArgs e)
        {

            switch (e.UserRoleId)
            {
                case 3: // Manager
                    killCookies();
                    break;

                default:
                    break;
            }
        }










        protected void setCookies(string userName, string password)
        {
            killCookies();


            //-----------------------------------------------
            DateTime expiration = DateTime.Now.AddDays(14);

            HttpCookie aCookieUsername = new HttpCookie("UserName");
            aCookieUsername.Value = userName;
            aCookieUsername.Expires = expiration;
            Response.Cookies.Add(aCookieUsername);

            HttpCookie aCookiePassword = new HttpCookie("Password");
            aCookiePassword.Value = password;
            aCookiePassword.Expires = expiration;
            Response.Cookies.Add(aCookiePassword);
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




















        protected void ucScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
        }




    }
}
