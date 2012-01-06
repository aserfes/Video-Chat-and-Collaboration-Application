//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace UcWebKiosk.App_Core.Helpers
//{
//    public class IncidentHelper
//    {
//    }
//}


using System;
using System.Collections.Generic;
using System.Web;


using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;




namespace UCENTRIK.Helpers
{
    public class IncidentHelper
    {



        ////------------------------------------------------------------------------------------
        ////------------------------------------------------------------------------------------
        ////------------------------------------------------------------------------------------
        //public static void SetIncidentStateActive(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "ACT");
        //}
        //public static void SetIncidentStateVideoSession(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "VID");
        //}
        //public static void SetIncidentStateScreenCast(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "SCT");
        //}
        //public static void SetIncidentStateAppShareSend(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "APS");
        //}
        //public static void SetIncidentStateAppShareReceive(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, true, "APR");
        //}
        //public static void SetIncidentStateInactive(Int32 incidentId)
        //{
        //    BllProxyIncidentState.UpdateIncidentState(incidentId, false, "CLS");
        //}




        //------------------------------------------------------------------------------------

        public static bool GetIncidentState(Int32 incidentId, ref Int32 statusId, ref string state)
        {
            bool isActive = false;
            statusId = 0;
            state = "";

            IncidentDS.IncidentStateDSDataTable dt = BllProxyIncidentState.SelectIncidentState(incidentId);

            if (dt.Rows.Count != 0)
            {
                statusId = dt[0].status_id;

                if(!dt[0].IsstateNull())
                    state = dt[0].state;

                if (!dt[0].Isis_activeNull())
                    isActive = dt[0].is_active;
            }

            return isActive;
        }




    }

}
