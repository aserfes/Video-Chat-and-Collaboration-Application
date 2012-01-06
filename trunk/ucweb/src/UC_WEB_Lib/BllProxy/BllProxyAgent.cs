using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
  
    
    public class BllProxyAgent
    {
        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable GetAllAgents()
        {
            return BllAgent.GetAllAgents();
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable SelectAgent(Int32 agent_id)
        {
            return BllAgent.SelectAgent(agent_id);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentDSDataTable GetAgentByUser(Int32 user_id)
        {
            return BllAgent.GetAgentByUser(user_id);
        }

        public static Int32 InsertAgent(Int32 user_id, string first_name, string last_name, string email, string phone, bool public_enabled)
        {
            return BllAgent.InsertAgent(user_id, first_name, last_name, email, phone, public_enabled);
        }

        public static Int32 UpdateAgent(Int32 agent_id, Int32 user_id, string first_name, string last_name, string email, string phone, bool public_enabled)
        {
            return BllAgent.UpdateAgent(agent_id, user_id, first_name, last_name, email, phone, public_enabled);
        }

        public static Int32 DeleteAgent(Int32 agent_id)
        {
            return BllAgent.DeleteAgent(agent_id);
        }

        public static AgentDS.AgentDSDataTable GetAgentByEmail(string email)
        {
            return BllAgent.GetAgentByEmail(email);
        }
    }



    public class BllProxyAgentGroup
    {
        public static UCENTRIK.DATASETS.AgentDS.AgentGroupDSDataTable GetAllAgentGroups(Int32 agent_id)
        {
            return BllAgentGroup.GetAllAgentGroups(agent_id);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentSkillDSDataTable GetAllAgentSkills(Int32 agent_id)
        {
            return BllAgentGroup.GetAllAgentSkills(agent_id);
        }

        public static UCENTRIK.DATASETS.AgentDS.AgentLanguageDSDataTable GetAllAgentLanguages(Int32 agent_id)
        {
            return BllAgentGroup.GetAllAgentLanguages(agent_id);
        }
    }



}
