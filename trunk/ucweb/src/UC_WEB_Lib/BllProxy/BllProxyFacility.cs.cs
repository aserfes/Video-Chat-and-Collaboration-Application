using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyFacility
    {

		public static FacilityDS.FacilityDSDataTable GetAllFacilities( Int32 stamp_max_ms )
        {
			return BllFacility.GetAllFacilities( stamp_max_ms );
        }

		public static FacilityDS.FacilityDSDataTable GetFacilitiesByAgent( Int32 stamp_max_ms, Int32 agent_id )
        {
			return BllFacility.GetFacilitiesByAgent( stamp_max_ms, agent_id );
        }






        public static FacilityDS.FacilityDSDataTable SelectFacility(Int32 facility_id)
        {
            return BllFacility.SelectFacility(facility_id);
        }

        public static FacilityDS.FacilityDSDataTable GetFacilityByGuid(Guid facility_guid)
        {
            return BllFacility.GetFacilityByGuid(facility_guid);
        }

        public static FacilityDS.FacilityDSDataTable GetFacilityByUser(Int32 user_id)
        {
            return BllFacility.GetFacilityByUser(user_id);
        }











        public static Int32 InsertFacility(bool active, Int32 user_id, Int32 survey_id, string facility_name, string address, string phone, string ip_address, string web_referrer)
        {
            return BllFacility.InsertFacility(active, user_id, survey_id, facility_name, address, phone, ip_address, web_referrer);
        }

        public static Int32 UpdateFacility(Int32 facility_id, bool active, Int32 user_id, Int32 survey_id, string facility_name, string address, string phone, string ip_address, string web_referrer)
        {
            return BllFacility.UpdateFacility(facility_id, active, user_id, survey_id, facility_name, address, phone, ip_address, web_referrer);
        }







        public static Int32 DeleteFacility(Int32 facility_id)
        {
            return BllFacility.DeleteFacility(facility_id);
        }

		public static int SetCommand( int facility_id, int agent_id, string command )
		{
			return BllFacility.SetCommand( facility_id, agent_id, command );
		}
		public static int SetStatus( int facility_id, string status, int stamp_max_ms, ref string command, ref int agent_id )
		{
			return BllFacility.SetStatus( facility_id, status, stamp_max_ms, ref command, ref agent_id );
		}


    }




    public class BllProxyFacilityGroup
    {
        public static FacilityDS.FacilityGroupDSDataTable GetAllFacilityGroups(Int32 facility_id)
        {
            return BllFacilityGroup.GetAllFacilityGroups(facility_id);
        }
		public static FacilityDS.FacilityGroupDSDataTable GetFacilityGroupsByFacility( Int32 facility_id )
		{
			return BllFacilityGroup.GetFacilityGroupsByFacility( facility_id );
		}
	}
}
