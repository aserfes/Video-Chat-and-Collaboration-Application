using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Configuration;

namespace KioskLauncher
{
	static class Program
	{
		static int LoadSection( Dictionary<string, string> data, string id )
		{
			NameValueCollection settings = ConfigurationManager.GetSection( id ) as NameValueCollection;

			for( int i = 0; i < settings.Count; i++ )
				data[ settings.GetKey( i ) ] = settings.Get( i );

			return settings.Count;
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			log4net.Config.XmlConfigurator.Configure();

			Dictionary<string, string> settings = new Dictionary<string, string>();

			LoadSection( settings, "appSettings" );
			Model.Root root = new Model.Root( settings );

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault( false );
			Application.Run( new UI.FormRoot( root ) );
		}
	}
}
