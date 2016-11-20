namespace Aresv2.HemenAl.UrunSecenek
{
  partial class frmHemenAlUrunSecenekOnTanimDetaylari
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
      this.txtAdi = new DevExpress.XtraEditors.TextEdit();
      this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.gcHemenAlSecenek = new DevExpress.XtraGrid.GridControl();
      this.gvHemenAlSecenek = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colHemenAlSecenekID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenALSecenekStokID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ColHemenAlSecenekSecenekGrubu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekSatirSecenek = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekSutunSecenek = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekKavala = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekSira = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekSatisFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekStokMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAlSecenekGoruntulemeSekli = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_GoruntulemeSekli = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAlSecenekStokKontrol = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_StokKontrol = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAlSecenekUrunFiyatiYerineGecsin = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAlSecenekSeciliGelsin = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_SeciliGelsin = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAlSecenekSecimZorunlu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_SecimZorunlu = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAlSecenekSecenekAktif = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_SecenekAktif = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colSatisFiyatiHesaplamaSayisi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcHemenAlSecenek)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvHemenAlSecenek)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_GoruntulemeSekli)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_StokKontrol)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SeciliGelsin)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SecimZorunlu)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SecenekAktif)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi)).BeginInit();
      this.SuspendLayout();
      // 
      // txtAdi
      // 
      this.txtAdi.Location = new System.Drawing.Point(12, 23);
      this.txtAdi.Name = "txtAdi";
      this.txtAdi.Size = new System.Drawing.Size(338, 22);
      this.txtAdi.TabIndex = 1;
      // 
      // txtAciklama
      // 
      this.txtAciklama.Location = new System.Drawing.Point(356, 23);
      this.txtAciklama.Name = "txtAciklama";
      this.txtAciklama.Size = new System.Drawing.Size(338, 22);
      this.txtAciklama.TabIndex = 1;
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(12, 1);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(18, 16);
      this.labelControl1.TabIndex = 2;
      this.labelControl1.Text = "Adı";
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(356, -1);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(51, 16);
      this.labelControl2.TabIndex = 2;
      this.labelControl2.Text = "Açıklama";
      // 
      // gcHemenAlSecenek
      // 
      this.gcHemenAlSecenek.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gcHemenAlSecenek.Location = new System.Drawing.Point(12, 51);
      this.gcHemenAlSecenek.MainView = this.gvHemenAlSecenek;
      this.gcHemenAlSecenek.Name = "gcHemenAlSecenek";
      this.gcHemenAlSecenek.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_SecenekAktif,
            this.repositoryItemLookUpEdit_SecimZorunlu,
            this.repositoryItemLookUpEdit_SeciliGelsin,
            this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin,
            this.repositoryItemLookUpEdit_StokKontrol,
            this.repositoryItemLookUpEdit_GoruntulemeSekli,
            this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi});
      this.gcHemenAlSecenek.Size = new System.Drawing.Size(1232, 599);
      this.gcHemenAlSecenek.TabIndex = 3;
      this.gcHemenAlSecenek.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHemenAlSecenek});
      // 
      // gvHemenAlSecenek
      // 
      this.gvHemenAlSecenek.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHemenAlSecenekID,
            this.colHemenALSecenekStokID,
            this.ColHemenAlSecenekSecenekGrubu,
            this.colHemenAlSecenekSatirSecenek,
            this.colHemenAlSecenekSutunSecenek,
            this.colHemenAlSecenekKavala,
            this.colHemenAlSecenekSira,
            this.colHemenAlSecenekSatisFiyat,
            this.colHemenAlSecenekStokMiktar,
            this.colHemenAlSecenekGoruntulemeSekli,
            this.colHemenAlSecenekStokKontrol,
            this.colHemenAlSecenekUrunFiyatiYerineGecsin,
            this.colHemenAlSecenekSeciliGelsin,
            this.colHemenAlSecenekSecimZorunlu,
            this.colHemenAlSecenekSecenekAktif,
            this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi,
            this.colSatisFiyatiHesaplamaSayisi});
      this.gvHemenAlSecenek.GridControl = this.gcHemenAlSecenek;
      this.gvHemenAlSecenek.Name = "gvHemenAlSecenek";
      this.gvHemenAlSecenek.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
      // 
      // colHemenAlSecenekID
      // 
      this.colHemenAlSecenekID.Caption = "HemenAlSecenekID";
      this.colHemenAlSecenekID.FieldName = "HemenAlSecenekID";
      this.colHemenAlSecenekID.Name = "colHemenAlSecenekID";
      // 
      // colHemenALSecenekStokID
      // 
      this.colHemenALSecenekStokID.Caption = "StokID";
      this.colHemenALSecenekStokID.FieldName = "StokID";
      this.colHemenALSecenekStokID.Name = "colHemenALSecenekStokID";
      // 
      // ColHemenAlSecenekSecenekGrubu
      // 
      this.ColHemenAlSecenekSecenekGrubu.Caption = "SecenekGrubu";
      this.ColHemenAlSecenekSecenekGrubu.FieldName = "SecenekGrubu";
      this.ColHemenAlSecenekSecenekGrubu.Name = "ColHemenAlSecenekSecenekGrubu";
      this.ColHemenAlSecenekSecenekGrubu.Visible = true;
      this.ColHemenAlSecenekSecenekGrubu.VisibleIndex = 1;
      this.ColHemenAlSecenekSecenekGrubu.Width = 92;
      // 
      // colHemenAlSecenekSatirSecenek
      // 
      this.colHemenAlSecenekSatirSecenek.Caption = "SatirSecenek";
      this.colHemenAlSecenekSatirSecenek.FieldName = "SatirSecenek";
      this.colHemenAlSecenekSatirSecenek.Name = "colHemenAlSecenekSatirSecenek";
      this.colHemenAlSecenekSatirSecenek.Visible = true;
      this.colHemenAlSecenekSatirSecenek.VisibleIndex = 2;
      this.colHemenAlSecenekSatirSecenek.Width = 92;
      // 
      // colHemenAlSecenekSutunSecenek
      // 
      this.colHemenAlSecenekSutunSecenek.Caption = "SutunSecenek";
      this.colHemenAlSecenekSutunSecenek.FieldName = "SutunSecenek";
      this.colHemenAlSecenekSutunSecenek.Name = "colHemenAlSecenekSutunSecenek";
      this.colHemenAlSecenekSutunSecenek.Visible = true;
      this.colHemenAlSecenekSutunSecenek.VisibleIndex = 3;
      this.colHemenAlSecenekSutunSecenek.Width = 92;
      // 
      // colHemenAlSecenekKavala
      // 
      this.colHemenAlSecenekKavala.Caption = "Kavala";
      this.colHemenAlSecenekKavala.FieldName = "Kavala";
      this.colHemenAlSecenekKavala.Name = "colHemenAlSecenekKavala";
      // 
      // colHemenAlSecenekSira
      // 
      this.colHemenAlSecenekSira.Caption = "Sira";
      this.colHemenAlSecenekSira.FieldName = "Sira";
      this.colHemenAlSecenekSira.Name = "colHemenAlSecenekSira";
      this.colHemenAlSecenekSira.Visible = true;
      this.colHemenAlSecenekSira.VisibleIndex = 0;
      this.colHemenAlSecenekSira.Width = 65;
      // 
      // colHemenAlSecenekSatisFiyat
      // 
      this.colHemenAlSecenekSatisFiyat.Caption = "SatisFiyat";
      this.colHemenAlSecenekSatisFiyat.FieldName = "SatisFiyat";
      this.colHemenAlSecenekSatisFiyat.Name = "colHemenAlSecenekSatisFiyat";
      this.colHemenAlSecenekSatisFiyat.Visible = true;
      this.colHemenAlSecenekSatisFiyat.VisibleIndex = 6;
      this.colHemenAlSecenekSatisFiyat.Width = 92;
      // 
      // colHemenAlSecenekStokMiktar
      // 
      this.colHemenAlSecenekStokMiktar.Caption = "StokMiktar";
      this.colHemenAlSecenekStokMiktar.FieldName = "StokMiktar";
      this.colHemenAlSecenekStokMiktar.Name = "colHemenAlSecenekStokMiktar";
      this.colHemenAlSecenekStokMiktar.Visible = true;
      this.colHemenAlSecenekStokMiktar.VisibleIndex = 7;
      this.colHemenAlSecenekStokMiktar.Width = 92;
      // 
      // colHemenAlSecenekGoruntulemeSekli
      // 
      this.colHemenAlSecenekGoruntulemeSekli.Caption = "GoruntulemeSekli";
      this.colHemenAlSecenekGoruntulemeSekli.ColumnEdit = this.repositoryItemLookUpEdit_GoruntulemeSekli;
      this.colHemenAlSecenekGoruntulemeSekli.FieldName = "GoruntulemeSekli";
      this.colHemenAlSecenekGoruntulemeSekli.Name = "colHemenAlSecenekGoruntulemeSekli";
      this.colHemenAlSecenekGoruntulemeSekli.Visible = true;
      this.colHemenAlSecenekGoruntulemeSekli.VisibleIndex = 8;
      this.colHemenAlSecenekGoruntulemeSekli.Width = 92;
      // 
      // repositoryItemLookUpEdit_GoruntulemeSekli
      // 
      this.repositoryItemLookUpEdit_GoruntulemeSekli.AutoHeight = false;
      this.repositoryItemLookUpEdit_GoruntulemeSekli.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_GoruntulemeSekli.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("GoruntulemeSekliAdi", "GoruntulemeSekliAdi")});
      this.repositoryItemLookUpEdit_GoruntulemeSekli.Name = "repositoryItemLookUpEdit_GoruntulemeSekli";
      // 
      // colHemenAlSecenekStokKontrol
      // 
      this.colHemenAlSecenekStokKontrol.Caption = "StokKontrol";
      this.colHemenAlSecenekStokKontrol.ColumnEdit = this.repositoryItemLookUpEdit_StokKontrol;
      this.colHemenAlSecenekStokKontrol.FieldName = "StokKontrol";
      this.colHemenAlSecenekStokKontrol.Name = "colHemenAlSecenekStokKontrol";
      this.colHemenAlSecenekStokKontrol.Visible = true;
      this.colHemenAlSecenekStokKontrol.VisibleIndex = 9;
      this.colHemenAlSecenekStokKontrol.Width = 92;
      // 
      // repositoryItemLookUpEdit_StokKontrol
      // 
      this.repositoryItemLookUpEdit_StokKontrol.AutoHeight = false;
      this.repositoryItemLookUpEdit_StokKontrol.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_StokKontrol.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("StokKontrolAdi", "StokKontrolAdi")});
      this.repositoryItemLookUpEdit_StokKontrol.Name = "repositoryItemLookUpEdit_StokKontrol";
      // 
      // colHemenAlSecenekUrunFiyatiYerineGecsin
      // 
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.Caption = "UrunFiyatiYerineGecsin";
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.ColumnEdit = this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin;
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.FieldName = "UrunFiyatiYerineGecsin";
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.Name = "colHemenAlSecenekUrunFiyatiYerineGecsin";
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.Visible = true;
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.VisibleIndex = 10;
      this.colHemenAlSecenekUrunFiyatiYerineGecsin.Width = 92;
      // 
      // repositoryItemLookUpEdit_UrunFiyatiYerineGecsin
      // 
      this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.AutoHeight = false;
      this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("UrunFiyatiYerineGecsinAdi", "UrunFiyatiYerineGecsinAdi")});
      this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.Name = "repositoryItemLookUpEdit_UrunFiyatiYerineGecsin";
      // 
      // colHemenAlSecenekSeciliGelsin
      // 
      this.colHemenAlSecenekSeciliGelsin.Caption = "SeciliGelsin";
      this.colHemenAlSecenekSeciliGelsin.ColumnEdit = this.repositoryItemLookUpEdit_SeciliGelsin;
      this.colHemenAlSecenekSeciliGelsin.FieldName = "SeciliGelsin";
      this.colHemenAlSecenekSeciliGelsin.Name = "colHemenAlSecenekSeciliGelsin";
      this.colHemenAlSecenekSeciliGelsin.Visible = true;
      this.colHemenAlSecenekSeciliGelsin.VisibleIndex = 11;
      this.colHemenAlSecenekSeciliGelsin.Width = 92;
      // 
      // repositoryItemLookUpEdit_SeciliGelsin
      // 
      this.repositoryItemLookUpEdit_SeciliGelsin.AutoHeight = false;
      this.repositoryItemLookUpEdit_SeciliGelsin.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_SeciliGelsin.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SeciliGelsinAdi", "SeciliGelsinAdi")});
      this.repositoryItemLookUpEdit_SeciliGelsin.Name = "repositoryItemLookUpEdit_SeciliGelsin";
      // 
      // colHemenAlSecenekSecimZorunlu
      // 
      this.colHemenAlSecenekSecimZorunlu.Caption = "SecimZorunlu";
      this.colHemenAlSecenekSecimZorunlu.ColumnEdit = this.repositoryItemLookUpEdit_SecimZorunlu;
      this.colHemenAlSecenekSecimZorunlu.FieldName = "SecimZorunlu";
      this.colHemenAlSecenekSecimZorunlu.Name = "colHemenAlSecenekSecimZorunlu";
      this.colHemenAlSecenekSecimZorunlu.Visible = true;
      this.colHemenAlSecenekSecimZorunlu.VisibleIndex = 12;
      this.colHemenAlSecenekSecimZorunlu.Width = 92;
      // 
      // repositoryItemLookUpEdit_SecimZorunlu
      // 
      this.repositoryItemLookUpEdit_SecimZorunlu.AutoHeight = false;
      this.repositoryItemLookUpEdit_SecimZorunlu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_SecimZorunlu.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SecimZorunluAdi", "SecimZorunluAdi")});
      this.repositoryItemLookUpEdit_SecimZorunlu.Name = "repositoryItemLookUpEdit_SecimZorunlu";
      // 
      // colHemenAlSecenekSecenekAktif
      // 
      this.colHemenAlSecenekSecenekAktif.Caption = "SecenekAktif";
      this.colHemenAlSecenekSecenekAktif.ColumnEdit = this.repositoryItemLookUpEdit_SecenekAktif;
      this.colHemenAlSecenekSecenekAktif.FieldName = "SecenekAktif";
      this.colHemenAlSecenekSecenekAktif.MaxWidth = 75;
      this.colHemenAlSecenekSecenekAktif.Name = "colHemenAlSecenekSecenekAktif";
      this.colHemenAlSecenekSecenekAktif.Visible = true;
      this.colHemenAlSecenekSecenekAktif.VisibleIndex = 13;
      // 
      // repositoryItemLookUpEdit_SecenekAktif
      // 
      this.repositoryItemLookUpEdit_SecenekAktif.AutoHeight = false;
      this.repositoryItemLookUpEdit_SecenekAktif.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_SecenekAktif.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SecenekAktifAdi", "SecenekAktifAdi")});
      this.repositoryItemLookUpEdit_SecenekAktif.Name = "repositoryItemLookUpEdit_SecenekAktif";
      // 
      // colHemenAlSecenek_SatisFiyatiHesaplamaIslemi
      // 
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.Caption = "SatisFiyatiHesaplamaIslemi";
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.ColumnEdit = this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi;
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.FieldName = "SatisFiyatiHesaplamaIslemi";
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.Name = "colHemenAlSecenek_SatisFiyatiHesaplamaIslemi";
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.Visible = true;
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.VisibleIndex = 4;
      this.colHemenAlSecenek_SatisFiyatiHesaplamaIslemi.Width = 92;
      // 
      // repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi
      // 
      this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.AutoHeight = false;
      this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SatisFiyatiHesaplamaIslemiAdi", "SatisFiyatiHesaplamaIslemiAdi")});
      this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.Name = "repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi";
      // 
      // colSatisFiyatiHesaplamaSayisi
      // 
      this.colSatisFiyatiHesaplamaSayisi.Caption = "SatisFiyatiHesaplamaSayisi";
      this.colSatisFiyatiHesaplamaSayisi.FieldName = "SatisFiyatiHesaplamaSayisi";
      this.colSatisFiyatiHesaplamaSayisi.Name = "colSatisFiyatiHesaplamaSayisi";
      this.colSatisFiyatiHesaplamaSayisi.Visible = true;
      this.colSatisFiyatiHesaplamaSayisi.VisibleIndex = 5;
      this.colSatisFiyatiHesaplamaSayisi.Width = 92;
      // 
      // btnKaydet
      // 
      this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.btnKaydet.Location = new System.Drawing.Point(12, 656);
      this.btnKaydet.Name = "btnKaydet";
      this.btnKaydet.Size = new System.Drawing.Size(372, 23);
      this.btnKaydet.TabIndex = 4;
      this.btnKaydet.Text = "Kaydet";
      this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
      // 
      // simpleButton1
      // 
      this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
      this.simpleButton1.Location = new System.Drawing.Point(410, 656);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(75, 23);
      this.simpleButton1.TabIndex = 5;
      this.simpleButton1.Text = "Sil";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // frmHemenAlUrunSecenekOnTanimDetaylari
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1246, 685);
      this.Controls.Add(this.simpleButton1);
      this.Controls.Add(this.btnKaydet);
      this.Controls.Add(this.gcHemenAlSecenek);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.labelControl1);
      this.Controls.Add(this.txtAciklama);
      this.Controls.Add(this.txtAdi);
      this.Name = "frmHemenAlUrunSecenekOnTanimDetaylari";
      this.Text = "frmHemenAlUrunSecenekOnTanimDetaylari";
      this.Load += new System.EventHandler(this.frmHemenAlUrunSecenekOnTanimDetaylari_Load);
      ((System.ComponentModel.ISupportInitialize)(this.txtAdi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcHemenAlSecenek)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvHemenAlSecenek)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_GoruntulemeSekli)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_StokKontrol)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_UrunFiyatiYerineGecsin)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SeciliGelsin)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SecimZorunlu)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_SecenekAktif)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.TextEdit txtAdi;
    private DevExpress.XtraEditors.TextEdit txtAciklama;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraGrid.GridControl gcHemenAlSecenek;
    private DevExpress.XtraGrid.Views.Grid.GridView gvHemenAlSecenek;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekID;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenALSecenekStokID;
    private DevExpress.XtraGrid.Columns.GridColumn ColHemenAlSecenekSecenekGrubu;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSatirSecenek;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSutunSecenek;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekKavala;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSira;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSatisFiyat;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekStokMiktar;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekGoruntulemeSekli;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_GoruntulemeSekli;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekStokKontrol;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_StokKontrol;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekUrunFiyatiYerineGecsin;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_UrunFiyatiYerineGecsin;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSeciliGelsin;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_SeciliGelsin;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSecimZorunlu;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_SecimZorunlu;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenekSecenekAktif;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_SecenekAktif;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAlSecenek_SatisFiyatiHesaplamaIslemi;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi;
    private DevExpress.XtraGrid.Columns.GridColumn colSatisFiyatiHesaplamaSayisi;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
  }
}