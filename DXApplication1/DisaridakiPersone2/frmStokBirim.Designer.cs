namespace clsTablolar.Stok
{
  partial class frmStokBirim
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
            this.colStokBirimCevirmeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKatSayi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(12, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1008, 392);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokBirimCevirmeID,
            this.colAciklama,
            this.colStokID,
            this.colBirimID,
            this.colKatSayi,
            this.colBarkodu,
            this.colBirimAdi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colStokBirimCevirmeID
            // 
            this.colStokBirimCevirmeID.Caption = "StokBirimCevirmeID";
            this.colStokBirimCevirmeID.FieldName = "StokBirimCevirmeID";
            this.colStokBirimCevirmeID.Name = "colStokBirimCevirmeID";
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 0;
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            // 
            // colBirimID
            // 
            this.colBirimID.Caption = "BirimID";
            this.colBirimID.FieldName = "BirimID";
            this.colBirimID.Name = "colBirimID";
            // 
            // colKatSayi
            // 
            this.colKatSayi.Caption = "KatSayi";
            this.colKatSayi.FieldName = "KatSayi";
            this.colKatSayi.Name = "colKatSayi";
            this.colKatSayi.Visible = true;
            this.colKatSayi.VisibleIndex = 1;
            // 
            // colBarkodu
            // 
            this.colBarkodu.Caption = "Barkodu";
            this.colBarkodu.FieldName = "Barkodu";
            this.colBarkodu.Name = "colBarkodu";
            this.colBarkodu.Visible = true;
            this.colBarkodu.VisibleIndex = 2;
            // 
            // colBirimAdi
            // 
            this.colBirimAdi.Caption = "BirimAdi";
            this.colBirimAdi.FieldName = "BirimAdi";
            this.colBirimAdi.Name = "colBirimAdi";
            this.colBirimAdi.Visible = true;
            this.colBirimAdi.VisibleIndex = 3;
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(12, 400);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(1008, 23);
            this.btnTamam.TabIndex = 1;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // frmStokBirim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 432);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.gridControl1);
            this.Name = "frmStokBirim";
            this.Text = "frmStokBirim";
            this.Load += new System.EventHandler(this.frmStokBirim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.SimpleButton btnTamam;
    private DevExpress.XtraGrid.Columns.GridColumn colStokBirimCevirmeID;
    private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colBirimID;
    private DevExpress.XtraGrid.Columns.GridColumn colKatSayi;
    private DevExpress.XtraGrid.Columns.GridColumn colBarkodu;
    private DevExpress.XtraGrid.Columns.GridColumn colBirimAdi;
  }
}