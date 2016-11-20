namespace PDKS
{
  partial class frmPDKS
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAdiSoyadi = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblZaman = new System.Windows.Forms.Label();
            this.btnBugunkuHareketlerimiGoster = new DevExpress.XtraEditors.SimpleButton();
            this.txtPersonelSifre = new DevExpress.XtraEditors.TextEdit();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnKimNerede = new DevExpress.XtraEditors.SimpleButton();
            this.timer_kimneredeGoster = new System.Windows.Forms.Timer(this.components);
            this.lblBilgilendirme = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelSifre.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(50, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Adı Soyadı";
            // 
            // lblAdiSoyadi
            // 
            this.lblAdiSoyadi.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAdiSoyadi.Location = new System.Drawing.Point(330, 95);
            this.lblAdiSoyadi.Name = "lblAdiSoyadi";
            this.lblAdiSoyadi.Size = new System.Drawing.Size(344, 23);
            this.lblAdiSoyadi.TabIndex = 0;
            this.lblAdiSoyadi.Text = "Adı Soyadı";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(50, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 27);
            this.label3.TabIndex = 0;
            this.label3.Text = "Giriş / Çıkış Zamanı";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(51, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 27);
            this.label6.TabIndex = 0;
            this.label6.Text = "Şifre";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(661, 91);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(165, 188);
            this.pictureEdit1.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(304, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 27);
            this.label7.TabIndex = 3;
            this.label7.Text = ":";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(304, 124);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 27);
            this.label8.TabIndex = 3;
            this.label8.Text = ":";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(304, 243);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(20, 27);
            this.label11.TabIndex = 3;
            this.label11.Text = ":";
            // 
            // lblZaman
            // 
            this.lblZaman.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblZaman.Location = new System.Drawing.Point(330, 128);
            this.lblZaman.Name = "lblZaman";
            this.lblZaman.Size = new System.Drawing.Size(344, 23);
            this.lblZaman.TabIndex = 0;
            this.lblZaman.Text = "Giriş Çıkış Zamanı";
            // 
            // btnBugunkuHareketlerimiGoster
            // 
            this.btnBugunkuHareketlerimiGoster.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBugunkuHareketlerimiGoster.Location = new System.Drawing.Point(877, 605);
            this.btnBugunkuHareketlerimiGoster.Name = "btnBugunkuHareketlerimiGoster";
            this.btnBugunkuHareketlerimiGoster.Size = new System.Drawing.Size(193, 43);
            this.btnBugunkuHareketlerimiGoster.TabIndex = 5;
            this.btnBugunkuHareketlerimiGoster.Text = "Bugünkü Hareketlerimi Göster";
            this.btnBugunkuHareketlerimiGoster.Click += new System.EventHandler(this.btnBugunkuHareketlerimiGoster_Click);
            // 
            // txtPersonelSifre
            // 
            this.txtPersonelSifre.Location = new System.Drawing.Point(335, 240);
            this.txtPersonelSifre.Name = "txtPersonelSifre";
            this.txtPersonelSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13F);
            this.txtPersonelSifre.Properties.Appearance.Options.UseFont = true;
            this.txtPersonelSifre.Size = new System.Drawing.Size(245, 34);
            this.txtPersonelSifre.TabIndex = 0;
            this.txtPersonelSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPersonelSifre_KeyDown);
            // 
            // timer1
            // 
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnKimNerede
            // 
            this.btnKimNerede.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKimNerede.Location = new System.Drawing.Point(733, 605);
            this.btnKimNerede.Name = "btnKimNerede";
            this.btnKimNerede.Size = new System.Drawing.Size(138, 43);
            this.btnKimNerede.TabIndex = 9;
            this.btnKimNerede.Text = "Kim Nerede";
            this.btnKimNerede.Click += new System.EventHandler(this.btnKimNerede_Click);
            // 
            // lblBilgilendirme
            // 
            this.lblBilgilendirme.Font = new System.Drawing.Font("Tahoma", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblBilgilendirme.ForeColor = System.Drawing.Color.Red;
            this.lblBilgilendirme.Location = new System.Drawing.Point(51, 298);
            this.lblBilgilendirme.Name = "lblBilgilendirme";
            this.lblBilgilendirme.Size = new System.Drawing.Size(775, 105);
            this.lblBilgilendirme.TabIndex = 0;
            this.lblBilgilendirme.Text = "Bilgilendirme";
            this.lblBilgilendirme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPDKS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 660);
            this.Controls.Add(this.btnKimNerede);
            this.Controls.Add(this.txtPersonelSifre);
            this.Controls.Add(this.btnBugunkuHareketlerimiGoster);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.lblBilgilendirme);
            this.Controls.Add(this.lblZaman);
            this.Controls.Add(this.lblAdiSoyadi);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.KeyPreview = true;
            this.Name = "frmPDKS";
            this.Text = "frmPDKS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPDKS_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPDKS_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPersonelSifre.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label lblAdiSoyadi;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label6;
    private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label8;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.Label lblZaman;
    private DevExpress.XtraEditors.SimpleButton btnBugunkuHareketlerimiGoster;
    private DevExpress.XtraEditors.TextEdit txtPersonelSifre;
    private System.Windows.Forms.Timer timer1;
    private DevExpress.XtraEditors.SimpleButton btnKimNerede;
    private System.Windows.Forms.Timer timer_kimneredeGoster;
    private System.Windows.Forms.Label lblBilgilendirme;
  }
}