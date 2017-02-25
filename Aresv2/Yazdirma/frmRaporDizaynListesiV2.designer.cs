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
            this.gcRaporDizayn = new DevExpress.XtraGrid.GridControl();
            this.gvRaporDizayn = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRaporDizaynYolu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVarsayilanMi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.colKagitKaynagi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYaziciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKagitKaynagiIndex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAyarlar = new DevExpress.XtraEditors.SimpleButton();
            this.btnYaziciAyarlari = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdirmaDiyalogu = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnOnizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcRaporDizayn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRaporDizayn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gcRaporDizayn
            // 
            this.gcRaporDizayn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcRaporDizayn.Location = new System.Drawing.Point(0, 0);
            this.gcRaporDizayn.MainView = this.gvRaporDizayn;
            this.gcRaporDizayn.Name = "gcRaporDizayn";
            this.gcRaporDizayn.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gcRaporDizayn.Size = new System.Drawing.Size(959, 266);
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
            this.gvRaporDizayn.OptionsDetail.DetailMode = DevExpress.XtraGrid.Views.Grid.DetailMode.Embedded;
            this.gvRaporDizayn.OptionsDetail.SmartDetailHeight = true;
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnAyarlar);
            this.panelControl1.Controls.Add(this.btnYaziciAyarlari);
            this.panelControl1.Controls.Add(this.btnTamam);
            this.panelControl1.Controls.Add(this.btnYazdirmaDiyalogu);
            this.panelControl1.Controls.Add(this.btnSil);
            this.panelControl1.Controls.Add(this.btnEkle);
            this.panelControl1.Controls.Add(this.btnDuzenle);
            this.panelControl1.Controls.Add(this.btnOnizle);
            this.panelControl1.Controls.Add(this.btnYazdir);
            this.panelControl1.Controls.Add(this.btnIptal);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 266);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(959, 36);
            this.panelControl1.TabIndex = 1;
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Location = new System.Drawing.Point(306, 4);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(75, 23);
            this.btnAyarlar.TabIndex = 6;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnYaziciAyarlari
            // 
            this.btnYaziciAyarlari.Location = new System.Drawing.Point(590, 5);
            this.btnYaziciAyarlari.Name = "btnYaziciAyarlari";
            this.btnYaziciAyarlari.Size = new System.Drawing.Size(75, 23);
            this.btnYaziciAyarlari.TabIndex = 5;
            this.btnYaziciAyarlari.Text = "YaziciAyarlari";
            this.btnYaziciAyarlari.Visible = false;
            this.btnYaziciAyarlari.Click += new System.EventHandler(this.btnYaziciAyarlari_Click);
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(791, 4);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(75, 23);
            this.btnTamam.TabIndex = 4;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnYazdirmaDiyalogu
            // 
            this.btnYazdirmaDiyalogu.Location = new System.Drawing.Point(165, 4);
            this.btnYazdirmaDiyalogu.Name = "btnYazdirmaDiyalogu";
            this.btnYazdirmaDiyalogu.Size = new System.Drawing.Size(75, 23);
            this.btnYazdirmaDiyalogu.TabIndex = 3;
            this.btnYazdirmaDiyalogu.Text = "Y. Diyaloğu";
            this.btnYazdirmaDiyalogu.Click += new System.EventHandler(this.btnYazdirmaDiyalogu_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(509, 4);
            this.btnSil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 2;
            this.btnSil.Text = "Sil";
            this.btnSil.Visible = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(429, 4);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(75, 23);
            this.btnEkle.TabIndex = 2;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Visible = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(671, 4);
            this.btnDuzenle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(86, 23);
            this.btnDuzenle.TabIndex = 2;
            this.btnDuzenle.Text = "Formu Düzenle";
            this.btnDuzenle.Visible = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnOnizle
            // 
            this.btnOnizle.Location = new System.Drawing.Point(3, 4);
            this.btnOnizle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOnizle.Name = "btnOnizle";
            this.btnOnizle.Size = new System.Drawing.Size(75, 23);
            this.btnOnizle.TabIndex = 2;
            this.btnOnizle.Text = "Önizle";
            this.btnOnizle.Click += new System.EventHandler(this.btnOnizle_Click);
            // 
            // btnYazdir
            // 
            this.btnYazdir.Location = new System.Drawing.Point(84, 4);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(75, 23);
            this.btnYazdir.TabIndex = 1;
            this.btnYazdir.Text = "Yazdır";
            this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(872, 4);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(75, 23);
            this.btnIptal.TabIndex = 0;
            this.btnIptal.Text = "İptal";
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // frmRaporDizaynListesiv2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 302);
            this.Controls.Add(this.gcRaporDizayn);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRaporDizaynListesiv2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rapor Dizayn";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmRaporDizaynListesiv2_FormClosing);
            this.Load += new System.EventHandler(this.frmRaporDizaynListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcRaporDizayn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvRaporDizayn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.PanelControl panelControl1;
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
    }
}