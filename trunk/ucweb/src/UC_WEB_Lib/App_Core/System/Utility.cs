using System;
using System.Collections.Generic;
using System.Web;




namespace UCENTRIK.LIB.CoreSystem
{


    public class Utility
    {
        public const string ConferenceStartupParametersSessionVariableName = "ConferenceStartupParametersSessionVariableName";
    }




    public class AppHelper
    {

        public static string GetApplicationPath(string Url)
        {
            string url = Url;

            if (Url.StartsWith("~"))
                url = (HttpContext.Current.Request.ApplicationPath + Url.Substring(1)).Replace("//", "/");

            return url;
        }

        public static string GetFullyQualifiedApplicationPath(string Url)
        {

            //string url = Url;

            //if (Url.StartsWith("~"))
            //    url = (HttpContext.Current.Request.ApplicationPath + Url.Substring(1)).Replace("//", "/");

            string url = GetApplicationPath(Url); ;




            //Return variable declaration
            string appPath = null;

            //Getting the current context of HTTP request
            HttpContext context = HttpContext.Current;

            //Checking the current context content
            if (context != null)
            {
                //Formatting the fully qualified website url/name
                appPath = string.Format("{0}://{1}{2}{3}",
                  context.Request.Url.Scheme,
                  context.Request.Url.Host,
                  context.Request.Url.Port == 80
                    ? string.Empty : ":" + context.Request.Url.Port,
                  context.Request.ApplicationPath);
            }
            if (!appPath.EndsWith("/"))
                appPath += "/";




            appPath = appPath + url;
            appPath = appPath.Replace("//", "/");

            return appPath;
        }



        //public static string getThemeImage(string imageName)
        //{
        //    string appRoot = GetFullyQualifiedApplicationPath("");


        //    //HttpContext context = HttpContext.Current;
        //    //if (context != null)
        //    //{
        //    //      context.Request.page
        //    //}


        //    //ConfigurationManager.




        //    appRoot = appRoot + "/App_Themes" + "/images" + imageName;



        //    return "~/Images/desc.png";
        //}




    }
}
