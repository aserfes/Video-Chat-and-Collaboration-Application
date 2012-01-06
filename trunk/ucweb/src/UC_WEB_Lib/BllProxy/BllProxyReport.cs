using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyReport
    {






        public static ReportDS.ReportIncidentDSDataTable GetIncidentReport(TimeZone localZone, Int32 group, DateTime start, DateTime end)
        {
            return BllReport.GetIncidentReport(localZone, group, start, end);
        }

        public static ReportDS.ReportSurveyDSDataTable GetSurveyReport(TimeZone localZone, Int32 group, DateTime start, DateTime end)
        {
            return BllReport.GetSurveyReport(localZone, group, start, end);
        }

        public static ReportDS.ReportSurveyAverageDataTable GetSurveyAverageReport(TimeZone localZone, Int32 group, DateTime start, DateTime end)
        {
            return BllReport.GetSurveyAverageReport(localZone, group, start, end);
        }
        









        //public static ReportDS.CallDetailsDSDataTable GetReportCallDetails(Int32 group, DateTime start, DateTime end)
        //{
        //    return BllReport.GetReportCallDetails(group, start, end);
        //}

        //===============================


    }


}
