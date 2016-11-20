namespace Aresv2.Personel
{
  partial class frmPdks
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonelID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZaman = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYerID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTur = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonelAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonelAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYerAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTurAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnDuzenle = new DevExpress.XtraEditors.SimpleButton();
            this.btnYeniKayit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(12, 63);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1191, 481);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colPersonelID,
            this.colZaman,
            this.colYerID,
            this.colTur,
            this.colPersonelAdi,
            this.colPersonelAciklama,
            this.colYerAdi,
            this.colTurAdi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            // 
            // colPersonelID
            // 
            this.colPersonelID.Caption = "PersonelID";
            this.colPersonelID.FieldName = "PersonelID";
            this.colPersonelID.Name = "colPersonelID";
            // 
            // colZaman
            // 
            this.colZaman.Caption = "Zaman";
            this.colZaman.DisplayFormat.FormatString = "G";
            this.colZaman.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colZaman.FieldName = "Zaman";
            this.colZaman.Name = "colZaman";
            this.colZaman.Visible = true;
            this.colZaman.VisibleIndex = 0;
            this.colZaman.Width = 170;
            // 
            // colYerID
            // 
            this.colYerID.Caption = "YerID";
            this.colYerID.FieldName = "YerID";
            this.colYerID.Name = "colYerID";
            this.colYerID.Visible = true;
            this.colYerID.VisibleIndex = 1;
            this.colYerID.Width = 174;
            // 
            // colTur
            // 
            this.colTur.Caption = "Tur";
            this.colTur.FieldName = "Tur";
            this.colTur.Name = "colTur";
            this.colTur.Visible = true;
            this.colTur.VisibleIndex = 2;
            this.colTur.Width = 151;
            // 
            // colPersonelAdi
            // 
            this.colPersonelAdi.Caption = "PersonelAdi";
            this.colPersonelAdi.FieldName = "PersonelAdi";
            this.colPersonelAdi.Name = "colPersonelAdi";
            this.colPersonelAdi.Visible = true;
            this.colPersonelAdi.VisibleIndex = 3;
            this.colPersonelAdi.Width = 168;
            // 
            // colPersonelAciklama
            // 
            this.colPersonelAciklama.Caption = "PersonelAciklama";
            this.colPersonelAciklama.FieldName = "PersonelAciklama";
            this.colPersonelAciklama.Name = "colPersonelAciklama";
            this.colPersonelAciklama.Visible = true;
            this.colPersonelAciklama.VisibleIndex = 4;
            this.colPersonelAciklama.Width = 219;
            // 
            // colYerAdi
            // 
            this.colYerAdi.Caption = "colYerAdi";
            this.colYerAdi.FieldName = "YerAdi";
            this.colYerAdi.Name = "colYerAdi";
            this.colYerAdi.Visible = true;
            this.colYerAdi.VisibleIndex = 5;
            this.colYerAdi.Width = 187;
            // 
            // colTurAdi
            // 
            this.colTurAdi.Caption = "TurAdi";
            this.colTurAdi.FieldName = "TurAdi";
            this.colTurAdi.Name = "colTurAdi";
            this.colTurAdi.Visible = true;
            this.colTurAdi.VisibleIndex = 6;
            this.colTurAdi.Width = 135;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(132, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "labelControl1";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(12, 34);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(275, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Kayıtları Getir";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(58, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "IP Adresi";
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(417, 34);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(214, 23);
            this.btnDuzenle.TabIndex = 4;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnYeniKayit
            // 
            this.btnYeniKayit.Location = new System.Drawing.Point(667, 34);
            this.btnYeniKayit.Name = "btnYeniKayit";
            this.btnYeniKayit.Size = new System.Drawing.Size(181, 23);
            this.btnYeniKayit.TabIndex = 5;
            this.btnYeniKayit.Text = "Yeni Kayıt";
            // 
            // frmPdks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 556);
            this.Controls.Add(this.btnYeniKayit);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmPdks";
            this.Text = "frmPdks";
            this.Load += new System.EventHandler(this.frmPdks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.SimpleButton simpleButton1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.SimpleButton btnDuzenle;
    private DevExpress.XtraEditors.SimpleButton btnYeniKayit;
    private DevExpress.XtraGrid.Columns.GridColumn colID;
    private DevExpress.XtraGrid.Columns.GridColumn colPersonelID;
    private DevExpress.XtraGrid.Columns.GridColumn colZaman;
    private DevExpress.XtraGrid.Columns.GridColumn colYerID;
    private DevExpress.XtraGrid.Columns.GridColumn colTur;
    private DevExpress.XtraGrid.Columns.GridColumn colPersonelAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colPersonelAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colYerAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colTurAdi;
  }
}