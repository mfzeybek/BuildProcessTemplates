namespace Aresv2.ExceldenUrun_CariCek
{
  partial class frmExceldenCariAktar
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
      this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
      this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
      this.gcAktarilacaklarListesi = new DevExpress.XtraGrid.GridControl();
      this.gvAktarilacaklarListesi = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.Aktar = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
      this.AlanAdi = new DevExpress.XtraGrid.Columns.GridColumn();
      this.ExcelSutunu = new DevExpress.XtraGrid.Columns.GridColumn();
      this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
      this.Aciklama = new DevExpress.XtraGrid.Columns.GridColumn();
      this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
      this.gcExeldekiler = new DevExpress.XtraGrid.GridControl();
      this.gvExeldekiler = new DevExpress.XtraGrid.Views.Grid.GridView();
      this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.label1 = new System.Windows.Forms.Label();
      this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
      this.btnAktar = new DevExpress.XtraEditors.SimpleButton();
      this.cmbStokKarsilastirmaAlani = new System.Windows.Forms.ComboBox();
      this.cmbStokMevcutDegilse = new System.Windows.Forms.ComboBox();
      this.cmbStokMevcutsa = new System.Windows.Forms.ComboBox();
      this.spinEdit1 = new DevExpress.XtraEditors.SpinEdit();
      this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
      this.buttonEdit1 = new DevExpress.XtraEditors.ButtonEdit();
      this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
      this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
      this.xtraTabControl1.SuspendLayout();
      this.xtraTabPage1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gcAktarilacaklarListesi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvAktarilacaklarListesi)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
      this.xtraTabPage2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gcExeldekiler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvExeldekiler)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).BeginInit();
      this.SuspendLayout();
      // 
      // xtraTabControl1
      // 
      this.xtraTabControl1.Enabled = false;
      this.xtraTabControl1.Location = new System.Drawing.Point(11, 127);
      this.xtraTabControl1.Margin = new System.Windows.Forms.Padding(4);
      this.xtraTabControl1.Name = "xtraTabControl1";
      this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
      this.xtraTabControl1.Size = new System.Drawing.Size(661, 471);
      this.xtraTabControl1.TabIndex = 7;
      this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
      // 
      // xtraTabPage1
      // 
      this.xtraTabPage1.Controls.Add(this.gcAktarilacaklarListesi);
      this.xtraTabPage1.Margin = new System.Windows.Forms.Padding(4);
      this.xtraTabPage1.Name = "xtraTabPage1";
      this.xtraTabPage1.Size = new System.Drawing.Size(656, 443);
      this.xtraTabPage1.Text = "Alan Ayarları";
      // 
      // gcAktarilacaklarListesi
      // 
      this.gcAktarilacaklarListesi.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcAktarilacaklarListesi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
      this.gcAktarilacaklarListesi.Location = new System.Drawing.Point(0, 0);
      this.gcAktarilacaklarListesi.MainView = this.gvAktarilacaklarListesi;
      this.gcAktarilacaklarListesi.Margin = new System.Windows.Forms.Padding(4);
      this.gcAktarilacaklarListesi.Name = "gcAktarilacaklarListesi";
      this.gcAktarilacaklarListesi.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemComboBox1});
      this.gcAktarilacaklarListesi.Size = new System.Drawing.Size(656, 443);
      this.gcAktarilacaklarListesi.TabIndex = 1;
      this.gcAktarilacaklarListesi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvAktarilacaklarListesi});
      // 
      // gvAktarilacaklarListesi
      // 
      this.gvAktarilacaklarListesi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Aktar,
            this.AlanAdi,
            this.ExcelSutunu,
            this.Aciklama});
      this.gvAktarilacaklarListesi.GridControl = this.gcAktarilacaklarListesi;
      this.gvAktarilacaklarListesi.Name = "gvAktarilacaklarListesi";
      this.gvAktarilacaklarListesi.OptionsView.ShowGroupPanel = false;
      this.gvAktarilacaklarListesi.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel;
      // 
      // Aktar
      // 
      this.Aktar.Caption = "Aktar";
      this.Aktar.ColumnEdit = this.repositoryItemCheckEdit1;
      this.Aktar.FieldName = "Aktar";
      this.Aktar.Name = "Aktar";
      this.Aktar.OptionsColumn.FixedWidth = true;
      this.Aktar.Visible = true;
      this.Aktar.VisibleIndex = 0;
      this.Aktar.Width = 40;
      // 
      // repositoryItemCheckEdit1
      // 
      this.repositoryItemCheckEdit1.AutoHeight = false;
      this.repositoryItemCheckEdit1.Caption = "Check";
      this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
      // 
      // AlanAdi
      // 
      this.AlanAdi.Caption = "AlanAdi";
      this.AlanAdi.FieldName = "AlanAdi";
      this.AlanAdi.Name = "AlanAdi";
      this.AlanAdi.OptionsColumn.AllowEdit = false;
      this.AlanAdi.OptionsColumn.FixedWidth = true;
      this.AlanAdi.Visible = true;
      this.AlanAdi.VisibleIndex = 1;
      this.AlanAdi.Width = 97;
      // 
      // ExcelSutunu
      // 
      this.ExcelSutunu.Caption = "ExcelSutunu";
      this.ExcelSutunu.ColumnEdit = this.repositoryItemComboBox1;
      this.ExcelSutunu.FieldName = "ExcelSutunu";
      this.ExcelSutunu.Name = "ExcelSutunu";
      this.ExcelSutunu.OptionsColumn.FixedWidth = true;
      this.ExcelSutunu.Visible = true;
      this.ExcelSutunu.VisibleIndex = 2;
      this.ExcelSutunu.Width = 86;
      // 
      // repositoryItemComboBox1
      // 
      this.repositoryItemComboBox1.AutoHeight = false;
      this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
      this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
      // 
      // Aciklama
      // 
      this.Aciklama.Caption = "Aciklama";
      this.Aciklama.FieldName = "Aciklama";
      this.Aciklama.Name = "Aciklama";
      this.Aciklama.OptionsColumn.AllowEdit = false;
      this.Aciklama.OptionsColumn.FixedWidth = true;
      this.Aciklama.Visible = true;
      this.Aciklama.VisibleIndex = 3;
      this.Aciklama.Width = 255;
      // 
      // xtraTabPage2
      // 
      this.xtraTabPage2.Controls.Add(this.gcExeldekiler);
      this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(4);
      this.xtraTabPage2.Name = "xtraTabPage2";
      this.xtraTabPage2.Size = new System.Drawing.Size(655, 440);
      this.xtraTabPage2.Text = "Aktarılacaklar";
      // 
      // gcExeldekiler
      // 
      this.gcExeldekiler.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gcExeldekiler.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
      this.gcExeldekiler.Location = new System.Drawing.Point(0, 0);
      this.gcExeldekiler.MainView = this.gvExeldekiler;
      this.gcExeldekiler.Margin = new System.Windows.Forms.Padding(4);
      this.gcExeldekiler.Name = "gcExeldekiler";
      this.gcExeldekiler.Size = new System.Drawing.Size(655, 440);
      this.gcExeldekiler.TabIndex = 0;
      this.gcExeldekiler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvExeldekiler});
      // 
      // gvExeldekiler
      // 
      this.gvExeldekiler.GridControl = this.gcExeldekiler;
      this.gvExeldekiler.Name = "gvExeldekiler";
      this.gvExeldekiler.OptionsView.ShowGroupPanel = false;
      // 
      // xtraTabPage3
      // 
      this.xtraTabPage3.Margin = new System.Windows.Forms.Padding(4);
      this.xtraTabPage3.Name = "xtraTabPage3";
      this.xtraTabPage3.Size = new System.Drawing.Size(655, 440);
      this.xtraTabPage3.Text = "Sorunlu Alanlar";
      // 
      // openFileDialog1
      // 
      this.openFileDialog1.FileName = "openFileDialog1";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(11, 39);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(222, 17);
      this.label1.TabIndex = 14;
      this.label1.Text = "İlk satır başlıkları içermek zorundadır";
      // 
      // simpleButton2
      // 
      this.simpleButton2.Location = new System.Drawing.Point(523, 606);
      this.simpleButton2.Margin = new System.Windows.Forms.Padding(4);
      this.simpleButton2.Name = "simpleButton2";
      this.simpleButton2.Size = new System.Drawing.Size(143, 28);
      this.simpleButton2.TabIndex = 19;
      this.simpleButton2.Text = "Vazgeç";
      // 
      // btnAktar
      // 
      this.btnAktar.Enabled = false;
      this.btnAktar.Location = new System.Drawing.Point(11, 606);
      this.btnAktar.Margin = new System.Windows.Forms.Padding(4);
      this.btnAktar.Name = "btnAktar";
      this.btnAktar.Size = new System.Drawing.Size(504, 28);
      this.btnAktar.TabIndex = 20;
      this.btnAktar.Text = "Aktar";
      this.btnAktar.Click += new System.EventHandler(this.btnAktar_Click);
      // 
      // cmbStokKarsilastirmaAlani
      // 
      this.cmbStokKarsilastirmaAlani.FormattingEnabled = true;
      this.cmbStokKarsilastirmaAlani.Items.AddRange(new object[] {
            "Stok kodu",
            "Stok adı"});
      this.cmbStokKarsilastirmaAlani.Location = new System.Drawing.Point(187, 70);
      this.cmbStokKarsilastirmaAlani.Margin = new System.Windows.Forms.Padding(4);
      this.cmbStokKarsilastirmaAlani.Name = "cmbStokKarsilastirmaAlani";
      this.cmbStokKarsilastirmaAlani.Size = new System.Drawing.Size(160, 24);
      this.cmbStokKarsilastirmaAlani.TabIndex = 16;
      // 
      // cmbStokMevcutDegilse
      // 
      this.cmbStokMevcutDegilse.FormattingEnabled = true;
      this.cmbStokMevcutDegilse.Items.AddRange(new object[] {
            "Yeni kayıt oluştur",
            "Hiçbir işlem yapma"});
      this.cmbStokMevcutDegilse.Location = new System.Drawing.Point(511, 67);
      this.cmbStokMevcutDegilse.Margin = new System.Windows.Forms.Padding(4);
      this.cmbStokMevcutDegilse.Name = "cmbStokMevcutDegilse";
      this.cmbStokMevcutDegilse.Size = new System.Drawing.Size(160, 24);
      this.cmbStokMevcutDegilse.TabIndex = 17;
      // 
      // cmbStokMevcutsa
      // 
      this.cmbStokMevcutsa.FormattingEnabled = true;
      this.cmbStokMevcutsa.Items.AddRange(new object[] {
            "Bilgileri güncelle",
            "Hiçbir işlem yapma"});
      this.cmbStokMevcutsa.Location = new System.Drawing.Point(511, 100);
      this.cmbStokMevcutsa.Margin = new System.Windows.Forms.Padding(4);
      this.cmbStokMevcutsa.Name = "cmbStokMevcutsa";
      this.cmbStokMevcutsa.Size = new System.Drawing.Size(160, 24);
      this.cmbStokMevcutsa.TabIndex = 18;
      // 
      // spinEdit1
      // 
      this.spinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
      this.spinEdit1.Location = new System.Drawing.Point(582, 35);
      this.spinEdit1.Margin = new System.Windows.Forms.Padding(4);
      this.spinEdit1.Name = "spinEdit1";
      this.spinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.spinEdit1.Size = new System.Drawing.Size(91, 22);
      this.spinEdit1.TabIndex = 15;
      // 
      // labelControl5
      // 
      this.labelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
      this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
      this.labelControl5.Location = new System.Drawing.Point(11, 67);
      this.labelControl5.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl5.Name = "labelControl5";
      this.labelControl5.Size = new System.Drawing.Size(151, 52);
      this.labelControl5.TabIndex = 8;
      this.labelControl5.Text = "Stokun karşılaştırlması hangi alandan yapılacak";
      // 
      // buttonEdit1
      // 
      this.buttonEdit1.Location = new System.Drawing.Point(187, 4);
      this.buttonEdit1.Margin = new System.Windows.Forms.Padding(4);
      this.buttonEdit1.Name = "buttonEdit1";
      this.buttonEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
      this.buttonEdit1.Properties.ReadOnly = true;
      this.buttonEdit1.Properties.Click += new System.EventHandler(this.buttonEdit1_Properties_Click);
      this.buttonEdit1.Size = new System.Drawing.Size(485, 22);
      this.buttonEdit1.TabIndex = 13;
      // 
      // labelControl4
      // 
      this.labelControl4.Location = new System.Drawing.Point(360, 70);
      this.labelControl4.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl4.Name = "labelControl4";
      this.labelControl4.Size = new System.Drawing.Size(114, 16);
      this.labelControl4.TabIndex = 9;
      this.labelControl4.Text = "Stok mevcut değilse";
      // 
      // labelControl3
      // 
      this.labelControl3.Location = new System.Drawing.Point(360, 103);
      this.labelControl3.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl3.Name = "labelControl3";
      this.labelControl3.Size = new System.Drawing.Size(83, 16);
      this.labelControl3.TabIndex = 10;
      this.labelControl3.Text = "Stok mevcutsa";
      // 
      // labelControl2
      // 
      this.labelControl2.Location = new System.Drawing.Point(360, 39);
      this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl2.Name = "labelControl2";
      this.labelControl2.Size = new System.Drawing.Size(192, 16);
      this.labelControl2.TabIndex = 11;
      this.labelControl2.Text = "Bilgilerin alınacağı çalışma sayfası";
      // 
      // labelControl1
      // 
      this.labelControl1.Location = new System.Drawing.Point(11, 11);
      this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
      this.labelControl1.Name = "labelControl1";
      this.labelControl1.Size = new System.Drawing.Size(101, 16);
      this.labelControl1.TabIndex = 12;
      this.labelControl1.Text = "Excel Dosyası Seç";
      // 
      // frmExceldenCariAktar
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(724, 659);
      this.Controls.Add(this.xtraTabControl1);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.simpleButton2);
      this.Controls.Add(this.btnAktar);
      this.Controls.Add(this.cmbStokKarsilastirmaAlani);
      this.Controls.Add(this.cmbStokMevcutDegilse);
      this.Controls.Add(this.cmbStokMevcutsa);
      this.Controls.Add(this.spinEdit1);
      this.Controls.Add(this.labelControl5);
      this.Controls.Add(this.buttonEdit1);
      this.Controls.Add(this.labelControl4);
      this.Controls.Add(this.labelControl3);
      this.Controls.Add(this.labelControl2);
      this.Controls.Add(this.labelControl1);
      this.Name = "frmExceldenCariAktar";
      this.Text = "frmExceldenCariAktar";
      this.Load += new System.EventHandler(this.frmExceldenCariAktar_Load);
      ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
      this.xtraTabControl1.ResumeLayout(false);
      this.xtraTabPage1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gcAktarilacaklarListesi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvAktarilacaklarListesi)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
      this.xtraTabPage2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gcExeldekiler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gvExeldekiler)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.spinEdit1.Properties)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.buttonEdit1.Properties)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
    private DevExpress.XtraGrid.GridControl gcAktarilacaklarListesi;
    private DevExpress.XtraGrid.Views.Grid.GridView gvAktarilacaklarListesi;
    private DevExpress.XtraGrid.Columns.GridColumn Aktar;
    private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    private DevExpress.XtraGrid.Columns.GridColumn AlanAdi;
    private DevExpress.XtraGrid.Columns.GridColumn ExcelSutunu;
    private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
    private DevExpress.XtraGrid.Columns.GridColumn Aciklama;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
    private DevExpress.XtraGrid.GridControl gcExeldekiler;
    private DevExpress.XtraGrid.Views.Grid.GridView gvExeldekiler;
    private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    private System.Windows.Forms.Label label1;
    private DevExpress.XtraEditors.SimpleButton simpleButton2;
    private DevExpress.XtraEditors.SimpleButton btnAktar;
    private System.Windows.Forms.ComboBox cmbStokKarsilastirmaAlani;
    private System.Windows.Forms.ComboBox cmbStokMevcutDegilse;
    private System.Windows.Forms.ComboBox cmbStokMevcutsa;
    private DevExpress.XtraEditors.SpinEdit spinEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl5;
    private DevExpress.XtraEditors.ButtonEdit buttonEdit1;
    private DevExpress.XtraEditors.LabelControl labelControl4;
    private DevExpress.XtraEditors.LabelControl labelControl3;
    private DevExpress.XtraEditors.LabelControl labelControl2;
    private DevExpress.XtraEditors.LabelControl labelControl1;

  }
}