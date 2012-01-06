using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyLanguage
    {
        public static LanguageDS.LanguageDSDataTable GetLanguageList(Int32 agent_id)
        {
            return BllLanguage.GetLanguageList(agent_id);
        }

        public static LanguageDS.LanguageDSDataTable SelectLanguage(Int32 language_id)
        {
            return BllLanguage.SelectLanguage(language_id);
        }

        public static Int32 InsertLanguage(string language_name)
        {
            return BllLanguage.InsertLanguage(language_name);
        }

        public static Int32 UpdateLanguage(Int32 language_id, string language_name)
        {
            return BllLanguage.UpdateLanguage(language_id, language_name);
        }

        public static Int32 DeleteLanguage(Int32 language_id)
        {
            return BllLanguage.DeleteLanguage(language_id);
        }
    }

    public class BllProxyLanguageAgent
    {
        public static LanguageDS.LanguageAgentDSDataTable GetAllLanguageAgents(Int32 language_id)
        {
            return BllLanguageAgent.GetAllLanguageAgents(language_id);
        }

        public static void SetLanguageAgent(Int32 language_id, Int32 agent_id, bool is_set)
        {
            BllLanguageAgent.SetLanguageAgent(language_id, agent_id, is_set);
        }
    }
}