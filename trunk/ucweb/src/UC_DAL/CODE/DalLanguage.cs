using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCENTRIK.DATASETS.LanguageDSTableAdapters;
using UCENTRIK.DATASETS;

namespace UCENTRIK.DAL
{
    public class DalLanguage
    {
        public static LanguageDS.LanguageDSDataTable GetLanguageList(Int32 agentId)
        {
            LanguageDSTableAdapter ta = new LanguageDSTableAdapter();
            return ta.GetLanguageList(agentId);
        }

        public static LanguageDS.LanguageDSDataTable SelectLanguage(Int32 languageId)
        {
            LanguageDSTableAdapter ta = new LanguageDSTableAdapter();
            return ta.GetData(languageId);
        }

        public static Int32 InsertLanguage(string languageName)
        {
            LanguageDSTableAdapter ta = new LanguageDSTableAdapter();
            return Convert.ToInt32(ta.InsertLanguage(languageName));
        }

        public static Int32 UpdateLanguage(Int32 languageId, string languageName)
        {
            LanguageDSTableAdapter ta = new LanguageDSTableAdapter();
            return ta.Update(languageId, languageName);
        }

        public static Int32 DeleteLanguage(Int32 languageId)
        {
            LanguageDSTableAdapter ta = new LanguageDSTableAdapter();
            return ta.Delete(languageId);
        }

    }

    public class DalLanguageAgent
    {
        public static LanguageDS.LanguageAgentDSDataTable GetAllLanguageAgents(Int32 languageId)
        {
            LanguageAgentDSTableAdapter ta = new LanguageAgentDSTableAdapter();
            return ta.GetData(languageId);
        }

        public static void SetLanguageAgent(Int32 languageId, Int32 agentId, bool isSet)
        {
            LanguageAgentDSTableAdapter ta = new LanguageAgentDSTableAdapter();
            ta.SetLanguageAgent(agentId, languageId, isSet);
        }
    }
}
