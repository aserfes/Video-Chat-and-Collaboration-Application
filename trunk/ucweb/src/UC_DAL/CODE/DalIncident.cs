using System;
using System.Data;
using System.Data.SqlClient;

using UCENTRIK.DATASETS;
using UCENTRIK.DATASETS.IncidentDSTableAdapters;



namespace UCENTRIK.DAL
{


    public class DalIncident
    {

        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentDSDataTable OpenIncident(Int32 incidentId, Int32 agentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Open(incidentId, agentId);
        }

        public static IncidentDS.IncidentDSDataTable OpenFollowUpIncident(Int32 incidentId, Int32 agentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.OpenFollowUp(incidentId, agentId);
        }



        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentDSDataTable GetIncidentsByStatus(Int32 statusId, Int32 agentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetIncidentsByStatus(statusId, agentId);
        }

        public static IncidentDS.IncidentDSDataTable GetIncidentsByContact(Int32 statusId, Int32 contactId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetIncidentsByContact(statusId, contactId);
        }




        public static IncidentDS.IncidentDSDataTable GetIncidentQueueList(Int32 statusId, Int32 agentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetIncidentQueueList(statusId, agentId);
        }



        public static IncidentDS.IncidentDSDataTable GetIncidentFollowUpList(Int32 statusId, Int32 agentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetIncidentFollowUpList(statusId, agentId);
        }





        public static IncidentDS.IncidentDSDataTable SelectIncident(Int32 incidentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(incidentId);
        }

        public static IncidentDS.IncidentDSDataTable GetIncidentByGuid(Guid incidentGuid)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetIncidentByGuid(incidentGuid);
        }






        public static Int32 InsertIncident(Int32 groupId, Int32 skillId, Int32 langId, Int32 facilityId, Int32 contactId, Int32 agentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> group_id = Helper.ResolveEmptyInt(groupId);
            System.Nullable<Int32> skill_id = Helper.ResolveEmptyInt(skillId);
            System.Nullable<Int32> lang_id = Helper.ResolveEmptyInt(langId);
            System.Nullable<Int32> facility_id = Helper.ResolveEmptyInt(facilityId);
            System.Nullable<Int32> contact_id = Helper.ResolveEmptyInt(contactId);
            System.Nullable<Int32> agent_id = Helper.ResolveEmptyInt(agentId);



            int id = Convert.ToInt32(ta.InsertIncident(group_id, skill_id, lang_id, facility_id, contact_id, agent_id));
            return id;
        }


        public static Int32 UpdateIncident(Int32 incidentId, Int32 contactId, Int32 agentId, Int32 statusId, string subject)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;


            System.Nullable<Int32> contact_id = Helper.ResolveEmptyInt(contactId);
            System.Nullable<Int32> agent_id = Helper.ResolveEmptyInt(agentId);



