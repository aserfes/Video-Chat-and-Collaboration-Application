using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.ROUTING;
using UCENTRIK.DATASETS;


namespace UcentrikWeb.dirAgent
{
    public partial class profile : UcAppBasePage
    {
        protected Int32 agentId;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.allowTimerUpdate = false;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            agentId = ProxyHelper.GetUserAgentId(this.UserId);
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
                sosProfile.AgentId = agentId;
        }

        ///---------------------------------------------------------------------------------
        protected void view_Back(object sender, EventArgs e)
        {
            SetAgentId();
        }

        ///---------------------------------------------------------------------------------
        protected void view_Save(object sender, EventArgs e)
        {
            bool isNew = false;
            if (agentId == 0)
            {
                isNew = true;

                agentId = ProxyHelper.GetUserAgentId(this.UserId);
                sosProfile.AgentId = agentId;

                AgentPool agentPool = (AgentPool)Application["AgentPool"];
                agentPool.RegisterAgent(agentId);
            }


            if (agentId != 0)
            {
                UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt = BllProxyAgent.SelectAgent(agentId);
                if (dt.Rows.Count != 0)
                {
                    string firstName = dt[0].first_name;
                    string lastName = dt[0].last_name;
                    string email = dt[0].email;
                    BllProxyUserHelper.UpdateUserDetails(this.UserId, firstName, lastName, email);

                }
            }

            if(isNew)
                this.Refresh();

        }

        //TODO: Link "Manage Group" is not correct because of agent can only view info, not manage.

        protected void sosAgent_Back(object sender, UcControlArgs e)
        {
            SetAgentId();
            mvProfile.ActiveViewIndex = 0;
        }

        protected void sosAgent_ManageGroups(object sender, UcControlArgs e)
        {
            AgentGroup.AgentId = e.Id;
            AgentGroup.UcDataBind();
            mvProfile.ActiveViewIndex = 1;
        }

        protected void sosAgent_ManageSkills(object sender, UcControlArgs e)
        {
            AgentSkills.AgentId = e.Id;
            AgentSkills.UcDataBind();
            mvProfile.ActiveViewIndex = 2;
        }

        protected void sosAgent_ManageLanguages(object sender, UcControlArgs e)
        {
            AgentLanguages.AgentId = e.Id;
            AgentLanguages.UcDataBind();
            mvProfile.ActiveViewIndex = 3;
        }

        private void SetAgentId()
        {
            if (agentId == 0)
            {
                agentId = ProxyHelper.GetUserAgentId(this.UserId);
                sosProfile.AgentId = agentId;
            }
        }
    }
}
