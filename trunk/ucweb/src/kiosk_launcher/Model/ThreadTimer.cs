using System;
using System.Threading;

namespace KioskLauncher.Model
{
	class ThreadTimer
	{
		static readonly log4net.ILog ___log =
			log4net.LogManager.GetLogger( typeof( ThreadTimer ).ToString() );

		Thread thread;
		EventWaitHandle event_wait;
		int timeout;

		internal interface IListener
		{
			void OnStart( ThreadTimer ctx );
			void OnStop( ThreadTimer ctx );
			void OnTimer( ThreadTimer ctx );
		}

		IListener listener;

		internal ThreadTimer()
		{
			timeout = -1;
			event_wait = new EventWaitHandle( false, EventResetMode.ManualReset );
		}

		void Internal()
		{
			___log.Debug( "Start" );

			try
			{
				listener.OnStart( this );

				for( ; ; )
				{
					listener.OnTimer( this );
					if( event_wait.WaitOne( timeout ) )
					{
						if( thread == null ) break;
						event_wait.Reset();
					}
				}

				listener.OnStop( this );
			}
			catch( Exception e )
			{
				___log.Fatal( null, e );
			}

			listener = null;
			thread = null;

			___log.Debug( "Stop" );
		}

		internal void SetTimeout( int timeout )
		{
			this.timeout = timeout;
		}

		internal void Start( IListener listener )
		{
			if( this.listener != null ) return; //???

			this.listener = listener;
			event_wait.Reset();

			//___log.Debug( "starting thread" );
	
			thread = new Thread( new ThreadStart( Internal ) );
			//thread.SetApartmentState( ApartmentState.STA );
			thread.Start();
			
			//___log.Debug( "starting thread complete" );
		}

		internal void Stop()
		{
			thread = null;
			event_wait.Set();
		}

		internal void Touch()
		{
			event_wait.Set();
		}
	}
}
