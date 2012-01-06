using System;
using System.Collections.Generic;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyPool
    {


        public static PoolDS.PoolDSDataTable GetAllPoolAgents()
        {
            return BllPool.GetAllPoolAgents();
        }



        public static PoolDS.PoolDSDataTable SelectPoolAgent(Int32 agent_id)
        {
            return BllPool.SelectPoolAgent(agent_id);
        }

        public static void InsertPoolAgent(Int32 agent_id)
        {
            BllPool.InsertPoolAgent(agent_id);
        }

        public static void DeletePoolAgent(Int32 agent_id)
        {
            BllPool.DeletePoolAgent(agent_id);
        }








        public static void SetPoolAgentAvailable(Int32 agent_id, bool is_available)
        {
            BllPool.SetPoolAgentAvailable(agent_id, is_available);
        }

        public static void SetPoolAgentBusy(Int32 agent_id, bool is_busy)
        {
            BllPool.SetPoolAgentBusy(agent_id, is_busy);
        }

        public static void SetPoolAgentIncident(Int32 agent_id, Int32 incident_id)
        {
            BllPool.SetPoolAgentIncident(agent_id, incident_id);
        }

        public static void SetPoolAgentSession(Int32 agent_id, Int32 incident_id)
        {
            BllPool.SetPoolAgentSession(agent_id, incident_id);
        }




    }


}
