namespace Aresv2.BasitUretim
{
    partial class frmBasitUretim
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
            this.txtUretilenStokAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnReceteSec = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBasitUretimDetayID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiraNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMalzemeStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaliyetFiyatTanimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colMaliyet = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGerekliMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaliyetTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBasitUretimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUretimMiktari = new DevExpress.XtraEditors.TextEdit();
            this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokCikar = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokAc = new DevExpress.XtraEditors.SimpleButton();
            this.lkpKullanilanFiyatTanimi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUretilenStokKodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.btnCariSec = new DevExpress.XtraEditors.SimpleButton();
            this.txtCariTanim = new DevExpress.XtraEditors.MemoEdit();
            this.txtToplamMaliyet = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.txtCariKodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretimMiktari.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpKullanilanFiyatTanimi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokKodu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariTanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplamMaliyet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUretilenStokAdi
            // 
            this.txtUretilenStokAdi.Location = new System.Drawing.Point(236, 150);
            this.txtUretilenStokAdi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUretilenStokAdi.Name = "txtUretilenStokAdi";
            this.txtUretilenStokAdi.Size = new System.Drawing.Size(508, 34);
            this.txtUretilenStokAdi.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(40, 156);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(157, 25);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Üretilen Stok Adı";
            // 
            // btnReceteSec
            // 
            this.btnReceteSec.Location = new System.Drawing.Point(72, 17);
            this.btnReceteSec.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnReceteSec.Name = "btnReceteSec";
            this.btnReceteSec.Size = new System.Drawing.Size(282, 52);
            this.btnReceteSec.TabIndex = 2;
            this.btnReceteSec.Text = "Reçete Seç";
            this.btnReceteSec.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gridControl1.Location = new System.Drawing.Point(112, 338);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(2016, 369);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBasitUretimDetayID,
            this.colSiraNo,
            this.colMalzemeStokID,
            this.colMaliyetFiyatTanimID,
            this.colMaliyet,
            this.colGerekliMiktar,
            this.colMaliyetTutari,
            this.colAciklama,
            this.colBasitUretimID,
            this.colStokAdi,
            this.colStokKodu});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colBasitUretimDetayID
            // 
            this.colBasitUretimDetayID.Caption = "BasitUretimDetayID";
            this.colBasitUretimDetayID.FieldName = "BasitUretimDetayID";
            this.colBasitUretimDetayID.Name = "colBasitUretimDetayID";
            // 
            // colSiraNo
            // 
            this.colSiraNo.Caption = "SiraNo";
            this.colSiraNo.FieldName = "SiraNo";
            this.colSiraNo.Name = "colSiraNo";
            this.colSiraNo.Visible = true;
            this.colSiraNo.VisibleIndex = 0;
            this.colSiraNo.Width = 53;
            // 
            // colMalzemeStokID
            // 
            this.colMalzemeStokID.Caption = "MalzemeStokID";
            this.colMalzemeStokID.FieldName = "MalzemeStokID";
            this.colMalzemeStokID.Name = "colMalzemeStokID";
            this.colMalzemeStokID.Width = 102;
            // 
            // colMaliyetFiyatTanimID
            // 
            this.colMaliyetFiyatTanimID.Caption = "MaliyetFiyatTanimID";
            this.colMaliyetFiyatTanimID.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colMaliyetFiyatTanimID.FieldName = "MaliyetFiyatTanimID";
            this.colMaliyetFiyatTanimID.Name = "colMaliyetFiyatTanimID";
            this.colMaliyetFiyatTanimID.Visible = true;
            this.colMaliyetFiyatTanimID.VisibleIndex = 3;
            this.colMaliyetFiyatTanimID.Width = 132;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            // 
            // colMaliyet
            // 
            this.colMaliyet.Caption = "Maliyet";
            this.colMaliyet.FieldName = "Maliyet";
            this.colMaliyet.Name = "colMaliyet";
            this.colMaliyet.Visible = true;
            this.colMaliyet.VisibleIndex = 4;
            this.colMaliyet.Width = 132;
            // 
            // colGerekliMiktar
            // 
            this.colGerekliMiktar.Caption = "GerekliMiktar";
            this.colGerekliMiktar.FieldName = "GerekliMiktar";
            this.colGerekliMiktar.Name = "colGerekliMiktar";
            this.colGerekliMiktar.Visible = true;
            this.colGerekliMiktar.VisibleIndex = 5;
            this.colGerekliMiktar.Width = 132;
            // 
            // colMaliyetTutari
            // 
            this.colMaliyetTutari.Caption = "MaliyetTutari";
            this.colMaliyetTutari.FieldName = "MaliyetTutari";
            this.colMaliyetTutari.Name = "colMaliyetTutari";
            this.colMaliyetTutari.Visible = true;
            this.colMaliyetTutari.VisibleIndex = 6;
            this.colMaliyetTutari.Width = 132;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 7;
            this.colAciklama.Width = 145;
            // 
            // colBasitUretimID
            // 
            this.colBasitUretimID.Caption = "BasitUretimID";
            this.colBasitUretimID.FieldName = "BasitUretimID";
            this.colBasitUretimID.Name = "colBasitUretimID";
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "StokAdi";
            this.colStokAdi.FieldName = "MalzemeStokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 2;
            this.colStokAdi.Width = 132;
            // 
            // colStokKodu
            // 
            this.colStokKodu.Caption = "StokKodu";
            this.colStokKodu.FieldName = "MalzemeStokKodu";
            this.colStokKodu.Name = "colStokKodu";
            this.colStokKodu.Visible = true;
            this.colStokKodu.VisibleIndex = 1;
            this.colStokKodu.Width = 132;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(388, 17);
            this.simpleButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(324, 52);
            this.simpleButton2.TabIndex = 4;
            this.simpleButton2.Text = "ÜretilecekUrunSecimi";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(40, 248);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(83, 25);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Açıklama";
            // 
            // txtUretimMiktari
            // 
            this.txtUretimMiktari.Location = new System.Drawing.Point(236, 191);
            this.txtUretimMiktari.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUretimMiktari.Name = "txtUretimMiktari";
            this.txtUretimMiktari.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUretimMiktari.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtUretimMiktari.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.Value;
            this.txtUretimMiktari.Properties.NullText = "0";
            this.txtUretimMiktari.Properties.NullValuePrompt = "0";
            this.txtUretimMiktari.Size = new System.Drawing.Size(508, 34);
            this.txtUretimMiktari.TabIndex = 7;
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(22, 338);
            this.btnStokEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(76, 65);
            this.btnStokEkle.TabIndex = 9;
            this.btnStokEkle.Text = "+";
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // btnStokCikar
            // 
            this.btnStokCikar.Location = new System.Drawing.Point(22, 417);
            this.btnStokCikar.Margin = new System.Windows.Forms.Padding(4);
            this.btnStokCikar.Name = "btnStokCikar";
            this.btnStokCikar.Size = new System.Drawing.Size(76, 65);
            this.btnStokCikar.TabIndex = 9;
            this.btnStokCikar.Text = "-";
            // 
            // btnStokAc
            // 
            this.btnStokAc.Location = new System.Drawing.Point(22, 500);
            this.btnStokAc.Margin = new System.Windows.Forms.Padding(4);
            this.btnStokAc.Name = "btnStokAc";
            this.btnStokAc.Size = new System.Drawing.Size(76, 65);
            this.btnStokAc.TabIndex = 9;
            this.btnStokAc.Text = "A";
            // 
            // lkpKullanilanFiyatTanimi
            // 
            this.lkpKullanilanFiyatTanimi.Location = new System.Drawing.Point(902, 100);
            this.lkpKullanilanFiyatTanimi.Margin = new System.Windows.Forms.Padding(6);
            this.lkpKullanilanFiyatTanimi.Name = "lkpKullanilanFiyatTanimi";
            this.lkpKullanilanFiyatTanimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpKullanilanFiyatTanimi.Size = new System.Drawing.Size(258, 34);
            this.lkpKullanilanFiyatTanimi.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(778, 106);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(114, 25);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Fiyat Tanımı";
            // 
            // txtUretilenStokKodu
            // 
            this.txtUretilenStokKodu.Location = new System.Drawing.Point(236, 100);
            this.txtUretilenStokKodu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUretilenStokKodu.Name = "txtUretilenStokKodu";
            this.txtUretilenStokKodu.Properties.ReadOnly = true;
            this.txtUretilenStokKodu.Size = new System.Drawing.Size(508, 34);
            this.txtUretilenStokKodu.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(40, 106);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(174, 25);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Üretilen Stok Kodu";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKaydet.Location = new System.Drawing.Point(112, 717);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(4);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(510, 65);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVazgec.Location = new System.Drawing.Point(686, 717);
            this.btnVazgec.Margin = new System.Windows.Forms.Padding(4);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(150, 65);
            this.btnVazgec.TabIndex = 11;
            this.btnVazgec.Text = "Vazgeç";
            // 
            // btnSil
            // 
            this.btnSil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSil.Location = new System.Drawing.Point(934, 717);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(150, 65);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(40, 200);
            this.labelControl5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(132, 25);
            this.labelControl5.TabIndex = 1;
            this.labelControl5.Text = "Üretim Miktarı";
            // 
            // btnCariSec
            // 
            this.btnCariSec.Location = new System.Drawing.Point(1178, 27);
            this.btnCariSec.Margin = new System.Windows.Forms.Padding(6);
            this.btnCariSec.Name = "btnCariSec";
            this.btnCariSec.Size = new System.Drawing.Size(294, 44);
            this.btnCariSec.TabIndex = 12;
            this.btnCariSec.Text = "Cari Seç";
            this.btnCariSec.Click += new System.EventHandler(this.btnCariSec_Click);
            // 
            // txtCariTanim
            // 
            this.txtCariTanim.Location = new System.Drawing.Point(1178, 102);
            this.txtCariTanim.Margin = new System.Windows.Forms.Padding(6);
            this.txtCariTanim.Name = "txtCariTanim";
            this.txtCariTanim.Size = new System.Drawing.Size(608, 79);
            this.txtCariTanim.TabIndex = 13;
            // 
            // txtToplamMaliyet
            // 
            this.txtToplamMaliyet.Location = new System.Drawing.Point(1586, 267);
            this.txtToplamMaliyet.Margin = new System.Windows.Forms.Padding(6);
            this.txtToplamMaliyet.Name = "txtToplamMaliyet";
            this.txtToplamMaliyet.Size = new System.Drawing.Size(200, 34);
            this.txtToplamMaliyet.TabIndex = 14;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(1372, 273);
            this.labelControl6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(203, 25);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Toplam Maliyet Tutarı";
            // 
            // txtAciklama
            // 
            this.txtAciklama.Location = new System.Drawing.Point(236, 244);
            this.txtAciklama.Margin = new System.Windows.Forms.Padding(6);
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Size = new System.Drawing.Size(508, 79);
            this.txtAciklama.TabIndex = 13;
            // 
            // txtCariKodu
            // 
            this.txtCariKodu.Location = new System.Drawing.Point(1178, 193);
            this.txtCariKodu.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtCariKodu.Name = "txtCariKodu";
            this.txtCariKodu.Size = new System.Drawing.Size(508, 34);
            this.txtCariKodu.TabIndex = 0;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(1013, 195);
            this.labelControl7.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(91, 25);
            this.labelControl7.TabIndex = 1;
            this.labelControl7.Text = "Cari Kodu";
            // 
            // frmBasitUretim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2140, 804);
            this.Controls.Add(this.txtToplamMaliyet);
            this.Controls.Add(this.txtAciklama);
            this.Controls.Add(this.txtCariTanim);
            this.Controls.Add(this.btnCariSec);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lkpKullanilanFiyatTanimi);
            this.Controls.Add(this.btnStokAc);
            this.Controls.Add(this.btnStokCikar);
            this.Controls.Add(this.btnStokEkle);
            this.Controls.Add(this.txtUretimMiktari);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnReceteSec);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtUretilenStokKodu);
            this.Controls.Add(this.txtCariKodu);
            this.Controls.Add(this.txtUretilenStokAdi);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmBasitUretim";
            this.Text = "Üretim";
            this.Load += new System.EventHandler(this.BasitUretim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretimMiktari.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpKullanilanFiyatTanimi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokKodu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariTanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToplamMaliyet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCariKodu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtUretilenStokAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnReceteSec;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtUretimMiktari;
        private DevExpress.XtraEditors.SimpleButton btnStokEkle;
        private DevExpress.XtraEditors.SimpleButton btnStokCikar;
        private DevExpress.XtraEditors.SimpleButton btnStokAc;
        private DevExpress.XtraEditors.LookUpEdit lkpKullanilanFiyatTanimi;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colBasitUretimDetayID;
        private DevExpress.XtraGrid.Columns.GridColumn colSiraNo;
        private DevExpress.XtraGrid.Columns.GridColumn colMalzemeStokID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaliyetFiyatTanimID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaliyet;
        private DevExpress.XtraGrid.Columns.GridColumn colGerekliMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colMaliyetTutari;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colBasitUretimID;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colStokKodu;
        private DevExpress.XtraEditors.TextEdit txtUretilenStokKodu;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.SimpleButton btnCariSec;
        private DevExpress.XtraEditors.MemoEdit txtCariTanim;
        private DevExpress.XtraEditors.TextEdit txtToplamMaliyet;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit txtAciklama;
        private DevExpress.XtraEditors.TextEdit txtCariKodu;
        private DevExpress.XtraEditors.LabelControl labelControl7;
    }
}