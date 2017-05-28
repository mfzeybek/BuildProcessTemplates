namespace Aresv2.Uretim
{
	partial class frmRecete
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
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.btnGuncelle = new DevExpress.XtraEditors.SimpleButton();
			this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
			this.btnDegistir = new DevExpress.XtraEditors.SimpleButton();
			this.btnSil = new DevExpress.XtraEditors.SimpleButton();
			this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
			this.gcRecete = new DevExpress.XtraGrid.GridControl();
			this.gvRecete = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colReceteMasterID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colReceteKod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOzelKod1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOzelKod2 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gcRecete)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRecete)).BeginInit();
			this.SuspendLayout();
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnGuncelle);
			this.panelControl1.Controls.Add(this.btnExceleAktar);
			this.panelControl1.Controls.Add(this.btnDegistir);
			this.panelControl1.Controls.Add(this.btnSil);
			this.panelControl1.Controls.Add(this.btnEkle);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(713, 37);
			this.panelControl1.TabIndex = 0;
			// 
			// btnGuncelle
			// 
			this.btnGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnGuncelle.Location = new System.Drawing.Point(263, 5);
			this.btnGuncelle.Name = "btnGuncelle";
			this.btnGuncelle.Size = new System.Drawing.Size(83, 27);
			this.btnGuncelle.TabIndex = 4;
			this.btnGuncelle.Text = "Güncelle";
			this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
			// 
			// btnExceleAktar
			// 
			this.btnExceleAktar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExceleAktar.Location = new System.Drawing.Point(349, 5);
			this.btnExceleAktar.Name = "btnExceleAktar";
			this.btnExceleAktar.Size = new System.Drawing.Size(83, 27);
			this.btnExceleAktar.TabIndex = 3;
			this.btnExceleAktar.Text = "Excel Aktar";
			this.btnExceleAktar.Click += new System.EventHandler(this.btnExceleAktar_Click);
			// 
			// btnDegistir
			// 
			this.btnDegistir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDegistir.Location = new System.Drawing.Point(177, 5);
			this.btnDegistir.Name = "btnDegistir";
			this.btnDegistir.Size = new System.Drawing.Size(83, 27);
			this.btnDegistir.TabIndex = 2;
			this.btnDegistir.Text = "Değiştir";
			this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
			// 
			// btnSil
			// 
			this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSil.Location = new System.Drawing.Point(91, 5);
			this.btnSil.Name = "btnSil";
			this.btnSil.Size = new System.Drawing.Size(83, 27);
			this.btnSil.TabIndex = 1;
			this.btnSil.Text = "Sil";
			this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
			// 
			// btnEkle
			// 
			this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEkle.Location = new System.Drawing.Point(5, 5);
			this.btnEkle.Name = "btnEkle";
			this.btnEkle.Size = new System.Drawing.Size(83, 27);
			this.btnEkle.TabIndex = 0;
			this.btnEkle.Text = "Ekle";
			this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
			// 
			// gcRecete
			// 
			this.gcRecete.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcRecete.Location = new System.Drawing.Point(0, 37);
			this.gcRecete.MainView = this.gvRecete;
			this.gcRecete.Name = "gcRecete";
			this.gcRecete.Size = new System.Drawing.Size(713, 399);
			this.gcRecete.TabIndex = 1;
			this.gcRecete.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRecete});
			this.gcRecete.DoubleClick += new System.EventHandler(this.btnDegistir_Click);
			this.gcRecete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gcRecete_KeyDown);
			// 
			// gvRecete
			// 
			this.gvRecete.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReceteMasterID,
            this.colReceteKod,
            this.colAciklama,
            this.colOzelKod1,
            this.colOzelKod2});
			this.gvRecete.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gvRecete.GridControl = this.gcRecete;
			this.gvRecete.Name = "gvRecete";
			this.gvRecete.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvRecete.OptionsBehavior.Editable = false;
			this.gvRecete.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gvRecete.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gvRecete.OptionsView.ColumnAutoWidth = false;
			this.gvRecete.OptionsView.EnableAppearanceEvenRow = true;
			this.gvRecete.OptionsView.EnableAppearanceOddRow = true;
			this.gvRecete.OptionsView.ShowAutoFilterRow = true;
			// 
			// colReceteMasterID
			// 
			this.colReceteMasterID.Caption = "ReceteMasterID";
			this.colReceteMasterID.FieldName = "ReceteMasterID";
			this.colReceteMasterID.Name = "colReceteMasterID";
			this.colReceteMasterID.Visible = true;
			this.colReceteMasterID.VisibleIndex = 0;
			// 
			// colReceteKod
			// 
			this.colReceteKod.Caption = "ReceteKod";
			this.colReceteKod.FieldName = "ReceteKod";
			this.colReceteKod.Name = "colReceteKod";
			this.colReceteKod.Visible = true;
			this.colReceteKod.VisibleIndex = 1;
			// 
			// colAciklama
			// 
			this.colAciklama.Caption = "Aciklama";
			this.colAciklama.FieldName = "Aciklama";
			this.colAciklama.Name = "colAciklama";
			this.colAciklama.Visible = true;
			this.colAciklama.VisibleIndex = 2;
			// 
			// colOzelKod1
			// 
			this.colOzelKod1.Caption = "OzelKod1";
			this.colOzelKod1.FieldName = "OzelKod1";
			this.colOzelKod1.Name = "colOzelKod1";
			this.colOzelKod1.Visible = true;
			this.colOzelKod1.VisibleIndex = 3;
			// 
			// colOzelKod2
			// 
			this.colOzelKod2.Caption = "OzelKod2";
			this.colOzelKod2.FieldName = "OzelKod2";
			this.colOzelKod2.Name = "colOzelKod2";
			this.colOzelKod2.Visible = true;
			this.colOzelKod2.VisibleIndex = 4;
			// 
			// frmRecete
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(713, 436);
			this.Controls.Add(this.gcRecete);
			this.Controls.Add(this.panelControl1);
			this.Name = "frmRecete";
			this.Text = "Reçete Listesi";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRecete_FormClosed);
			this.Load += new System.EventHandler(this.frmRecete_Load);
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gcRecete)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvRecete)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraGrid.GridControl gcRecete;
		private DevExpress.XtraGrid.Views.Grid.GridView gvRecete;
		private DevExpress.XtraEditors.SimpleButton btnDegistir;
		private DevExpress.XtraEditors.SimpleButton btnSil;
		private DevExpress.XtraEditors.SimpleButton btnEkle;
		private DevExpress.XtraGrid.Columns.GridColumn colReceteMasterID;
		private DevExpress.XtraGrid.Columns.GridColumn colReceteKod;
		private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
		private DevExpress.XtraGrid.Columns.GridColumn colOzelKod1;
		private DevExpress.XtraGrid.Columns.GridColumn colOzelKod2;
		private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
		private DevExpress.XtraEditors.SimpleButton btnGuncelle;
	}
}