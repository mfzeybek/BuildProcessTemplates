namespace Aresv2.Irsaliye
{
  partial class frmIrsaliyeListesi
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
      this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
      this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
      this.lkpIrsaliyeTipi = new DevExpress.XtraEditors.LookUpEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
      this.txtCariAdi = new DevExpress.XtraEditors.TextEdit();
      this.gcIrsaliye = new DevExpress.XtraGrid.GridControl();
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cbtnFaturalandir = new System.Windows.Forms.ToolStripMenuItem();
      this.gvIrsaliye = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colSecim = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ceSecim = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.colF = new DevExpress.XtraGrid.Columns.GridColumn();
      this.coIrsaliyeID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIrsaliyeNo = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIrsaliyeTipi_ = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIrsaliyeTipi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariKod = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariTanim = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIrsaliyeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colDuzenlemeTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colToplamIndirim = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colToplamKdv = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colToplam = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colNetToplam = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colVadesi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIptal = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colSilindiMi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.btnYazdir = new DevExpress.XtraEditors.SimpleButton();
      this.btnSil = new DevExpress.XtraEditors.SimpleButton();
      this.btnIslemler = new DevExpress.XtraEditors.DropDownButton();
      this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
      this.mbtnYazdir = new DevExpress.XtraBars.BarButtonItem();
      this.mbtnOnizleme = new DevExpress.XtraBars.BarButtonItem();
      this.mbtnDizayn = new DevExpress.XtraBars.BarButtonItem();
      this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
      this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
      this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
      this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
      this.btnCariHareketleri = new DevExpress.XtraEditors.SimpleButton();
      this.btnKaydiAc = new DevExpress.XtraEditors.SimpleButton();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
      this.splitContainerControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.lkpIrsaliyeTipi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtCariAdi.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcIrsaliye)).BeginInit();
      this.contextMenuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gvIrsaliye)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.ceSecim)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      this.panelControl1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
      this.SuspendLayout();
      // 
      // splitContainerControl1
      // 
      this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
      this.splitContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.splitContainerControl1.Name = "splitContainerControl1";
      this.splitContainerControl1.Panel1.Controls.Add(this.xtraScrollableControl1);
      this.splitContainerControl1.Panel1.Controls.Add(this.lkpIrsaliyeTipi);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl2);
      this.splitContainerControl1.Panel1.Controls.Add(this.labelControl1);
      this.splitContainerControl1.Panel1.Controls.Add(this.simpleButton2);
      this.splitContainerControl1.Panel1.Controls.Add(this.btnFiltrele);
      this.splitContainerControl1.Panel1.Controls.Add(this.txtCariAdi);
      this.splitContainerControl1.Panel1.Text = "Panel1";
      this.splitContainerControl1.Panel2.Controls.Add(this.gcIrsaliye);
      this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
      this.splitContainerControl1.Panel2.Text = "Panel2";
      this.splitContainerControl1.Size = new System.Drawing.Size(1098, 481);
      this.splitContainerControl1.SplitterPosition = 205;
      this.splitContainerControl1.TabIndex = 0;
      this.splitContainerControl1.Text = "splitContainerControl1";
      // 
      // xtraScrollableControl1
      // 
      this.xtraScrollableControl1.Location = new System.Drawing.Point(112, 400);
      this.xtraScrollableControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.xtraScrollableControl1.Name = "xtraScrollableControl1";
      this.xtraScrollableControl1.Size = new System.Drawing.Size(87, 28);
      this.xtraScrollableControl1.TabIndex = 5;
      // 
      // lkpIrsaliyeTipi
      // 
      this.lkpIrsaliyeTipi.EditValue = -1;
      this.lkpIrsaliyeTipi.Location = new System.Drawing.Point(80, 53);
      this.lkpIrsaliyeTipi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lkpIrsaliyeTipi.Name = "lkpIrsaliyeTipi";
      this.lkpIrsaliyeTipi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
      this.lkpIrsaliyeTipi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
      this.lkpIrsaliyeTipi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
      this.lkpIrsaliyeTipi.Properties.NullText = "Yok";
      this.lkpIrsaliyeTipi.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
      this.lkpIrsaliyeTipi.Size = new System.Drawing.Size(141, 22);
      this.lkpIrsaliyeTipi.TabIndex = 4;
      this.lkpIrsaliyeTipi.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkpIrsaliyeTipi_ButtonClick);
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(3, 57);
      this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(66, 16);
      this.labelControl2.TabIndex = 3;
      this.labelControl2.Text = "Irsaliye Tipi";
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(3, 25);
      this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(66, 16);
      this.labelControl1.TabIndex = 3;
      this.labelControl1.Text = "Cari Tanımı";
      // 
      // simpleButton2
      // 
      this.simpleButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.simpleButton2.Location = new System.Drawing.Point(88, 348);
      this.simpleButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(65, 28);
      this.simpleButton2.TabIndex = 2;
      this.simpleButton2.Text = "Temizle";
      // 
      // btnFiltrele
      // 
      this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.btnFiltrele.Location = new System.Drawing.Point(14, 348);
      this.btnFiltrele.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnFiltrele.Name = "btnFiltrele";
      this.btnFiltrele.Size = new System.Drawing.Size(67, 28);
      this.btnFiltrele.TabIndex = 1;
      this.btnFiltrele.Text = "Filtrele";
      this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
      // 
      // txtCariAdi
      // 
      this.txtCariAdi.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtCariAdi.Location = new System.Drawing.Point(80, 21);
      this.txtCariAdi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.txtCariAdi.Name = "txtCariAdi";
      this.txtCariAdi.Size = new System.Drawing.Size(73, 22);
      this.txtCariAdi.TabIndex = 0;
      // 
      // gcIrsaliye
      // 
      this.gcIrsaliye.ContextMenuStrip = this.contextMenuStrip1;
      this.gcIrsaliye.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcIrsaliye.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gcIrsaliye.Location = new System.Drawing.Point(0, 46);
      this.gcIrsaliye.MainView = this.gvIrsaliye;
      this.gcIrsaliye.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gcIrsaliye.Name = "gcIrsaliye";
      this.gcIrsaliye.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ceSecim});
      this.gcIrsaliye.Size = new System.Drawing.Size(889, 435);
      this.gcIrsaliye.TabIndex = 4;
      this.gcIrsaliye.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvIrsaliye});
      this.gcIrsaliye.DoubleClick += new System.EventHandler(this.btnKaydiAc_Click);
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbtnFaturalandir});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(158, 28);
      this.contextMenuStrip1.Opened += new System.EventHandler(this.contextMenuStrip1_Opened);
      // 
      // cbtnFaturalandir
      // 
      this.cbtnFaturalandir.Name = "cbtnFaturalandir";
      this.cbtnFaturalandir.Size = new System.Drawing.Size(157, 24);
      this.cbtnFaturalandir.Text = "Faturalandır";
      this.cbtnFaturalandir.Click += new System.EventHandler(this.cbtnFaturalandir_Click);
      // 
      // gvIrsaliye
      // 
      this.gvIrsaliye.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSecim,
            this.colF,
            this.coIrsaliyeID,
            this.colIrsaliyeNo,
            this.colIrsaliyeTipi_,
            this.colIrsaliyeTipi,
            this.colCariID,
            this.colCariKod,
            this.colCariTanim,
            this.colIrsaliyeTarihi,
            this.colDuzenlemeTarihi,
            this.colToplamIndirim,
            this.colToplamKdv,
            this.colToplam,
            this.colNetToplam,
            this.colVadesi,
            this.colIptal,
            this.colSilindiMi,
            this.colAciklama});
      this.gvIrsaliye.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
      this.gvIrsaliye.GridControl = this.gcIrsaliye;
      this.gvIrsaliye.Name = "gvIrsaliye";
      this.gvIrsaliye.OptionsBehavior.AllowIncrementalSearch = true;
      this.gvIrsaliye.OptionsSelection.EnableAppearanceFocusedCell = false;
      this.gvIrsaliye.OptionsSelection.EnableAppearanceFocusedRow = false;
      this.gvIrsaliye.OptionsView.ColumnAutoWidth = false;
      this.gvIrsaliye.OptionsView.EnableAppearanceEvenRow = true;
      this.gvIrsaliye.OptionsView.EnableAppearanceOddRow = true;
      this.gvIrsaliye.OptionsView.ShowGroupPanel = false;
      // 
      // colSecim
      // 
      this.colSecim.Caption = "Secim";
      this.colSecim.ColumnEdit = this.ceSecim;
      this.colSecim.FieldName = "Secim";
      this.colSecim.Name = "colSecim";
      this.colSecim.UnboundType = DevExpress.Data.UnboundColumnType.Boolean;
      this.colSecim.Visible = true;
      this.colSecim.VisibleIndex = 0;
      this.colSecim.Width = 40;
      // 
      // ceSecim
      // 
      this.ceSecim.AutoHeight = false;
      this.ceSecim.Caption = "Check";
      this.ceSecim.Name = "ceSecim";
      // 
      // colF
      // 
      this.colF.Caption = "F";
      this.colF.FieldName = "F";
      this.colF.Name = "colF";
      this.colF.OptionsColumn.AllowEdit = false;
      this.colF.Visible = true;
      this.colF.VisibleIndex = 1;
      // 
      // coIrsaliyeID
      // 
      this.coIrsaliyeID.Caption = "IrsaliyeID";
      this.coIrsaliyeID.FieldName = "IrsaliyeID";
      this.coIrsaliyeID.Name = "coIrsaliyeID";
      this.coIrsaliyeID.OptionsColumn.AllowEdit = false;
      this.coIrsaliyeID.Visible = true;
      this.coIrsaliyeID.VisibleIndex = 2;
      // 
      // colIrsaliyeNo
      // 
      this.colIrsaliyeNo.Caption = "Irsaliye No";
      this.colIrsaliyeNo.FieldName = "IrsaliyeNo";
      this.colIrsaliyeNo.Name = "colIrsaliyeNo";
      this.colIrsaliyeNo.OptionsColumn.AllowEdit = false;
      this.colIrsaliyeNo.Visible = true;
      this.colIrsaliyeNo.VisibleIndex = 3;
      // 
      // colIrsaliyeTipi_
      // 
      this.colIrsaliyeTipi_.Caption = "Irsaliye Tipi";
      this.colIrsaliyeTipi_.FieldName = "IrsaliyeTipi_";
      this.colIrsaliyeTipi_.Name = "colIrsaliyeTipi_";
      this.colIrsaliyeTipi_.OptionsColumn.AllowEdit = false;
      this.colIrsaliyeTipi_.Visible = true;
      this.colIrsaliyeTipi_.VisibleIndex = 4;
      // 
      // colIrsaliyeTipi
      // 
      this.colIrsaliyeTipi.Caption = "IrsaliyeTipi";
      this.colIrsaliyeTipi.FieldName = "IrsaliyeTipi";
      this.colIrsaliyeTipi.Name = "colIrsaliyeTipi";
      this.colIrsaliyeTipi.OptionsColumn.AllowEdit = false;
      // 
      // colCariID
      // 
      this.colCariID.Caption = "CariID";
      this.colCariID.FieldName = "CariID";
      this.colCariID.Name = "colCariID";
      this.colCariID.OptionsColumn.AllowEdit = false;
      // 
      // colCariKod
      // 
      this.colCariKod.Caption = "Cari Kod";
      this.colCariKod.FieldName = "CariKod";
      this.colCariKod.Name = "colCariKod";
      this.colCariKod.OptionsColumn.AllowEdit = false;
      this.colCariKod.Visible = true;
      this.colCariKod.VisibleIndex = 5;
      // 
      // colCariTanim
      // 
      this.colCariTanim.Caption = "Cari Tanım";
      this.colCariTanim.FieldName = "CariTanim";
      this.colCariTanim.Name = "colCariTanim";
      this.colCariTanim.OptionsColumn.AllowEdit = false;
      this.colCariTanim.Visible = true;
      this.colCariTanim.VisibleIndex = 6;
      // 
      // colIrsaliyeTarihi
      // 
      this.colIrsaliyeTarihi.Caption = "İrsaliye Tarihi";
      this.colIrsaliyeTarihi.FieldName = "IrsaliyeTarihi";
      this.colIrsaliyeTarihi.Name = "colIrsaliyeTarihi";
      this.colIrsaliyeTarihi.OptionsColumn.AllowEdit = false;
      this.colIrsaliyeTarihi.Visible = true;
      this.colIrsaliyeTarihi.VisibleIndex = 7;
      // 
      // colDuzenlemeTarihi
      // 
      this.colDuzenlemeTarihi.Caption = "Düzenleme Tarihi";
      this.colDuzenlemeTarihi.FieldName = "DuzenlemeTarihi";
      this.colDuzenlemeTarihi.Name = "colDuzenlemeTarihi";
      this.colDuzenlemeTarihi.OptionsColumn.AllowEdit = false;
      this.colDuzenlemeTarihi.Visible = true;
      this.colDuzenlemeTarihi.VisibleIndex = 8;
      // 
      // colToplamIndirim
      // 
      this.colToplamIndirim.Caption = "Toplam İndirim";
      this.colToplamIndirim.FieldName = "ToplamIndirim";
      this.colToplamIndirim.Name = "colToplamIndirim";
      this.colToplamIndirim.OptionsColumn.AllowEdit = false;
      this.colToplamIndirim.Visible = true;
      this.colToplamIndirim.VisibleIndex = 9;
      // 
      // colToplamKdv
      // 
      this.colToplamKdv.Caption = "Toplam Kdv";
      this.colToplamKdv.FieldName = "ToplamKdv";
      this.colToplamKdv.Name = "colToplamKdv";
      this.colToplamKdv.OptionsColumn.AllowEdit = false;
      this.colToplamKdv.Visible = true;
      this.colToplamKdv.VisibleIndex = 10;
      // 
      // colToplam
      // 
      this.colToplam.Caption = "Toplam";
      this.colToplam.FieldName = "Toplam";
      this.colToplam.Name = "colToplam";
      this.colToplam.OptionsColumn.AllowEdit = false;
      this.colToplam.Visible = true;
      this.colToplam.VisibleIndex = 11;
      // 
      // colNetToplam
      // 
      this.colNetToplam.Caption = "Net Toplam";
      this.colNetToplam.FieldName = "NetToplam";
      this.colNetToplam.Name = "colNetToplam";
      this.colNetToplam.OptionsColumn.AllowEdit = false;
      this.colNetToplam.Visible = true;
      this.colNetToplam.VisibleIndex = 12;
      // 
      // colVadesi
      // 
      this.colVadesi.Caption = "Vadesi";
      this.colVadesi.FieldName = "Vadesi";
      this.colVadesi.Name = "colVadesi";
      this.colVadesi.OptionsColumn.AllowEdit = false;
      this.colVadesi.Visible = true;
      this.colVadesi.VisibleIndex = 13;
      // 
      // colIptal
      // 
      this.colIptal.Caption = "İptal";
      this.colIptal.FieldName = "Iptal";
      this.colIptal.Name = "colIptal";
      this.colIptal.OptionsColumn.AllowEdit = false;
      this.colIptal.Visible = true;
      this.colIptal.VisibleIndex = 14;
      // 
      // colSilindiMi
      // 
      this.colSilindiMi.Caption = "Silindi";
      this.colSilindiMi.FieldName = "SilindiMi";
      this.colSilindiMi.Name = "colSilindiMi";
      this.colSilindiMi.OptionsColumn.AllowEdit = false;
      this.colSilindiMi.Visible = true;
      this.colSilindiMi.VisibleIndex = 15;
      // 
      // colAciklama
      // 
      this.colAciklama.Caption = "Açıklama";
      this.colAciklama.FieldName = "Aciklama";
      this.colAciklama.Name = "colAciklama";
      this.colAciklama.OptionsColumn.AllowEdit = false;
      this.colAciklama.Visible = true;
      this.colAciklama.VisibleIndex = 16;
      // 
      // panelControl1
      // 
      this.panelControl1.Controls.Add(this.btnYazdir);
      this.panelControl1.Controls.Add(this.btnSil);
      this.panelControl1.Controls.Add(this.btnIslemler);
      this.panelControl1.Controls.Add(this.labelControl15);
      this.panelControl1.Controls.Add(this.btnCariHareketleri);
      this.panelControl1.Controls.Add(this.btnKaydiAc);
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl1.Location = new System.Drawing.Point(0, 0);
      this.panelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(889, 46);
      this.panelControl1.TabIndex = 3;
      // 
      // btnYazdir
      // 
      this.btnYazdir.Location = new System.Drawing.Point(157, 9);
      this.btnYazdir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnYazdir.Name = "btnYazdir";
      this.btnYazdir.Size = new System.Drawing.Size(87, 28);
      this.btnYazdir.TabIndex = 12;
      this.btnYazdir.Text = "Yazdır";
      this.btnYazdir.Click += new System.EventHandler(this.btnYazdir_Click);
      // 
      // btnSil
      // 
      this.btnSil.Location = new System.Drawing.Point(415, 9);
      this.btnSil.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnSil.Name = "btnSil";
      this.btnSil.Size = new System.Drawing.Size(87, 28);
      this.btnSil.TabIndex = 11;
      this.btnSil.Text = "Sil";
      this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
      // 
      // btnIslemler
      // 
      this.btnIslemler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnIslemler.DropDownControl = this.popupMenu1;
      this.btnIslemler.Location = new System.Drawing.Point(869, 13);
      this.btnIslemler.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnIslemler.Name = "btnIslemler";
      this.btnIslemler.Size = new System.Drawing.Size(120, 28);
      this.btnIslemler.TabIndex = 5;
      this.btnIslemler.Text = "İşlemler";
      // 
      // popupMenu1
      // 
      this.popupMenu1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtnYazdir),
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtnOnizleme),
            new DevExpress.XtraBars.LinkPersistInfo(this.mbtnDizayn)});
      this.popupMenu1.Manager = this.barManager1;
      this.popupMenu1.Name = "popupMenu1";
      // 
      // mbtnYazdir
      // 
      this.mbtnYazdir.Caption = "Yazdır";
      this.mbtnYazdir.Id = 0;
      this.mbtnYazdir.Name = "mbtnYazdir";
      this.mbtnYazdir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mbtnYazdir_ItemClick);
      // 
      // mbtnOnizleme
      // 
      this.mbtnOnizleme.Caption = "Önizle";
      this.mbtnOnizleme.Id = 1;
      this.mbtnOnizleme.Name = "mbtnOnizleme";
      this.mbtnOnizleme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mbtnOnizleme_ItemClick);
      // 
      // mbtnDizayn
      // 
      this.mbtnDizayn.Caption = "Dizayn";
      this.mbtnDizayn.Id = 2;
      this.mbtnDizayn.Name = "mbtnDizayn";
      this.mbtnDizayn.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.mbtnDizayn_ItemClick);
      // 
      // barManager1
      // 
      this.barManager1.DockControls.Add(this.barDockControlTop);
      this.barManager1.DockControls.Add(this.barDockControlBottom);
      this.barManager1.DockControls.Add(this.barDockControlLeft);
      this.barManager1.DockControls.Add(this.barDockControlRight);
      this.barManager1.Form = this;
      this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.mbtnYazdir,
            this.mbtnOnizleme,
            this.mbtnDizayn});
      this.barManager1.MaxItemId = 3;
      // 
      // barDockControlTop
      // 
      this.barDockControlTop.CausesValidation = false;
      this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
      this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
      this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.barDockControlTop.Size = new System.Drawing.Size(1098, 0);
      // 
      // barDockControlBottom
      // 
      this.barDockControlBottom.CausesValidation = false;
      this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.barDockControlBottom.Location = new System.Drawing.Point(0, 481);
      this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.barDockControlBottom.Size = new System.Drawing.Size(1098, 0);
      // 
      // barDockControlLeft
      // 
      this.barDockControlLeft.CausesValidation = false;
      this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
      this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
      this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.barDockControlLeft.Size = new System.Drawing.Size(0, 481);
      // 
      // barDockControlRight
      // 
      this.barDockControlRight.CausesValidation = false;
      this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
      this.barDockControlRight.Location = new System.Drawing.Point(1098, 0);
      this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.barDockControlRight.Size = new System.Drawing.Size(0, 481);
      // 
      // labelControl15
      // 
      this.labelControl15.Appearance.Font = new System.Drawing.Font("Centaur", 14F, System.Drawing.FontStyle.Bold);
      this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
      this.labelControl15.Location = new System.Drawing.Point(10, 14);
      this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.labelControl15.Name = "labelControl15";
      this.labelControl15.Size = new System.Drawing.Size(135, 25);
      this.labelControl15.TabIndex = 4;
      this.labelControl15.Text = "Irsaliye Listesi";
      // 
      // btnCariHareketleri
      // 
      this.btnCariHareketleri.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCariHareketleri.Location = new System.Drawing.Point(774, 13);
      this.btnCariHareketleri.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnCariHareketleri.Name = "btnCariHareketleri";
      this.btnCariHareketleri.Size = new System.Drawing.Size(87, 28);
      this.btnCariHareketleri.TabIndex = 3;
      this.btnCariHareketleri.Text = "Hareketleri";
      // 
      // btnKaydiAc
      // 
      this.btnKaydiAc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnKaydiAc.Location = new System.Drawing.Point(680, 13);
      this.btnKaydiAc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnKaydiAc.Name = "btnKaydiAc";
      this.btnKaydiAc.Size = new System.Drawing.Size(87, 28);
      this.btnKaydiAc.TabIndex = 3;
      this.btnKaydiAc.Text = "Kaydı Aç ";
      this.btnKaydiAc.Click += new System.EventHandler(this.btnKaydiAc_Click);
      // 
      // frmIrsaliyeListesi
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1098, 481);
      this.Controls.Add(this.splitContainerControl1);
      this.Controls.Add(this.barDockControlLeft);
      this.Controls.Add(this.barDockControlRight);
      this.Controls.Add(this.barDockControlBottom);
      this.Controls.Add(this.barDockControlTop);
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "frmIrsaliyeListesi";
      this.Text = "Irsaliye Listesi";
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmIrsaliyeListesi_FormClosed);
      this.Load += new System.EventHandler(this.frmIrsaliyeListesi_Load);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
      this.splitContainerControl1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.lkpIrsaliyeTipi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtCariAdi.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gcIrsaliye)).EndInit();
      this.contextMenuStrip1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gvIrsaliye)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.ceSecim)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      this.panelControl1.ResumeLayout(false);
      this.panelControl1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    private DevExpress.XtraGrid.GridControl gcIrsaliye;
    private DevExpress.XtraGrid.Views.Grid.GridView gvIrsaliye;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.DropDownButton btnIslemler;
    private DevExpress.XtraEditors.LabelControl labelControl15;
    private DevExpress.XtraEditors.SimpleButton btnCariHareketleri;
    private DevExpress.XtraEditors.SimpleButton btnKaydiAc;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton btnFiltrele;
    private DevExpress.XtraEditors.TextEdit txtCariAdi;
    private DevExpress.XtraEditors.LookUpEdit lkpIrsaliyeTipi;
    private DevExpress.XtraEditors.SimpleButton btnSil;
    private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
    private DevExpress.XtraBars.PopupMenu popupMenu1;
    private DevExpress.XtraBars.BarButtonItem mbtnYazdir;
    private DevExpress.XtraBars.BarButtonItem mbtnOnizleme;
    private DevExpress.XtraBars.BarButtonItem mbtnDizayn;
    private DevExpress.XtraBars.BarManager barManager1;
    private DevExpress.XtraBars.BarDockControl barDockControlTop;
    private DevExpress.XtraBars.BarDockControl barDockControlBottom;
    private DevExpress.XtraBars.BarDockControl barDockControlLeft;
    private DevExpress.XtraBars.BarDockControl barDockControlRight;
		private DevExpress.XtraEditors.SimpleButton btnYazdir;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cbtnFaturalandir;
		private DevExpress.XtraGrid.Columns.GridColumn colSecim;
		private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ceSecim;
		private DevExpress.XtraGrid.Columns.GridColumn colF;
		private DevExpress.XtraGrid.Columns.GridColumn coIrsaliyeID;
		private DevExpress.XtraGrid.Columns.GridColumn colIrsaliyeNo;
		private DevExpress.XtraGrid.Columns.GridColumn colIrsaliyeTipi_;
		private DevExpress.XtraGrid.Columns.GridColumn colIrsaliyeTipi;
		private DevExpress.XtraGrid.Columns.GridColumn colCariID;
		private DevExpress.XtraGrid.Columns.GridColumn colCariKod;
		private DevExpress.XtraGrid.Columns.GridColumn colCariTanim;
		private DevExpress.XtraGrid.Columns.GridColumn colIrsaliyeTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colDuzenlemeTarihi;
		private DevExpress.XtraGrid.Columns.GridColumn colToplamIndirim;
		private DevExpress.XtraGrid.Columns.GridColumn colToplamKdv;
		private DevExpress.XtraGrid.Columns.GridColumn colToplam;
		private DevExpress.XtraGrid.Columns.GridColumn colNetToplam;
		private DevExpress.XtraGrid.Columns.GridColumn colVadesi;
		private DevExpress.XtraGrid.Columns.GridColumn colIptal;
		private DevExpress.XtraGrid.Columns.GridColumn colSilindiMi;
		private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
  }
}