using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;

using UCENTRIK.BLL;
using UCENTRIK.DATASETS;
using UCENTRIK.AppSettings;

namespace UCENTRIK.LIB.BllProxy
{
    public class BllProxyLog
    {
        public static LogDS.LogDSDataTable SelectLog(Int32 incident_id)
        {
            return BllLog.SelectLog(incident_id);
        }

        public static object GetImage(int incident_id, string fields)
        {
            return BllLog.GetImage(incident_id, fields);
        }

		public static void UpdateAudio( int incident_id, int audio_source, ref bool audio_complete )
        {
			BllLog.UpdateAudio( incident_id, audio_source, ref audio_complete );
        }

        public static void UpdateLog(int incident_id, string subject_notes)
        {
            BllLog.UpdateLog(incident_id,subject_notes);
        }

        public static void InsertLog(int incidentId, 
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
            BllLog.InsertLog(incidentId,
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
    }
}
