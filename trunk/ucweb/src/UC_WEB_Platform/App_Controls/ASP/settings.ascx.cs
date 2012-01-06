using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;

using UCENTRIK.LIB.BllProxy;

using System.Runtime.Serialization;
using System.Text;


namespace UCENTRIK.WEB.PLATFORM.App_Controls.ASP
{
    public partial class settings : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void BindData(string categoryName)
        {
            SettingsDS.SettingsDSDataTable dt1 = BllProxySettings.GetAllSettings(categoryName);
            rptSettingsCtxServer.DataSource = dt1;
            rptSettingsCtxServer.DataBind();
        }
    }
}