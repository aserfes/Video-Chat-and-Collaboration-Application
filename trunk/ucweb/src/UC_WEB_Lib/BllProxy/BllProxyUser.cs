using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
//using SosDAL.CODE;
using UCENTRIK.DATASETS;
using System.Data;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyUser
    {
        public static UserDS.UserDSDataTable GetUsersByRole(Int32 user_role_id, Int32 login_user_role_id)
        {
            UserDS.UserDSDataTable ds = BllUser.GetUsersByRole(user_role_id);
            ProxyHelper.FilterForLoginUser(login_user_role_id, ds.Rows);
            return ds;
        }


        public static UserDS.UserDSDataTable GetUser(string userName)
        {
            UserDS.UserDSDataTable ds = BllUser.GetUser(userName);
            return ds;
        }



        public static UserDS.UserDSDataTable SelectUser(Int32 user_id)
        {
            UserDS.UserDSDataTable ds = BllUser.SelectUser(user_id);
            return ds;
        }

        public static UserDS.UserDSDataTable GetUserByGuid(Guid user_guid)
        {
            UserDS.UserDSDataTable ds = BllUser.GetUserByGuid(user_guid);
            return ds;
        }




        public static Int32 InsertUser(string username, string first_name, string last_name, string password, Int32 user_role_id, string time_zone)
        {
            return BllUser.InsertUser(username, first_name, last_name, password, user_role_id, time_zone);
        }


        public static Int32 UpdateUser(string username, string first_name, string last_name, string password, Int32 user_role_id, Int32 user_id, string time_zone)
        {
            return BllUser.UpdateUser(username, first_name, last_name, password, user_role_id, user_id, time_zone);
        }

        public static Int32 DeleteUser(Int32 user_id)
        {
            return BllUser.DeleteUser(user_id);
        }



        public static void Login(string username, bool success)
        {
            BllUser.Login(username, success);
        }

    }


    public class BllProxyUserHelper
    {
        public static void UpdateUserDetails(Int32 user_id, string first_name, string last_name, string email)
        {
            BllUserHelper.UpdateUserDetails(user_id, first_name, last_name, email);
        }
    }
}
