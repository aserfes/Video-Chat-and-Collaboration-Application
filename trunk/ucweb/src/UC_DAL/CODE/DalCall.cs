using System;
using System.Data;
using System.Data.SqlClient;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.CallDSTableAdapters;


namespace UCENTRIK.DAL
{

    
    
    public class DalCall
    {

        
        public static CallDS.CallDSDataTable SelectCall(Int32 callId)
        {
            CallDSTableAdapter ta = new CallDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(callId);
        }

        public static CallDS.CallDSDataTable GetCallsByContact(Int32 contactId)
        {
            CallDSTableAdapter ta = new CallDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetCallsByContact(contactId);
        }
        public static CallDS.CallDSDataTable GetCallsByStatus(Int32 statusId)
        {
            CallDSTableAdapter ta = new CallDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetCallsByStatus(statusId);
        }


        public static CallDS.CallDSDataTable GetCallsAll(Int32 fromContactId, Int32 toContactId, Int32 statusId)
        {
            CallDSTableAdapter ta = new CallDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetCallsAll(fromContactId, toContactId, statusId);
        }













        public static Int32 InsertCall(Guid guid, Int32 fromContactId, Int32 toContactId)
        {
            CallDSTableAdapter ta = new CallDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            int id = Convert.ToInt32(ta.InsertCall(guid, fromContactId, toContactId));
            return id;
        }

        //========================




    }



    public class DalCallHelper
    {
        private static string connectionString = UcConnection.ConnectionString;



        public static void SetCallOpen(Int32 callId)
        {
            string commandString = "usp_call_open";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@call_id", SqlDbType.Int).Value = callId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static void SetCallClose(Int32 callId)
        {
            string commandString = "usp_call_close";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@call_id", SqlDbType.Int).Value = callId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public static void SetCallCancel(Int32 callId)
        {
            string commandString = "usp_call_cancel";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@call_id", SqlDbType.Int).Value = callId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }




    }





}
