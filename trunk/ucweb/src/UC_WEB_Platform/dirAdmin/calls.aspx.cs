using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;


namespace UcentrikWeb.dirAdmin
{
    public partial class incidents : UcAppBasePage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            sosIncident.UcHeaderControl = pnlPageHeader;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                
                ddlIncidentStatus.DataSource = BllProxyLookup.GetIncidentStatuses();
                ddlIncidentStatus.DataBind();
                ListItem item = new ListItem("All", "0");
                ddlIncidentStatus.Items.Insert(0, item);
                ddlIncidentStatus.Items.FindByValue("0").Selected = true;


                ddlAgents.DataSource = BllProxyAgent.GetAllAgents();
                ddlAgents.DataBind();
                ListItem item1 = new ListItem("All", "0");
                ddlAgents.Items.Insert(0, item1);
                ddlAgents.Items.FindByValue("0").Selected = true;


                filterIncidents();
            }
        }

        protected void ddlIncident_SelectedIndexChanged(object sender, EventArgs e)
        {
            filterIncidents();
        }




        protected void filterIncidents()
        {
            Int32 incidentStatusId = Convert.ToInt32(ddlIncidentStatus.SelectedValue);
            Int32 agentId = Convert.ToInt32(ddlAgents.SelectedValue);


            //sosIncident.AgentId = agentId;
            sosIncident.UcDataBind(incidentStatusId, agentId);
        }

    }
}

