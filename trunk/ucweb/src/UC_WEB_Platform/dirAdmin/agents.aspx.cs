using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAdmin
{
    public partial class agents : UcAppBasePage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
                filterAgents();
        }

        protected void filterAgents()
        {
            sosAgent.UcDataBind();
        }

        protected void sosAgent_Back(object sender, UcControlArgs e)
        {
            sosAgent.UcDataBind();
            mvAgent.ActiveViewIndex = 0;
        }

        protected void sosAgent_ManageGroups(object sender, UcControlArgs e)
        {
            AgentGroup.AgentId = e.Id;
            AgentGroup.UcDataBind();
            mvAgent.ActiveViewIndex = 1;
        }

        protected void sosAgent_ManageSkills(object sender, UcControlArgs e)
        {
            AgentSkills.AgentId = e.Id;
            AgentSkills.UcDataBind();
            mvAgent.ActiveViewIndex = 2;
        }

        protected void sosAgent_ManageLanguages(object sender, UcControlArgs e)
        {
            AgentLanguages.AgentId = e.Id;
            AgentLanguages.UcDataBind();
            mvAgent.ActiveViewIndex = 3;
        }
    }
}

