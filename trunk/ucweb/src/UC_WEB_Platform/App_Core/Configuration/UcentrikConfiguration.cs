using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace UCENTRIK.Configuration
{
    public class UcentrikConfiguration
    {
        #region Public properties

        public static bool MailSenderUseSsl
        {
            get
            {
                return GetBoolValueFromConfigurationFile("MailSender.UseSSL", false);
            }
        }

        public static string RestorePasswordSubject
        {
            get
            {
                return GetStringValueFromConfigurationFile("EmailTemplates.RestorePassword.Subject", "Restore password");
            }
        }

        #endregion

        #region Boolean

        protected static bool GetBoolValueFromConfigurationFile(String key)
        {
            return GetBoolValueFromConfigurationFile(key, false);
        }

        protected static bool GetBoolValueFromConfigurationFile(String key, bool defaultValue)
        {
            bool value;

            String stringValue = GetStringValueFromConfigurationFile(key);

            if (bool.TryParse(stringValue, out value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion

        #region Int

        protected static int GetIntValueFromConfigurationFile(String key)
        {
            return GetIntValueFromConfigurationFile(key, 0);
        }

        protected static int GetIntValueFromConfigurationFile(String key, int defaultValue)
        {
            int value = 0;

            String stringValue = GetStringValueFromConfigurationFile(key);

            if (int.TryParse(stringValue, out value))
            {
                return value;
            }
            else
            {
                return defaultValue;
            }
        }

        #endregion

        #region String

        protected static String GetStringValueFromConfigurationFile(String key)
        {
            return GetStringValueFromConfigurationFile(key, null);
        }

        protected static String GetStringValueFromConfigurationFile(String key, String defautValue)
        {
            String stringValue = ConfigurationManager.AppSettings[key];
            
            if (String.IsNullOrEmpty(stringValue))
            {
                return defautValue;
            }
            else
            {
                return stringValue;
            }
        }

        #endregion
    }
}