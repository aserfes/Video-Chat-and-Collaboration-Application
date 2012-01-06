using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KioskLauncher.UI
{
	public partial class DlgLogin : Form
	{
		string name;
		internal string GetName() { return name; }
		string password;
		internal string GetPassword() { return password; }

		public DlgLogin()
		{
			InitializeComponent();
		}

		void btn_ok_Click( object sender, EventArgs e )
		{
			name = tb_name.Text;
			password = tb_password.Text;
		}

		void tb_name_TextChanged( object sender, EventArgs e )
		{
			btn_ok.Enabled = tb_name.Text.Length > 0;
		}
	}
}
