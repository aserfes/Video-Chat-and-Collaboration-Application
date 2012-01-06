using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.ExceptionDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalException
    {

        public static ExceptionDS.ExceptionDSDataTable GetAllExceptions()
        {
            ExceptionDSTableAdapter ta = new ExceptionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllExceptions();
        }

        public static ExceptionDS.ExceptionDSDataTable SelectException(Int32 exceptionId)
        {
            ExceptionDSTableAdapter ta = new ExceptionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(exceptionId);
        }

        public static Int32 InsertException(Int32 parentExId, string message, string stackTrace, string application, string username, string pageUrl)
        {
            ExceptionDSTableAdapter ta = new ExceptionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> parent_ex_id = Helper.ResolveEmptyInt(parentExId);


            int id = Convert.ToInt32(ta.InsertException(parent_ex_id, message, stackTrace, application, username, pageUrl));
            return id;
        }

        public static Int32 DeleteException(Int32 exceptionId)
        {
            ExceptionDSTableAdapter ta = new ExceptionDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(exceptionId);
        }



    }
}
