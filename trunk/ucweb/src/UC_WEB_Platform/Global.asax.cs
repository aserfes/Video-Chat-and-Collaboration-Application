using System;
using System.Web;
using System.Web.SessionState;

using UCENTRIK.GLOBAL;
using UCENTRIK.ROUTING;
using UCENTRIK.Conference;

namespace UCENTRIK.WEB.PLATFORM
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            UcGlobalHelper.UcApplicationStart(Application);
            //-----------------------------------------------------------

        
            UcTextChatController textChatController = new UcTextChatController();
            Application.Add("UcTextChatController", textChatController);

            AgentPool agentPool = new AgentPool();
            Application.Add("AgentPool", agentPool);

            UcAppBot appBot = new UcAppBot(agentPool);
            Application.Add("appBot", appBot);

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //string userName = HttpContext.Current.Items["UserName"].ToString();
            //string pageUrl = Request.Url.ToString();

            //Exception ex = Server.GetLastError();

            //string errorPath = UcGlobalHelper.UcApplicationError(userName, pageUrl, ex);
                
            //Response.Redirect(errorPath);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
