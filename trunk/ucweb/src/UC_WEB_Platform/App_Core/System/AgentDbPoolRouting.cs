using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data;

using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.Helpers;
using UCENTRIK.AppSettings;

namespace UCENTRIK.ROUTING
{




    //==========================================================
    //==========================================================
    //==========================================================
    public class AgentPool
    {


        public AgentPool()
        {
        }













        //-------------------------------------------------------------------------------
        public void RegisterAgent(Int32 agentId)
        {
            if (agentId != 0)
            {
                PoolDS.PoolDSDataTable dt = BllProxyPool.SelectPoolAgent(agentId);
                if (dt.Rows.Count == 0)
                {
                    BllProxyPool.InsertPoolAgent(agentId);
                }
            }
        }

        //-------------------------------------------------------------------------------
        public void UnRegisterAgent(Int32 agentId)
        {
            BllProxyPool.SetPoolAgentAvailable(agentId, false);
            //BllProxyPool.DeletePoolAgent(agentId);
        }






        ////-------------------------------------------------------------------------------
        //public void SetAgentAvailable(Int32 agentId, bool available)
        //{
        //    BllProxyPool.SetPoolAgentAvailable(agentId, available);
        //    if (available)
        //        this.SetAgentBusy(agentId, false);

        //}


        //-------------------------------------------------------------------------------
        public void SetAgentOn(Int32 agentId)
        {
            BllProxyPool.SetPoolAgentAvailable(agentId, true);
            this.SetAgentBusy(agentId, false);
        }
        public void SetAgentOff(Int32 agentId)
        {
            BllProxyPool.SetPoolAgentAvailable(agentId, false);
        }




        //-------------------------------------------------------------------------------
        public void SetAgentBusy(Int32 agentId, bool busy)
        {
            PoolDS.PoolDSDataTable dtPool = BllProxyPool.SelectPoolAgent(agentId);
            if (dtPool.Rows.Count != 0)
            {
                bool isBusy = busy;

                if (!isBusy)
                {
                    IncidentDS.IncidentDSDataTable dtIncident = BllProxyIncident.GetIncidentsByStatus(2, agentId);   //2:In-Progress
                    if (dtIncident.Rows.Count != 0)
                    {
                        isBusy = true;
                    }
                }


                if (isBusy)
                    BllProxyPool.SetPoolAgentBusy(agentId, true);
                else
                    BllProxyPool.SetPoolAgentBusy(agentId, busy);

                BllProxyPool.SetPoolAgentIncident(agentId, 0);
            }

        }







        //-------------------------------------------------------------------------------
        public Int32 GetAgentIncident(Int32 agentId)
        {
            Int32 incidentId = 0;

            PoolDS.PoolDSDataTable dt = BllProxyPool.SelectPoolAgent(agentId);
            if (dt.Rows.Count != 0)
            {
                if (!dt[0].Isincident_idNull())
                    incidentId = dt[0].incident_id;
            }

            return incidentId;
        }







        //-------------------------------------------------------------------------------
        public void ReleaseIncident(Int32 incidentId)
        {
            PoolDS.PoolDSDataTable dt = BllProxyPool.GetAllPoolAgents();
            foreach (PoolDS.PoolDSRow row in dt.Rows)
            {
                if (!dt[0].Isincident_idNull())
                {
                    if (row.incident_id == incidentId)
                    {
                        BllProxyPool.SetPoolAgentIncident(row.agent_id, 0);
                    }
                }
            }
        }


        public void SetSession(Int32 agentId, Int32 incidentId)
        {
            BllProxyPool.SetPoolAgentSession(agentId, incidentId);
        }



        public void DoRoutine()
        {
            try
            {
                PoolDS.PoolDSDataTable dtAllPoolAgents = BllProxyPool.GetAllPoolAgents();

                cancelObsoleteIncidents();

                if (this.cleanUp(dtAllPoolAgents))
                    dtAllPoolAgents = BllProxyPool.GetAllPoolAgents();

                if (this.checkReservations(dtAllPoolAgents))
                    dtAllPoolAgents = BllProxyPool.GetAllPoolAgents();

                this.handleIncidentQueue(dtAllPoolAgents);
            }
            catch
            {
            }
        }








