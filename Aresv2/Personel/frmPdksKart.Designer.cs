namespace Aresv2.Personel
{
  partial class frmPdksKart
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
            this.btnPersonel = new DevExpress.XtraEditors.SimpleButton();
            this.lblPersonelAdi = new DevExpress.XtraEditors.LabelControl();
            this.txtZaman1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.checkEdit2 = new DevExpress.XtraEditors.CheckEdit();
            this.lkpYer = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtZaman1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpYer.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPersonel
            // 
            this.btnPersonel.Location = new System.Drawing.Point(12, 12);
            this.btnPersonel.Name = "btnPersonel";
            this.btnPersonel.Size = new System.Drawing.Size(177, 23);
            this.btnPersonel.TabIndex = 0;
            this.btnPersonel.Text = "Personel Bul";
            this.btnPersonel.Click += new System.EventHandler(this.btnPersonel_Click);
            // 
            // lblPersonelAdi
            // 
            this.lblPersonelAdi.Location = new System.Drawing.Point(12, 41);
            this.lblPersonelAdi.Name = "lblPersonelAdi";
            this.lblPersonelAdi.Size = new System.Drawing.Size(80, 16);
            this.lblPersonelAdi.TabIndex = 1;
            this.lblPersonelAdi.Text = "lblPersonelAdi";
            // 
            // txtZaman1
            // 
            this.txtZaman1.EditValue = new System.DateTime(2013, 3, 27, 17, 17, 13, 310);
            this.txtZaman1.Location = new System.Drawing.Point(20, 116);
            this.txtZaman1.Name = "txtZaman1";
            this.txtZaman1.Properties.DisplayFormat.FormatString = "T";
            this.txtZaman1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.txtZaman1.Properties.EditFormat.FormatString = "T";
            this.txtZaman1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtZaman1.Size = new System.Drawing.Size(217, 22);
            this.txtZaman1.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(39, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Zaman";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(20, 153);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(111, 23);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(137, 153);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(111, 23);
            this.btnVazgec.TabIndex = 4;
            this.btnVazgec.Text = "Vazgeç";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(254, 153);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(111, 23);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            // 
            // checkEdit2
            // 
            this.checkEdit2.Location = new System.Drawing.Point(241, 68);
            this.checkEdit2.Name = "checkEdit2";
            this.checkEdit2.Properties.Caption = "Mesai Başlangıcı";
            this.checkEdit2.Size = new System.Drawing.Size(149, 20);
            this.checkEdit2.TabIndex = 6;
            // 
            // lkpYer
            // 
            this.lkpYer.Location = new System.Drawing.Point(243, 116);
            this.lkpYer.Name = "lkpYer";
            this.lkpYer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpYer.Size = new System.Drawing.Size(200, 22);
            this.lkpYer.TabIndex = 8;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(243, 94);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(19, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Yer";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Location = new System.Drawing.Point(243, 7);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(289, 50);
            this.labelControl4.TabIndex = 9;
            this.labelControl4.Text = "Son";
            // 
            // frmPdksKart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 192);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.lkpYer);
            this.Controls.Add(this.checkEdit2);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtZaman1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lblPersonelAdi);
            this.Controls.Add(this.btnPersonel);
            this.Name = "frmPdksKart";
            this.Text = "frmPdksKArt";
            this.Load += new System.EventHandler(this.frmPdksKart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtZaman1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpYer.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnPersonel;
    private DevExpress.XtraEditors.LabelControl lblPersonelAdi;
    private DevExpress.XtraEditors.TextEdit txtZaman1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraEditors.SimpleButton btnVazgec;
    private DevExpress.XtraEditors.SimpleButton btnSil;
    private DevExpress.XtraEditors.CheckEdit checkEdit2;
    private DevExpress.XtraEditors.LookUpEdit lkpYer;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl4;
  }
}