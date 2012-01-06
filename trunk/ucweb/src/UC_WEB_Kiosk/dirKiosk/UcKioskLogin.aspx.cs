using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;

namespace UCENTRIK.WEB.KIOSK.dirKiosk
{
    public partial class UcKioskLogin : UcKioskBasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            this.LoginAllowed = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

