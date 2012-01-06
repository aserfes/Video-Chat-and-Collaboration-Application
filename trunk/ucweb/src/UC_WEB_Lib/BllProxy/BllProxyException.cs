using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyException
    {

        public static ExceptionDS.ExceptionDSDataTable GetAllExceptions()
        {
            return BllException.GetAllExceptions();
        }

        public static ExceptionDS.ExceptionDSDataTable SelectException(Int32 exceptionId)
        {
            return BllException.SelectException(exceptionId);
        }

        public static Int32 InsertException(Int32 parent_ex_id, string message, string stacktrace, string application, string username, string page_url)
        {
            return BllException.InsertException(parent_ex_id, message, stacktrace, application, username, page_url);
        }

        public static Int32 DeleteException(Int32 exceptionId)
        {
            return BllException.DeleteException(exceptionId);
        }




    }


}
