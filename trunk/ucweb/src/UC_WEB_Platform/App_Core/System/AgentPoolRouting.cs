using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data;

using SOS_Datasets.DATASETS;
using SOS.BllProxy;
using SOS.Helpers;

namespace SosWebPrototype.Routing
{

    public class AgentPoolRouting
    {
    }











    //==========================================================
    //==========================================================
    //==========================================================
    public class AgentAccount
    {

        private Int32 _agentId;
        private bool _isAvailable;
        private bool _isBusy;

        private Int32 _loadBalanceRating;

        private DateTime _created;
        private DateTime _accessed;
        private DateTime _reserved;

        private Int32 _incidentId;





        public Int32 AgentId
        {
            get { return _agentId; }
            set { _agentId = value; }
        }
        public bool IsAvailable
        {
            get { return _isAvailable; }
            set { _isAvailable = value; }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; }
        }

        


        public Int32 LoadBalanceRating
        {
            get { return _loadBalanceRating; }
            set { _loadBalanceRating = value; }
        }

        public TimeSpan TimeIdle
        {
            get
            {
                DateTime now = DateTime.Now.ToUniversalTime();
                TimeSpan span = now.Subtract(_accessed);

                return span;
            }
        }
        public TimeSpan Reserved
        {
            get
            {
                DateTime now = DateTime.Now.ToUniversalTime();
                TimeSpan span = now.Subtract(_reserved);

                return span;
            }
        }

        public Int32 IncidentId
        {
            set
            {
                _incidentId = value;
            }

            get
            {
                return _incidentId;
            }
        }




        public bool IsExpired
        {
            get
            {
                DateTime now = DateTime.Now.ToUniversalTime();
                TimeSpan span = now.Subtract(_accessed);

                TimeSpan max = new TimeSpan(0, 1, 0);
                if (TimeSpan.Compare(span, max) > 0)
                    return true;
                else
                    return false;
            }
        }

        public bool HasIncident
        {
            get
            {
                if (_incidentId != 0)
                    return true;
                else
                    return false;
            }
        }







        public AgentAccount(Int32 agentId, Int32 averageLoadBalanceRating)
        {
            this._agentId = agentId;

            this._isAvailable = false;
            this._isBusy = false;


            this._incidentId = 0;


            this.LoadBalanceRating = averageLoadBalanceRating;

            this._created = DateTime.Now.ToUniversalTime();
            this._accessed = DateTime.Now.ToUniversalTime();
        }



        public void Reserve()
        {
            this._reserved = DateTime.Now.ToUniversalTime();
        }


