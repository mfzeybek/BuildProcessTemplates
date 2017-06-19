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
            this.dockPanel1 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel1_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.dockPanel2 = new DevExpress.XtraBars.Docking.DockPanel();
            this.dockPanel2_Container = new DevExpress.XtraBars.Docking.ControlContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCariTanim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisiAlanPersonelAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisDurumTanimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.frmYonetimlayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.panelContainer1 = new DevExpress.XtraBars.Docking.DockPanel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).BeginInit();
            this.dockPanel1.SuspendLayout();
            this.dockPanel1_Container.SuspendLayout();
            this.dockPanel2.SuspendLayout();
            this.dockPanel2_Container.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmYonetimlayoutControl1ConvertedLayout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            this.panelContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(467, 247);
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
            this.panelContainer1});
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
            // dockPanel1
            // 
            this.dockPanel1.Controls.Add(this.dockPanel1_Container);
            this.dockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel1.FloatSize = new System.Drawing.Size(355, 365);
            this.dockPanel1.FloatVertical = true;
            this.dockPanel1.ID = new System.Guid("5950e414-0315-4cc6-b5fe-4f9195917b4b");
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.OriginalSize = new System.Drawing.Size(200, 200);
            this.dockPanel1.Size = new System.Drawing.Size(476, 275);
            this.dockPanel1.Text = "dockPanel1";
            // 
            // dockPanel1_Container
            // 
            this.dockPanel1_Container.Controls.Add(this.gridControl1);
            this.dockPanel1_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel1_Container.Margin = new System.Windows.Forms.Padding(2);
            this.dockPanel1_Container.Name = "dockPanel1_Container";
            this.dockPanel1_Container.Size = new System.Drawing.Size(467, 247);
            this.dockPanel1_Container.TabIndex = 0;
            // 
            // dockPanel2
            // 
            this.dockPanel2.Controls.Add(this.dockPanel2_Container);
            this.dockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill;
            this.dockPanel2.FloatSize = new System.Drawing.Size(284, 158);
            this.dockPanel2.FloatVertical = true;
            this.dockPanel2.ID = new System.Guid("8be2d8c5-d3ce-4645-9429-ead55b377460");
            this.dockPanel2.Location = new System.Drawing.Point(476, 0);
            this.dockPanel2.Name = "dockPanel2";
            this.dockPanel2.OriginalSize = new System.Drawing.Size(200, 185);
            this.dockPanel2.Size = new System.Drawing.Size(475, 275);
            this.dockPanel2.Text = "dockPanel2";
            this.dockPanel2.Click += new System.EventHandler(this.dockPanel2_Click);
            // 
            // dockPanel2_Container
            // 
            this.dockPanel2_Container.Controls.Add(this.gridControl2);
            this.dockPanel2_Container.Location = new System.Drawing.Point(4, 23);
            this.dockPanel2_Container.Name = "dockPanel2_Container";
            this.dockPanel2_Container.Size = new System.Drawing.Size(467, 247);
            this.dockPanel2_Container.TabIndex = 0;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl2.Location = new System.Drawing.Point(0, 0);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Margin = new System.Windows.Forms.Padding(2);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(467, 247);
            this.gridControl2.TabIndex = 2;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariTanim,
            this.colSiparisTutari,
            this.colTeslimTarihi,
            this.colSiparisiAlanPersonelAdi,
            this.colSiparisDurumTanimAdi});
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
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
            // frmYonetimlayoutControl1ConvertedLayout
            // 
            this.frmYonetimlayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmYonetimlayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 275);
            this.frmYonetimlayoutControl1ConvertedLayout.Name = "frmYonetimlayoutControl1ConvertedLayout";
            this.frmYonetimlayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmYonetimlayoutControl1ConvertedLayout.Size = new System.Drawing.Size(951, 358);
            this.frmYonetimlayoutControl1ConvertedLayout.TabIndex = 2;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(951, 358);
            this.layoutControlGroup1.TextVisible = false;
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
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.OriginalSize = new System.Drawing.Size(200, 275);
            this.panelContainer1.Size = new System.Drawing.Size(951, 275);
            this.panelContainer1.Text = "panelContainer1";
            // 
            // frmYonetim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 633);
            this.Controls.Add(this.frmYonetimlayoutControl1ConvertedLayout);
            this.Controls.Add(this.panelContainer1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "frmYonetim";
            this.Text = "frmYonetim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmYonetim_FormClosing);
            this.Load += new System.EventHandler(this.frmYonetim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dockManager1)).EndInit();
            this.dockPanel1.ResumeLayout(false);
            this.dockPanel1_Container.ResumeLayout(false);
            this.dockPanel2.ResumeLayout(false);
            this.dockPanel2_Container.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmYonetimlayoutControl1ConvertedLayout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            this.panelContainer1.ResumeLayout(false);
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
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colCariTanim;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisTutari;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisiAlanPersonelAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisDurumTanimAdi;
        private DevExpress.XtraLayout.LayoutControl frmYonetimlayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraBars.Docking.DockPanel panelContainer1;
    }
}