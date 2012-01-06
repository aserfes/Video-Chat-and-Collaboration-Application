using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Base;

namespace UCENTRIK.WEB.PLATFORM.dirAdmin
{
    public partial class languages : UcAppBasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterGroups();
        }

        protected void filterGroups()
        {
            Language.UcDataBind(0);
        }

        protected void Language_Back(object sender, UcControlArgs e)
        {
            Language.UcDataBind(0);
            mvGroup.ActiveViewIndex = 0;
        }

        protected void Language_ManageAgents(object sender, UcControlArgs e)
        {
            LanguageAgent.LanguageId = e.Id;
            LanguageAgent.UcDataBind();
            mvGroup.ActiveViewIndex = 1;
        }
    }
}