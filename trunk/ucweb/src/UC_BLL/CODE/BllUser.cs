using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllUser
    {


        private static UserDS.UserDSDataTable processData(UserDS.UserDSDataTable dt)
        {
            foreach (UserDS.UserDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
                row.password = Helper.DecryptPasswords(row.password);
            }

            return dt;
        }







        public static UserDS.UserDSDataTable GetUser(string userName)
        {
            UserDS.UserDSDataTable dt = DalUser.GetUser(userName);
            return processData(dt);
        }

        public static UserDS.UserDSDataTable GetUsersByRole(Int32 userRoleId)
        {
            UserDS.UserDSDataTable dt = DalUser.GetUsersByRole(userRoleId);
            return processData(dt);
        }



        public static UserDS.UserDSDataTable SelectUser(Int32 userId)
        {
            UserDS.UserDSDataTable dt = DalUser.SelectUser(userId);
            return processData(dt);
        }
        public static UserDS.UserDSDataTable GetUserByGuid(Guid userGuid)
        {
            UserDS.UserDSDataTable dt = DalUser.GetUserByGuid(userGuid);
            return processData(dt);
        }







        public static Int32 InsertUser(string userName, string firstName, string lastName, string password, Int32 userRoleId, string timeZone)
        {
            string encPassword = Helper.EncryptPasswords(password);

            return DalUser.InsertUser(userName, firstName, lastName, encPassword, userRoleId, timeZone);
        }


        public static Int32 UpdateUser(string userName, string firstName, string lastName, string password, Int32 userRoleId, Int32 userId, string timeZone)
        {
            string encPassword = Helper.EncryptPasswords(password);

            return DalUser.UpdateUser(userName, firstName, lastName, encPassword, userRoleId, userId, timeZone);
        }


        public static Int32 DeleteUser(Int32 userId)
        {
            return DalUser.DeleteUser(userId);
        }




        public static void Login(string userName, bool success)
        {
            DalUser.Login(userName, success);
        }


    }


    public class BllUserHelper
    {
        public static void UpdateUserDetails(Int32 userId, string firstName, string lastName, string email)
        {
            DalUserHelper.UpdateUserDetails(userId, firstName, lastName, email);
        }
    }
}
