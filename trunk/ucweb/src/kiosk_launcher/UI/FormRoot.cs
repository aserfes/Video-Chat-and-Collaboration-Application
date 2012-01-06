using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KioskLauncher.UI
{
	partial class FormRoot : Form, Model.Root.IListener
	{
		Model.Root ctx;

		Delegate f_refresh;
		Delegate f_close;
		Delegate f_call;
		Delegate f_data;
		//Delegate f_login;

		internal FormRoot( Model.Root ctx )
		{
			f_refresh = new MethodInvoker( RefreshControls );
			f_close = new MethodInvoker( Close );
			f_call = new MethodInvoker( Launch );
			f_data = new MethodInvoker( InitControls );
			//f_login = new MethodInvoker( LoginComplete );
			this.ctx = ctx;
			InitializeComponent();
		}

		public void OnRefreshAsync()
		{
			BeginInvoke( f_refresh );
		}

		public void OnCloseAsync()
		{
			BeginInvoke( f_close );
		}

		public void OnCallAsync()
		{
			BeginInvoke( f_call );
		}

		public void OnDataAsync()
		{
			BeginInvoke( f_data );
		}

		//public void OnLoginAsync()
		//{
		//    BeginInvoke( f_login );
		//}

		void InitComboBox( string id, ComboBox cb )
		{
			cb.Items.Clear();
			object[] list = ctx.GetItemList( id );
			if( list == null || list.Length == 0 ) return;
			
			cb.Items.AddRange( list );
			cb.SelectedIndex = 0;
		}

		void InitControls()
		{
			InitComboBox( Model.Parameter.GROUP_ID, cb_group );
			InitComboBox( Model.Parameter.LANGUAGE_ID, cb_language );
			InitComboBox( Model.Parameter.SKILL_ID, cb_skill );
		}

		void RefreshControls()
		{
			bool is_online = ctx.IsOnline();

			tsmi_launch.Enabled = is_online;
			tsmi_status.Enabled = is_online;

			cb_group.Enabled = is_online;
			cb_language.Enabled = is_online;
			cb_skill.Enabled = is_online;
			tb_id.Enabled = is_online;
			tb_name.Enabled = is_online;
			tb_location.Enabled = is_online;
			tb_user.Enabled = is_online;

			tb_log.Text = ctx.GetLog();
			tb_log.Select( tb_log.TextLength, 0 );
			tb_log.ScrollToCaret();
		}

		void Launch()
		{
			Dictionary<string, string> data = new Dictionary<string, string>();
			data[ Model.Parameter.KIOSK_ID ] = tb_id.Text;
			data[ Model.Parameter.KIOSK_NAME ] = tb_name.Text;
			data[ Model.Parameter.KIOSK_LOCATION ] = tb_location.Text;
			data[ Model.Parameter.KIOSK_USER ] = tb_user.Text;
			data[ Model.Parameter.LANGUAGE_ID ] = cb_language.Text;
			data[ Model.Parameter.SKILL_ID ] = cb_skill.Text;
			data[ Model.Parameter.GROUP_ID ] = cb_group.Text;
			ctx.Launch( data );
		}

		//void LoginComplete()
		//{
		//}

		void tsmi_login_Click( object sender, EventArgs e )
		{
			DlgLogin dlg = new DlgLogin();
			if( DialogResult.OK != dlg.ShowDialog( this ) ) return;

			ctx.BeginLogin( dlg.GetName(), dlg.GetPassword() );
		}

		void tsmi_launch_Click( object sender, EventArgs e )
		{
			Launch();
		}

		void tsmi_status_Click( object sender, EventArgs e )
		{
			DlgStatus dlg = new DlgStatus( ctx.GetFacilityStatus() );
			if( DialogResult.OK != dlg.ShowDialog( this ) ) return;

			ctx.SetFacilityStatus( dlg.GetValue() );
		}

		void FormRoot_FormClosing( object sender, FormClosingEventArgs e )
		{
			if( ctx.IsDestroyed() ) return;

			ctx.Stop();
			e.Cancel = true;
		}

		private void FormRoot_Load( object sender, EventArgs e )
		{
			ctx.Start( this );
		}
	}
}
