using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.Security;




namespace UCENTRIK.WEB
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Redirect("~/dirKioskPage/default.aspx");
            //Response.Redirect("dirMobile/default.aspx");
        }
    }
}
