using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.LIB.BllProxy
{



    public class BllProxyGroup
    {


        public static GroupDS.GroupDSDataTable GetGroupList(Int32 agent_id, Int32 facility_id)
        {
            return BllGroup.GetGroupList(agent_id, facility_id);
        }







        public static GroupDS.GroupDSDataTable SelectGroup(Int32 group_id)
        {
            return BllGroup.SelectGroup(group_id);
        }

        public static Int32 InsertGroup(string group_name)
        {
            return BllGroup.InsertGroup(group_name);
        }

        public static Int32 UpdateGroup(Int32 group_id, string group_name)
        {
            return BllGroup.UpdateGroup(group_id, group_name);
        }

        public static Int32 DeleteGroup(Int32 group_id)
        {
            return BllGroup.DeleteGroup(group_id);
        }

    }

    
    
    public class BllProxyGroupAgent
    {

        public static GroupDS.GroupAgentDSDataTable GetAllGroupAgents(Int32 group_id)
        {
            return BllGroupAgent.GetAllGroupAgents(group_id);
        }

        public static void SetGroupAgent(Int32 group_id, Int32 agent_id, bool is_set)
        {
            BllGroupAgent.SetGroupAgent(group_id, agent_id, is_set);
        }

    }



    public class BllProxyGroupFacility
    {

        public static GroupDS.GroupFacilityDSDataTable GetAllGroupFacilities(Int32 group_id)
        {
            return BllGroupFacility.GetAllGroupFacilities(group_id);
        }

        public static void SetGroupFacility(Int32 group_id, Int32 facility_id, bool is_set)
        {
            BllGroupFacility.SetGroupFacility(group_id, facility_id, is_set);
        }

    }



}
