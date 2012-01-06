using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UCENTRIK.DATASETS;
using UCENTRIK.LIB.BllProxy;
using UCENTRIK.Membership;
using System.Configuration;

namespace UCENTRIK.WEB.KIOSK
{
	/// <summary>
	/// Summary description for entry
	/// </summary>
	[WebService( Namespace = "http://tempuri.org/" )]
	[WebServiceBinding( ConformsTo = WsiProfiles.BasicProfile1_1 )]
	[System.ComponentModel.ToolboxItem( false )]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class entry : System.Web.Services.WebService
	{
		static string[] map_name = new string[]
			{ "scrp.timer_span"
			, "TimerSpan"
			, "CTX_SERVER"
			, "scrp.dif_frame_count"
			, "DifFrameCount"
			, "CTX_SERVER"
			};

		int stamp_max_ms;
		string[] settings = new string[]
			{ ".facility.url"
			, null
			//, "server.host"
			//, null
			//, "server.port"
			//, null
			//, "server.port_ssl"
			//, null
			//, "server.port_http"
			//, null
			, ".facility.status.timeout_ms"
			, null
			//, ".facility.status_stamp_max_ms"
			//, null
			, "scrp.timer_span"
			, null
			, "scrp.dif_frame_count"
			, null
			, "protocol.purpose"
			, "2"
			, "protocol.is_master"
			, "1"
			, "id.user"
			, "1"
			, "id.other"
			, "2"
			, "scrp.type_pixel"
			, "1"
			, "autodetect_sequence"
			, "tcp; tcp socks4 config; tcp socks5 config; tcp http_proxy config; http_tunnel; http_tunnel socks4 config; http_tunnel socks5 config; http_tunnel http_proxy config;"
			};

		public entry()
		{
			int.TryParse( ConfigurationManager.AppSettings[ "facility.status_stamp_max_ms" ], out stamp_max_ms );

			//string server = ProxyHelper.GetSettingValueString( "Server", "CTX_SERVER" );
			//string[] ss = server.Split( ':' );

			//settings[ 3 ] = ss[ 0 ];
			//settings[ 5 ] = ss[ 1 ];
			//settings[ 7 ] = ss[ 2 ];
			//settings[ 9 ] = ss[ 3 ];

			settings[ 3 ] = ConfigurationManager.AppSettings[ "facility.status.timeout_ms" ];

			for( int i = 0; i < settings.Length; i += 2 )
			{
				if( settings[ i + 1 ] != null ) continue;

				for( int j = 0; j < map_name.Length; j += 3 )
				{
					if( map_name[ j ] != settings[ i ] ) continue;

					settings[ i + 1 ] = ProxyHelper.GetSettingValueString( map_name[ j + 1 ], map_name[ j + 2 ] );
				}
			}
		}

		[WebMethod]
		public string[] GetSettings()
		{
			if( settings[ 1 ] == null )
			{
				Uri uri = HttpContext.Current.Request.Url;
				settings[ 1 ] = string.Format
					( "{0}://{1}:{2}{3}"
					, uri.Scheme
					, uri.Host
					, uri.Port
					, VirtualPathUtility.ToAbsolute( ConfigurationManager.AppSettings[ "facility.url" ] )
					);
			}
			return settings;
		}

		[WebMethod]
		public string[] GetLanguages()
		{
			LanguageDS.LanguageDSDataTable dt = BllProxyLanguage.GetLanguageList( 0 );
			string[] ret = new string[ dt.Rows.Count * 2 ];
			int ret_i = 0;
			for( int i = 0; i < dt.Rows.Count; i++ )
			{
				LanguageDS.LanguageDSRow row = dt[ i ];
				ret[ ret_i++ ] = row.language_id.ToString();
				ret[ ret_i++ ] = row.language_name;
			}
			return ret;
		}

		[WebMethod]
		public string[] GetSkills()
		{
			SkillDS.SkillDSDataTable dt = BllProxySkill.GetSkillList( 0 );
			string[] ret = new string[ dt.Rows.Count * 2 ];
			int ret_i = 0;
			for( int i = 0; i < dt.Rows.Count; i++ )
			{
				SkillDS.SkillDSRow row = dt[ i ];
				ret[ ret_i++ ] = row.skill_id.ToString();
				ret[ ret_i++ ] = row.skill_name;
			}
			return ret;
		}

		[WebMethod]
		public string[] GetFacilityGroups( int facility_id )
		{
			FacilityDS.FacilityGroupDSDataTable dt = BllProxyFacilityGroup.GetFacilityGroupsByFacility( facility_id );
			string[] ret = new string[ dt.Rows.Count * 2 ];
			int ret_i = 0;
			for( int i = 0; i < dt.Rows.Count; i++ )
			{
				FacilityDS.FacilityGroupDSRow row = dt[ i ];
				ret[ ret_i++ ] = row.group_id.ToString();
				ret[ ret_i++ ] = row.group_name;
			}
			return ret;
		}

		[WebMethod]
		public void Login( string name, string pwd, out int facility_id )
		{
			facility_id = 0;

			UserAccount account = new UserAccount( name );
			if( !account.IsValid( name, pwd ) )
				return;

			FacilityDS.FacilityDSDataTable dt = BllProxyFacility.GetFacilityByUser( account.UserId );
			if( dt.Rows.Count == 0 ) return;

			facility_id = dt[ 0 ].facility_id;
		}

		[WebMethod]
		public void SetStatus
			( int facility_id
			, string status
			, out string command
			, out int agent_id
			)
		{
			agent_id = 0;
			command = null;
			BllProxyFacility.SetStatus( facility_id, status, stamp_max_ms, ref command, ref agent_id );
		}
	}
}
