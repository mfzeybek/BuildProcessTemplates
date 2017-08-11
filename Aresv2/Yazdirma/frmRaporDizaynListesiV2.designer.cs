namespace Aresv2
{
  partial class frmRaporDizaynListesiv2
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
            this.gcRaporDizayn = new DevExpress.XtraGrid.GridControl();
            this.gvRaporDizayn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRaporDizaynYolu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarsayilanMi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colKagitKaynagi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYaziciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKagitKaynagiIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAyarlar = new DevExpress.XtraEditors.SimpleButton();
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnYaziciAyarlari = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdirmaDiyalogu = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem11 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem12 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gcRaporDizayn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRaporDizayn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout)).BeginInit();
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // gcRaporDizayn
            // 
            this.gcRaporDizayn.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gcRaporDizayn.Location = new System.Drawing.Point(14, 14);
            this.gcRaporDizayn.MainView = this.gvRaporDizayn;
            this.gcRaporDizayn.Margin = new System.Windows.Forms.Padding(6);
            this.gcRaporDizayn.Name = "gcRaporDizayn";
            this.gcRaporDizayn.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcRaporDizayn.Size = new System.Drawing.Size(2280, 998);
            this.gcRaporDizayn.TabIndex = 0;
            this.gcRaporDizayn.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvRaporDizayn});
            this.gcRaporDizayn.Click += new System.EventHandler(this.gcRaporDizayn_Click);
            // 
            // gvRaporDizayn
            // 
            this.gvRaporDizayn.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAciklama,
            this.colRaporDizaynYolu,
            this.colVarsayilanMi,
            this.colKagitKaynagi,
            this.colYaziciAdi,
            this.colKagitKaynagiIndex});
            this.gvRaporDizayn.GridControl = this.gcRaporDizayn;
            this.gvRaporDizayn.Name = "gvRaporDizayn";
            this.gvRaporDizayn.OptionsFilter.UseNewCustomFilterDialog = true;
            this.gvRaporDizayn.OptionsFind.AlwaysVisible = true;
            this.gvRaporDizayn.OptionsFind.FindFilterColumns = "Aciklama";
            this.gvRaporDizayn.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gvRaporDizayn.OptionsFind.FindNullPrompt = "Buraya aradığın tasarımın açıklamasını gir hamısına";
            this.gvRaporDizayn.OptionsView.ColumnAutoWidth = false;
            this.gvRaporDizayn.OptionsView.ShowGroupPanel = false;
            this.gvRaporDizayn.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvRaporDizayn_CellValueChanged);
            this.gvRaporDizayn.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvRaporDizayn_CellValueChanging);
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 0;
            this.colAciklama.Width = 201;
            // 
            // colRaporDizaynYolu
            // 
            this.colRaporDizaynYolu.Caption = "Yolu";
            this.colRaporDizaynYolu.FieldName = "RaporDizaynYolu";
            this.colRaporDizaynYolu.Name = "colRaporDizaynYolu";
            this.colRaporDizaynYolu.OptionsColumn.AllowEdit = false;
            this.colRaporDizaynYolu.OptionsFilter.AllowAutoFilter = false;
            this.colRaporDizaynYolu.OptionsFilter.AllowFilter = false;
            this.colRaporDizaynYolu.Visible = true;
            this.colRaporDizaynYolu.VisibleIndex = 1;
            this.colRaporDizaynYolu.Width = 262;
            // 
            // colVarsayilanMi
            // 
            this.colVarsayilanMi.Caption = "Varsayılan Mı";
            this.colVarsayilanMi.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colVarsayilanMi.FieldName = "VarsayilanMi";
            this.colVarsayilanMi.Name = "colVarsayilanMi";
            this.colVarsayilanMi.OptionsFilter.AllowAutoFilter = false;
            this.colVarsayilanMi.OptionsFilter.AllowFilter = false;
            this.colVarsayilanMi.Width = 100;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AccessibleRole = System.Windows.Forms.AccessibleRole.RadioButton;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Caption = "Check";
            this.repositoryItemCheckEdit1.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Unchecked;
            this.repositoryItemCheckEdit1.RadioGroupIndex = 1;
            this.repositoryItemCheckEdit1.ValueGrayed = "False";
            // 
            // colKagitKaynagi
            // 
            this.colKagitKaynagi.Caption = "KagitKaynagi";
            this.colKagitKaynagi.FieldName = "KagitKaynagi";
            this.colKagitKaynagi.Name = "colKagitKaynagi";
            this.colKagitKaynagi.OptionsColumn.AllowEdit = false;
            this.colKagitKaynagi.Visible = true;
            this.colKagitKaynagi.VisibleIndex = 3;
            this.colKagitKaynagi.Width = 134;
            // 
            // colYaziciAdi
            // 
            this.colYaziciAdi.Caption = "YaziciAdi";
            this.colYaziciAdi.FieldName = "YaziciAdi";
            this.colYaziciAdi.Name = "colYaziciAdi";
            this.colYaziciAdi.OptionsColumn.AllowEdit = false;
            this.colYaziciAdi.Visible = true;
            this.colYaziciAdi.VisibleIndex = 2;
            this.colYaziciAdi.Width = 161;
            // 
            // colKagitKaynagiIndex
            // 
            this.colKagitKaynagiIndex.Caption = "KagitKaynagiIndex";
            this.colKagitKaynagiIndex.FieldName = "KagitKaynagiIndex";
            this.colKagitKaynagiIndex.Name = "colKagitKaynagiIndex";
            this.colKagitKaynagiIndex.OptionsColumn.AllowEdit = false;
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnAyarlar.Appearance.Options.UseFont = true;
            this.btnAyarlar.Location = new System.Drawing.Point(948, 1020);
            this.btnAyarlar.Margin = new System.Windows.Forms.Padding(6);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(218, 59);
            this.btnAyarlar.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnAyarlar.TabIndex = 6;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // frmRaporDizaynListesiv2layoutControl1ConvertedLayout
            // 
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnIptal);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnTamam);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnYaziciAyarlari);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnDuzenle);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnAyarlar);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnSil);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnEkle);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnYazdirmaDiyalogu);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.gcRaporDizayn);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnOnizle);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Controls.Add(this.btnYazdir);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Name = "frmRaporDizaynListesiv2layoutControl1ConvertedLayout";
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1005, 376, 900, 920);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.Size = new System.Drawing.Size(2308, 1105);
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnIptal.Appearance.Options.UseFont = true;
            this.btnIptal.Location = new System.Drawing.Point(2104, 1020);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(6);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(190, 59);
            this.btnIptal.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnTamam.Appearance.Options.UseFont = true;
            this.btnTamam.Location = new System.Drawing.Point(1906, 1020);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(6);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(190, 59);
            this.btnTamam.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnTamam.TabIndex = 4;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnYaziciAyarlari
            // 
            this.btnYaziciAyarlari.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnYaziciAyarlari.Appearance.Options.UseFont = true;
            this.btnYaziciAyarlari.Location = new System.Drawing.Point(472, 1020);
            this.btnYaziciAyarlari.Margin = new System.Windows.Forms.Padding(6);
            this.btnYaziciAyarlari.Name = "btnYaziciAyarlari";
            this.btnYaziciAyarlari.Size = new System.Drawing.Size(243, 59);
            this.btnYaziciAyarlari.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnYaziciAyarlari.TabIndex = 5;
            this.btnYaziciAyarlari.Text = "YaziciAyarlari";
            this.btnYaziciAyarlari.Visible = false;
            this.btnYaziciAyarlari.Click += new System.EventHandler(this.btnYaziciAyarlari_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnDuzenle.Appearance.Options.UseFont = true;
            this.btnDuzenle.Location = new System.Drawing.Point(1613, 1026);
            this.btnDuzenle.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(279, 59);
            this.btnDuzenle.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "Formu Düzenle";
            this.btnDuzenle.Visible = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnSil.Appearance.Options.UseFont = true;
            this.btnSil.Location = new System.Drawing.Point(1401, 1026);
            this.btnSil.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(204, 59);
            this.btnSil.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.Visible = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnEkle.Appearance.Options.UseFont = true;
            this.btnEkle.Location = new System.Drawing.Point(1180, 1026);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(213, 59);
            this.btnEkle.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Visible = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnYazdirmaDiyalogu
            // 
            this.btnYazdirmaDiyalogu.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnYazdirmaDiyalogu.Appearance.Options.UseFont = true;
            this.btnYazdirmaDiyalogu.Location = new System.Drawing.Point(723, 1020);
            this.btnYazdirmaDiyalogu.Margin = new System.Windows.Forms.Padding(6);
            this.btnYazdirmaDiyalogu.Name = "btnYazdirmaDiyalogu";
            this.btnYazdirmaDiyalogu.Size = new System.Drawing.Size(217, 59);
            this.btnYazdirmaDiyalogu.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnYazdirmaDiyalogu.TabIndex = 3;
            this.btnYazdirmaDiyalogu.Text = "Y. Diyaloğu";
            this.btnYazdirmaDiyalogu.Click += new System.EventHandler(this.btnYazdirmaDiyalogu_Click);
            // 
            // btnOnizle
            // 
            this.btnOnizle.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnOnizle.Appearance.Options.UseFont = true;
            this.btnOnizle.Location = new System.Drawing.Point(14, 1020);
            this.btnOnizle.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnOnizle.Name = "btnOnizle";
            this.btnOnizle.Size = new System.Drawing.Size(221, 59);
            this.btnOnizle.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnOnizle.TabIndex = 2;
            this.btnOnizle.Text = "Önizle";
            this.btnOnizle.Click += new System.EventHandler(this.btnOnizle_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnYazdir.Appearance.Options.UseFont = true;
            this.btnYazdir.Location = new System.Drawing.Point(243, 1020);
            this.btnYazdir.Margin = new System.Windows.Forms.Padding(6);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(221, 59);
            this.btnYazdir.StyleController = this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
            this.btnYazdir.TabIndex = 1;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem9,
            this.layoutControlItem11,
            this.layoutControlItem12,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(2308, 1105);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.BestFitWeight = 60;
            this.layoutControlItem1.Control = this.gcRaporDizayn;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(108, 28);
            this.layoutControlItem1.Name = "gcRaporDizaynitem";
            this.layoutControlItem1.Size = new System.Drawing.Size(2288, 1006);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.BestFitWeight = 40;
            this.layoutControlItem3.Control = this.btnOnizle;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 1006);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(229, 79);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.BestFitWeight = 40;
            this.layoutControlItem4.Control = this.btnYazdir;
            this.layoutControlItem4.Location = new System.Drawing.Point(229, 1006);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(229, 79);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.BestFitWeight = 40;
            this.layoutControlItem5.Control = this.btnYazdirmaDiyalogu;
            this.layoutControlItem5.Location = new System.Drawing.Point(709, 1006);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(225, 79);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.BestFitWeight = 40;
            this.layoutControlItem6.Control = this.btnAyarlar;
            this.layoutControlItem6.Location = new System.Drawing.Point(934, 1006);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(226, 79);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.BestFitWeight = 40;
            this.layoutControlItem9.Control = this.btnYaziciAyarlari;
            this.layoutControlItem9.Location = new System.Drawing.Point(458, 1006);
            this.layoutControlItem9.Name = "layoutControlItem9";
            this.layoutControlItem9.Size = new System.Drawing.Size(251, 79);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem11
            // 
            this.layoutControlItem11.BestFitWeight = 40;
            this.layoutControlItem11.Control = this.btnTamam;
            this.layoutControlItem11.Location = new System.Drawing.Point(1892, 1006);
            this.layoutControlItem11.Name = "layoutControlItem11";
            this.layoutControlItem11.Size = new System.Drawing.Size(198, 79);
            this.layoutControlItem11.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem11.TextVisible = false;
            // 
            // layoutControlItem12
            // 
            this.layoutControlItem12.BestFitWeight = 40;
            this.layoutControlItem12.Control = this.btnIptal;
            this.layoutControlItem12.Location = new System.Drawing.Point(2090, 1006);
            this.layoutControlItem12.Name = "layoutControlItem12";
            this.layoutControlItem12.Size = new System.Drawing.Size(198, 79);
            this.layoutControlItem12.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem12.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem7,
            this.layoutControlItem8,
            this.layoutControlItem10});
            this.layoutControlGroup2.Location = new System.Drawing.Point(1160, 1006);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(732, 79);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.BestFitWeight = 40;
            this.layoutControlItem7.Control = this.btnEkle;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(221, 67);
            this.layoutControlItem7.Text = "lcEkle";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.BestFitWeight = 40;
            this.layoutControlItem8.Control = this.btnSil;
            this.layoutControlItem8.Location = new System.Drawing.Point(221, 0);
            this.layoutControlItem8.Name = "layoutControlItem8";
            this.layoutControlItem8.Size = new System.Drawing.Size(212, 67);
            this.layoutControlItem8.Text = "lcSil";
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.BestFitWeight = 40;
            this.layoutControlItem10.Control = this.btnDuzenle;
            this.layoutControlItem10.Location = new System.Drawing.Point(433, 0);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(287, 67);
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // frmRaporDizaynListesiv2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2308, 1105);
            this.Controls.Add(this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.Name = "frmRaporDizaynListesiv2";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor Dizayn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRaporDizaynListesiv2_FormClosing);
            this.Load += new System.EventHandler(this.frmRaporDizaynListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcRaporDizayn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRaporDizayn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout)).EndInit();
            this.frmRaporDizaynListesiv2layoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion
    public DevExpress.XtraGrid.GridControl gcRaporDizayn;
    public DevExpress.XtraEditors.SimpleButton btnEkle;
    public DevExpress.XtraEditors.SimpleButton btnDuzenle;
    public DevExpress.XtraEditors.SimpleButton btnOnizle;
    public DevExpress.XtraEditors.SimpleButton btnSil;
    public DevExpress.XtraEditors.SimpleButton btnYazdir;
    public DevExpress.XtraEditors.SimpleButton btnIptal;
    public DevExpress.XtraGrid.Views.Grid.GridView gvRaporDizayn;
    private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colRaporDizaynYolu;
    private DevExpress.XtraGrid.Columns.GridColumn colVarsayilanMi;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    public DevExpress.XtraEditors.SimpleButton btnYazdirmaDiyalogu;
        public DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnYaziciAyarlari;
        private DevExpress.XtraEditors.SimpleButton btnAyarlar;
        private DevExpress.XtraGrid.Columns.GridColumn colKagitKaynagi;
        private DevExpress.XtraGrid.Columns.GridColumn colYaziciAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colKagitKaynagiIndex;
        private DevExpress.XtraLayout.LayoutControl frmRaporDizaynListesiv2layoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem11;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem12;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
    }
}