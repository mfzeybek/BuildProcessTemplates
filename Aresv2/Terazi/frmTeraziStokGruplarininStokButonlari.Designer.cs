namespace Aresv2.Terazi
{
    partial class frmTeraziStokGruplarininStokButonlari
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
            this.btnStokCikar = new DevExpress.XtraEditors.SimpleButton();
            this.btnStokEkle = new DevExpress.XtraEditors.SimpleButton();
            this.gcStokButonlari = new DevExpress.XtraGrid.GridControl();
            this.gvStokButonlari = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTeraziStokGrupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeraziStokGrupTanimID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiraNu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeraziKisayolTusu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblStokGrupAdi = new DevExpress.XtraEditors.LabelControl();
            this.lblStokGrupAciklama = new DevExpress.XtraEditors.LabelControl();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.colAktif = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gcStokButonlari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStokButonlari)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStokCikar
            // 
            this.btnStokCikar.Location = new System.Drawing.Point(0, 138);
            this.btnStokCikar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStokCikar.Name = "btnStokCikar";
            this.btnStokCikar.Size = new System.Drawing.Size(122, 23);
            this.btnStokCikar.TabIndex = 7;
            this.btnStokCikar.Text = "Stok Çıkar";
            this.btnStokCikar.Click += new System.EventHandler(this.btnStokCikar_Click);
            // 
            // btnStokEkle
            // 
            this.btnStokEkle.Location = new System.Drawing.Point(1, 85);
            this.btnStokEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStokEkle.Name = "btnStokEkle";
            this.btnStokEkle.Size = new System.Drawing.Size(122, 23);
            this.btnStokEkle.TabIndex = 6;
            this.btnStokEkle.Text = "Stok Ekle";
            this.btnStokEkle.Click += new System.EventHandler(this.btnStokEkle_Click);
            // 
            // gcStokButonlari
            // 
            this.gcStokButonlari.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcStokButonlari.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcStokButonlari.Location = new System.Drawing.Point(129, 85);
            this.gcStokButonlari.MainView = this.gvStokButonlari;
            this.gcStokButonlari.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gcStokButonlari.Name = "gcStokButonlari";
            this.gcStokButonlari.Size = new System.Drawing.Size(633, 528);
            this.gcStokButonlari.TabIndex = 5;
            this.gcStokButonlari.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvStokButonlari});
            // 
            // gvStokButonlari
            // 
            this.gvStokButonlari.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTeraziStokGrupID,
            this.colStokID,
            this.colTeraziStokGrupTanimID,
            this.colSiraNu,
            this.colStokAdi,
            this.colTeraziKisayolTusu,
            this.colAktif});
            this.gvStokButonlari.GridControl = this.gcStokButonlari;
            this.gvStokButonlari.Name = "gvStokButonlari";
            this.gvStokButonlari.OptionsView.ShowGroupPanel = false;
            this.gvStokButonlari.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gvStokButonlari_ShowingEditor);
            this.gvStokButonlari.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvStokButonlari_FocusedRowChanged);
            this.gvStokButonlari.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvStokButonlari_CellValueChanged);
            this.gvStokButonlari.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gvStokButonlari_CellValueChanging);
            this.gvStokButonlari.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gvStokButonlari_ValidatingEditor);
            // 
            // colTeraziStokGrupID
            // 
            this.colTeraziStokGrupID.Caption = "TeraziStokGrupID";
            this.colTeraziStokGrupID.FieldName = "TeraziStokGrupID";
            this.colTeraziStokGrupID.Name = "colTeraziStokGrupID";
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            // 
            // colTeraziStokGrupTanimID
            // 
            this.colTeraziStokGrupTanimID.Caption = "TeraziStokGrupTanimID";
            this.colTeraziStokGrupTanimID.FieldName = "TeraziStokGrupTanimID";
            this.colTeraziStokGrupTanimID.Name = "colTeraziStokGrupTanimID";
            // 
            // colSiraNu
            // 
            this.colSiraNu.Caption = "SiraNu";
            this.colSiraNu.FieldName = "SiraNu";
            this.colSiraNu.Name = "colSiraNu";
            this.colSiraNu.Visible = true;
            this.colSiraNu.VisibleIndex = 0;
            this.colSiraNu.Width = 153;
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
            this.colStokAdi.Width = 153;
            // 
            // colTeraziKisayolTusu
            // 
            this.colTeraziKisayolTusu.Caption = "TeraziKisayolTusu";
            this.colTeraziKisayolTusu.FieldName = "TeraziKisayolTusu";
            this.colTeraziKisayolTusu.Name = "colTeraziKisayolTusu";
            this.colTeraziKisayolTusu.Visible = true;
            this.colTeraziKisayolTusu.VisibleIndex = 2;
            this.colTeraziKisayolTusu.Width = 240;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 16);
            this.labelControl1.TabIndex = 8;
            this.labelControl1.Text = "Stok Grup Adi :";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(334, 12);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(120, 16);
            this.labelControl2.TabIndex = 9;
            this.labelControl2.Text = "Stok Grup Açıklama :";
            // 
            // lblStokGrupAdi
            // 
            this.lblStokGrupAdi.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblStokGrupAdi.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStokGrupAdi.Location = new System.Drawing.Point(114, 12);
            this.lblStokGrupAdi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStokGrupAdi.Name = "lblStokGrupAdi";
            this.lblStokGrupAdi.Size = new System.Drawing.Size(212, 66);
            this.lblStokGrupAdi.TabIndex = 10;
            this.lblStokGrupAdi.Text = "lblStokGrupAdi";
            // 
            // lblStokGrupAciklama
            // 
            this.lblStokGrupAciklama.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblStokGrupAciklama.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStokGrupAciklama.Location = new System.Drawing.Point(460, 12);
            this.lblStokGrupAciklama.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lblStokGrupAciklama.Name = "lblStokGrupAciklama";
            this.lblStokGrupAciklama.Size = new System.Drawing.Size(302, 66);
            this.lblStokGrupAciklama.TabIndex = 11;
            this.lblStokGrupAciklama.Text = "lblStokGrupAciklama";
            // 
            // btnKaydet
            // 
            this.btnKaydet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnKaydet.Location = new System.Drawing.Point(129, 619);
            this.btnKaydet.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(185, 23);
            this.btnKaydet.TabIndex = 12;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnVazgec
            // 
            this.btnVazgec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVazgec.Location = new System.Drawing.Point(377, 619);
            this.btnVazgec.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(185, 23);
            this.btnVazgec.TabIndex = 12;
            this.btnVazgec.Text = "Vazgeç";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(0, 308);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(122, 28);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // colAktif
            // 
            this.colAktif.Caption = "Aktif";
            this.colAktif.FieldName = "Aktif";
            this.colAktif.Name = "colAktif";
            this.colAktif.Visible = true;
            this.colAktif.VisibleIndex = 3;
            this.colAktif.Width = 69;
            // 
            // frmTeraziStokGruplarininStokButonlari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 650);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnVazgec);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.lblStokGrupAciklama);
            this.Controls.Add(this.lblStokGrupAdi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnStokCikar);
            this.Controls.Add(this.btnStokEkle);
            this.Controls.Add(this.gcStokButonlari);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTeraziStokGruplarininStokButonlari";
            this.Text = "frmTeraziStokGruplarininStokButonlari";
            this.Load += new System.EventHandler(this.frmTeraziStokGruplarininStokButonlari_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcStokButonlari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvStokButonlari)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnStokCikar;
        private DevExpress.XtraEditors.SimpleButton btnStokEkle;
        private DevExpress.XtraGrid.GridControl gcStokButonlari;
        private DevExpress.XtraGrid.Views.Grid.GridView gvStokButonlari;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        public DevExpress.XtraEditors.LabelControl lblStokGrupAdi;
        public DevExpress.XtraEditors.LabelControl lblStokGrupAciklama;
        private DevExpress.XtraGrid.Columns.GridColumn colTeraziStokGrupID;
        private DevExpress.XtraGrid.Columns.GridColumn colStokID;
        private DevExpress.XtraGrid.Columns.GridColumn colTeraziStokGrupTanimID;
        private DevExpress.XtraGrid.Columns.GridColumn colSiraNu;
        private DevExpress.XtraGrid.Columns.GridColumn colStokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colTeraziKisayolTusu;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraGrid.Columns.GridColumn colAktif;
    }
}