        public void Refresh()
        {
            this._accessed = DateTime.Now.ToUniversalTime();
        }
    }















    //==========================================================
    //==========================================================
    //==========================================================
    public class AgentPool
    {
        private Hashtable table;

        public Hashtable Table
        {
            get
            {
                return (Hashtable)table.Clone();
            }
        }

        public AgentPool()
        {
            table = new Hashtable();
        }













        public AgentAccount GetAgent(Int32 agentId)
        {
            AgentAccount agentAccount = null;

            if (table.Contains(agentId))
            {
                agentAccount = (AgentAccount)table[agentId];
            }

            return agentAccount;
        }






        public Int32 GetAgentIncident(Int32 agentId)
        {
            Int32 incidentId = 0;
            if (table.Contains(agentId))
            {
                AgentAccount agentAccount = (AgentAccount)table[agentId];
                incidentId = agentAccount.IncidentId;
            }
            return incidentId;
        }








        //-------------------------------------------------------------------------------
        public void RegisterAgent(Int32 agentId)
        {
            if (!table.Contains(agentId))
            {
                Int32 averageLoadBalanceRating = this.getAverageLoadBalanceRate();
                AgentAccount agentAccount = new AgentAccount(agentId, averageLoadBalanceRating);
                table.Add(agentId, agentAccount);
            }
        }

        public void UnRegisterAgent(Int32 agentId)
        {
            if (table.Contains(agentId))
            {
                table.Remove(agentId);
            }
        }




        //-------------------------------------------------------------------------------
        public void SetAgentAvailable(Int32 agentId, bool available)
        {
            if (table.Contains(agentId))
            {
                AgentAccount agentAccount = (AgentAccount)table[agentId];
                if (available)
                {
                    Int32 averageLoadBalanceRating = this.getAverageLoadBalanceRate();
                    agentAccount.LoadBalanceRating = averageLoadBalanceRating;
                }
                agentAccount.IsAvailable = available;
            }
        }


        //-------------------------------------------------------------------------------
        public void SetAgentBusy(Int32 agentId, bool busy)
        {
            if (table.Contains(agentId))
            {
                AgentAccount agentAccount = (AgentAccount)table[agentId];

                //if (agentAccount.IsAvailable)
                //{

                bool isOccupied = false;
                if (!busy)
                {
                    IncidentDS.IncidentDSDataTable dt = BllProxyIncident.GetIncidentsByStatus(2, agentId);   //2:In-Progress

                    if (dt.Rows.Count != 0)
                    {
                        isOccupied = true;
                    }
                }


                //    if (isOccupied)
                //    {
                //        agentAccount.IsBusy = false;
                //    }
                //    else
                //    {
                //        agentAccount.IsBusy = true;
                //    }
                //    agentAccount.IncidentId = 0;
                //}


                if (isOccupied)
                    agentAccount.IsBusy = true;
                else
                    agentAccount.IsBusy = busy;


                agentAccount.IncidentId = 0;

            }
        }



















        //-------------------------------------------------------------------------------
        public void ReleaseIncident(Int32 incidentId)
        {
            foreach (AgentAccount agent in table.Values)
            {
                if (agent.IncidentId == incidentId)
                {
                    agent.IncidentId = 0;
                }
            }
        }


        public void CountIncrease(Int32 agentId)
        {
            if (table.Contains(agentId))
            {
                AgentAccount agentAccount = (AgentAccount)table[agentId];
                agentAccount.LoadBalanceRating++;
            }
        }



        public void DoRoutine()
        {

            this.cleanUp();

            this.checkReservations();

            this.handleIncidentQueue();

        }
























        //=========================================================================

        protected Int32 getAverageLoadBalanceRate()
        {
            Int32 num = 0;
            Int32 sum = 0;

            foreach (AgentAccount agent in table.Values)
            {
                if (agent.IsAvailable)
                {
                    sum += agent.LoadBalanceRating;
                    num++;
                }
            }

            Int32 result = 0;
            if(num != 0)
                result = sum / num;

            return result;
        }














        protected void handleIncidentQueue()
        {
            IncidentDS.IncidentDSDataTable dt;

            DataTable dt0 = convertToDataset(table);
            DataRow[] rows = dt0.Select("", "rating");

            foreach (DataRow agentRow in rows)
            {
                int rating = Convert.ToInt32(agentRow["rating"]);

                Int32 agentId = Convert.ToInt32(agentRow["agent_id"]);
                AgentAccount agentAccount = this.GetAgent(agentId);


                if ((agentAccount.IsAvailable) && (!agentAccount.IsBusy))
                {
                    dt = BllProxyIncident.GetIncidentQueueList(1, agentAccount.AgentId);   //1:New

                    foreach (IncidentDS.IncidentDSRow rowIncident in dt)
                    {
                        if (rowIncident.Isreserved_agent_idNull())
                        {
                            Int32 incidentId = rowIncident.incident_id;
                            BllProxyIncidentHelper.SetIncidentReservation(incidentId, agentAccount.AgentId);

                            agentAccount.Reserve();
                            agentAccount.IsBusy = true;
                            agentAccount.IncidentId = incidentId;

                            break;
                        }

                        //---
                    }
                }
            }
        }

        protected void checkReservations()
        {

            Hashtable tableToClear = new Hashtable();


            foreach (AgentAccount agent in table.Values)
            {


                if (agent.HasIncident)
                {
                    TimeSpan max = new TimeSpan(0, 0, 15);

                    if (TimeSpan.Compare(agent.Reserved, max) > 0)
                    {
                        Int32 incidentId = agent.IncidentId;
                        Int32 incidentStatusId = BllProxyIncidentHelper.GetIncidentStatus(incidentId);

                        if (incidentStatusId == 1)
                        {
                            BllProxyIncidentHelper.SetIncidentReservation(incidentId, 0);
                            agent.IsBusy = false;

                            tableToClear.Add(agent.AgentId, null);
                        }


                    }
                }

            }




            foreach (Int32 agentId in tableToClear.Keys)
            {
                //this.UnRegisterAgent(agentId);
                this.SetAgentAvailable(agentId, false);
            }

        }

        protected void cleanUp()
        {
            Hashtable tableToClear = new Hashtable();

            foreach (AgentAccount agent in table.Values)
            {
                if (agent.IsExpired)
                {
                    tableToClear.Add(agent.AgentId, null);
                }
            }


            foreach (Int32 agentId in tableToClear.Keys)
            {
                this.UnRegisterAgent(agentId);
            }
        }

        public Int32 Count
        {
            get
            {
                return table.Count;
            }
        }







        //------------------------------------------------
        protected DataTable convertToDataset(Hashtable tbl)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("agent_id", typeof(Int32));
            dt.Columns.Add("rating", typeof(Int32));


            long ticks = DateTime.Now.Ticks;



            string s = ticks.ToString();
            string ss = TextHelper.Right(s, 8);

            int seed = Convert.ToInt32(TextHelper.Right(s, 8));
            Random rnd = new Random(seed);
            


            Int32 i = 0;
            foreach (AgentAccount agent in tbl.Values)
            {
                DataRow row = dt.NewRow();



                int c0 = rnd.Next(0, 1000);
                int c1 = agent.LoadBalanceRating;
                


                int sortIndex = c1;
                //int sortIndex = c0 + c1 + c2;



                row["agent_id"] = agent.AgentId;
                row["rating"] = sortIndex;

                dt.Rows.Add(row);

                i++;
            }


            return dt;
        }


    }




}
