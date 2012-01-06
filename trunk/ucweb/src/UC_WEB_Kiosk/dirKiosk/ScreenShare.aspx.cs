using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.BllProxy;
using System.Configuration;
using UCENTRIK.LIB.Helpers;

namespace UCENTRIK.WEB.KIOSK.dirKiosk
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

                uiControlWidth = ProxyHelper.GetSettingValueString("ScreenUIControlWidth", "KIOSK");
                uiControlHeight = ProxyHelper.GetSettingValueString("ScreenUIControlHeight", "KIOSK");
            }
        }

        private void UpdateEvents()
        {
            string confID = Request["confId"];
            string script = null;
            string viewMethod = ProxyHelper.GetSettingValueString("ScreenViewMethod", "KIOSK");

            script = "javascript:StartScreenSubscriber(5, " + confID + ", 1, 2, 1, 'wye_uic_screen', " + viewMethod + ",'OnRefreshSubscriber');";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "StartScreenSubscriber", script, true);

            script = "javascript:ScreenSubscriberControlBy('conn5_" + confID + "_1', 'scrs5_" + confID + "_1_2_1');";
            ButtonControl.OnClientClick = script + "return false;";
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