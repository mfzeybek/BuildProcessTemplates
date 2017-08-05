namespace Aresv2.Stok
{
  partial class frmStokSayim
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
            this.gcSayim = new DevExpress.XtraGrid.GridControl();
            this.gvSayim = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSayimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSayimKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSayimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DepoID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepoAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.frmStokSayimlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnSayimGuncelle = new DevExpress.XtraEditors.SimpleButton();
            this.lkpSayimDeposu = new DevExpress.XtraEditors.LookUpEdit();
            this.deTarihAraligi1 = new DevExpress.XtraEditors.DateEdit();
            this.txtAciklama = new DevExpress.XtraEditors.TextEdit();
            this.txtSayimKodu = new DevExpress.XtraEditors.TextEdit();
            this.deTarihAraligi2 = new DevExpress.XtraEditors.DateEdit();
            this.btnFiltrele = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem8 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem9 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem10 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter();
            ((System.ComponentModel.ISupportInitialize)(this.gcSayim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSayim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmStokSayimlayoutControl1ConvertedLayout)).BeginInit();
            this.frmStokSayimlayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkpSayimDeposu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSayimKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSayim
            // 
            this.gcSayim.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gcSayim.Location = new System.Drawing.Point(333, 100);
            this.gcSayim.MainView = this.gvSayim;
            this.gcSayim.Margin = new System.Windows.Forms.Padding(6);
            this.gcSayim.Name = "gcSayim";
            this.gcSayim.Size = new System.Drawing.Size(1815, 998);
            this.gcSayim.TabIndex = 1;
            this.gcSayim.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSayim});
            // 
            // gvSayim
            // 
            this.gvSayim.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSayimID,
            this.colSayimKodu,
            this.colSayimTarihi,
            this.DepoID,
            this.colDepoAdi,
            this.Aciklama});
            this.gvSayim.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gvSayim.GridControl = this.gcSayim;
            this.gvSayim.Name = "gvSayim";
            this.gvSayim.OptionsBehavior.AllowIncrementalSearch = true;
            this.gvSayim.OptionsBehavior.Editable = false;
            this.gvSayim.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSayim.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gvSayim.OptionsView.EnableAppearanceEvenRow = true;
            this.gvSayim.OptionsView.EnableAppearanceOddRow = true;
            this.gvSayim.OptionsView.ShowGroupPanel = false;
            // 
            // colSayimID
            // 
            this.colSayimID.Caption = "SayimID";
            this.colSayimID.FieldName = "SayimID";
            this.colSayimID.Name = "colSayimID";
            // 
            // colSayimKodu
            // 
            this.colSayimKodu.Caption = "Sayım Kodu";
            this.colSayimKodu.FieldName = "SayimKodu";
            this.colSayimKodu.Name = "colSayimKodu";
            this.colSayimKodu.Visible = true;
            this.colSayimKodu.VisibleIndex = 1;
            // 
            // colSayimTarihi
            // 
            this.colSayimTarihi.Caption = "Sayım Tarihi";
            this.colSayimTarihi.FieldName = "SayimTarihi";
            this.colSayimTarihi.Name = "colSayimTarihi";
            this.colSayimTarihi.Visible = true;
            this.colSayimTarihi.VisibleIndex = 0;
            // 
            // DepoID
            // 
            this.DepoID.Caption = "DepoID";
            this.DepoID.FieldName = "DepoID";
            this.DepoID.Name = "DepoID";
            // 
            // colDepoAdi
            // 
            this.colDepoAdi.Caption = "Sayım Deposu";
            this.colDepoAdi.FieldName = "DepoAdi";
            this.colDepoAdi.Name = "colDepoAdi";
            this.colDepoAdi.Visible = true;
            this.colDepoAdi.VisibleIndex = 2;
            // 
            // Aciklama
            // 
            this.Aciklama.Caption = "Aciklama";
            this.Aciklama.FieldName = "Aciklama";
            this.Aciklama.Name = "Aciklama";
            this.Aciklama.Visible = true;
            this.Aciklama.VisibleIndex = 3;
            // 
            // btnTemizle
            // 
            this.btnTemizle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTemizle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnTemizle.Appearance.Options.UseFont = true;
            this.btnTemizle.Location = new System.Drawing.Point(159, 1048);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(166, 50);
            this.btnTemizle.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.btnTemizle.TabIndex = 7;
            this.btnTemizle.Text = "Temizle";
            // 
            // frmStokSayimlayoutControl1ConvertedLayout
            // 
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.btnSayimGuncelle);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.lkpSayimDeposu);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.deTarihAraligi1);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.txtAciklama);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.txtSayimKodu);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.btnTemizle);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.deTarihAraligi2);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.btnFiltrele);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.gcSayim);
            this.frmStokSayimlayoutControl1ConvertedLayout.Controls.Add(this.panelControl1);
            this.frmStokSayimlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmStokSayimlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.frmStokSayimlayoutControl1ConvertedLayout.Name = "frmStokSayimlayoutControl1ConvertedLayout";
            this.frmStokSayimlayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1369, 664, 900, 800);
            this.frmStokSayimlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmStokSayimlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(2162, 1112);
            this.frmStokSayimlayoutControl1ConvertedLayout.TabIndex = 3;
            // 
            // btnSayimGuncelle
            // 
            this.btnSayimGuncelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSayimGuncelle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSayimGuncelle.Location = new System.Drawing.Point(1245, 14);
            this.btnSayimGuncelle.Margin = new System.Windows.Forms.Padding(6);
            this.btnSayimGuncelle.Name = "btnSayimGuncelle";
            this.btnSayimGuncelle.Size = new System.Drawing.Size(903, 78);
            this.btnSayimGuncelle.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.btnSayimGuncelle.TabIndex = 1;
            this.btnSayimGuncelle.Text = "Sayımı Aç";
            this.btnSayimGuncelle.Click += new System.EventHandler(this.btnSayimGuncelle_Click);
            // 
            // lkpSayimDeposu
            // 
            this.lkpSayimDeposu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lkpSayimDeposu.EditValue = -1;
            this.lkpSayimDeposu.Location = new System.Drawing.Point(14, 306);
            this.lkpSayimDeposu.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.lkpSayimDeposu.Name = "lkpSayimDeposu";
            this.lkpSayimDeposu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.lkpSayimDeposu.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("DepoAdi", "DepoAdi")});
            this.lkpSayimDeposu.Properties.NullText = "";
            this.lkpSayimDeposu.Size = new System.Drawing.Size(311, 34);
            this.lkpSayimDeposu.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.lkpSayimDeposu.TabIndex = 6;
            this.lkpSayimDeposu.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.lkpSayimDeposu_ButtonClick);
            // 
            // deTarihAraligi1
            // 
            this.deTarihAraligi1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deTarihAraligi1.EditValue = null;
            this.deTarihAraligi1.Location = new System.Drawing.Point(14, 45);
            this.deTarihAraligi1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.deTarihAraligi1.Name = "deTarihAraligi1";
            this.deTarihAraligi1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deTarihAraligi1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTarihAraligi1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.deTarihAraligi1.Size = new System.Drawing.Size(311, 34);
            this.deTarihAraligi1.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.deTarihAraligi1.TabIndex = 3;
            this.deTarihAraligi1.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deTarihAraligi1_ButtonClick);
            // 
            // txtAciklama
            // 
            this.txtAciklama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAciklama.Location = new System.Drawing.Point(14, 233);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(311, 34);
            this.txtAciklama.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.txtAciklama.TabIndex = 1;
            // 
            // txtSayimKodu
            // 
            this.txtSayimKodu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSayimKodu.Location = new System.Drawing.Point(14, 160);
            this.txtSayimKodu.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.txtSayimKodu.Name = "txtSayimKodu";
            this.txtSayimKodu.Size = new System.Drawing.Size(311, 34);
            this.txtSayimKodu.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.txtSayimKodu.TabIndex = 1;
            // 
            // deTarihAraligi2
            // 
            this.deTarihAraligi2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deTarihAraligi2.EditValue = null;
            this.deTarihAraligi2.Location = new System.Drawing.Point(14, 87);
            this.deTarihAraligi2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.deTarihAraligi2.Name = "deTarihAraligi2";
            this.deTarihAraligi2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete)});
            this.deTarihAraligi2.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.deTarihAraligi2.Size = new System.Drawing.Size(311, 34);
            this.deTarihAraligi2.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.deTarihAraligi2.TabIndex = 4;
            this.deTarihAraligi2.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.deTarihAraligi2_ButtonClick);
            // 
            // btnFiltrele
            // 
            this.btnFiltrele.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFiltrele.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnFiltrele.Appearance.Options.UseFont = true;
            this.btnFiltrele.Location = new System.Drawing.Point(14, 1048);
            this.btnFiltrele.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnFiltrele.Name = "btnFiltrele";
            this.btnFiltrele.Size = new System.Drawing.Size(137, 50);
            this.btnFiltrele.StyleController = this.frmStokSayimlayoutControl1ConvertedLayout;
            this.btnFiltrele.TabIndex = 0;
            this.btnFiltrele.Text = "Filtrele";
            this.btnFiltrele.Click += new System.EventHandler(this.btnFiltrele_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl15);
            this.panelControl1.Location = new System.Drawing.Point(333, 14);
            this.panelControl1.Margin = new System.Windows.Forms.Padding(6);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(904, 78);
            this.panelControl1.TabIndex = 2;
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseForeColor = true;
            this.labelControl15.Location = new System.Drawing.Point(8, 12);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(6);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(210, 44);
            this.labelControl15.TabIndex = 10;
            this.labelControl15.Text = "Stok Sayımı";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutControlGroup1.Size = new System.Drawing.Size(2162, 1112);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup3,
            this.layoutControlGroup4});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "splitContainerControl1item";
            this.layoutControlGroup2.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup2.Size = new System.Drawing.Size(2142, 1092);
            this.layoutControlGroup2.Text = "splitContainerControl1";
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.GroupBordersVisible = false;
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.layoutControlItem5,
            this.layoutControlItem6,
            this.layoutControlItem7,
            this.emptySpaceItem1});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup3.Name = "Panel1item";
            this.layoutControlGroup3.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup3.Size = new System.Drawing.Size(319, 1092);
            this.layoutControlGroup3.Text = "Panel1";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.lkpSayimDeposu;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 261);
            this.layoutControlItem1.Name = "lkpSayimDeposuitem";
            this.layoutControlItem1.Size = new System.Drawing.Size(319, 73);
            this.layoutControlItem1.Text = "Sayım Deposu";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(182, 25);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.deTarihAraligi1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "deTarihAraligi1item";
            this.layoutControlItem2.Size = new System.Drawing.Size(319, 73);
            this.layoutControlItem2.Text = "Sayim Tarihi Aralığı";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(182, 25);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.txtAciklama;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 188);
            this.layoutControlItem3.Name = "txtAciklamaitem";
            this.layoutControlItem3.Size = new System.Drawing.Size(319, 73);
            this.layoutControlItem3.Text = "Açıklama";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(182, 25);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtSayimKodu;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 115);
            this.layoutControlItem4.Name = "txtSayimKoduitem";
            this.layoutControlItem4.Size = new System.Drawing.Size(319, 73);
            this.layoutControlItem4.Text = "Sayım Kodu";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(182, 25);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnTemizle;
            this.layoutControlItem5.Location = new System.Drawing.Point(145, 1034);
            this.layoutControlItem5.Name = "btnTemizleitem";
            this.layoutControlItem5.Size = new System.Drawing.Size(174, 58);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.deTarihAraligi2;
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 73);
            this.layoutControlItem6.Name = "deTarihAraligi2item";
            this.layoutControlItem6.Size = new System.Drawing.Size(319, 42);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.btnFiltrele;
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 1034);
            this.layoutControlItem7.Name = "btnFiltreleitem";
            this.layoutControlItem7.Size = new System.Drawing.Size(145, 58);
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 334);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(319, 700);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.GroupBordersVisible = false;
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem8,
            this.layoutControlItem9,
            this.layoutControlItem10});
            this.layoutControlGroup4.Location = new System.Drawing.Point(319, 0);
            this.layoutControlGroup4.Name = "Panel2item";
            this.layoutControlGroup4.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup4.Size = new System.Drawing.Size(1823, 1092);
            this.layoutControlGroup4.Text = "Panel2";
            // 
            // layoutControlItem8
            // 
            this.layoutControlItem8.Control = this.gcSayim;
            this.layoutControlItem8.Location = new System.Drawing.Point(0, 86);
            this.layoutControlItem8.Name = "gcSayimitem";
            this.layoutControlItem8.Size = new System.Drawing.Size(1823, 1006);
            this.layoutControlItem8.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem8.TextVisible = false;
            // 
            // layoutControlItem9
            // 
            this.layoutControlItem9.Control = this.panelControl1;
            this.layoutControlItem9.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem9.Name = "panelControl1item";
            this.layoutControlItem9.Size = new System.Drawing.Size(912, 86);
            this.layoutControlItem9.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem9.TextVisible = false;
            // 
            // layoutControlItem10
            // 
            this.layoutControlItem10.Control = this.btnSayimGuncelle;
            this.layoutControlItem10.Location = new System.Drawing.Point(912, 0);
            this.layoutControlItem10.MinSize = new System.Drawing.Size(112, 50);
            this.layoutControlItem10.Name = "layoutControlItem10";
            this.layoutControlItem10.Size = new System.Drawing.Size(911, 86);
            this.layoutControlItem10.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem10.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem10.TextVisible = false;
            // 
            // frmStokSayim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2162, 1112);
            this.Controls.Add(this.frmStokSayimlayoutControl1ConvertedLayout);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmStokSayim";
            this.Text = "frmStokSayim";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmStokSayim_FormClosed);
            this.Load += new System.EventHandler(this.frmStokSayim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcSayim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSayim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmStokSayimlayoutControl1ConvertedLayout)).EndInit();
            this.frmStokSayimlayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkpSayimDeposu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSayimKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deTarihAraligi2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem10)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcSayim;
    private DevExpress.XtraGrid.Views.Grid.GridView gvSayim;
    private DevExpress.XtraGrid.Columns.GridColumn colSayimID;
    private DevExpress.XtraGrid.Columns.GridColumn colSayimKodu;
    private DevExpress.XtraGrid.Columns.GridColumn colSayimTarihi;
    private DevExpress.XtraGrid.Columns.GridColumn DepoID;
    private DevExpress.XtraGrid.Columns.GridColumn colDepoAdi;
    private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
    private DevExpress.XtraEditors.DateEdit deTarihAraligi2;
    private DevExpress.XtraEditors.DateEdit deTarihAraligi1;
    private DevExpress.XtraEditors.TextEdit txtAciklama;
    private DevExpress.XtraEditors.TextEdit txtSayimKodu;
    private DevExpress.XtraEditors.SimpleButton btnFiltrele;
    private DevExpress.XtraEditors.LookUpEdit lkpSayimDeposu;
    private DevExpress.XtraEditors.SimpleButton btnTemizle;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl15;
    private DevExpress.XtraEditors.SimpleButton btnSayimGuncelle;
        private DevExpress.XtraLayout.LayoutControl frmStokSayimlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem8;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem9;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem10;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
    }
}