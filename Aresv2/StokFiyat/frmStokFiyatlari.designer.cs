namespace Aresv2.Stok
{
  partial class frmStokFiyatlari
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
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabPage1 = new System.Windows.Forms.TabPage();
      this.gridControl1 = new DevExpress.XtraGrid.GridControl();
      this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colStokFiyatID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colFiyatTanimID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colAlisMiSatisMi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.tabPage2 = new System.Windows.Forms.TabPage();
      this.gridControl2 = new DevExpress.XtraGrid.GridControl();
      this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.colFaturaTipi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
      this.colFaturaTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colCariTanim = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colHStokID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colFaturaHareketStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colStokAnaBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colAnaBirimFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
      this.colIskontoluFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
      this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
      this.lblStokAdi = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.lblStokKodu = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.helpProvider1 = new System.Windows.Forms.HelpProvider();
      this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
      this.tabControl1.SuspendLayout();
      this.tabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
      this.tabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
      this.panelControl2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabPage1);
      this.tabControl1.Controls.Add(this.tabPage2);
      this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabControl1.Location = new System.Drawing.Point(0, 50);
      this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(936, 317);
      this.tabControl1.TabIndex = 2;
      // 
      // tabPage1
      // 
      this.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
      this.tabPage1.Controls.Add(this.gridControl1);
      this.tabPage1.Location = new System.Drawing.Point(4, 25);
      this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPage1.Name = "tabPage1";
      this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPage1.Size = new System.Drawing.Size(928, 288);
      this.tabPage1.TabIndex = 0;
      this.tabPage1.Text = "Fiyatları";
      this.tabPage1.UseVisualStyleBackColor = true;
      // 
      // gridControl1
      // 
      this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gridControl1.Location = new System.Drawing.Point(3, 4);
      this.gridControl1.MainView = this.gridView1;
      this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.gridControl1.Name = "gridControl1";
      this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
      this.gridControl1.Size = new System.Drawing.Size(922, 280);
      this.gridControl1.TabIndex = 4;
      this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
      // 
      // gridView1
      // 
      this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStokFiyatID,
            this.colFiyatTanimID,
            this.colFiyat,
            this.colStokID,
            this.colAlisMiSatisMi});
      this.gridView1.GridControl = this.gridControl1;
      this.gridView1.Name = "gridView1";
      this.gridView1.OptionsBehavior.Editable = false;
      this.gridView1.OptionsBehavior.ReadOnly = true;
      this.gridView1.OptionsView.ShowGroupPanel = false;
      this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
      // 
      // colStokFiyatID
      // 
      this.colStokFiyatID.Caption = "StokFiyatID";
      this.colStokFiyatID.FieldName = "StokFiyatID";
      this.colStokFiyatID.Name = "colStokFiyatID";
      // 
      // colFiyatTanimID
      // 
      this.colFiyatTanimID.Caption = "FiyatTanimID";
      this.colFiyatTanimID.ColumnEdit = this.repositoryItemLookUpEdit1;
      this.colFiyatTanimID.FieldName = "FiyatTanimID";
      this.colFiyatTanimID.Name = "colFiyatTanimID";
      this.colFiyatTanimID.Visible = true;
      this.colFiyatTanimID.VisibleIndex = 0;
      // 
      // repositoryItemLookUpEdit1
      // 
      this.repositoryItemLookUpEdit1.AutoHeight = false;
      this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
      // 
      // colFiyat
      // 
      this.colFiyat.Caption = "Fiyat";
      this.colFiyat.FieldName = "Fiyat";
      this.colFiyat.Name = "colFiyat";
      this.colFiyat.Visible = true;
      this.colFiyat.VisibleIndex = 1;
      // 
      // colStokID
      // 
      this.colStokID.Caption = "StokID";
      this.colStokID.FieldName = "StokID";
      this.colStokID.Name = "colStokID";
      // 
      // colAlisMiSatisMi
      // 
      this.colAlisMiSatisMi.Caption = "AlisMiSatisMi";
      this.colAlisMiSatisMi.FieldName = "AlisMiSatisMi";
      this.colAlisMiSatisMi.Name = "colAlisMiSatisMi";
      // 
      // tabPage2
      // 
      this.tabPage2.Controls.Add(this.gridControl2);
      this.tabPage2.Controls.Add(this.labelControl1);
      this.tabPage2.Location = new System.Drawing.Point(4, 25);
      this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPage2.Name = "tabPage2";
      this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.tabPage2.Size = new System.Drawing.Size(928, 288);
      this.tabPage2.TabIndex = 1;
      this.tabPage2.Text = "Hareketleri";
      this.tabPage2.UseVisualStyleBackColor = true;
      // 
      // gridControl2
      // 
      this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridControl2.Location = new System.Drawing.Point(3, 4);
      this.gridControl2.MainView = this.gridView2;
      this.gridControl2.Name = "gridControl2";
      this.gridControl2.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit2});
      this.gridControl2.Size = new System.Drawing.Size(922, 280);
      this.gridControl2.TabIndex = 1;
      this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
      // 
      // gridView2
      // 
      this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colFaturaTipi,
            this.colFaturaTarihi,
            this.colCariID,
            this.colCariTanim,
            this.colHStokID,
            this.colFaturaHareketStokAdi,
            this.colMiktar,
            this.colStokAnaBirimID,
            this.colAnaBirimFiyat,
            this.colIskontoluFiyat});
      this.gridView2.GridControl = this.gridControl2;
      this.gridView2.Name = "gridView2";
      this.gridView2.OptionsBehavior.Editable = false;
      this.gridView2.OptionsBehavior.ReadOnly = true;
      this.gridView2.OptionsView.ShowGroupPanel = false;
      this.gridView2.DoubleClick += new System.EventHandler(this.gridView2_DoubleClick);
      // 
      // colFaturaTipi
      // 
      this.colFaturaTipi.Caption = "Fatura Tipi";
      this.colFaturaTipi.ColumnEdit = this.repositoryItemLookUpEdit2;
      this.colFaturaTipi.FieldName = "FaturaTipi";
      this.colFaturaTipi.Name = "colFaturaTipi";
      this.colFaturaTipi.Visible = true;
      this.colFaturaTipi.VisibleIndex = 0;
      this.colFaturaTipi.Width = 112;
      // 
      // repositoryItemLookUpEdit2
      // 
      this.repositoryItemLookUpEdit2.AutoHeight = false;
      this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
      // 
      // colFaturaTarihi
      // 
      this.colFaturaTarihi.Caption = "FaturaTarihi";
      this.colFaturaTarihi.FieldName = "FaturaTarihi";
      this.colFaturaTarihi.Name = "colFaturaTarihi";
      this.colFaturaTarihi.Visible = true;
      this.colFaturaTarihi.VisibleIndex = 1;
      this.colFaturaTarihi.Width = 123;
      // 
      // colCariID
      // 
      this.colCariID.Caption = "CariID";
      this.colCariID.FieldName = "CariID";
      this.colCariID.Name = "colCariID";
      this.colCariID.Width = 90;
      // 
      // colCariTanim
      // 
      this.colCariTanim.Caption = "CariTanim";
      this.colCariTanim.FieldName = "CariTanim";
      this.colCariTanim.Name = "colCariTanim";
      this.colCariTanim.Visible = true;
      this.colCariTanim.VisibleIndex = 2;
      this.colCariTanim.Width = 227;
      // 
      // colHStokID
      // 
      this.colHStokID.Caption = "StokID";
      this.colHStokID.FieldName = "StokID";
      this.colHStokID.Name = "colHStokID";
      this.colHStokID.Width = 53;
      // 
      // colFaturaHareketStokAdi
      // 
      this.colFaturaHareketStokAdi.Caption = "FaturaHareketStokAdi";
      this.colFaturaHareketStokAdi.FieldName = "FaturaHareketStokAdi";
      this.colFaturaHareketStokAdi.Name = "colFaturaHareketStokAdi";
      this.colFaturaHareketStokAdi.Width = 205;
      // 
      // colMiktar
      // 
      this.colMiktar.Caption = "Miktar";
      this.colMiktar.FieldName = "Miktar";
      this.colMiktar.Name = "colMiktar";
      this.colMiktar.Visible = true;
      this.colMiktar.VisibleIndex = 3;
      this.colMiktar.Width = 135;
      // 
      // colStokAnaBirimID
      // 
      this.colStokAnaBirimID.Caption = "StokAnaBirimID";
      this.colStokAnaBirimID.FieldName = "StokAnaBirimID";
      this.colStokAnaBirimID.Name = "colStokAnaBirimID";
      this.colStokAnaBirimID.Width = 90;
      // 
      // colAnaBirimFiyat
      // 
      this.colAnaBirimFiyat.Caption = "AnaBirimFiyat";
      this.colAnaBirimFiyat.FieldName = "AnaBirimFiyat";
      this.colAnaBirimFiyat.Name = "colAnaBirimFiyat";
      this.colAnaBirimFiyat.Visible = true;
      this.colAnaBirimFiyat.VisibleIndex = 4;
      this.colAnaBirimFiyat.Width = 90;
      // 
      // colIskontoluFiyat
      // 
      this.colIskontoluFiyat.Caption = "IskontoluFiyat";
      this.colIskontoluFiyat.FieldName = "IskontoluFiyat";
      this.colIskontoluFiyat.Name = "colIskontoluFiyat";
      this.colIskontoluFiyat.Visible = true;
      this.colIskontoluFiyat.VisibleIndex = 5;
      this.colIskontoluFiyat.Width = 217;
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(68, 101);
      this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(566, 16);
      this.labelControl1.TabIndex = 0;
      this.labelControl1.Text = "Burada tanımlı firmanın veya bütün firmaların o ürün için hangi fiyattan ne kadar" +
    " verilmiş o yazacak";
      // 
      // panelControl1
      // 
      this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelControl1.Location = new System.Drawing.Point(0, 367);
      this.panelControl1.Name = "panelControl1";
      this.panelControl1.Size = new System.Drawing.Size(936, 44);
      this.panelControl1.TabIndex = 2;
      // 
      // panelControl2
      // 
      this.panelControl2.Controls.Add(this.radioGroup1);
      this.panelControl2.Controls.Add(this.lblStokAdi);
      this.panelControl2.Controls.Add(this.labelControl3);
      this.panelControl2.Controls.Add(this.lblStokKodu);
      this.panelControl2.Controls.Add(this.labelControl2);
      this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelControl2.Location = new System.Drawing.Point(0, 0);
      this.panelControl2.Name = "panelControl2";
      this.panelControl2.Size = new System.Drawing.Size(936, 50);
      this.panelControl2.TabIndex = 5;
      // 
      // lblStokAdi
      // 
      this.lblStokAdi.Location = new System.Drawing.Point(94, 5);
      this.lblStokAdi.Name = "lblStokAdi";
      this.lblStokAdi.Size = new System.Drawing.Size(60, 16);
      this.lblStokAdi.TabIndex = 5;
      this.lblStokAdi.Text = "Stok Adı : ";
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(17, 5);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(60, 16);
      this.labelControl3.TabIndex = 5;
      this.labelControl3.Text = "Stok Adı : ";
      // 
      // lblStokKodu
      // 
      this.lblStokKodu.Location = new System.Drawing.Point(94, 27);
      this.lblStokKodu.Name = "lblStokKodu";
      this.lblStokKodu.Size = new System.Drawing.Size(70, 16);
      this.lblStokKodu.TabIndex = 5;
      this.lblStokKodu.Text = "Stok Kodu : ";
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(7, 27);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(70, 16);
      this.labelControl2.TabIndex = 5;
      this.labelControl2.Text = "Stok Kodu : ";
      // 
      // radioGroup1
      // 
      this.radioGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.radioGroup1.Location = new System.Drawing.Point(683, 5);
      this.radioGroup1.Name = "radioGroup1";
      this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Aktif Cari"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, "Hepsi")});
      this.radioGroup1.Size = new System.Drawing.Size(241, 40);
      this.radioGroup1.TabIndex = 5;
      this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
      this.radioGroup1.CausesValidationChanged += new System.EventHandler(this.radioGroup1_CausesValidationChanged);
      this.radioGroup1.ChangeUICues += new System.Windows.Forms.UICuesEventHandler(this.radioGroup1_ChangeUICues);
      // 
      // frmStokFiyatlari
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(936, 411);
      this.Controls.Add(this.tabControl1);
      this.Controls.Add(this.panelControl1);
      this.Controls.Add(this.panelControl2);
      this.HelpButton = true;
      this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
      this.Name = "frmStokFiyatlari";
      this.Text = "frmStokFiyatlari";
      this.Load += new System.EventHandler(this.frmStokFiyatlari_Load);
      this.tabControl1.ResumeLayout(false);
      this.tabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
      this.tabPage2.ResumeLayout(false);
      this.tabPage2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
      this.panelControl2.ResumeLayout(false);
      this.panelControl2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabPage1;
    private DevExpress.XtraGrid.GridControl gridControl1;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    private System.Windows.Forms.TabPage tabPage2;
    private DevExpress.XtraEditors.LabelControl labelControl1;
    private DevExpress.XtraGrid.Columns.GridColumn colStokFiyatID;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyatTanimID;
    private DevExpress.XtraGrid.Columns.GridColumn colFiyat;
    private DevExpress.XtraGrid.Columns.GridColumn colStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colAlisMiSatisMi;
    private DevExpress.XtraGrid.GridControl gridControl2;
    private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
    private DevExpress.XtraGrid.Columns.GridColumn colFaturaTipi;
    private DevExpress.XtraGrid.Columns.GridColumn colFaturaTarihi;
    private DevExpress.XtraGrid.Columns.GridColumn colCariID;
    private DevExpress.XtraGrid.Columns.GridColumn colCariTanim;
    private DevExpress.XtraGrid.Columns.GridColumn colHStokID;
    private DevExpress.XtraGrid.Columns.GridColumn colFaturaHareketStokAdi;
    private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
    private DevExpress.XtraGrid.Columns.GridColumn colStokAnaBirimID;
    private DevExpress.XtraGrid.Columns.GridColumn colAnaBirimFiyat;
    private DevExpress.XtraGrid.Columns.GridColumn colIskontoluFiyat;
    private DevExpress.XtraEditors.PanelControl panelControl1;
    private DevExpress.XtraEditors.PanelControl panelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private System.Windows.Forms.HelpProvider helpProvider1;
    public DevExpress.XtraEditors.LabelControl lblStokAdi;
    public DevExpress.XtraEditors.LabelControl lblStokKodu;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
    private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
    private DevExpress.XtraEditors.RadioGroup radioGroup1;

  }
}