namespace Aresv2.n11
{
    partial class frmN11Kategorileri
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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colID = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colKategoriAdi = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnArestekiN11KategorileriniGetir = new DevExpress.XtraEditors.SimpleButton();
            this.btnKategoriOzellikleriniGetir = new DevExpress.XtraEditors.SimpleButton();
            this.treeList_ArestekiN11Kategorileri = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_ArestekiN11Kategorileri)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(6, 7);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(227, 40);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Location = new System.Drawing.Point(557, 113);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(503, 487);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colID,
            this.colKategoriAdi});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Location = new System.Drawing.Point(6, 113);
            this.treeList1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.ParentFieldName = "UstKategoriID";
            this.treeList1.Size = new System.Drawing.Size(227, 487);
            this.treeList1.TabIndex = 6;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colKategoriAdi
            // 
            this.colKategoriAdi.Caption = "KategoriAdi";
            this.colKategoriAdi.FieldName = "KategoriAdi";
            this.colKategoriAdi.Name = "colKategoriAdi";
            this.colKategoriAdi.Visible = true;
            this.colKategoriAdi.VisibleIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(6, 85);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(227, 23);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "N11 deki Kategorileri Getir";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // btnArestekiN11KategorileriniGetir
            // 
            this.btnArestekiN11KategorileriniGetir.Location = new System.Drawing.Point(277, 85);
            this.btnArestekiN11KategorileriniGetir.Name = "btnArestekiN11KategorileriniGetir";
            this.btnArestekiN11KategorileriniGetir.Size = new System.Drawing.Size(233, 23);
            this.btnArestekiN11KategorileriniGetir.TabIndex = 7;
            this.btnArestekiN11KategorileriniGetir.Text = "Aresteki N11 Kategorilerini Getir";
            this.btnArestekiN11KategorileriniGetir.Click += new System.EventHandler(this.btnArestekiN11KategorileriniGetir_Click);
            // 
            // btnKategoriOzellikleriniGetir
            // 
            this.btnKategoriOzellikleriniGetir.Location = new System.Drawing.Point(557, 85);
            this.btnKategoriOzellikleriniGetir.Name = "btnKategoriOzellikleriniGetir";
            this.btnKategoriOzellikleriniGetir.Size = new System.Drawing.Size(503, 23);
            this.btnKategoriOzellikleriniGetir.TabIndex = 7;
            this.btnKategoriOzellikleriniGetir.Text = "Aresteki Kategori Özelliklerini Getir";
            this.btnKategoriOzellikleriniGetir.Click += new System.EventHandler(this.btnKategoriOzellikleriniGetir_Click);
            // 
            // treeList_ArestekiN11Kategorileri
            // 
            this.treeList_ArestekiN11Kategorileri.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList_ArestekiN11Kategorileri.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList_ArestekiN11Kategorileri.Location = new System.Drawing.Point(277, 113);
            this.treeList_ArestekiN11Kategorileri.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeList_ArestekiN11Kategorileri.Name = "treeList_ArestekiN11Kategorileri";
            this.treeList_ArestekiN11Kategorileri.ParentFieldName = "UstKategoriID";
            this.treeList_ArestekiN11Kategorileri.Size = new System.Drawing.Size(233, 487);
            this.treeList_ArestekiN11Kategorileri.TabIndex = 6;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "ID";
            this.treeListColumn1.FieldName = "ID";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "KategoriAdi";
            this.treeListColumn2.FieldName = "KategoriAdi";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(557, 605);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(503, 23);
            this.simpleButton3.TabIndex = 8;
            this.simpleButton3.Text = "simpleButton3";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // frmN11Kategorileri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 665);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.btnKategoriOzellikleriniGetir);
            this.Controls.Add(this.btnArestekiN11KategorileriniGetir);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.treeList_ArestekiN11Kategorileri);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmN11Kategorileri";
            this.Text = "frmN11";
            this.Load += new System.EventHandler(this.frmN11_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList_ArestekiN11Kategorileri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colID;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colKategoriAdi;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton btnArestekiN11KategorileriniGetir;
        private DevExpress.XtraEditors.SimpleButton btnKategoriOzellikleriniGetir;
        private DevExpress.XtraTreeList.TreeList treeList_ArestekiN11Kategorileri;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
    }
}