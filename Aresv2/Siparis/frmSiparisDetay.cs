using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;

namespace Aresv2.Siparis
{
    public partial class frmSiparisDetay : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Yeni Bir Siparis açılıyorsa Siparis Tipi ve Cari ID bildir
        /// </summary>
        /// <param name="SiparisTipi">Siparisnın Tipi:  
        /// Alınan sipariş = 10,
        /// Verilen Sipariş = 11</param>
        /// <param name="CariID">Eğer hangi cariye kesileceği belli ise CariID belli değilse -1 ver</param>
        public frmSiparisDetay(clsTablolar.Siparis.csSiparis.SiparisTip SiparisTipi, int CariID)
        {
            InitializeComponent();
            Siparis = new clsTablolar.Siparis.csSiparis(SqlConnections.GetBaglanti(), trGenel, SiparisTipi, CariID);
            clsTablolar.cari.csCariv2 Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, CariID);
            _SiparisTipi = SiparisTipi;

            deSiparisTarihi.DateTime = DateTime.Now;
            deSiparisVadesi.DateTime = DateTime.Now;
            deDuzenlemeTarihi.DateTime = DateTime.Now;


            if (SiparisTipi == clsTablolar.Siparis.csSiparis.SiparisTip.AlinanSiparis)
            {
                Siparis.DepoID = clsTablolar.Ayarlar.csAyarlar.AlinanSiparisDepoID;
                Siparis.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.AlinanSiparisIcinFiyatTanimID;
            }
            if (SiparisTipi == clsTablolar.Siparis.csSiparis.SiparisTip.VerilenSiparis)
            {
                Siparis.DepoID = clsTablolar.Ayarlar.csAyarlar.VerilenSiparisDepoID;
                Siparis.KullanilanFiyatTanimID = clsTablolar.Ayarlar.csAyarlar.AlisFaturasiFiyatTanimID;
            }
        }
        /// <summary>
        /// Kaydedilmiş bir Siparis ise SiparisID ver
        /// </summary>
        /// <param name="SiparisID"></param>
        public frmSiparisDetay(int SiparisID)
        {
            InitializeComponent();
            Siparis = new clsTablolar.Siparis.csSiparis(SqlConnections.GetBaglanti(), trGenel, SiparisID);
            _SiparisTipi = Siparis.SiparisTipi;
        }

        clsTablolar.Siparis.csSiparis Siparis;
        SqlTransaction trGenel;

        clsTablolar.Siparis.csSiparisHareket SiparisHareket;
        csFiyatTanim FiyatTanimlari = new csFiyatTanim();
        clsTablolar.Stok.csStokunBirimleri StokunBirimleri;
        csDepo Depo;
        csNumaraVer NumaraVer;
        clsTablolar.Siparis.csSiparis.SiparisTip _SiparisTipi;
        clsTablolar.Stok.csStok YeniStok;
        clsTablolar.cari.csCariv2 Cari;
        Stok.frmStokEtiket StokEtiketYazdir;
        clsTablolar.Yazdirma.csYazdir yazdir;
        clsTablolar.Rapor.csRaporVarsayilanYolu varsayilanyol;
        clsTablolar.Siparis.csSiparisGrup SiparisGrup = new clsTablolar.Siparis.csSiparisGrup();
        clsTablolar.EvrakIliski.csEvrakIliski EvrakIliski = new clsTablolar.EvrakIliski.csEvrakIliski();


        clsTablolar.csFatura_Irsaliye_Teklif_Hesapla hesaplama;// = new cs.csFatura_Irsaliye_Teklif_Hesapla();


        /* Numara verme işi bir numara şablonu seçildiğinde artık numara verilmesini engelle eğer numara değiştirilmek istenirse numara listesinden 
         * çıkılacağını belirt */

        #region Cari Bul

        private void btnCariKartAc_Click(object sender, EventArgs e)
        {
            Cari.frmCariDetay CariKart = new Cari.frmCariDetay(Siparis.CariID);
            CariKart.MdiParent = this.MdiParent;
            CariKart.Show();
        }

        private void BtnCariBul_Click(object sender, EventArgs e)
        {
            frmCariListe frmCariListe = new frmCariListe();
            frmCariListe.Text = "Cari Seçim";
            frmCariListe._CariIDVer = CariAktar; // delegeye Cari Bul u atıyoruz.
            frmCariListe.ShowDialog();
        }

        // Datarow dan cari bilgilerini gerekli yerlere koyar
        // Nereden bulur bu cari bilgileri carilisteden, dahası cari listenin içindeki delegeye gönderilir cari listede tamam a tıklanınca bu kodlar çalışır.
        void CariAktar(int CariID)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, CariID);
                Siparis.CariID = CariID;
                txtVergiNo.EditValue = Cari.VergiNumarasi;
                txtVergiDairesi.EditValue = Cari.VergiDairesi;

                memoUnvan.EditValue = Cari.CariTanim;

                //txtIlce.EditValue = CariID["IlceAdi"].ToString();
                //txtIl.EditValue = CariID["SehirAdi"].ToString();

                txtCariKodu.EditValue = Cari.CariKod;

                //this.BindingContext[Siparis].EndCurrentEdit();

                //Siparis.Cari_Isk_Orani_4 = Convert.ToDecimal(row["iskOrani1"]); // Caride iskonto oranı 4 diye bişi yok bu iskonto yu iler de başka bir yerden getireceksin şimdilik 0 olarak bırak Aynı zamanda iskontoların bağlı olduğu bütün textbox ların null değerlerini 0 olacak şekilde ayarla.
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        #endregion
        private void frmSiparisKarti_Load(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = xtraTabControl2.Size.Height; // farklı ekran çözünürlüğü için

            splitContainer1.SplitterDistance = xtraTabControl1.Size.Height;
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();

                DepoDoldur();

                SiparisHareket = new clsTablolar.Siparis.csSiparisHareket(SqlConnections.GetBaglanti(), trGenel, Siparis.SiparisID);

                #region FORM BAŞLIĞI AYARLANIYOR.
                clsTablolar.FormBaslik BaslikAyarla = new clsTablolar.FormBaslik();
                this.Text = BaslikAyarla.FormBaslikDon((int)_SiparisTipi);
                #endregion


                gcSiparisHareket.DataSource = SiparisHareket.dt_SiparisHareketleri;

                hesaplama = new clsTablolar.csFatura_Irsaliye_Teklif_Hesapla(SiparisHareket.dt_SiparisHareketleri, gvSiparisHareket);
                hesaplama.AltToplamlarDegisti = AltToplamlariAl;
                gcIskontoDetaylari.DataSource = hesaplama.dt_IskontoDetay;
                gcKdvDetaylari.DataSource = hesaplama.dt_kdv;

                FiyatTanimlariniDoldur();

                lkpSiparisGrup.Properties.DataSource = SiparisGrup.SiparisGrupGetir(SqlConnections.GetBaglanti(), trGenel);
                lkpSiparisGrup.Properties.DisplayMember = "SiparisGrupAdi";
                lkpSiparisGrup.Properties.ValueMember = "SiparisGrupID";

                trGenel.Commit();
                SatisElemaniDoldur();

                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                EvrakIliski.SiparistenEvrakIliskiGetir(SqlConnections.GetBaglanti(), trGenel, Siparis.SiparisID);
                trGenel.Commit();

                gcEvrakIliski.DataSource = EvrakIliski.dt;

                GridArayuzIslemleri(enGridArayuzIslemleri.Get);

                //if (Siparis.SiparisTipi == clsTablolar.Siparis.csSiparis.SiparisTip.AlinanSiparis)
                //  Text = "Alınan Sipariş";
                //else
                //  Text = "Verilen Sipariş";

                SiparisCsDekiBilgileriAl();
                Kaydet_Vazgec_Sil_Enable(false);
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        void SiparisCsDekiBilgileriVer()
        {
            Siparis.SiparisTarihi = deSiparisTarihi.DateTime;
            Siparis.DuzenlemeTarihi = deDuzenlemeTarihi.DateTime;
            Siparis.Vadesi = deSiparisVadesi.DateTime;
            Siparis.TeslimTarihi = deTeslimTarihi.DateTime;
            Siparis.SiparisNo = txtSiparisNo.EditValue.ToString();
            Siparis.CariTanim = memoUnvan.EditValue.ToString();
            Siparis.CariKod = txtCariKodu.EditValue.ToString();
            Siparis.Adres = memoAdres.EditValue.ToString();
            Siparis.Il = txtIl.EditValue.ToString();
            Siparis.Ilce = txtIlce.EditValue.ToString();
            Siparis.VergiDairesi = txtVergiDairesi.EditValue.ToString();
            Siparis.VergiNo = txtVergiNo.EditValue.ToString();
            Siparis.Aciklama = memoNot.EditValue.ToString();
            Siparis.DepoID = Convert.ToInt32(lkpDepo.EditValue);
            Siparis.KullanilanFiyatTanimID = Convert.ToInt32(lkpKullanilanFiyatTanimi.EditValue);

            #region Alt Toplamlar

            Siparis.Toplam_Iskontosuz_Kdvsiz = Convert.ToDecimal(txtToplam_Iskontosuz_Kdvsiz.EditValue);
            Siparis.ToplamIndirim = Convert.ToDecimal(txtToplamIndirim.EditValue);
            Siparis.IskontoluToplam = Convert.ToDecimal(txtAraToplam.EditValue);
            Siparis.ToplamKdv = Convert.ToDecimal(txtToplamKDV.EditValue);
            Siparis.SiparisTutari = Convert.ToDecimal(txtSiparisTutari.EditValue);

            Siparis.StokIskontoToplami = Convert.ToDecimal(txtStokIskontoToplami.EditValue);
            Siparis.CariIskontoToplami = Convert.ToDecimal(txtCariIskontoToplami.EditValue);

            Siparis.ToplamIndirim = Convert.ToDecimal(txtToplamIskonto.EditValue);
            Siparis.HizliSatistaDegisiklikYapmaIzniVarMi = cEditSiparisTerazidenDegistirilebilsin.Checked;
            Siparis.HizliSatistaGozukecekMi = cEditSiparisTerazideGozuksun.Checked;

            Siparis.SiparisBarkodNu = txtSiparisBarkodu.EditValue.ToString();
            #endregion

        }

        void SiparisCsDekiBilgileriAl()
        {

            deSiparisTarihi.DateTime = Siparis.SiparisTarihi;
            deDuzenlemeTarihi.DateTime = Siparis.DuzenlemeTarihi;
            deSiparisVadesi.DateTime = Siparis.Vadesi;
            deTeslimTarihi.DateTime = Siparis.TeslimTarihi;
            txtSiparisNo.EditValue = Siparis.SiparisNo;
            memoUnvan.EditValue = Siparis.CariTanim;
            txtCariKodu.EditValue = Siparis.CariKod;
            memoAdres.EditValue = Siparis.Adres;
            txtIl.EditValue = Siparis.Il;
            txtIlce.EditValue = Siparis.Ilce;
            txtVergiDairesi.EditValue = Siparis.VergiDairesi;
            txtVergiNo.EditValue = Siparis.VergiNo;
            memoNot.EditValue = Siparis.Aciklama;
            lkpDepo.EditValue = Siparis.DepoID;
            lkpKullanilanFiyatTanimi.EditValue = Siparis.KullanilanFiyatTanimID;

            cEditSiparisTerazidenDegistirilebilsin.Checked = Siparis.HizliSatistaDegisiklikYapmaIzniVarMi;
            cEditSiparisTerazideGozuksun.Checked = Siparis.HizliSatistaGozukecekMi;

            lkpSatisElemani.EditValue = Siparis.SatisElemaniID;

            #region Alt Toplamlar

            txtToplam_Iskontosuz_Kdvsiz.EditValue = Siparis.Toplam_Iskontosuz_Kdvsiz;
            txtToplamIndirim.EditValue = Siparis.ToplamIndirim;
            txtAraToplam.EditValue = Siparis.IskontoluToplam;
            txtToplamKDV.EditValue = Siparis.ToplamKdv;
            txtSiparisTutari.EditValue = Siparis.SiparisTutari;

            txtStokIskontoToplami.EditValue = Siparis.StokIskontoToplami;
            txtCariIskontoToplami.EditValue = Siparis.CariIskontoToplami;
            txtToplamIskonto.EditValue = Siparis.ToplamIndirim;
            txtSiparisBarkodu.EditValue = Siparis.SiparisBarkodNu;


            #endregion
        }


        private void DepoDoldur()
        {
            Depo = new csDepo(SqlConnections.GetBaglanti(), trGenel);
            lkpDepo.Properties.DataSource = Depo.dt_Depo;
            lkpDepo.Properties.PopulateColumns();
            lkpDepo.Properties.ValueMember = "DepoID";
            lkpDepo.Properties.DisplayMember = "DepoAdi";
        }
        private void SatisElemaniDoldur()
        {
            clsTablolar.Personel.csSatistaGorevliPersonel perso = new clsTablolar.Personel.csSatistaGorevliPersonel();
            lkpSatisElemani.Properties.DataSource = perso.SatistaGorevliPersonelListesi(SqlConnections.GetBaglanti());
            lkpSatisElemani.Properties.DisplayMember = "CariTanim";
            lkpSatisElemani.Properties.ValueMember = "PersonelID";

            lkpSatisElemani.Properties.PopulateColumns();
        }
        private void FiyatTanimlariniDoldur()
        {
            lkpKullanilanFiyatTanimi.Properties.DataSource = FiyatTanimlari.TumFiyatTanimlariniGetir(SqlConnections.GetBaglanti(), trGenel);
            lkpKullanilanFiyatTanimi.Properties.DisplayMember = "FiyatTanimAdi";
            lkpKullanilanFiyatTanimi.Properties.ValueMember = "FiyatTanimID";


        }

        private void lkpBirim2_Doldur(string stokID)
        {
            try
            {
                //csStok üstünde sen güncelleme yaptığın için şimdilik buraya yazıyorum. birleştirirken, istersek class a taşıyabiliriz.
                using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT SB.BirimID, SB.BirimAdi FROM dbo.StokBirimCevrim AS SBC INNER JOIN dbo.Stok AS S ON SBC.StokID = S.StokID INNER JOIN dbo.StokBirim AS SB ON SBC.BirimID = SB.BirimID WHERE     (S.StokID = @StokID)", SqlConnections.GetBaglanti()))
                {
                    da.SelectCommand.Transaction = trGenel;
                    da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = stokID;
                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    //lkpBirim2.DataSource = dt;
                    //lkpBirim2.PopulateColumns();
                    //lkpBirim2.ValueMember = "BirimID";
                    //lkpBirim2.DisplayMember = "BirimAdi";
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void cbtnNumaraGetir_Click(object sender, EventArgs e)
        {
            //NumaraSablon.frmNumaraSablonListesi frmNumaraSablonListesi = new NumaraSablon.frmNumaraSablonListesi();
            //frmNumaraSablonListesi.ShowDialog();
        }

        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvSiparisHareket.FocusedRowHandle < 0) return;
                if (XtraMessageBox.Show("satırı silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                gvSiparisHareket.DeleteSelectedRows();
                //SiparisHareket.dt_SiparisHareketleri.Rows.RemoveAt(gvSiparisHareket.FocusedRowHandle);
                SatirNumaralariniOlustur();
                hesaplama.AltToplamlariHesapla();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        /// <summary>
        /// Gridde bulunan SatirNo alanının 
        /// </summary>
        /// 
        void SatirNumaralariniOlustur()
        {
            int satirSayisi = 1;
            foreach (DataRow row in SiparisHareket.dt_SiparisHareketleri.AsEnumerable())
            {
                if (row.RowState != DataRowState.Deleted)
                {
                    row["SatirNo"] = satirSayisi.ToString();
                    satirSayisi++;
                }
            }
        }

        void AltToplamlariAl()
        {
            Kaydet_Vazgec_Sil_Enable(true);
            txtToplam_Iskontosuz_Kdvsiz.EditValue = hesaplama.Toplam_Iskontosuz_Kdvsiz;
            txtToplamIndirim.EditValue = hesaplama.ToplamIndirim;
            txtCariIskontoToplami.EditValue = hesaplama.CariIskontoToplami;
            txtStokIskontoToplami.EditValue = hesaplama.StokIskontoToplami;
            txtToplamKDV.EditValue = hesaplama.ToplamKdv;
            txtAraToplam.EditValue = hesaplama.IskontoluToplam;

            txtSiparisTutari.EditValue = hesaplama.FaturaTutari;

            Kaydet_Vazgec_Sil_Enable(true);

            //colKdvDetay_KdvTutari
        }


        void Kaydet_Vazgec_Sil_Enable(bool true_false)
        {
            if (true_false == true)
                Tag = 0;
            else
                Tag = 1;

            btnKaydet.Enabled = true_false;
            btnVazgec.Enabled = true_false;
            btnSil.Enabled = !true_false;
        }



        int SecilenNumaraSablonID = -1;
        // Sipariş Numarası Buradan ayarlanabiliyor
        private void txtSiparisNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                NumaraSablon.frmNumaraSablonListesi frmNumaraSablonListesi = new NumaraSablon.frmNumaraSablonListesi((int)Siparis.SiparisTipi);
                if (frmNumaraSablonListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtSiparisNo.EditValue = frmNumaraSablonListesi._KullanilacakNumara;
                    SecilenNumaraSablonID = frmNumaraSablonListesi._NumaraSablonID;
                    txtSiparisNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                }
            }
            if (e.Button.Index == 1)
            {
                SecilenNumaraSablonID = -1;
                txtSiparisNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
                txtSiparisNo.EditValue = "";
            }
        }

        #region Gird Arayüz İşlemleri
        enum enGridArayuzIslemleri { Set, Get };
        void GridArayuzIslemleri(enGridArayuzIslemleri islem)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                FormdakiGridleriBul(this, islem);
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
            }
        }
        private void FormdakiGridleriBul(Control nesne, enGridArayuzIslemleri islem)
        {
            if (nesne is DevExpress.XtraGrid.GridControl)
            {
                if (islem == enGridArayuzIslemleri.Set)
                    GridArayuzleriKaydet(nesne);
                else
                    GridArayuzleriYukle(nesne);
            }

            foreach (Control altnesne in nesne.Controls)
                FormdakiGridleriBul(altnesne, islem);
        }
        void GridArayuzleriKaydet(Control ctrl)
        {
            DevExpress.XtraGrid.GridControl gc = new GridControl();
            gc = ctrl as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

            string Layout = "";
            using (var ms = new MemoryStream())
            {
                gv.SaveLayoutToStream(ms);
                ms.Position = 0;
                using (var reader = new StreamReader(ms))
                    Layout = reader.ReadToEnd();
            }
            cs.csGridLayout.InsertLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, Layout, SqlConnections.GetBaglanti(), trGenel);
        }
        void GridArayuzleriYukle(Control ctrl)
        {
            DevExpress.XtraGrid.GridControl gc = new GridControl();
            gc = ctrl as DevExpress.XtraGrid.GridControl;
            DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

            MemoryStream ms = cs.csGridLayout.GetLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, SqlConnections.GetBaglanti(), trGenel);
            if (ms.Length > 0)
                gv.RestoreLayoutFromStream(ms);
        }
        #endregion

        #region Kısayollar
        private void frmSiparisDetay_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    BtnCariBul_Click(null, null);
                    break;
                case Keys.F6:
                    btnStokEkle_Click(null, null);
                    break;
                    //default:
            }

            if (e.KeyCode == Keys.F2)
                btnKaydet_Click(null, null);
            else if (e.KeyCode == Keys.F3)
                btnVazgec_Click(null, null);
            else if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void txtSiparisNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
                txtSiparisNo_ButtonClick(null, null);
        }
        #endregion

        #region Kaydet vazgeç Sil Butonları

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SiparisCsDekiBilgileriVer();
                #region BOŞ ALAN KONTROLÜ
                //foreach (DataRow row in SiparisHareket.dt_SiparisHareketleri.AsEnumerable())
                //{
                //  if (row["AnaBirimFiyat"].ToString() == "")
                //  {
                //    XtraMessageBox.Show("Birim Fiyat girişi yapılmamış satır var.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //  }
                //}
                if (gvSiparisHareket.RowCount == 0)
                {
                    XtraMessageBox.Show("Stok seçiniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSiparisNo.Focus();
                    return;
                }
                if (memoUnvan.Text == "")
                {
                    XtraMessageBox.Show("Cari seçiniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    memoUnvan.Focus();
                    return;
                }
                if (lkpDepo.EditValue == null || lkpDepo.EditValue.ToString() == "-1")
                {
                    XtraMessageBox.Show("Depo seçiniz", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    lkpDepo.Focus();
                    return;
                }

                #endregion
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();

                #region Siparis TABLOSUNA KAYDEDİLİYOR.

                #region Siparis No daha önce kaydedilmiş mi kontrolü yapılıyor.
                //bool cevap = false;
                //using (SqlCommand cmd = new SqlCommand("Select  SiparisID From Siparis Where SiparisNo=@SiparisNo AND SiparisID<>@SiparisID", SqlConnections.GetBaglanti(), trGenel))
                //{
                //  cmd.Parameters.Add("@SiparisNo", SqlDbType.NVarChar).Value = txtSiparisNo.Text;
                //  cmd.Parameters.Add("@SiparisID", SqlDbType.Int).Value = Siparis.SiparisID;
                //  using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                //    cevap = dr.Read();
                //}
                //if (cevap)
                //{
                //  MessageBox.Show("Siparis No zaten kullanılıyor.");
                //  trGenel.Rollback();
                //  txtSiparisNo.Focus();
                //  return;
                //}
                #endregion


                // yeni kayıtsa yeni kayıt ile ilgili Sipariş numarası verme işlemleri
                if (Siparis.SiparisID == -1)
                {
                    // sipariş numarası boşsa varsayilan numarayı ver
                    if (txtSiparisNo.Text == "")
                    {
                        NumaraVer = new csNumaraVer();
                        Siparis.SiparisNo = NumaraVer.VarsayilanNumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, (IslemTipi)Siparis.SiparisTipi);
                    } // secilen numara şablonID -1 den farklı olması bir numara şablon u seçilmiş demektir o o numarasablonId ye göre numarayı yeniden ver
                    else if (SecilenNumaraSablonID != -1)
                    {
                        NumaraVer = new csNumaraVer();
                        Siparis.SiparisNo = NumaraVer.NumaraVerveKaydet(SecilenNumaraSablonID, SqlConnections.GetBaglanti(), trGenel);
                    }
                }


                Siparis.SiparisKAydet(SqlConnections.GetBaglanti(), trGenel);
                SiparisHareket.SiparisHareketleriniKaydet(SqlConnections.GetBaglanti(), trGenel, Siparis.SiparisID);
                #endregion

                trGenel.Commit();
                Kaydet_Vazgec_Sil_Enable(false);
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        int IlkCariID = -1; // eğer
        private void btnVazgec_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Değişiklikler İptal Edilecek\nEmin misin hamısına", "Dikkat Hamısına", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                SiparisCsDekiBilgileriAl();
                SiparisHareket.dt_SiparisHareketleri.RejectChanges();
                Kaydet_Vazgec_Sil_Enable(false);
            }
        }

        #endregion

        #region Stok Ekle, Stok Çıkar vn Butonlar

        public void StokEkle(int StokID, decimal Miktar)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);

                SiparisHareket.dt_SiparisHareketleri.Rows.Add(SiparisHareket.dt_SiparisHareketleri.NewRow());// Rows.Add(SiparisHareket.dt_SiparisHareketleri.NewRow());
                //SiparisHareket.dt_SiparisHareketleri.Rows.Add(SiparisHareket.dt_SiparisHareketleri.Rows.Add(new object[]{});
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["StokID"] = YeniStok.StokID;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["StokAnaBirimID"] = YeniStok.StokBirimID;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["SiparisHareketStokAdi"] = YeniStok.StokAdi;
                //SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["Birim2ID"] = Stok["BirimAdi"];
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["Miktar"] = Miktar;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["Kdv"] = YeniStok.SatisKdv;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["DepoID"] = lkpDepo.EditValue.ToString();
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["StokIskonto1"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["StokIskonto2"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["StokIskonto3"] = 0;

                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["CariIskonto1"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["CariIskonto2"] = 0;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["CariIskonto3"] = 0;



                // Alt Birim İle İlgili Ayarları Koyuyoruz hamısına
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["KatSayi"] = 1;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["Birim2ID"] = YeniStok.StokBirimID;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["StokAltBirimAdi"] = YeniStok.StokAnaBirimAdi;



                decimal Fiyat = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), trGenel, Siparis.KullanilanFiyatTanimID, YeniStok.StokID);

                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["AnaBirimFiyat"] = Fiyat;
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["Birim2Fiyat"] = Fiyat;


                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["BirlesikUrunHareketID"] = -2; // -2 olunca ne oluyrdu bunu yaz
                SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]["FireMiktari"] = 0;
                // BirleşikUrunID -2 normal hareket -1 birleşik hareket


                lkpBirim2_Doldur(YeniStok.StokID.ToString());
                gvSiparisHareket.BestFitColumns();


                hesaplama.SatirHesaplamasi(SiparisHareket.dt_SiparisHareketleri.Rows[SiparisHareket.dt_SiparisHareketleri.Rows.Count - 1]);



                SatirNumaralariniOlustur();
                trGenel.Commit();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void StokDegistir(DataRow Stok, decimal Miktar)
        {
            try
            {
                //SiparisHareket.dt_SiparisHareketleri.Rows.Add(SiparisHareket.dt_SiparisHareketleri.NewRow());
                SiparisHareket.dt_SiparisHareketleri.Rows[gvSiparisHareket.FocusedRowHandle]["StokID"] = Stok["StokID"];
                SiparisHareket.dt_SiparisHareketleri.Rows[gvSiparisHareket.FocusedRowHandle]["Birim1ID"] = Stok["StokBirimID"];
                SiparisHareket.dt_SiparisHareketleri.Rows[gvSiparisHareket.FocusedRowHandle]["StokAdi"] = Stok["StokAdi"];
                SiparisHareket.dt_SiparisHareketleri.Rows[gvSiparisHareket.FocusedRowHandle]["Birim1"] = Stok["BirimAdi"];
                SiparisHareket.dt_SiparisHareketleri.Rows[gvSiparisHareket.FocusedRowHandle]["Miktar1"] = Miktar;
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void btnStokEkle_Click(object sender, EventArgs e)
        {
            Stok.frmStokListesi StokArama = new Stok.frmStokListesi(true);
            StokArama.Stok_Sec = StokEkle;
            StokArama.ShowDialog();
            gvSiparisHareket.FocusedRowHandle = gvSiparisHareket.RowCount - 1;
            gvSiparisHareket.FocusedColumn = colMiktar;
            gvSiparisHareket.ShowEditor();
        }
        private void btnStokKartiAc_Click(object sender, EventArgs e)
        {
            if (gvSiparisHareket.RowCount == 0) return;
            Stok.frmStokDetay StokKarti = new Stok.frmStokDetay(Convert.ToInt32(gvSiparisHareket.GetFocusedRowCellValue(colStokID)));
            StokKarti.MdiParent = this.MdiParent;
            StokKarti.Show();
        }

        #endregion

        private void ButunControllerIcin_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            Kaydet_Vazgec_Sil_Enable(true);
        }

        private void frmSiparisDetay_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                e.Cancel = true;
                MessageBox.Show("Kayıt Tamamlanmadı hamısına");
            }
        }

        private void frmSiparisDetay_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                GridArayuzIslemleri(enGridArayuzIslemleri.Set);
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        #region Iskonto Uygula

        private void btnStokIskontoBirinciYuzdeGir_Click(object sender, EventArgs e)
        {
            hesaplama.IskontoUgula(colStokIskonto1.FieldName);
        }
        private void btnStokIskontoIkinciYuzdeGir_Click(object sender, EventArgs e)
        {
            hesaplama.IskontoUgula(colStokIskonto2.FieldName);
        }
        private void btnStokIskontoUcuncuYuzdeGir_Click(object sender, EventArgs e)
        {
            hesaplama.IskontoUgula(colStokIskonto3.FieldName);
        }
        private void btnStokIskontoBirTutarGir_Click(object sender, EventArgs e)
        {
            hesaplama.StokIskonto1TutarGir();
        }
        private void btnStokIskontoIkiTutarGir_Click(object sender, EventArgs e)
        {
            hesaplama.StokIskonto2TutarGir();
        }
        private void btnStokIskontoUcTutarGir_Click(object sender, EventArgs e)
        {
            hesaplama.StokIskonto3TutarGir();
        }
        private void btnCariIskontoBirYuzdeGir_Click(object sender, EventArgs e)
        {
            hesaplama.IskontoUgula(colCariIskonto1.FieldName);
        }
        private void btnCariIskontoIkiYuzdeGir_Click(object sender, EventArgs e)
        {
            hesaplama.IskontoUgula(colCariIskonto2.FieldName);
        }
        private void btnCariIskontoUcYuzdeGir_Click(object sender, EventArgs e)
        {
            hesaplama.IskontoUgula(colCariIskonto3.FieldName);
        }
        private void btnCariIskontoBirTutarGir_Click(object sender, EventArgs e)
        {
            hesaplama.CariIskonto1TutarGir();
        }
        private void btnCariIskontoIkiTutarGir_Click(object sender, EventArgs e)
        {
            hesaplama.CariIskonto2TutarGir();
        }
        private void btnCariIskontoUcTutarGir_Click(object sender, EventArgs e)
        {
            hesaplama.CariIskonto3TutarGir();
        }

        #endregion

        #region Fiyat Aktarma Tab ındakiler

        private void btnFiyatYukselt_Click(object sender, EventArgs e)
        {
            hesaplama.FiyatYukselt();
        }

        private void btnFiyatDusur_Click(object sender, EventArgs e)
        {
            hesaplama.FiyatDusur();
        }
        private void btnFiyatDegistir_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvSiparisHareket.RowCount; i++)
            {
                int ID = (int)gvSiparisHareket.GetRowCellValue(i, colStokID);
                decimal Fiyat = FiyatTanimlari.FiyatTanimIDveStokIDdenFiyatiniGetir(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(lkpKullanilanFiyatTanimi.EditValue), ID);
                gvSiparisHareket.SetRowCellValue(i, colAnaBirimFiyat, Fiyat);
            }
        }

        private void btnKdvDegistir_Click(object sender, EventArgs e)
        {
            hesaplama.KDVDegistir();
        }

        #endregion

        #region İşlemler
        private void barBtnItemEtiketeGonder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StokEtiketYazdir = new Stok.frmStokEtiket();

            StokEtiketYazdir.MdiParent = this.MdiParent;
            StokEtiketYazdir.Show();
            for (int i = 0; i < gvSiparisHareket.RowCount; i++)
            {
                StokEtiketYazdir.StokEkle(Convert.ToInt32(gvSiparisHareket.GetRowCellValue(i, colStokID)), Convert.ToDecimal(gvSiparisHareket.GetRowCellValue(i, colMiktar)));
            }
        }
        #endregion

        #region Yazdırma İşlemleri

        private void YazdirmakicinVerileriHazirla()
        {
            if (btnKaydet.Enabled == true) // eğer kayıt tamamlanmamışsa önce kaydediyoruz ki verileri class a atsın
                btnKaydet_Click(null, null);

            yazdir = new clsTablolar.Yazdirma.csYazdir();

            yazdir.dt_ekle("Sipariş Ust Bilgi");
            yazdir.DtyaYeniSatirEkle("Sipariş Ust Bilgi");

            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Ticari Adi", Siparis.CariTanim, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Cari Kodu", Siparis.CariKod, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Adresi", Siparis.Adres, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Vergi Dairesi", Siparis.VergiDairesi, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Vergi Numarası", Siparis.VergiNo, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Fatura Tarihi", Siparis.SiparisTarihi, System.Type.GetType("System.DateTime"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "İli", Siparis.Il, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "İlçesi", Siparis.Ilce, System.Type.GetType("System.String"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "İrsaliye No", Siparis.Ilce, System.Type.GetType("System.String"));
            //yazdir.dtyaAlanVeVeriEkle("FaturaUstBilgi", "İrsaliye Tarihi", );
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Ara Toplam", Siparis.Toplam_Iskontosuz_Kdvsiz, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Toplam Iskonto", Siparis.ToplamIndirim, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Iskontolu Toplam", Siparis.IskontoluToplam, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Toplam Kdv", Siparis.ToplamKdv, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Genel Toplam", Siparis.SiparisTutari, System.Type.GetType("System.Decimal"));
            yazdir.dtAlanEkleVeriEkle("Sipariş Ust Bilgi", "Yazı İle", yazdir.yaziyaCevir(Siparis.SiparisTutari), System.Type.GetType("System.String"));



            //yazdir.classtandsyeDtekle("Fatura Alt Bilgi");
            //yazdir.DtyaYeniSatirEkle("Fatura Alt Bilgi");



            //yazdir.ds.Tables[]

            yazdir.dt_ekle(SiparisHareket.dt_SiparisHareketleri.Copy());
            yazdir.dt_ekle(hesaplama.dt_kdv.Copy());
        }

        private void barBtnItemYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), (clsTablolar.csRaporDizayn.RaporModul)Siparis.SiparisTipi), clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir);
            }
        }

        private void barBtnItemOnizle_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            using (varsayilanyol = new clsTablolar.Rapor.csRaporVarsayilanYolu())
            {
                yazdir.Yazdirr(varsayilanyol.RaporVarsayilan(SqlConnections.GetBaglanti(), (clsTablolar.csRaporDizayn.RaporModul)Siparis.SiparisTipi), clsTablolar.Yazdirma.csYazdir.Nasil.Goster);
            }
        }

        private void barBtnItemFormSecerekYazdir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            YazdirmakicinVerileriHazirla();
            frmRaporDizaynListesiv2 frm = new frmRaporDizaynListesiv2(yazdir, (csRaporDizayn.RaporModul)Siparis.SiparisTipi);
            frm.ShowDialog();
        }
        #endregion



        //int _NumaraSablonID
        private void txtSiparisNo_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnFiyatListesiniAc_Click(object sender, EventArgs e)
        {
            Stok.frmStokFiyatlari Fiyatlari;
            if ((IslemTipi)Siparis.SiparisTipi == IslemTipi.AlinanSiparis)
            {
                Fiyatlari = new Stok.frmStokFiyatlari(Stok.frmStokFiyatlari.NeFiyati.Satis, (int)gvSiparisHareket.GetFocusedRowCellValue(colStokID), Siparis.CariID);
            }
            else
            {
                Fiyatlari = new Stok.frmStokFiyatlari(Stok.frmStokFiyatlari.NeFiyati.Alis, (int)gvSiparisHareket.GetFocusedRowCellValue(colStokID), Siparis.CariID);
            }
            Fiyatlari.lblStokAdi.Text = gvSiparisHareket.GetFocusedRowCellValue(colSiparisHareketStokAdi).ToString();
            Fiyatlari.lblStokKodu.Text = gvSiparisHareket.GetFocusedRowCellValue(colStokKodu).ToString();
            Fiyatlari.FiyatVer = FiyatDegistir;
            Fiyatlari.ShowDialog();
        }
        void FiyatDegistir(decimal Fiyat)
        {
            gvSiparisHareket.SetFocusedRowCellValue(colAnaBirimFiyat, Fiyat);
        }


        Fatura.frmFaturaDetay Fatura;
        private void barButtonItem_Faturalandir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (btnKaydet.Enabled == true)
            {
                MessageBox.Show("Önce kaydı tamamlayın");
                return;
            }
            switch (_SiparisTipi)
            {
                case clsTablolar.Siparis.csSiparis.SiparisTip.AlinanSiparis:
                    Fatura = new Fatura.frmFaturaDetay(IslemTipi.SatisFaturasi, Siparis.CariID);
                    break;
                case clsTablolar.Siparis.csSiparis.SiparisTip.VerilenSiparis:
                    Fatura = new Fatura.frmFaturaDetay(IslemTipi.AlisFaturasi, Siparis.CariID);
                    break;
            }

            Fatura.MdiParent = this.MdiParent;
            Fatura.Show();

            for (int i = 0; i < gvSiparisHareket.RowCount; i++)
            {
                if (_SiparisTipi == clsTablolar.Siparis.csSiparis.SiparisTip.VerilenSiparis)
                {
                    Fatura.StokEkle((int)gvSiparisHareket.GetRowCellValue(i, colStokID), (decimal)gvSiparisHareket.GetRowCellValue(i, colMiktar)); // stok ekle ile faturayaharekete yeni satır eklemiş oluyoruz zaten

                    Fatura.gvFaturaHareket.SetRowCellValue(i, colAnaBirimFiyat, gvSiparisHareket.GetRowCellValue(i, colAnaBirimFiyat));
                }
                else if (_SiparisTipi == clsTablolar.Siparis.csSiparis.SiparisTip.AlinanSiparis)
                {
                    Fatura.StokEkle((int)gvSiparisHareket.GetRowCellValue(i, colStokID), (decimal)gvSiparisHareket.GetRowCellValue(i, colMiktar)); // stok ekle ile faturayaharekete yeni satır eklemiş oluyoruz zaten
                    Fatura.gvFaturaHareket.SetRowCellValue(i, colAnaBirimFiyat, gvSiparisHareket.GetRowCellValue(i, colAnaBirimFiyat));
                }
            }
            Fatura.SiparisEvrakEkle(Siparis.SiparisID);
            Fatura.BindingContext[Fatura.FaturaHareket.dt_FaturaHareketleri].EndCurrentEdit();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kayıt Silinecek Eminmisiniz??", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                try
                {
                    trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    Siparis.SiparisSil(SqlConnections.GetBaglanti(), trGenel, Siparis.SiparisID);
                    trGenel.Commit();
                }
                catch (Exception hata)
                {
                    trGenel.Rollback();
                    frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                    frmHataBildir.ShowDialog();
                }
            }
        }

        private void txtBirim2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Stok.frmStokBirim Birimler = new Stok.frmStokBirim(Convert.ToInt32(gvSiparisHareket.GetFocusedRowCellValue("StokID")));


            if (Birimler.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                gvSiparisHareket.SetFocusedRowCellValue(colBirim2ID, Birimler.AltBirimID);
                gvSiparisHareket.SetFocusedRowCellValue(colStokAltBirimAdi, Birimler.AltBirimAdi);
                gvSiparisHareket.SetFocusedRowCellValue(colKatSayi, Birimler.AltBirimKatsayi);
                decimal AltBirimMiktar = Convert.ToDecimal(gvSiparisHareket.GetFocusedRowCellValue(colMiktar)) / Birimler.AltBirimKatsayi;

                gvSiparisHareket.SetFocusedRowCellValue(colAltBirimMiktar, AltBirimMiktar);
            }
        }

        private void gcSiparisHareket_Click(object sender, EventArgs e)
        {

        }

        private void btnIlgiliFaturayiAc_Click(object sender, EventArgs e)
        {
            if (gvEvrakIliski.RowCount != 0)
                if (gvEvrakIliski.GetFocusedRowCellValue("FaturaID") != DBNull.Value)
                {
                    Aresv2.Fatura.frmFaturaDetay IlgiliFatura = new Aresv2.Fatura.frmFaturaDetay(Convert.ToInt32(gvEvrakIliski.GetFocusedRowCellValue("FaturaID")));
                    IlgiliFatura.MdiParent = this.MdiParent;
                    IlgiliFatura.Show();
                }
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void xtraTabPage1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}