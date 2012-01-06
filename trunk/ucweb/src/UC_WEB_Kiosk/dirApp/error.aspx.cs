using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SOS.Base;
using SOS.BllProxy;
using SosWebControlPrototype;

namespace SosWebPrototype.dirApp
{
    public partial class error : SosAppBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            object obj = Request.QueryString["code"];

            if (obj != null)
            {
                string code = Request.QueryString["code"].ToString();

                if (code != "0")
                {
                    string userName = this.UserName;
                    string pageUrl = "";

                    Exception ex = new Exception("SOS Exception Code: " + code);
                    SosSystem.HandleException(ex, userName, pageUrl);
                }
                else if (code != "AJAX")
                {
                }


                lblCode.Text = code;
            }
            else
            {
                lblCode.Text = "UNKNOWN";

            }



        }
    }
}
