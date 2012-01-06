using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{

    public class BllFacility
    {

        private static FacilityDS.FacilityDSDataTable processData(FacilityDS.FacilityDSDataTable dt)
        {
            foreach (FacilityDS.FacilityDSRow row in dt.Rows)
            {
                row.user_full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }

        //=========================================================================================









		public static FacilityDS.FacilityDSDataTable GetAllFacilities( Int32 stamp_max_ms )
        {
			FacilityDS.FacilityDSDataTable dt = DalFacility.GetAllFacilities( stamp_max_ms );
            return processData(dt);
        }

		public static FacilityDS.FacilityDSDataTable GetFacilitiesByAgent( Int32 stamp_max_ms, Int32 agent_id )
        {
			FacilityDS.FacilityDSDataTable dt = DalFacility.GetFacilitiesByAgent( stamp_max_ms, agent_id );
            return processData(dt);
        }


        public static FacilityDS.FacilityDSDataTable SelectFacility(Int32 facilityId)
        {
            FacilityDS.FacilityDSDataTable dt = DalFacility.SelectFacility(facilityId);
            return processData(dt);
        }

        public static FacilityDS.FacilityDSDataTable GetFacilityByGuid(Guid facilityGuid)
        {
            FacilityDS.FacilityDSDataTable dt = DalFacility.GetFacilityByGuid(facilityGuid);
            return processData(dt);
        }

        public static FacilityDS.FacilityDSDataTable GetFacilityByUser(Int32 userId)
        {
            FacilityDS.FacilityDSDataTable dt = DalFacility.GetFacilityByUser(userId);
            return processData(dt);
        }





        public static Int32 InsertFacility(bool active, Int32 userId, Int32 surveyId, string name, string address, string phone, string ipAddress, string webReferrer)
        {
            return DalFacility.InsertFacility(active, userId, surveyId, name, address, phone, ipAddress, webReferrer);
        }

        public static Int32 UpdateFacility(Int32 facilityId, bool active, Int32 userId, Int32 surveyId, string name, string address, string phone, string ipAddress, string webReferrer)
        {
            return DalFacility.UpdateFacility(facilityId, active, userId, surveyId, name, address, phone, ipAddress, webReferrer);
        }


        public static Int32 DeleteFacility(Int32 facilityId)
        {
            return DalFacility.DeleteFacility(facilityId);
        }

		public static int SetCommand( int facility_id, int agent_id, string command )
		{
			return DalFacility.SetCommand( facility_id, agent_id, command );
		}

		public static int SetStatus( int facility_id, string status, int stamp_max_ms, ref string command, ref int agent_id )
		{
			return DalFacility.SetStatus( facility_id, status, stamp_max_ms, ref command, ref agent_id );
		}



    }





    public class BllFacilityGroup
    {
        public static FacilityDS.FacilityGroupDSDataTable GetAllFacilityGroups(Int32 facilityId)
        {
            return DalFacilityGroup.GetAllFacilityGroups(facilityId);
        }

		public static FacilityDS.FacilityGroupDSDataTable GetFacilityGroupsByFacility( Int32 facilityId )
		{
			return DalFacilityGroup.GetFacilityGroupsByFacility( facilityId );
		}
	}
}

