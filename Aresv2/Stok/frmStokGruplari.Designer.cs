namespace Aresv2.Stok
{
    partial class frmStokGruplari
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
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colStokGrupAdi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colStokGrupID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colUstGrupID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.frmStokGruplarilayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAltGrupEkle = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.btnAltGrupEkleItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnKaydetitem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.btnDeleteItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.btnTamamItem = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmStokGruplarilayoutControl1ConvertedLayout)).BeginInit();
            this.frmStokGruplarilayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltGrupEkleItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydetitem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTamamItem)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colStokGrupAdi,
            this.colStokGrupID,
            this.colUstGrupID});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.KeyFieldName = "";
            this.treeList1.Location = new System.Drawing.Point(24, 24);
            this.treeList1.Margin = new System.Windows.Forms.Padding(6);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "ahandaaa",
            null,
            null}, -1);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsDragAndDrop.AcceptOuterNodes = true;
            this.treeList1.OptionsDragAndDrop.DropNodesMode = DevExpress.XtraTreeList.DropNodesMode.Advanced;
            this.treeList1.OptionsView.AutoWidth = false;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.RowFocus;
            this.treeList1.OptionsView.ShowAutoFilterRow = true;
            this.treeList1.Size = new System.Drawing.Size(1142, 772);
            this.treeList1.TabIndex = 0;
            // 
            // colStokGrupAdi
            // 
            this.colStokGrupAdi.Caption = "StokGrupAdi";
            this.colStokGrupAdi.FieldName = "StokGrupAdi";
            this.colStokGrupAdi.MinWidth = 42;
            this.colStokGrupAdi.Name = "colStokGrupAdi";
            this.colStokGrupAdi.Visible = true;
            this.colStokGrupAdi.VisibleIndex = 0;
            this.colStokGrupAdi.Width = 527;
            // 
            // colStokGrupID
            // 
            this.colStokGrupID.Caption = "StokGrupID";
            this.colStokGrupID.FieldName = "StokGrupID";
            this.colStokGrupID.Name = "colStokGrupID";
            this.colStokGrupID.Visible = true;
            this.colStokGrupID.VisibleIndex = 1;
            this.colStokGrupID.Width = 142;
            // 
            // colUstGrupID
            // 
            this.colUstGrupID.Caption = "UstGrupID";
            this.colUstGrupID.FieldName = "UstGrupID";
            this.colUstGrupID.Name = "colUstGrupID";
            this.colUstGrupID.Visible = true;
            this.colUstGrupID.VisibleIndex = 2;
            this.colUstGrupID.Width = 139;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(24, 804);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(6);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(282, 42);
            this.btnKaydet.StyleController = this.frmStokGruplarilayoutControl1ConvertedLayout;
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // frmStokGruplarilayoutControl1ConvertedLayout
            // 
            this.frmStokGruplarilayoutControl1ConvertedLayout.Controls.Add(this.btnTamam);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Controls.Add(this.btnDelete);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Controls.Add(this.btnAltGrupEkle);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Controls.Add(this.btnKaydet);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Controls.Add(this.treeList1);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmStokGruplarilayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Margin = new System.Windows.Forms.Padding(6);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Name = "frmStokGruplarilayoutControl1ConvertedLayout";
            this.frmStokGruplarilayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(799, 371, 450, 400);
            this.frmStokGruplarilayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmStokGruplarilayoutControl1ConvertedLayout.Size = new System.Drawing.Size(1480, 1200);
            this.frmStokGruplarilayoutControl1ConvertedLayout.TabIndex = 3;
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(314, 804);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(6);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(278, 42);
            this.btnTamam.StyleController = this.frmStokGruplarilayoutControl1ConvertedLayout;
            this.btnTamam.TabIndex = 4;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(600, 804);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(6);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(280, 42);
            this.btnDelete.StyleController = this.frmStokGruplarilayoutControl1ConvertedLayout;
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Sil";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAltGrupEkle
            // 
            this.btnAltGrupEkle.Location = new System.Drawing.Point(888, 804);
            this.btnAltGrupEkle.Margin = new System.Windows.Forms.Padding(6);
            this.btnAltGrupEkle.Name = "btnAltGrupEkle";
            this.btnAltGrupEkle.Size = new System.Drawing.Size(278, 42);
            this.btnAltGrupEkle.StyleController = this.frmStokGruplarilayoutControl1ConvertedLayout;
            this.btnAltGrupEkle.TabIndex = 2;
            this.btnAltGrupEkle.Text = "Alt Grup Ekle";
            this.btnAltGrupEkle.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.btnAltGrupEkleItem,
            this.btnKaydetitem,
            this.layoutControlItem3,
            this.btnDeleteItem,
            this.emptySpaceItem1,
            this.emptySpaceItem2,
            this.btnTamamItem});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1480, 1200);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // btnAltGrupEkleItem
            // 
            this.btnAltGrupEkleItem.Control = this.btnAltGrupEkle;
            this.btnAltGrupEkleItem.Location = new System.Drawing.Point(864, 780);
            this.btnAltGrupEkleItem.Name = "btnAltGrupEkleItem";
            this.btnAltGrupEkleItem.Size = new System.Drawing.Size(286, 50);
            this.btnAltGrupEkleItem.TextSize = new System.Drawing.Size(0, 0);
            this.btnAltGrupEkleItem.TextVisible = false;
            // 
            // btnKaydetitem
            // 
            this.btnKaydetitem.Control = this.btnKaydet;
            this.btnKaydetitem.Location = new System.Drawing.Point(0, 780);
            this.btnKaydetitem.Name = "btnKaydetitem";
            this.btnKaydetitem.Size = new System.Drawing.Size(290, 50);
            this.btnKaydetitem.TextSize = new System.Drawing.Size(0, 0);
            this.btnKaydetitem.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.treeList1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "treeList1item";
            this.layoutControlItem3.Size = new System.Drawing.Size(1150, 780);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // btnDeleteItem
            // 
            this.btnDeleteItem.Control = this.btnDelete;
            this.btnDeleteItem.Location = new System.Drawing.Point(576, 780);
            this.btnDeleteItem.Name = "btnDeleteItem";
            this.btnDeleteItem.Size = new System.Drawing.Size(288, 50);
            this.btnDeleteItem.TextSize = new System.Drawing.Size(0, 0);
            this.btnDeleteItem.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 830);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(1150, 330);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(1150, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(290, 1160);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // btnTamamItem
            // 
            this.btnTamamItem.Control = this.btnTamam;
            this.btnTamamItem.Location = new System.Drawing.Point(290, 780);
            this.btnTamamItem.Name = "btnTamamItem";
            this.btnTamamItem.Size = new System.Drawing.Size(286, 50);
            this.btnTamamItem.TextSize = new System.Drawing.Size(0, 0);
            this.btnTamamItem.TextVisible = false;
            // 
            // frmStokGruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1480, 1200);
            this.Controls.Add(this.frmStokGruplarilayoutControl1ConvertedLayout);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmStokGruplari";
            this.Text = "frmStokGruplari";
            this.Load += new System.EventHandler(this.frmStokGruplari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmStokGruplarilayoutControl1ConvertedLayout)).EndInit();
            this.frmStokGruplarilayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAltGrupEkleItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnKaydetitem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDeleteItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTamamItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnAltGrupEkle;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStokGrupAdi;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colStokGrupID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colUstGrupID;
        private DevExpress.XtraLayout.LayoutControl frmStokGruplarilayoutControl1ConvertedLayout;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem btnAltGrupEkleItem;
        private DevExpress.XtraLayout.LayoutControlItem btnKaydetitem;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem btnDeleteItem;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.LayoutControlItem btnTamamItem;
        public DevExpress.XtraTreeList.TreeList treeList1;
    }
}