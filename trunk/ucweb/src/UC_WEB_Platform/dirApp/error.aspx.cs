using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.LIB.CoreSystem;






namespace UcentrikWeb.dirApp
{
    public partial class error : UcAppBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object obj = Request.QueryString["code"];

            if (obj != null)
            {
                string code = Request.QueryString["code"].ToString();

                //if (code != "0")
                //{
                //    string userName = this.UserName;
                //    string pageUrl = "";

                //    Exception ex = new Exception("UCENTRIK Exception Code: " + code);
                //    UcSystem.HandleException(ex, userName, pageUrl);
                //}
                //else if (code != "AJAX")
                //{
                //}


                if (code != "0")
                {
                    if (code != "AJAX")
                    {
                        string userName = this.UserName;
                        string pageUrl = "";

                        Exception ex = new Exception("UCENTRIK Exception Code: " + code);
                        UcSystem.HandleException(ex, userName, pageUrl);
                    }
                }




                //lblCode.Text = code;
            }
            else
            {
                //lblCode.Text = "UNKNOWN";

            }



        }
    }
}
