using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Aresv2.Cek
{
    public partial class frmCekKarti : DevExpress.XtraEditors.XtraForm
    {
        public frmCekKarti(int CekHrID)
        {
            _CekHrID = CekHrID;
            InitializeComponent();
        }

        public frmCekKarti(clsTablolar.Cek.csCekHr.CekTipi CekTipi)
        {
            _CekTipi = CekTipi;
            InitializeComponent();
        }
        int _CekHrID = -1;
        clsTablolar.Cek.csCekHr.CekTipi _CekTipi;

        SqlTransaction TrGenel;
        clsTablolar.Cek.csCekHr Hareket;
        clsTablolar.cari.CariHr.csCariHr CariHr = new clsTablolar.cari.CariHr.csCariHr();
        clsTablolar.cari.csCariBasit CariGetir;

        private void frmCekKarti_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Hareket = new clsTablolar.Cek.csCekHr(SqlConnections.GetBaglanti(), TrGenel, _CekHrID);
                CariListeden(Hareket.CariID);
                BilgileriAl();
                Kaydet_Vazgec_sil(false);
                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        private void CariHareketeKaydet()
        {
            CariHr.Aciklama = "Çek";
            CariHr.Devirmi = false;
            CariHr.SilindiMi = Hareket.SilindiMi;
            CariHr.Tarih = Hareket.Tarih;
            CariHr.EvrakNo = Hareket.EvrakNo;
            CariHr.Entegrasyon = (clsTablolar.cari.CariHr.CariHrEntegrasyon)(Hareket.EvrakTipi);
            if (CariHr.Entegrasyon == clsTablolar.cari.CariHr.CariHrEntegrasyon.AlinanCek)
                CariHr.AlacakMiBorcMu = clsTablolar.cari.CariHr.HareketYonu.Alacak;
            else if (CariHr.Entegrasyon == clsTablolar.cari.CariHr.CariHrEntegrasyon.VerilenCek)
                CariHr.AlacakMiBorcMu = clsTablolar.cari.CariHr.HareketYonu.Borc;

            CariHr.EntegrasyonID = Hareket.CekHrID;
            CariHr.CariID = Hareket.CariID;
            CariHr.Tutar = Hareket.Tutari;
            CariHr._FaturaID = -1;

            CariHr.CariHrKaydet(SqlConnections.GetBaglanti(), TrGenel, (clsTablolar.cari.CariHr.CariHrEntegrasyon)Hareket.EvrakTipi, Hareket.CekHrID);
        }

        //Cari Listedeki delegeye gönderiyorum
        void CariListeden(int CariID)
        {
            CariGetir = new clsTablolar.cari.csCariBasit(SqlConnections.GetBaglanti(), TrGenel, CariID);
            lblCariKodu.Text = CariGetir.CariKod;
            lblCariTanim.Text = CariGetir.CariTanim;
            Kaydet_Vazgec_sil(true);
        }

        void BilgileriAl()
        {
            txtBankasi.Text = Hareket.EvrakBankasi;
            txtSubesi.Text = Hareket.EvrakSubesi;
            txtHesapNo.Text = Hareket.EvrakHesapNo;
            txtKesideYeri.Text = Hareket.KesideYeri;

            txtCekNo.Text = Hareket.EvrakNo;
            txtTutari.EditValue = Hareket.Tutari;
            deCekTarihi.DateTime = Hareket.EvrakTarihi;
            deTarih.DateTime = Hareket.Tarih;
            if (_CekTipi == 0)
            {
                _CekTipi = Hareket.EvrakTipi;
            }
            if (_CekTipi == clsTablolar.Cek.csCekHr.CekTipi.AlinanCek)
                lblCekTipi.Text = "Alınan Çek";
            else if (_CekTipi == clsTablolar.Cek.csCekHr.CekTipi.VerilenCek)
                lblCekTipi.Text = "Verilen Çek";
        }
        void BilgileriVer()
        {
            Hareket.EvrakBankasi = txtBankasi.Text;
            Hareket.EvrakSubesi = txtSubesi.Text;
            Hareket.EvrakHesapNo = txtHesapNo.Text;
            Hareket.KesideYeri = txtKesideYeri.Text;

            Hareket.EvrakNo = txtCekNo.Text;
            Hareket.Tutari = Convert.ToDecimal(txtTutari.EditValue);
            Hareket.EvrakTarihi = deCekTarihi.DateTime;
            Hareket.Tarih = deTarih.DateTime;

            Hareket.CariID = CariGetir.CariID;
            Hareket.EvrakTipi = _CekTipi;
        }

        void Kaydet_Vazgec_sil(bool true_false)
        {
            btnKaydet.Enabled = true_false;
            btnVazgec.Enabled = true_false;
            btnSil.Enabled = !true_false;
        }

        private void btnCariBul_Click(object sender, EventArgs e)
        {
            using (frmCariListe CariArama = new frmCariListe())
            {
                CariArama._CariIDVer = CariListeden;
                CariArama.ShowDialog();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (CariGetir.CariID == -1)
            {
                MessageBox.Show("Cari Seçilmedi");
                return;
            }
            try
            {
                BilgileriVer();
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Hareket.CekKaydet(SqlConnections.GetBaglanti(), TrGenel);
                CariHareketeKaydet();
                Kaydet_Vazgec_sil(false);
                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            BilgileriAl();
            Kaydet_Vazgec_sil(false);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Silinecek eminmisin ??"
                , "Silinecek eminmisin??", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.No)
                return;

            try
            {
                BilgileriVer();
                Hareket.SilindiMi = true;
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Hareket.CekKaydet(SqlConnections.GetBaglanti(), TrGenel);
                CariHareketeKaydet();
                Kaydet_Vazgec_sil(false);
                TrGenel.Commit();
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
            Close();
        }

        private void ButunTextler_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Kaydet_Vazgec_sil(true);
        }
    }
}