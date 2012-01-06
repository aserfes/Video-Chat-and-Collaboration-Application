using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCENTRIK.DATASETS.LogDSTableAdapters;
using UCENTRIK.DATASETS;

namespace UCENTRIK.DAL
{
    public class DalLog
    {
        public static LogDS.LogDSDataTable SelectLog(int incident_id)
        {
            LogDSTableAdapter ta = new LogDSTableAdapter();
            return ta.GetData(incident_id);
        }

        public static void UpdateAudio(int incident_id, int audio_source, ref bool audio_complete)
        {
            LogDSTableAdapter ta = new LogDSTableAdapter();
			bool? value = false;
            ta.UpdateAudio(incident_id, audio_source, ref value );
			audio_complete = value.GetValueOrDefault();
        }

        public static void UpdateLog(int incidentId, string subject_notes)
        {
            LogDSTableAdapter ta = new LogDSTableAdapter();
            ta.UpdateAgentInfo(incidentId, subject_notes);
        }

        public static void InsertLog(
            int incidentId, 
            string consName, 
            string deviceMake, 
            string deviceModel, 
            int deviceValue, 
            string deviceType, 
            string kioskID, 
            string kioskName, 
            string kioskLocation, 
            byte[] idCard, 
            byte[] inspectorBin, 
            byte[] driverLicense, 
            string transactValue, 
            bool transactCompletion,
            string screenUserHelp,
			string server)
        {
            LogDSTableAdapter ta = new LogDSTableAdapter();
            ta.Insert(
                incidentId, 
                consName, 
                transactValue, 
                transactCompletion, 
                null, 
                null, 
                false, 
                null, 
                kioskID, 
                kioskName, 
                kioskLocation, 
                false, 
                null, 
                deviceValue, 
                deviceType, 
                deviceMake, 
                deviceModel, 
                null, 
                driverLicense, 
                idCard, 
                inspectorBin, 
                0, 
                null,
                screenUserHelp,
				server);
        }

        public static object GetImage(int incident_id, string fields)
        {
            LogDSTableAdapter ta = new LogDSTableAdapter();
            return ta.GetImage(incident_id, fields);
        }
    }
}
