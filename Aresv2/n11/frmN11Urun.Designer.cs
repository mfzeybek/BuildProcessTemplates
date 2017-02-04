namespace Aresv2.n11
{
    partial class frmN11Urun
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
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.treeListLookUpEdit1 = new DevExpress.XtraEditors.TreeListLookUpEdit();
            this.treeListLookUpEdit1TreeList = new DevExpress.XtraTreeList.TreeList();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAciklamaDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.DetayliUrunBilgisi = new System.Windows.Forms.WebBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).BeginInit();
            this.SuspendLayout();
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(77, 101);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(498, 34);
            this.textEdit1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(77, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 25);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Kategori Adı";
            // 
            // treeListLookUpEdit1
            // 
            this.treeListLookUpEdit1.Location = new System.Drawing.Point(699, 101);
            this.treeListLookUpEdit1.Name = "treeListLookUpEdit1";
            this.treeListLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.treeListLookUpEdit1.Properties.TreeList = this.treeListLookUpEdit1TreeList;
            this.treeListLookUpEdit1.Size = new System.Drawing.Size(468, 34);
            this.treeListLookUpEdit1.TabIndex = 2;
            // 
            // treeListLookUpEdit1TreeList
            // 
            this.treeListLookUpEdit1TreeList.Location = new System.Drawing.Point(0, 0);
            this.treeListLookUpEdit1TreeList.Name = "treeListLookUpEdit1TreeList";
            this.treeListLookUpEdit1TreeList.OptionsBehavior.EnableFiltering = true;
            this.treeListLookUpEdit1TreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.treeListLookUpEdit1TreeList.Size = new System.Drawing.Size(400, 200);
            this.treeListLookUpEdit1TreeList.TabIndex = 0;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(711, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(114, 25);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Kategori Adı";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(47, 1384);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(293, 105);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Kaydet";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(874, 1384);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(293, 105);
            this.simpleButton2.TabIndex = 3;
            this.simpleButton2.Text = "Sil";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(368, 1384);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(293, 105);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "Vazgeç";
            // 
            // btnAciklamaDuzenle
            // 
            this.btnAciklamaDuzenle.Location = new System.Drawing.Point(324, 390);
            this.btnAciklamaDuzenle.Name = "btnAciklamaDuzenle";
            this.btnAciklamaDuzenle.Size = new System.Drawing.Size(288, 61);
            this.btnAciklamaDuzenle.TabIndex = 4;
            this.btnAciklamaDuzenle.Text = "Düzenle";
            this.btnAciklamaDuzenle.Click += new System.EventHandler(this.btnAciklamaDuzenle_Click);
            // 
            // DetayliUrunBilgisi
            // 
            this.DetayliUrunBilgisi.Location = new System.Drawing.Point(31, 610);
            this.DetayliUrunBilgisi.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.DetayliUrunBilgisi.MinimumSize = new System.Drawing.Size(34, 31);
            this.DetayliUrunBilgisi.Name = "DetayliUrunBilgisi";
            this.DetayliUrunBilgisi.Size = new System.Drawing.Size(1252, 367);
            this.DetayliUrunBilgisi.TabIndex = 7;
            // 
            // frmN11Urun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1870, 1591);
            this.Controls.Add(this.DetayliUrunBilgisi);
            this.Controls.Add(this.btnAciklamaDuzenle);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.treeListLookUpEdit1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.textEdit1);
            this.Name = "frmN11Urun";
            this.Text = "frmN11Urun";
            this.Load += new System.EventHandler(this.frmN11Urun_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeListLookUpEdit1TreeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TreeListLookUpEdit treeListLookUpEdit1;
        private DevExpress.XtraTreeList.TreeList treeListLookUpEdit1TreeList;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton btnAciklamaDuzenle;
        private System.Windows.Forms.WebBrowser DetayliUrunBilgisi;
    }
}