using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.Cari.CariHr
{
    public partial class frmCariHrKarti : DevExpress.XtraEditors.XtraForm
    {
        public frmCariHrKarti(int CariHrID)
        {
            _CariHrID = CariHrID;
            InitializeComponent();
        }
        /// <summary>
        /// CariHrID = -1 olarak verebilir sin
        /// </summary>
        /// <param name="CariHrID"></param>
        /// <param name="CariID"></param>
        public frmCariHrKarti(int CariHrID, int CariID)
        {
            _CariID = CariID;
            InitializeComponent();
        }
        public enum VerilenID_Nerenin
        {
            CariKart = clsTablolar.IslemTipi.CariKart,
            Fatura,
            CariHr = clsTablolar.IslemTipi.CariHareket,
            AlisFaturasi = clsTablolar.IslemTipi.AlisFaturasi,
            SatisFaturasi = clsTablolar.IslemTipi.SatisFaturasi
        }
        public frmCariHrKarti(VerilenID_Nerenin Nere, int VerilenID, int CariID) // şimdilik sadece fatura için yaptın
        {
            if (Nere == VerilenID_Nerenin.Fatura)
            {
                _FaturaID = VerilenID;
                _Nere = Nere;
            }
            else
            if (Nere == VerilenID_Nerenin.AlisFaturasi)
            {
                _FaturaID = VerilenID;
                _Nere = Nere;
            }
            else
            if (Nere == VerilenID_Nerenin.SatisFaturasi)
            {
                _FaturaID = VerilenID;
                _Nere = Nere;
            }
            _CariID = CariID;
            InitializeComponent();
            btnFaturaSec.Enabled = false;
            btnFaturaSec.Visible = false;
        }

        VerilenID_Nerenin _Nere;

        int _CariID = -1;
        public int _CariHrID = -1;
        int _FaturaID = -1;
        int _KasaHrID = -1;
        int _KasaID = 2; // TODO: varsayılan daha sonra ayarlardan alıcak

        clsTablolar.cari.CariHr.csCariHr Hareket;
        clsTablolar.cari.csCariv2 Cari;
        clsTablolar.cari.csCariBakiye Bakiye = new clsTablolar.cari.csCariBakiye();
        clsTablolar.Kasa.csKasaHareket KasaHareketi = new clsTablolar.Kasa.csKasaHareket();

        SqlTransaction TrGenel;
        private void frmCariHrKarti_Load(object sender, EventArgs e)
        {
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Hareket = new clsTablolar.cari.CariHr.csCariHr(SqlConnections.GetBaglanti(), TrGenel, _CariHrID);
                Hareket._FaturaID = _FaturaID;

                if (_CariHrID == -1)
                    CariGetirSec(_CariID);
                else
                    CariGetirSec(Hareket.CariID);

                IslemTuru_HareketYonu_Kasa_Doldur();


                Bakiye.BakiyeVer(SqlConnections.GetBaglanti(), TrGenel, _CariID);

                VeriAlVer(GET_SET.get);
                lkpKasa.Properties.DataSource = KasaHareketi.KasaListeGetir(SqlConnections.GetBaglanti(), TrGenel);
                TrGenel.Commit();

                lkpKasa.Properties.ValueMember = "KasaID";
                lkpKasa.Properties.DisplayMember = "KasaAdi";
                lkpKasa.EditValue = _KasaID;
                if (_FaturaID != -1)
                {
                    groupControl3.Visible = true;
                    KapaliFaturaBilgileriniGetir();
                }
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }



        void CariGetirSec(int CariIDD)
        {
            Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), TrGenel, CariIDD);
            _CariID = Cari.CariID;
        }

        void IslemTuru_HareketYonu_Kasa_Doldur()
        {
            clsTablolar.cari.CariHr.csHareketYonu Hareett = new clsTablolar.cari.CariHr.csHareketYonu();
            lkpHareketYonu.Properties.DataSource = Hareett.dt_HareketYonu();

            lkpHareketYonu.Properties.PopulateColumns();
            lkpHareketYonu.Properties.Columns["value"].Visible = false;
            lkpHareketYonu.Properties.DisplayMember = "name";
            lkpHareketYonu.Properties.ValueMember = "value";

            if (_Nere == VerilenID_Nerenin.AlisFaturasi)
            {
                lkpHareketYonu.EditValue = (int)clsTablolar.cari.CariHr.HareketYonu.Borc;
                Hareket.AlacakMiBorcMu = clsTablolar.cari.CariHr.HareketYonu.Borc;
                lkpHareketYonu.Properties.ReadOnly = true;
            }
            else if (_Nere == VerilenID_Nerenin.SatisFaturasi)
            {
                lkpHareketYonu.EditValue = (int)clsTablolar.cari.CariHr.HareketYonu.Alacak;
                Hareket.AlacakMiBorcMu = clsTablolar.cari.CariHr.HareketYonu.Alacak;
                lkpHareketYonu.Properties.ReadOnly = true;
            }
        }

        enum GET_SET { get, set }

        void VeriAlVer(GET_SET alver)
        {
            if (alver == GET_SET.get)
            {
                deTarih.EditValue = Hareket.Tarih;
                lkpHareketYonu.EditValue = Convert.ToInt32(Hareket.AlacakMiBorcMu);
                txtEvrakNo.EditValue = Hareket.EvrakNo.ToString();
                txtTutar.EditValue = Convert.ToDecimal(Hareket.Tutar);
                memoEdit_Aciklama.EditValue = Hareket.Aciklama;
                checkEdit_Devirmi.Checked = Hareket.Devirmi;
                _FaturaID = Hareket._FaturaID;
                _KasaHrID = Hareket.KasaHrID;
                _KasaID = Hareket.KasaID;

                // sadece get
                lblBakiye.Text = Bakiye.Bakiye.ToString();
                lblToplamAlacak.Text = Bakiye.AlacakToplami.ToString();
                lblToplamBorc.Text = Bakiye.BorcToplami.ToString();
                lblBakiyeTuru.Text = Bakiye.BakiyeTuru.ToString();
            }
            else
            {
                Hareket.Tarih = Convert.ToDateTime(deTarih.EditValue);
                Hareket.AlacakMiBorcMu = (clsTablolar.cari.CariHr.HareketYonu)Convert.ToInt32(lkpHareketYonu.EditValue);
                Hareket.EvrakNo = txtEvrakNo.EditValue.ToString();
                Hareket.Tutar = Convert.ToDecimal(txtTutar.EditValue);
                Hareket.Aciklama = memoEdit_Aciklama.EditValue.ToString();
                Hareket.Devirmi = checkEdit_Devirmi.Checked;
                Hareket._FaturaID = _FaturaID;
                Hareket.CariID = Cari.CariID;

                Hareket.KasaHrID = _KasaHrID;
                Hareket.KasaID = _KasaID;

            }
            ButtonEnabled(false);
            lblCariKodu.Text = Cari.CariKod;
            lblCariTanim.Text = Cari.CariTanim;
        }

        private void btnCariKartiAc_Click(object sender, EventArgs e)
        {
            frmCariDetay CariKart = new frmCariDetay(Hareket.CariID);
            CariKart.MdiParent = this.MdiParent;
            CariKart.Show();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (_CariID == -1)
            {
                MessageBox.Show("Cari Seçilmedi");
                return;
            }
            try
            {
                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                VeriAlVer(GET_SET.set);

                if (Hareket.AlacakMiBorcMu == clsTablolar.cari.CariHr.HareketYonu.Alacak)
                    Hareket.KasaHrID = KasaHareketi.HarekeKaydet(SqlConnections.GetBaglanti(), TrGenel, Hareket.KasaHrID, Hareket.KasaID, Hareket.Tutar, 0, "");
                else if (Hareket.AlacakMiBorcMu == clsTablolar.cari.CariHr.HareketYonu.Borc)
                    Hareket.KasaHrID = KasaHareketi.HarekeKaydet(SqlConnections.GetBaglanti(), TrGenel, Hareket.KasaHrID, Hareket.KasaID, 0, Hareket.Tutar, "");



                Hareket.Kaydet(SqlConnections.GetBaglanti(), TrGenel);


                TrGenel.Commit();
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            }
            catch (Exception hata)
            {
                TrGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        /// <summary>
        /// true = kaydet basılabilir
        /// </summary>
        /// <param name="true_false"></param>
        private void ButtonEnabled(bool true_false)
        {
            btnKaydet.Enabled = true_false;
            btnVazgec.Enabled = true_false;
            btnSil.Enabled = !true_false;
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            VeriAlVer(GET_SET.get);
        }

        private void ButunTextler_EditValueChanged(object sender, EventArgs e)
        {
            ButtonEnabled(true);
        }

        private void frmCariHrKarti_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                e.Cancel = true;
                MessageBox.Show("Kayıt Tamamlanmadı");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Kayıt Silinecek Eminmisin??", "Dikkat Hamısına", MessageBoxButtons.YesNo, MessageBoxIcon.None))
            {
                Hareket.SilindiMi = true;
                btnKaydet_Click(null, null);
                this.DialogResult = DialogResult.Yes;
                Close();
            }
        }

        private void btnBakiyeAktar_Click(object sender, EventArgs e)
        {
            if (Bakiye.Bakiye == 0) return;
            txtTutar.EditValue = Bakiye.Bakiye;
            if (Bakiye.BakiyeTuru == clsTablolar.cari.CariHr.HareketYonu.Alacak)
                lkpHareketYonu.EditValue = Convert.ToInt32(clsTablolar.cari.CariHr.HareketYonu.Borc);
            if (Bakiye.BakiyeTuru == clsTablolar.cari.CariHr.HareketYonu.Borc)
                lkpHareketYonu.EditValue = Convert.ToInt32(clsTablolar.cari.CariHr.HareketYonu.Alacak);
        }

        #region Yazdırma işlemleri

        clsTablolar.Yazdirma.csYazdir yazdir;
        clsTablolar.Rapor.csRaporVarsayilanYolu varsayilanyol;
        /// <summary>
        /// bütün butonlardan önce bunu çalıştır sonra istediğin işlemi yap
        /// </summary>
        private void YazdirmakicinVerileriHazirla()
        {
            yazdir = new clsTablolar.Yazdirma.csYazdir();

            yazdir.dt_ekle("Cari Hareket");
            yazdir.DtyaYeniSatirEkle("Cari Hareket");

            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Ticari Adi", Cari.CariTanim, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Cari Kodu", Cari.CariKod, System.Type.GetType("System.String"));
            //yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Adresi", Fatura.Adres, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Vergi Dairesi", Cari.VergiDairesi, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Vergi Numarası", Cari.VergiNumarasi, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Tarihi", Hareket.Tarih, System.Type.GetType("System.DateTime"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "İli", Hareket.AlacakMiBorcMu.ToString(), System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "İlçesi", Hareket.Aciklama, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Evrak No", Hareket.EvrakNo, System.Type.GetType("System.String"));
            //yazdir.dtyaAlanVeVeriEkle("FaturaUstBilgi", "İrsaliye Tarihi", );
            yazdir.dtAlanEkleVeriEkle("Cari Hareket", "Tutar", Hareket.Tutar, System.Type.GetType("System.Decimal"));
            //yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Toplam Iskonto", Fatura.ToplamIndirim, System.Type.GetType("System.Decimal"));
            //yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Iskontolu Toplam", Fatura.IskontoluToplam, System.Type.GetType("System.Decimal"));
            //yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Toplam Kdv", Fatura.ToplamKdv, System.Type.GetType("System.Decimal"));
            //yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Genel Toplam", Fatura.FaturaTutari, System.Type.GetType("System.Decimal"));
            //yazdir.dtAlanEkleVeriEkle("Fatura Ust Bilgi", "Yazı İle", yazdir.yaziyaCevir(Fatura.FaturaTutari), System.Type.GetType("System.String"));



            //yazdir.classtandsyeDtekle("Fatura Alt Bilgi");
            //yazdir.DtyaYeniSatirEkle("Fatura Alt Bilgi");



            //yazdir.ds.Tables[]

            //yazdir.dt_ekle(FaturaHareket.dt_FaturaHareketleri.Copy());
            //yazdir.dt_ekle(Hesaplamalar.dt_kdv.Copy());
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), clsTablolar.csRaporDizayn.RaporModul.CariHareket), clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), clsTablolar.csRaporDizayn.RaporModul.CariHareket), clsTablolar.Yazdirma.csYazdir.Nasil.Goster);
            }
        }

        private void barBtnItemFormSecerekYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(yazdir, clsTablolar.csRaporDizayn.RaporModul.CariHareket);
            frm.ShowDialog();
        }

        #endregion

        #region Kapalı Fatura Bilgileri

        clsTablolar.Fatura.csKapaliFatura KapaliFatura = new clsTablolar.Fatura.csKapaliFatura();


        private void btnFaturaSec_Click(object sender, EventArgs e)
        {
            if (KapaliFatura.dt.Rows.Count != 0) // kapalı faturada 
            {
                return;
            }
            if (Hareket.Entegrasyon != clsTablolar.cari.CariHr.CariHrEntegrasyon.CariKartHareketi) // eğer CARİkart hareketi değilse fatura bağlanamaz
            {// gerçi bu form açıldığına göre bu illaki bir cari kart hareketidir.
                return;
            }
            Fatura.frmFaturaListesi frm = new Fatura.frmFaturaListesi(Fatura.frmFaturaListesi.AcmaYontemi.FaturaArama);
            if (Convert.ToInt32(Cari.CariID) != Convert.ToInt32(-1)) // eğer cari belli ise sadece o cariye ait faturaların ödemesi yapılabilir.
            {
                frm.txtCariKodu.Text = Cari.CariKod;
                frm.txtCariKodu.Enabled = false;
            }
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                // CariHareketten Cari Kart Seçilmemişse (bu aynı zamanda yeni Cari Harekettir)
                if (Cari.CariID == -1)
                {
                    KapaliFatura.dt.Rows.Add(KapaliFatura.dt.NewRow());
                    KapaliFatura.dt.Rows[KapaliFatura.dt.Rows.Count - 1]["FaturaID"] = frm.SeciliFaturaID;
                    KapaliFatura.dt.Rows[KapaliFatura.dt.Rows.Count - 1]["EntegrasyonNu"] = clsTablolar.IslemTipi.CariHareket;
                    //Hareket.CariID
                    CariGetirSec(frm.SeciliFaturaCariID);
                    Bakiye.BakiyeVer(SqlConnections.GetBaglanti(), TrGenel, frm.SeciliFaturaCariID);
                }
                else
                {//ama hareketin ne hareketi olduğuna bağlı
                    KapaliFatura.Getir(SqlConnections.GetBaglanti(), TrGenel, Hareket.EntegrasyonID); //burada önemli olan entegrasyonId FaturaID olması gerekmektedir. sadece cari kart hareketleri fatura hareketine bağlanabilir.

                    KapaliFatura.dt.Rows.Add(KapaliFatura.dt.NewRow());
                    KapaliFatura.dt.Rows[KapaliFatura.dt.Rows.Count - 1]["FaturaID"] = frm.SeciliFaturaID;
                    //clsTablolar.Fatura.
                    KapaliFatura.dt.Rows[KapaliFatura.dt.Rows.Count - 1]["EntegrasyonNu"] = clsTablolar.IslemTipi.CariHareket;


                    // bu kısımları çok karışık oldu aslında
                }

                //KapaliFatura.YeniOdeme(frm.SeciliFaturaID, Hareket.CariID, clsTablolar.IslemTipi.CariHareket);
            }
        }

        void FaturaninBakiyesiniGetir() // eğer carinin bakiyesi yoksa faturaya özel ödeme yapılmamışsa bile fatura bakiyesi gelmesin
                                        // ha gene de o faturaya özel fazladan ödeme yapılabilsin ama hadi bakalım nerde kullanıcaksan
        {
            //KapaliFatura.


        }


        void FaturaID_denFaturaBilgileriniGetir(int FaturaID) // eğer burada cari ID yoksa aynı zamanda cariyi de getirmesi gerekiyor
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            KapaliFatura.Getir(SqlConnections.GetBaglanti(), TrGenel, _FaturaID);
            TrGenel.Commit();

            if (Cari.CariID == -1) // eğer Cari seçilmemişse Cari yi de seçsin biraz yukarda bahsettim sanırım
            {
                //CariGetirSec(KapaliFatura.dt.Rows[0][""]);
            }
        }

        void FaturaninBakiyesiniGetir(int FaturaID)
        {



        }


        void KapaliFaturaBilgileriniGetir()
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            //KapaliFatura.GetirEntegrasyonNumarasindan(SqlConnections.GetBaglanti(), TrGenel, clsTablolar.IslemTipi.CariKart, Hareket.CariHrID);
            lblKalanBakiye.Text = KapaliFatura.FaturaninKalanBakiyesiniGetir(SqlConnections.GetBaglanti(), TrGenel, _FaturaID).ToString();
            //lblFaturaTutari.Text = 
            TrGenel.Commit();
        }

        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtTutar.EditValue = lblKalanBakiye.Text;
        }
    }
}