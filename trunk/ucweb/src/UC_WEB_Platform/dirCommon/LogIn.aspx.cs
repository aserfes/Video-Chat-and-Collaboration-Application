using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.ROUTING;

namespace UcentrikWeb.dirCommon
{
    public partial class LogIn : Page
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            Page.Theme = "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Login_LoggedIn(object sender, UcUserArgs e)
        {
            switch (e.UserRoleId)
            {
                case 1: // Admin
                    break;

                case 2: // Agent
                    Int32 agentId = ProxyHelper.GetUserAgentId(e.UserId);
                    AgentPool agentPool = (AgentPool)Application["AgentPool"];
                    agentPool.RegisterAgent(agentId);
                    break;

                case 3: // Manager
                    break;

                case 5: // Supervisor
                    break;

                default:
                    break;
            }
        }
    }
}