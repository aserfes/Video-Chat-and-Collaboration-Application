using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace KioskLauncher.Model
{
	class Root
		: ThreadTimer.IListener
		, UCTX.IListener
	{
		static readonly log4net.ILog ___log =
			log4net.LogManager.GetLogger( typeof( Root ).ToString() );

		internal interface IListener
		{
			void OnDataAsync();
			void OnRefreshAsync();
			void OnCloseAsync();
			void OnCallAsync();
		}

		IListener listener;
		//bool is_stop_called;

		Dictionary<string, string> settings;

		Service service = new Service();
		ThreadTimer timer = new ThreadTimer();
		UCTX uctx = new UCTX();

		UCTX.Status uctx_status;
		Service.Internal service_data;
		bool is_timer_active;

		StringBuilder log = new StringBuilder();

		string name;
		string pwd;

		const string STATUS_OFF = "off";
		const string STATUS_ONLINE = "online";
		const string STATUS_DESTROYED = "destroyed";
		string status;
		internal bool IsDestroyed() { return status == STATUS_DESTROYED; }
		internal bool IsOnline() { return status == STATUS_ONLINE; }

		internal Root( Dictionary<string, string> settings )
		{
			this.settings = settings;
			status = STATUS_OFF;
		}

		internal void Start( IListener listener )
		{
			this.listener = listener;
			timer.Start( this );
		}

		internal void Stop()
		{
			___log.Debug( "Stop" );
			if( status == STATUS_DESTROYED ) return;

			timer.Stop();
			uctx.Stop();
			//is_stop_called = true;
		}

		void InternalStop() // thread:any
		{
			if( is_timer_active ) return;
			if( uctx_status.root != null && uctx_status.root != UCTX.STATUS_DESTROYED ) return;

			status = STATUS_DESTROYED;
			
			listener.OnCloseAsync();
		}

		public void OnStart( ThreadTimer ctx ) // thread:timer
		{
			is_timer_active = true;
		}

		public void OnStop( ThreadTimer ctx ) // thread:timer
		{
			is_timer_active = false;
			InternalStop();
		}

		public void OnTimer( ThreadTimer ctx ) // thread:timer
		{
			string result;

			if( name != null )
			{
				result = service.Login( name, pwd );
				name = null;
				pwd = null;

				___log.Debug( "Login: " + result );
				Log( "Login: " + result );

				if( result == Service.RESULT_READY )
				{
					int timeout = int.Parse( service.GetSettings()[ ".facility.status.timeout_ms" ] );
					___log.Debug( "timeout: " + timeout );

					string s;
					settings.TryGetValue( "status.init", out s );
					service.SetStatus( s );
					Log( "Status: " + s );
					status = STATUS_ONLINE;
					timer.SetTimeout( timeout );
					//timer.Touch();
					listener.OnDataAsync();
				}
				else
				{
					status = STATUS_OFF;
					timer.SetTimeout( -1 );
					//timer.Stop();
				}

				listener.OnRefreshAsync();
			}

			if( status == STATUS_DESTROYED || status == STATUS_OFF ) return;

			result = service.Poll();

			service.GetData( ref service_data );

			if( result == Service.RESULT_CALL )
			{
				Log( "Request: " + result );
				//status = STATUS_CALL;
			}
			else if( result == Service.RESULT_RSCR )
			{
				Log( "Request: " + result );
				if( uctx_status.root == null || uctx_status.root == UCTX.STATUS_DESTROYED )
					uctx.Start( this, service.GetSettings(), service_data.command.Substring( Service.RESULT_RSCR.Length + 1 ) );
			}

			listener.OnRefreshAsync();

			if( result == Service.RESULT_CALL )
				listener.OnCallAsync();
		}

		public void OnRefresh( UCTX ctx ) // thread:uctx
		{
			string scrp_old = uctx_status.scrp;

			uctx.GetStatus( ref uctx_status );
			//if( scrp_old != UCTX.STATUS_ACTIVE && uctx_status.scrp == UCTX.STATUS_ACTIVE )
			//{
			//    service.SetStatusRemoteControl();
			//    timer.Touch();
			//}

			listener.OnRefreshAsync();

			if( uctx_status.root == UCTX.STATUS_DESTROYED )
			{
				InternalStop();
			}
		}

		internal void Log( string msg )
		{
			lock( log )
			{
				if( log.Length > 0 ) log.Append( "\r\n" );
				log.Append( DateTime.Now.ToString( "MM.dd hh:mm:ss" ) );
				log.Append( " " );
				log.Append( msg );
			}
		}

		internal string GetLog()
		{
			lock( log )
			{
				return log.ToString();
			}
		}

		internal void BeginLogin( string name, string pwd )
		{
			this.pwd = pwd;
			this.name = name;
			timer.Touch();
		}

		internal void Launch( Dictionary<string,string> data )
		{
			string url = service.GetSettings()[ ".facility.url" ];

			//service.SetStatusCall();
			service.UpdateParameters( data );

			foreach( string key in data.Keys )
				url = url.Replace( "{" + key + "}", data[ key ] );

			___log.Debug( "Launch: " + url );

			string pfiles = Environment.GetEnvironmentVariable( "ProgramFiles(x86)" );
			if( string.IsNullOrEmpty( pfiles ) )
				pfiles = Environment.GetFolderPath( Environment.SpecialFolder.ProgramFiles );

			string command = Path.Combine( pfiles, @"Internet Explorer\IEXPLORE.EXE" );

			string path_k_log;
			settings.TryGetValue( "path.k_log", out path_k_log );

			if( System.Environment.OSVersion.Version.Major < 6 )
			{
				System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo( command, url );
				psi.UseShellExecute = false;
				if( path_k_log != null )
					psi.EnvironmentVariables.Add( "K_LOG_DLL", path_k_log );
				System.Diagnostics.Process.Start( psi );
				return;
			}

			UtilSecurity.RunAsExplorerUser
				( command
				, "\"" + url + "\""
				, null
				, path_k_log == null ? null : new string[] { "K_LOG_DLL", path_k_log }
				);
		}

		internal string GetFacilityStatus()
		{
			return service_data.status;
		}

		internal void SetFacilityStatus( string value )
		{
			service.SetStatus( value );
			Log( "Status: " + value );
			timer.Touch();
		}

		internal object[] GetItemList( string key )
		{
			return service.GetItemList( key );
		}
	}
}
