namespace KioskLauncher.UI
{
	partial class FormRoot
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing )
		{
			if( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tb_log = new System.Windows.Forms.TextBox();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.commandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_login = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_status = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmi_launch = new System.Windows.Forms.ToolStripMenuItem();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label7 = new System.Windows.Forms.Label();
			this.tb_user = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tb_location = new System.Windows.Forms.TextBox();
			this.tb_name = new System.Windows.Forms.TextBox();
			this.tb_id = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cb_group = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_language = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.cb_skill = new System.Windows.Forms.ComboBox();
			this.menuStrip1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tb_log
			// 
			this.tb_log.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tb_log.Location = new System.Drawing.Point( 0, 236 );
			this.tb_log.Multiline = true;
			this.tb_log.Name = "tb_log";
			this.tb_log.ReadOnly = true;
			this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tb_log.Size = new System.Drawing.Size( 292, 98 );
			this.tb_log.TabIndex = 2;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.commandToolStripMenuItem} );
			this.menuStrip1.Location = new System.Drawing.Point( 0, 0 );
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size( 292, 24 );
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// commandToolStripMenuItem
			// 
			this.commandToolStripMenuItem.DropDownItems.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_login,
            this.tsmi_status,
            this.tsmi_launch} );
			this.commandToolStripMenuItem.Name = "commandToolStripMenuItem";
			this.commandToolStripMenuItem.Size = new System.Drawing.Size( 66, 20 );
			this.commandToolStripMenuItem.Text = "Command";
			// 
			// tsmi_login
			// 
			this.tsmi_login.Name = "tsmi_login";
			this.tsmi_login.Size = new System.Drawing.Size( 171, 22 );
			this.tsmi_login.Text = "Login...";
			this.tsmi_login.Click += new System.EventHandler( this.tsmi_login_Click );
			// 
			// tsmi_status
			// 
			this.tsmi_status.Enabled = false;
			this.tsmi_status.Name = "tsmi_status";
			this.tsmi_status.Size = new System.Drawing.Size( 171, 22 );
			this.tsmi_status.Text = "Change Status...";
			this.tsmi_status.Click += new System.EventHandler( this.tsmi_status_Click );
			// 
			// tsmi_launch
			// 
			this.tsmi_launch.Enabled = false;
			this.tsmi_launch.Name = "tsmi_launch";
			this.tsmi_launch.Size = new System.Drawing.Size( 171, 22 );
			this.tsmi_launch.Text = "Launch Web Kiosk";
			this.tsmi_launch.Click += new System.EventHandler( this.tsmi_launch_Click );
			// 
			// panel1
			// 
			this.panel1.Controls.Add( this.label7 );
			this.panel1.Controls.Add( this.tb_user );
			this.panel1.Controls.Add( this.label6 );
			this.panel1.Controls.Add( this.label5 );
			this.panel1.Controls.Add( this.label4 );
			this.panel1.Controls.Add( this.tb_location );
			this.panel1.Controls.Add( this.tb_name );
			this.panel1.Controls.Add( this.tb_id );
			this.panel1.Controls.Add( this.label3 );
			this.panel1.Controls.Add( this.cb_group );
			this.panel1.Controls.Add( this.label2 );
			this.panel1.Controls.Add( this.cb_language );
			this.panel1.Controls.Add( this.label1 );
			this.panel1.Controls.Add( this.cb_skill );
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point( 0, 24 );
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size( 292, 212 );
			this.panel1.TabIndex = 1;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point( 16, 181 );
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size( 46, 13 );
			this.label7.TabIndex = 13;
			this.label7.Text = "User ID:";
			// 
			// tb_user
			// 
			this.tb_user.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_user.Enabled = false;
			this.tb_user.Location = new System.Drawing.Point( 107, 178 );
			this.tb_user.Name = "tb_user";
			this.tb_user.Size = new System.Drawing.Size( 173, 20 );
			this.tb_user.TabIndex = 6;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point( 16, 155 );
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size( 51, 13 );
			this.label6.TabIndex = 12;
			this.label6.Text = "Location:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point( 16, 129 );
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size( 67, 13 );
			this.label5.TabIndex = 11;
			this.label5.Text = "Kiosk Name:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point( 16, 103 );
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size( 50, 13 );
			this.label4.TabIndex = 10;
			this.label4.Text = "Kiosk ID:";
			// 
			// tb_location
			// 
			this.tb_location.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_location.Enabled = false;
			this.tb_location.Location = new System.Drawing.Point( 107, 152 );
			this.tb_location.Name = "tb_location";
			this.tb_location.Size = new System.Drawing.Size( 173, 20 );
			this.tb_location.TabIndex = 5;
			// 
			// tb_name
			// 
			this.tb_name.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_name.Enabled = false;
			this.tb_name.Location = new System.Drawing.Point( 107, 126 );
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size( 173, 20 );
			this.tb_name.TabIndex = 4;
			// 
			// tb_id
			// 
			this.tb_id.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_id.Enabled = false;
			this.tb_id.Location = new System.Drawing.Point( 107, 100 );
			this.tb_id.Name = "tb_id";
			this.tb_id.Size = new System.Drawing.Size( 173, 20 );
			this.tb_id.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point( 16, 76 );
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size( 39, 13 );
			this.label3.TabIndex = 9;
			this.label3.Text = "Group:";
			// 
			// cb_group
			// 
			this.cb_group.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cb_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_group.Enabled = false;
			this.cb_group.FormattingEnabled = true;
			this.cb_group.Location = new System.Drawing.Point( 107, 73 );
			this.cb_group.Name = "cb_group";
			this.cb_group.Size = new System.Drawing.Size( 173, 21 );
			this.cb_group.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point( 16, 49 );
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size( 58, 13 );
			this.label2.TabIndex = 8;
			this.label2.Text = "Language:";
			// 
			// cb_language
			// 
			this.cb_language.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cb_language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_language.Enabled = false;
			this.cb_language.FormattingEnabled = true;
			this.cb_language.Location = new System.Drawing.Point( 107, 46 );
			this.cb_language.Name = "cb_language";
			this.cb_language.Size = new System.Drawing.Size( 173, 21 );
			this.cb_language.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 16, 22 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 29, 13 );
			this.label1.TabIndex = 7;
			this.label1.Text = "Skill:";
			// 
			// cb_skill
			// 
			this.cb_skill.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.cb_skill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cb_skill.Enabled = false;
			this.cb_skill.FormattingEnabled = true;
			this.cb_skill.Location = new System.Drawing.Point( 107, 19 );
			this.cb_skill.Name = "cb_skill";
			this.cb_skill.Size = new System.Drawing.Size( 173, 21 );
			this.cb_skill.TabIndex = 0;
			// 
			// FormRoot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 292, 334 );
			this.Controls.Add( this.tb_log );
			this.Controls.Add( this.panel1 );
			this.Controls.Add( this.menuStrip1 );
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size( 300, 330 );
			this.Name = "FormRoot";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Kiosk Launcher";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.FormRoot_FormClosing );
			this.Load += new System.EventHandler( this.FormRoot_Load );
			this.Shown += new System.EventHandler( this.tsmi_login_Click );
			this.menuStrip1.ResumeLayout( false );
			this.menuStrip1.PerformLayout();
			this.panel1.ResumeLayout( false );
			this.panel1.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tb_log;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem commandToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem tsmi_login;
		private System.Windows.Forms.ToolStripMenuItem tsmi_launch;
		private System.Windows.Forms.ToolStripMenuItem tsmi_status;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cb_language;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cb_skill;
		private System.Windows.Forms.TextBox tb_id;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cb_group;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tb_location;
		private System.Windows.Forms.TextBox tb_name;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tb_user;
	}
}