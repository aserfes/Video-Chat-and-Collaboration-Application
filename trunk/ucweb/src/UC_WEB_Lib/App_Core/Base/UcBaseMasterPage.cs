using System;
using System.Web.UI;

using UCENTRIK.LIB.CoreSystem;
//using UCENTRIK.AppSettings;


namespace UCENTRIK.LIB.Base
{
    public class UcBaseMasterPage : MasterPage
    {
        protected UcBasePage page;
        protected bool isInAsyncPostBack = false;
        protected ScriptManager UcScriptManager;


        protected override void OnInit(EventArgs e)
        {
            ScriptManager UcScriptManager = (ScriptManager)this.FindControl("UcScriptManager");
            if (UcScriptManager != null)
                this.isInAsyncPostBack = UcScriptManager.IsInAsyncPostBack;
            Context.Items.Add("IsInAsyncPostBack", this.isInAsyncPostBack);


            //-------------
            base.OnInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {

            //-------------
            base.OnLoad(e);
        }












        protected void ucScriptManager_AsyncPostBackError(object sender, AsyncPostBackErrorEventArgs e)
        {
            string userName = "";
            string pageUrl = "";
            //string app = UcConfParameters.UcAppName;

            if (page != null)
            {
                userName = page.UserName;
                pageUrl = page.Request.Url.ToString();
            }

            Exception ex = new Exception("UCENTRIK Exception Code: " + "AJAX", e.Exception);
            UcSystem.HandleException(ex, userName, pageUrl);

            string errorPath = AppHelper.GetApplicationPath("~/dirApp/error.aspx?code=AJAX");
            Response.Redirect(errorPath);
        }


    }
}
