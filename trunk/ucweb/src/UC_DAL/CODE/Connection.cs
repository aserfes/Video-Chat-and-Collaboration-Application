using System;
using System.Configuration;

namespace UCENTRIK.DAL
{
    internal class UcConnection
    {

        internal static string ConnectionString
        {
            get
            {
                string cs = "";
                object obj = ConfigurationManager.ConnectionStrings["UCENTRIK.Properties.Settings.UcConnectionString"];
                if (obj != null)
                    cs = obj.ToString();

                return cs;
            }
        }
    }


}
