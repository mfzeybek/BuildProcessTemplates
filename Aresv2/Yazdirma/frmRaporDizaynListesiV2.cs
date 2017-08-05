using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace Aresv2
{
    public partial class frmRaporDizaynListesiv2 : DevExpress.XtraEditors.XtraForm
    {
        // bu açıklamayı birkaç yere yazmak lazım
        // şimdilik
        // 2 tip yazdırma işlemi var
        // 1 ncisi dataset olarak verileri vererek // budeğişti aslında hepsi değişti şimdi classı veriyorsun
        // 2 ncisi ID vererek
        //



        /// <summary>
        /// Dinamik olarak rapor dizaynlarının hazırlanmasını sağlayan form.
        /// Rapor dizaynları exe nin yanındaki "ReportDesigners" klasörü altında saklanıyor.
        /// Rapor dizayn başlık bilgileri veritabanında "RaporDizayn" tablosunda saklanıyor. 
        /// Yeni bir dizayn yaratıldığında önce klasör içindeki defaultRapor dosyasını yeni isimde aynı klasöre kopyalıyor. sonrada veritabanına yeni satır yazıyor.
        /// </summary>
        /// <param name="ModulNo">Rapor Dizayn larının hangi modüle ait olduklarını tutar. 1:Fatura, 2:Stok, 3:Cari</param>
        /// <param name="Param1">Fatura dizaynı ise CariID gönderilecek. </param>
        /// <param name="Param2">Fatura Dizaynı ise FaturaID gönderilecek. Stok Dizaynı ise StokID gödnerilecek.</param>
        /// 


        public frmRaporDizaynListesiv2(clsTablolar.Yazdirma.csYazdir YazdirClasi, clsTablolar.csRaporDizayn.RaporModul Modul)
        {
            _YazdirClasi = YazdirClasi;
            _Modul = Modul;
            InitializeComponent();
        }

        public frmRaporDizaynListesiv2(int YazdirilacakVerininID, clsTablolar.csRaporDizayn.RaporModul Modul)
        {
            _YazdirilacakVerininID = YazdirilacakVerininID;
            _Modul = Modul;
            InitializeComponent();
        }

        public frmRaporDizaynListesiv2(clsTablolar.csRaporDizayn.RaporModul Modul)
        {
            _Modul = Modul;
            InitializeComponent();
        }
        public string SeciliRaporYolu;

        clsTablolar.Yazdirma.csYazdir _YazdirClasi;
        SqlTransaction TrGenel;
        clsTablolar.csRaporDizayn.RaporModul _Modul;
        int _YazdirilacakVerininID = -1;
        clsTablolar.csRaporDizayn RapolarListesi = new clsTablolar.csRaporDizayn();

        private void frmRaporDizaynListesi_Load(object sender, EventArgs e)
        {
            RapolarListesi.RaporDizaynYukle(SqlConnections.GetBaglanti(), _Modul);
            gcRaporDizayn.DataSource = RapolarListesi.dt_Raporlar;


            //            var query =
            //from tbl1 in RapolarListesi.dt_Raporlar.AsEnumerable()
            //join tbl2 in RapolarListesi.dtYaziciAyarlari.AsEnumerable() on tbl1["RaporDizaynID"] equals tbl2["RaporDizaynID"]
            //select new { RaporDizaynID = tbl1["RaporDizaynID"], RaporDizaynYolu = tbl1["RaporDizaynYolu"], Field2 = tbl2["YaziciAdi"] };

            //gcRaporDizayn.DataSource = query;

            if (!clsTablolar.Ayarlar.csYetkiler.YazdirmaAyarlariDuzenleme)
            {
                btnDuzenle.Visible = false;
                btnEkle.Visible = false;
                btnSil.Visible = false;
                btnYaziciAyarlari.Visible = false;
            }
        }

        private void cbtnYeniDizayn_Click(object sender, EventArgs e)
        {
            _YazdirClasi.Yazdirr(gvRaporDizayn.GetFocusedRowCellValue(colRaporDizaynYolu).ToString(), clsTablolar.Yazdirma.csYazdir.Nasil.dizayn);
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnOnizle_Click(object sender, EventArgs e)
        {
            if (gvRaporDizayn.RowCount == 0) return;
            YaziciAyarlariniGonder();
            _YazdirClasi.Yazdirr(gvRaporDizayn.GetFocusedRowCellValue(colRaporDizaynYolu).ToString(), clsTablolar.Yazdirma.csYazdir.Nasil.Goster);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diyalog = new OpenFileDialog())
            {
                diyalog.Title = "Lütfen Rapor Dizayn Dosyasını Seçiniz";
                diyalog.Filter = " (*.repx)|";
                diyalog.InitialDirectory = @"\ReportDesigners\Fatura\";
                diyalog.ShowDialog();
                RapolarListesi.dt_Raporlar.Rows.Add(RapolarListesi.dt_Raporlar.NewRow());
                gvRaporDizayn.SetRowCellValue(gvRaporDizayn.RowCount - 1, colRaporDizaynYolu, diyalog.FileName);
            }
        }

        private void frmRaporDizaynListesiv2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                gvRaporDizayn.PostEditor();
                this.BindingContext[gcRaporDizayn.DataSource].EndCurrentEdit();
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                RapolarListesi.RaporGuncelle(SqlConnections.GetBaglanti(), TrGenel, _Modul);

                TrGenel.Commit();
            }
            catch (Exception exeee)
            {
                TrGenel.Rollback();
                MessageBox.Show("Bi hata oldu hamısına");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show(gvRaporDizayn.GetFocusedRowCellValue(colAciklama).ToString() + "\nKayıt Silinecek", "", MessageBoxButtons.YesNo))
            {
                gvRaporDizayn.DeleteSelectedRows();
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (gvRaporDizayn.RowCount == 0) return;
            _YazdirClasi.Yazdirr(gvRaporDizayn.GetFocusedRowCellValue(colRaporDizaynYolu).ToString(), clsTablolar.Yazdirma.csYazdir.Nasil.dizayn);
        }

        private void gvRaporDizayn_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void gvRaporDizayn_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column == colVarsayilanMi)
                for (int i = 0; i < gvRaporDizayn.RowCount; i++)
                {
                    if (i != e.RowHandle)
                        gvRaporDizayn.SetRowCellValue(i, colVarsayilanMi, false);
                }
        }

        private void gcRaporDizayn_Click(object sender, EventArgs e)
        {

        }


        void YaziciAyarlariniGonder()
        {
            _YazdirClasi.YaziciAdi = gvRaporDizayn.GetFocusedRowCellValue(colYaziciAdi).ToString();
            if (gvRaporDizayn.GetFocusedRowCellValue(colKagitKaynagiIndex) != DBNull.Value)
                _YazdirClasi.KagitKaynagiIndex = Convert.ToInt32(gvRaporDizayn.GetFocusedRowCellValue(colKagitKaynagiIndex));
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (gvRaporDizayn.RowCount == 0) return;
            Thread yazdirr = new Thread(new ThreadStart(Yazdir));
            yazdirr.Start();
        }
        object lockTaken = new object();
        void Yazdir()
        {
            try
            {
                lock (lockTaken)
                {
                    YaziciAyarlariniGonder();
                    _YazdirClasi.Yazdirr(gvRaporDizayn.GetFocusedRowCellValue(colRaporDizaynYolu).ToString(), clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
                }
            }
            catch (Exception exep)
            {
                MessageBox.Show(exep.Message);
            }

        }

        private void btnYazdirmaDiyalogu_Click(object sender, EventArgs e)
        {
            if (gvRaporDizayn.RowCount == 0) return;
            YaziciAyarlariniGonder();
            _YazdirClasi.Yazdirr(gvRaporDizayn.GetFocusedRowCellValue(colRaporDizaynYolu).ToString(), clsTablolar.Yazdirma.csYazdir.Nasil.YazdirmaDiyalogu);
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {


            SeciliRaporYolu = gvRaporDizayn.GetFocusedRowCellValue(colRaporDizaynYolu).ToString();
            this.DialogResult = DialogResult.Yes;
            Close();
        }

        private void btnYaziciAyarlari_Click(object sender, EventArgs e)
        {
            try
            {
                clsTablolar.Yazdirma.frmYaziciAyarlari fff = new clsTablolar.Yazdirma.frmYaziciAyarlari();
                fff.cmbYaziciAdi.EditValue = gvRaporDizayn.GetFocusedRowCellValue(colYaziciAdi).ToString();
                if (gvRaporDizayn.GetFocusedRowCellValue(colKagitKaynagiIndex) != DBNull.Value)
                    fff.cmbKagitKaynagi.SelectedIndex = Convert.ToInt16(gvRaporDizayn.GetFocusedRowCellValue(colKagitKaynagiIndex));
                if (fff.ShowDialog() == DialogResult.Yes)
                {

                    gvRaporDizayn.SetFocusedRowCellValue(colKagitKaynagi, fff.KagitKaynagiAdi);
                    gvRaporDizayn.SetFocusedRowCellValue(colKagitKaynagiIndex, fff.KagitKaynagiIndex);
                    gvRaporDizayn.SetFocusedRowCellValue(colYaziciAdi, fff.PinterName);

                    gvRaporDizayn.PostEditor();
                }

                //PrintDialog pdialog = new PrintDialog();
                //pdialog.ShowDialog();
                //string SecilenTepsi = pdialog.Document.PrinterSettings.DefaultPageSettings.PaperSource.SourceName;

                //MessageBox.Show(SecilenTepsi);

                //string TepsiAdi = pdialog.PrinterSettings.PaperSources[3].SourceName;

                //MessageBox.Show(TepsiAdi);
                //_YazdirClasi.TepsiSecenekleriniGetir();
                //pdialog.PrinterSettings.PaperSources
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (btnAyarlar.Text == "Ayarlar")
            {
                colVarsayilanMi.Visible = true;
                colAciklama.OptionsColumn.AllowEdit = true;
                btnAyarlar.Text = "Ayarlandı";
                btnEkle.Visible = true;
                btnSil.Visible = true;
                btnDuzenle.Visible = true;
                btnYaziciAyarlari.Visible = true;
            }
            else
            {
                btnAyarlar.Text = "Ayarlar";
                colAciklama.OptionsColumn.AllowEdit = false;
                colVarsayilanMi.Visible = false;
                btnEkle.Visible = false;
                btnSil.Visible = false;
                btnDuzenle.Visible = false;
                btnYaziciAyarlari.Visible = false;
            }
        }
    }
}