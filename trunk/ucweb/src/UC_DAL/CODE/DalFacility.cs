using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.FacilityDSTableAdapters;


namespace UCENTRIK.DAL
{

    public class DalFacility
    {

		public static FacilityDS.FacilityDSDataTable GetAllFacilities( Int32 stamp_max_ms )
		{
			FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
			ta.Connection.ConnectionString = UcConnection.ConnectionString;
			return ta.GetAllFacilities( stamp_max_ms );
		}

		public static FacilityDS.FacilityDSDataTable GetFacilitiesByAgent( Int32 stamp_max_ms, Int32 agent_id )
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
			return ta.GetFacilitiesByAgent( stamp_max_ms, agent_id );
        }






        public static FacilityDS.FacilityDSDataTable SelectFacility(Int32 facilityId)
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(facilityId);
        }

        public static FacilityDS.FacilityDSDataTable GetFacilityByGuid(Guid facilityGuid)
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetFacilityByGuid(facilityGuid);
        }


        public static FacilityDS.FacilityDSDataTable GetFacilityByUser(Int32 userId)
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetFacilityByUser(userId);
        }







        public static Int32 InsertFacility(bool active, Int32 userId, Int32 surveyId, string name, string address, string phone, string ipAddress, string webReferrer)
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> user_id = Helper.ResolveEmptyInt(userId);
            System.Nullable<Int32> survey_id = Helper.ResolveEmptyInt(surveyId);

            int id = Convert.ToInt32(ta.InsertFacility(active, user_id, survey_id, name, address, phone, ipAddress, webReferrer));
            return id;
        }






        public static Int32 UpdateFacility(Int32 facilityId, bool active, Int32 userId, Int32 surveyId, string name, string address, string phone, string ipAddress, string webReferrer)
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            System.Nullable<Int32> user_id = Helper.ResolveEmptyInt(userId);
            System.Nullable<Int32> survey_id = Helper.ResolveEmptyInt(surveyId);


            return ta.Update(facilityId, active, user_id, survey_id, name, address, phone, ipAddress, webReferrer);
        }


        public static Int32 DeleteFacility(Int32 facilityId)
        {
            FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(facilityId);
        }

		public static int SetCommand( int facility_id, int agent_id, string command )
		{
			FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
			ta.Connection.ConnectionString = UcConnection.ConnectionString;
			return ta.SetCommand
				( Helper.ResolveEmptyInt( facility_id )
				, Helper.ResolveEmptyInt( agent_id )
				, command
				);
		}

		public static int SetStatus( int facility_id, string status, int stamp_max_ms, ref string command, ref int agent_id )
		{
			FacilityDSTableAdapter ta = new FacilityDSTableAdapter();
			ta.Connection.ConnectionString = UcConnection.ConnectionString;

			int? agent_id_ = 0;
			int ret = ta.SetStatus
				( Helper.ResolveEmptyInt( facility_id )
				, status
				, Helper.ResolveEmptyInt( stamp_max_ms )
				, ref command
				, ref agent_id_
				);

			agent_id = agent_id_.HasValue ? agent_id_.Value : 0;

			return ret;
		}


    }





    public class DalFacilityGroup
    {

        public static FacilityDS.FacilityGroupDSDataTable GetAllFacilityGroups(Int32 facilityId)
        {
            FacilityGroupDSTableAdapter ta = new FacilityGroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(facilityId);
        }

		public static FacilityDS.FacilityGroupDSDataTable GetFacilityGroupsByFacility( Int32 facilityId )
		{
			FacilityGroupDSTableAdapter ta = new FacilityGroupDSTableAdapter();
			ta.Connection.ConnectionString = UcConnection.ConnectionString;
			return ta.GetDataByFacility( facilityId );
		}

    }
}
