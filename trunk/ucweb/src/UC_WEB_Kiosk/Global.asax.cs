using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Threading;

using UCENTRIK.Membership;
using UCENTRIK.GLOBAL;
using UCENTRIK.Conference;

namespace UCENTRIK.WEB
{

    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            UserPool userPool = new UserPool();
            Application.Add("UserPool", userPool);

            ////delegate botDelegate = new ( w TimerCallback(bot.doit());

            //Thread _bot = new Thread();
            //Application.Add("bot", _bot);
            //_bot.Start();


            SosBot bot = new SosBot(userPool);
            Application.Add("bot", bot);



            UcTextChatController textChatController = new UcTextChatController();
            Application.Add("UcTextChatController", textChatController);

        }

        

















        //========================================================================================================
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

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}