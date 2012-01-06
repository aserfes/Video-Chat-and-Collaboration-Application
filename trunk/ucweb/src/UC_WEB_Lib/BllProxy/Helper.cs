using System;
using System.Web;

using UCENTRIK.LIB.Base;
//using UCENTRIK.LIB.BllProxy;
using UCENTRIK.DATASETS;
using System.Data;
using System.Collections.Generic;



namespace UCENTRIK.LIB.BllProxy
{
    public enum UserRole
    {
        Administrator = 1,
        Agent,
        Manager,
        User, 
        Supervisor
    }

    public class ProxyHelper
    {

        public static Int32 GetUserAgentId(Int32 userId)
        {
            Int32 id = 0;
            UCENTRIK.DATASETS.AgentDS.AgentDSDataTable dt = BllProxyAgent.GetAgentByUser(userId);

            if (dt.Rows.Count > 0)
                id = dt[0].agent_id;

            return id;
        }

        public static Int32 GetUserContactId(Int32 userId)
        {
            Int32 id = 0;
            ContactDS.ContactDSDataTable dt = BllProxyContact.GetUserContactId(userId);

            if (dt.Rows.Count > 0)
                id = dt[0].contact_id;

            return id;
        }

























        public static string GetSettingValueString(string settingName, string settingCategory)
        {
            string s = "";
            SettingsDS.SettingsDSDataTable dt = BllProxySettings.SelectSetting(settingName, settingCategory);

            if (dt.Rows.Count > 0)
                s = dt[0].value;

            return s;
        }

        public static Int32 GetSettingValueInt(string settingName, string settingCategory)
        {
            Int32 result = 0;

            Int32 i = 0;
            SettingsDS.SettingsDSDataTable dt = BllProxySettings.SelectSetting(settingName, settingCategory);

            string s = "";
            if (dt.Rows.Count > 0)
                s = dt[0].value;


            if (Int32.TryParse(s, out i))
            {
                result = i;
            }


            return result;
        }

        public static bool GetSettingValueBoolean(string settingName, string settingCategory)
        {
            bool result = false;

            bool b = false;
            SettingsDS.SettingsDSDataTable dt = BllProxySettings.SelectSetting(settingName, settingCategory);

            string s = "";
            if (dt.Rows.Count > 0)
                s = dt[0].value;


            if (bool.TryParse(s, out b))
            {
                result = b;
            }

            return result;
        }




        internal static void FilterForLoginUser(int login_user_role_id, System.Data.DataRowCollection drc)
        {
            List<DataRow> remove = new List<DataRow>();
            foreach (DataRow row in drc)
            {
                if (login_user_role_id == (int)UserRole.Supervisor)
                {
                    int role = Int32.Parse(row["user_role_id"].ToString());
                    if (role != (int)UserRole.Agent && role != (int)UserRole.Manager && role != (int)UserRole.User)
                    {
                        remove.Add(row);
                    }
                }
            }

            foreach (DataRow row in remove)
            {
                drc.Remove(row);
            }
        }
    }


}
