using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace KioskLauncher.Model
{
	class UCTX
	{
		static readonly log4net.ILog ___log =
			log4net.LogManager.GetLogger( typeof( UCTX ).ToString() );

		internal struct Status
		{
			internal string root;
			internal string con;
			internal string scrp;
		}

		internal interface IListener
		{
			void OnRefresh( UCTX ctx );
		}

		IListener listener;

		string wye_set;
		WyeCom.Console wye_console;
		
		static Dictionary<string, MethodInfo> handlers;
		
		internal const string STATUS_ACTIVE = "active";
		internal const string STATUS_READY = "ready";
		internal const string STATUS_OFF = "off";
		internal const string STATUS_DESTROYED = "destroyed";

		Status status;
		internal void GetStatus( ref Status status ) { status = this.status; }

		static UCTX()
		{
			handlers = new Dictionary<string,MethodInfo>();

			string prefix = "handler_";

			MethodInfo[] methods = typeof( UCTX ).GetMethods( BindingFlags.Instance | BindingFlags.InvokeMethod | BindingFlags.NonPublic );
			for( int i = 0; i < methods.Length; i++ )
			{
				MethodInfo method = methods[ i ];

				if( method.Name.StartsWith( prefix ) )
					handlers[ method.Name.Substring( prefix.Length ) ] = method;
			}
		}

		internal UCTX()
		{
			status.root = STATUS_DESTROYED;
		}

		void wye_console_OnMessage( string oid, string cmd, string value )
		{
			___log.Info( string.Format( "{0}_{1}({2})", oid, cmd, value ) );

			try
			{
				MethodInfo method;
				handlers.TryGetValue( string.Format( "{0}_{1}", oid, cmd ), out method );
				if( method != null )
					method.Invoke( this, new object[] { value } );
			}
			catch( Exception e )
			{
				___log.Error( null, e );
			}
		}

		internal void Start( IListener listener, Dictionary<string, string> settings, string server )
		{
			this.listener = listener;
			wye_console = new WyeCom.ConsoleClass();
			wye_console.OnMessage += new WyeCom._IConsoleEvents_OnMessageEventHandler( wye_console_OnMessage );

			StringBuilder sb = new StringBuilder();
			foreach( string key in settings.Keys )
			{
				if( key.StartsWith( "." ) ) continue;

				sb.Append( "\n.Set " );
				sb.Append( key );
				sb.Append( '=' );
				sb.Append( settings[ key ] );
			}

			string[] ss = server.Split( ':' );
			sb.Append( "\n.Set server.host=" );
			sb.Append( ss[ 0 ] );
			sb.Append( "\n.Set server.port=" );
			sb.Append( ss[ 1 ] );
			sb.Append( "\n.Set server.port_ssl=" );
			sb.Append( ss[ 2 ] );
			sb.Append( "\n.Set server.port_http=" );
			sb.Append( ss[ 3 ] );

			wye_set = sb.ToString();

			wye_console.Execute( "\n.Start" );
		}

		internal void Stop()
		{
			if( wye_console != null )
				wye_console.Execute( "\n.Destroy" );
		}

		void handler__OnStatusChanged( string value )
		{
			status.root = value;

			if( value == STATUS_READY )
			{
				wye_console.Execute
					( "\n.Set send.size=4000000"
					+ "\n.Set scrp.timer_span=400"
					+ "\n.Set scrp.id.channel=1"
					+ "\n.Set scrp.type_pixel=1"
					+ wye_set
					+ "\n.New con=Connection"
					);
			}
			listener.OnRefresh( this );
		}

		void handler_con_OnStatusChanged( string value )
		{
			string old_value = status.con;
			status.con = value;

			if( old_value == null && value == STATUS_OFF )
			{
				wye_console.Execute
					( "\ncon.Start"
					);
			}

			if( value == STATUS_ACTIVE )
			{
				wye_console.Execute
					( "\ncon.New scrp=ScreenPublisher"
					);
			}
			listener.OnRefresh( this );
		}

		void handler_con_OnEvent( string value )
		{
			if( value == "P" )
				wye_console.Execute( "\n#scrp.ControlBy {id.other}" );
			else if( value == "p" )
				wye_console.Execute( "\n#scrp.ControlBy {id.user}" );
		}

		void handler_scrp_OnStatusChanged( string value )
		{
			string old_value = status.scrp;
			status.scrp = value;
			if( old_value == null && value == STATUS_OFF )
			{
				wye_console.Execute
					( "\nscrp.Start"
					);
			}
			listener.OnRefresh( this );
		}
	}

}
