using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UCENTRIK.WEB.KIOSK.Controls.Common
{
    public partial class KioskAccessDenied : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }






        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../default.aspx");
        }


    }
}