        //=========================================================================

        protected Int32 getAverageLoadBalanceRate()
        {
            //Int32 num = 0;
            //Int32 sum = 0;

            //foreach (AgentAccount agent in table.Values)
            //{
            //    if (agent.IsAvailable)
            //    {
            //        sum += agent.LoadBalanceRating;
            //        num++;
            //    }
            //}

            //Int32 result = 0;
            //if (num != 0)
            //    result = sum / num;

            //return result;


            return 0;
        }










        /// <summary>
        /// Cancel the Obsolete incidents (sitting too long in Queue)
        /// </summary>
        /// <returns></returns>
        protected bool cancelObsoleteIncidents()
        {
            bool result = false;

            //int cleanUpInterval = 300; // SosParameters.SosCallCleanUpInterval;


            //IncidentDS.IncidentDSDataTable dt = BllProxyIncident.GetIncidentQueueList(1, 0);   //1:New; 0:All
            IncidentDS.IncidentDSDataTable dt = BllProxyIncident.GetIncidentsByStatus(1, 0);   //1:New; 0:All

            foreach (IncidentDS.IncidentDSRow rowIncident in dt)
            {
                if (rowIncident.Isdate_openNull())  // Not for transferred incidents
                {
                    DateTime now = DateTime.Now.ToUniversalTime();
                    TimeSpan span = now.Subtract(rowIncident.date_created);
                    TimeSpan max = new TimeSpan(0, 0, 15, 0);                        // 15 minutes

                    if (TimeSpan.Compare(span, max) > 0)
                    {
                        Int32 incidentId = rowIncident.incident_id;
                        BllProxyIncidentHelper.SetIncidentSubject(incidentId, 3, "[_CLEARED_]");    // Canceled

                        result = true;
                        break;
                    }
                }
                //---
            }


            return result;
        }



        /// <summary>
        /// Disable the Agent if not online (Agent in AgentPool is not renewed for too long)
        /// Remove the Agent from AgentPool if not online for a week
        /// </summary>
        /// <param name="dtAllPoolAgents"></param>
        /// <returns></returns>
        protected bool cleanUp(PoolDS.PoolDSDataTable dtAllPoolAgents)
        {
            bool result = false;

            int cleanUpInterval = UcConfParameters.UcCallCleanUpInterval;

            foreach (PoolDS.PoolDSRow row in dtAllPoolAgents.Rows)
            {
                Int32 agentId = row.agent_id;


                DateTime now = DateTime.Now.ToUniversalTime();
                TimeSpan span = now.Subtract(row.date_accessed);
                TimeSpan max;

                if (row.is_available)
                {


                    // Disable the Agent if not online (Agent in AgentPool is not renewed for too long)
                    max = new TimeSpan(0, 0, cleanUpInterval);             // seconds
                    if (TimeSpan.Compare(span, max) > 0)
                    {
                        BllProxyPool.SetPoolAgentAvailable(agentId, false);
                        result = true;
                    }




                    // Clean up the Agent's Incident and turn Agent available if the Incident is gone
                    if (!row.Isincident_idNull())
                    {
                        IncidentDS.IncidentDSDataTable dtIncident = BllProxyIncident.SelectIncident(row.incident_id);
                        if (dtIncident.Rows.Count > 0)
                        {

                            //if ((dtIncident[0].status_id != 1) || (dtIncident[0].agent_id != agentId))
                            if ((dtIncident[0].status_id != 1) || ((!dtIncident[0].Isagent_idNull()) && (dtIncident[0].agent_id != agentId)))
                            {
                                BllProxyPool.SetPoolAgentIncident(agentId, 0);
                                BllProxyPool.SetPoolAgentBusy(agentId, false);

                                result = true;
                            }
                        }
                    }


                }
                else
                {
                    // Remove the Agent from AgentPool if not online for a week

                    max = new TimeSpan(7, 0, 0, 0);                        // 7 days
                    if (TimeSpan.Compare(span, max) > 0)
                    {
                        BllProxyPool.DeletePoolAgent(agentId);
                        result = true;
                    }

                }




            }

            return result;
        }
        


