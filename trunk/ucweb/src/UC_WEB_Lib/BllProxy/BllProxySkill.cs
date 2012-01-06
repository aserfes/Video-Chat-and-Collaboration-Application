using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxySkill
    {
        public static SkillDS.SkillDSDataTable GetSkillList(Int32 agent_id)
        {
            return BllSkill.GetSkillList(agent_id);
        }

        public static SkillDS.SkillDSDataTable SelectSkill(Int32 skill_id)
        {
            return BllSkill.SelectSkill(skill_id);
        }

        public static Int32 InsertSkill(string skill_name)
        {
            return BllSkill.InsertSkill(skill_name);
        }

        public static Int32 UpdateSkill(Int32 skill_id, string skill_name)
        {
            return BllSkill.UpdateSkill(skill_id, skill_name);
        }

        public static Int32 DeleteSkill(Int32 skill_id)
        {
            return BllSkill.DeleteSkill(skill_id);
        }
    }

    public class BllProxySkillAgent
    {
        public static SkillDS.SkillAgentDSDataTable GetAllSkillAgents(Int32 skill_id)
        {
            return BllSkillAgent.GetAllSkillAgents(skill_id);
        }

        public static void SetSkillAgent(Int32 skill_id, Int32 agent_id, bool is_set)
        {
            BllSkillAgent.SetSkillAgent(skill_id, agent_id, is_set);
        }
    }
}