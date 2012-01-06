using System;

using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{


    public class BllGroup
    {

        private static GroupDS.GroupDSDataTable processData(GroupDS.GroupDSDataTable dt)
        {
            return dt;
        }







        public static GroupDS.GroupDSDataTable GetGroupList(Int32 agentId, Int32 facilityId)
        {
            GroupDS.GroupDSDataTable dt = DalGroup.GetGroupList(agentId, facilityId);
            return processData(dt);
        }





        public static GroupDS.GroupDSDataTable SelectGroup(Int32 groupId)
        {
            GroupDS.GroupDSDataTable dt = DalGroup.SelectGroup(groupId);
            return processData(dt);
        }


        public static Int32 InsertGroup(string groupName)
        {
            return DalGroup.InsertGroup(groupName);
        }

        public static Int32 UpdateGroup(Int32 groupId, string groupName)
        {
            return DalGroup.UpdateGroup(groupId, groupName);
        }

        public static Int32 DeleteGroup(Int32 groupId)
        {
            return DalGroup.DeleteGroup(groupId);
        }




        //=====================================================================================================================


    }

    
    
    public class BllGroupAgent
    {
        private static GroupDS.GroupAgentDSDataTable processData(GroupDS.GroupAgentDSDataTable dt)
        {
            foreach (GroupDS.GroupAgentDSRow row in dt.Rows)
            {
                row.full_name = Helper.GetFullName(row.first_name, row.last_name);
            }

            return dt;
        }

        public static GroupDS.GroupAgentDSDataTable GetAllGroupAgents(Int32 groupId)
        {
            GroupDS.GroupAgentDSDataTable dt = DalGroupAgent.GetAllGroupAgents(groupId);
            return processData(dt);
        }


        public static void SetGroupAgent(Int32 groupId, Int32 agentId, bool isSet)
        {
            DalGroupAgent.SetGroupAgent(groupId, agentId, isSet);
        }
    }

    
    
    public class BllGroupFacility
    {

        public static GroupDS.GroupFacilityDSDataTable GetAllGroupFacilities(Int32 groupId)
        {
            return DalGroupFacility.GetAllGroupFacilities(groupId);
        }

        public static void SetGroupFacility(Int32 groupId, Int32 facilityId, bool isSet)
        {
            DalGroupFacility.SetGroupFacility(groupId, facilityId, isSet);
        }


    }



}



