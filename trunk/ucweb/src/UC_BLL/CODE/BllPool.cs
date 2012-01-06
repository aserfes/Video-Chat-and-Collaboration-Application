using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllPool
    {

        private static PoolDS.PoolDSDataTable processData(PoolDS.PoolDSDataTable dt)
        {
            foreach (PoolDS.PoolDSRow row in dt.Rows)
            {
                row.agent_full_name = Helper.GetFullName(row.agent_first_name, row.agent_last_name);
            }

            return dt;
        }







        public static PoolDS.PoolDSDataTable GetAllPoolAgents()
        {
            PoolDS.PoolDSDataTable dt = DalPool.GetAllPoolAgents();
            return processData(dt);
        }


        public static PoolDS.PoolDSDataTable SelectPoolAgent(Int32 agentId)
        {
            PoolDS.PoolDSDataTable dt = DalPool.SelectPoolAgent(agentId);
            return processData(dt);
        }

        public static void InsertPoolAgent(Int32 agentId)
        {
            DalPool.InsertPoolAgent(agentId);
        }

        public static void DeletePoolAgent(Int32 agentId)
        {
            DalPool.DeletePoolAgent(agentId);
        }









        public static void SetPoolAgentAvailable(Int32 agentId, bool isAvailable)
        {
            DalPool.SetPoolAgentAvailable(agentId, isAvailable);
        }

        public static void SetPoolAgentBusy(Int32 agentId, bool isBusy)
        {
            DalPool.SetPoolAgentBusy(agentId, isBusy);
        }

        public static void SetPoolAgentIncident(Int32 agentId, Int32 incidentId)
        {
            DalPool.SetPoolAgentIncident(agentId, incidentId);
        }

        public static void SetPoolAgentSession(Int32 agentId, Int32 incidentId)
        {
            DalPool.SetPoolAgentSession(agentId, incidentId);
        }




    }
}
