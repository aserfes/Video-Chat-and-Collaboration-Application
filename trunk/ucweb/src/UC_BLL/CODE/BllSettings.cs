using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllSettings
    {



        public static SettingsDS.SettingsDSDataTable GetAllSettings(string category)
        {
            SettingsDS.SettingsDSDataTable dt = DalSettings.GetAllSettings(category);
            return dt;
        }


        public static SettingsDS.SettingsDSDataTable SelectSetting(string settingName, string settingCategory)
        {
            SettingsDS.SettingsDSDataTable dt = DalSettings.SelectSetting(settingName, settingCategory);
            return dt;
        }


        public static void SetSetting(string settingName, string settingCategory, string settingValue)
        {
            DalSettings.SetSetting(settingName, settingCategory, settingValue);
        }










    }
}
