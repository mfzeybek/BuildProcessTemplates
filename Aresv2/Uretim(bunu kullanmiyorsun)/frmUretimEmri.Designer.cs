namespace Aresv2.Uretim
{
	partial class frmUretimEmri
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
			this.components = new System.ComponentModel.Container();
			this.gcUretimEmri = new DevExpress.XtraGrid.GridControl();
			this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cbtnKaydedildi = new System.Windows.Forms.ToolStripMenuItem();
			this.cbtnUretildi = new System.Windows.Forms.ToolStripMenuItem();
			this.gvUretimEmri = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colUretimEmriID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPartiNo = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUretimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOzelKod1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCariTanim = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSarfAmbarID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSarfAmbar = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUretimdenGirisAmbarID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUretimdenGiris = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colReceteMasterID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colReceteKod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUretimMiktari = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBaslangicTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBitisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUretimAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDurum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colUretimDurum = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colKaydedenID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colKayitTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGuncelleyenID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGuncellemeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
			this.btnDegistir = new DevExpress.XtraEditors.SimpleButton();
			this.btnSil = new DevExpress.XtraEditors.SimpleButton();
			this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gcUretimEmri)).BeginInit();
			this.contextMenuStrip2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gvUretimEmri)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// gcUretimEmri
			// 
			this.gcUretimEmri.ContextMenuStrip = this.contextMenuStrip2;
			this.gcUretimEmri.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcUretimEmri.Location = new System.Drawing.Point(0, 37);
			this.gcUretimEmri.MainView = this.gvUretimEmri;
			this.gcUretimEmri.Name = "gcUretimEmri";
			this.gcUretimEmri.Size = new System.Drawing.Size(1057, 401);
			this.gcUretimEmri.TabIndex = 3;
			this.gcUretimEmri.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvUretimEmri});
			// 
			// contextMenuStrip2
			// 
			this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbtnKaydedildi,
            this.cbtnUretildi});
			this.contextMenuStrip2.Name = "contextMenuStrip2";
			this.contextMenuStrip2.Size = new System.Drawing.Size(267, 48);
			this.contextMenuStrip2.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip2_Opening);
			// 
			// cbtnKaydedildi
			// 
			this.cbtnKaydedildi.Name = "cbtnKaydedildi";
			this.cbtnKaydedildi.Size = new System.Drawing.Size(266, 22);
			this.cbtnKaydedildi.Text = "Durum Değiştir -> Kaydedildi olarak.";
			this.cbtnKaydedildi.Click += new System.EventHandler(this.cbtnKaydedildi_Click);
			// 
			// cbtnUretildi
			// 
			this.cbtnUretildi.Name = "cbtnUretildi";
			this.cbtnUretildi.Size = new System.Drawing.Size(266, 22);
			this.cbtnUretildi.Text = "Durum Değiştir -> Üretildi olarak";
			this.cbtnUretildi.Click += new System.EventHandler(this.cbtnUretildi_Click);
			// 
			// gvUretimEmri
			// 
			this.gvUretimEmri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUretimEmriID,
            this.colPartiNo,
            this.colUretimTarihi,
            this.colOzelKod1,
            this.colCariID,
            this.colCariTanim,
            this.colSarfAmbarID,
            this.colSarfAmbar,
            this.colUretimdenGirisAmbarID,
            this.colUretimdenGiris,
            this.colReceteMasterID,
            this.colReceteKod,
            this.colUretimMiktari,
            this.colBaslangicTarihi,
            this.colBitisTarihi,
            this.colTeslimTarihi,
            this.colUretimAciklama,
            this.colDurum,
            this.colUretimDurum,
            this.colKaydedenID,
            this.colKayitTarihi,
            this.colGuncelleyenID,
            this.colGuncellemeTarihi});
			this.gvUretimEmri.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gvUretimEmri.GridControl = this.gcUretimEmri;
			this.gvUretimEmri.Name = "gvUretimEmri";
			this.gvUretimEmri.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvUretimEmri.OptionsBehavior.Editable = false;
			this.gvUretimEmri.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gvUretimEmri.OptionsSelection.EnableAppearanceFocusedRow = false;
			this.gvUretimEmri.OptionsView.ColumnAutoWidth = false;
			this.gvUretimEmri.OptionsView.EnableAppearanceEvenRow = true;
			this.gvUretimEmri.OptionsView.EnableAppearanceOddRow = true;
			this.gvUretimEmri.OptionsView.ShowAutoFilterRow = true;
			this.gvUretimEmri.DoubleClick += new System.EventHandler(this.btnDegistir_Click);
			// 
			// colUretimEmriID
			// 
			this.colUretimEmriID.Caption = "UretimEmriID";
			this.colUretimEmriID.FieldName = "UretimEmriID";
			this.colUretimEmriID.Name = "colUretimEmriID";
			this.colUretimEmriID.Visible = true;
			this.colUretimEmriID.VisibleIndex = 0;
			// 
			// colPartiNo
			// 
			this.colPartiNo.Caption = "PartiNo";
			this.colPartiNo.FieldName = "PartiNo";
			this.colPartiNo.Name = "colPartiNo";
			this.colPartiNo.Visible = true;
			this.colPartiNo.VisibleIndex = 1;
			// 
			// colUretimTarihi
			// 
			this.colUretimTarihi.Caption = "UretimTarihi";
			this.colUretimTarihi.FieldName = "UretimTarihi";
			this.colUretimTarihi.Name = "colUretimTarihi";
			this.colUretimTarihi.Visible = true;
			this.colUretimTarihi.VisibleIndex = 2;
			// 
			// colOzelKod1
			// 
			this.colOzelKod1.Caption = "OzelKod1";
			this.colOzelKod1.FieldName = "OzelKod1";
			this.colOzelKod1.Name = "colOzelKod1";
			this.colOzelKod1.Visible = true;
			this.colOzelKod1.VisibleIndex = 3;
			// 
			// colCariID
			// 
			this.colCariID.Caption = "CariID";
			this.colCariID.FieldName = "CariID";
			this.colCariID.Name = "colCariID";
			this.colCariID.Visible = true;
			this.colCariID.VisibleIndex = 4;
			// 
			// colCariTanim
			// 
			this.colCariTanim.Caption = "CariTanim";
			this.colCariTanim.FieldName = "CariTanim";
			this.colCariTanim.Name = "colCariTanim";
			this.colCariTanim.Visible = true;
			this.colCariTanim.VisibleIndex = 5;
			// 
			// colSarfAmbarID
			// 
			this.colSarfAmbarID.Caption = "SarfAmbarID";
			this.colSarfAmbarID.FieldName = "SarfAmbarID";
			this.colSarfAmbarID.Name = "colSarfAmbarID";
			this.colSarfAmbarID.Visible = true;
			this.colSarfAmbarID.VisibleIndex = 6;
			// 
			// colSarfAmbar
			// 
			this.colSarfAmbar.Caption = "SarfAmbar";
			this.colSarfAmbar.FieldName = "SarfAmbar";
			this.colSarfAmbar.Name = "colSarfAmbar";
			this.colSarfAmbar.Visible = true;
			this.colSarfAmbar.VisibleIndex = 7;
			// 
			// colUretimdenGirisAmbarID
			// 
			this.colUretimdenGirisAmbarID.Caption = "UretimdenGirisAmbarID";
			this.colUretimdenGirisAmbarID.FieldName = "UretimdenGirisAmbarID";
			this.colUretimdenGirisAmbarID.Name = "colUretimdenGirisAmbarID";
			this.colUretimdenGirisAmbarID.Visible = true;
			this.colUretimdenGirisAmbarID.VisibleIndex = 8;
			// 
			// colUretimdenGiris
			// 
			this.colUretimdenGiris.Caption = "UretimdenGiris";
			this.colUretimdenGiris.FieldName = "UretimdenGiris";
			this.colUretimdenGiris.Name = "colUretimdenGiris";
			this.colUretimdenGiris.Visible = true;
			this.colUretimdenGiris.VisibleIndex = 9;
			// 
			// colReceteMasterID
			// 
			this.colReceteMasterID.Caption = "ReceteMasterID";
			this.colReceteMasterID.FieldName = "ReceteMasterID";
			this.colReceteMasterID.Name = "colReceteMasterID";
			this.colReceteMasterID.Visible = true;
			this.colReceteMasterID.VisibleIndex = 10;
			// 
			// colReceteKod
			// 
			this.colReceteKod.Caption = "ReceteKod";
			this.colReceteKod.FieldName = "ReceteKod";
			this.colReceteKod.Name = "colReceteKod";
			this.colReceteKod.Visible = true;
			this.colReceteKod.VisibleIndex = 11;
			// 
			// colUretimMiktari
			// 
			this.colUretimMiktari.Caption = "UretimMiktari";
			this.colUretimMiktari.FieldName = "UretimMiktari";
			this.colUretimMiktari.Name = "colUretimMiktari";
			this.colUretimMiktari.Visible = true;
			this.colUretimMiktari.VisibleIndex = 12;
			// 
			// colBaslangicTarihi
			// 
			this.colBaslangicTarihi.Caption = "BaslangicTarihi";
			this.colBaslangicTarihi.FieldName = "BaslangicTarihi";
			this.colBaslangicTarihi.Name = "colBaslangicTarihi";
			this.colBaslangicTarihi.Visible = true;
			this.colBaslangicTarihi.VisibleIndex = 13;
			// 
			// colBitisTarihi
			// 
			this.colBitisTarihi.Caption = "BitisTarihi";
			this.colBitisTarihi.FieldName = "BitisTarihi";
			this.colBitisTarihi.Name = "colBitisTarihi";
			this.colBitisTarihi.Visible = true;
			this.colBitisTarihi.VisibleIndex = 19;
			// 
			// colTeslimTarihi
			// 
			this.colTeslimTarihi.Caption = "TeslimTarihi";
			this.colTeslimTarihi.FieldName = "TeslimTarihi";
			this.colTeslimTarihi.Name = "colTeslimTarihi";
			this.colTeslimTarihi.Visible = true;
			this.colTeslimTarihi.VisibleIndex = 14;
			// 
			// colUretimAciklama
			// 
			this.colUretimAciklama.Caption = "UretimAciklama";
			this.colUretimAciklama.FieldName = "UretimAciklama";
			this.colUretimAciklama.Name = "colUretimAciklama";
			this.colUretimAciklama.Visible = true;
			this.colUretimAciklama.VisibleIndex = 15;
			// 
			// colDurum
			// 
			this.colDurum.Caption = "Durum";
			this.colDurum.FieldName = "Durum";
			this.colDurum.Name = "colDurum";
			this.colDurum.Visible = true;
			this.colDurum.VisibleIndex = 16;
			// 
			// colUretimDurum
			// 
			this.colUretimDurum.Caption = "Üretim Durumu";
			this.colUretimDurum.FieldName = "UretimDurum";
			this.colUretimDurum.Name = "colUretimDurum";
			this.colUretimDurum.Visible = true;
			this.colUretimDurum.VisibleIndex = 22;
			// 
			// colKaydedenID
			// 
			this.colKaydedenID.Caption = "KaydedenID";
			this.colKaydedenID.FieldName = "KaydedenID";
			this.colKaydedenID.Name = "colKaydedenID";
			this.colKaydedenID.Visible = true;
			this.colKaydedenID.VisibleIndex = 17;
			// 
			// colKayitTarihi
			// 
			this.colKayitTarihi.Caption = "KayitTarihi";
			this.colKayitTarihi.FieldName = "KayitTarihi";
			this.colKayitTarihi.Name = "colKayitTarihi";
			this.colKayitTarihi.Visible = true;
			this.colKayitTarihi.VisibleIndex = 18;
			// 
			// colGuncelleyenID
			// 
			this.colGuncelleyenID.Caption = "GuncelleyenID";
			this.colGuncelleyenID.FieldName = "GuncelleyenID";
			this.colGuncelleyenID.Name = "colGuncelleyenID";
			this.colGuncelleyenID.Visible = true;
			this.colGuncelleyenID.VisibleIndex = 20;
			// 
			// colGuncellemeTarihi
			// 
			this.colGuncellemeTarihi.Caption = "GuncellemeTarihi";
			this.colGuncellemeTarihi.FieldName = "GuncellemeTarihi";
			this.colGuncellemeTarihi.Name = "colGuncellemeTarihi";
			this.colGuncellemeTarihi.Visible = true;
			this.colGuncellemeTarihi.VisibleIndex = 21;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnExceleAktar);
			this.panelControl1.Controls.Add(this.btnDegistir);
			this.panelControl1.Controls.Add(this.btnSil);
			this.panelControl1.Controls.Add(this.btnEkle);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(1057, 37);
			this.panelControl1.TabIndex = 2;
			// 
			// btnExceleAktar
			// 
			this.btnExceleAktar.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnExceleAktar.Location = new System.Drawing.Point(256, 7);
			this.btnExceleAktar.Name = "btnExceleAktar";
			this.btnExceleAktar.Size = new System.Drawing.Size(75, 23);
			this.btnExceleAktar.TabIndex = 3;
			this.btnExceleAktar.Text = "Excel e Aktar";
			this.btnExceleAktar.Click += new System.EventHandler(this.btnExceleAktar_Click);
			// 
			// btnDegistir
			// 
			this.btnDegistir.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnDegistir.Location = new System.Drawing.Point(174, 7);
			this.btnDegistir.Name = "btnDegistir";
			this.btnDegistir.Size = new System.Drawing.Size(75, 23);
			this.btnDegistir.TabIndex = 2;
			this.btnDegistir.Text = "Değiştir";
			this.btnDegistir.Click += new System.EventHandler(this.btnDegistir_Click);
			// 
			// btnSil
			// 
			this.btnSil.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSil.Location = new System.Drawing.Point(93, 7);
			this.btnSil.Name = "btnSil";
			this.btnSil.Size = new System.Drawing.Size(75, 23);
			this.btnSil.TabIndex = 1;
			this.btnSil.Text = "Sil";
			this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
			// 
			// btnEkle
			// 
			this.btnEkle.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnEkle.Location = new System.Drawing.Point(12, 7);
			this.btnEkle.Name = "btnEkle";
			this.btnEkle.Size = new System.Drawing.Size(75, 23);
			this.btnEkle.TabIndex = 0;
			this.btnEkle.Text = "Ekle";
			this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
			// 
			// frmUretimEmri
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1057, 438);
			this.Controls.Add(this.gcUretimEmri);
			this.Controls.Add(this.panelControl1);
			this.Name = "frmUretimEmri";
			this.Text = "Üretim Emri";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUretimEmri_FormClosed);
			this.Load += new System.EventHandler(this.frmUretimEmri_Load);
			((System.ComponentModel.ISupportInitialize)(this.gcUretimEmri)).EndInit();
			this.contextMenuStrip2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gvUretimEmri)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gcUretimEmri;
		private DevExpress.XtraGrid.Views.Grid.GridView gvUretimEmri;
		private DevExpress.XtraEditors.PanelControl panelControl1;
		private DevExpress.XtraEditors.SimpleButton btnDegistir;
		private DevExpress.XtraEditors.SimpleButton btnSil;
		private DevExpress.XtraEditors.SimpleButton btnEkle;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimEmriID;
		private DevExpress.XtraGrid.Columns.GridColumn colPartiNo;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colOzelKod1;
		private DevExpress.XtraGrid.Columns.GridColumn colCariID;
		private DevExpress.XtraGrid.Columns.GridColumn colCariTanim;
		private DevExpress.XtraGrid.Columns.GridColumn colSarfAmbarID;
		private DevExpress.XtraGrid.Columns.GridColumn colSarfAmbar;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimdenGirisAmbarID;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimdenGiris;
		private DevExpress.XtraGrid.Columns.GridColumn colReceteMasterID;
		private DevExpress.XtraGrid.Columns.GridColumn colReceteKod;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimMiktari;
		private DevExpress.XtraGrid.Columns.GridColumn colBaslangicTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimAciklama;
		private DevExpress.XtraGrid.Columns.GridColumn colBitisTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colDurum;
		private DevExpress.XtraGrid.Columns.GridColumn colKaydedenID;
		private DevExpress.XtraGrid.Columns.GridColumn colKayitTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colGuncelleyenID;
		private DevExpress.XtraGrid.Columns.GridColumn colGuncellemeTarihi;
		private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
		private DevExpress.XtraGrid.Columns.GridColumn colUretimDurum;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
		private System.Windows.Forms.ToolStripMenuItem cbtnKaydedildi;
		private System.Windows.Forms.ToolStripMenuItem cbtnUretildi;

	}
}