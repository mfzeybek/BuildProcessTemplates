namespace Aresv2.Siparis
{
    partial class frmSiparisHazirlama
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
            this.components = new System.ComponentModel.Container();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.dropDownButton1 = new DevExpress.XtraEditors.DropDownButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem_KolonIslemleri = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem_KolonIslemleri = new DevExpress.XtraBars.BarSubItem();
            this.barButtonItemYerlesimiKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.barBtnExceleAktar = new DevExpress.XtraBars.BarButtonItem();
            this.btnXmlOlustur = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.btnHemenAlUrunleriGetir = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem_HepsiniSec = new DevExpress.XtraBars.BarButtonItem();
            this.btnYazdir = new DevExpress.XtraBars.BarButtonItem();
            this.btnOnizle = new DevExpress.XtraBars.BarButtonItem();
            this.btnFormSecerekYazdir = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu_yazdirma = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_yazdirma)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(610, 535);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(164, 68);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "Siparişe Aktar";
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(245, 535);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(179, 68);
            this.simpleButton2.TabIndex = 1;
            this.simpleButton2.Text = "Stok Çıkar";
            // 
            // dropDownButton1
            // 
            this.dropDownButton1.DropDownArrowStyle = DevExpress.XtraEditors.DropDownArrowStyle.Show;
            this.dropDownButton1.DropDownControl = this.popupMenu_yazdirma;
            this.dropDownButton1.Location = new System.Drawing.Point(799, 535);
            this.dropDownButton1.Name = "dropDownButton1";
            this.dropDownButton1.Size = new System.Drawing.Size(156, 68);
            this.dropDownButton1.TabIndex = 2;
            this.dropDownButton1.Text = "Yazdır";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(32, 535);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(179, 68);
            this.simpleButton3.TabIndex = 1;
            this.simpleButton3.Text = "Stok Ekle";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(32, 12);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(995, 517);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "StokAdi";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            this.gridColumn1.Width = 136;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "MevcutMiktar";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 136;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Sipariş Miktarı";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 115;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Minimum Miktar";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 5;
            this.gridColumn4.Width = 142;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Olması Gereken Miktar";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 6;
            this.gridColumn5.Width = 142;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Minimum Sipariş Miktarı";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            this.gridColumn6.Width = 148;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Stok Kodu";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            this.gridColumn7.Width = 95;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Stok ID";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 63;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem_KolonIslemleri,
            this.barSubItem_KolonIslemleri,
            this.barButtonItemYerlesimiKaydet,
            this.barBtnExceleAktar,
            this.btnXmlOlustur,
            this.barSubItem1,
            this.btnHemenAlUrunleriGetir,
            this.barButtonItem2,
            this.barButtonItem_HepsiniSec,
            this.btnYazdir,
            this.btnOnizle,
            this.btnFormSecerekYazdir});
            this.barManager1.MaxItemId = 18;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(1039, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 627);
            this.barDockControlBottom.Size = new System.Drawing.Size(1039, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 627);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1039, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 627);
            // 
            // barButtonItem_KolonIslemleri
            // 
            this.barButtonItem_KolonIslemleri.Id = 3;
            this.barButtonItem_KolonIslemleri.Name = "barButtonItem_KolonIslemleri";
            // 
            // barSubItem_KolonIslemleri
            // 
            this.barSubItem_KolonIslemleri.Caption = "KolonIslemleri";
            this.barSubItem_KolonIslemleri.Id = 1;
            this.barSubItem_KolonIslemleri.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItemYerlesimiKaydet)});
            this.barSubItem_KolonIslemleri.Name = "barSubItem_KolonIslemleri";
            // 
            // barButtonItemYerlesimiKaydet
            // 
            this.barButtonItemYerlesimiKaydet.Caption = "Yerleşimi Kaydet";
            this.barButtonItemYerlesimiKaydet.Id = 2;
            this.barButtonItemYerlesimiKaydet.Name = "barButtonItemYerlesimiKaydet";
            // 
            // barBtnExceleAktar
            // 
            this.barBtnExceleAktar.Caption = "Excel e aktar";
            this.barBtnExceleAktar.Id = 4;
            this.barBtnExceleAktar.Name = "barBtnExceleAktar";
            // 
            // btnXmlOlustur
            // 
            this.btnXmlOlustur.Caption = "Xml Oluştur (HemenAl.com)";
            this.btnXmlOlustur.Id = 10;
            this.btnXmlOlustur.Name = "btnXmlOlustur";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "HemenAl Entegrasyonu";
            this.barSubItem1.Id = 11;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnHemenAlUrunleriGetir)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // btnHemenAlUrunleriGetir
            // 
            this.btnHemenAlUrunleriGetir.Caption = "Ürünleri Getir";
            this.btnHemenAlUrunleriGetir.Id = 12;
            this.btnHemenAlUrunleriGetir.Name = "btnHemenAlUrunleriGetir";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Listelenen Ürünleri Top Güncelle";
            this.barButtonItem2.Id = 13;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem_HepsiniSec
            // 
            this.barButtonItem_HepsiniSec.Caption = "Hepsini Seç";
            this.barButtonItem_HepsiniSec.Id = 14;
            this.barButtonItem_HepsiniSec.Name = "barButtonItem_HepsiniSec";
            // 
            // btnYazdir
            // 
            this.btnYazdir.Caption = "Yazdır";
            this.btnYazdir.Id = 15;
            this.btnYazdir.Name = "btnYazdir";
            this.btnYazdir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnYazdir_ItemClick);
            // 
            // btnOnizle
            // 
            this.btnOnizle.Caption = "Önizle";
            this.btnOnizle.Id = 16;
            this.btnOnizle.Name = "btnOnizle";
            // 
            // btnFormSecerekYazdir
            // 
            this.btnFormSecerekYazdir.Caption = "Form Seçerek Yazdır";
            this.btnFormSecerekYazdir.Id = 17;
            this.btnFormSecerekYazdir.Name = "btnFormSecerekYazdir";
            this.btnFormSecerekYazdir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnFormSecerekYazdir_ItemClick);
            // 
            // popupMenu_yazdirma
            // 
            this.popupMenu_yazdirma.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnYazdir),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnOnizle),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnFormSecerekYazdir)});
            this.popupMenu_yazdirma.Manager = this.barManager1;
            this.popupMenu_yazdirma.Name = "popupMenu_yazdirma";
            // 
            // frmSiparisHazirlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 627);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.dropDownButton1);
            this.Controls.Add(this.simpleButton3);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "frmSiparisHazirlama";
            this.Text = "frmSiparisHazirlama";
            this.Load += new System.EventHandler(this.frmSiparisHazirlama_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu_yazdirma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.DropDownButton dropDownButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_KolonIslemleri;
        private DevExpress.XtraBars.BarSubItem barSubItem_KolonIslemleri;
        private DevExpress.XtraBars.BarButtonItem barButtonItemYerlesimiKaydet;
        private DevExpress.XtraBars.BarButtonItem barBtnExceleAktar;
        private DevExpress.XtraBars.BarButtonItem btnXmlOlustur;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarButtonItem btnHemenAlUrunleriGetir;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem_HepsiniSec;
        private DevExpress.XtraBars.BarButtonItem btnYazdir;
        private DevExpress.XtraBars.BarButtonItem btnOnizle;
        private DevExpress.XtraBars.BarButtonItem btnFormSecerekYazdir;
        private DevExpress.XtraBars.PopupMenu popupMenu_yazdirma;
    }
}