namespace Aresv2.Uretim
{
  partial class frmReceteListesi
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
			this.gcReceteListesi = new DevExpress.XtraGrid.GridControl();
			this.gvReceteListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colReceteMasterID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colReceteKod = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOzelKod1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colOzelKod2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCODE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colNAME = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.gcReceteListesi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceteListesi)).BeginInit();
			this.SuspendLayout();
			// 
			// gcReceteListesi
			// 
			this.gcReceteListesi.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gcReceteListesi.Location = new System.Drawing.Point(0, 0);
			this.gcReceteListesi.MainView = this.gvReceteListesi;
			this.gcReceteListesi.Name = "gcReceteListesi";
			this.gcReceteListesi.Size = new System.Drawing.Size(492, 412);
			this.gcReceteListesi.TabIndex = 0;
			this.gcReceteListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvReceteListesi});
			// 
			// gvReceteListesi
			// 
			this.gvReceteListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colReceteMasterID,
            this.colReceteKod,
            this.colAciklama,
            this.colOzelKod1,
            this.colOzelKod2,
            this.colStokID,
            this.colCODE,
            this.colNAME});
			this.gvReceteListesi.GridControl = this.gcReceteListesi;
			this.gvReceteListesi.Name = "gvReceteListesi";
			this.gvReceteListesi.OptionsBehavior.AllowIncrementalSearch = true;
			this.gvReceteListesi.OptionsBehavior.Editable = false;
			this.gvReceteListesi.OptionsView.ColumnAutoWidth = false;
			this.gvReceteListesi.OptionsView.EnableAppearanceEvenRow = true;
			this.gvReceteListesi.OptionsView.EnableAppearanceOddRow = true;
			this.gvReceteListesi.OptionsView.ShowAutoFilterRow = true;
			this.gvReceteListesi.OptionsView.ShowGroupPanel = false;
			this.gvReceteListesi.DoubleClick += new System.EventHandler(this.grvReceteListesi_DoubleClick);
			// 
			// colReceteMasterID
			// 
			this.colReceteMasterID.Caption = "Recete Master ID";
			this.colReceteMasterID.FieldName = "ReceteMasterID";
			this.colReceteMasterID.Name = "colReceteMasterID";
			// 
			// colReceteKod
			// 
			this.colReceteKod.Caption = "Reçete Kod";
			this.colReceteKod.FieldName = "ReceteKod";
			this.colReceteKod.Name = "colReceteKod";
			this.colReceteKod.Visible = true;
			this.colReceteKod.VisibleIndex = 0;
			this.colReceteKod.Width = 96;
			// 
			// colAciklama
			// 
			this.colAciklama.Caption = "Açıklama";
			this.colAciklama.FieldName = "Aciklama";
			this.colAciklama.Name = "colAciklama";
			this.colAciklama.Visible = true;
			this.colAciklama.VisibleIndex = 1;
			this.colAciklama.Width = 215;
			// 
			// colOzelKod1
			// 
			this.colOzelKod1.Caption = "Özel Kod 1";
			this.colOzelKod1.FieldName = "OzelKod1";
			this.colOzelKod1.Name = "colOzelKod1";
			this.colOzelKod1.Visible = true;
			this.colOzelKod1.VisibleIndex = 2;
			// 
			// colOzelKod2
			// 
			this.colOzelKod2.Caption = "Özel Kod 2";
			this.colOzelKod2.FieldName = "OzelKod2";
			this.colOzelKod2.Name = "colOzelKod2";
			this.colOzelKod2.Visible = true;
			this.colOzelKod2.VisibleIndex = 3;
			// 
			// colStokID
			// 
			this.colStokID.Caption = "Stok ID";
			this.colStokID.FieldName = "StokID";
			this.colStokID.Name = "colStokID";
			// 
			// colCODE
			// 
			this.colCODE.Caption = "Stok Kodu";
			this.colCODE.FieldName = "CODE";
			this.colCODE.Name = "colCODE";
			// 
			// colNAME
			// 
			this.colNAME.Caption = "Stok Tanım";
			this.colNAME.FieldName = "NAME";
			this.colNAME.Name = "colNAME";
			// 
			// frmReceteListesi
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(492, 412);
			this.Controls.Add(this.gcReceteListesi);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmReceteListesi";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "  Reçete Listesi";
			this.Load += new System.EventHandler(this.frmReceteListesi_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmReceteListesi_KeyDown);
			((System.ComponentModel.ISupportInitialize)(this.gcReceteListesi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gvReceteListesi)).EndInit();
			this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcReceteListesi;
    private DevExpress.XtraGrid.Views.Grid.GridView gvReceteListesi;
    private DevExpress.XtraGrid.Columns.GridColumn colReceteMasterID;
    private DevExpress.XtraGrid.Columns.GridColumn colReceteKod;
    private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelKod1;
    private DevExpress.XtraGrid.Columns.GridColumn colOzelKod2;
    private DevExpress.XtraGrid.Columns.GridColumn colStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colCODE;
    private DevExpress.XtraGrid.Columns.GridColumn colNAME;
  }
}