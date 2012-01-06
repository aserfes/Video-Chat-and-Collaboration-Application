using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;




namespace UCENTRIK.BLL
{
    public class BllIncident
    {


        private static IncidentDS.IncidentDSDataTable processData(IncidentDS.IncidentDSDataTable dt)
        {
            foreach (IncidentDS.IncidentDSRow row in dt.Rows)
            {
                row.agent_full_name = Helper.GetFullName(row.agent_first_name, row.agent_last_name);
                row.contact_full_name = Helper.GetFullName(row.contact_first_name, row.contact_last_name);
            }

            return dt;
        }










        public static IncidentDS.IncidentDSDataTable GetIncidentsByStatus(Int32 statusId, Int32 agentId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.GetIncidentsByStatus(statusId, agentId);
            return processData(dt);
        }


        public static IncidentDS.IncidentDSDataTable GetIncidentsByContact(Int32 statusId, Int32 contactId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.GetIncidentsByContact(statusId, contactId);
            return processData(dt);
        }



        public static IncidentDS.IncidentDSDataTable GetIncidentQueueList(Int32 statusId, Int32 agentId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.GetIncidentQueueList(statusId, agentId);
            return processData(dt);
        }


        public static IncidentDS.IncidentDSDataTable GetIncidentFollowUpList(Int32 statusId, Int32 agentId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.GetIncidentFollowUpList(statusId, agentId);
            return processData(dt);
        }




        
        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentDSDataTable OpenIncident(Int32 incidentId, Int32 agentId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.OpenIncident(incidentId, agentId);
            return processData(dt);
        }
        public static IncidentDS.IncidentDSDataTable OpenFollowUpIncident(Int32 incidentId, Int32 agentId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.OpenFollowUpIncident(incidentId, agentId);
            return processData(dt);
        }









        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentDSDataTable SelectIncident(Int32 incidentId)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.SelectIncident(incidentId);
            return processData(dt);
        }

        public static IncidentDS.IncidentDSDataTable GetIncidentByGuid(Guid incidentGuid)
        {
            IncidentDS.IncidentDSDataTable dt = DalIncident.GetIncidentByGuid(incidentGuid);
            return processData(dt);
        }










        //-----------------------------------------------------------------------------

        public static Int32 InsertIncident(Int32 groupId, Int32 skillId, Int32 langId, Int32 facilityId, Int32 contactId, Int32 agentId)
        {
            return DalIncident.InsertIncident(groupId, skillId, langId, facilityId, contactId, agentId);
        }


        public static Int32 UpdateIncident(Int32 incidentId, Int32 contactId, Int32 agentId, Int32 statusId, string subject)
        {
            //if ((statusId == 3) || (statusId == 4))  //3:Canceled; 4:Closed;
            //    DalIncidentState.DeleteIncidentState(incidentId);

            return DalIncident.UpdateIncident(incidentId, contactId, agentId, statusId, subject);
        }


