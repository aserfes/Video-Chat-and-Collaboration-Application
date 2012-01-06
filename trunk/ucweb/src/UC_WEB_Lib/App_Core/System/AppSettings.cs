using System;
using System.Configuration;


namespace UCENTRIK.AppSettings
{


    public class UcConstant
    {
        public const Int32 UCCACHEEXPIRATION = 5;
    }






    public class UcConfParameters
    {

        public static string UcAvControlServerUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["UcAvControlServerUrl"];
            }
        }


        //public static Guid SosFaclityGuid
        //{
        //    get
        //    {

        //        string sosFaclityGuid = ConfigurationManager.AppSettings["SosFaclityGuid"];
        //        Guid guid = new Guid();
        //        try
        //        {
        //            guid = new Guid(sosFaclityGuid);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("'SosFaclityGuid' failed", ex);
        //        }

        //        return guid;

        //    }
        //}



        public static Int32 UcGridViewPageRows
        {
            get
            {

                string ucGridViewPageRows = ConfigurationManager.AppSettings["UcGridViewPageRows"];
                Int32 rows = 0;
                try
                {
                    rows = Convert.ToInt32(ucGridViewPageRows);
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcGridViewPageRows' failed", ex);
                }


                if (rows == 0)
                    rows = 10;

                return rows;
            }
        }




        public static Int32 UcPageRefreshInterval
        {
            get
            {

                string ucPageRefreshInterval = ConfigurationManager.AppSettings["UcPageRefreshInterval"];
                Int32 interval = 0;
                try
                {
                    interval = Convert.ToInt32(ucPageRefreshInterval);
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcPageRefreshInterval' failed", ex);
                }


                if (interval == 0)
                    interval = 10;  // default

                return interval;
            }
        }


        public static Int32 UcWaitingInterval
        {
            get
            {

                string ucWaitingInterval = ConfigurationManager.AppSettings["UcWaitingInterval"];
                Int32 interval = 30;    // default: 30 seconds
                try
                {
                    interval = Convert.ToInt32(ucWaitingInterval);
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcWaitingInterval' failed", ex);
                }

                return interval;
            }
        }







        public static Int32 UcCallCleanUpInterval
        {
            get
            {

                string ucCallCleanUpInterval = ConfigurationManager.AppSettings["UcCallCleanUpInterval"];
                Int32 interval = 0;
                try
                {
                    interval = Convert.ToInt32(ucCallCleanUpInterval);
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcCallCleanUpInterval' failed", ex);
                }


                if (interval == 0)
                    interval = 60;  // default

                return interval;
            }
        }





        public static Int32 UcCallForwardingInterval
        {
            get
            {

                string ucCallForwardingInterval = ConfigurationManager.AppSettings["UcCallForwardingInterval"];
                Int32 interval = 0;
                try
                {
                    interval = Convert.ToInt32(ucCallForwardingInterval);
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcCallForwardingInterval' failed", ex);
                }


                if (interval == 0)
                    interval = 60;  // default

                return interval;
            }
        }








        //UcPublicCallEnabled
        public static bool UcPublicCallEnabled
        {
            get
            {
                string ucUcPublicCallEnabled = ConfigurationManager.AppSettings["UcPublicCallEnabled"];
                bool enabled = false;
                try
                {
                    enabled = Convert.ToBoolean(ucUcPublicCallEnabled);
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcPublicCallEnabled' failed", ex);
                }

                return enabled;
            }
        }











        public static string UcDefaultTimeZone
        {
            get
            {
                string ucDefaultTimeZone = ConfigurationManager.AppSettings["UcDefaultTimeZone"];
                if (ucDefaultTimeZone == null)
                    ucDefaultTimeZone = "";
                return ucDefaultTimeZone;
            }
        }


        public static string UcAppName
        {
            get
            {
                string ucAppName = ConfigurationManager.AppSettings["UcAppName"];
                if (ucAppName == null)
                    ucAppName = "";
                return ucAppName;
            }
        }

        public static string UcStreamServerType
        {
            get
            {
                string ucStreamServerType = ConfigurationManager.AppSettings["UcStreamServerType"];
                if (ucStreamServerType == null)
                    ucStreamServerType = "";
                return ucStreamServerType;
            }
        }






    }





















    public class UcFormats
    {
        public static string UcFormatProfileDateTime
        {
            get
            {
                string format = "dd-MMMM-yyyy [hh:mm tt]";
                try
                {
                    format = ConfigurationManager.AppSettings["UcFormatProfileDateTime"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcFormatProfileDateTime' failed", ex);
                }

                return format;
            }
        }
        public static string UcFormatProfileDate
        {
            get
            {
                string format = "dd-MMMM-yyyy";
                try
                {
                    format = ConfigurationManager.AppSettings["UcFormatProfileDate"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcFormatProfileDate' failed", ex);
                }

                return format;
            }
        }
        public static string UcFormatProfileTime
        {
            get
            {
                string format = "hh:mm tt";
                try
                {
                    format = ConfigurationManager.AppSettings["UcFormatProfileTime"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcFormatProfileTime' failed", ex);
                }

                return format;
            }
        }

        public static string UcFormatListDateTime
        {
            get
            {
                string format = "dd-MMMM-yyyy [hh:mm tt]";
                try
                {
                    format = ConfigurationManager.AppSettings["UcFormatListDateTime"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcFormatListDateTime' failed", ex);
                }

                return format;
            }
        }
        public static string UcFormatListDate
        {
            get
            {
                string format = "dd-MMMM-yyyy";
                try
                {
                    format = ConfigurationManager.AppSettings["UcFormatListDate"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcFormatListDate' failed", ex);
                }

                return format;
            }
        }
        public static string UcFormatListTime
        {
            get
            {
                string format = "hh:mm tt";
                try
                {
                    format = ConfigurationManager.AppSettings["UcFormatListTime"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcFormatListTime' failed", ex);
                }

                return format;
            }
        }
    }











    public class UcDefaults
    {
        public static string UcDefaultTimeZone
        {
            get
            {
                string defaultTimeZone = "";
                try
                {
                    defaultTimeZone = ConfigurationManager.AppSettings["UcDefaultTimeZone"];
                }
                catch (Exception ex)
                {
                    throw new Exception("'UcDefaultTimeZone' failed", ex);
                }

                return defaultTimeZone;
            }
        }
    }









}


