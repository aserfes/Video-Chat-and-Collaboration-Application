using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.WEB.PLATFORM.dirAdmin
{
    public partial class settings : UcAppBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                menuTabs.Items.Add(new MenuItem("CS", "0"));
                menuTabs.Items.Add(new MenuItem("Platform", "1"));
                menuTabs.Items.Add(new MenuItem("Kiosk", "2"));
            }
        }

        protected void menuTabs_MenuItemClick(object sender, MenuEventArgs e)
        {
            Int32 i = Int32.Parse(e.Item.Value);
            mvSettings.ActiveViewIndex = i;
            e.Item.Selected = true;
        }

        protected void mvSettings_ActiveViewChanged(object sender, EventArgs e)
        {
            switch (mvSettings.ActiveViewIndex)
            {
                case 0: 
                    selectConferenceServer();
                    break;

                case 1: 
                    selectPlatform();
                    break;

                case 2: 
                    selectKiosk();
                    break;

                default:
                    break;
            }
        }

        #region Select Settings

        private void selectKiosk()
        {
            SettingsKiosk.BindData("KIOSK");
        }

        private void selectPlatform()
        {
            SettingsPlatform.BindData("PLATFORM");
        }

        private void selectConferenceServer()
        {
            SettingsCS.BindData("CTX_SERVER");
        }

        #endregion
    }
}
