using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.AgentDSTableAdapters;
using UCENTRIK.DATASETS.SkillDSTableAdapters;


namespace UCENTRIK.DAL
{
  
    public class DalAgent
    {
        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable GetAllAgents()
        {
            LogDS log = new LogDS();

            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            //ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllAgents();
        }



        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable SelectAgent(Int32 agentId)
        {
            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            //ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(agentId);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable GetAgentByUser(Int32 userId)
        {
            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            //ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAgentByUser(userId);
        }

        


        public static Int32 InsertAgent(Int32 userId, string firstName, string lastName, string email, string phone, bool publicEnabled)
        {
            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            //ta.Connection.ConnectionString = UcConnection.ConnectionString;
            int id = Convert.ToInt32(ta.InsertAgent(userId, firstName, lastName, email, phone, publicEnabled));
            return id;
        }

        public static Int32 UpdateAgent(Int32 agentId, Int32 userId, string firstName, string lastName, string email, string phone, bool publicEnabled)
        {
            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            //ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Update(agentId, userId, firstName, lastName, email, phone, publicEnabled);
        }


        public static Int32 DeleteAgent(Int32 agentId)
        {
            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            //ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(agentId);
        }




        public static AgentDS.AgentDSDataTable GetAgentByEmail(string email)
        {
            AgentDSTableAdapter ta = new AgentDSTableAdapter();
            return ta.GetAgentByEmail(email);
        }
    }



    public class DalAgentGroup
    {

        public static UCENTRIK.DATASETS.AgentDS.AgentGroupDSDataTable GetAllAgentGroups(Int32 agentId)
        {
            AgentGroupDSTableAdapter ta = new AgentGroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(agentId);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentSkillDSDataTable GetAllAgentSkills(Int32 agentId)
        {
            UCENTRIK.DATASETS.AgentDSTableAdapters.AgentSkillDSTableAdapter ta = new UCENTRIK.DATASETS.AgentDSTableAdapters.AgentSkillDSTableAdapter();
            return ta.GetData(agentId);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentLanguageDSDataTable GetAllAgentLanguages(Int32 agentId)
        {
            UCENTRIK.DATASETS.AgentDSTableAdapters.AgentLanguageDSTableAdapter ta = new UCENTRIK.DATASETS.AgentDSTableAdapters.AgentLanguageDSTableAdapter();
            return ta.GetData(agentId);
        }
    }
}
