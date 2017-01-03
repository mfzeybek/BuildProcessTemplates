namespace clsTablolar
{
    partial class frmKapora
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
            this.memoEdit2 = new DevExpress.XtraEditors.MemoEdit();
            this.btnYazdir = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // memoEdit1
            // 
            this.memoEdit1.Location = new System.Drawing.Point(32, 18);
            this.memoEdit1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.memoEdit1.Name = "memoEdit1";
            this.memoEdit1.Size = new System.Drawing.Size(150, 148);
            this.memoEdit1.TabIndex = 0;
            // 
            // memoEdit2
            // 
            this.memoEdit2.Location = new System.Drawing.Point(240, 18);
            this.memoEdit2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.memoEdit2.Name = "memoEdit2";
            this.memoEdit2.Size = new System.Drawing.Size(150, 148);
            this.memoEdit2.TabIndex = 1;
            // 
            // btnYazdir
            // 
            this.btnYazdir.Location = new System.Drawing.Point(32, 590);
            this.btnYazdir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.Size = new System.Drawing.Size(261, 72);
            this.btnYazdir.TabIndex = 2;
            this.btnYazdir.Text = "btnYazdir";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(372, 329);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(226, 72);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Klavyeyi Aç";
            // 
            // frmKapora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1491, 682);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnYazdir);
            this.Controls.Add(this.memoEdit2);
            this.Controls.Add(this.memoEdit1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmKapora";
            this.Text = "frmKapora";
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit2.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.MemoEdit memoEdit1;
        private DevExpress.XtraEditors.MemoEdit memoEdit2;
        private DevExpress.XtraEditors.SimpleButton btnYazdir;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}