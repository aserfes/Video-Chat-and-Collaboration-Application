using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{
    public class BllException
    {

        public static ExceptionDS.ExceptionDSDataTable GetAllExceptions()
        {
            return DalException.GetAllExceptions();
        }

        public static ExceptionDS.ExceptionDSDataTable SelectException(Int32 exceptionId)
        {
            return DalException.SelectException(exceptionId);
        }

        public static Int32 InsertException(Int32 parentExId, string message, string stackTrace, string application, string username, string pageUrl)
        {
            return DalException.InsertException(parentExId, message, stackTrace, application, username, pageUrl);
        }

        public static Int32 DeleteException(Int32 exceptionId)
        {
            return DalException.DeleteException(exceptionId);
        }
    }
}

