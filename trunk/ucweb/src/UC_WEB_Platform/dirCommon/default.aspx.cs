using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.Templates;

namespace UcentrikWeb.dirCommon
{
    public partial class _default : UcAppBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (this.UserRoleId)
            {
                case 1: // Admin
                    Response.Redirect("../dirAdmin/default.aspx", false);
                    break;

                case 2: // Agent
                    Response.Redirect("../dirAgent/default.aspx", false);
                    break;

                case 3: // Manager
                    //Response.Redirect("../dirManager/default.aspx");
                    break;

                case 5: // Supervisor
                    Response.Redirect("../dirAdmin/default.aspx", false);
                    break;

                default:
                    Response.Redirect("../dirCommon/LogIn.aspx", false);
                    //ltHtml.Text = Templates.GetHtmlHomeScreen();
                    break;
            }
            this.Context.ApplicationInstance.CompleteRequest();
        }
    }
}
