using System;
//using System.Collections.Generic;
using System.Web;
//using System.Web.UI;
using System.Web.UI.WebControls;
using UCENTRIK.LIB.BllProxy;
using System.Text;
using UCENTRIK.LIB.Base;
using UCENTRIK.DATASETS;


namespace UCENTRIK.WEB.PLATFORM.dirAgent
{
	public partial class scrs : UcBasePage//System.Web.UI.Page
	{
		protected string[] settings = new string[]
			{ "id.conference"
			, null
			, "server.host"
			, null
			, "server.port"
			, null
			, "server.port_ssl"
			, null
			, "server.port_http"
			, null
			, "id.user"
			, "2"
			, "id.other"
			, "1"
			, "protocol.is_master"
			, "0"
			, "protocol.purpose"
			, "2"
			//, "scrp.device"
			//, ""
			};

		protected string uctx_cab;
		protected string error;
		protected string name;
		protected int facility_id;

		protected void Page_Load( object sender, EventArgs e )
		{
			if( this.IsPostBack ) return;

			uctx_cab = System.Configuration.ConfigurationManager.AppSettings[ "uctx.cab" ];

			string fid = Request[ "id" ];
			int.TryParse( fid, out facility_id );

			if( Request[ "release" ] != null )
			{
				BllProxyFacility.SetCommand( facility_id, 0, null );
				Response.Redirect( "../close.htm" );
				return;
			}

			int agent_id = ProxyHelper.GetUserAgentId( this.UserId );

			FacilityDS.FacilityDSDataTable dt = BllProxyFacility.SelectFacility( facility_id );
			if( dt.Rows.Count == 0 )
			{
				error = "Failed to view facility screen";
				return;
			}

			FacilityDS.FacilityDSRow row = dt[ 0 ];

			int id = row.agent_id;
			if( id != 0 && id != agent_id )
			{
				error = "Failed to view facility screen";
				return;
			}

			name = row.facility_name;

			settings[ 1 ] = fid;

			string server = ProxyHelper.GetSettingValueString( "Server", "CTX_SERVER" );
			if( string.IsNullOrEmpty( server ) )
			{
				error = "Configuration failed";
				return;
			}

			string[] ss = server.Split( ':' );
			if( ss.Length != 4 )
			{
				error = "Configuration failed";
				return;
			}

			settings[ 3 ] = ss[ 0 ];
			settings[ 5 ] = ss[ 1 ];
			settings[ 7 ] = ss[ 2 ];
			settings[ 9 ] = ss[ 3 ];

			BllProxyFacility.SetCommand( facility_id, agent_id, "rscr\n" + server );
		}

		protected string SetSettings
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				for( int i = 0; i < settings.Length; i += 2 )
					sb.Append( string.Format( "\r\n\t\t\t\t{0} \"\\n.Set {1}={2}\"", i == 0 ? "(" : "+", settings[ i ], settings[ i + 1 ] ) );
				return sb.ToString();
			}
		}
	}
}