namespace Aresv2
{
  partial class frmKullaniciGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKullaniciGiris));
            this.txtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.txtKullaniciSifre = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit3 = new DevExpress.XtraEditors.ButtonEdit();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            this.btnIptal = new DevExpress.XtraEditors.SimpleButton();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            this.btnAyarlar = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.EditValue = "1";
            this.txtKullaniciAdi.Location = new System.Drawing.Point(176, 23);
            this.txtKullaniciAdi.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(454, 34);
            this.txtKullaniciAdi.TabIndex = 0;
            this.txtKullaniciAdi.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.txtKullaniciAdi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKullaniciAdi_KeyDown);
            this.txtKullaniciAdi.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            // 
            // txtKullaniciSifre
            // 
            this.txtKullaniciSifre.EditValue = "1";
            this.txtKullaniciSifre.Location = new System.Drawing.Point(176, 73);
            this.txtKullaniciSifre.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtKullaniciSifre.Name = "txtKullaniciSifre";
            this.txtKullaniciSifre.Properties.PasswordChar = '*';
            this.txtKullaniciSifre.Size = new System.Drawing.Size(454, 34);
            this.txtKullaniciSifre.TabIndex = 1;
            this.txtKullaniciSifre.Enter += new System.EventHandler(this.AktifTextBackColorChange);
            this.txtKullaniciSifre.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKullaniciSifre_KeyDown);
            this.txtKullaniciSifre.Leave += new System.EventHandler(this.PasifTextBackColorChange);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 29);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(114, 25);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Kullanıcı Adı";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 79);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(141, 25);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Kullanıcı Şifresi";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 129);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(53, 25);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Firma";
            // 
            // textEdit3
            // 
            this.textEdit3.Location = new System.Drawing.Point(176, 123);
            this.textEdit3.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.textEdit3.Size = new System.Drawing.Size(454, 34);
            this.textEdit3.TabIndex = 2;
            // 
            // btnTamam
            // 
            this.btnTamam.Appearance.Image = global::Aresv2.Properties.Resources.Double_J_Design_Origami_Colored_Pencil_Blue_ok;
            this.btnTamam.Appearance.Options.UseImage = true;
            this.btnTamam.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnTamam.Image = global::Aresv2.Properties.Resources.blue_ok_icon_1_;
            this.btnTamam.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTamam.Location = new System.Drawing.Point(176, 171);
            this.btnTamam.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(144, 63);
            this.btnTamam.TabIndex = 3;
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.Image = global::Aresv2.Properties.Resources.blue_cross_icon_1_;
            this.btnIptal.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnIptal.Location = new System.Drawing.Point(330, 171);
            this.btnIptal.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(144, 63);
            this.btnIptal.TabIndex = 4;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "DevExpress Dark Style";
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.Location = new System.Drawing.Point(486, 169);
            this.btnAyarlar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(144, 65);
            this.btnAyarlar.TabIndex = 5;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // frmKullaniciGiris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 279);
            this.Controls.Add(this.btnAyarlar);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtKullaniciSifre);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.textEdit3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmKullaniciGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ares Kullanıcı Girişi";
            this.Load += new System.EventHandler(this.frmKullaniciGiris_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKullaniciSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.TextEdit txtKullaniciAdi;
    private DevExpress.XtraEditors.TextEdit txtKullaniciSifre;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.ButtonEdit textEdit3;
    private DevExpress.XtraEditors.SimpleButton btnTamam;
    private DevExpress.XtraEditors.SimpleButton btnIptal;
    public DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    private DevExpress.XtraEditors.SimpleButton btnAyarlar;
  }
}