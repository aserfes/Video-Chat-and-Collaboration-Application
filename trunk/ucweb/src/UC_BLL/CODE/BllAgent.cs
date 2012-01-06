using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{

    public class BllAgent
    {

        private static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable processData(UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt)
        {
            foreach (UCENTRIK.DATASETS.AgentDS.AgentDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
            }
            
            return dt;
        }









        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable GetAllAgents()
        {
            UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt = DalAgent.GetAllAgents();
            return processData(dt);
        }



        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable SelectAgent(Int32 agentId)
        {
            UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt = DalAgent.SelectAgent(agentId);
            return processData(dt);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable GetAgentByUser(Int32 userId)
        {
            UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt = DalAgent.GetAgentByUser(userId);
            return processData(dt);
        }





        public static Int32 InsertAgent(Int32 userId, string firstName, string lastName, string email, string phone, bool publicEnabled)
        {
            return DalAgent.InsertAgent(userId, firstName, lastName, email, phone, publicEnabled);
        }

        public static Int32 UpdateAgent(Int32 agentId, Int32 userId, string firstName, string lastName, string email, string phone, bool publicEnabled)
        {
            return DalAgent.UpdateAgent(agentId, userId, firstName, lastName, email, phone, publicEnabled);
        }

        public static Int32 DeleteAgent(Int32 agentId)
        {
            return DalAgent.DeleteAgent(agentId);
        }




        public static AgentDS.AgentDSDataTable GetAgentByEmail(string email)
        {
            return DalAgent.GetAgentByEmail(email);
        }
    }



    public class BllAgentGroup
    {
        public static UCENTRIK.DATASETS.AgentDS.AgentGroupDSDataTable GetAllAgentGroups(Int32 agentId)
        {
            return DalAgentGroup.GetAllAgentGroups(agentId);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentSkillDSDataTable GetAllAgentSkills(int agent_id)
        {
            return DalAgentGroup.GetAllAgentSkills(agent_id);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentLanguageDSDataTable GetAllAgentLanguages(int agent_id)
        {
            return DalAgentGroup.GetAllAgentLanguages(agent_id);
        }
    }


}