        public static Int32 DeleteIncident(Int32 incidentId)
        {
            return DalIncident.DeleteIncident(incidentId);
        }





    }


    public class BllIncidentState
    {


        private static IncidentDS.IncidentStateDSDataTable processData(IncidentDS.IncidentStateDSDataTable dt)
        {
            return dt;
        }

        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentStateDSDataTable SelectIncidentState(Int32 incidentId)
        {
            IncidentDS.IncidentStateDSDataTable dt = DalIncidentState.SelectIncidentState(incidentId);
            return processData(dt);
        }

        public static void InsertIncidentState(Int32 incidentId, bool isActive, string state)
        {
            DalIncidentState.InsertIncidentState(incidentId, isActive, state);
        }

        public static Int32 UpdateIncidentState(Int32 incidentId, bool isActive, string state)
        {
            return DalIncidentState.UpdateIncidentState(incidentId, isActive, state);
        }

        public static Int32 DeleteIncidentState(Int32 incidentId)
        {
            return DalIncidentState.DeleteIncidentState(incidentId);
        }









        public static bool SetIncidentState0(Int32 incidentId, Int32 periodToUpdate0)
        {
            bool result = false;

            IncidentDS.IncidentStateDSDataTable dt = DalIncidentState.SetIncidentState0(incidentId, periodToUpdate0);
            if (dt.Rows.Count != 0)
            {
                if ((!dt[0].Isdate_accessed_1Null()) && (!dt[0].Isperiod_to_update_1Null()))
                {
                    result = true;

                    
                    DateTime date_accessed_0 = dt[0].date_accessed_0;
                    DateTime date_accessed_1 = dt[0].date_accessed_1;
                    Int32 periodToUpdate1 = dt[0].period_to_update_1;

                    Int32 maxPeriodToUpdate = periodToUpdate0 + periodToUpdate1;  // seconds
                    maxPeriodToUpdate = 1 + maxPeriodToUpdate;                    // seconds
                    //maxPeriodToUpdate = 2 * maxPeriodToUpdate;


                    TimeSpan span = date_accessed_0.Subtract(date_accessed_1);
                    TimeSpan max = new TimeSpan(0, 0, 0, maxPeriodToUpdate);    // seconds

                    if (TimeSpan.Compare(span, max) > 0)
                        result = false;
                }
            }

            return result;
        }
        public static bool SetIncidentState1(Int32 incidentId, Int32 periodToUpdate1)
        {
            bool result = false;

            IncidentDS.IncidentStateDSDataTable dt = DalIncidentState.SetIncidentState1(incidentId, periodToUpdate1);
            if (dt.Rows.Count != 0)
            {
                if ((!dt[0].Isdate_accessed_0Null()) && (!dt[0].Isperiod_to_update_0Null()))
                {
                    result = true;

                    DateTime date_accessed_0 = dt[0].date_accessed_0;
                    DateTime date_accessed_1 = dt[0].date_accessed_1;
                    Int32 periodToUpdate0 = dt[0].period_to_update_0;

                    Int32 maxPeriodToUpdate = periodToUpdate0 + periodToUpdate1;
                    TimeSpan span = date_accessed_1.Subtract(date_accessed_0);
                    TimeSpan max = new TimeSpan(0, 0, 0, maxPeriodToUpdate);    // seconds

                    if (TimeSpan.Compare(span, max) > 0)
                        result = false;
                }
            }

            return result;
        }




    }


    public class BllIncidentNote
    {

        private static IncidentDS.IncidentNoteDSDataTable processData(IncidentDS.IncidentNoteDSDataTable dt)
        {
            foreach (IncidentDS.IncidentNoteDSRow row in dt.Rows)
            {
                row.user_full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }
        //-----------------------------------------------------------------------------




        public static IncidentDS.IncidentNoteDSDataTable SelectIncidentNote(Int32 noteId)
        {
            IncidentDS.IncidentNoteDSDataTable dt = DalIncidentNote.SelectIncidentNote(noteId);
            return processData(dt);
        }


        public static IncidentDS.IncidentNoteDSDataTable GetAllIncidentNotes(Int32 incidentId)
        {
            IncidentDS.IncidentNoteDSDataTable dt = DalIncidentNote.GetAllIncidentNotes(incidentId);
            return processData(dt);
        }


        public static void InsertIncidentNote(Int32 incidentId, Int32 userId, string note)
        {
            DalIncidentNote.InsertIncidentNote(incidentId, userId, note);
        }


        public static Int32 DeleteIncidentNote(Int32 noteId)
        {
            return DalIncidentNote.DeleteIncidentNote(noteId);
        }
    }





    //============================================================
    public class BllIncidentHelper
    {

        public static Int32 GetIncidentStatus(Int32 incidentId)
        {
            return DalIncidentHelper.GetIncidentStatus(incidentId);
        }


        public static void SetIncidentStatus(Int32 incidentId, Int32 statusId)
        {
            DalIncidentHelper.SetIncidentStatus(incidentId, statusId);

            //if ((statusId == 3) || (statusId == 4))  //3:Canceled; 4:Closed;
            //    DalIncidentState.DeleteIncidentState(incidentId);
        }

        public static void SetIncidentSubject(Int32 incidentId, Int32 statusId, string subject)
        {
            DalIncidentHelper.SetIncidentSubject(incidentId, statusId, subject);
        }



        public static void SetIncidentReservation(Int32 incidentId, Int32 reservedAgentId)
        {
            DalIncidentHelper.SetIncidentReservation(incidentId, reservedAgentId);
        }

        public static void SetIncidentConnectCount(Int32 incidentId)
        {
            DalIncidentHelper.SetIncidentConnectCount(incidentId);
        }



        public static void TransferIncident(Int32 userId, Int32 incidentId, Int32 statusId, Int32 fromAgentId, Int32 toAgentId)
        {
            DalIncidentHelper.TransferIncident(userId, incidentId, statusId, fromAgentId, toAgentId);
        }


    }


}
