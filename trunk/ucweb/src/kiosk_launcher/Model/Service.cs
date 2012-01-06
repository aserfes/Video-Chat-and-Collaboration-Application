using System;
using System.Collections.Generic;
using System.Text;

namespace KioskLauncher.Model
{
	class Service
	{
		static readonly log4net.ILog ___log =
			log4net.LogManager.GetLogger( typeof( Service ).ToString() );

		WebEntry.entry ws = new WebEntry.entry();

		internal struct Internal
		{
			internal int facility_id;
			internal int agent_id;
			internal string status;
			internal string command;
			internal string name;
			internal string pwd;
		}

		Internal data;
		internal void GetData( ref Internal data ){ data = this.data; }
		internal void SetStatus( string status ){ data.status = status; }

		Dictionary<string,string> settings = new Dictionary<string,string>();
		internal Dictionary<string, string> GetSettings() { return settings; }

		string[] skills;
		string[] languages;
		string[] facility_groups;

		internal const string RESULT_FAILED = "failed";
		internal const string RESULT_READY = "ready";
		internal const string RESULT_ACCESS_DENIED = "access_denied";
		internal const string RESULT_RSCR = "rscr";
		internal const string RESULT_CALL = "call";

		void Log( string name, string[] ss )
		{
			if( ss == null ) return; // error???
			for( int i = 0; i < ss.Length; i += 2 )
				___log.Debug( string.Format( "{0}: {1}={2}", name, ss[ i ], ss[ i + 1 ] ) );
		}

		internal string Login( string name, string pwd )
		{
			try
			{
				data.name = null;
				data.pwd = null;

				data.facility_id = ws.Login( name, pwd );
				if( data.facility_id == 0 )
				{
					___log.Error( "Login" );
					return RESULT_ACCESS_DENIED;
				}

				string[] ss = ws.GetSettings();
				Log( "Settings", ss );

				settings.Clear();
				for( int i = 0; i < ss.Length; i += 2 )
					settings[ ss[ i ] ] = ss[ i + 1 ];

				settings[ "id.conference" ] = data.facility_id.ToString();

				skills = ws.GetSkills();
				Log( "Skill", skills );
				
				languages = ws.GetLanguages();
				Log( "Language", languages );

				facility_groups = ws.GetFacilityGroups( data.facility_id );
				Log( "Group", facility_groups );

				data.name = name;
				data.pwd = pwd;

				return RESULT_READY;
			}
			catch( Exception e )
			{
				___log.Error( null, e );
				return RESULT_FAILED;
			}
		}

		internal string Poll()
		{
			if( data.facility_id == 0 ) return RESULT_FAILED;

			try
			{
				___log.Debug( string.Format( "SetStatus {0}", data.status ) );

				data.command = ws.SetStatus( data.facility_id, data.status, out data.agent_id );

				___log.Debug( string.Format( "SetStatus agent={0} command={1}", data.agent_id, data.command ) );

				if( string.IsNullOrEmpty( data.command ) )
					return RESULT_READY;

				if( data.command == RESULT_CALL )
					return RESULT_CALL;

				if( data.command.StartsWith( RESULT_RSCR ) )
					return RESULT_RSCR;

				return RESULT_FAILED;
			}
			catch( Exception e )
			{
				___log.Error( null, e );
				return RESULT_FAILED;
			}
		}

		string UpdateParameter( string[] ss, string value )
		{
			for( int i = 0; i < ss.Length; i += 2 )
			{
				if( ss[ i + 1 ] != value ) continue;
				return ss[ i ];
			}
			return null;
		}

		internal void UpdateParameters( Dictionary<string, string> data )
		{
			data[ Parameter.SKILL_ID ] = UpdateParameter( skills, data[ Parameter.SKILL_ID ] );
			data[ Parameter.LANGUAGE_ID ] = UpdateParameter( languages, data[ Parameter.LANGUAGE_ID ] );
			data[ Parameter.GROUP_ID ] = UpdateParameter( facility_groups, data[ Parameter.GROUP_ID ] );
			data[ Parameter.NAME ] = this.data.name;
			data[ Parameter.PWD ] = this.data.pwd;
		}

		internal object[] GetItemList( string key )
		{
			string[] ss
				= key == Parameter.SKILL_ID ? skills
				: key == Parameter.LANGUAGE_ID ? languages
				: key == Parameter.GROUP_ID ? facility_groups
				: null
				;

			if( ss == null )
				return null;

			object[] ret = new object[ ss.Length / 2 ];

			int ret_i = 0;
			for( int i = 1; i < ss.Length; i += 2, ret_i++ )
				ret[ ret_i ] = ss[ i ];

			return ret;
		}
	}
}
