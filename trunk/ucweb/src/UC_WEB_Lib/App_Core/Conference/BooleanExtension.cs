using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UCENTRIK.LIB.dirCode
{
    public static class BooleanExtension
    {
        public static String ToFlashString(this bool boolValue)
        {
            return (boolValue) ? "true" : "false";
        }
    }
}
