using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.ReportDSTableAdapters;


namespace UCENTRIK.DAL
{
    public class DalReport
    {

        public static ReportDS.ReportIncidentDSDataTable GetIncidentReport(DateTime start, DateTime end)
        {
            ReportIncidentDSTableAdapter ta = new ReportIncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(start, end);
        }

        public static ReportDS.ReportSurveyDSDataTable GetSurveyReport(DateTime start, DateTime end)
        {
            ReportSurveyDSTableAdapter ta = new ReportSurveyDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(start, end);
        }


        public static ReportDS.ReportSurveyAverageDataTable GetSurveyAverageReport(DateTime start, DateTime end)
        {
            ReportSurveyAverageTableAdapter ta = new ReportSurveyAverageTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(start, end);
        }










    }
}
