namespace Aresv2
{
    partial class ucStokGruplari
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGrupSil = new DevExpress.XtraEditors.SimpleButton();
            this.UserControl1layoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.btnGrupSec = new DevExpress.XtraEditors.SimpleButton();
            this.listBoxControl1 = new DevExpress.XtraEditors.ListBoxControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.UserControl1layoutControl1ConvertedLayout)).BeginInit();
            this.UserControl1layoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGrupSil
            // 
            this.btnGrupSil.Location = new System.Drawing.Point(350, 350);
            this.btnGrupSil.Margin = new System.Windows.Forms.Padding(6);
            this.btnGrupSil.Name = "btnGrupSil";
            this.btnGrupSil.Size = new System.Drawing.Size(105, 42);
            this.btnGrupSil.StyleController = this.UserControl1layoutControl1ConvertedLayout;
            this.btnGrupSil.TabIndex = 12;
            this.btnGrupSil.Text = "Sil";
            this.btnGrupSil.Click += new System.EventHandler(this.btnGrupSil_Click);
            // 
            // UserControl1layoutControl1ConvertedLayout
            // 
            this.UserControl1layoutControl1ConvertedLayout.Controls.Add(this.btnGrupSil);
            this.UserControl1layoutControl1ConvertedLayout.Controls.Add(this.btnGrupSec);
            this.UserControl1layoutControl1ConvertedLayout.Controls.Add(this.listBoxControl1);
            this.UserControl1layoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserControl1layoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.UserControl1layoutControl1ConvertedLayout.Name = "UserControl1layoutControl1ConvertedLayout";
            this.UserControl1layoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.UserControl1layoutControl1ConvertedLayout.Size = new System.Drawing.Size(463, 400);
            this.UserControl1layoutControl1ConvertedLayout.TabIndex = 13;
            // 
            // btnGrupSec
            // 
            this.btnGrupSec.Location = new System.Drawing.Point(8, 350);
            this.btnGrupSec.Margin = new System.Windows.Forms.Padding(6);
            this.btnGrupSec.Name = "btnGrupSec";
            this.btnGrupSec.Size = new System.Drawing.Size(334, 42);
            this.btnGrupSec.StyleController = this.UserControl1layoutControl1ConvertedLayout;
            this.btnGrupSec.TabIndex = 11;
            this.btnGrupSec.Text = "Grup Seç";
            this.btnGrupSec.Click += new System.EventHandler(this.btnGrupSec_Click);
            // 
            // listBoxControl1
            // 
            this.listBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.listBoxControl1.DisplayMember = "StokGrupAdi";
            this.listBoxControl1.HorizontalScrollbar = true;
            this.listBoxControl1.Location = new System.Drawing.Point(8, 8);
            this.listBoxControl1.Margin = new System.Windows.Forms.Padding(6);
            this.listBoxControl1.MultiColumn = true;
            this.listBoxControl1.Name = "listBoxControl1";
            this.listBoxControl1.Size = new System.Drawing.Size(447, 334);
            this.listBoxControl1.StyleController = this.UserControl1layoutControl1ConvertedLayout;
            this.listBoxControl1.TabIndex = 10;
            this.listBoxControl1.ValueMember = "StokGrupID";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.OptionsItemText.TextToControlDistance = 6;
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(463, 400);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.btnGrupSil;
            this.layoutControlItem1.Location = new System.Drawing.Point(342, 342);
            this.layoutControlItem1.Name = "btnGrupSilitem";
            this.layoutControlItem1.Size = new System.Drawing.Size(113, 50);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnGrupSec;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 342);
            this.layoutControlItem2.Name = "btnGrupSecitem";
            this.layoutControlItem2.Size = new System.Drawing.Size(342, 50);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.listBoxControl1;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "listBoxControl1item";
            this.layoutControlItem3.Size = new System.Drawing.Size(455, 342);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // ucStokGruplari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.UserControl1layoutControl1ConvertedLayout);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "ucStokGruplari";
            this.Size = new System.Drawing.Size(463, 400);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucStokGruplari_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.UserControl1layoutControl1ConvertedLayout)).EndInit();
            this.UserControl1layoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraLayout.LayoutControl UserControl1layoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        public DevExpress.XtraEditors.SimpleButton btnGrupSil;
        public DevExpress.XtraEditors.SimpleButton btnGrupSec;
        public DevExpress.XtraEditors.ListBoxControl listBoxControl1;
    }
}
