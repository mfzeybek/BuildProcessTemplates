namespace Aresv2.Stok
{
  partial class frmStokFiyatKarsilastirma
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
            this.lkpStokFiyat1 = new DevExpress.XtraEditors.LookUpEdit();
            this.lkpStokFiyat2 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnKarşılaştır = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat1TanimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyatTanimAdi1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYuzde = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat2TanimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyatTanimAdi2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEskiFiyat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFiyat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEskiFiyat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokCikar = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokAc = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokBosalt = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.txtYuzde = new DevExpress.XtraEditors.TextEdit();
            this.btnYuzdeAktar = new DevExpress.XtraEditors.SimpleButton();
            this.txtAsagiYukariYuvarla = new DevExpress.XtraEditors.TextEdit();
            this.btnYukariYuvarla = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnAsagiYuvarla = new DevExpress.XtraEditors.SimpleButton();
            this.btnExceleAktar = new DevExpress.XtraEditors.SimpleButton();
            this.btnFiyat2Getir = new DevExpress.XtraEditors.SimpleButton();
            this.btnFiyat1Getir = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStokFiyat1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStokFiyat2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYuzde.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsagiYukariYuvarla.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lkpStokFiyat1
            // 
            this.lkpStokFiyat1.Location = new System.Drawing.Point(69, 12);
            this.lkpStokFiyat1.Name = "lkpStokFiyat1";
            this.lkpStokFiyat1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpStokFiyat1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FiyatTanimAdi", "FiyatTanimAdi")});
            this.lkpStokFiyat1.Size = new System.Drawing.Size(150, 22);
            this.lkpStokFiyat1.TabIndex = 0;
            // 
            // lkpStokFiyat2
            // 
            this.lkpStokFiyat2.Location = new System.Drawing.Point(278, 12);
            this.lkpStokFiyat2.Name = "lkpStokFiyat2";
            this.lkpStokFiyat2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpStokFiyat2.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FiyatTanimAdi", "FiyatTanimAdi")});
            this.lkpStokFiyat2.Size = new System.Drawing.Size(150, 22);
            this.lkpStokFiyat2.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(234, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 16);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Fiyat 2";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(25, 15);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 16);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Fiyat 1";
            // 
            // btnKarşılaştır
            // 
            this.btnKarşılaştır.Location = new System.Drawing.Point(447, 11);
            this.btnKarşılaştır.Name = "btnKarşılaştır";
            this.btnKarşılaştır.Size = new System.Drawing.Size(169, 23);
            this.btnKarşılaştır.TabIndex = 4;
            this.btnKarşılaştır.Text = "Karşılaştır";
            this.btnKarşılaştır.Click += new System.EventHandler(this.btnKarşılaştır_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(47, 75);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1178, 585);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokID,
            this.colStokAdi,
            this.colFiyat1TanimID,
            this.colFiyatTanimAdi1,
            this.colFiyat1,
            this.colYuzde,
            this.colFiyat2TanimID,
            this.colFiyatTanimAdi2,
            this.colEskiFiyat2,
            this.colFiyat2,
            this.colEskiFiyat1});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            this.colStokID.OptionsColumn.AllowEdit = false;
            this.colStokID.OptionsColumn.ReadOnly = true;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "StokAdi";
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.OptionsColumn.AllowEdit = false;
            this.colStokAdi.OptionsColumn.ReadOnly = true;
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 1;
            this.colStokAdi.Width = 289;
            // 
            // colFiyat1TanimID
            // 
            this.colFiyat1TanimID.Caption = "Fiyat1TanimID";
            this.colFiyat1TanimID.FieldName = "Fiyat1TanimID";
            this.colFiyat1TanimID.Name = "colFiyat1TanimID";
            this.colFiyat1TanimID.OptionsColumn.AllowEdit = false;
            this.colFiyat1TanimID.OptionsColumn.ReadOnly = true;
            // 
            // colFiyatTanimAdi1
            // 
            this.colFiyatTanimAdi1.Caption = "FiyatTanimAdi1";
            this.colFiyatTanimAdi1.FieldName = "FiyatTanimAdi1";
            this.colFiyatTanimAdi1.Name = "colFiyatTanimAdi1";
            this.colFiyatTanimAdi1.OptionsColumn.AllowEdit = false;
            this.colFiyatTanimAdi1.OptionsColumn.ReadOnly = true;
            this.colFiyatTanimAdi1.Visible = true;
            this.colFiyatTanimAdi1.VisibleIndex = 0;
            this.colFiyatTanimAdi1.Width = 109;
            // 
            // colFiyat1
            // 
            this.colFiyat1.Caption = "Fiyat1";
            this.colFiyat1.FieldName = "Fiyat1";
            this.colFiyat1.Name = "colFiyat1";
            this.colFiyat1.OptionsColumn.AllowEdit = false;
            this.colFiyat1.Visible = true;
            this.colFiyat1.VisibleIndex = 3;
            this.colFiyat1.Width = 111;
            // 
            // colYuzde
            // 
            this.colYuzde.Caption = "Yuzde";
            this.colYuzde.DisplayFormat.FormatString = "d";
            this.colYuzde.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colYuzde.FieldName = "Yuzde";
            this.colYuzde.Name = "colYuzde";
            this.colYuzde.Visible = true;
            this.colYuzde.VisibleIndex = 4;
            this.colYuzde.Width = 104;
            // 
            // colFiyat2TanimID
            // 
            this.colFiyat2TanimID.Caption = "Fiyat2TanimID";
            this.colFiyat2TanimID.FieldName = "Fiyat2TanimID";
            this.colFiyat2TanimID.Name = "colFiyat2TanimID";
            this.colFiyat2TanimID.OptionsColumn.AllowEdit = false;
            this.colFiyat2TanimID.OptionsColumn.ReadOnly = true;
            // 
            // colFiyatTanimAdi2
            // 
            this.colFiyatTanimAdi2.Caption = "FiyatTanimAdi2";
            this.colFiyatTanimAdi2.FieldName = "FiyatTanimAdi2";
            this.colFiyatTanimAdi2.Name = "colFiyatTanimAdi2";
            this.colFiyatTanimAdi2.OptionsColumn.AllowEdit = false;
            this.colFiyatTanimAdi2.OptionsColumn.ReadOnly = true;
            this.colFiyatTanimAdi2.Visible = true;
            this.colFiyatTanimAdi2.VisibleIndex = 5;
            this.colFiyatTanimAdi2.Width = 125;
            // 
            // colEskiFiyat2
            // 
            this.colEskiFiyat2.Caption = "Eski Fiyat 2";
            this.colEskiFiyat2.FieldName = "EskiFiyat2";
            this.colEskiFiyat2.Name = "colEskiFiyat2";
            this.colEskiFiyat2.OptionsColumn.AllowEdit = false;
            this.colEskiFiyat2.Visible = true;
            this.colEskiFiyat2.VisibleIndex = 6;
            this.colEskiFiyat2.Width = 148;
            // 
            // colFiyat2
            // 
            this.colFiyat2.Caption = "Fiyat2";
            this.colFiyat2.FieldName = "Fiyat2";
            this.colFiyat2.Name = "colFiyat2";
            this.colFiyat2.Visible = true;
            this.colFiyat2.VisibleIndex = 7;
            this.colFiyat2.Width = 416;
            // 
            // colEskiFiyat1
            // 
            this.colEskiFiyat1.Caption = "EskiFiyat1";
            this.colEskiFiyat1.FieldName = "EskiFiyat1";
            this.colEskiFiyat1.Name = "colEskiFiyat1";
            this.colEskiFiyat1.Visible = true;
            this.colEskiFiyat1.VisibleIndex = 2;
            this.colEskiFiyat1.Width = 127;
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(2, 75);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(39, 23);
            this.btnStokEkle.TabIndex = 6;
            this.btnStokEkle.Text = "+";
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // btnStokCikar
            // 
            this.btnStokCikar.Location = new System.Drawing.Point(2, 104);
            this.btnStokCikar.Name = "btnStokCikar";
            this.btnStokCikar.Size = new System.Drawing.Size(39, 23);
            this.btnStokCikar.TabIndex = 6;
            this.btnStokCikar.Text = "-";
            this.btnStokCikar.Click += new System.EventHandler(this.btnStokCikar_Click);
            // 
            // btnStokAc
            // 
            this.btnStokAc.Location = new System.Drawing.Point(2, 133);
            this.btnStokAc.Name = "btnStokAc";
            this.btnStokAc.Size = new System.Drawing.Size(39, 23);
            this.btnStokAc.TabIndex = 6;
            this.btnStokAc.Text = "A";
            this.btnStokAc.Click += new System.EventHandler(this.btnStokAc_Click);
            // 
            // btnStokBosalt
            // 
            this.btnStokBosalt.Location = new System.Drawing.Point(2, 162);
            this.btnStokBosalt.Name = "btnStokBosalt";
            this.btnStokBosalt.Size = new System.Drawing.Size(39, 23);
            this.btnStokBosalt.TabIndex = 7;
            this.btnStokBosalt.Text = "---";
            this.btnStokBosalt.Click += new System.EventHandler(this.btnStokBosalt_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKaydet.Location = new System.Drawing.Point(47, 666);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(155, 23);
            this.btnKaydet.TabIndex = 8;
            this.btnKaydet.Text = "Fiyatları Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // txtYuzde
            // 
            this.txtYuzde.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtYuzde.Location = new System.Drawing.Point(633, 12);
            this.txtYuzde.Name = "txtYuzde";
            this.txtYuzde.Size = new System.Drawing.Size(139, 22);
            this.txtYuzde.TabIndex = 9;
            // 
            // btnYuzdeAktar
            // 
            this.btnYuzdeAktar.Location = new System.Drawing.Point(778, 12);
            this.btnYuzdeAktar.Name = "btnYuzdeAktar";
            this.btnYuzdeAktar.Size = new System.Drawing.Size(75, 23);
            this.btnYuzdeAktar.TabIndex = 10;
            this.btnYuzdeAktar.Text = "Yüzde Aktar";
            this.btnYuzdeAktar.Click += new System.EventHandler(this.btnYuzdeAktar_Click);
            // 
            // txtAsagiYukariYuvarla
            // 
            this.txtAsagiYukariYuvarla.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtAsagiYukariYuvarla.Location = new System.Drawing.Point(5, 27);
            this.txtAsagiYukariYuvarla.Name = "txtAsagiYukariYuvarla";
            this.txtAsagiYukariYuvarla.Size = new System.Drawing.Size(111, 22);
            this.txtAsagiYukariYuvarla.TabIndex = 11;
            // 
            // btnYukariYuvarla
            // 
            this.btnYukariYuvarla.Location = new System.Drawing.Point(122, 27);
            this.btnYukariYuvarla.Name = "btnYukariYuvarla";
            this.btnYukariYuvarla.Size = new System.Drawing.Size(90, 23);
            this.btnYukariYuvarla.TabIndex = 12;
            this.btnYukariYuvarla.Text = "Yukarı Yuvarla";
            this.btnYukariYuvarla.Click += new System.EventHandler(this.btnYukariYuvarla_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtAsagiYukariYuvarla);
            this.groupControl1.Controls.Add(this.btnAsagiYuvarla);
            this.groupControl1.Controls.Add(this.btnYukariYuvarla);
            this.groupControl1.Location = new System.Drawing.Point(882, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(342, 62);
            this.groupControl1.TabIndex = 13;
            this.groupControl1.Text = "Fiyat Yuvarlama";
            // 
            // btnAsagiYuvarla
            // 
            this.btnAsagiYuvarla.Location = new System.Drawing.Point(218, 27);
            this.btnAsagiYuvarla.Name = "btnAsagiYuvarla";
            this.btnAsagiYuvarla.Size = new System.Drawing.Size(90, 23);
            this.btnAsagiYuvarla.TabIndex = 12;
            this.btnAsagiYuvarla.Text = "Aşağı Yuvarla";
            this.btnAsagiYuvarla.Click += new System.EventHandler(this.btnAsagiYuvarla_Click);
            // 
            // btnExceleAktar
            // 
            this.btnExceleAktar.Location = new System.Drawing.Point(2, 218);
            this.btnExceleAktar.Name = "btnExceleAktar";
            this.btnExceleAktar.Size = new System.Drawing.Size(39, 23);
            this.btnExceleAktar.TabIndex = 14;
            this.btnExceleAktar.Text = "E";
            this.btnExceleAktar.ToolTip = "Excel e aktar";
            this.btnExceleAktar.Click += new System.EventHandler(this.btnExceleAktar_Click);
            // 
            // btnFiyat2Getir
            // 
            this.btnFiyat2Getir.Location = new System.Drawing.Point(278, 40);
            this.btnFiyat2Getir.Name = "btnFiyat2Getir";
            this.btnFiyat2Getir.Size = new System.Drawing.Size(150, 23);
            this.btnFiyat2Getir.TabIndex = 15;
            this.btnFiyat2Getir.Text = "Fiyat 2 Getir";
            this.btnFiyat2Getir.Click += new System.EventHandler(this.btnFiyat2Getir_Click);
            // 
            // btnFiyat1Getir
            // 
            this.btnFiyat1Getir.Location = new System.Drawing.Point(69, 40);
            this.btnFiyat1Getir.Name = "btnFiyat1Getir";
            this.btnFiyat1Getir.Size = new System.Drawing.Size(150, 23);
            this.btnFiyat1Getir.TabIndex = 15;
            this.btnFiyat1Getir.Text = "Fiyat1 Getir";
            // 
            // frmStokFiyatKarsilastirma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1230, 699);
            this.Controls.Add(this.btnFiyat1Getir);
            this.Controls.Add(this.btnFiyat2Getir);
            this.Controls.Add(this.btnExceleAktar);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnYuzdeAktar);
            this.Controls.Add(this.txtYuzde);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.btnStokBosalt);
            this.Controls.Add(this.btnStokAc);
            this.Controls.Add(this.btnStokCikar);
            this.Controls.Add(this.btnStokEkle);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnKarşılaştır);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lkpStokFiyat2);
            this.Controls.Add(this.lkpStokFiyat1);
            this.Name = "frmStokFiyatKarsilastirma";
            this.Text = "frmStokFiyatKarsilastirma";
            this.Load += new System.EventHandler(this.frmStokFiyatKarsilastirma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lkpStokFiyat1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpStokFiyat2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtYuzde.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAsagiYukariYuvarla.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraEditors.LookUpEdit lkpStokFiyat1;
    private DevExpress.XtraEditors.LookUpEdit lkpStokFiyat2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.SimpleButton btnKarşılaştır;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private DevExpress.XtraEditors.SimpleButton btnStokEkle;
    private DevExpress.XtraEditors.SimpleButton btnStokCikar;
    private DevExpress.XtraEditors.SimpleButton btnStokAc;
    private DevExpress.XtraGrid.Columns.GridColumn colStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat1TanimID;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyatTanimAdi1;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat1;
    private DevExpress.XtraGrid.Columns.GridColumn colYuzde;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat2TanimID;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyatTanimAdi2;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat2;
    private DevExpress.XtraEditors.SimpleButton btnStokBosalt;
    private DevExpress.XtraEditors.SimpleButton btnKaydet;
    private DevExpress.XtraEditors.TextEdit txtYuzde;
    private DevExpress.XtraEditors.SimpleButton btnYuzdeAktar;
    private DevExpress.XtraEditors.TextEdit txtAsagiYukariYuvarla;
    private DevExpress.XtraEditors.SimpleButton btnYukariYuvarla;
    private DevExpress.XtraEditors.GroupControl groupControl1;
    private DevExpress.XtraEditors.SimpleButton btnAsagiYuvarla;
    private DevExpress.XtraGrid.Columns.GridColumn colEskiFiyat2;
    private DevExpress.XtraGrid.Columns.GridColumn colEskiFiyat1;
    private DevExpress.XtraEditors.SimpleButton btnExceleAktar;
    private DevExpress.XtraEditors.SimpleButton btnFiyat2Getir;
    private DevExpress.XtraEditors.SimpleButton btnFiyat1Getir;
  }
}