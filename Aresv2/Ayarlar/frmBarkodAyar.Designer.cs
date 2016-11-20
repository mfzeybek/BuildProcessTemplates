namespace Aresv2.Ayarlar
{
  partial class frmBarkodAyar
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
            this.gcBarkodAyar = new DevExpress.XtraGrid.GridControl();
            this.gvBarkodAyar = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBarkodAyarID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOnEk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBarkodTipi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit_BarkodTip = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colKontrolNoOlsunMu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktarOlacakMi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKacHaneMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKacHaneKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplamKarakterSayisi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiradakiKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.btnTamam = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcBarkodAyar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBarkodAyar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_BarkodTip)).BeginInit();
            this.SuspendLayout();
            // 
            // gcBarkodAyar
            // 
            this.gcBarkodAyar.Location = new System.Drawing.Point(1, -1);
            this.gcBarkodAyar.MainView = this.gvBarkodAyar;
            this.gcBarkodAyar.Name = "gcBarkodAyar";
            this.gcBarkodAyar.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit_BarkodTip});
            this.gcBarkodAyar.Size = new System.Drawing.Size(757, 312);
            this.gcBarkodAyar.TabIndex = 0;
            this.gcBarkodAyar.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvBarkodAyar});
            this.gcBarkodAyar.Click += new System.EventHandler(this.gcBarkodAyar_Click);
            // 
            // gvBarkodAyar
            // 
            this.gvBarkodAyar.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBarkodAyarID,
            this.colOnEk,
            this.colBarkodTipi,
            this.colKontrolNoOlsunMu,
            this.colMiktarOlacakMi,
            this.colKacHaneMiktar,
            this.colKacHaneKod,
            this.colAciklama,
            this.colToplamKarakterSayisi,
            this.colSiradakiKod});
            this.gvBarkodAyar.GridControl = this.gcBarkodAyar;
            this.gvBarkodAyar.Name = "gvBarkodAyar";
            this.gvBarkodAyar.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            this.gvBarkodAyar.OptionsView.ShowGroupPanel = false;
            this.gvBarkodAyar.DoubleClick += new System.EventHandler(this.gvBarkodAyar_DoubleClick);
            // 
            // colBarkodAyarID
            // 
            this.colBarkodAyarID.Caption = "BarkodAyarID";
            this.colBarkodAyarID.FieldName = "BarkodAyarID";
            this.colBarkodAyarID.Name = "colBarkodAyarID";
            this.colBarkodAyarID.Width = 68;
            // 
            // colOnEk
            // 
            this.colOnEk.Caption = "OnEk";
            this.colOnEk.FieldName = "OnEk";
            this.colOnEk.Name = "colOnEk";
            this.colOnEk.Visible = true;
            this.colOnEk.VisibleIndex = 0;
            this.colOnEk.Width = 40;
            // 
            // colBarkodTipi
            // 
            this.colBarkodTipi.Caption = "BarkodTipi";
            this.colBarkodTipi.ColumnEdit = this.repositoryItemLookUpEdit_BarkodTip;
            this.colBarkodTipi.FieldName = "BarkodTipi";
            this.colBarkodTipi.Name = "colBarkodTipi";
            this.colBarkodTipi.Visible = true;
            this.colBarkodTipi.VisibleIndex = 1;
            this.colBarkodTipi.Width = 74;
            // 
            // repositoryItemLookUpEdit_BarkodTip
            // 
            this.repositoryItemLookUpEdit_BarkodTip.AutoHeight = false;
            this.repositoryItemLookUpEdit_BarkodTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit_BarkodTip.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("name", "name")});
            this.repositoryItemLookUpEdit_BarkodTip.Name = "repositoryItemLookUpEdit_BarkodTip";
            // 
            // colKontrolNoOlsunMu
            // 
            this.colKontrolNoOlsunMu.Caption = "KontrolNoOlsunMu";
            this.colKontrolNoOlsunMu.FieldName = "KontrolNoOlsunMu";
            this.colKontrolNoOlsunMu.Name = "colKontrolNoOlsunMu";
            this.colKontrolNoOlsunMu.Visible = true;
            this.colKontrolNoOlsunMu.VisibleIndex = 2;
            this.colKontrolNoOlsunMu.Width = 54;
            // 
            // colMiktarOlacakMi
            // 
            this.colMiktarOlacakMi.Caption = "MiktarOlacakMi";
            this.colMiktarOlacakMi.FieldName = "MiktarOlacakMi";
            this.colMiktarOlacakMi.Name = "colMiktarOlacakMi";
            this.colMiktarOlacakMi.Visible = true;
            this.colMiktarOlacakMi.VisibleIndex = 3;
            this.colMiktarOlacakMi.Width = 48;
            // 
            // colKacHaneMiktar
            // 
            this.colKacHaneMiktar.Caption = "KacHaneMiktar";
            this.colKacHaneMiktar.FieldName = "KacHaneMiktar";
            this.colKacHaneMiktar.Name = "colKacHaneMiktar";
            this.colKacHaneMiktar.Visible = true;
            this.colKacHaneMiktar.VisibleIndex = 4;
            this.colKacHaneMiktar.Width = 68;
            // 
            // colKacHaneKod
            // 
            this.colKacHaneKod.Caption = "KacHaneKod";
            this.colKacHaneKod.FieldName = "KacHaneKod";
            this.colKacHaneKod.Name = "colKacHaneKod";
            this.colKacHaneKod.Visible = true;
            this.colKacHaneKod.VisibleIndex = 6;
            this.colKacHaneKod.Width = 57;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 5;
            this.colAciklama.Width = 86;
            // 
            // colToplamKarakterSayisi
            // 
            this.colToplamKarakterSayisi.Caption = "ToplamKarakterSayisi";
            this.colToplamKarakterSayisi.FieldName = "ToplamKarakterSayisi";
            this.colToplamKarakterSayisi.Name = "colToplamKarakterSayisi";
            this.colToplamKarakterSayisi.Visible = true;
            this.colToplamKarakterSayisi.VisibleIndex = 7;
            this.colToplamKarakterSayisi.Width = 79;
            // 
            // colSiradakiKod
            // 
            this.colSiradakiKod.Caption = "SiradakiKod";
            this.colSiradakiKod.FieldName = "SiradakiKod";
            this.colSiradakiKod.Name = "colSiradakiKod";
            this.colSiradakiKod.Visible = true;
            this.colSiradakiKod.VisibleIndex = 8;
            this.colSiradakiKod.Width = 110;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(12, 340);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(576, 23);
            this.btnKaydet.TabIndex = 1;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(594, 340);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(75, 23);
            this.btnVazgec.TabIndex = 1;
            this.btnVazgec.Text = "Vazgeç";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(675, 340);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(75, 23);
            this.btnSil.TabIndex = 1;
            this.btnSil.Text = "Sil";
            // 
            // btnTamam
            // 
            this.btnTamam.Location = new System.Drawing.Point(12, 317);
            this.btnTamam.Name = "btnTamam";
            this.btnTamam.Size = new System.Drawing.Size(738, 23);
            this.btnTamam.TabIndex = 2;
            this.btnTamam.Text = "Tamam";
            this.btnTamam.Click += new System.EventHandler(this.btnTamam_Click);
            // 
            // frmBarkodAyar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 370);
            this.Controls.Add(this.btnTamam);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.gcBarkodAyar);
            this.Name = "frmBarkodAyar";
            this.Text = "x";
            this.Load += new System.EventHandler(this.frmBarkodAyar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcBarkodAyar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvBarkodAyar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit_BarkodTip)).EndInit();
            this.ResumeLayout(false);

    }

    #endregion

    private DevExpress.XtraGrid.GridControl gcBarkodAyar;
    private DevExpress.XtraGrid.Views.Grid.GridView gvBarkodAyar;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraEditors.SimpleButton btnVazgec;
    private DevExpress.XtraEditors.SimpleButton btnSil;
    private DevExpress.XtraGrid.Columns.GridColumn colBarkodAyarID;
    private DevExpress.XtraGrid.Columns.GridColumn colOnEk;
    private DevExpress.XtraGrid.Columns.GridColumn colBarkodTipi;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit_BarkodTip;
    private DevExpress.XtraGrid.Columns.GridColumn colKontrolNoOlsunMu;
    private DevExpress.XtraGrid.Columns.GridColumn colMiktarOlacakMi;
    private DevExpress.XtraGrid.Columns.GridColumn colKacHaneMiktar;
    private DevExpress.XtraGrid.Columns.GridColumn colKacHaneKod;
    private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
    private DevExpress.XtraGrid.Columns.GridColumn colToplamKarakterSayisi;
    private DevExpress.XtraGrid.Columns.GridColumn colSiradakiKod;
    private DevExpress.XtraEditors.SimpleButton btnTamam;
  }
}