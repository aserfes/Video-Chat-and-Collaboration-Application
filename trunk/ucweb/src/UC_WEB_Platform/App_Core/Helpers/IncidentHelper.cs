using System;
using System.Collections.Generic;
using System.Web;


using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.ROUTING;




namespace UCENTRIK.Helpers
{
    public class IncidentPlatformHelper
    {

        protected static AgentPool agentPool = (AgentPool)HttpContext.Current.Application["AgentPool"];


        
        public static bool OpenIncident(Int32 incidentId, Int32 agentId, out string msg)
        {
            msg = "";
            bool success = false;
            agentPool.SetAgentBusy(agentId, true);


            BllProxyIncidentState.InsertIncidentState(incidentId, true, "NEW");


            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.OpenIncident(incidentId, agentId);
            if (dt.Rows.Count != 0)
            {
                if (dt[0].status_id == 2)
                {
                    if ((!dt[0].Isreserved_agent_idNull()) && (dt[0].reserved_agent_id != agentId))
                    {
                        msg = "The incident is RESERVED";
                    }
                    else
                    {
                        Int32 incidentAgentId = dt[0].agent_id;
                        String incidentAgentName = dt[0].agent_full_name;

                        if (incidentAgentId != agentId)
                        {
                            msg = "The incident is in progress with " + incidentAgentName;
                        }
                        else
                        {
                            success = true;
                        }
                    }
                }
                else
                {
                    msg = "canceled";
                }
            }
            else
            {
                msg = "The incident has already been processed";
            }


            if (success)
            {
                agentPool.ReleaseIncident(incidentId);
                agentPool.SetSession(agentId, incidentId);
            }
            else
            {
                agentPool.SetAgentBusy(agentId, false);
            }



            return success;
        }




        public static bool OpenFollowUpIncident(Int32 incidentId, Int32 agentId, out string msg)
        {
            msg = "";
            bool success = false;
            agentPool.SetAgentBusy(agentId, true);


            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.OpenFollowUpIncident(incidentId, agentId);
            if (dt.Rows.Count != 0)
            {
                if (dt[0].status_id == 5)
                {

                    //if ((!dt[0].Isreserved_agent_idNull()) && (dt[0].reserved_agent_id != agentId))
                    //{
                    //    msg = "The incident is RESERVED";
                    //}
                    //else
                    //{
                        Int32 incidentAgentId = dt[0].agent_id;
                        String incidentAgentName = dt[0].agent_full_name;

                        if (incidentAgentId != agentId)
                        {
                            msg = "The incident is in progress with " + incidentAgentName;
                        }
                        else
                        {
                            success = true;
                        }
                    //}
                }
                else
                {
                    msg = "canceled";
                }
            }
            else
            {
                msg = "The incident has already been processed";
            }


            if (success)
            {
                agentPool.ReleaseIncident(incidentId);
                agentPool.SetSession(agentId, incidentId);
            }
            else
            {
                agentPool.SetAgentBusy(agentId, false);
            }



            return success;
        }




        ////------------------------------------------------------------------------------------
        ////------------------------------------------------------------------------------------
        ////------------------------------------------------------------------------------------
        //public static void SetIncidentStateActive(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "ACT");
        //}
        //public static void SetIncidentStateVideoSession(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "VID");
        //}
        //public static void SetIncidentStateScreenCast(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "SCT");
        //}
        //public static void SetIncidentStateAppShareSend(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "APS");
        //}
        //public static void SetIncidentStateAppShareReceive(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "APR");
        //}
        //public static void SetIncidentStateInactive(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, false, "CLS");
        //}




        ////------------------------------------------------------------------------------------






    }

}
