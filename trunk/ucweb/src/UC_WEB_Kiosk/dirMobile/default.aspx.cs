using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;





namespace UCENTRIK.WEB.KIOSK.dirMobile
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnConnect_Click(object sender, EventArgs e)
        {
            Int32 incidentId = BllProxyIncident.InsertIncident(0, 0, 0, 1, 0, 0);

            Response.Redirect("pageConnect.aspx?id=" + incidentId.ToString());
        }
    }
}
