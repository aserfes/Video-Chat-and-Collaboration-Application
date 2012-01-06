using System;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Diagnostics;
using UCENTRIK.LIB.BllProxy;

namespace UCENTRIK.Helpers
{
    public class AudioUploadHelper
    {
		public static string SOURCE_FACILITY = "facility";
		public static string SOURCE_CALLCENTER = "callcenter";
		private static string FOLDER_NAME = "AudioRecords";

		public static void StartUploadInNewWindow( Page page, int id_incident, string source )
		{
			string script = string.Format
				( "PopupDown('{0}?id={1}&by={2}&file={3}', '_blank', 200, 100);"
				, page.ResolveClientUrl( "~/dirCommon/AsyncUploadFile.aspx" )
				, id_incident
				, source
				, GetFileName( id_incident, source )
				);

			ScriptManager.RegisterClientScriptInclude( page, page.GetType(), "common", page.ResolveClientUrl( "~/dirJavascript/common.js" ) );
			ScriptManager.RegisterClientScriptBlock( page, page.GetType(), "AsyncUploadFile", script, true );
		}

		public static string GetFileName( int id_incident, string source )
		{
			return string.Format( "{1}{0}.mp3", id_incident, source );
		}

		public static string GetAudioLinkName( int id_incident, bool callcenter, bool facility, bool merged )
		{
			if( !callcenter && !facility && !merged ) return "N/A";

			return string.Format
				( "{1}{0}.mp3"
				, id_incident
				, merged ? string.Empty : callcenter ? SOURCE_CALLCENTER : SOURCE_FACILITY
				);
		}

		public static string GetAudioLink( int id_incident, bool callcenter, bool facility, bool merged )
		{
			if( !callcenter && !facility && !merged ) return string.Empty;

			return string.Format
				( "~/{0}/{2}{1}.mp3"
				, FOLDER_NAME
				, id_incident
				, merged ? string.Empty : callcenter ? SOURCE_CALLCENTER : SOURCE_FACILITY
				);
		}

		public static void ProcessUpload( HttpRequest request )
		{
			string upload_id = request.Headers[ "UploadId" ];
			string upload_by = request.Headers[ "UploadBy" ];

			if( string.IsNullOrEmpty( upload_id ) || string.IsNullOrEmpty( upload_by ) )
				return; // error???

			int id_incident;
			int.TryParse( upload_id, out id_incident );

			string name = GetFileName( id_incident, upload_by );

			string folder = Path.Combine( request.PhysicalApplicationPath, FOLDER_NAME );
			Directory.CreateDirectory( folder );

			request.SaveAs( Path.Combine( folder, name ), false );

			bool complete = false;
			BllProxyLog.UpdateAudio( id_incident, upload_by == SOURCE_CALLCENTER ? 1 : 2, ref complete );

			if( !complete ) return;

			ProcessStartInfo psi = new ProcessStartInfo();
			psi.UseShellExecute = false;
			psi.CreateNoWindow = true;

			psi.WorkingDirectory = folder;
			psi.FileName = System.Configuration.ConfigurationManager.AppSettings[ "path.GStreamer" ];

			psi.Arguments = string.Format
				( "-v adder name=mux ! lamemp3enc ! filesink location={0}.mp3 {{ filesrc location={1}{0}.mp3 ! queue ! decodebin ! audioconvert ! audioresample ! queue ! mux. }} {{ filesrc location={2}{0}.mp3 ! queue ! decodebin ! audioconvert ! audioresample ! queue ! mux. }}"
				, id_incident
				, SOURCE_CALLCENTER
				, SOURCE_FACILITY
				);

			Process process = Process.Start( psi );
			process.WaitForExit();

			if( process.ExitCode == 0 )
			{
				BllProxyLog.UpdateAudio( id_incident, 3, ref complete );
			}
		}
    }
}