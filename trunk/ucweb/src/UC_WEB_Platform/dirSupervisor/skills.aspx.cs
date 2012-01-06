using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.Base;

namespace UCENTRIK.WEB.PLATFORM.dirAdmin
{
    public partial class skills : UcAppBasePage
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
            Skill.UcDataBind(0);
        }

        protected void Skill_Back(object sender, UcControlArgs e)
        {
            Skill.UcDataBind(0);
            mvGroup.ActiveViewIndex = 0;
        }

        protected void Skill_ManageAgents(object sender, UcControlArgs e)
        {
            SkillAgent.SkillId = e.Id;
            SkillAgent.UcDataBind();
            mvGroup.ActiveViewIndex = 1;
        }
    }
}