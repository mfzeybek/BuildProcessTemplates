namespace Aresv2.Uretim
{
	partial class frmUretimEmriDurum
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
			this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
			this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
			this.rgrpDurum = new DevExpress.XtraEditors.RadioGroup();
			((System.ComponentModel.ISupportInitialize)(this.rgrpDurum.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// btnIptal
			// 
			this.btnIptal.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnIptal.Location = new System.Drawing.Point(106, 79);
			this.btnIptal.Name = "btnIptal";
			this.btnIptal.Size = new System.Drawing.Size(88, 28);
			this.btnIptal.TabIndex = 5;
			this.btnIptal.Text = "İptal";
			this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
			// 
			// btnKaydet
			// 
			this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnKaydet.Location = new System.Drawing.Point(12, 79);
			this.btnKaydet.Name = "btnKaydet";
			this.btnKaydet.Size = new System.Drawing.Size(88, 28);
			this.btnKaydet.TabIndex = 4;
			this.btnKaydet.Text = "Kaydet";
			this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
			// 
			// rgrpDurum
			// 
			this.rgrpDurum.Cursor = System.Windows.Forms.Cursors.Hand;
			this.rgrpDurum.Dock = System.Windows.Forms.DockStyle.Top;
			this.rgrpDurum.Location = new System.Drawing.Point(0, 0);
			this.rgrpDurum.Name = "rgrpDurum";
			this.rgrpDurum.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Kaydedildi"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Üretildi")});
			this.rgrpDurum.Size = new System.Drawing.Size(199, 69);
			this.rgrpDurum.TabIndex = 3;
			// 
			// frmUretimEmriDurum
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(199, 110);
			this.Controls.Add(this.btnIptal);
			this.Controls.Add(this.btnKaydet);
			this.Controls.Add(this.rgrpDurum);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUretimEmriDurum";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Üretim Emri Durum";
			this.Load += new System.EventHandler(this.frmUretimEmriDurum_Load);
			((System.ComponentModel.ISupportInitialize)(this.rgrpDurum.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.SimpleButton btnIptal;
		private DevExpress.XtraEditors.SimpleButton btnKaydet;
		private DevExpress.XtraEditors.RadioGroup rgrpDurum;
	}
}