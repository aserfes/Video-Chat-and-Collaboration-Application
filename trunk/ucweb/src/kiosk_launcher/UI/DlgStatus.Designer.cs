namespace KioskLauncher.UI
{
	partial class DlgStatus
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
			this.tb_value = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btn_ok
			// 
			this.btn_ok.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_ok.Location = new System.Drawing.Point( 54, 43 );
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size( 75, 23 );
			this.btn_ok.TabIndex = 2;
			this.btn_ok.Text = "Set";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler( this.btn_ok_Click );
			// 
			// btn_cancel
			// 
			this.btn_cancel.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point( 135, 43 );
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size( 75, 23 );
			this.btn_cancel.TabIndex = 3;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// tb_value
			// 
			this.tb_value.Anchor = ( (System.Windows.Forms.AnchorStyles) ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.tb_value.Location = new System.Drawing.Point( 78, 12 );
			this.tb_value.Name = "tb_value";
			this.tb_value.Size = new System.Drawing.Size( 132, 20 );
			this.tb_value.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point( 6, 15 );
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size( 37, 13 );
			this.label1.TabIndex = 4;
			this.label1.Text = "Status";
			// 
			// DlgStatus
			// 
			this.AcceptButton = this.btn_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size( 222, 78 );
			this.Controls.Add( this.btn_ok );
			this.Controls.Add( this.btn_cancel );
			this.Controls.Add( this.tb_value );
			this.Controls.Add( this.label1 );
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size( 400, 105 );
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size( 230, 105 );
			this.Name = "DlgStatus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Status";
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox tb_value;
		private System.Windows.Forms.Label label1;
	}
}

