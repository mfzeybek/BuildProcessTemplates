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
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.lkpKullanilanFiyatTanimi = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtUretilenStokKodu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretimMiktari.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpKullanilanFiyatTanimi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokKodu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUretilenStokAdi
            // 
            this.txtUretilenStokAdi.Location = new System.Drawing.Point(236, 150);
            this.txtUretilenStokAdi.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUretilenStokAdi.Name = "txtUretilenStokAdi";
            this.txtUretilenStokAdi.Size = new System.Drawing.Size(508, 32);
            this.txtUretilenStokAdi.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(22, 156);
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
            this.gridControl1.Size = new System.Drawing.Size(1223, 227);
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
            this.colSiraNo.Width = 54;
            // 
            // colMalzemeStokID
            // 
            this.colMalzemeStokID.Caption = "MalzemeStokID";
            this.colMalzemeStokID.FieldName = "MalzemeStokID";
            this.colMalzemeStokID.Name = "colMalzemeStokID";
            this.colMalzemeStokID.Visible = true;
            this.colMalzemeStokID.VisibleIndex = 3;
            this.colMalzemeStokID.Width = 102;
            // 
            // colMaliyetFiyatTanimID
            // 
            this.colMaliyetFiyatTanimID.Caption = "MaliyetFiyatTanimID";
            this.colMaliyetFiyatTanimID.FieldName = "MaliyetFiyatTanimID";
            this.colMaliyetFiyatTanimID.Name = "colMaliyetFiyatTanimID";
            this.colMaliyetFiyatTanimID.Visible = true;
            this.colMaliyetFiyatTanimID.VisibleIndex = 4;
            this.colMaliyetFiyatTanimID.Width = 102;
            // 
            // colMaliyet
            // 
            this.colMaliyet.Caption = "Maliyet";
            this.colMaliyet.FieldName = "Maliyet";
            this.colMaliyet.Name = "colMaliyet";
            this.colMaliyet.Visible = true;
            this.colMaliyet.VisibleIndex = 5;
            this.colMaliyet.Width = 102;
            // 
            // colGerekliMiktar
            // 
            this.colGerekliMiktar.Caption = "GerekliMiktar";
            this.colGerekliMiktar.FieldName = "GerekliMiktar";
            this.colGerekliMiktar.Name = "colGerekliMiktar";
            this.colGerekliMiktar.Visible = true;
            this.colGerekliMiktar.VisibleIndex = 6;
            this.colGerekliMiktar.Width = 102;
            // 
            // colMaliyetTutari
            // 
            this.colMaliyetTutari.Caption = "MaliyetTutari";
            this.colMaliyetTutari.FieldName = "MaliyetTutari";
            this.colMaliyetTutari.Name = "colMaliyetTutari";
            this.colMaliyetTutari.Visible = true;
            this.colMaliyetTutari.VisibleIndex = 7;
            this.colMaliyetTutari.Width = 102;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 8;
            this.colAciklama.Width = 106;
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
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 2;
            this.colStokAdi.Width = 102;
            // 
            // colStokKodu
            // 
            this.colStokKodu.Caption = "StokKodu";
            this.colStokKodu.FieldName = "StokKodu";
            this.colStokKodu.Name = "colStokKodu";
            this.colStokKodu.Visible = true;
            this.colStokKodu.VisibleIndex = 1;
            this.colStokKodu.Width = 102;
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
            this.labelControl2.Location = new System.Drawing.Point(1058, 1028);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(132, 25);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Üretim Miktarı";
            // 
            // txtUretimMiktari
            // 
            this.txtUretimMiktari.Location = new System.Drawing.Point(236, 194);
            this.txtUretimMiktari.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtUretimMiktari.Name = "txtUretimMiktari";
            this.txtUretimMiktari.Size = new System.Drawing.Size(508, 32);
            this.txtUretimMiktari.TabIndex = 7;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(112, 1085);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(264, 69);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(22, 338);
            this.simpleButton3.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(76, 65);
            this.simpleButton3.TabIndex = 9;
            this.simpleButton3.Text = "+";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(22, 417);
            this.simpleButton4.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(76, 65);
            this.simpleButton4.TabIndex = 9;
            this.simpleButton4.Text = "-";
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(22, 500);
            this.simpleButton5.Margin = new System.Windows.Forms.Padding(4);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(76, 65);
            this.simpleButton5.TabIndex = 9;
            this.simpleButton5.Text = "A";
            // 
            // lkpKullanilanFiyatTanimi
            // 
            this.lkpKullanilanFiyatTanimi.Location = new System.Drawing.Point(926, 99);
            this.lkpKullanilanFiyatTanimi.Margin = new System.Windows.Forms.Padding(6);
            this.lkpKullanilanFiyatTanimi.Name = "lkpKullanilanFiyatTanimi";
            this.lkpKullanilanFiyatTanimi.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkpKullanilanFiyatTanimi.Size = new System.Drawing.Size(406, 32);
            this.lkpKullanilanFiyatTanimi.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(778, 105);
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
            this.txtUretilenStokKodu.Size = new System.Drawing.Size(508, 32);
            this.txtUretilenStokKodu.TabIndex = 0;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(22, 106);
            this.labelControl4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(174, 25);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Üretilen Stok Kodu";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(132, 616);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(150, 65);
            this.btnKaydet.TabIndex = 11;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(322, 616);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(150, 65);
            this.btnVazgec.TabIndex = 11;
            this.btnVazgec.Text = "Vazgeç";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(505, 616);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(150, 65);
            this.btnSil.TabIndex = 11;
            this.btnSil.Text = "Sil";
            // 
            // frmBasitUretim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1347, 693);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lkpKullanilanFiyatTanimi);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.txtUretimMiktari);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnReceteSec);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtUretilenStokKodu);
            this.Controls.Add(this.txtUretilenStokAdi);
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "frmBasitUretim";
            this.Text = "sim";
            this.Load += new System.EventHandler(this.BasitUretim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretimMiktari.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkpKullanilanFiyatTanimi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUretilenStokKodu.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
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
    }
}