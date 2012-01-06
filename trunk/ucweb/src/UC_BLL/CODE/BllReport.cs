using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;


namespace UCENTRIK.BLL
{
    public class BllReport
    {



        //private static ReportDS.CallDetailsDSDataTable processData(ReportDS.CallDetailsDSDataTable dt, Int32 group)
        //{
        //    foreach (ReportDS.CallDetailsDSRow row in dt.Rows)
        //    {
        //        row.agent_full_name = Helper.GetFullName(row.agent_first_name, row.agent_last_name);
        //        row.contact_full_name = Helper.GetFullName(row.contact_first_name, row.contact_last_name);

        //        if ((!row.Isdate_openNull()) && (!row.Isdate_closedNull()))
        //            row.duration = Helper.GetDuration(row.date_open, row.date_closed);
        //        else
        //            row.duration = "";


        //        if (!row.Isdate_openNull())
        //        {
        //            row.date = row.date_open.ToShortDateString();
        //            row.time = row.date_open.ToShortTimeString();
        //        }





        //        switch (group)
        //        {
        //            case 1: // Status
        //                row.group_field = row.incident_status_name;
        //                break;

        //            case 2: // Agent
        //                row.group_field = row.agent_full_name;
        //                break;

        //            case 3: // Contact
        //                row.group_field = row.contact_full_name;
        //                break;

        //            case 4: // Date
        //                row.group_field = row.date;
        //                break;
        //        }
        //    }

        //    return dt;
        //}



        private static ReportDS.ReportIncidentDSDataTable processData(ReportDS.ReportIncidentDSDataTable dt, TimeZone localZone, Int32 group)
        {
            foreach (ReportDS.ReportIncidentDSRow row in dt.Rows)
            {
                row.agent_full_name = Helper.GetFullName(row.agent_first_name, row.agent_last_name);
                row.contact_full_name = Helper.GetFullName(row.contact_first_name, row.contact_last_name);

                if ((!row.Isdate_openNull()) && (!row.Isdate_closedNull()))
                    row.duration = Helper.GetDuration(row.date_open, row.date_closed);
                else
                    row.duration = "";


                if (!row.Isdate_openNull())
                {
                    row.date = row.date_open.ToShortDateString();
                    //row.date = row.date_open.ToString("yyyy: MM/dd");


                    
                    //row.time = row.date_open.ToShortTimeString();
                    //row.time = row.date_open.ToLocalTime().ToShortTimeString();
                    row.time = localZone.ToLocalTime(row.date_open).ToShortTimeString();
                }




                switch (group)
                {
                    case 1: // Agent
                        row.group_field = row.agent_full_name;
                        row.group_field_title = row.agent_full_name;
                        break;

                    case 2: // Group
                        row.group_field = row.group_name;
                        row.group_field_title = row.group_name;
                        break;

                    case 3: // Facility
                        row.group_field = row.facility_name;
                        row.group_field_title = row.facility_name;
                        break;

                    case 4: // Contact
                        row.group_field = row.contact_full_name;
                        row.group_field_title = row.contact_full_name;
                        break;

                    case 5: // Status
                        row.group_field = row.incident_status_name;
                        row.group_field_title = row.incident_status_name;
                        break;

                    case 6: // Date
                        //row.group_field = row.date;
                        row.group_field = row.Isdate_openNull() ? "" : row.date_open.ToString("yyyy: MM/dd");
                        row.group_field_title = row.date;
                        break;
                }

            }

            return dt;
        }


        private static ReportDS.ReportSurveyDSDataTable processData(ReportDS.ReportSurveyDSDataTable dt, TimeZone localZone, Int32 group)
        {
            foreach (ReportDS.ReportSurveyDSRow row in dt.Rows)
            {
                row.agent_full_name = Helper.GetFullName(row.agent_first_name, row.agent_last_name);
                row.contact_full_name = Helper.GetFullName(row.contact_first_name, row.contact_last_name);


                if ((!row.Isdate_openNull()) && (!row.Isdate_closedNull()))
                    row.duration = Helper.GetDuration(row.date_open, row.date_closed);
                else
                    row.duration = "";



                if (!row.Isdate_openNull())
                {
                    row.date = row.date_open.ToShortDateString();
                    //row.time = row.date_open.ToShortTimeString();
                    row.time = row.date_open.ToLocalTime().ToShortTimeString();


                    //    row.date = row.date_survey_created.ToShortDateString();
                    //    row.time = row.date_survey_created.ToShortTimeString();
                }



                //switch (group)
                //{
                //    case 1: // Agent
                //        row.group_field = row.agent_full_name;
                //        break;

                //    case 2: // Group
                //        row.group_field = row.group_name;
                //        break;

                //    case 3: // Facility
                //        row.group_field = row.facility_name;
                //        break;

                //    case 4: // Contact
                //        row.group_field = row.contact_full_name;
                //        break;

                //    case 5: // Status
                //        row.group_field = row.incident_status_name;
                //        break;

                //    case 6: // Date
                //        row.group_field = row.date;
                //        break;
                //}


                switch (group)
                {
                    case 1: // Agent
                        row.group_field = row.agent_full_name;
                        row.group_field_title = row.agent_full_name;
                        break;

                    case 2: // Group
                        row.group_field = row.group_name;
                        row.group_field_title = row.group_name;
                        break;

                    case 3: // Facility
                        row.group_field = row.facility_name;
                        row.group_field_title = row.facility_name;
                        break;

                    case 4: // Contact
                        row.group_field = row.contact_full_name;
                        row.group_field_title = row.contact_full_name;
                        break;

                    case 5: // Status
                        row.group_field = row.incident_status_name;
                        row.group_field_title = row.incident_status_name;
                        break;

                    case 6: // Date
                        //row.group_field = row.date;
                        row.group_field = row.Isdate_openNull() ? "" : row.date_open.ToString("yyyy: MM/dd");
                        row.group_field_title = row.date;
                        break;
                }



            }

            return dt;
        }


