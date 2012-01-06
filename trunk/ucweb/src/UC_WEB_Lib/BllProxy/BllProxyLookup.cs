using System;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;
using System.Data;
using System.Collections.Generic;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyLookup
    {


        //public static LookupDS.TimeZonesDSDataTable GetTimeZones()
        //{
        //    return BllLookup.GetTimeZones();
        //}

        public static LookupDS.UserRoleDSDataTable GetUserRoles(int loginUser)
        {
            LookupDS.UserRoleDSDataTable dt = BllLookup.GetUserRoles();
            ProxyHelper.FilterForLoginUser(loginUser, dt.Rows);
            return dt;
        }

        public static LookupDS.IncidentStatusDSDataTable GetIncidentStatuses()
        {
            return BllLookup.GetIncidentStatuses();
        }


        public static LookupDS.QuestionTypesDSDataTable GetQuestionTypes()
        {
            return BllLookup.GetQuestionTypes();
        }


    }


}