        /// <summary>
        /// Clear the Incident's ReservedAgent and Disable Agent not taking the call
        /// </summary>
        /// <param name="dtAllPoolAgents"></param>
        /// <returns></returns>
        protected bool checkReservations(PoolDS.PoolDSDataTable dtAllPoolAgents)
        {
            bool result = false;

            PoolDS.PoolDSRow[] rows = (PoolDS.PoolDSRow[])dtAllPoolAgents.Select("is_available=1 and is_busy=0", "");
            if (rows.Length > 0)
            {
                int cancelInterval = UcConfParameters.UcCallForwardingInterval;     // seconds


                foreach (PoolDS.PoolDSRow row in dtAllPoolAgents.Rows)
                {
                    if ((!row.Isincident_idNull()) && (!row.Isdate_reservedNull()))
                    {
                        DateTime now = DateTime.Now.ToUniversalTime();
                        TimeSpan span = now.Subtract(row.date_reserved);
                        TimeSpan max = new TimeSpan(0, 0, cancelInterval);

                        if (TimeSpan.Compare(span, max) > 0)
                        {
                            Int32 incidentId = row.incident_id;

                            Int32 incidentStatusId = 0;
                            Int32 incidentAgentId = 0;

                            IncidentDS.IncidentDSDataTable dtIncident = BllProxyIncident.SelectIncident(incidentId);
                            if (dtIncident.Rows.Count > 0)
                            {
                                incidentStatusId = dtIncident[0].status_id;
                                if (!dtIncident[0].Isagent_idNull())
                                    incidentAgentId = dtIncident[0].agent_id;
                            }



                            if (incidentAgentId == 0)
                            {
                                if (incidentStatusId == 1)
                                {
                                    BllProxyIncidentHelper.SetIncidentReservation(incidentId, 0);
                                    BllProxyPool.SetPoolAgentAvailable(row.agent_id, false);
                                    BllProxyPool.SetPoolAgentBusy(row.agent_id, false);
                                }
                                else
                                {
                                    BllProxyPool.SetPoolAgentAvailable(row.agent_id, true);
                                    BllProxyPool.SetPoolAgentBusy(row.agent_id, true);
                                }
                            }

                            result = true;
                        }
                    }
                }
            }

            return result;
        }



        /// <summary>
        /// Assign the Incident to the available Agent
        /// </summary>
        /// <param name="dtAllPoolAgents"></param>
        /// <returns></returns>
        protected bool handleIncidentQueue(PoolDS.PoolDSDataTable dtAllPoolAgents)
        {
            bool result = false;

            IncidentDS.IncidentDSDataTable dt;

            PoolDS.PoolDSRow[] rows = (PoolDS.PoolDSRow[])dtAllPoolAgents.Select("", "last_call_time");

            foreach (PoolDS.PoolDSRow row in rows)
            {
                Int32 agentId = row.agent_id;

                if ((row.is_available) && (!row.is_busy))
                {
                    dt = BllProxyIncident.GetIncidentQueueList(1, agentId);   //1:New

                    foreach (IncidentDS.IncidentDSRow rowIncident in dt)
                    {
                        if (rowIncident.Isreserved_agent_idNull())
                        {
                            Int32 incidentId = rowIncident.incident_id;
                            BllProxyIncidentHelper.SetIncidentReservation(incidentId, agentId);

                            BllProxyPool.SetPoolAgentBusy(agentId, true);
                            BllProxyPool.SetPoolAgentIncident(agentId, incidentId);

                            result = true;
                            break;
                        }

                        //---
                    }
                }
            }


            return result;
        }


    }


}
