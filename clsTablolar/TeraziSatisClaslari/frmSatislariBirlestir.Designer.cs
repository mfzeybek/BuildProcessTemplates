namespace clsTablolar.TeraziSatisClaslari
{
    partial class frmSatislariBirlestir
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
            this.txtBarkodIki = new DevExpress.XtraEditors.TextEdit();
            this.txtBarkodBir = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnBirlestir = new DevExpress.XtraEditors.SimpleButton();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblMesaj = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodIki.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodBir.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBarkodIki
            // 
            this.txtBarkodIki.Location = new System.Drawing.Point(171, 117);
            this.txtBarkodIki.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarkodIki.Name = "txtBarkodIki";
            this.txtBarkodIki.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtBarkodIki.Properties.Appearance.Options.UseFont = true;
            this.txtBarkodIki.Size = new System.Drawing.Size(321, 36);
            this.txtBarkodIki.TabIndex = 0;
            // 
            // txtBarkodBir
            // 
            this.txtBarkodBir.Location = new System.Drawing.Point(171, 161);
            this.txtBarkodBir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBarkodBir.Name = "txtBarkodBir";
            this.txtBarkodBir.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.txtBarkodBir.Properties.Appearance.Options.UseFont = true;
            this.txtBarkodBir.Size = new System.Drawing.Size(321, 36);
            this.txtBarkodBir.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(14, 174);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(140, 21);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Barkod Numarası 1";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Location = new System.Drawing.Point(14, 129);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(140, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Barkod Numarası 2";
            // 
            // btnBirlestir
            // 
            this.btnBirlestir.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnBirlestir.Appearance.Options.UseFont = true;
            this.btnBirlestir.Location = new System.Drawing.Point(171, 302);
            this.btnBirlestir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnBirlestir.Name = "btnBirlestir";
            this.btnBirlestir.Size = new System.Drawing.Size(208, 55);
            this.btnBirlestir.TabIndex = 3;
            this.btnBirlestir.Text = "Birleştir";
            this.btnBirlestir.Click += new System.EventHandler(this.btnBirlestir_Click);
            // 
            // btnKapat
            // 
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.Location = new System.Drawing.Point(171, 364);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(208, 55);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Location = new System.Drawing.Point(0, 0);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(497, 74);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Barkod Numarası 2 yazan yerdeki Tüm hareketleri Barkod Numarası 1 e aktarır\r\nBark" +
    "od 2 Fişini Çöpe At, Barkod 1 i kullan";
            // 
            // lblMesaj
            // 
            this.lblMesaj.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblMesaj.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMesaj.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMesaj.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMesaj.Location = new System.Drawing.Point(0, 220);
            this.lblMesaj.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMesaj.Name = "lblMesaj";
            this.lblMesaj.Size = new System.Drawing.Size(497, 74);
            this.lblMesaj.TabIndex = 5;
            // 
            // frmSatislariBirlestir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 447);
            this.Controls.Add(this.lblMesaj);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.btnBirlestir);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtBarkodBir);
            this.Controls.Add(this.txtBarkodIki);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmSatislariBirlestir";
            this.Text = "frmSatislariBirlestir";
            this.Load += new System.EventHandler(this.frmSatislariBirlestir_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSatislariBirlestir_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodIki.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkodBir.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtBarkodIki;
        private DevExpress.XtraEditors.TextEdit txtBarkodBir;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnBirlestir;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblMesaj;
    }
}