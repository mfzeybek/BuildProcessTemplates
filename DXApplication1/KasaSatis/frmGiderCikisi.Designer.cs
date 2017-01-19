namespace KasaSatis
{
    partial class frmGiderCikisi
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
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.frmGiderCikisilayoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnDuzelt = new DevExpress.XtraEditors.SimpleButton();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBorc = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmGiderCikisilayoutControl1ConvertedLayout)).BeginInit();
            this.frmGiderCikisilayoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6);
            this.gridControl1.Location = new System.Drawing.Point(24, 55);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(786, 584);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F);
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colAciklama,
            this.colBorc});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnTamam
            // 
            this.btnTamam.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnTamam.Appearance.Options.UseFont = true;
            this.btnTamam.Location = new System.Drawing.Point(24, 647);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(6);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(256, 111);
            this.btnTamam.StyleController = this.frmGiderCikisilayoutControl1ConvertedLayout;
            this.btnTamam.TabIndex = 5;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // frmGiderCikisilayoutControl1ConvertedLayout
            // 
            this.frmGiderCikisilayoutControl1ConvertedLayout.Controls.Add(this.gridControl1);
            this.frmGiderCikisilayoutControl1ConvertedLayout.Controls.Add(this.btnDuzelt);
            this.frmGiderCikisilayoutControl1ConvertedLayout.Controls.Add(this.btnEkle);
            this.frmGiderCikisilayoutControl1ConvertedLayout.Controls.Add(this.btnTamam);
            this.frmGiderCikisilayoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmGiderCikisilayoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.frmGiderCikisilayoutControl1ConvertedLayout.Name = "frmGiderCikisilayoutControl1ConvertedLayout";
            this.frmGiderCikisilayoutControl1ConvertedLayout.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1041, 294, 900, 800);
            this.frmGiderCikisilayoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.frmGiderCikisilayoutControl1ConvertedLayout.Size = new System.Drawing.Size(834, 782);
            this.frmGiderCikisilayoutControl1ConvertedLayout.TabIndex = 6;
            // 
            // btnDuzelt
            // 
            this.btnDuzelt.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuzelt.Appearance.Options.UseFont = true;
            this.btnDuzelt.Location = new System.Drawing.Point(288, 647);
            this.btnDuzelt.Margin = new System.Windows.Forms.Padding(6);
            this.btnDuzelt.Name = "btnDuzelt";
            this.btnDuzelt.Size = new System.Drawing.Size(257, 111);
            this.btnDuzelt.StyleController = this.frmGiderCikisilayoutControl1ConvertedLayout;
            this.btnDuzelt.TabIndex = 5;
            this.btnDuzelt.Text = "Düzelt";
            this.btnDuzelt.Click += new System.EventHandler(this.btnDuzelt_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btnEkle.Appearance.Options.UseFont = true;
            this.btnEkle.Location = new System.Drawing.Point(553, 647);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(6);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(257, 111);
            this.btnEkle.StyleController = this.frmGiderCikisilayoutControl1ConvertedLayout;
            this.btnEkle.TabIndex = 5;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click_1);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Size = new System.Drawing.Size(834, 782);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(108, 59);
            this.layoutControlItem1.Name = "gridControl1item";
            this.layoutControlItem1.Size = new System.Drawing.Size(794, 623);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.Text = "Giderler";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(74, 25);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnDuzelt;
            this.layoutControlItem2.Location = new System.Drawing.Point(264, 623);
            this.layoutControlItem2.MaxSize = new System.Drawing.Size(0, 119);
            this.layoutControlItem2.MinSize = new System.Drawing.Size(107, 119);
            this.layoutControlItem2.Name = "btnDuzeltitem";
            this.layoutControlItem2.Size = new System.Drawing.Size(265, 119);
            this.layoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnEkle;
            this.layoutControlItem3.Location = new System.Drawing.Point(529, 623);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(0, 119);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(78, 119);
            this.layoutControlItem3.Name = "btnEkleitem";
            this.layoutControlItem3.Size = new System.Drawing.Size(265, 119);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnTamam;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 623);
            this.layoutControlItem4.MaxSize = new System.Drawing.Size(0, 119);
            this.layoutControlItem4.MinSize = new System.Drawing.Size(122, 119);
            this.layoutControlItem4.Name = "btnTamamitem";
            this.layoutControlItem4.Size = new System.Drawing.Size(264, 119);
            this.layoutControlItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 0;
            this.colAciklama.Width = 550;
            // 
            // colBorc
            // 
            this.colBorc.Caption = "Borc";
            this.colBorc.DisplayFormat.FormatString = "c2";
            this.colBorc.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colBorc.FieldName = "Borc";
            this.colBorc.Name = "colBorc";
            this.colBorc.Visible = true;
            this.colBorc.VisibleIndex = 1;
            this.colBorc.Width = 202;
            // 
            // frmGiderCikisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 782);
            this.Controls.Add(this.frmGiderCikisilayoutControl1ConvertedLayout);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "frmGiderCikisi";
            this.Text = "frmGiderCikisi";
            this.Load += new System.EventHandler(this.frmGiderCikisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frmGiderCikisilayoutControl1ConvertedLayout)).EndInit();
            this.frmGiderCikisilayoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private DevExpress.XtraEditors.SimpleButton btnDuzelt;
        private DevExpress.XtraLayout.LayoutControl frmGiderCikisilayoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colBorc;
    }
}