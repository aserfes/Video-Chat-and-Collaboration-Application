using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.WEB.PLATFORM.dirAdmin
{
    public partial class settings : UcAppBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            //Label1.Text = ProxyHelper.GetSettingValueString("CrmUserName");
        }
    }
}
