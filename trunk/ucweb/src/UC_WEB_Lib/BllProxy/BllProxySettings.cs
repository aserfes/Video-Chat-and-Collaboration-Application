using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{

    public class BllProxyCache
    {
        protected static bool byPass = true;

        protected static Int32 cachePeriodHours = 12;
        
        protected static Cache cache = HttpContext.Current.Cache;



        protected static void clearCacheGroup(string keyPreffix)
        {
            List<string> keyList = new List<string>();
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                string key = cacheEnum.Key.ToString();
                if (key.Contains(keyPreffix))
                    keyList.Add(key);
            }
            foreach (string key in keyList)
            {
                cache.Remove(key);
            }
        }

        protected static void clearCacheItem(string keyPreffix, string key)
        {
            string cacheKey = keyPreffix + key;

            cache.Remove(cacheKey);
        }
    }



    public class BllProxySettings : BllProxyCache
    {

        protected static string cacheKeyPreffix = "SETTING_";


        public static SettingsDS.SettingsDSDataTable SelectSetting(string settingName, string settingCategory)
        {
            //bool byPass = true;
            string cacheKey = cacheKeyPreffix + settingName;

            ////---------------------------------------------------------------------
            object cacheItem = cache[cacheKey];
            if ((byPass == true) || (cacheItem == null))
            {
                cacheItem = BllSettings.SelectSetting(settingName, settingCategory);
                cache.Insert(cacheKey, cacheItem, null, DateTime.Now.ToUniversalTime().AddHours(cachePeriodHours), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Default, null);
            }
            ////---------------------------------------------------------------------

            SettingsDS.SettingsDSDataTable resultDt = ((SettingsDS.SettingsDSDataTable)cacheItem);
            return resultDt;
        }






        public static SettingsDS.SettingsDSDataTable GetAllSettings(string category)
        {
            clearCacheGroup(cacheKeyPreffix);
            return BllSettings.GetAllSettings(category);
        }


        public static void SetSetting(string settingName, string settingCategory, string settingValue)
        {
            BllSettings.SetSetting(settingName, settingCategory, settingValue);
            clearCacheItem(cacheKeyPreffix, settingName);
        }




    }

}
