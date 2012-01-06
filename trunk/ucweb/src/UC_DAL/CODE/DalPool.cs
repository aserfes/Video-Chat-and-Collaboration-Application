using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.PoolDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalPool
    {

        

        public static PoolDS.PoolDSDataTable GetAllPoolAgents()
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllPoolAgents();
        }

        public static PoolDS.PoolDSDataTable SelectPoolAgent(Int32 agentId)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(agentId);
        }

        public static void InsertPoolAgent(Int32 agentId)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Insert(agentId);
        }

        public static void DeletePoolAgent(Int32 agentId)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Delete(agentId);
        }








        public static void SetPoolAgentAvailable(Int32 agentId, bool isAvailable)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.SetPoolAgentAvailable(agentId, isAvailable);
        }

        public static void SetPoolAgentBusy(Int32 agentId, bool isBusy)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.SetPoolAgentBusy(agentId, isBusy); 
        }

        public static void SetPoolAgentIncident(Int32 agentId, Int32 incidentId)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            System.Nullable<Int32> incident_id = Helper.ResolveEmptyInt(incidentId);

            ta.SetPoolAgentIncident(agentId, incident_id);
        }

        public static void SetPoolAgentSession(Int32 agentId, Int32 incidentId)
        {
            PoolDSTableAdapter ta = new PoolDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.SetPoolAgentSession(agentId, incidentId);
        }



    }
}
