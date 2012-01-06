namespace KioskLauncher.UI
{
	partial class DlgLogin
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
			this.btn_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.tb_password = new System.Windows.Forms.TextBox();
			this.tb_name = new System.Windows.Forms.TextBox();
			this.lblPassword_ = new System.Windows.Forms.Label();
			this.lblUserName_ = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_ok.Enabled = false;
			this.btn_ok.Location = new System.Drawing.Point( 54, 73 );
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size( 75, 23 );
			this.btn_ok.TabIndex = 0;
			this.btn_ok.Text = "Login";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler( this.btn_ok_Click );
			// 
			// btn_cancel
			// 
			this.btn_cancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point( 135, 73 );
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size( 75, 23 );
			this.btn_cancel.TabIndex = 3;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// tb_password
			// 
			this.tb_password.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_password.Location = new System.Drawing.Point( 78, 38 );
			this.tb_password.Name = "tb_password";
			this.tb_password.PasswordChar = '*';
			this.tb_password.Size = new System.Drawing.Size( 132, 20 );
			this.tb_password.TabIndex = 1;
			// 
			// tb_name
			// 
			this.tb_name.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_name.Location = new System.Drawing.Point( 78, 12 );
			this.tb_name.Name = "tb_name";
			this.tb_name.Size = new System.Drawing.Size( 132, 20 );
			this.tb_name.TabIndex = 0;
			this.tb_name.TextChanged += new System.EventHandler( this.tb_name_TextChanged );
			// 
			// lblPassword_
			// 
			this.lblPassword_.AutoSize = true;
			this.lblPassword_.Location = new System.Drawing.Point( 6, 41 );
			this.lblPassword_.Name = "lblPassword_";
			this.lblPassword_.Size = new System.Drawing.Size( 53, 13 );
			this.lblPassword_.TabIndex = 5;
			this.lblPassword_.Text = "Password";
			// 
			// lblUserName_
			// 
			this.lblUserName_.AutoSize = true;
			this.lblUserName_.Location = new System.Drawing.Point( 6, 15 );
			this.lblUserName_.Name = "lblUserName_";
			this.lblUserName_.Size = new System.Drawing.Size( 58, 13 );
			this.lblUserName_.TabIndex = 4;
			this.lblUserName_.Text = "User name";
			// 
			// DlgLogin
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size( 222, 108 );
			this.Controls.Add( this.btn_ok );
			this.Controls.Add( this.btn_cancel );
			this.Controls.Add( this.tb_password );
			this.Controls.Add( this.tb_name );
			this.Controls.Add( this.lblPassword_ );
			this.Controls.Add( this.lblUserName_ );
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size( 400, 135 );
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size( 230, 135 );
			this.Name = "DlgLogin";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Login";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox tb_password;
		private System.Windows.Forms.TextBox tb_name;
		private System.Windows.Forms.Label lblPassword_;
		private System.Windows.Forms.Label lblUserName_;
	}
}

