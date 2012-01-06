using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UCENTRIK.DAL;
using UCENTRIK.DATASETS;

namespace UCENTRIK.BLL
{
    public class BllLog
    {
        public static LogDS.LogDSDataTable SelectLog(int incident_id)
        {
            return DalLog.SelectLog(incident_id);
        }

		public static void UpdateAudio( int incident_id, int audio_source, ref bool audio_complete )
        {
			DalLog.UpdateAudio( incident_id, audio_source, ref audio_complete );
        }

        public static void UpdateLog(int incidentId, string subject_notes)
        {
            DalLog.UpdateLog(incidentId, subject_notes);
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
            DalLog.InsertLog(
                incidentId, 
                consName, 
                deviceMake, 
                deviceModel, 
                deviceValue, 
                deviceType, 
                kioskID, 
                kioskName, 
                kioskLocation, 
                idCard, 
                inspectorBin, 
                driverLicense, 
                transactValue, 
                transactCompletion,
                screenUserHelp,
				server);
        }

        public static object GetImage(int incident_id, string fields)
        {
            return DalLog.GetImage(incident_id, fields);
        }
    }
}
