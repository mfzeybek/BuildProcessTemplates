namespace Aresv2.Stok
{
    partial class frmFotoKatalog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFotoKatalog));
            this.ımageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.layoutView1 = new DevExpress.XtraGrid.Views.Layout.LayoutView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.layoutViewField_gridColumn1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.layoutViewField_gridColumn2 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn3 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn4 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.LayoutViewColumn();
            this.layoutViewField_gridColumn5 = new DevExpress.XtraGrid.Views.Layout.LayoutViewField();
            this.layoutViewCard1 = new DevExpress.XtraGrid.Views.Layout.LayoutViewCard();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).BeginInit();
            this.SuspendLayout();
            // 
            // ımageSlider1
            // 
            this.ımageSlider1.CurrentImageIndex = 0;
            this.ımageSlider1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images1"))));
            this.ımageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("ımageSlider1.Images2"))));
            this.ımageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.MiddleCenter;
            this.ımageSlider1.Location = new System.Drawing.Point(28, 23);
            this.ımageSlider1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ımageSlider1.Name = "ımageSlider1";
            this.ımageSlider1.Size = new System.Drawing.Size(896, 596);
            this.ımageSlider1.TabIndex = 0;
            this.ımageSlider1.Text = "ımageSlider1";
            this.ımageSlider1.Click += new System.EventHandler(this.ımageSlider1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Location = new System.Drawing.Point(968, 23);
            this.gridControl1.MainView = this.layoutView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemImageEdit1});
            this.gridControl1.Size = new System.Drawing.Size(660, 733);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.layoutView1});
            // 
            // layoutView1
            // 
            this.layoutView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.LayoutViewColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.layoutView1.GridControl = this.gridControl1;
            this.layoutView1.Name = "layoutView1";
            this.layoutView1.TemplateCard = this.layoutViewCard1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "gridColumn1";
            this.gridColumn1.ColumnEdit = this.repositoryItemPictureEdit1;
            this.gridColumn1.LayoutViewField = this.layoutViewField_gridColumn1;
            this.gridColumn1.Name = "gridColumn1";
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // layoutViewField_gridColumn1
            // 
            this.layoutViewField_gridColumn1.EditorPreferredWidth = 132;
            this.layoutViewField_gridColumn1.Location = new System.Drawing.Point(0, 0);
            this.layoutViewField_gridColumn1.Name = "layoutViewField_gridColumn1";
            this.layoutViewField_gridColumn1.Size = new System.Drawing.Size(133, 24);
            this.layoutViewField_gridColumn1.StartNewLine = true;
            this.layoutViewField_gridColumn1.TextSize = new System.Drawing.Size(126, 25);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "gridColumn2";
            this.gridColumn2.ColumnEdit = this.repositoryItemImageEdit1;
            this.gridColumn2.LayoutViewField = this.layoutViewField_gridColumn2;
            this.gridColumn2.Name = "gridColumn2";
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // layoutViewField_gridColumn2
            // 
            this.layoutViewField_gridColumn2.EditorPreferredWidth = 132;
            this.layoutViewField_gridColumn2.Location = new System.Drawing.Point(0, 24);
            this.layoutViewField_gridColumn2.Name = "layoutViewField_gridColumn2";
            this.layoutViewField_gridColumn2.Size = new System.Drawing.Size(133, 22);
            this.layoutViewField_gridColumn2.TextSize = new System.Drawing.Size(126, 25);
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "gridColumn3";
            this.gridColumn3.LayoutViewField = this.layoutViewField_gridColumn3;
            this.gridColumn3.Name = "gridColumn3";
            // 
            // layoutViewField_gridColumn3
            // 
            this.layoutViewField_gridColumn3.EditorPreferredWidth = 132;
            this.layoutViewField_gridColumn3.Location = new System.Drawing.Point(0, 46);
            this.layoutViewField_gridColumn3.Name = "layoutViewField_gridColumn3";
            this.layoutViewField_gridColumn3.Size = new System.Drawing.Size(133, 22);
            this.layoutViewField_gridColumn3.TextSize = new System.Drawing.Size(126, 25);
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "gridColumn4";
            this.gridColumn4.LayoutViewField = this.layoutViewField_gridColumn4;
            this.gridColumn4.Name = "gridColumn4";
            // 
            // layoutViewField_gridColumn4
            // 
            this.layoutViewField_gridColumn4.EditorPreferredWidth = 132;
            this.layoutViewField_gridColumn4.Location = new System.Drawing.Point(0, 68);
            this.layoutViewField_gridColumn4.Name = "layoutViewField_gridColumn4";
            this.layoutViewField_gridColumn4.Size = new System.Drawing.Size(133, 20);
            this.layoutViewField_gridColumn4.TextSize = new System.Drawing.Size(126, 25);
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "gridColumn5";
            this.gridColumn5.LayoutViewField = this.layoutViewField_gridColumn5;
            this.gridColumn5.Name = "gridColumn5";
            // 
            // layoutViewField_gridColumn5
            // 
            this.layoutViewField_gridColumn5.EditorPreferredWidth = 132;
            this.layoutViewField_gridColumn5.Location = new System.Drawing.Point(0, 88);
            this.layoutViewField_gridColumn5.Name = "layoutViewField_gridColumn5";
            this.layoutViewField_gridColumn5.Size = new System.Drawing.Size(133, 24);
            this.layoutViewField_gridColumn5.TextSize = new System.Drawing.Size(126, 25);
            // 
            // layoutViewCard1
            // 
            this.layoutViewCard1.HeaderButtonsLocation = DevExpress.Utils.GroupElementLocation.AfterText;
            this.layoutViewCard1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutViewField_gridColumn1,
            this.layoutViewField_gridColumn2,
            this.layoutViewField_gridColumn3,
            this.layoutViewField_gridColumn4,
            this.layoutViewField_gridColumn5});
            this.layoutViewCard1.Name = "layoutViewTemplateCard";
            // 
            // frmFotoKatalog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1726, 904);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ımageSlider1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmFotoKatalog";
            this.Text = "frmFotoKatalog";
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewField_gridColumn5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutViewCard1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn1;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn2;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn3;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn3;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn4;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn4;
        private DevExpress.XtraGrid.Columns.LayoutViewColumn gridColumn5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewField layoutViewField_gridColumn5;
        private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
    }
}