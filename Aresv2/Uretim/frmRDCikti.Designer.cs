namespace Aresv2.Uretim
{
	partial class frmRDCikti
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
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtMiktar = new DevExpress.XtraEditors.TextEdit();
            this.lkpStokBirim = new DevExpress.XtraEditors.LookUpEdit();
            this.txtStokKodu = new DevExpress.XtraEditors.ButtonEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtStokTanim = new DevExpress.XtraEditors.TextEdit();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStokBirim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokTanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(173, 164);
            this.memoAciklama.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Size = new System.Drawing.Size(615, 77);
            this.memoAciklama.TabIndex = 4;
            this.memoAciklama.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.memoAciklama.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(156, 172);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(7, 25);
            this.labelControl10.TabIndex = 19;
            this.labelControl10.Text = ":";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(14, 169);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(78, 25);
            this.labelControl11.TabIndex = 37;
            this.labelControl11.Text = "Açıkama";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(156, 122);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(7, 25);
            this.labelControl6.TabIndex = 36;
            this.labelControl6.Text = ":";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(156, 72);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(7, 25);
            this.labelControl8.TabIndex = 34;
            this.labelControl8.Text = ":";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(156, 22);
            this.labelControl9.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(7, 25);
            this.labelControl9.TabIndex = 33;
            this.labelControl9.Text = ":";
            // 
            // txtMiktar
            // 
            this.txtMiktar.Location = new System.Drawing.Point(173, 114);
            this.txtMiktar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtMiktar.Name = "txtMiktar";
            this.txtMiktar.Properties.Appearance.Options.UseTextOptions = true;
            this.txtMiktar.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtMiktar.Size = new System.Drawing.Size(170, 34);
            this.txtMiktar.TabIndex = 3;
            this.txtMiktar.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.txtMiktar.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            this.txtMiktar.Validating += new System.ComponentModel.CancelEventHandler(this.txtMiktar_Validating);
            // 
            // lkpStokBirim
            // 
            this.lkpStokBirim.Location = new System.Drawing.Point(590, 14);
            this.lkpStokBirim.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.lkpStokBirim.Name = "lkpStokBirim";
            this.lkpStokBirim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpStokBirim.Properties.NullText = "";
            this.lkpStokBirim.Size = new System.Drawing.Size(201, 34);
            this.lkpStokBirim.TabIndex = 1;
            this.lkpStokBirim.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.lkpStokBirim.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            // 
            // txtStokKodu
            // 
            this.txtStokKodu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtStokKodu.Location = new System.Drawing.Point(173, 14);
            this.txtStokKodu.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtStokKodu.Name = "txtStokKodu";
            this.txtStokKodu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.txtStokKodu.Size = new System.Drawing.Size(279, 34);
            this.txtStokKodu.TabIndex = 0;
            this.txtStokKodu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtStokKodu_ButtonClick);
            this.txtStokKodu.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.txtStokKodu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtStokKodu_KeyDown);
            this.txtStokKodu.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(466, 22);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(117, 25);
            this.labelControl5.TabIndex = 31;
            this.labelControl5.Text = "Stok Birim  :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(14, 119);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(57, 25);
            this.labelControl4.TabIndex = 29;
            this.labelControl4.Text = "Miktar";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 69);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 25);
            this.labelControl2.TabIndex = 26;
            this.labelControl2.Text = "Stok Tanım";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 22);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 25);
            this.labelControl1.TabIndex = 23;
            this.labelControl1.Text = "Stok Kodu";
            // 
            // btnKapat
            // 
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnKapat.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnKapat.Location = new System.Drawing.Point(629, 6);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(5, 0, 5, 6);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(159, 58);
            this.btnKapat.TabIndex = 1;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKaydet.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnKaydet.Location = new System.Drawing.Point(470, 6);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(5, 0, 5, 6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(159, 58);
            this.btnKaydet.TabIndex = 0;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtStokTanim
            // 
            this.txtStokTanim.Enabled = false;
            this.txtStokTanim.Location = new System.Drawing.Point(173, 64);
            this.txtStokTanim.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtStokTanim.Name = "txtStokTanim";
            this.txtStokTanim.Size = new System.Drawing.Size(615, 34);
            this.txtStokTanim.TabIndex = 2;
            this.txtStokTanim.TabStop = false;
            this.txtStokTanim.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.txtStokTanim.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btnKapat);
            this.panelControl2.Controls.Add(this.btnKaydet);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl2.Location = new System.Drawing.Point(0, 247);
            this.panelControl2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(802, 69);
            this.panelControl2.TabIndex = 5;
            // 
            // frmRDCikti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnKapat;
            this.ClientSize = new System.Drawing.Size(802, 316);
            this.Controls.Add(this.memoAciklama);
            this.Controls.Add(this.txtMiktar);
            this.Controls.Add(this.txtStokKodu);
            this.Controls.Add(this.txtStokTanim);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.labelControl9);
            this.Controls.Add(this.lkpStokBirim);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panelControl2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRDCikti";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reçete Çıktı Satırı";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRDCikti_FormClosed);
            this.Load += new System.EventHandler(this.frmReceteDetayCikti_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRDCikti_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMiktar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStokBirim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStokTanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.MemoEdit memoAciklama;
		private DevExpress.XtraEditors.LabelControl labelControl10;
		private DevExpress.XtraEditors.LabelControl labelControl11;
		private DevExpress.XtraEditors.LabelControl labelControl6;
		private DevExpress.XtraEditors.LabelControl labelControl8;
		private DevExpress.XtraEditors.LabelControl labelControl9;
		private DevExpress.XtraEditors.TextEdit txtMiktar;
		private DevExpress.XtraEditors.LookUpEdit lkpStokBirim;
		public DevExpress.XtraEditors.ButtonEdit txtStokKodu;
		private DevExpress.XtraEditors.LabelControl labelControl5;
		private DevExpress.XtraEditors.LabelControl labelControl4;
		private DevExpress.XtraEditors.LabelControl labelControl2;
		private DevExpress.XtraEditors.LabelControl labelControl1;
		private DevExpress.XtraEditors.SimpleButton btnKapat;
		private DevExpress.XtraEditors.SimpleButton btnKaydet;
		public DevExpress.XtraEditors.TextEdit txtStokTanim;
		private DevExpress.XtraEditors.PanelControl panelControl2;
	}
}