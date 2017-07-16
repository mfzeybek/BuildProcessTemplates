namespace clsTablolar.TeraziSatisClaslari
{
    partial class frmSiparisListesi
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
            this.gcSiparis = new DevExpress.XtraGrid.GridControl();
            this.gvSiparis = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCariTanim = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisTutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTeslimTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPersonelAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisDurumTanimAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnSiparisiAc = new DevExpress.XtraEditors.SimpleButton();
            this.checkedListBoxControl1 = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.btnKapat = new DevExpress.XtraEditors.SimpleButton();
            this.gcSiparisDetayi = new DevExpress.XtraGrid.GridControl();
            this.gvSiparisDetayi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSatirNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSiparisHareketStokAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirim2Fiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colToplam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokIskonto1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokIskonto1Tutari = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStokIskonto1SonrasiTutar = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKdvDahilToplam = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAltBirimKdvDahilFiyat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gcSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiparis)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSiparisDetayi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiparisDetayi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gcSiparis
            // 
            this.gcSiparis.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSiparis.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcSiparis.Location = new System.Drawing.Point(9, 10);
            this.gcSiparis.MainView = this.gvSiparis;
            this.gcSiparis.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcSiparis.Name = "gcSiparis";
            this.gcSiparis.Size = new System.Drawing.Size(711, 281);
            this.gcSiparis.TabIndex = 0;
            this.gcSiparis.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSiparis});
            // 
            // gvSiparis
            // 
            this.gvSiparis.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 15F);
            this.gvSiparis.Appearance.Row.Options.UseFont = true;
            this.gvSiparis.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCariTanim,
            this.colSiparisTarihi,
            this.colSiparisTutari,
            this.colSiparisID,
            this.colTeslimTarihi,
            this.colPersonelAdi,
            this.colSiparisDurumTanimAdi});
            this.gvSiparis.GridControl = this.gcSiparis;
            this.gvSiparis.Name = "gvSiparis";
            this.gvSiparis.OptionsBehavior.Editable = false;
            this.gvSiparis.OptionsBehavior.ReadOnly = true;
            this.gvSiparis.OptionsCustomization.AllowColumnMoving = false;
            this.gvSiparis.OptionsCustomization.AllowColumnResizing = false;
            this.gvSiparis.OptionsCustomization.AllowFilter = false;
            this.gvSiparis.OptionsCustomization.AllowGroup = false;
            this.gvSiparis.OptionsCustomization.AllowQuickHideColumns = false;
            this.gvSiparis.OptionsCustomization.AllowRowSizing = true;
            this.gvSiparis.OptionsCustomization.AllowSort = false;
            this.gvSiparis.OptionsView.ShowGroupPanel = false;
            this.gvSiparis.RowHeight = 45;
            this.gvSiparis.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colTeslimTarihi, DevExpress.Data.ColumnSortOrder.Descending)});
            this.gvSiparis.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gvSiparis_FocusedRowChanged);
            // 
            // colCariTanim
            // 
            this.colCariTanim.Caption = "CariTanim";
            this.colCariTanim.FieldName = "CariTanim";
            this.colCariTanim.Name = "colCariTanim";
            this.colCariTanim.Visible = true;
            this.colCariTanim.VisibleIndex = 0;
            // 
            // colSiparisTarihi
            // 
            this.colSiparisTarihi.Caption = "SiparisTarihi";
            this.colSiparisTarihi.FieldName = "SiparisTarihi";
            this.colSiparisTarihi.Name = "colSiparisTarihi";
            this.colSiparisTarihi.Visible = true;
            this.colSiparisTarihi.VisibleIndex = 1;
            // 
            // colSiparisTutari
            // 
            this.colSiparisTutari.Caption = "SiparisTutari";
            this.colSiparisTutari.FieldName = "SiparisTutari";
            this.colSiparisTutari.Name = "colSiparisTutari";
            this.colSiparisTutari.Visible = true;
            this.colSiparisTutari.VisibleIndex = 2;
            // 
            // colSiparisID
            // 
            this.colSiparisID.Caption = "SiparisID";
            this.colSiparisID.FieldName = "SiparisID";
            this.colSiparisID.Name = "colSiparisID";
            // 
            // colTeslimTarihi
            // 
            this.colTeslimTarihi.Caption = "TeslimTarihi";
            this.colTeslimTarihi.DisplayFormat.FormatString = "d";
            this.colTeslimTarihi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colTeslimTarihi.FieldName = "TeslimTarihi";
            this.colTeslimTarihi.Name = "colTeslimTarihi";
            this.colTeslimTarihi.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True;
            this.colTeslimTarihi.OptionsFilter.AllowFilter = false;
            this.colTeslimTarihi.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.colTeslimTarihi.Visible = true;
            this.colTeslimTarihi.VisibleIndex = 3;
            // 
            // colPersonelAdi
            // 
            this.colPersonelAdi.Caption = "PersonelAdi";
            this.colPersonelAdi.FieldName = "PersonelAdi";
            this.colPersonelAdi.Name = "colPersonelAdi";
            this.colPersonelAdi.Visible = true;
            this.colPersonelAdi.VisibleIndex = 4;
            // 
            // colSiparisDurumTanimAdi
            // 
            this.colSiparisDurumTanimAdi.Caption = "Durmu";
            this.colSiparisDurumTanimAdi.FieldName = "SiparisDurumTanimAdi";
            this.colSiparisDurumTanimAdi.Name = "colSiparisDurumTanimAdi";
            this.colSiparisDurumTanimAdi.Visible = true;
            this.colSiparisDurumTanimAdi.VisibleIndex = 5;
            // 
            // btnSiparisiAc
            // 
            this.btnSiparisiAc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSiparisiAc.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.btnSiparisiAc.Appearance.Options.UseFont = true;
            this.btnSiparisiAc.Location = new System.Drawing.Point(11, 673);
            this.btnSiparisiAc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSiparisiAc.Name = "btnSiparisiAc";
            this.btnSiparisiAc.Size = new System.Drawing.Size(140, 51);
            this.btnSiparisiAc.TabIndex = 1;
            this.btnSiparisiAc.Text = "Siparişi Aç";
            this.btnSiparisiAc.Click += new System.EventHandler(this.btnSiparisiAc_Click);
            // 
            // checkedListBoxControl1
            // 
            this.checkedListBoxControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.checkedListBoxControl1.Appearance.Options.UseFont = true;
            this.checkedListBoxControl1.CheckOnClick = true;
            this.checkedListBoxControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.checkedListBoxControl1.Location = new System.Drawing.Point(727, 11);
            this.checkedListBoxControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkedListBoxControl1.Name = "checkedListBoxControl1";
            this.checkedListBoxControl1.Size = new System.Drawing.Size(268, 280);
            this.checkedListBoxControl1.TabIndex = 2;
            this.checkedListBoxControl1.ItemCheck += new DevExpress.XtraEditors.Controls.ItemCheckEventHandler(this.checkedListBoxControl1_ItemCheck);
            // 
            // btnKapat
            // 
            this.btnKapat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnKapat.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold);
            this.btnKapat.Appearance.Options.UseFont = true;
            this.btnKapat.Location = new System.Drawing.Point(855, 673);
            this.btnKapat.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(140, 51);
            this.btnKapat.TabIndex = 3;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.Click += new System.EventHandler(this.btnKapat_Click);
            // 
            // gcSiparisDetayi
            // 
            this.gcSiparisDetayi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gcSiparisDetayi.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcSiparisDetayi.Location = new System.Drawing.Point(9, 295);
            this.gcSiparisDetayi.MainView = this.gvSiparisDetayi;
            this.gcSiparisDetayi.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gcSiparisDetayi.Name = "gcSiparisDetayi";
            this.gcSiparisDetayi.Size = new System.Drawing.Size(711, 363);
            this.gcSiparisDetayi.TabIndex = 4;
            this.gcSiparisDetayi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSiparisDetayi});
            // 
            // gvSiparisDetayi
            // 
            this.gvSiparisDetayi.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 15F);
            this.gvSiparisDetayi.Appearance.Row.Options.UseFont = true;
            this.gvSiparisDetayi.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSatirNo,
            this.colStokID,
            this.colSiparisHareketStokAdi,
            this.colBirim2Fiyat,
            this.colToplam,
            this.colStokIskonto1,
            this.colStokIskonto1Tutari,
            this.colStokIskonto1SonrasiTutar,
            this.colKdvDahilToplam,
            this.colAltBirimKdvDahilFiyat});
            this.gvSiparisDetayi.GridControl = this.gcSiparisDetayi;
            this.gvSiparisDetayi.Name = "gvSiparisDetayi";
            this.gvSiparisDetayi.OptionsBehavior.Editable = false;
            this.gvSiparisDetayi.OptionsBehavior.ReadOnly = true;
            this.gvSiparisDetayi.OptionsView.ShowGroupPanel = false;
            // 
            // colSatirNo
            // 
            this.colSatirNo.Caption = "SatirNo";
            this.colSatirNo.FieldName = "SatirNo";
            this.colSatirNo.Name = "colSatirNo";
            this.colSatirNo.Visible = true;
            this.colSatirNo.VisibleIndex = 0;
            this.colSatirNo.Width = 85;
            // 
            // colStokID
            // 
            this.colStokID.Caption = "StokID";
            this.colStokID.FieldName = "StokID";
            this.colStokID.Name = "colStokID";
            // 
            // colSiparisHareketStokAdi
            // 
            this.colSiparisHareketStokAdi.Caption = "SiparisHareketStokAdi";
            this.colSiparisHareketStokAdi.FieldName = "SiparisHareketStokAdi";
            this.colSiparisHareketStokAdi.Name = "colSiparisHareketStokAdi";
            this.colSiparisHareketStokAdi.Visible = true;
            this.colSiparisHareketStokAdi.VisibleIndex = 1;
            this.colSiparisHareketStokAdi.Width = 415;
            // 
            // colBirim2Fiyat
            // 
            this.colBirim2Fiyat.Caption = "Birim2Fiyat";
            this.colBirim2Fiyat.FieldName = "Birim2Fiyat";
            this.colBirim2Fiyat.Name = "colBirim2Fiyat";
            // 
            // colToplam
            // 
            this.colToplam.Caption = "Toplam";
            this.colToplam.FieldName = "Toplam";
            this.colToplam.Name = "colToplam";
            // 
            // colStokIskonto1
            // 
            this.colStokIskonto1.Caption = "StokIskonto1";
            this.colStokIskonto1.DisplayFormat.FormatString = "f1";
            this.colStokIskonto1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colStokIskonto1.FieldName = "StokIskonto1";
            this.colStokIskonto1.Name = "colStokIskonto1";
            this.colStokIskonto1.Visible = true;
            this.colStokIskonto1.VisibleIndex = 4;
            this.colStokIskonto1.Width = 155;
            // 
            // colStokIskonto1Tutari
            // 
            this.colStokIskonto1Tutari.Caption = "StokIskonto1Tutari";
            this.colStokIskonto1Tutari.FieldName = "StokIskonto1Tutari";
            this.colStokIskonto1Tutari.Name = "colStokIskonto1Tutari";
            // 
            // colStokIskonto1SonrasiTutar
            // 
            this.colStokIskonto1SonrasiTutar.Caption = "StokIskonto1SonrasiTutar";
            this.colStokIskonto1SonrasiTutar.FieldName = "StokIskonto1SonrasiTutar";
            this.colStokIskonto1SonrasiTutar.Name = "colStokIskonto1SonrasiTutar";
            // 
            // colKdvDahilToplam
            // 
            this.colKdvDahilToplam.Caption = "KdvDahilToplam";
            this.colKdvDahilToplam.DisplayFormat.FormatString = "c2";
            this.colKdvDahilToplam.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colKdvDahilToplam.FieldName = "KdvDahilToplam";
            this.colKdvDahilToplam.Name = "colKdvDahilToplam";
            this.colKdvDahilToplam.Visible = true;
            this.colKdvDahilToplam.VisibleIndex = 3;
            this.colKdvDahilToplam.Width = 149;
            // 
            // colAltBirimKdvDahilFiyat
            // 
            this.colAltBirimKdvDahilFiyat.Caption = "AltBirimKdvDahilFiyat";
            this.colAltBirimKdvDahilFiyat.DisplayFormat.FormatString = "c2";
            this.colAltBirimKdvDahilFiyat.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAltBirimKdvDahilFiyat.FieldName = "AltBirimKdvDahilFiyat";
            this.colAltBirimKdvDahilFiyat.Name = "colAltBirimKdvDahilFiyat";
            this.colAltBirimKdvDahilFiyat.Visible = true;
            this.colAltBirimKdvDahilFiyat.VisibleIndex = 2;
            this.colAltBirimKdvDahilFiyat.Width = 149;
            // 
            // radioGroup1
            // 
            this.radioGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioGroup1.EditValue = ((short)(-1));
            this.radioGroup1.Location = new System.Drawing.Point(727, 306);
            this.radioGroup1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.radioGroup1.Properties.Appearance.Options.UseFont = true;
            this.radioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(-1)), "Ahanda"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(1)), "Satışa Aktarılmadı"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(((short)(4)), "Satışa Aktarıldı")});
            this.radioGroup1.Size = new System.Drawing.Size(268, 149);
            this.radioGroup1.TabIndex = 7;
            this.radioGroup1.EditValueChanged += new System.EventHandler(this.radioGroup1_EditValueChanged);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Location = new System.Drawing.Point(765, 546);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(176, 50);
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Çok da şey etme.";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click_1);
            // 
            // frmSiparisListesi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 735);
            this.ControlBox = false;
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.radioGroup1);
            this.Controls.Add(this.btnKapat);
            this.Controls.Add(this.checkedListBoxControl1);
            this.Controls.Add(this.btnSiparisiAc);
            this.Controls.Add(this.gcSiparis);
            this.Controls.Add(this.gcSiparisDetayi);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmSiparisListesi";
            this.Text = "frmSiparisListesi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSiparisListesi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gcSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiparis)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkedListBoxControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSiparisDetayi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSiparisDetayi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSiparis;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSiparis;
        private DevExpress.XtraEditors.SimpleButton btnSiparisiAc;
        private DevExpress.XtraEditors.CheckedListBoxControl checkedListBoxControl1;
        private DevExpress.XtraEditors.SimpleButton btnKapat;
        private DevExpress.XtraGrid.Columns.GridColumn colCariTanim;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisTutari;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisID;
        private DevExpress.XtraGrid.Columns.GridColumn colTeslimTarihi;
        private DevExpress.XtraGrid.GridControl gcSiparisDetayi;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSiparisDetayi;
        private DevExpress.XtraGrid.Columns.GridColumn colSatirNo;
        private DevExpress.XtraGrid.Columns.GridColumn colStokID;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisHareketStokAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colBirim2Fiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colToplam;
        private DevExpress.XtraGrid.Columns.GridColumn colStokIskonto1;
        private DevExpress.XtraGrid.Columns.GridColumn colStokIskonto1Tutari;
        private DevExpress.XtraGrid.Columns.GridColumn colStokIskonto1SonrasiTutar;
        private DevExpress.XtraGrid.Columns.GridColumn colKdvDahilToplam;
        private DevExpress.XtraGrid.Columns.GridColumn colAltBirimKdvDahilFiyat;
        private DevExpress.XtraGrid.Columns.GridColumn colPersonelAdi;
        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private DevExpress.XtraGrid.Columns.GridColumn colSiparisDurumTanimAdi;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}