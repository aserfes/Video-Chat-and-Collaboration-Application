using System;
using System.Web.UI;

using UCENTRIK.LIB.Helpers;
using UCENTRIK.AppSettings;



namespace UCENTRIK.LIB.Base
{

    public class UcBaseControl : System.Web.UI.UserControl
    {
        public UcBasePage UcPage
        {
            get
            {
                return (UcBasePage)this.Page;
            }
        }





        //--//----------- TEMPORARY
        protected String format = UcFormats.UcFormatProfileDateTime; //"{0:dd-MMM-yyyy [HH:mm]}";
        protected string formatDateTime(object obj)
        {
            string result = "";

            if ((obj != null) && (obj is DateTime))
            {
                DateTime utcTime = Convert.ToDateTime(obj);
                //DateTime localTime = utcTime;
                //if (this.UcPage.TimeZone != "")
                //{
                //    TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(this.UcPage.TimeZone);
                //    localTime = TimeZoneInfo.ConvertTimeFromUtc(utcTime, tzi);
                //}

                DateTime localTime = UcDateTime.GetUserLocalDateTime(utcTime, this.UcPage.TimeZone);

                result = localTime.ToString(this.format);
            }

            return result;
        }




        protected string formatHtmlText(object obj)
        {
            string result = "...";

            if (obj != null)
            {
                result = obj.ToString();

                result = result.Replace("\n", "<BR>");
            }

            return result;
        }
        //--//----------- TEMPORARY


    }












    //public class UcBaseListControl : UcBaseControl
    //{
    //    protected String format = UcFormats.UcFormatProfileDateTime; //"{0:dd-MMM-yyyy [HH:mm]}";
    //    protected string formatListDateTime(object obj)
    //    {
    //        string result = "...";

    //        if ((obj != null) && (obj is DateTime))
    //        {
    //            DateTime utcTime = Convert.ToDateTime(obj);
    //            DateTime localTime = utcTime;
    //            if (this.UcPage.TimeZone != "")
    //            {
    //                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(this.UcPage.TimeZone);
    //                localTime = utcTime.Add(tzi.BaseUtcOffset);
    //            }

    //            result = localTime.ToString(this.format);
    //        }

    //        return result;
    //    }

    //}


    //public class UcBaseProfileControl : UcBaseControl
    //{
    //    protected String format = UcFormats.UcFormatProfileDateTime; //"{0:dd-MMM-yyyy [HH:mm]}";
    //    protected string formatProfileDateTime(object obj)
    //    {
    //        string result = "...";

    //        if ((obj != null) && (obj is DateTime))
    //        {
    //            DateTime utcTime = Convert.ToDateTime(obj);
    //            DateTime localTime = utcTime;
    //            if (this.UcPage.TimeZone != "")
    //            {
    //                TimeZoneInfo tzi = TimeZoneInfo.FindSystemTimeZoneById(this.UcPage.TimeZone);
    //                localTime = utcTime.Add(tzi.BaseUtcOffset);
    //            }

    //            result = localTime.ToString(this.format);
    //        }

    //        return result;
    //    }

    //}






}
