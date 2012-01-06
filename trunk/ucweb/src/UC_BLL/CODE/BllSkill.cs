using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{
    public class BllSkill
    {
        public static SkillDS.SkillDSDataTable GetSkillList(Int32 agentId)
        {
            return DalSkill.GetSkillList(agentId);
        }

        public static SkillDS.SkillDSDataTable SelectSkill(Int32 skillId)
        {
            return DalSkill.SelectSkill(skillId);
        }

        public static Int32 InsertSkill(string skillName)
        {
            return DalSkill.InsertSkill(skillName);
        }

        public static Int32 UpdateSkill(Int32 skillId, string skillName)
        {
            return DalSkill.UpdateSkill(skillId, skillName);
        }

        public static Int32 DeleteSkill(Int32 skillId)
        {
            return DalSkill.DeleteSkill(skillId);
        }
    }

    public class BllSkillAgent
    {
        private static SkillDS.SkillAgentDSDataTable processData(SkillDS.SkillAgentDSDataTable dt)
        {
            foreach (SkillDS.SkillAgentDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }

        public static void SetSkillAgent(Int32 skillId, Int32 agentId, bool isSet)
        {
            DalSkillAgent.SetSkillAgent(skillId, agentId, isSet);
        }

        public static SkillDS.SkillAgentDSDataTable GetAllSkillAgents(Int32 skillId)
        {
            SkillDS.SkillAgentDSDataTable dt = DalSkillAgent.GetAllSkillAgents(skillId);
            return processData(dt);
        }
    }

}
