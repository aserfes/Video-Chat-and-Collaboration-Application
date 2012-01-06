using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.SettingsDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalSettings
    {



        public static SettingsDS.SettingsDSDataTable GetAllSettings(string category)
        {
            SettingsDSTableAdapter ta = new SettingsDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllSettings(category);
        }


        public static SettingsDS.SettingsDSDataTable SelectSetting(string settingName, string settingCategory)
        {
            SettingsDSTableAdapter ta = new SettingsDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(settingName, settingCategory);
        }


        public static void SetSetting(string settingName, string settingCategory, string settingValue)
        {
            SettingsDSTableAdapter ta = new SettingsDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Update(settingName, settingCategory, settingValue);
        }







    }
}
