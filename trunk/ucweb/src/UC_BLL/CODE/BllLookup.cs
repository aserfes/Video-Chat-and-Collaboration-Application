using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllLookup
    {

        //public static LookupDS.TimeZonesDSDataTable GetTimeZones()
        //{
        //    return DalLookup.GetTimeZones();
        //}

        public static LookupDS.UserRoleDSDataTable GetUserRoles()
        {
            return DalLookup.GetUserRoles();
        }

        public static LookupDS.IncidentStatusDSDataTable GetIncidentStatuses()
        {
            return DalLookup.GetIncidentStatuses();
        }

        public static LookupDS.QuestionTypesDSDataTable GetQuestionTypes()
        {
            return DalLookup.GetQuestionTypes();
        }


    }
}
