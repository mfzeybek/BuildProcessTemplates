namespace Aresv2.SoftPhone
{
	partial class frmNetTelefon
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.panel1 = new System.Windows.Forms.Panel();
      this.labelIdentifier = new System.Windows.Forms.Label();
      this.labelRegStatus = new System.Windows.Forms.Label();
      this.labelDialingNumber = new System.Windows.Forms.Label();
      this.labelCallStateInfo = new System.Windows.Forms.Label();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(121, 182);
      this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(129, 28);
      this.simpleButton1.TabIndex = 0;
      this.simpleButton1.Text = "Aramayı Sonlandır";
      // 
      // panel1
      // 
      this.panel1.BackColor = System.Drawing.Color.White;
      this.panel1.Controls.Add(this.labelIdentifier);
      this.panel1.Controls.Add(this.labelRegStatus);
      this.panel1.Controls.Add(this.labelDialingNumber);
      this.panel1.Controls.Add(this.labelCallStateInfo);
      this.panel1.Location = new System.Drawing.Point(14, 15);
      this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(237, 160);
      this.panel1.TabIndex = 20;
      // 
      // labelIdentifier
      // 
      this.labelIdentifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.labelIdentifier.Location = new System.Drawing.Point(141, 7);
      this.labelIdentifier.Name = "labelIdentifier";
      this.labelIdentifier.Size = new System.Drawing.Size(92, 22);
      this.labelIdentifier.TabIndex = 3;
      this.labelIdentifier.Text = "Identifier";
      this.labelIdentifier.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // labelRegStatus
      // 
      this.labelRegStatus.AutoSize = true;
      this.labelRegStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.labelRegStatus.Location = new System.Drawing.Point(7, 11);
      this.labelRegStatus.Name = "labelRegStatus";
      this.labelRegStatus.Size = new System.Drawing.Size(63, 24);
      this.labelRegStatus.TabIndex = 2;
      this.labelRegStatus.Text = "Offline";
      // 
      // labelDialingNumber
      // 
      this.labelDialingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.labelDialingNumber.Location = new System.Drawing.Point(10, 98);
      this.labelDialingNumber.Name = "labelDialingNumber";
      this.labelDialingNumber.Size = new System.Drawing.Size(210, 27);
      this.labelDialingNumber.TabIndex = 1;
      this.labelDialingNumber.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // labelCallStateInfo
      // 
      this.labelCallStateInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      this.labelCallStateInfo.Location = new System.Drawing.Point(6, 54);
      this.labelCallStateInfo.Name = "labelCallStateInfo";
      this.labelCallStateInfo.Size = new System.Drawing.Size(227, 30);
      this.labelCallStateInfo.TabIndex = 0;
      this.labelCallStateInfo.Text = "No connection";
      this.labelCallStateInfo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // frmNetTelefon
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(264, 224);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.simpleButton1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmNetTelefon";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Net Telefon";
      this.Load += new System.EventHandler(this.frmNetTelefon_Load);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton simpleButton1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label labelIdentifier;
		private System.Windows.Forms.Label labelRegStatus;
		private System.Windows.Forms.Label labelDialingNumber;
		private System.Windows.Forms.Label labelCallStateInfo;
	}
}