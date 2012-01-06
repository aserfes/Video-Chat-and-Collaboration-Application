using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCENTRIK.DATASETS.SkillDSTableAdapters;
using UCENTRIK.DATASETS;

namespace UCENTRIK.DAL
{
    public class DalSkill
    {
        public static SkillDS.SkillDSDataTable GetSkillList(Int32 agentId)
        {
            SkillDSTableAdapter ta = new SkillDSTableAdapter();
            return ta.GetSkillList(agentId);
        }

        public static SkillDS.SkillDSDataTable SelectSkill(Int32 skillId)
        {
            SkillDSTableAdapter ta = new SkillDSTableAdapter();
            return ta.GetData(skillId);
        }

        public static Int32 InsertSkill(string skillName)
        {
            SkillDSTableAdapter ta = new SkillDSTableAdapter();
            return Convert.ToInt32(ta.InsertSkill(skillName));
        }

        public static Int32 UpdateSkill(Int32 skillId, string skillName)
        {
            SkillDSTableAdapter ta = new SkillDSTableAdapter();
            return ta.Update(skillId, skillName);
        }

        public static Int32 DeleteSkill(Int32 skillId)
        {
            SkillDSTableAdapter ta = new SkillDSTableAdapter();
            return ta.Delete(skillId);
        }

    }

    public class DalSkillAgent
    {
        public static SkillDS.SkillAgentDSDataTable GetAllSkillAgents(Int32 skillId)
        {
            SkillAgentDSTableAdapter ta = new SkillAgentDSTableAdapter();
            return ta.GetData(skillId);
        }

        public static void SetSkillAgent(Int32 skillId, Int32 agentId, bool isSet)
        {
            SkillAgentDSTableAdapter ta = new SkillAgentDSTableAdapter();
            ta.SetSkillAgent(agentId, skillId, isSet);
        }
    }
}
