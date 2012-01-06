using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{



    public class BllCall
    {


        private static CallDS.CallDSDataTable processData(CallDS.CallDSDataTable dt)
        {
            foreach (CallDS.CallDSRow row in dt.Rows)
            {
                row.from_full_name = Helper.GetFullName(row.from_first_name, row.from_last_name);
                row.to_full_name = Helper.GetFullName(row.to_first_name, row.to_last_name);
            }

            return dt;
        }

        //=====================================================================================================================




        public static CallDS.CallDSDataTable SelectCall(Int32 callId)
        {
            CallDS.CallDSDataTable dt = DalCall.SelectCall(callId);
            return processData(dt);
        }

        
        public static CallDS.CallDSDataTable GetCallsByContact(Int32 contactId)
        {
            CallDS.CallDSDataTable dt = DalCall.GetCallsByContact(contactId);
            return processData(dt);
        }
        public static CallDS.CallDSDataTable GetCallsByStatus(Int32 statusId)
        {
            CallDS.CallDSDataTable dt = DalCall.GetCallsByStatus(statusId);
            return processData(dt);
        }

        public static CallDS.CallDSDataTable GetCallsAll(Int32 fromContactId, Int32 toContactId, Int32 statusId)
        {
            CallDS.CallDSDataTable dt = DalCall.GetCallsAll(fromContactId, toContactId, statusId);
            return processData(dt);
        }








        public static Int32 InsertCall(Guid guid, Int32 fromContactId, Int32 toContactId)
        {
            return DalCall.InsertCall(guid, fromContactId, toContactId);
        }

        //========================




    }



    public class BllCallHelper
    {


        public static void SetCallOpen(Int32 callId)
        {
            DalCallHelper.SetCallOpen(callId);
        }

        public static void SetCallClose(Int32 callId)
        {
            DalCallHelper.SetCallClose(callId);
        }

        public static void SetCallCancel(Int32 callId)
        {
            DalCallHelper.SetCallCancel(callId);
        }



    }





}
