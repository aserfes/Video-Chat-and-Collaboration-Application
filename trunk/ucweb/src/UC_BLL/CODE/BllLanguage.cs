using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{
    public class BllLanguage
    {
        public static LanguageDS.LanguageDSDataTable GetLanguageList(Int32 agentId)
        {
            return DalLanguage.GetLanguageList(agentId);
        }

        public static LanguageDS.LanguageDSDataTable SelectLanguage(Int32 languageId)
        {
            return DalLanguage.SelectLanguage(languageId);
        }

        public static Int32 InsertLanguage(string languageName)
        {
            return DalLanguage.InsertLanguage(languageName);
        }

        public static Int32 UpdateLanguage(Int32 languageId, string languageName)
        {
            return DalLanguage.UpdateLanguage(languageId, languageName);
        }

        public static Int32 DeleteLanguage(Int32 languageId)
        {
            return DalLanguage.DeleteLanguage(languageId);
        }
    }

    public class BllLanguageAgent
    {
        private static LanguageDS.LanguageAgentDSDataTable processData(LanguageDS.LanguageAgentDSDataTable dt)
        {
            foreach (LanguageDS.LanguageAgentDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }

        public static void SetLanguageAgent(Int32 languageId, Int32 agentId, bool isSet)
        {
            DalLanguageAgent.SetLanguageAgent(languageId, agentId, isSet);
        }

        public static LanguageDS.LanguageAgentDSDataTable GetAllLanguageAgents(Int32 languageId)
        {
            LanguageDS.LanguageAgentDSDataTable dt = DalLanguageAgent.GetAllLanguageAgents(languageId);
            return processData(dt);
        }
    }

}
