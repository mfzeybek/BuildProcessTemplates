namespace Aresv2.HemenAl
{
  partial class frmHemenAlKategori
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
      this.gcHemenAldakiKategoriler = new DevExpress.XtraGrid.GridControl();
      this.gvHemenAldakiKategoriler = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colHemenAl_id = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAl_KategoriAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAl_Aktif = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAl_Aktif_Bayi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAl_entKod = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHemenAl_ustKategoriID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit_HemenAl_UstKategori = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colHemenAl_sira = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
      this.txtAresHemenAlKategoriAdi = new DevExpress.XtraEditors.TextEdit();
      this.lkpAresHemenAlUstKategori = new DevExpress.XtraEditors.LookUpEdit();
      this.btnAresHemenAlKategoriKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
      this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
      this.btnHemenAldakiKategorileriYenile = new DevExpress.XtraEditors.SimpleButton();
      this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
      this.treeList1 = new DevExpress.XtraTreeList.TreeList();
      this.btnGonder = new DevExpress.XtraEditors.SimpleButton();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
      this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
      this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
      ((System.ComponentModel.ISupportInitialize)(this.gcHemenAldakiKategoriler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvHemenAldakiKategoriler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_HemenAl_UstKategori)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresHemenAlKategoriAdi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.lkpAresHemenAlUstKategori.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
      this.groupControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
      this.groupControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
      this.xtraTabControl1.SuspendLayout();
      this.xtraTabPage1.SuspendLayout();
      this.xtraTabPage2.SuspendLayout();
      this.SuspendLayout();
      // 
      // gcHemenAldakiKategoriler
      // 
      this.gcHemenAldakiKategoriler.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.gcHemenAldakiKategoriler.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.gcHemenAldakiKategoriler.Location = new System.Drawing.Point(5, 26);
      this.gcHemenAldakiKategoriler.MainView = this.gvHemenAldakiKategoriler;
      this.gcHemenAldakiKategoriler.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.gcHemenAldakiKategoriler.Name = "gcHemenAldakiKategoriler";
      this.gcHemenAldakiKategoriler.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1,
            this.repositoryItemLookUpEdit_HemenAl_UstKategori});
      this.gcHemenAldakiKategoriler.Size = new System.Drawing.Size(1335, 598);
      this.gcHemenAldakiKategoriler.TabIndex = 0;
      this.gcHemenAldakiKategoriler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvHemenAldakiKategoriler});
      // 
      // gvHemenAldakiKategoriler
      // 
      this.gvHemenAldakiKategoriler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colHemenAl_id,
            this.colHemenAl_KategoriAdi,
            this.colHemenAl_Aktif,
            this.colHemenAl_Aktif_Bayi,
            this.colHemenAl_entKod,
            this.colHemenAl_ustKategoriID,
            this.colHemenAl_sira});
      this.gvHemenAldakiKategoriler.GridControl = this.gcHemenAldakiKategoriler;
      this.gvHemenAldakiKategoriler.Name = "gvHemenAldakiKategoriler";
      this.gvHemenAldakiKategoriler.OptionsBehavior.Editable = false;
      this.gvHemenAldakiKategoriler.OptionsBehavior.ReadOnly = true;
      // 
      // colHemenAl_id
      // 
      this.colHemenAl_id.Caption = "id";
      this.colHemenAl_id.FieldName = "id";
      this.colHemenAl_id.Name = "colHemenAl_id";
      this.colHemenAl_id.Visible = true;
      this.colHemenAl_id.VisibleIndex = 0;
      // 
      // colHemenAl_KategoriAdi
      // 
      this.colHemenAl_KategoriAdi.Caption = "KategoriAdi";
      this.colHemenAl_KategoriAdi.FieldName = "KategoriAdi";
      this.colHemenAl_KategoriAdi.Name = "colHemenAl_KategoriAdi";
      this.colHemenAl_KategoriAdi.Visible = true;
      this.colHemenAl_KategoriAdi.VisibleIndex = 1;
      // 
      // colHemenAl_Aktif
      // 
      this.colHemenAl_Aktif.Caption = "Aktif";
      this.colHemenAl_Aktif.FieldName = "Aktif";
      this.colHemenAl_Aktif.Name = "colHemenAl_Aktif";
      this.colHemenAl_Aktif.Visible = true;
      this.colHemenAl_Aktif.VisibleIndex = 2;
      // 
      // colHemenAl_Aktif_Bayi
      // 
      this.colHemenAl_Aktif_Bayi.Caption = "Aktif_Bayi";
      this.colHemenAl_Aktif_Bayi.FieldName = "Aktif_Bayi";
      this.colHemenAl_Aktif_Bayi.Name = "colHemenAl_Aktif_Bayi";
      this.colHemenAl_Aktif_Bayi.Visible = true;
      this.colHemenAl_Aktif_Bayi.VisibleIndex = 3;
      // 
      // colHemenAl_entKod
      // 
      this.colHemenAl_entKod.Caption = "entKod";
      this.colHemenAl_entKod.FieldName = "entKod";
      this.colHemenAl_entKod.Name = "colHemenAl_entKod";
      this.colHemenAl_entKod.Visible = true;
      this.colHemenAl_entKod.VisibleIndex = 4;
      // 
      // colHemenAl_ustKategoriID
      // 
      this.colHemenAl_ustKategoriID.Caption = "ustKategoriID";
      this.colHemenAl_ustKategoriID.ColumnEdit = this.repositoryItemLookUpEdit_HemenAl_UstKategori;
      this.colHemenAl_ustKategoriID.FieldName = "ustKategoriID";
      this.colHemenAl_ustKategoriID.Name = "colHemenAl_ustKategoriID";
      this.colHemenAl_ustKategoriID.Visible = true;
      this.colHemenAl_ustKategoriID.VisibleIndex = 5;
      // 
      // repositoryItemLookUpEdit_HemenAl_UstKategori
      // 
      this.repositoryItemLookUpEdit_HemenAl_UstKategori.AutoHeight = false;
      this.repositoryItemLookUpEdit_HemenAl_UstKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit_HemenAl_UstKategori.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KategoriAdi", "Name2")});
      this.repositoryItemLookUpEdit_HemenAl_UstKategori.Name = "repositoryItemLookUpEdit_HemenAl_UstKategori";
      // 
      // colHemenAl_sira
      // 
      this.colHemenAl_sira.Caption = "sira";
      this.colHemenAl_sira.FieldName = "sira";
      this.colHemenAl_sira.Name = "colHemenAl_sira";
      this.colHemenAl_sira.Visible = true;
      this.colHemenAl_sira.VisibleIndex = 6;
      // 
      // repositoryItemImageComboBox1
      // 
      this.repositoryItemImageComboBox1.AutoHeight = false;
      this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
      // 
      // txtAresHemenAlKategoriAdi
      // 
      this.txtAresHemenAlKategoriAdi.Location = new System.Drawing.Point(191, 630);
      this.txtAresHemenAlKategoriAdi.Name = "txtAresHemenAlKategoriAdi";
      this.txtAresHemenAlKategoriAdi.Size = new System.Drawing.Size(316, 22);
      this.txtAresHemenAlKategoriAdi.TabIndex = 8;
      // 
      // lkpAresHemenAlUstKategori
      // 
      this.lkpAresHemenAlUstKategori.Location = new System.Drawing.Point(5, 630);
      this.lkpAresHemenAlUstKategori.Name = "lkpAresHemenAlUstKategori";
      this.lkpAresHemenAlUstKategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
      this.lkpAresHemenAlUstKategori.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("KategoriAdi", "KategoriAdi")});
      this.lkpAresHemenAlUstKategori.Size = new System.Drawing.Size(180, 22);
      this.lkpAresHemenAlUstKategori.TabIndex = 9;
      this.lkpAresHemenAlUstKategori.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkpAresHemenAlUstKategori_ButtonClick);
      // 
      // btnAresHemenAlKategoriKaydet
      // 
      this.btnAresHemenAlKategoriKaydet.Location = new System.Drawing.Point(513, 629);
      this.btnAresHemenAlKategoriKaydet.Name = "btnAresHemenAlKategoriKaydet";
      this.btnAresHemenAlKategoriKaydet.Size = new System.Drawing.Size(75, 23);
      this.btnAresHemenAlKategoriKaydet.TabIndex = 10;
      this.btnAresHemenAlKategoriKaydet.Text = "Kaydet";
      this.btnAresHemenAlKategoriKaydet.Click += new System.EventHandler(this.btnAresHemenAlKategoriKaydet_Click);
      // 
      // simpleButton4
      // 
      this.simpleButton4.Location = new System.Drawing.Point(594, 629);
      this.simpleButton4.Name = "simpleButton4";
      this.simpleButton4.Size = new System.Drawing.Size(75, 23);
      this.simpleButton4.TabIndex = 10;
      this.simpleButton4.Text = "Sil";
      this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
      // 
      // groupControl1
      // 
      this.groupControl1.Controls.Add(this.btnHemenAldakiKategorileriYenile);
      this.groupControl1.Controls.Add(this.gcHemenAldakiKategoriler);
      this.groupControl1.Location = new System.Drawing.Point(3, 3);
      this.groupControl1.Name = "groupControl1";
      this.groupControl1.Size = new System.Drawing.Size(1345, 657);
      this.groupControl1.TabIndex = 11;
      this.groupControl1.Text = "Hemen Al Kategori";
      // 
      // btnHemenAldakiKategorileriYenile
      // 
      this.btnHemenAldakiKategorileriYenile.Location = new System.Drawing.Point(5, 629);
      this.btnHemenAldakiKategorileriYenile.Name = "btnHemenAldakiKategorileriYenile";
      this.btnHemenAldakiKategorileriYenile.Size = new System.Drawing.Size(1335, 23);
      this.btnHemenAldakiKategorileriYenile.TabIndex = 1;
      this.btnHemenAldakiKategorileriYenile.Text = "Yenile";
      this.btnHemenAldakiKategorileriYenile.Click += new System.EventHandler(this.btnHemenAldakiKategorileriYenile_Click);
      // 
      // groupControl2
      // 
      this.groupControl2.Controls.Add(this.treeList1);
      this.groupControl2.Controls.Add(this.btnGonder);
      this.groupControl2.Controls.Add(this.simpleButton1);
      this.groupControl2.Controls.Add(this.lkpAresHemenAlUstKategori);
      this.groupControl2.Controls.Add(this.simpleButton4);
      this.groupControl2.Controls.Add(this.txtAresHemenAlKategoriAdi);
      this.groupControl2.Controls.Add(this.btnAresHemenAlKategoriKaydet);
      this.groupControl2.Location = new System.Drawing.Point(3, 3);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new System.Drawing.Size(1345, 657);
      this.groupControl2.TabIndex = 12;
      this.groupControl2.Text = "Ares Hemen Al Kategori";
      // 
      // treeList1
      // 
      this.treeList1.Location = new System.Drawing.Point(5, 27);
      this.treeList1.Name = "treeList1";
      this.treeList1.Size = new System.Drawing.Size(1326, 596);
      this.treeList1.TabIndex = 12;
      // 
      // btnGonder
      // 
      this.btnGonder.Location = new System.Drawing.Point(756, 629);
      this.btnGonder.Name = "btnGonder";
      this.btnGonder.Size = new System.Drawing.Size(75, 23);
      this.btnGonder.TabIndex = 11;
      this.btnGonder.Text = "Gönder";
      this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(675, 629);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(75, 23);
      this.simpleButton1.TabIndex = 11;
      this.simpleButton1.Text = "Esitle";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // xtraTabControl1
      // 
      this.xtraTabControl1.Location = new System.Drawing.Point(17, 12);
      this.xtraTabControl1.Name = "xtraTabControl1";
      this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
      this.xtraTabControl1.Size = new System.Drawing.Size(1357, 694);
      this.xtraTabControl1.TabIndex = 8;
      this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
      // 
      // xtraTabPage1
      // 
      this.xtraTabPage1.Controls.Add(this.groupControl1);
      this.xtraTabPage1.Name = "xtraTabPage1";
      this.xtraTabPage1.Size = new System.Drawing.Size(1352, 666);
      this.xtraTabPage1.Text = "Hemen Aldaki Kategoriler";
      // 
      // xtraTabPage2
      // 
      this.xtraTabPage2.Controls.Add(this.groupControl2);
      this.xtraTabPage2.Name = "xtraTabPage2";
      this.xtraTabPage2.Size = new System.Drawing.Size(1351, 663);
      this.xtraTabPage2.Text = "Aresteki Hemen Al Kategorileri";
      // 
      // frmHemenAlKategori
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1386, 727);
      this.Controls.Add(this.xtraTabControl1);
      this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.Name = "frmHemenAlKategori";
      this.Text = "frmHemenAlKategori";
      this.Load += new System.EventHandler(this.frmHemenAlKategori_Load);
      ((System.ComponentModel.ISupportInitialize)(this.gcHemenAldakiKategoriler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvHemenAldakiKategoriler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_HemenAl_UstKategori)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresHemenAlKategoriAdi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.lkpAresHemenAlUstKategori.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
      this.groupControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
      this.groupControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
      this.xtraTabControl1.ResumeLayout(false);
      this.xtraTabPage1.ResumeLayout(false);
      this.xtraTabPage2.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcHemenAldakiKategoriler;
    private DevExpress.XtraGrid.Views.Grid.GridView gvHemenAldakiKategoriler;
    private DevExpress.XtraEditors.TextEdit txtAresHemenAlKategoriAdi;
    private DevExpress.XtraEditors.LookUpEdit lkpAresHemenAlUstKategori;
    private DevExpress.XtraEditors.SimpleButton btnAresHemenAlKategoriKaydet;
    private DevExpress.XtraEditors.SimpleButton simpleButton4;
    private DevExpress.XtraEditors.GroupControl groupControl1;
    private DevExpress.XtraEditors.GroupControl groupControl2;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_id;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_KategoriAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_Aktif;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_Aktif_Bayi;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_entKod;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_ustKategoriID;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_HemenAl_UstKategori;
    private DevExpress.XtraGrid.Columns.GridColumn colHemenAl_sira;
    private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    private DevExpress.XtraEditors.SimpleButton btnGonder;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    private DevExpress.XtraEditors.SimpleButton btnHemenAldakiKategorileriYenile;
    private DevExpress.XtraTreeList.TreeList treeList1;
  }
}