            return ta.Update(incidentId, contact_id, agent_id, statusId, subject);
        }


        public static Int32 DeleteIncident(Int32 incidentId)
        {
            IncidentDSTableAdapter ta = new IncidentDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(incidentId);
        }

    }



    public class DalIncidentState
    {
        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentStateDSDataTable SelectIncidentState(Int32 incidentId)
        {
            IncidentStateDSTableAdapter ta = new IncidentStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(incidentId);
        }

        public static void InsertIncidentState(Int32 incidentId, bool isActive, string state)
        {
            IncidentStateDSTableAdapter ta = new IncidentStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            ta.Insert(incidentId, isActive, state);
        }

        public static Int32 UpdateIncidentState(Int32 incidentId, bool isActive, string state)
        {
            IncidentStateDSTableAdapter ta = new IncidentStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.Update(incidentId, isActive, state);
        }




        public static IncidentDS.IncidentStateDSDataTable SetIncidentState0(Int32 incidentId, Int32 periodToUpdate)
        {
            IncidentStateDSTableAdapter ta = new IncidentStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.SetIncidentState0(incidentId, periodToUpdate);
        }
        public static IncidentDS.IncidentStateDSDataTable SetIncidentState1(Int32 incidentId, Int32 periodToUpdate)
        {
            IncidentStateDSTableAdapter ta = new IncidentStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            return ta.SetIncidentState1(incidentId, periodToUpdate);
        }





        public static Int32 DeleteIncidentState(Int32 incidentId)
        {
            IncidentStateDSTableAdapter ta = new IncidentStateDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(incidentId);
        }
    }




    public class DalIncidentNote
    {
        //-----------------------------------------------------------------------------

        public static IncidentDS.IncidentNoteDSDataTable SelectIncidentNote(Int32 noteId)
        {
            IncidentNoteDSTableAdapter ta = new IncidentNoteDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetData(noteId);
        }


        public static IncidentDS.IncidentNoteDSDataTable GetAllIncidentNotes(Int32 incidentId)
        {
            IncidentNoteDSTableAdapter ta = new IncidentNoteDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.GetAllIncidentNotes(incidentId);
        }


        public static void InsertIncidentNote(Int32 incidentId, Int32 userId, string note)
        {
            IncidentNoteDSTableAdapter ta = new IncidentNoteDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;

            ta.Insert(incidentId, userId, note);
        }


        public static Int32 DeleteIncidentNote(Int32 noteId)
        {
            IncidentNoteDSTableAdapter ta = new IncidentNoteDSTableAdapter();
            ta.Connection.ConnectionString = UcConnection.ConnectionString;
            return ta.Delete(noteId);
        }
    }





    //==============================================================================
    public class DalIncidentHelper
    {
        private static string connectionString = UcConnection.ConnectionString;




        public static Int32 GetIncidentStatus(Int32 incidentId)
        {
            Int32 result = 0;
            string commandString = "usp_incident_status_get";

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@incident_id", SqlDbType.Int).Value = incidentId;

                    connection.Open();
                    result = Convert.ToInt32(command.ExecuteScalar());

                }
            }

            return result;
        }


        public static void SetIncidentStatus(Int32 incidentId, Int32 statusId)
        {
            string commandString = "usp_incident_status_set";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@incident_id", SqlDbType.Int).Value = incidentId;
                    command.Parameters.Add("@status_id", SqlDbType.Int).Value = statusId;

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }


        public static void SetIncidentSubject(Int32 incidentId, Int32 statusId, string subject)
        {
            string commandString = "usp_incident_subject_set";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@incident_id", SqlDbType.Int).Value = incidentId;
                    command.Parameters.Add("@status_id", SqlDbType.Int).Value = statusId;
                    command.Parameters.Add("@subject", SqlDbType.NVarChar, 100).Value = subject;

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }





        public static void SetIncidentReservation(Int32 incidentId, Int32 reservedAgentId)
        {
            string commandString = "usp_incident_reservation_set";


            System.Nullable<Int32> reserved_agent_id = Helper.ResolveEmptyInt(reservedAgentId);




            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@incident_id", SqlDbType.Int).Value = incidentId;
                    command.Parameters.Add("@reserved_agent_id", SqlDbType.Int).Value = reserved_agent_id;

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }


        public static void SetIncidentConnectCount(Int32 incidentId)
        {
            string commandString = "usp_incident_connect_update";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@incident_id", SqlDbType.Int).Value = incidentId;

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
        }







        public static void TransferIncident(Int32 userId, Int32 incidentId, Int32 statusId, Int32 fromAgentId, Int32 toAgentId)
        {
            string commandString = "usp_incident_transfer";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = commandString;
                    command.Parameters.Add("@incident_id", SqlDbType.Int).Value = incidentId;
                    command.Parameters.Add("@status_id", SqlDbType.Int).Value = statusId;
                    command.Parameters.Add("@user_id", SqlDbType.Int).Value = userId;
                    command.Parameters.Add("@from_agent_id", SqlDbType.Int).Value = fromAgentId;
                    command.Parameters.Add("@to_agent_id", SqlDbType.Int).Value = toAgentId;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }


    }





}
