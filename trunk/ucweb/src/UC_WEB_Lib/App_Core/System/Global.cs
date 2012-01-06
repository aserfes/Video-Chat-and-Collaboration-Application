using System;
using System.Web;
using System.Threading;

using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;
using UCENTRIK.Membership;
using UCENTRIK.LIB.CoreSystem;





namespace UCENTRIK.GLOBAL
{


    public class SosBot
    {
        private UserPool _userPool;

        public SosBot(UserPool userPool)
        {
            _userPool = userPool;

            Thread threadBot = new Thread(this._doRoutine);
            threadBot.Start();
        }

        private void _doRoutine()
        {
            Thread.Sleep(10000);        // delay 10 sec


            while (true)
            {
                try
                {
                    _userPool.CleanUp();

                }
                catch { }

                Thread.Sleep(1000);     // repeat every 1 sec
            }

        } 
    }





    public class UcGlobalHelper
    {

        public static void UcApplicationStart(HttpApplicationState app)
        {
            UserDS.UserDSDataTable dt = BllProxyUser.GetUsersByRole(1, 1);
            if (dt.Rows.Count == 0)
            {
                BllProxyUser.InsertUser("admin", "Admin", "Admin", "welcome", 1, "");
            }

            UserPool userPool = new UserPool();
            app.Add("UserPool", userPool);

            SosBot bot = new SosBot(userPool);
            app.Add("bot", bot);
        }

        public static string UcApplicationError(string userName, string pageUrl, Exception ex)
        {
            UcSystem.HandleException(ex, userName, pageUrl);
            string errorPath = AppHelper.GetApplicationPath("~/dirApp/error.aspx?code=0");

            return errorPath;
        }

    }


}
