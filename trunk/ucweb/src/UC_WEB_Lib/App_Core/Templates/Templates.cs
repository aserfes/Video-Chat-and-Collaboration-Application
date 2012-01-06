using System;
using System.Collections.Generic;
using System.Web;

namespace UCENTRIK.Templates
{
    public class TemplateFunctions
    {

        internal static HttpContext context = HttpContext.Current;


        public static string GetHtmlTemplate(string templateFileName)
        {
            string template = context.Server.MapPath("~") + @"\" + templateFileName;
            string sData = "";


            try
            {
                using (System.IO.StreamReader sr = System.IO.File.OpenText(template))
                {
                    sData = sr.ReadToEnd();
                }
            }
            catch
            {
            }

            return sData;
        }


        //---
    }
}
