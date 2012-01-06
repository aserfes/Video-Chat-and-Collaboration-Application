using System;
using System.Collections.Generic;
using System.Web;

namespace UCENTRIK.Templates
{
    public class Templates
    {
        public static string GetHtmlHeader()
        {
            return TemplateFunctions.GetHtmlTemplate(@"Templates\HTML\Header.htm"); ;
        }
        public static string GetHtmlFooter()
        {
            return TemplateFunctions.GetHtmlTemplate(@"Templates\HTML\Footer.htm"); ;
        }

        public static string GetHtmlSideBar()
        {
            return TemplateFunctions.GetHtmlTemplate(@"Templates\HTML\SideBar.htm"); ;
        }
        public static string GetHtmlHomeScreen()
        {
            return TemplateFunctions.GetHtmlTemplate(@"Templates\HTML\HomeScreen.htm"); ;
        }

        //---
    }
}
