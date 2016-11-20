namespace AresUrunTanitim
{
  partial class frmAnaFormParametre
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
      this.lkpFiyatTanim = new DevExpress.XtraEditors.LookUpEdit();
      this.btnAresStokListesiniCek = new DevExpress.XtraEditors.SimpleButton();
      this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
      this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
      this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
      this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
      this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
      this.btnBaglantiAyarlariKaydet = new DevExpress.XtraEditors.SimpleButton();
      this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
      this.cmUrunTanitimDbName = new DevExpress.XtraEditors.ComboBoxEdit();
      this.txtUrunTanitimServerName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
      this.comboBoxEdit1 = new DevExpress.XtraEditors.ComboBoxEdit();
      this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
      this.txtUrunTanitimPassword = new DevExpress.XtraEditors.TextEdit();
      this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
      this.txtUrunTanitimUserName = new DevExpress.XtraEditors.TextEdit();
      this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
      this.cmAresbDbName = new DevExpress.XtraEditors.ComboBoxEdit();
      this.txtAresServerNane = new DevExpress.XtraEditors.TextEdit();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.cmbAuthentication = new DevExpress.XtraEditors.ComboBoxEdit();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.txtAresPassword = new DevExpress.XtraEditors.TextEdit();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.txtAresUserName = new DevExpress.XtraEditors.TextEdit();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.lkpFiyatTanim.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
      this.groupControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
      this.xtraTabControl1.SuspendLayout();
      this.xtraTabPage1.SuspendLayout();
      this.xtraTabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
      this.groupControl4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmUrunTanitimDbName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUrunTanitimServerName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUrunTanitimPassword.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUrunTanitimUserName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
      this.groupControl3.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmAresbDbName.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresServerNane.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.cmbAuthentication.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresPassword.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresUserName.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // lkpFiyatTanim
      // 
      this.lkpFiyatTanim.Location = new System.Drawing.Point(5, 28);
      this.lkpFiyatTanim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.lkpFiyatTanim.Name = "lkpFiyatTanim";
      this.lkpFiyatTanim.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.lkpFiyatTanim.Properties.NullText = "Fiyat Tanım Seçiniz.";
      this.lkpFiyatTanim.Size = new System.Drawing.Size(166, 22);
      this.lkpFiyatTanim.TabIndex = 0;
      // 
      // btnAresStokListesiniCek
      // 
      this.btnAresStokListesiniCek.Location = new System.Drawing.Point(5, 58);
      this.btnAresStokListesiniCek.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.btnAresStokListesiniCek.Name = "btnAresStokListesiniCek";
      this.btnAresStokListesiniCek.Size = new System.Drawing.Size(166, 34);
      this.btnAresStokListesiniCek.TabIndex = 1;
      this.btnAresStokListesiniCek.Text = "&Ares ten verileri al";
      this.btnAresStokListesiniCek.Click += new System.EventHandler(this.btnAresStokListesiniCek_Click);
      // 
      // groupControl2
      // 
      this.groupControl2.Controls.Add(this.lkpFiyatTanim);
      this.groupControl2.Controls.Add(this.btnAresStokListesiniCek);
      this.groupControl2.Location = new System.Drawing.Point(3, 4);
      this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.groupControl2.Name = "groupControl2";
      this.groupControl2.Size = new System.Drawing.Size(610, 198);
      this.groupControl2.TabIndex = 1;
      this.groupControl2.Text = "Ares Stok Listesini Çek";
      // 
      // simpleButton1
      // 
      this.simpleButton1.Location = new System.Drawing.Point(12, 288);
      this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.simpleButton1.Name = "simpleButton1";
      this.simpleButton1.Size = new System.Drawing.Size(617, 34);
      this.simpleButton1.TabIndex = 4;
      this.simpleButton1.Text = "simpleButton1";
      this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
      // 
      // xtraTabControl1
      // 
      this.xtraTabControl1.Location = new System.Drawing.Point(12, 12);
      this.xtraTabControl1.Name = "xtraTabControl1";
      this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
      this.xtraTabControl1.Size = new System.Drawing.Size(622, 269);
      this.xtraTabControl1.TabIndex = 5;
      this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
      // 
      // xtraTabPage1
      // 
      this.xtraTabPage1.Controls.Add(this.groupControl2);
      this.xtraTabPage1.Name = "xtraTabPage1";
      this.xtraTabPage1.Size = new System.Drawing.Size(616, 238);
      this.xtraTabPage1.Text = "xtraTabPage1";
      // 
      // xtraTabPage2
      // 
      this.xtraTabPage2.Controls.Add(this.btnBaglantiAyarlariKaydet);
      this.xtraTabPage2.Controls.Add(this.groupControl4);
      this.xtraTabPage2.Controls.Add(this.groupControl3);
      this.xtraTabPage2.Name = "xtraTabPage2";
      this.xtraTabPage2.Size = new System.Drawing.Size(616, 238);
      this.xtraTabPage2.Text = "Baglanti Ayarlari";
      // 
      // btnBaglantiAyarlariKaydet
      // 
      this.btnBaglantiAyarlariKaydet.Location = new System.Drawing.Point(4, 204);
      this.btnBaglantiAyarlariKaydet.Name = "btnBaglantiAyarlariKaydet";
      this.btnBaglantiAyarlariKaydet.Size = new System.Drawing.Size(605, 23);
      this.btnBaglantiAyarlariKaydet.TabIndex = 6;
      this.btnBaglantiAyarlariKaydet.Text = "Kaydet";
      this.btnBaglantiAyarlariKaydet.Click += new System.EventHandler(this.btnBaglantiAyarlariKaydet_Click);
      // 
      // groupControl4
      // 
      this.groupControl4.Controls.Add(this.cmUrunTanitimDbName);
      this.groupControl4.Controls.Add(this.txtUrunTanitimServerName);
      this.groupControl4.Controls.Add(this.labelControl6);
      this.groupControl4.Controls.Add(this.comboBoxEdit1);
      this.groupControl4.Controls.Add(this.labelControl7);
      this.groupControl4.Controls.Add(this.labelControl8);
      this.groupControl4.Controls.Add(this.txtUrunTanitimPassword);
      this.groupControl4.Controls.Add(this.labelControl9);
      this.groupControl4.Controls.Add(this.labelControl10);
      this.groupControl4.Controls.Add(this.txtUrunTanitimUserName);
      this.groupControl4.Location = new System.Drawing.Point(309, 4);
      this.groupControl4.Name = "groupControl4";
      this.groupControl4.Size = new System.Drawing.Size(300, 194);
      this.groupControl4.TabIndex = 2;
      this.groupControl4.Text = "Ürün Tanıtım";
      // 
      // cmUrunTanitimDbName
      // 
      this.cmUrunTanitimDbName.Location = new System.Drawing.Point(106, 151);
      this.cmUrunTanitimDbName.Name = "cmUrunTanitimDbName";
      this.cmUrunTanitimDbName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cmUrunTanitimDbName.Size = new System.Drawing.Size(173, 22);
      this.cmUrunTanitimDbName.TabIndex = 13;
      // 
      // txtUrunTanitimServerName
      // 
      this.txtUrunTanitimServerName.Location = new System.Drawing.Point(106, 31);
      this.txtUrunTanitimServerName.Name = "txtUrunTanitimServerName";
      this.txtUrunTanitimServerName.Size = new System.Drawing.Size(173, 22);
      this.txtUrunTanitimServerName.TabIndex = 6;
      this.txtUrunTanitimServerName.Leave += new System.EventHandler(this.txtUrunTanitimServerName_Leave);
      // 
      // labelControl6
      // 
      this.labelControl6.Location = new System.Drawing.Point(16, 34);
      this.labelControl6.Name = "labelControl6";
      this.labelControl6.Size = new System.Drawing.Size(84, 16);
      this.labelControl6.TabIndex = 11;
      this.labelControl6.Text = "Server Name :";
      // 
      // comboBoxEdit1
      // 
      this.comboBoxEdit1.Location = new System.Drawing.Point(106, 61);
      this.comboBoxEdit1.Name = "comboBoxEdit1";
      this.comboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.comboBoxEdit1.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
      this.comboBoxEdit1.Size = new System.Drawing.Size(173, 22);
      this.comboBoxEdit1.TabIndex = 14;
      // 
      // labelControl7
      // 
      this.labelControl7.Location = new System.Drawing.Point(10, 64);
      this.labelControl7.Name = "labelControl7";
      this.labelControl7.Size = new System.Drawing.Size(90, 16);
      this.labelControl7.TabIndex = 10;
      this.labelControl7.Text = "Authentication :";
      // 
      // labelControl8
      // 
      this.labelControl8.Location = new System.Drawing.Point(28, 94);
      this.labelControl8.Name = "labelControl8";
      this.labelControl8.Size = new System.Drawing.Size(72, 16);
      this.labelControl8.TabIndex = 9;
      this.labelControl8.Text = "User Name :";
      // 
      // txtUrunTanitimPassword
      // 
      this.txtUrunTanitimPassword.Location = new System.Drawing.Point(106, 121);
      this.txtUrunTanitimPassword.Name = "txtUrunTanitimPassword";
      this.txtUrunTanitimPassword.Properties.PasswordChar = '*';
      this.txtUrunTanitimPassword.Size = new System.Drawing.Size(173, 22);
      this.txtUrunTanitimPassword.TabIndex = 4;
      // 
      // labelControl9
      // 
      this.labelControl9.Location = new System.Drawing.Point(36, 124);
      this.labelControl9.Name = "labelControl9";
      this.labelControl9.Size = new System.Drawing.Size(64, 16);
      this.labelControl9.TabIndex = 8;
      this.labelControl9.Text = "Password :";
      // 
      // labelControl10
      // 
      this.labelControl10.Location = new System.Drawing.Point(1, 154);
      this.labelControl10.Name = "labelControl10";
      this.labelControl10.Size = new System.Drawing.Size(99, 16);
      this.labelControl10.TabIndex = 7;
      this.labelControl10.Text = "Database Name :";
      // 
      // txtUrunTanitimUserName
      // 
      this.txtUrunTanitimUserName.Location = new System.Drawing.Point(106, 91);
      this.txtUrunTanitimUserName.Name = "txtUrunTanitimUserName";
      this.txtUrunTanitimUserName.Size = new System.Drawing.Size(173, 22);
      this.txtUrunTanitimUserName.TabIndex = 5;
      // 
      // groupControl3
      // 
      this.groupControl3.Controls.Add(this.cmAresbDbName);
      this.groupControl3.Controls.Add(this.txtAresServerNane);
      this.groupControl3.Controls.Add(this.labelControl1);
      this.groupControl3.Controls.Add(this.cmbAuthentication);
      this.groupControl3.Controls.Add(this.labelControl2);
      this.groupControl3.Controls.Add(this.txtAresPassword);
      this.groupControl3.Controls.Add(this.labelControl3);
      this.groupControl3.Controls.Add(this.txtAresUserName);
      this.groupControl3.Controls.Add(this.labelControl4);
      this.groupControl3.Controls.Add(this.labelControl5);
      this.groupControl3.Location = new System.Drawing.Point(3, 4);
      this.groupControl3.Name = "groupControl3";
      this.groupControl3.Size = new System.Drawing.Size(300, 194);
      this.groupControl3.TabIndex = 2;
      this.groupControl3.Text = "Ares";
      this.groupControl3.Paint += new System.Windows.Forms.PaintEventHandler(this.groupControl3_Paint);
      // 
      // cmAresbDbName
      // 
      this.cmAresbDbName.Location = new System.Drawing.Point(106, 154);
      this.cmAresbDbName.Name = "cmAresbDbName";
      this.cmAresbDbName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cmAresbDbName.Size = new System.Drawing.Size(173, 22);
      this.cmAresbDbName.TabIndex = 13;
      // 
      // txtAresServerNane
      // 
      this.txtAresServerNane.Location = new System.Drawing.Point(106, 34);
      this.txtAresServerNane.Name = "txtAresServerNane";
      this.txtAresServerNane.Size = new System.Drawing.Size(173, 22);
      this.txtAresServerNane.TabIndex = 6;
      this.txtAresServerNane.Leave += new System.EventHandler(this.txtAresServerNane_Leave);
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(16, 37);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(84, 16);
      this.labelControl1.TabIndex = 11;
      this.labelControl1.Text = "Server Name :";
      // 
      // cmbAuthentication
      // 
      this.cmbAuthentication.Location = new System.Drawing.Point(106, 64);
      this.cmbAuthentication.Name = "cmbAuthentication";
      this.cmbAuthentication.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.cmbAuthentication.Properties.Items.AddRange(new object[] {
            "Windows Authentication",
            "SQL Server Authentication"});
      this.cmbAuthentication.Size = new System.Drawing.Size(173, 22);
      this.cmbAuthentication.TabIndex = 14;
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(10, 67);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(90, 16);
      this.labelControl2.TabIndex = 10;
      this.labelControl2.Text = "Authentication :";
      // 
      // txtAresPassword
      // 
      this.txtAresPassword.Location = new System.Drawing.Point(106, 124);
      this.txtAresPassword.Name = "txtAresPassword";
      this.txtAresPassword.Properties.PasswordChar = '*';
      this.txtAresPassword.Size = new System.Drawing.Size(173, 22);
      this.txtAresPassword.TabIndex = 4;
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(28, 97);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(72, 16);
      this.labelControl3.TabIndex = 9;
      this.labelControl3.Text = "User Name :";
      // 
      // txtAresUserName
      // 
      this.txtAresUserName.Location = new System.Drawing.Point(106, 94);
      this.txtAresUserName.Name = "txtAresUserName";
      this.txtAresUserName.Size = new System.Drawing.Size(173, 22);
      this.txtAresUserName.TabIndex = 5;
      // 
      // labelControl4
      // 
      this.labelControl4.Location = new System.Drawing.Point(36, 127);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(64, 16);
      this.labelControl4.TabIndex = 8;
      this.labelControl4.Text = "Password :";
      // 
      // labelControl5
      // 
      this.labelControl5.Location = new System.Drawing.Point(1, 157);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(99, 16);
      this.labelControl5.TabIndex = 7;
      this.labelControl5.Text = "Database Name :";
      // 
      // frmAnaFormParametre
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(644, 339);
      this.Controls.Add(this.xtraTabControl1);
      this.Controls.Add(this.simpleButton1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.KeyPreview = true;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "frmAnaFormParametre";
      this.ShowIcon = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "  ..::  Parametleri Yönet";
      this.Load += new System.EventHandler(this.frmAnaFormParametre_Load);
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAnaFormParametre_KeyDown);
      ((System.ComponentModel.ISupportInitialize)(this.lkpFiyatTanim.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
      this.groupControl2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
      this.xtraTabControl1.ResumeLayout(false);
      this.xtraTabPage1.ResumeLayout(false);
      this.xtraTabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
      this.groupControl4.ResumeLayout(false);
      this.groupControl4.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmUrunTanitimDbName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUrunTanitimServerName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUrunTanitimPassword.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtUrunTanitimUserName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
      this.groupControl3.ResumeLayout(false);
      this.groupControl3.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.cmAresbDbName.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresServerNane.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.cmbAuthentication.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresPassword.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.txtAresUserName.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraEditors.LookUpEdit lkpFiyatTanim;
    private DevExpress.XtraEditors.SimpleButton btnAresStokListesiniCek;
    private DevExpress.XtraEditors.GroupControl groupControl2;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    private DevExpress.XtraEditors.ComboBoxEdit cmAresbDbName;
    private DevExpress.XtraEditors.ComboBoxEdit cmbAuthentication;
    private DevExpress.XtraEditors.TextEdit txtAresPassword;
    private DevExpress.XtraEditors.TextEdit txtAresUserName;
    private DevExpress.XtraEditors.TextEdit txtAresServerNane;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.GroupControl groupControl4;
    private DevExpress.XtraEditors.ComboBoxEdit cmUrunTanitimDbName;
    private DevExpress.XtraEditors.TextEdit txtUrunTanitimServerName;
    private DevExpress.XtraEditors.LabelControl labelControl6;
    private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl7;
    private DevExpress.XtraEditors.LabelControl labelControl8;
    private DevExpress.XtraEditors.TextEdit txtUrunTanitimPassword;
    private DevExpress.XtraEditors.LabelControl labelControl9;
    private DevExpress.XtraEditors.LabelControl labelControl10;
    private DevExpress.XtraEditors.TextEdit txtUrunTanitimUserName;
    private DevExpress.XtraEditors.GroupControl groupControl3;
    private DevExpress.XtraEditors.SimpleButton btnBaglantiAyarlariKaydet;
  }
}