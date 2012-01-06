using System;
using System.Data;
using System.Data.SqlClient;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.UserDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalUser
    {
        public static UserDS.UserDSDataTable GetUser(string userName)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetUserByUsername(userName);
        }

        public static UserDS.UserDSDataTable GetUsersByRole(Int32 userRoleId)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetUsersByRole(userRoleId);
        }



        public static UserDS.UserDSDataTable SelectUser(Int32 userId)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(userId);
        }

        public static UserDS.UserDSDataTable GetUserByGuid(Guid userGuid)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetUserByGuid(userGuid);
        }




        public static Int32 InsertUser(string userName, string firstName, string lastName, string password, Int32 userRoleId, string timeZone)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            int id = Convert.ToInt32(ta.InsertUser(firstName, lastName, userName, password, "", userRoleId, timeZone));
            return id;
        }


        public static Int32 UpdateUser(string userName, string firstName, string lastName, string password, Int32 userRoleId, Int32 userId, string timeZone)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Update(userId, firstName, lastName, userName, password, "", userRoleId, timeZone);
        }


        public static Int32 DeleteUser(Int32 userId)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(userId);
        }





        public static void Login(string userName, bool success)
        {
            UserDSTableAdapter ta = new UserDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.Login(userName, success);
        }

    }

    public class DalUserHelper
    {
        private static string connectionString = UcConnection.ConnectionString;

        public static void UpdateUserDetails(Int32 userId, string firstName, string lastName, string email)
        {

            string commandString = "usp_user_info_set";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@user_id", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@first_name", SqlDbType.NVarChar, 50).Value = firstName;
                    command.Parameters.Add("@last_name", SqlDbType.NVarChar, 50).Value = lastName;
                    //command.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }

        }
    }
}
