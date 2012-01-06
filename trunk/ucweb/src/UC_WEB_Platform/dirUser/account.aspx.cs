using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.ROUTING;

using System.Globalization;
using System.IO;
using System.Collections.ObjectModel;


namespace UCENTRIK.WEB.PLATFORM.dirUser
{
    public partial class account : UcAppBasePage
    {


        protected void Page_Init(object sender, EventArgs e)
        {
            this.allowTimerUpdate = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }






        ///---------------------------------------------------------------------------------
        protected void view_Back(object sender, EventArgs e)
        {
        }


        ///---------------------------------------------------------------------------------
        protected void view_Save(object sender, EventArgs e)
        {
            if (this.UserId == 0)
                this.Refresh();
        }










        //--
    }
}
