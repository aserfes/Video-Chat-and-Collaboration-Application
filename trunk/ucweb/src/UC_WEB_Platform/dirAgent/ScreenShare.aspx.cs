using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.BllProxy;
using System.Configuration;
using UCENTRIK.LIB.Helpers;

namespace UCENTRIK.WEB.PLATFORM.dirAgent
{
    public partial class ScreenShare : System.Web.UI.Page
    {
        private string uiControlWidth;
        private string uiControlHeight;
		protected string uctx_cab;

        protected string UIControlWidth
        {
            get
            {
                return uiControlWidth;
            }
        }
        protected string UIControlHeight
        {
            get
            {
                return uiControlHeight;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
				uctx_cab = System.Configuration.ConfigurationManager.AppSettings[ "uctx.cab" ];

                UCTXHelper.AddUCTXObjectsToHeader(Page);
                LoadCoreJS();
                UCTXHelper.SetCommonSettings(Page);
                UpdateEvents();

                uiControlWidth = ProxyHelper.GetSettingValueString("ScreenUIControlWidth", "PLATFORM");
                uiControlHeight = ProxyHelper.GetSettingValueString("ScreenUIControlHeight", "PLATFORM");
            }
        }

        private void UpdateEvents()
        {
            string confID = Request["confId"];
            string script = null;
            string viewMethod = ProxyHelper.GetSettingValueString("ScreenViewMethod", "PLATFORM");

            script = string.Format(
                "javascript:StartScreenSubscriber(5, {0}, 2, 1, 0, 'wye_uic_screen', {1}, 'OnRefreshSubscriber');return false;",
                confID, viewMethod);
            ButtonStart.OnClientClick = script;

            script = string.Format("javascript:StopScreenSubscriber('scrs5_{0}_2_1_1');return false;", confID);
            ButtonStop.OnClientClick = script;

            script = string.Format(
                "javascript:ScreenSubscriberControlBy('conn5_{0}_2', 'scrs5_{0}_2_1_1');return false;",
                confID);
            ButtonControl.OnClientClick = script;

            script = "function OnDestroy() { " + 
                string.Format("SendStopAppshareRequest('conn5_{0}_2');", confID) +
                "}";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OnDestroy", script, true);

            script = string.Format("StartScreenSubscriber(5, {0}, 2, 1, 0, 'wye_uic_screen', {1}, 'OnRefreshSubscriber', true);", confID, viewMethod);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "OnCreate", script, true);
        }

        private void LoadCoreJS()
        {
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("uctx"))
            {
                ScriptManager.RegisterClientScriptInclude(Page, Page.GetType(), "uctx", ResolveClientUrl("~/dirJavascript/uctx_core.js"));
            }
            if (!Page.ClientScript.IsClientScriptIncludeRegistered("screen"))
            {
                ScriptManager.RegisterClientScriptInclude(Page, Page.GetType(), "screen", ResolveClientUrl("~/dirJavascript/screen.js"));
            }
        }
    }
}