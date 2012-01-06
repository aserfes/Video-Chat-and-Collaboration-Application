using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.LookupDSTableAdapters;



namespace UCENTRIK.DAL
{
    public class DalLookup
    {

        //public static LookupDS.TimeZonesDSDataTable GetTimeZones()
        //{
        //    TimeZonesDSTableAdapter ta = new TimeZonesDSTableAdapter();
        //    ta.Connection.ConnectionString = UcConnection.ConnectionString;
        //    return ta.GetData();
        //}


        public static LookupDS.UserRoleDSDataTable GetUserRoles()
        {
            UserRoleDSTableAdapter ta = new UserRoleDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData();
        }


        public static LookupDS.IncidentStatusDSDataTable GetIncidentStatuses()
        {
            IncidentStatusDSTableAdapter ta = new IncidentStatusDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData();
        }


        public static LookupDS.QuestionTypesDSDataTable GetQuestionTypes()
        {
            QuestionTypesDSTableAdapter ta = new QuestionTypesDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData();
        }


    }
}
