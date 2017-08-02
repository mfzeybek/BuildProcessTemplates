namespace Aresv2.Yonetim
{
    partial class frmYonetim
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPersonelAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZaman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYerAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockManager1 = new DevExpress.XtraBars.Docking.DockManager(this.components);
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gcAlinanSiparisler = new DevExpress.XtraGrid.GridControl();
            this.gvAlinanSiparisler = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCariTanim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisiAlanPersonelAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisDurumTanimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dockPanel3 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel3_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.frmYonetimlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.btnAyarKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAlinanSiparisler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlinanSiparisler)).BeginInit();
            this.dockPanel3.SuspendLayout();
            this.dockPanel3_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.frmYonetimlayoutControl1ConvertedLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(931, 226);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPersonelAdi,
            this.colZaman,
            this.colYerAdi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPersonelAdi
            // 
            this.colPersonelAdi.Caption = "PersonelAdi";
            this.colPersonelAdi.FieldName = "PersonelAdi";
            this.colPersonelAdi.Name = "colPersonelAdi";
            this.colPersonelAdi.Visible = true;
            this.colPersonelAdi.VisibleIndex = 0;
            // 
            // colZaman
            // 
            this.colZaman.Caption = "Zaman";
            this.colZaman.DisplayFormat.FormatString = "T";
            this.colZaman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colZaman.FieldName = "Zaman";
            this.colZaman.Name = "colZaman";
            this.colZaman.Visible = true;
            this.colZaman.VisibleIndex = 1;
            // 
            // colYerAdi
            // 
            this.colYerAdi.Caption = "colYerAdi";
            this.colYerAdi.FieldName = "YerAdi";
            this.colYerAdi.Name = "colYerAdi";
            this.colYerAdi.Visible = true;
            this.colYerAdi.VisibleIndex = 2;
            // 
            // dockManager1
            // 
            this.dockManager1.Form = this;
            this.dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] {
            this.panelContainer1,
            this.dockPanel3});
            this.dockManager1.TopZIndexControls.AddRange(new string[] {
            "DevExpress.XtraBars.BarDockControl",
            "DevExpress.XtraBars.StandaloneBarDockControl",
            "System.Windows.Forms.StatusBar",
            "System.Windows.Forms.MenuStrip",
            "System.Windows.Forms.StatusStrip",
            "DevExpress.XtraBars.Ribbon.RibbonStatusBar",
            "DevExpress.XtraBars.Ribbon.RibbonControl",
            "DevExpress.XtraBars.Navigation.OfficeNavigationBar",
            "DevExpress.XtraBars.Navigation.TileNavPane",
            "DevExpress.XtraBars.TabFormControl"});
            // 
            // panelContainer1
            // 
            this.panelContainer1.Controls.Add(this.dockPanel1);
            this.panelContainer1.Controls.Add(this.dockPanel2);
            this.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Top;
            this.panelContainer1.FloatSize = new System.Drawing.Size(355, 365);
            this.panelContainer1.FloatVertical = true;
            this.panelContainer1.ID = new System.Guid("de7795a7-f47e-44f7-9916-505b2f446a12");
            this.panelContainer1.Location = new System.Drawing.Point(0, 0);
            this.panelContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 288);
            this.panelContainer1.Size = new System.Drawing.Size(1902, 288);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Yenile", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.FloatSize = new System.Drawing.Size(355, 365);
            this.dockPanel1.FloatVertical = true;
            this.dockPanel1.ID = new System.Guid("5950e414-0315-4cc6-b5fe-4f9195917b4b");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(952, 554);
            this.dockPanel1.Size = new System.Drawing.Size(952, 288);
            this.dockPanel1.Text = "Dışarıdaki Personel";
            this.dockPanel1.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.dockPanel1_CustomButtonClick);
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(8, 49);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(4);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(931, 226);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton("Yenile", DevExpress.XtraBars.Docking2010.ButtonStyle.PushButton)});
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.FloatSize = new System.Drawing.Size(284, 158);
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("8be2d8c5-d3ce-4645-9429-ead55b377460");
            this.dockPanel2.Location = new System.Drawing.Point(952, 0);
            this.dockPanel2.Margin = new System.Windows.Forms.Padding(6);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(950, 554);
            this.dockPanel2.Size = new System.Drawing.Size(950, 288);
            this.dockPanel2.Text = "Alınan Siparişler";
            this.dockPanel2.CustomButtonClick += new DevExpress.XtraBars.Docking2010.ButtonEventHandler(this.dockPanel2_CustomButtonClick);
            this.dockPanel2.Click += new System.EventHandler(this.dockPanel2_Click);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.gcAlinanSiparisler);
            this.dockPanel2_Container.Location = new System.Drawing.Point(8, 49);
            this.dockPanel2_Container.Margin = new System.Windows.Forms.Padding(6);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(934, 226);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gcAlinanSiparisler
            // 
            this.gcAlinanSiparisler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAlinanSiparisler.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gcAlinanSiparisler.Location = new System.Drawing.Point(0, 0);
            this.gcAlinanSiparisler.MainView = this.gvAlinanSiparisler;
            this.gcAlinanSiparisler.Margin = new System.Windows.Forms.Padding(4);
            this.gcAlinanSiparisler.Name = "gcAlinanSiparisler";
            this.gcAlinanSiparisler.Size = new System.Drawing.Size(934, 226);
            this.gcAlinanSiparisler.TabIndex = 2;
            this.gcAlinanSiparisler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAlinanSiparisler});
            // 
            // gvAlinanSiparisler
            // 
            this.gvAlinanSiparisler.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariTanim,
            this.colSiparisTutari,
            this.colTeslimTarihi,
            this.colSiparisiAlanPersonelAdi,
            this.colSiparisDurumTanimAdi});
            this.gvAlinanSiparisler.GridControl = this.gcAlinanSiparisler;
            this.gvAlinanSiparisler.Name = "gvAlinanSiparisler";
            this.gvAlinanSiparisler.OptionsView.ShowGroupPanel = false;
            // 
            // colCariTanim
            // 
            this.colCariTanim.Caption = "CariTanim";
            this.colCariTanim.FieldName = "CariTanim";
            this.colCariTanim.Name = "colCariTanim";
            this.colCariTanim.Visible = true;
            this.colCariTanim.VisibleIndex = 0;
            // 
            // colSiparisTutari
            // 
            this.colSiparisTutari.Caption = "SiparisTutari";
            this.colSiparisTutari.FieldName = "SiparisTutari";
            this.colSiparisTutari.Name = "colSiparisTutari";
            this.colSiparisTutari.Visible = true;
            this.colSiparisTutari.VisibleIndex = 1;
            // 
            // colTeslimTarihi
            // 
            this.colTeslimTarihi.Caption = "TeslimTarihi";
            this.colTeslimTarihi.FieldName = "TeslimTarihi";
            this.colTeslimTarihi.Name = "colTeslimTarihi";
            this.colTeslimTarihi.Visible = true;
            this.colTeslimTarihi.VisibleIndex = 2;
            // 
            // colSiparisiAlanPersonelAdi
            // 
            this.colSiparisiAlanPersonelAdi.Caption = "PersonelAdi";
            this.colSiparisiAlanPersonelAdi.FieldName = "PersonelAdi";
            this.colSiparisiAlanPersonelAdi.Name = "colSiparisiAlanPersonelAdi";
            this.colSiparisiAlanPersonelAdi.Visible = true;
            this.colSiparisiAlanPersonelAdi.VisibleIndex = 3;
            // 
            // colSiparisDurumTanimAdi
            // 
            this.colSiparisDurumTanimAdi.Caption = "SiparisDurumTanimAdi";
            this.colSiparisDurumTanimAdi.FieldName = "SiparisDurumTanimAdi";
            this.colSiparisDurumTanimAdi.Name = "colSiparisDurumTanimAdi";
            this.colSiparisDurumTanimAdi.Visible = true;
            this.colSiparisDurumTanimAdi.VisibleIndex = 4;
            // 
            // dockPanel3
            // 
            this.dockPanel3.Controls.Add(this.dockPanel3_Container);
            this.dockPanel3.CustomHeaderButtons.AddRange(new DevExpress.XtraBars.Docking2010.IButton[] {
            new DevExpress.XtraBars.Docking.CustomHeaderButton()});
            this.dockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            this.dockPanel3.ID = new System.Guid("654e572d-3553-4a89-90d2-96e48df1fbfc");
            this.dockPanel3.Location = new System.Drawing.Point(0, 288);
            this.dockPanel3.Margin = new System.Windows.Forms.Padding(6);
            this.dockPanel3.Name = "dockPanel3";
            this.dockPanel3.OriginalSize = new System.Drawing.Size(435, 200);
            this.dockPanel3.Size = new System.Drawing.Size(435, 929);
            this.dockPanel3.Text = "Ayarlar";
            // 
            // dockPanel3_Container
            // 
            this.dockPanel3_Container.Controls.Add(this.vGridControl1);
            this.dockPanel3_Container.Controls.Add(this.btnAyarKaydet);
            this.dockPanel3_Container.Location = new System.Drawing.Point(8, 49);
            this.dockPanel3_Container.Margin = new System.Windows.Forms.Padding(6);
            this.dockPanel3_Container.Name = "dockPanel3_Container";
            this.dockPanel3_Container.Size = new System.Drawing.Size(414, 872);
            this.dockPanel3_Container.TabIndex = 0;
            // 
            // frmYonetimlayoutControl1ConvertedLayout
            // 
            this.frmYonetimlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmYonetimlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(435, 288);
            this.frmYonetimlayoutControl1ConvertedLayout.Margin = new System.Windows.Forms.Padding(6);
            this.frmYonetimlayoutControl1ConvertedLayout.Name = "frmYonetimlayoutControl1ConvertedLayout";
            this.frmYonetimlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmYonetimlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(1467, 929);
            this.frmYonetimlayoutControl1ConvertedLayout.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1467, 929);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // btnAyarKaydet
            // 
            this.btnAyarKaydet.Location = new System.Drawing.Point(53, 776);
            this.btnAyarKaydet.Name = "btnAyarKaydet";
            this.btnAyarKaydet.Size = new System.Drawing.Size(185, 63);
            this.btnAyarKaydet.TabIndex = 5;
            this.btnAyarKaydet.Text = "Kaydet";
            // 
            // vGridControl1
            // 
            this.vGridControl1.Location = new System.Drawing.Point(3, 16);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Size = new System.Drawing.Size(400, 546);
            this.vGridControl1.TabIndex = 6;
            // 
            // frmYonetim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1902, 1217);
            this.Controls.Add(this.frmYonetimlayoutControl1ConvertedLayout);
            this.Controls.Add(this.dockPanel3);
            this.Controls.Add(this.panelContainer1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmYonetim";
            this.Text = "frmYonetim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYonetim_FormClosing);
            this.Load += new System.EventHandler(this.frmYonetim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.panelContainer1.ResumeLayout(false);
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAlinanSiparisler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAlinanSiparisler)).EndInit();
            this.dockPanel3.ResumeLayout(false);
            this.dockPanel3_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.frmYonetimlayoutControl1ConvertedLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel1;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel1_Container;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel2;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel2_Container;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colZaman;
        private DevExpress.XtraGrid.Columns.GridColumn colYerAdi;
        private DevExpress.XtraGrid.GridControl gcAlinanSiparisler;
        private DevExpress.XtraGrid.Views.Grid.GridView gvAlinanSiparisler;
        private DevExpress.XtraGrid.Columns.GridColumn colCariTanim;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisTutari;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisiAlanPersonelAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisDurumTanimAdi;
        private DevExpress.XtraLayout.LayoutControl frmYonetimlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
        private DevExpress.XtraBars.Docking.DockPanel dockPanel3;
        private DevExpress.XtraBars.Docking.ControlContainer dockPanel3_Container;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private DevExpress.XtraEditors.SimpleButton btnAyarKaydet;
    }
}