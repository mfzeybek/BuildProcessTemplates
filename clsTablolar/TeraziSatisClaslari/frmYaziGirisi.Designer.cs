namespace clsTablolar.TeraziSatisClaslari
{
    partial class frmYaziGirisi
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
            this.memoEdit1 = new DevExpress.XtraEditors.MemoEdit();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnTemizle = new DevExpress.XtraEditors.SimpleButton();
            this.btnKlavyeyiAc = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(6, 62);
            this.memoEdit1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.memoEdit1.Properties.Appearance.Options.UseFont = true;
            this.memoEdit1.Size = new System.Drawing.Size(635, 169);
            this.memoEdit1.TabIndex = 0;
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(288, 236);
            this.btnVazgec.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(139, 49);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Enabled = false;
            this.labelControl1.Location = new System.Drawing.Point(6, 3);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(512, 55);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "labelControl1";
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(6, 236);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(217, 49);
            this.btnTamam.TabIndex = 1;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.Location = new System.Drawing.Point(492, 236);
            this.btnTemizle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(148, 49);
            this.btnTemizle.TabIndex = 3;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // btnKlavyeyiAc
            // 
            this.btnKlavyeyiAc.Location = new System.Drawing.Point(524, 10);
            this.btnKlavyeyiAc.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnKlavyeyiAc.Name = "btnKlavyeyiAc";
            this.btnKlavyeyiAc.Size = new System.Drawing.Size(112, 43);
            this.btnKlavyeyiAc.TabIndex = 4;
            this.btnKlavyeyiAc.Text = "Klavyeyi Aç";
            this.btnKlavyeyiAc.Click += new System.EventHandler(this.btnKlavyeyiAc_Click);
            // 
            // frmYaziGirisi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 291);
            this.ControlBox = false;
            this.Controls.Add(this.btnKlavyeyiAc);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.memoEdit1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frmYaziGirisi";
            this.Text = "Yaz Hamısına";
            this.Load += new System.EventHandler(this.frmYaziGirisi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnTamam;
        private DevExpress.XtraEditors.SimpleButton btnTemizle;
        public DevExpress.XtraEditors.MemoEdit memoEdit1;
        public DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnKlavyeyiAc;



    }
}