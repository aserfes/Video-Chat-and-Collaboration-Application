using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;
using UCENTRIK.AppSettings;




namespace UCENTRIK.LIB.BllProxy
{

    public class BllProxyIncident
    {




        ////-----------------------------------------------------------------------------
        //public static IncidentDS.IncidentDSDataTable GetIncidentQueue(Int32 status_id, Int32 agent_id)
        //{
        //    //return BllIncident.GetIncidentQueue();
        //    //-----

            
        //    Cache cache = HttpContext.Current.Cache;
        //    bool bypassCache = false;
        //    string cacheKey = "CustomersDataTable";

        //    object cacheItem = cache[cacheKey] as IncidentDS.IncidentDSDataTable;

        //    if ((bypassCache) || (cacheItem == null))
        //    {
        //        cacheItem = BllIncident.GetIncidentQueue();

        //        //cache.Insert(cacheKey, cacheItem, null, DateTime.Now.AddSeconds(10), TimeSpan.Zero);
        //        //cache.Insert(cacheKey, cacheItem, null, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);
                
        //        //cache.Insert(cacheKey, cacheItem, null, DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration);
        //        cache.Insert(cacheKey, cacheItem, null, DateTime.Now.AddSeconds(SosConstant.SOSCACHEEXPIRATION), Cache.NoSlidingExpiration);
        //    }
        //    return (IncidentDS.IncidentDSDataTable)cacheItem;
        //}



















        public static IncidentDS.IncidentDSDataTable GetIncidentsByStatus(Int32 status_id, Int32 agent_id)
        {
            return BllIncident.GetIncidentsByStatus(status_id, agent_id);
        }


        public static IncidentDS.IncidentDSDataTable GetIncidentsByContact(Int32 status_id, Int32 contact_id)
        {
            return BllIncident.GetIncidentsByContact(status_id, contact_id);
        }





        public static IncidentDS.IncidentDSDataTable GetIncidentQueueList(Int32 status_id, Int32 agent_id)
        {
            return BllIncident.GetIncidentQueueList(status_id, agent_id);
        }



        public static IncidentDS.IncidentDSDataTable GetIncidentFollowUpList(Int32 status_id, Int32 agent_id)
        {
            return BllIncident.GetIncidentFollowUpList(status_id, agent_id);
        }



        
        //-----------------------------------------------------------------------------
        public static IncidentDS.IncidentDSDataTable OpenIncident(Int32 incident_id, Int32 agent_id)
        {
            return BllIncident.OpenIncident(incident_id, agent_id);
        }
        public static IncidentDS.IncidentDSDataTable OpenFollowUpIncident(Int32 incident_id, Int32 agent_id)
        {
            return BllIncident.OpenFollowUpIncident(incident_id, agent_id);
        }

        








        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentDSDataTable SelectIncident(Int32 incident_id)
        {
            return BllIncident.SelectIncident(incident_id);
        }

        public static IncidentDS.IncidentDSDataTable GetIncidentByGuid(Guid incident_guid)
        {
            return BllIncident.GetIncidentByGuid(incident_guid);
        }




        public static Int32 InsertIncident(Int32 group_id, Int32 skill_id, Int32 lang_id, Int32 facility_id, Int32 contact_id, Int32 agent_id)
        {
            return BllIncident.InsertIncident(group_id, skill_id, lang_id, facility_id, contact_id, agent_id);
        }


        public static Int32 UpdateIncident(Int32 incident_id, Int32 contact_id, Int32 agent_id, Int32 status_id, string subject)
        {
            return BllIncident.UpdateIncident(incident_id, contact_id, agent_id, status_id, subject);
        }


        public static Int32 DeleteIncident(Int32 incident_id)
        {
            return BllIncident.DeleteIncident(incident_id);
        }


        //public static Guid CreateIncident(Int32 facility_id)
        //{

        //    return BllIncident.CreateIncident(facility_id);
        //}

    }

    public class BllProxyIncidentState
    {



        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentStateDSDataTable SelectIncidentState(Int32 incident_id)
        {
            return BllIncidentState.SelectIncidentState(incident_id);
        }

        public static void InsertIncidentState(Int32 incident_id, bool is_active, string state)
        {
            BllIncidentState.InsertIncidentState(incident_id, is_active, state);
        }

        public static Int32 UpdateIncidentState(Int32 incident_id, bool is_active, string state)
        {
            return BllIncidentState.UpdateIncidentState(incident_id, is_active, state);
        }


        public static bool SetIncidentState0(Int32 incident_id, Int32 period_to_update)
        {
            return BllIncidentState.SetIncidentState0(incident_id, period_to_update);
        }
        public static bool SetIncidentState1(Int32 incident_id, Int32 period_to_update)
        {
            return BllIncidentState.SetIncidentState1(incident_id, period_to_update);
        }



        public static Int32 DeleteIncidentState(Int32 incident_id)
        {
            return BllIncidentState.DeleteIncidentState(incident_id);
        }
    }

    public class BllProxyIncidentNote
    {

        public static IncidentDS.IncidentNoteDSDataTable SelectIncidentNote(Int32 note_id)
        {
            return BllIncidentNote.SelectIncidentNote(note_id);
        }


        public static IncidentDS.IncidentNoteDSDataTable GetAllIncidentNotes(Int32 incident_id)
        {
            return BllIncidentNote.GetAllIncidentNotes(incident_id);
        }


        public static void InsertIncidentNote(Int32 incident_id, Int32 user_id, string note)
        {
            BllIncidentNote.InsertIncidentNote(incident_id, user_id, note);
        }


        public static Int32 DeleteIncidentNote(Int32 note_id)
        {
            return BllIncidentNote.DeleteIncidentNote(note_id);
        }
    }








    //==============================================================================
    public class BllProxyIncidentHelper
    {

        public static Int32 GetIncidentStatus(Int32 incident_id)
        {
            return BllIncidentHelper.GetIncidentStatus(incident_id);
        }


        public static void SetIncidentStatus(Int32 incident_id, Int32 status_id)
        {
            BllIncidentHelper.SetIncidentStatus(incident_id, status_id);
        }

        public static void SetIncidentSubject(Int32 incident_id, Int32 status_id, string subject)
        {
            BllIncidentHelper.SetIncidentSubject(incident_id, status_id, subject);
        }



        public static void SetIncidentReservation(Int32 incident_id, Int32 reserved_agent_id)
        {
            BllIncidentHelper.SetIncidentReservation(incident_id, reserved_agent_id);
        }

        public static void SetIncidentConnectCount(Int32 incident_id)
        {
            BllIncidentHelper.SetIncidentConnectCount(incident_id);
        }


        public static void TransferIncident(Int32 user_id, Int32 incident_id, Int32 status_id, Int32 from_agent_id, Int32 to_agent_id)
        {
            BllIncidentHelper.TransferIncident(user_id, incident_id, status_id, from_agent_id, to_agent_id);
        }

    }


}
