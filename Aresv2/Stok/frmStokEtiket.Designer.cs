namespace Aresv2.Stok
{
  partial class frmStokEtiket
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
            this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOzelKod1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOzelKod2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOzelKod3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOzelTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOzelMetin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEtiketMiktari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnaBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltBirimKatSayi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltBirimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButtonEdit_AltBirimAdi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.colAltBirimBarkod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnabirimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokEtiketAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lkpFiyat1Tanim = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpFiyat2Tanim = new DevExpress.XtraEditors.LookUpEdit();
            this.btnStokCikar = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokAc = new DevExpress.XtraEditors.SimpleButton();
            this.dropDownButton_Yazdir = new DevExpress.XtraEditors.DropDownButton();
            this.popupMenu_yazdir = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnMiktarDegistir = new DevExpress.XtraEditors.SimpleButton();
            this.btnYenile = new DevExpress.XtraEditors.SimpleButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ceStokEkleninceYazdir = new DevExpress.XtraEditors.CheckEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_AltBirimAdi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFiyat1Tanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFiyat2Tanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_yazdir)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceStokEkleninceYazdir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(1, 32);
            this.btnStokEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(86, 51);
            this.btnStokEkle.TabIndex = 0;
            this.btnStokEkle.Text = "+";
            this.btnStokEkle.ToolTip = "Stok Ekle (F6)";
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(93, 32);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit_AltBirimAdi});
            this.gridControl1.Size = new System.Drawing.Size(981, 627);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokID,
            this.colStokKodu,
            this.colStokAdi,
            this.colBarkodu,
            this.colOzelKod1,
            this.colOzelKod2,
            this.colOzelKod3,
            this.colFiyat1,
            this.colFiyat2,
            this.colAciklama,
            this.colOzelTarih,
            this.colOzelMetin,
            this.colBirimAciklama,
            this.colEtiketMiktari,
            this.colAnaBirimID,
            this.colAltBirimID,
            this.colAltBirimKatSayi,
            this.colAltBirimAdi,
            this.colAltBirimBarkod,
            this.colAnabirimAdi,
            this.colStokEtiketAdi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            this.colStokID.Width = 81;
            // 
            // colStokKodu
            // 
            this.colStokKodu.Caption = "Stok Kodu";
            this.colStokKodu.FieldName = "Stok Kodu";
            this.colStokKodu.Name = "colStokKodu";
            this.colStokKodu.Visible = true;
            this.colStokKodu.VisibleIndex = 0;
            this.colStokKodu.Width = 92;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "Stok Adı";
            this.colStokAdi.FieldName = "Stok Adi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 1;
            this.colStokAdi.Width = 149;
            // 
            // colBarkodu
            // 
            this.colBarkodu.Caption = "Barkodu";
            this.colBarkodu.FieldName = "Barkodu";
            this.colBarkodu.Name = "colBarkodu";
            this.colBarkodu.Visible = true;
            this.colBarkodu.VisibleIndex = 5;
            this.colBarkodu.Width = 60;
            // 
            // colOzelKod1
            // 
            this.colOzelKod1.Caption = "Ozel Kod1";
            this.colOzelKod1.FieldName = "Ozel Kod1";
            this.colOzelKod1.Name = "colOzelKod1";
            this.colOzelKod1.Visible = true;
            this.colOzelKod1.VisibleIndex = 6;
            this.colOzelKod1.Width = 60;
            // 
            // colOzelKod2
            // 
            this.colOzelKod2.Caption = "Ozel Kod2";
            this.colOzelKod2.FieldName = "Ozel Kod2";
            this.colOzelKod2.Name = "colOzelKod2";
            this.colOzelKod2.Visible = true;
            this.colOzelKod2.VisibleIndex = 7;
            this.colOzelKod2.Width = 60;
            // 
            // colOzelKod3
            // 
            this.colOzelKod3.Caption = "Ozel Kod3";
            this.colOzelKod3.FieldName = "Ozel Kod3";
            this.colOzelKod3.Name = "colOzelKod3";
            this.colOzelKod3.Visible = true;
            this.colOzelKod3.VisibleIndex = 8;
            this.colOzelKod3.Width = 60;
            // 
            // colFiyat1
            // 
            this.colFiyat1.Caption = "Fiyat1";
            this.colFiyat1.FieldName = "Fiyat1";
            this.colFiyat1.Name = "colFiyat1";
            this.colFiyat1.Visible = true;
            this.colFiyat1.VisibleIndex = 9;
            this.colFiyat1.Width = 60;
            // 
            // colFiyat2
            // 
            this.colFiyat2.Caption = "Fiyat2";
            this.colFiyat2.FieldName = "Fiyat2";
            this.colFiyat2.Name = "colFiyat2";
            this.colFiyat2.Width = 60;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Width = 71;
            // 
            // colOzelTarih
            // 
            this.colOzelTarih.Caption = "Özel Tarih";
            this.colOzelTarih.FieldName = "Ozel Tarih";
            this.colOzelTarih.Name = "colOzelTarih";
            this.colOzelTarih.Width = 73;
            // 
            // colOzelMetin
            // 
            this.colOzelMetin.Caption = "Özel Metin";
            this.colOzelMetin.FieldName = "Ozel Metin";
            this.colOzelMetin.Name = "colOzelMetin";
            this.colOzelMetin.Width = 80;
            // 
            // colBirimAciklama
            // 
            this.colBirimAciklama.Caption = "BirimAciklama";
            this.colBirimAciklama.FieldName = "BirimAciklama";
            this.colBirimAciklama.Name = "colBirimAciklama";
            this.colBirimAciklama.OptionsColumn.AllowEdit = false;
            this.colBirimAciklama.OptionsColumn.ReadOnly = true;
            this.colBirimAciklama.Visible = true;
            this.colBirimAciklama.VisibleIndex = 10;
            // 
            // colEtiketMiktari
            // 
            this.colEtiketMiktari.Caption = "Etiket Miktari";
            this.colEtiketMiktari.FieldName = "EtiketMiktari";
            this.colEtiketMiktari.Name = "colEtiketMiktari";
            this.colEtiketMiktari.Visible = true;
            this.colEtiketMiktari.VisibleIndex = 3;
            this.colEtiketMiktari.Width = 126;
            // 
            // colAnaBirimID
            // 
            this.colAnaBirimID.Caption = "AnaBirimID";
            this.colAnaBirimID.FieldName = "AnaBirimID";
            this.colAnaBirimID.Name = "colAnaBirimID";
            this.colAnaBirimID.OptionsColumn.AllowEdit = false;
            this.colAnaBirimID.OptionsColumn.ReadOnly = true;
            this.colAnaBirimID.Width = 58;
            // 
            // colAltBirimID
            // 
            this.colAltBirimID.Caption = "AltBirimID";
            this.colAltBirimID.FieldName = "AltBirimID";
            this.colAltBirimID.Name = "colAltBirimID";
            this.colAltBirimID.OptionsColumn.AllowEdit = false;
            this.colAltBirimID.OptionsColumn.ReadOnly = true;
            this.colAltBirimID.Width = 58;
            // 
            // colAltBirimKatSayi
            // 
            this.colAltBirimKatSayi.Caption = "AltBirimKatSayi";
            this.colAltBirimKatSayi.FieldName = "AltBirimKatSayi";
            this.colAltBirimKatSayi.Name = "colAltBirimKatSayi";
            this.colAltBirimKatSayi.OptionsColumn.AllowEdit = false;
            this.colAltBirimKatSayi.OptionsColumn.ReadOnly = true;
            this.colAltBirimKatSayi.Visible = true;
            this.colAltBirimKatSayi.VisibleIndex = 11;
            this.colAltBirimKatSayi.Width = 68;
            // 
            // colAltBirimAdi
            // 
            this.colAltBirimAdi.Caption = "AltBirimAdi";
            this.colAltBirimAdi.ColumnEdit = this.repositoryItemButtonEdit_AltBirimAdi;
            this.colAltBirimAdi.FieldName = "AltBirimAdi";
            this.colAltBirimAdi.Name = "colAltBirimAdi";
            this.colAltBirimAdi.OptionsColumn.ReadOnly = true;
            this.colAltBirimAdi.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedCell;
            this.colAltBirimAdi.Visible = true;
            this.colAltBirimAdi.VisibleIndex = 12;
            this.colAltBirimAdi.Width = 68;
            // 
            // repositoryItemButtonEdit_AltBirimAdi
            // 
            this.repositoryItemButtonEdit_AltBirimAdi.AutoHeight = false;
            this.repositoryItemButtonEdit_AltBirimAdi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit_AltBirimAdi.Name = "repositoryItemButtonEdit_AltBirimAdi";
            this.repositoryItemButtonEdit_AltBirimAdi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButtonEdit_AltBirimAdi_ButtonClick);
            // 
            // colAltBirimBarkod
            // 
            this.colAltBirimBarkod.Caption = "AltBirimBarkod";
            this.colAltBirimBarkod.FieldName = "AltBirimBarkod";
            this.colAltBirimBarkod.Name = "colAltBirimBarkod";
            this.colAltBirimBarkod.Visible = true;
            this.colAltBirimBarkod.VisibleIndex = 13;
            this.colAltBirimBarkod.Width = 101;
            // 
            // colAnabirimAdi
            // 
            this.colAnabirimAdi.Caption = "AnaBirimAdi";
            this.colAnabirimAdi.FieldName = "AnaBirimAdi";
            this.colAnabirimAdi.Name = "colAnabirimAdi";
            this.colAnabirimAdi.Visible = true;
            this.colAnabirimAdi.VisibleIndex = 4;
            this.colAnabirimAdi.Width = 68;
            // 
            // colStokEtiketAdi
            // 
            this.colStokEtiketAdi.Caption = "Stok Etiket Adi";
            this.colStokEtiketAdi.FieldName = "Stok Etiket Adi";
            this.colStokEtiketAdi.Name = "colStokEtiketAdi";
            this.colStokEtiketAdi.Visible = true;
            this.colStokEtiketAdi.VisibleIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 11);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(123, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Fiyat 1 e aktarılacak Fiyat";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(368, 9);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(129, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Fiyat 2 ye aktarılacak Fiyat";
            // 
            // lkpFiyat1Tanim
            // 
            this.lkpFiyat1Tanim.Location = new System.Drawing.Point(159, 6);
            this.lkpFiyat1Tanim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkpFiyat1Tanim.Name = "lkpFiyat1Tanim";
            this.lkpFiyat1Tanim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpFiyat1Tanim.Size = new System.Drawing.Size(194, 20);
            this.lkpFiyat1Tanim.TabIndex = 4;
            // 
            // lkpFiyat2Tanim
            // 
            this.lkpFiyat2Tanim.Location = new System.Drawing.Point(503, 6);
            this.lkpFiyat2Tanim.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lkpFiyat2Tanim.Name = "lkpFiyat2Tanim";
            this.lkpFiyat2Tanim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpFiyat2Tanim.Size = new System.Drawing.Size(194, 20);
            this.lkpFiyat2Tanim.TabIndex = 4;
            // 
            // btnStokCikar
            // 
            this.btnStokCikar.Location = new System.Drawing.Point(1, 94);
            this.btnStokCikar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStokCikar.Name = "btnStokCikar";
            this.btnStokCikar.Size = new System.Drawing.Size(86, 51);
            this.btnStokCikar.TabIndex = 0;
            this.btnStokCikar.Text = "-";
            this.btnStokCikar.ToolTip = "Stok Çıkar";
            this.btnStokCikar.Click += new System.EventHandler(this.btnStokCikar_Click);
            // 
            // btnStokAc
            // 
            this.btnStokAc.Location = new System.Drawing.Point(1, 156);
            this.btnStokAc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStokAc.Name = "btnStokAc";
            this.btnStokAc.Size = new System.Drawing.Size(86, 51);
            this.btnStokAc.TabIndex = 0;
            this.btnStokAc.Text = "A";
            this.btnStokAc.ToolTip = "Stok Kartını Aç";
            this.btnStokAc.Click += new System.EventHandler(this.btnStokAc_Click);
            // 
            // dropDownButton_Yazdir
            // 
            this.dropDownButton_Yazdir.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Hide;
            this.dropDownButton_Yazdir.DropDownControl = this.popupMenu_yazdir;
            this.dropDownButton_Yazdir.Location = new System.Drawing.Point(1, 342);
            this.dropDownButton_Yazdir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dropDownButton_Yazdir.Name = "dropDownButton_Yazdir";
            this.dropDownButton_Yazdir.Size = new System.Drawing.Size(86, 51);
            this.dropDownButton_Yazdir.TabIndex = 9;
            this.dropDownButton_Yazdir.Text = "Yazdır";
            // 
            // popupMenu_yazdir
            // 
            this.popupMenu_yazdir.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem5),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem6),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem7)});
            this.popupMenu_yazdir.Manager = this.barManager1;
            this.popupMenu_yazdir.Name = "popupMenu_yazdir";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Yazdır";
            this.barButtonItem5.Id = 13;
            this.barButtonItem5.Name = "barButtonItem5";
            this.barButtonItem5.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem5_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Ön İzle";
            this.barButtonItem6.Id = 14;
            this.barButtonItem6.Name = "barButtonItem6";
            this.barButtonItem6.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem6_ItemClick);
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Form Seçerek Yazdır";
            this.barButtonItem7.Id = 15;
            this.barButtonItem7.Name = "barButtonItem7";
            this.barButtonItem7.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem7_ItemClick);
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItem7});
            this.barManager1.MaxItemId = 16;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1077, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 663);
            this.barDockControlBottom.Size = new System.Drawing.Size(1077, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 663);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1077, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 663);
            // 
            // btnMiktarDegistir
            // 
            this.btnMiktarDegistir.Location = new System.Drawing.Point(1, 218);
            this.btnMiktarDegistir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMiktarDegistir.Name = "btnMiktarDegistir";
            this.btnMiktarDegistir.Size = new System.Drawing.Size(86, 51);
            this.btnMiktarDegistir.TabIndex = 14;
            this.btnMiktarDegistir.Text = "M";
            this.btnMiktarDegistir.ToolTip = "Bütün Hepsinin Miktarını Değiştir";
            this.btnMiktarDegistir.Click += new System.EventHandler(this.btnMiktarDegistir_Click);
            // 
            // btnYenile
            // 
            this.btnYenile.Location = new System.Drawing.Point(1, 280);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(86, 51);
            this.btnYenile.TabIndex = 14;
            this.btnYenile.Text = "><";
            this.btnYenile.ToolTip = "Hepsini Yenile\r\n(Stokları miktarları ile yeniden günceller)";
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // ceStokEkleninceYazdir
            // 
            this.ceStokEkleninceYazdir.Location = new System.Drawing.Point(12, 443);
            this.ceStokEkleninceYazdir.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ceStokEkleninceYazdir.MenuManager = this.barManager1;
            this.ceStokEkleninceYazdir.Name = "ceStokEkleninceYazdir";
            this.ceStokEkleninceYazdir.Properties.Caption = "S E Yazdır";
            this.ceStokEkleninceYazdir.Size = new System.Drawing.Size(64, 19);
            this.ceStokEkleninceYazdir.TabIndex = 19;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(1, 536);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(78, 23);
            this.simpleButton1.TabIndex = 24;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(1, 565);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(78, 23);
            this.simpleButton2.TabIndex = 29;
            this.simpleButton2.Text = "simpleButton2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmStokEtiket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 663);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.ceStokEkleninceYazdir);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.btnMiktarDegistir);
            this.Controls.Add(this.dropDownButton_Yazdir);
            this.Controls.Add(this.lkpFiyat2Tanim);
            this.Controls.Add(this.lkpFiyat1Tanim);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnStokAc);
            this.Controls.Add(this.btnStokCikar);
            this.Controls.Add(this.btnStokEkle);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmStokEtiket";
            this.Text = "Stok Ektiket";
            this.Load += new System.EventHandler(this.frmStokEtiket_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStokEtiket_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit_AltBirimAdi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFiyat1Tanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpFiyat2Tanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_yazdir)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ceStokEkleninceYazdir.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnStokEkle;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LookUpEdit lkpFiyat1Tanim;
    private DevExpress.XtraEditors.LookUpEdit lkpFiyat2Tanim;
    private DevExpress.XtraEditors.SimpleButton btnStokCikar;
    private DevExpress.XtraEditors.SimpleButton btnStokAc;
    private DevExpress.XtraGrid.Columns.GridColumn colStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colStokKodu;
    private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colBarkodu;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelKod1;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelKod2;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelKod3;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat1;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat2;
    private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelTarih;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelMetin;
    private DevExpress.XtraGrid.Columns.GridColumn colEtiketMiktari;
    private DevExpress.XtraEditors.DropDownButton dropDownButton_Yazdir;
    private DevExpress.XtraBars.PopupMenu popupMenu_yazdir;
    private DevExpress.XtraBars.BarButtonItem barButtonItem5;
    private DevExpress.XtraBars.BarButtonItem barButtonItem6;
    private DevExpress.XtraBars.BarButtonItem barButtonItem7;
    private DevExpress.XtraBars.BarManager barManager1;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
    private DevExpress.XtraEditors.SimpleButton btnYenile;
    private DevExpress.XtraEditors.SimpleButton btnMiktarDegistir;
    private System.Windows.Forms.ColorDialog colorDialog1;
    private DevExpress.XtraGrid.Columns.GridColumn colAnaBirimID;
    private DevExpress.XtraGrid.Columns.GridColumn colAltBirimID;
    private DevExpress.XtraGrid.Columns.GridColumn colAltBirimKatSayi;
    private DevExpress.XtraGrid.Columns.GridColumn colAltBirimAdi;
    private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit_AltBirimAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colAltBirimBarkod;
    private DevExpress.XtraGrid.Columns.GridColumn colAnabirimAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colBirimAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colStokEtiketAdi;
    private DevExpress.XtraEditors.CheckEdit ceStokEkleninceYazdir;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
    }
}