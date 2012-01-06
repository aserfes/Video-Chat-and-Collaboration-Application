using System;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.GroupDSTableAdapters;



namespace UCENTRIK.DAL
{



    public class DalGroup
    {

        public static GroupDS.GroupDSDataTable GetGroupList(Int32 agentId, Int32 facilityId)
        {
            GroupDSTableAdapter ta = new GroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetGroupList(agentId, facilityId);
        }


        





        public static GroupDS.GroupDSDataTable SelectGroup(Int32 groupId)
        {
            GroupDSTableAdapter ta = new GroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(groupId);
        }





        public static Int32 InsertGroup(string groupName)
        {
            GroupDSTableAdapter ta = new GroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return Convert.ToInt32(ta.InsertGroup(groupName));
        }

        public static Int32 UpdateGroup(Int32 groupId, string groupName)
        {
            GroupDSTableAdapter ta = new GroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Update(groupId, groupName);
        }

        public static Int32 DeleteGroup(Int32 groupId)
        {
            GroupDSTableAdapter ta = new GroupDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(groupId);
        }

        //========================










    }

    
    
    public class DalGroupAgent
    {

        public static GroupDS.GroupAgentDSDataTable GetAllGroupAgents(Int32 groupId)
        {
            GroupAgentDSTableAdapter ta = new GroupAgentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(groupId);
        }
        
        public static void SetGroupAgent(Int32 groupId, Int32 agentId, bool isSet)
        {
            GroupAgentDSTableAdapter ta = new GroupAgentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.SetGroupAgent(groupId, agentId, isSet);
        }


    }

    
    
    public class DalGroupFacility
    {

        public static GroupDS.GroupFacilityDSDataTable GetAllGroupFacilities(Int32 groupId)
        {
            GroupFacilityDSTableAdapter ta = new GroupFacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(groupId);
        }

        public static void SetGroupFacility(Int32 groupId, Int32 facilityId, bool isSet)
        {
            GroupFacilityDSTableAdapter ta = new GroupFacilityDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            ta.SetGroupFacility(groupId, facilityId, isSet);
        }


    }



}
