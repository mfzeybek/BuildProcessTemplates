namespace Aresv2.StokSayim
{
  partial class frmStokSayimKarsilastirma
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
            this.btnSayimBirSec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSayimIkiSec = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnKarsilastir = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.lblSayimBirAcikalama = new System.Windows.Forms.Label();
            this.lblSayimBirTarih = new System.Windows.Forms.Label();
            this.lblSayimIkiAciklama = new DevExpress.XtraEditors.LabelControl();
            this.lblSayimIkiTarih = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSayimBirSec
            // 
            this.btnSayimBirSec.Location = new System.Drawing.Point(100, 19);
            this.btnSayimBirSec.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSayimBirSec.Name = "btnSayimBirSec";
            this.btnSayimBirSec.Size = new System.Drawing.Size(346, 37);
            this.btnSayimBirSec.TabIndex = 0;
            this.btnSayimBirSec.Text = "Sayım 1 seç";
            this.btnSayimBirSec.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnSayimIkiSec
            // 
            this.btnSayimIkiSec.Location = new System.Drawing.Point(1038, 19);
            this.btnSayimIkiSec.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnSayimIkiSec.Name = "btnSayimIkiSec";
            this.btnSayimIkiSec.Size = new System.Drawing.Size(284, 37);
            this.btnSayimIkiSec.TabIndex = 0;
            this.btnSayimIkiSec.Text = "Sayım 2 seç";
            this.btnSayimIkiSec.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(100, 63);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(105, 25);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "1 nci sayım";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(1038, 63);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(105, 25);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "2 nci sayım";
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gridControl1.Location = new System.Drawing.Point(20, 223);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(2002, 685);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // btnKarsilastir
            // 
            this.btnKarsilastir.Location = new System.Drawing.Point(672, 19);
            this.btnKarsilastir.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnKarsilastir.Name = "btnKarsilastir";
            this.btnKarsilastir.Size = new System.Drawing.Size(204, 37);
            this.btnKarsilastir.TabIndex = 3;
            this.btnKarsilastir.Text = "Karşılaştır";
            this.btnKarsilastir.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(1812, 19);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(178, 37);
            this.simpleButton4.TabIndex = 4;
            this.simpleButton4.Text = "Excel E gnder";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // lblSayimBirAcikalama
            // 
            this.lblSayimBirAcikalama.AutoSize = true;
            this.lblSayimBirAcikalama.Location = new System.Drawing.Point(94, 123);
            this.lblSayimBirAcikalama.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSayimBirAcikalama.Name = "lblSayimBirAcikalama";
            this.lblSayimBirAcikalama.Size = new System.Drawing.Size(210, 25);
            this.lblSayimBirAcikalama.TabIndex = 5;
            this.lblSayimBirAcikalama.Text = "lblSayimBirAcikalama";
            // 
            // lblSayimBirTarih
            // 
            this.lblSayimBirTarih.AutoSize = true;
            this.lblSayimBirTarih.Location = new System.Drawing.Point(94, 190);
            this.lblSayimBirTarih.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSayimBirTarih.Name = "lblSayimBirTarih";
            this.lblSayimBirTarih.Size = new System.Drawing.Size(164, 25);
            this.lblSayimBirTarih.TabIndex = 5;
            this.lblSayimBirTarih.Text = "lblSayimBirTarih";
            // 
            // lblSayimIkiAciklama
            // 
            this.lblSayimIkiAciklama.Location = new System.Drawing.Point(1038, 123);
            this.lblSayimIkiAciklama.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.lblSayimIkiAciklama.Name = "lblSayimIkiAciklama";
            this.lblSayimIkiAciklama.Size = new System.Drawing.Size(184, 25);
            this.lblSayimIkiAciklama.TabIndex = 1;
            this.lblSayimIkiAciklama.Text = "lblSayimIkiAciklama";
            // 
            // lblSayimIkiTarih
            // 
            this.lblSayimIkiTarih.Location = new System.Drawing.Point(1038, 190);
            this.lblSayimIkiTarih.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.lblSayimIkiTarih.Name = "lblSayimIkiTarih";
            this.lblSayimIkiTarih.Size = new System.Drawing.Size(149, 25);
            this.lblSayimIkiTarih.TabIndex = 1;
            this.lblSayimIkiTarih.Text = "lblSayimIkiTarih";
            // 
            // frmStokSayimKarsilastirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2036, 919);
            this.Controls.Add(this.lblSayimBirTarih);
            this.Controls.Add(this.lblSayimBirAcikalama);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.btnKarsilastir);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.lblSayimIkiTarih);
            this.Controls.Add(this.lblSayimIkiAciklama);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnSayimIkiSec);
            this.Controls.Add(this.btnSayimBirSec);
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "frmStokSayimKarsilastirma";
            this.Text = "frmStokSayimKarsilastirma";
            this.Load += new System.EventHandler(this.frmStokSayimKarsilastirma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.SimpleButton btnSayimBirSec;
    private DevExpress.XtraEditors.SimpleButton btnSayimIkiSec;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.SimpleButton btnKarsilastir;
    private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private System.Windows.Forms.Label lblSayimBirAcikalama;
        private System.Windows.Forms.Label lblSayimBirTarih;
        private DevExpress.XtraEditors.LabelControl lblSayimIkiAciklama;
        private DevExpress.XtraEditors.LabelControl lblSayimIkiTarih;
    }
}