        private static ReportDS.ReportSurveyAverageDataTable processData(ReportDS.ReportSurveyAverageDataTable dt, TimeZone localZone, Int32 group)
        {
            foreach (ReportDS.ReportSurveyAverageRow row in dt.Rows)
            {
                row.agent_full_name = Helper.GetFullName(row.agent_first_name, row.agent_last_name);
                row.contact_full_name = Helper.GetFullName(row.contact_first_name, row.contact_last_name);


                if ((!row.Isdate_openNull()) && (!row.Isdate_closedNull()))
                    row.duration = Helper.GetDuration(row.date_open, row.date_closed);
                else
                    row.duration = "";



                if (!row.Isdate_openNull())
                {
                    row.date = row.date_open.ToShortDateString();
                    //row.time = row.date_open.ToShortTimeString();
                    row.time = row.date_open.ToLocalTime().ToShortTimeString();
                }



                //switch (group)
                //{
                //    case 1: // Agent
                //        row.group_field = row.agent_full_name;
                //        break;

                //    case 2: // Group
                //        row.group_field = row.group_name;
                //        break;

                //    case 3: // Facility
                //        row.group_field = row.facility_name;
                //        break;

                //    case 4: // Contact
                //        row.group_field = row.contact_full_name;
                //        break;

                //    case 5: // Status
                //        row.group_field = row.incident_status_name;
                //        break;

                //    case 6: // Date
                //        row.group_field = row.date;
                //        break;
                //}


                switch (group)
                {
                    case 1: // Agent
                        row.group_field = row.agent_full_name;
                        row.group_field_title = row.agent_full_name;
                        break;

                    case 2: // Group
                        row.group_field = row.group_name;
                        row.group_field_title = row.group_name;
                        break;

                    case 3: // Facility
                        row.group_field = row.facility_name;
                        row.group_field_title = row.facility_name;
                        break;

                    case 4: // Contact
                        row.group_field = row.contact_full_name;
                        row.group_field_title = row.contact_full_name;
                        break;

                    case 5: // Status
                        row.group_field = row.incident_status_name;
                        row.group_field_title = row.incident_status_name;
                        break;

                    case 6: // Date
                        //row.group_field = row.date;
                        row.group_field = row.Isdate_openNull() ? "" : row.date_open.ToString("yyyy: MM/dd");
                        row.group_field_title = row.date;
                        break;
                }



            }

            return dt;
        }


        //=====================================================================================================================







        public static ReportDS.ReportIncidentDSDataTable GetIncidentReport(TimeZone localZone, Int32 group, DateTime start, DateTime end)
        {
            ReportDS.ReportIncidentDSDataTable dt = DalReport.GetIncidentReport(start, end);
            return processData(dt, localZone, group);
        }

        public static ReportDS.ReportSurveyDSDataTable GetSurveyReport(TimeZone localZone, Int32 group, DateTime start, DateTime end)
        {
            ReportDS.ReportSurveyDSDataTable dt = DalReport.GetSurveyReport(start, end);
            return processData(dt, localZone, group);
        }

        public static ReportDS.ReportSurveyAverageDataTable GetSurveyAverageReport(TimeZone localZone, Int32 group, DateTime start, DateTime end)
        {
            ReportDS.ReportSurveyAverageDataTable dt = DalReport.GetSurveyAverageReport(start, end);
            return processData(dt, localZone, group);
        }








        //public static ReportDS.CallDetailsDSDataTable GetReportCallDetails(Int32 group, DateTime start, DateTime end)
        //{
        //    ReportDS.CallDetailsDSDataTable dt = DalReport.GetReportCallDetails(start, end);
        //    return processData(dt, group);
        //}





    }
}
