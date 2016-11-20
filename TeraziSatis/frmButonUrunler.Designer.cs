namespace TeraziSatis
{
    partial class frmButonUrunler
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
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.stokButonGrupVeStokButonlari1 = new clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari();
            this.SuspendLayout();
            // 
            // btnVazgec
            // 
            this.btnVazgec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVazgec.Location = new System.Drawing.Point(460, 12);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(163, 49);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Kapat";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // stokButonGrupVeStokButonlari1
            // 
            this.stokButonGrupVeStokButonlari1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stokButonGrupVeStokButonlari1.CausesValidation = false;
            this.stokButonGrupVeStokButonlari1.Location = new System.Drawing.Point(12, 76);
            this.stokButonGrupVeStokButonlari1.Name = "stokButonGrupVeStokButonlari1";
            this.stokButonGrupVeStokButonlari1.Size = new System.Drawing.Size(611, 646);
            this.stokButonGrupVeStokButonlari1.TabIndex = 0;
            // 
            // frmButonUrunler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 734);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.stokButonGrupVeStokButonlari1);
            this.Name = "frmButonUrunler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmButonUrunler";
            this.Load += new System.EventHandler(this.frmButonUrunler_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private clsTablolar.TeraziSatisClaslari.StokButonGrupVeStokButonlari stokButonGrupVeStokButonlari1;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
    }
}