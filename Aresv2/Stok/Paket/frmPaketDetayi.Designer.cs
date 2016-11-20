namespace Aresv2.Stok.Paket
{
    partial class frmPaketDetayi
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
            this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPaketDetayID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaketID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltBirimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltBirimMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKatSayi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAciklama = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMiktar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.memoAciklama = new DevExpress.XtraEditors.MemoEdit();
            this.txtPaketAdi = new DevExpress.XtraEditors.TextEdit();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnSil = new DevExpress.XtraEditors.SimpleButton();
            this.txtBarkod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton4 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton5 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton6 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaketAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(8, 140);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(104, 23);
            this.btnStokEkle.TabIndex = 0;
            this.btnStokEkle.Text = "Stok Ekle";
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(133, 140);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(938, 453);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPaketDetayID,
            this.colPaketID,
            this.colStokID,
            this.colAltBirimID,
            this.colAltBirimMiktar,
            this.colKatSayi,
            this.colAciklama,
            this.colMiktar,
            this.colStokAdi});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colPaketDetayID
            // 
            this.colPaketDetayID.Caption = "PaketDetayID";
            this.colPaketDetayID.FieldName = "PaketDetayID";
            this.colPaketDetayID.Name = "colPaketDetayID";
            this.colPaketDetayID.Visible = true;
            this.colPaketDetayID.VisibleIndex = 0;
            // 
            // colPaketID
            // 
            this.colPaketID.Caption = "PaketID";
            this.colPaketID.FieldName = "PaketID";
            this.colPaketID.Name = "colPaketID";
            this.colPaketID.Visible = true;
            this.colPaketID.VisibleIndex = 1;
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            this.colStokID.Visible = true;
            this.colStokID.VisibleIndex = 2;
            // 
            // colAltBirimID
            // 
            this.colAltBirimID.Caption = "AltBirimID";
            this.colAltBirimID.FieldName = "AltBirimID";
            this.colAltBirimID.Name = "colAltBirimID";
            this.colAltBirimID.Visible = true;
            this.colAltBirimID.VisibleIndex = 4;
            // 
            // colAltBirimMiktar
            // 
            this.colAltBirimMiktar.Caption = "AltBirimMiktar";
            this.colAltBirimMiktar.FieldName = "AltBirimMiktar";
            this.colAltBirimMiktar.Name = "colAltBirimMiktar";
            this.colAltBirimMiktar.Visible = true;
            this.colAltBirimMiktar.VisibleIndex = 5;
            // 
            // colKatSayi
            // 
            this.colKatSayi.Caption = "KatSayi";
            this.colKatSayi.FieldName = "KatSayi";
            this.colKatSayi.Name = "colKatSayi";
            this.colKatSayi.Visible = true;
            this.colKatSayi.VisibleIndex = 6;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Aciklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.Visible = true;
            this.colAciklama.VisibleIndex = 7;
            // 
            // colMiktar
            // 
            this.colMiktar.Caption = "Miktar";
            this.colMiktar.FieldName = "Miktar";
            this.colMiktar.Name = "colMiktar";
            this.colMiktar.Visible = true;
            this.colMiktar.VisibleIndex = 8;
            // 
            // colStokAdi
            // 
            this.colStokAdi.Caption = "StokAdi";
            this.colStokAdi.FieldName = "StokAdi";
            this.colStokAdi.Name = "colStokAdi";
            this.colStokAdi.Visible = true;
            this.colStokAdi.VisibleIndex = 3;
            // 
            // memoAciklama
            // 
            this.memoAciklama.Location = new System.Drawing.Point(486, 12);
            this.memoAciklama.Name = "memoAciklama";
            this.memoAciklama.Size = new System.Drawing.Size(585, 69);
            this.memoAciklama.TabIndex = 2;
            // 
            // txtPaketAdi
            // 
            this.txtPaketAdi.Location = new System.Drawing.Point(173, 12);
            this.txtPaketAdi.Name = "txtPaketAdi";
            this.txtPaketAdi.Size = new System.Drawing.Size(209, 22);
            this.txtPaketAdi.TabIndex = 3;
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(133, 599);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(155, 38);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Location = new System.Drawing.Point(331, 599);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(155, 38);
            this.btnVazgec.TabIndex = 4;
            this.btnVazgec.Text = "Vazgeç";
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(703, 599);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(147, 38);
            this.btnSil.TabIndex = 4;
            this.btnSil.Text = "Sil";
            // 
            // txtBarkod
            // 
            this.txtBarkod.Location = new System.Drawing.Point(173, 59);
            this.txtBarkod.Name = "txtBarkod";
            this.txtBarkod.Size = new System.Drawing.Size(209, 22);
            this.txtBarkod.TabIndex = 5;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(59, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(53, 16);
            this.labelControl1.TabIndex = 7;
            this.labelControl1.Text = "Paket Adi";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(66, 62);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 16);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Barkodu";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(422, 14);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(51, 16);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Açıklama";
            // 
            // simpleButton4
            // 
            this.simpleButton4.Location = new System.Drawing.Point(8, 169);
            this.simpleButton4.Name = "simpleButton4";
            this.simpleButton4.Size = new System.Drawing.Size(104, 23);
            this.simpleButton4.TabIndex = 8;
            this.simpleButton4.Text = "Stok Çıkar";
            this.simpleButton4.Click += new System.EventHandler(this.simpleButton4_Click);
            // 
            // simpleButton5
            // 
            this.simpleButton5.Location = new System.Drawing.Point(173, 87);
            this.simpleButton5.Name = "simpleButton5";
            this.simpleButton5.Size = new System.Drawing.Size(209, 33);
            this.simpleButton5.TabIndex = 9;
            this.simpleButton5.Text = "Barkod Numarası Oluştur";
            // 
            // simpleButton6
            // 
            this.simpleButton6.Location = new System.Drawing.Point(8, 232);
            this.simpleButton6.Name = "simpleButton6";
            this.simpleButton6.Size = new System.Drawing.Size(104, 23);
            this.simpleButton6.TabIndex = 8;
            this.simpleButton6.Text = "Stok Kartını Aç";
            // 
            // frmPaketDetayi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 649);
            this.Controls.Add(this.simpleButton5);
            this.Controls.Add(this.simpleButton6);
            this.Controls.Add(this.simpleButton4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtBarkod);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtPaketAdi);
            this.Controls.Add(this.memoAciklama);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.btnStokEkle);
            this.Name = "frmPaketDetayi";
            this.Text = "frmPaketDetayi";
            this.Load += new System.EventHandler(this.frmPaketDetayi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memoAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPaketAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarkod.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnStokEkle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.MemoEdit memoAciklama;
        private DevExpress.XtraEditors.TextEdit txtPaketAdi;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnSil;
        private DevExpress.XtraEditors.TextEdit txtBarkod;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButton4;
        private DevExpress.XtraEditors.SimpleButton simpleButton5;
        private DevExpress.XtraEditors.SimpleButton simpleButton6;
        private DevExpress.XtraGrid.Columns.GridColumn colPaketDetayID;
        private DevExpress.XtraGrid.Columns.GridColumn colPaketID;
        private DevExpress.XtraGrid.Columns.GridColumn colStokID;
        private DevExpress.XtraGrid.Columns.GridColumn colAltBirimID;
        private DevExpress.XtraGrid.Columns.GridColumn colAltBirimMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colKatSayi;
        private DevExpress.XtraGrid.Columns.GridColumn colAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colMiktar;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
    }
}