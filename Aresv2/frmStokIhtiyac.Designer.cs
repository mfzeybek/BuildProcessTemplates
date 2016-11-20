namespace Aresv2
{
    partial class frmStokIhtiyac
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
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.gcStokIhtiyac = new DevExpress.XtraGrid.GridControl();
      this.gvStokIhtiyac = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.StokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
      this.StokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.StokIhtiyacMiktari = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDurumu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_DurumTanimlari = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.BirimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.Barkod = new DevExpress.XtraGrid.Columns.GridColumn();
      this.StokGrupAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.MinumumMikar = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colEklemeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
      this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
      this.btnSil = new DevExpress.XtraEditors.SimpleButton();
      this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
      this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
      this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
      this.btnStokKartiAc = new DevExpress.XtraEditors.SimpleButton();
      this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.barbtnExceleAktar = new DevExpress.XtraBars.BarButtonItem();
      this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
      this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
      this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
      this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
      this.ddbtnIslemler = new DevExpress.XtraEditors.DropDownButton();
      this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gcStokIhtiyac)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvStokIhtiyac)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DurumTanimlari)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
      this.panelControl3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
      this.panelControl4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
      this.SuspendLayout();
      // 
      // panelControl1
      // 
      this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panelControl1.Controls.Add(this.gcStokIhtiyac);
      this.panelControl1.Location = new System.Drawing.Point(96, 43);
      this.panelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(1053, 572);
      this.panelControl1.TabIndex = 1;
      // 
      // gcStokIhtiyac
      // 
      this.gcStokIhtiyac.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gcStokIhtiyac.Cursor = System.Windows.Forms.Cursors.Arrow;
      this.gcStokIhtiyac.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
      this.gcStokIhtiyac.Location = new System.Drawing.Point(67, 2);
      this.gcStokIhtiyac.MainView = this.gvStokIhtiyac;
      this.gcStokIhtiyac.Margin = new System.Windows.Forms.Padding(4);
      this.gcStokIhtiyac.Name = "gcStokIhtiyac";
      this.gcStokIhtiyac.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_DurumTanimlari,
            this.repositoryItemDateEdit1});
      this.gcStokIhtiyac.Size = new System.Drawing.Size(984, 568);
      this.gcStokIhtiyac.TabIndex = 1;
      this.gcStokIhtiyac.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStokIhtiyac});
      // 
      // gvStokIhtiyac
      // 
      this.gvStokIhtiyac.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.StokAdi,
            this.Aciklama,
            this.StokKodu,
            this.StokIhtiyacMiktari,
            this.colDurumu,
            this.BirimAdi,
            this.Barkod,
            this.StokGrupAdi,
            this.MinumumMikar,
            this.colEklemeTarihi});
      this.gvStokIhtiyac.GridControl = this.gcStokIhtiyac;
      this.gvStokIhtiyac.Name = "gvStokIhtiyac";
      this.gvStokIhtiyac.OptionsView.ShowGroupPanel = false;
      // 
      // StokAdi
      // 
      this.StokAdi.Caption = "StokAdi";
      this.StokAdi.FieldName = "StokAdi";
      this.StokAdi.Name = "StokAdi";
      this.StokAdi.OptionsColumn.AllowEdit = false;
      this.StokAdi.Visible = true;
      this.StokAdi.VisibleIndex = 2;
      this.StokAdi.Width = 360;
      // 
      // Aciklama
      // 
      this.Aciklama.Caption = "Aciklama";
      this.Aciklama.FieldName = "Aciklama";
      this.Aciklama.Name = "Aciklama";
      this.Aciklama.Visible = true;
      this.Aciklama.VisibleIndex = 5;
      this.Aciklama.Width = 283;
      // 
      // StokKodu
      // 
      this.StokKodu.Caption = "StokKodu";
      this.StokKodu.FieldName = "StokKodu";
      this.StokKodu.Name = "StokKodu";
      this.StokKodu.OptionsColumn.AllowEdit = false;
      this.StokKodu.Visible = true;
      this.StokKodu.VisibleIndex = 1;
      this.StokKodu.Width = 121;
      // 
      // StokIhtiyacMiktari
      // 
      this.StokIhtiyacMiktari.Caption = "StokIhtiyacMiktari";
      this.StokIhtiyacMiktari.FieldName = "StokIhtiyacMiktari";
      this.StokIhtiyacMiktari.Name = "StokIhtiyacMiktari";
      this.StokIhtiyacMiktari.Width = 77;
      // 
      // colDurumu
      // 
      this.colDurumu.Caption = "Drumu";
      this.colDurumu.ColumnEdit = this.repositoryItemLookUpEdit_DurumTanimlari;
      this.colDurumu.FieldName = "DrumID";
      this.colDurumu.Name = "colDurumu";
      this.colDurumu.Visible = true;
      this.colDurumu.VisibleIndex = 4;
      this.colDurumu.Width = 100;
      // 
      // repositoryItemLookUpEdit_DurumTanimlari
      // 
      this.repositoryItemLookUpEdit_DurumTanimlari.AutoHeight = false;
      this.repositoryItemLookUpEdit_DurumTanimlari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_DurumTanimlari.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TanimAdi", "TanimAdi")});
      this.repositoryItemLookUpEdit_DurumTanimlari.Name = "repositoryItemLookUpEdit_DurumTanimlari";
      // 
      // BirimAdi
      // 
      this.BirimAdi.Caption = "BirimAdi";
      this.BirimAdi.FieldName = "BirimAdi";
      this.BirimAdi.Name = "BirimAdi";
      this.BirimAdi.Visible = true;
      this.BirimAdi.VisibleIndex = 3;
      this.BirimAdi.Width = 66;
      // 
      // Barkod
      // 
      this.Barkod.Caption = "Barkod";
      this.Barkod.FieldName = "Barkod";
      this.Barkod.Name = "Barkod";
      // 
      // StokGrupAdi
      // 
      this.StokGrupAdi.Caption = "StokGrupAdi";
      this.StokGrupAdi.FieldName = "StokGrupAdi";
      this.StokGrupAdi.Name = "StokGrupAdi";
      // 
      // MinumumMikar
      // 
      this.MinumumMikar.Caption = "MinumumMikar";
      this.MinumumMikar.FieldName = "MinumumMikar";
      this.MinumumMikar.Name = "MinumumMikar";
      // 
      // colEklemeTarihi
      // 
      this.colEklemeTarihi.Caption = "Tarih";
      this.colEklemeTarihi.FieldName = "EklemeTarihi";
      this.colEklemeTarihi.Name = "colEklemeTarihi";
      this.colEklemeTarihi.Visible = true;
      this.colEklemeTarihi.VisibleIndex = 0;
      this.colEklemeTarihi.Width = 101;
      // 
      // repositoryItemDateEdit1
      // 
      this.repositoryItemDateEdit1.AutoHeight = false;
      this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.repositoryItemDateEdit1.CalendarTimeProperties.CloseUpKey = new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.F4);
      this.repositoryItemDateEdit1.CalendarTimeProperties.PopupBorderStyle = DevExpress.XtraEditors.Controls.PopupBorderStyles.Default;
      this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
      // 
      // btnKaydet
      // 
      this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKaydet.Enabled = false;
      this.btnKaydet.Location = new System.Drawing.Point(8, 6);
      this.btnKaydet.Margin = new System.Windows.Forms.Padding(4);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new System.Drawing.Size(964, 28);
      this.btnKaydet.TabIndex = 2;
      this.btnKaydet.Text = "Kaydet";
      this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
      // 
      // btnVazgec
      // 
      this.btnVazgec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.btnVazgec.Enabled = false;
      this.btnVazgec.Location = new System.Drawing.Point(987, 6);
      this.btnVazgec.Margin = new System.Windows.Forms.Padding(4);
      this.btnVazgec.Name = "btnVazgec";
      this.btnVazgec.Size = new System.Drawing.Size(140, 28);
      this.btnVazgec.TabIndex = 2;
      this.btnVazgec.Text = "Vazgeç";
      this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
      // 
      // btnSil
      // 
      this.btnSil.Location = new System.Drawing.Point(3, 39);
      this.btnSil.Margin = new System.Windows.Forms.Padding(4);
      this.btnSil.Name = "btnSil";
      this.btnSil.Size = new System.Drawing.Size(152, 28);
      this.btnSil.TabIndex = 2;
      this.btnSil.Text = "Sil";
      this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
      // 
      // btnStokEkle
      // 
      this.btnStokEkle.Location = new System.Drawing.Point(3, 7);
      this.btnStokEkle.Margin = new System.Windows.Forms.Padding(4);
      this.btnStokEkle.Name = "btnStokEkle";
      this.btnStokEkle.Size = new System.Drawing.Size(152, 28);
      this.btnStokEkle.TabIndex = 2;
      this.btnStokEkle.Text = "Stok ekle";
      this.btnStokEkle.ToolTip = "Stok ekle (F6)";
      this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.btnKaydet);
      this.panelControl2.Controls.Add(this.btnVazgec);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl2.Location = new System.Drawing.Point(0, 617);
      this.panelControl2.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(1149, 44);
      this.panelControl2.TabIndex = 3;
      // 
      // panelControl3
      // 
      this.panelControl3.Controls.Add(this.checkedListBoxControl1);
      this.panelControl3.Controls.Add(this.btnTemizle);
      this.panelControl3.Controls.Add(this.btnStokKartiAc);
      this.panelControl3.Controls.Add(this.btnSil);
      this.panelControl3.Controls.Add(this.btnStokEkle);
      this.panelControl3.Dock = System.Windows.Forms.DockStyle.Left;
      this.panelControl3.Location = new System.Drawing.Point(0, 43);
      this.panelControl3.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl3.Name = "panelControl3";
      this.panelControl3.Size = new System.Drawing.Size(162, 574);
      this.panelControl3.TabIndex = 4;
      // 
      // checkedListBoxControl1
      // 
      this.checkedListBoxControl1.CheckOnClick = true;
      this.checkedListBoxControl1.Location = new System.Drawing.Point(5, 118);
      this.checkedListBoxControl1.MultiColumn = true;
      this.checkedListBoxControl1.Name = "checkedListBoxControl1";
      this.checkedListBoxControl1.Size = new System.Drawing.Size(150, 276);
      this.checkedListBoxControl1.TabIndex = 2;
      this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
      // 
      // btnTemizle
      // 
      this.btnTemizle.Location = new System.Drawing.Point(5, 400);
      this.btnTemizle.Name = "btnTemizle";
      this.btnTemizle.Size = new System.Drawing.Size(150, 23);
      this.btnTemizle.TabIndex = 5;
      this.btnTemizle.Text = "Temizle";
      this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
      // 
      // btnStokKartiAc
      // 
      this.btnStokKartiAc.Location = new System.Drawing.Point(3, 71);
      this.btnStokKartiAc.Margin = new System.Windows.Forms.Padding(4);
      this.btnStokKartiAc.Name = "btnStokKartiAc";
      this.btnStokKartiAc.Size = new System.Drawing.Size(152, 28);
      this.btnStokKartiAc.TabIndex = 3;
      this.btnStokKartiAc.Text = "Kartı aç";
      this.btnStokKartiAc.Click += new System.EventHandler(this.btnStokKartiAc_Click);
      // 
      // barManager1
      // 
      this.barManager1.DockControls.Add(this.barDockControlTop);
      this.barManager1.DockControls.Add(this.barDockControlBottom);
      this.barManager1.DockControls.Add(this.barDockControlLeft);
      this.barManager1.DockControls.Add(this.barDockControlRight);
      this.barManager1.Form = this;
      this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barbtnExceleAktar,
            this.barButtonItem2,
            this.barButtonItem1,
            this.barButtonItem3});
      this.barManager1.MaxItemId = 5;
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Margin = new System.Windows.Forms.Padding(4);
      this.barDockControlTop.Size = new System.Drawing.Size(1149, 0);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 661);
      this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(4);
      this.barDockControlBottom.Size = new System.Drawing.Size(1149, 0);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
      this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(4);
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 661);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(1149, 0);
      this.barDockControlRight.Margin = new System.Windows.Forms.Padding(4);
      this.barDockControlRight.Size = new System.Drawing.Size(0, 661);
      // 
      // barbtnExceleAktar
      // 
      this.barbtnExceleAktar.Caption = "Excel e aktar";
      this.barbtnExceleAktar.Id = 0;
      this.barbtnExceleAktar.Name = "barbtnExceleAktar";
      this.barbtnExceleAktar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barbtnExceleAktar_ItemClick);
      // 
      // barButtonItem2
      // 
      this.barButtonItem2.Caption = "İhtiyac Listesine Gönder";
      this.barButtonItem2.Id = 1;
      this.barButtonItem2.Name = "barButtonItem2";
      // 
      // barButtonItem1
      // 
      this.barButtonItem1.Caption = "Mail ile gönder";
      this.barButtonItem1.Id = 3;
      this.barButtonItem1.Name = "barButtonItem1";
      // 
      // barButtonItem3
      // 
      this.barButtonItem3.Caption = "Tablo Konumu Kaydet";
      this.barButtonItem3.Id = 4;
      this.barButtonItem3.Name = "barButtonItem3";
      this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick);
      // 
      // panelControl4
      // 
      this.panelControl4.Controls.Add(this.ddbtnIslemler);
      this.panelControl4.Controls.Add(this.labelControl1);
      this.panelControl4.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl4.Location = new System.Drawing.Point(0, 0);
      this.panelControl4.Margin = new System.Windows.Forms.Padding(4);
      this.panelControl4.Name = "panelControl4";
      this.panelControl4.Size = new System.Drawing.Size(1149, 43);
      this.panelControl4.TabIndex = 2;
      // 
      // ddbtnIslemler
      // 
      this.ddbtnIslemler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ddbtnIslemler.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
      this.ddbtnIslemler.DropDownControl = this.popupMenu1;
      this.ddbtnIslemler.Location = new System.Drawing.Point(961, 6);
      this.ddbtnIslemler.Margin = new System.Windows.Forms.Padding(4);
      this.ddbtnIslemler.Name = "ddbtnIslemler";
      this.ddbtnIslemler.Size = new System.Drawing.Size(175, 33);
      this.ddbtnIslemler.TabIndex = 6;
      this.ddbtnIslemler.Text = "İşlemler";
      // 
      // popupMenu1
      // 
      this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barbtnExceleAktar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
      this.popupMenu1.Manager = this.barManager1;
      this.popupMenu1.Name = "popupMenu1";
      // 
      // labelControl1
      // 
      this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
      this.labelControl1.Location = new System.Drawing.Point(9, 9);
      this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(189, 30);
      this.labelControl1.TabIndex = 2;
      this.labelControl1.Text = "İHTİYAÇ LİSTESİ";
      // 
      // frmStokIhtiyac
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1149, 661);
      this.Controls.Add(this.panelControl3);
      this.Controls.Add(this.panelControl4);
      this.Controls.Add(this.panelControl2);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "frmStokIhtiyac";
      this.Text = "Stok İhtiyaç Listesi";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmStokIhtiyac_FormClosing);
      this.Load += new System.EventHandler(this.Form1_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStokIhtiyac_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gcStokIhtiyac)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvStokIhtiyac)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_DurumTanimlari)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
      this.panelControl3.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
      this.panelControl4.ResumeLayout(false);
      this.panelControl4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
      this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gcStokIhtiyac;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStokIhtiyac;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.SimpleButton btnStokEkle;
        private DevExpress.XtraGrid.Columns.GridColumn StokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
        private DevExpress.XtraGrid.Columns.GridColumn StokKodu;
        private DevExpress.XtraGrid.Columns.GridColumn StokIhtiyacMiktari;
        private DevExpress.XtraGrid.Columns.GridColumn colDurumu;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private DevExpress.XtraEditors.DropDownButton ddbtnIslemler;
        private DevExpress.XtraEditors.SimpleButton btnStokKartiAc;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn BirimAdi;
        private DevExpress.XtraGrid.Columns.GridColumn Barkod;
        private DevExpress.XtraGrid.Columns.GridColumn StokGrupAdi;
        private DevExpress.XtraGrid.Columns.GridColumn MinumumMikar;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barbtnExceleAktar;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_DurumTanimlari;
        private DevExpress.XtraGrid.Columns.GridColumn colEklemeTarihi;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;

    }
}