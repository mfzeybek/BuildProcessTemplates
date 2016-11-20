namespace TeraziSatis
{
    partial class frmGuncelleme
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
            this.lblGuncellemeVarMi = new DevExpress.XtraEditors.LabelControl();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Enabled = false;
            this.simpleButton1.Location = new System.Drawing.Point(43, 198);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(161, 43);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Güncelle";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // lblGuncellemeVarMi
            // 
            this.lblGuncellemeVarMi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblGuncellemeVarMi.Location = new System.Drawing.Point(12, 21);
            this.lblGuncellemeVarMi.Name = "lblGuncellemeVarMi";
            this.lblGuncellemeVarMi.Size = new System.Drawing.Size(223, 143);
            this.lblGuncellemeVarMi.TabIndex = 1;
            this.lblGuncellemeVarMi.Text = "lblGuncellemeVarMi";
            // 
            // frmGuncelleme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 253);
            this.Controls.Add(this.lblGuncellemeVarMi);
            this.Controls.Add(this.simpleButton1);
            this.Name = "frmGuncelleme";
            this.Text = "Guncelleme";
            this.Load += new System.EventHandler(this.Guncelleme_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl lblGuncellemeVarMi;
    }
}