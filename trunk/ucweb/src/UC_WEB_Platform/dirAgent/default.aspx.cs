using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using UCENTRIK.LIB.Base;
using UCENTRIK.LIB.BllProxy;






using UCENTRIK.DATASETS;

//using UCENTRIK.AppSettings;
//using UCENTRIK.ROUTING;
//using UCENTRIK.LIB.CoreSystem;





namespace UcentrikWeb.dirAgent
{
    public partial class _default : UcBasePage
    {


        protected Int32 agentId;

        protected void Page_Init(object sender, EventArgs e)
        {
            agentId = ProxyHelper.GetUserAgentId(this.UserId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string pathRedirect = "CallQueue.aspx";
            if (agentId == 0)
            {
                pathRedirect = "profile.aspx";
            }
            else
            {
                IncidentDS.IncidentDSDataTable dt = BllProxyIncident.GetIncidentsByStatus(1, agentId);  // New
                if (dt.Rows.Count != 0)
                {
                    pathRedirect = "CallQueue.aspx";
                }
                else
                {
                    dt = BllProxyIncident.GetIncidentsByStatus(2, agentId);  // In-Progress
                    if (dt.Rows.Count != 0)
                    {
                        pathRedirect = "myCalls.aspx";
                    }
                    else
                    {
                        dt = BllProxyIncident.GetIncidentsByStatus(5, agentId);  // Follow-Up
                        if (dt.Rows.Count != 0)
                        {
                            pathRedirect = "followupcalls.aspx";
                        }

                        pathRedirect = "CallQueue.aspx";
                    }
                }



            }


            Response.Redirect(pathRedirect);
        }










    }
}
