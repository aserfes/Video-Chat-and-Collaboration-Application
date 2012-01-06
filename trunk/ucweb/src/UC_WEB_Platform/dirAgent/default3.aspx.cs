//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;

//namespace UCENTRIK.WEB.PLATFORM.dirAgent
//{
//    public partial class default3 : System.Web.UI.Page
//    {
//        protected void Page_Load(object sender, EventArgs e)
//        {

//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UcentrikWeb.dirAgent
{
    public partial class default3 : UcBasePage
    {


        protected Int32 agentId;

        protected void Page_Init(object sender, EventArgs e)
        {
            agentId = ProxyHelper.GetUserAgentId(this.UserId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (agentId == 0)
                Response.Redirect("profile.aspx");
            else
                Response.Redirect("facilities.aspx");
        }
    }
}
