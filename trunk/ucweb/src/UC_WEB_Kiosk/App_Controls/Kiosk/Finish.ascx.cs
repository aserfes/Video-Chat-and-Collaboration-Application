using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;

using UCENTRIK.WEB.KIOSK.Kiosk;


namespace UCENTRIK.WEB.KIOSK.Connect
{
    public partial class Finish : UcKioskConnectBaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			//if( !this.Page.IsPostBack )
			//{
			//    Start();
			//}
        }

        public void Start()
        {
            string script = "window.open('../close.htm', '_self', null);";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "CloseWin", script, true);
        }
    }
}