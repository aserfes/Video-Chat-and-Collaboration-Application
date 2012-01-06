using System;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{



    public class BllProxyCall
    {

        public static CallDS.CallDSDataTable SelectCall(Int32 call_id)
        {
            return BllCall.SelectCall(call_id);
        }

        public static CallDS.CallDSDataTable GetCallsByContact(Int32 contact_id)
        {
            return BllCall.GetCallsByContact(contact_id);
        }
        public static CallDS.CallDSDataTable GetCallsByStatus(Int32 status_id)
        {
            return BllCall.GetCallsByStatus(status_id);
        }
        public static CallDS.CallDSDataTable GetCallsAll(Int32 from_contact_id, Int32 to_contact_id, Int32 status_id)
        {
            return BllCall.GetCallsAll(from_contact_id, to_contact_id, status_id);
        }

        
        




        public static Int32 InsertCall(Guid guid, Int32 from_contact_id, Int32 to_contact_id)
        {
            return BllCall.InsertCall(guid, from_contact_id, to_contact_id);
        }

        //========================
    }











    public class BllProxyCallHelper
    {
        public static void SetCallOpen(Int32 call_id)
        {
            BllCallHelper.SetCallOpen(call_id);
        }

        public static void SetCallClose(Int32 call_id)
        {
            BllCallHelper.SetCallClose(call_id);
        }

        public static void SetCallCancel(Int32 call_id)
        {
            BllCallHelper.SetCallCancel(call_id);
        }
        //========================
    }





}
