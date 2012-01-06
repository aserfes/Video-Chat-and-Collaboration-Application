using System;
using System.Web;




namespace UCENTRIK.LIB.Helpers
{
    public class UcDateTime
    {


        public static DateTime GetUserLocalDateTime(DateTime utcDateTime, string timeZone)
        {
            DateTime userLocalDateTime = utcDateTime;

            if (timeZone != "")
            {
                try
                {
                    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                    userLocalDateTime = TimeZoneInfo.ConvertTimeFromUtc(utcDateTime, tzi);
                }
                catch
                {
                }
            }

            return userLocalDateTime;
        }


    }


}
