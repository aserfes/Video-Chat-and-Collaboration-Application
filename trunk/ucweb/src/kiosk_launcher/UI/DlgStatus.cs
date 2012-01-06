using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KioskLauncher.UI
{
	public partial class DlgStatus : Form
	{
		string value;
		internal string GetValue() { return value; }

		public DlgStatus( string value )
		{
			InitializeComponent();
			tb_value.Text = value;
		}

		void btn_ok_Click( object sender, EventArgs e )
		{
			value = tb_value.Text;
		}
	}
}
