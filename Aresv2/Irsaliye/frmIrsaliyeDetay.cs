using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using clsTablolar;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraReports.UI;

namespace Aresv2.Irsaliye
{
    public partial class frmIrsaliyeDetay : DevExpress.XtraEditors.XtraForm
    {
        /// <summary>
        /// Yeni Bir Irsaliye açılıyorsa Irsaliye Tipi ve Cari ID bildir
        /// </summary>
        /// <param name="IrsaliyeTipi">Irsaliyenın Tipi:  
        /// Satis Irsaliye = 6,
        /// Alis Irsaliye = 7, 
        /// Satis Iade = 8, 
        /// Alis Iade = 9</param>
        /// <param name="CariID">Eğer hangi cariye kesileceği belli ise CariID belli değilse -1 ver</param>
        public frmIrsaliyeDetay(clsTablolar.IslemTipi IrsaliyeTipi, int CariID)
        {
            InitializeComponent();
            Irsaliye = new clsTablolar.Irsaliye.csIrsaliye(SqlConnections.GetBaglanti(), trGenel, IrsaliyeTipi.GetHashCode(), CariID);
            clsTablolar.cari.csCariv2 Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, CariID);
            _IrsaliyeTipi = IrsaliyeTipi;
        }
        /// <summary>
        /// Kaydedilmiş bir Irsaliye ise IrsaliyeID ver
        /// </summary>
        /// <param name="IrsaliyeID"></param>
        public frmIrsaliyeDetay(int IrsaliyeID)
        {
            InitializeComponent();
            Irsaliye = new clsTablolar.Irsaliye.csIrsaliye(SqlConnections.GetBaglanti(), trGenel, IrsaliyeID);
        }

        clsTablolar.Irsaliye.csIrsaliye Irsaliye;
        SqlTransaction trGenel;

        clsTablolar.Irsaliye.csIrsaliyeHareket IrsaliyeHareket;
        csFiyatTanim FiyatTanimlari = new csFiyatTanim();
        clsTablolar.Stok.csStokunBirimleri StokunBirimleri;
        csDepo Depo;

        csNumaraVer NumaraVer;
        clsTablolar.IslemTipi _IrsaliyeTipi;
        clsTablolar.Stok.csStok YeniStok;
        clsTablolar.cari.csCariv2 Cari;

        DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit GridUzerindeStokunBirimleri = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
        #region Cari Bul
        private void txtUnvan_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            try
            {
                if (e.Button.Index == 0)
                {
                    frmCariListe frmCariListe = new frmCariListe();
                    frmCariListe.Text = "Cari Seçim";
                    frmCariListe._CariIDVer = CariAktar; // delegeye Cari Bul u atıyoruz.
                    frmCariListe.ShowDialog();
                }
                else if (e.Button.Index == 1)
                {
                    Cari.frmCariDetay CariKart = new Cari.frmCariDetay(Irsaliye.CariID);
                    CariKart.MdiParent = this.MdiParent;
                    CariKart.Show();
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        // Datarow dan cari bilgilerini gerekli yerlere koyar
        // Nereden bulur bu cari bilgileri carilisteden, dahası cari listenin içindeki delegeye gönderilir cari listede tamam a tıklanınca bu kodlar çalışır.
        void CariAktar(int CariID)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                Cari = new clsTablolar.cari.csCariv2(SqlConnections.GetBaglanti(), trGenel, CariID);
                // Burada sadece CariID yi Irsaliye class ına yazıyoruzki carinin ID si clasa yazılsın diğerlerini textbox lardan
                Irsaliye.CariID = CariID;
                txtVergiNo.EditValue = Cari.VergiNumarasi;
                txtVergiDairesi.EditValue = Cari.VergiDairesi;
                txtUnvan.EditValue = Cari.CariTanim;
                //txtIlce.EditValue = cari
                //txtIl.EditValue = row["SehirAdi"].ToString();
                txtCariKodu.EditValue = Cari.CariKod;
                //txtVergiDairesi.EditValue = row["VergiDairesi"].ToString();
                //txtVergiNo.EditValue = row["VergiNumarasi"].ToString();
                this.BindingContext[Irsaliye].EndCurrentEdit();
                //Irsaliye.Cari_Isk_Orani_4 = Convert.ToDecimal(row["iskOrani1"]); // Caride iskonto oranı 4 diye bişi yok bu iskonto yu iler de başka bir yerden getireceksin şimdilik 0 olarak bırak Aynı zamanda iskontoların bağlı olduğu bütün textbox ların null değerlerini 0 olacak şekilde ayarla.
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
        private void frmIrsaliyeKarti_Load(object sender, EventArgs e)
        {
            try
            {
                deIrsaliyeTarihi.DateTime = DateTime.Now;
                deIrsaliyeVadesi.DateTime = DateTime.Now;
                deDuzenlemeTarihi.DateTime = DateTime.Now;

                trGenel = SqlConnections.GetBaglanti().BeginTransaction();

                //class düzenlenip, değerler class tan çekilecek.
                #region lkpDepo Dolduruluyor.
                using (SqlDataAdapter da = new SqlDataAdapter("SELECT DepoID, DepoAdi from Depo", SqlConnections.GetBaglanti()))
                {
                    da.SelectCommand.Transaction = trGenel;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    lkpDepo.Properties.DataSource = dt;
                    lkpDepo.Properties.PopulateColumns();
                    lkpDepo.Properties.ValueMember = "DepoID";
                    lkpDepo.Properties.DisplayMember = "DepoAdi";
                }
                #endregion


                IrsaliyeHareket = new clsTablolar.Irsaliye.csIrsaliyeHareket(SqlConnections.GetBaglanti(), trGenel, Irsaliye.IrsaliyeID);
                #region FORM BAŞLIĞI AYARLANIYOR.
                clsTablolar.FormBaslik BaslikAyarla = new clsTablolar.FormBaslik();
                this.Text = BaslikAyarla.FormBaslikDon(Irsaliye.IrsaliyeTipi);
                #endregion


                gcIrsaliyeHareket.DataSource = IrsaliyeHareket.dt_IrsaliyeHareketleri;
                trGenel.Commit();
                GridArayuzIslemleri(enGridArayuzIslemleri.Get);
                IskontoBilgileriniTextlereAktar();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
            NesneleriBinleHamisina();
        }
        private void NesneleriBinleHamisina()
        {
            try
            {
                // yukarıda 2 farklı şekilde türetme imkanın olan Irsaliyeyı burada alanlara al

                deIrsaliyeTarihi.DataBindings.Add("DateTime", Irsaliye, "IrsaliyeTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
                deDuzenlemeTarihi.DataBindings.Add("DateTime", Irsaliye, "DuzenlemeTarihi", true, DataSourceUpdateMode.OnPropertyChanged);
                txtIrsaliyeNo.DataBindings.Add("EditValue", Irsaliye, "IrsaliyeNo", true, DataSourceUpdateMode.OnPropertyChanged);
                txtUnvan.DataBindings.Add("EditValue", Irsaliye, "CariTanim", true, DataSourceUpdateMode.OnPropertyChanged);
                txtCariKodu.DataBindings.Add("EditValue", Irsaliye, "CariKod", true, DataSourceUpdateMode.OnPropertyChanged);
                memoAdres.DataBindings.Add("EditValue", Irsaliye, "Adres", true, DataSourceUpdateMode.OnPropertyChanged);
                txtIl.DataBindings.Add("EditValue", Irsaliye, "Il", true, DataSourceUpdateMode.OnPropertyChanged);
                txtIlce.DataBindings.Add("EditValue", Irsaliye, "Ilce", true, DataSourceUpdateMode.OnPropertyChanged);
                deIrsaliyeVadesi.DataBindings.Add("DateTime", Irsaliye, "Vadesi", true, DataSourceUpdateMode.OnPropertyChanged);
                txtVergiDairesi.DataBindings.Add("EditValue", Irsaliye, "VergiDairesi", true, DataSourceUpdateMode.OnPropertyChanged);
                txtVergiNo.DataBindings.Add("EditValue", Irsaliye, "VergiNo", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplamIndirim.DataBindings.Add("EditValue", Irsaliye, "ToplamIndirim", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplamKDV.DataBindings.Add("EditValue", Irsaliye, "ToplamKdv", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplam.DataBindings.Add("EditValue", Irsaliye, "Toplam", true, DataSourceUpdateMode.OnPropertyChanged);
                txtNET.DataBindings.Add("EditValue", Irsaliye, "NetToplam", true, DataSourceUpdateMode.OnPropertyChanged);
                memoNot.DataBindings.Add("EditValue", Irsaliye, "Aciklama", true, DataSourceUpdateMode.OnPropertyChanged);
                lkpDepo.DataBindings.Add("EditValue", Irsaliye, "DepoID", true, DataSourceUpdateMode.OnPropertyChanged);

                clsTablolar.Personel.csSatistaGorevliPersonel perso = new clsTablolar.Personel.csSatistaGorevliPersonel();
                lkpSatisElemani.Properties.DataSource = perso.SatistaGorevliPersonelListesi(SqlConnections.GetBaglanti());
                lkpSatisElemani.Properties.PopulateColumns();
                lkpSatisElemani.Properties.ValueMember = "PersonelID";
                lkpSatisElemani.Properties.DisplayMember = "CariTanim";
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
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
                    lkpBirim2.DataSource = dt;
                    lkpBirim2.PopulateColumns();
                    lkpBirim2.ValueMember = "BirimID";
                    lkpBirim2.DisplayMember = "BirimAdi";
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void StokEkle(int StokID, decimal Miktar)
        {
            try
            {
                trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);

                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Add(IrsaliyeHareket.dt_IrsaliyeHareketleri.NewRow());// Rows.Add(IrsaliyeHareket.dt_IrsaliyeHareketleri.NewRow());
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Count - 1]["StokID"] = YeniStok.StokID;
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Count - 1]["StokAnaBirimID"] = YeniStok.StokBirimID;
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Count - 1]["Miktar"] = Miktar;
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Count - 1]["Kdv"] = YeniStok.SatisKdv;
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Count - 1]["DepoID"] = lkpDepo.EditValue.ToString();

                lkpBirim2_Doldur(YeniStok.StokID.ToString());
                gvIrsaliyeHareket.BestFitColumns();
                SatirNumaralariniOlustur();
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void StokDegistir(DataRow Stok, decimal Miktar)
        {
            try
            {
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[gvIrsaliyeHareket.FocusedRowHandle]["StokID"] = Stok["StokID"];
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[gvIrsaliyeHareket.FocusedRowHandle]["Birim1ID"] = Stok["StokBirimID"];
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[gvIrsaliyeHareket.FocusedRowHandle]["StokAdi"] = Stok["StokAdi"];
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[gvIrsaliyeHareket.FocusedRowHandle]["Birim1"] = Stok["BirimAdi"];
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[gvIrsaliyeHareket.FocusedRowHandle]["Miktar1"] = Miktar;
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
        }
        private void SokBilgileriniAl(DataRow StokBilgileri)
        {
            try
            {
                int SonSatirHandle = gvIrsaliyeHareket.RowCount;
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.Add(IrsaliyeHareket.dt_IrsaliyeHareketleri.NewRow());
                gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "StokID", StokBilgileri["StokID"].ToString());
                gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "StokAdi", StokBilgileri["StokAdi"].ToString());
                gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "AnaBirimID", StokBilgileri["StokBirimID"].ToString());
                gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "AltBirimID", StokBilgileri[""].ToString());
                gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "AnaBirimMiktar", StokBilgileri[""].ToString());
                gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "AltBirimCarpani", StokBilgileri[""].ToString());

                if (Irsaliye.IrsaliyeTipi == 1 || Irsaliye.IrsaliyeTipi == 2 || Irsaliye.IrsaliyeTipi == 4) // Irsaliye Tipi satışlardan biri ise kdv satis kdv sini getir
                    gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "Kdv", StokBilgileri["SatisKdv"].ToString());
                else
                    gvIrsaliyeHareket.SetRowCellValue(SonSatirHandle, "Kdv", StokBilgileri["AlisKdv"].ToString());
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
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                #region BOŞ ALAN KONTROLÜ
                foreach (DataRow row in IrsaliyeHareket.dt_IrsaliyeHareketleri.AsEnumerable())
                {
                    if (row["AnaBirimFiyat"].ToString() == "")
                    {
                        XtraMessageBox.Show("Birim Fiyat girişi yapılmamış satır var.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (gvIrsaliyeHareket.RowCount == 0)
                {
                    XtraMessageBox.Show("Stok seçiniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIrsaliyeNo.Focus();
                    return;
                }
                if (txtIrsaliyeNo.Text == "")
                {
                    XtraMessageBox.Show("Irsaliye Numarasını giriniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtIrsaliyeNo.Focus();
                    return;
                }
                if (txtUnvan.Text == "")
                {
                    XtraMessageBox.Show("Cari seçiniz.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUnvan.Focus();
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
                #region NumaraVeriyor
                if (Irsaliye.IrsaliyeID == -1)
                {
                    /// Satis Irsaliye = 6,
                    /// Alis Irsaliye = 7, 
                    /// Satis Iade = 8, 
                    /// Alis Iade = 9</param>
                    NumaraVer = new csNumaraVer();
                    //switch (Irsaliye.IrsaliyeTipi)
                    //{
                    //  case 6: Irsaliye.IrsaliyeNo = NumaraVer.NumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, 6);
                    //    break;
                    //  case 7: Irsaliye.IrsaliyeNo = NumaraVer.NumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, 7);
                    //    break;
                    //  case 8: Irsaliye.IrsaliyeNo = NumaraVer.NumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel,8);
                    //    break;
                    //  case 9: Irsaliye.IrsaliyeNo = NumaraVer.NumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, 9);
                    //    break;
                    //}
                    Irsaliye.IrsaliyeNo = NumaraVer.NumaraVer_ve_Kaydet(SqlConnections.GetBaglanti(), trGenel, Convert.ToInt32(Irsaliye.IrsaliyeTipi));
                }
                #endregion
                #region Irsaliye TABLOSUNA KAYDEDİLİYOR.
                #region Irsaliye No daha önce kaydedilmiş mi kontrolü yapılıyor.
                bool cevap = false;
                using (SqlCommand cmd = new SqlCommand("Select  IrsaliyeID From Irsaliye Where IrsaliyeNo=@IrsaliyeNo AND IrsaliyeID<>@IrsaliyeID", SqlConnections.GetBaglanti(), trGenel))
                {
                    cmd.Parameters.Add("@IrsaliyeNo", SqlDbType.NVarChar).Value = txtIrsaliyeNo.Text;
                    cmd.Parameters.Add("@IrsaliyeID", SqlDbType.Int).Value = Irsaliye.IrsaliyeID;
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        cevap = dr.Read();
                }
                if (cevap)
                {
                    MessageBox.Show("Irsaliye No zaten kullanılıyor.");
                    trGenel.Rollback();
                    txtIrsaliyeNo.Focus();
                    return;
                }
                #endregion

                Irsaliye.IrsaliyeKAydet(SqlConnections.GetBaglanti(), trGenel);
                IrsaliyeHareket.IrsaliyeHareketleriniKaydet(SqlConnections.GetBaglanti(), trGenel, Irsaliye.IrsaliyeID);

                #endregion

                trGenel.Commit();

                this.Close();
            }
            catch (Exception hata)
            {
                trGenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void btnStokCikar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.FocusedRowHandle < 0) return;
                if (XtraMessageBox.Show("satırı silmek istiyor musunuz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) return;
                //gvIrsaliyeHareket.DeleteSelectedRows();
                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows.RemoveAt(gvIrsaliyeHareket.FocusedRowHandle);
                SatirNumaralariniOlustur();
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
            foreach (DataRow row in IrsaliyeHareket.dt_IrsaliyeHareketleri.AsEnumerable())
            {
                row["SatirNo"] = satirSayisi.ToString();
                satirSayisi++;
            }
            txtStokIskonto1_Validating(null, null);
            txtStokIskonto2_Validating(null, null);
            txtStokIskonto3_Validating(null, null);
            txtCariIskonto1_Validating(null, null);
            txtCariIskonto2_Validating(null, null);
            ceCariIskonto3_CheckedChanged(null, null);
        }
        private void gvIrsaliyeHareket_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            try
            {
                int sayac = 1;
                if (sayac == 1)
                {
                    IskontoBilgileriniTextlereAktar();

                    sayac = 2;
                }

                if (e.Column == gvIrsaliyeHareket.Columns["Birim2ID"])
                {
                    #region Birim2ID Değişimi
                    //IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Birim2fiyat"] = "90";
                    trGenel = SqlConnections.GetBaglanti().BeginTransaction();
                    using (SqlCommand cmd = new SqlCommand("Select KatSayi From StokBirimCevrim where StokID=@StokID AND BirimID=@Birim2ID", SqlConnections.GetBaglanti(), trGenel))
                    {
                        cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["StokID"].ToString();
                        cmd.Parameters.Add("@Birim2ID", SqlDbType.Int).Value = IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Birim2ID"].ToString();
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                            if (dr.Read())
                                IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["KatSayi"] = dr["KatSayi"].ToString();
                    }
                    trGenel.Commit();

                    #endregion
                }
                else if (e.Column == gvIrsaliyeHareket.Columns["KdvToplam"])
                {
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Net"] =
                    Convert.ToDecimal(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Toplam"]) +
                     Convert.ToDecimal(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["KdvToplam"]);
                }

                int Miktar = 0, KatSayi = 1;
                decimal AnaBirimFiyat = 0, Birim2Fiyat = 0, Kdv = 0, Toplam = 0, KdvToplam = 0, Net = 0,
                  StokIskonto1 = 0, StokIskonto2 = 0, StokIskonto3 = 0, CariIskonto1 = 0, CariIskonto2 = 0, CariIskonto3 = 0,
                  IndirimYuzdesi1 = 0, IndirimYuzdesi = 0, Indirim = 0, SatirIndirimliBirimFiyat = 0,
                  SatirIndirimliKDVTutar = 0, SatirIndirimliToplam = 0, AltIndirimBirimFiyat = 0, AltIndirimKDVTutar = 0, AltIndirimToplamTutar = 0,
                  SatirToplamIndirim = 0, SatirToplamTutar = 0;

                if (int.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Miktar"].ToString(), out Miktar) == true)
                {
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["AnaBirimFiyat"].ToString(), out AnaBirimFiyat);

                    if (int.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["KatSayi"].ToString(), out KatSayi) == false)
                        KatSayi = 1;
                    Birim2Fiyat = AnaBirimFiyat * Convert.ToDecimal(KatSayi);
                    SatirIndirimliBirimFiyat = Birim2Fiyat;
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Birim2Fiyat"] = Birim2Fiyat;

                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Kdv"].ToString(), out Kdv);
                    Toplam = Birim2Fiyat * Convert.ToDecimal(Miktar);
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Toplam"] = Toplam;
                    KdvToplam = (Toplam * Kdv) / 100;
                    SatirIndirimliKDVTutar = KdvToplam;
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["KdvToplam"] = KdvToplam;
                    Net = Toplam + KdvToplam;
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["Net"] = Net;

                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (Birim2Fiyat * Miktar) + KdvToplam;

                    SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                    //***** SATIR İNDİRİMLERİ 
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["IndirimYuzdesi1"].ToString(), out IndirimYuzdesi1);
                    if (IndirimYuzdesi1 > 0)
                    {
                        #region IndirimYuzdesi1 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * IndirimYuzdesi1 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += Birim2Fiyat - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["IndirimYuzdesi"].ToString(), out IndirimYuzdesi);
                    if (IndirimYuzdesi > 0)
                    {
                        #region IndirimYuzdesi GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * IndirimYuzdesi / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }

                    #region STOK İSKONTOLARI HESAPLANIYOR.
                    decimal SI1 = 0, SI2 = 0, SI3 = 0;
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["StokIskonto1"].ToString(), out SI1);
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["StokIskonto2"].ToString(), out SI2);
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["StokIskonto3"].ToString(), out SI3);
                    if (SI1 > 0)
                    {
                        #region İSKONTOLAR TABINDAKİ Iskonto1 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * SI1 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    if (SI2 > 0)
                    {
                        #region İSKONTOLAR TABINDAKİ Iskonto2 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * SI2 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    if (SI3 > 0)
                    {
                        #region İSKONTOLAR TABINDAKİ Iskonto3 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * SI3 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    #endregion

                    #region CARİ İSKONTOLARI HESAPLANIYOR.
                    decimal CI1 = 0, CI2 = 0, CI3 = 0;
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["CariIskonto1"].ToString(), out CI1);
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["CariIskonto2"].ToString(), out CI2);
                    decimal.TryParse(IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["CariIskonto3"].ToString(), out CI3);
                    if (CI1 > 0)
                    {
                        #region İSKONTOLAR TABINDAKİ Iskonto1 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * CI1 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    if (CI2 > 0)
                    {
                        #region İSKONTOLAR TABINDAKİ Iskonto2 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * CI2 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    if (CI3 > 0)
                    {
                        #region İSKONTOLAR TABINDAKİ Iskonto3 GİRŞLMİŞSE SATIR İNDİRİMLERİ HESAPLANIYOR
                        decimal indirimOncesi = SatirIndirimliBirimFiyat;
                        SatirIndirimliBirimFiyat = SatirIndirimliBirimFiyat - (SatirIndirimliBirimFiyat * CI3 / 100);
                        SatirIndirimliKDVTutar = (SatirIndirimliBirimFiyat * Convert.ToDecimal(Miktar)) * Kdv / 100;
                        SatirToplamIndirim += indirimOncesi - SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliBirimFiyat"] = SatirIndirimliBirimFiyat;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliKDVTutar"] = SatirIndirimliKDVTutar;
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirIndirimliToplam"] = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;

                        SatirToplamTutar = (SatirIndirimliBirimFiyat * Miktar) + SatirIndirimliKDVTutar;
                        #endregion
                    }
                    #endregion

                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirToplamIndirim"] = SatirToplamIndirim;
                    IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[e.RowHandle]["SatirToplamTutar"] = SatirToplamTutar;
                }
                // IrsaliyeHareket.dt_IrsaliyeHareketleri.AcceptChanges();
                altToplamlariHesapla();
            }
            catch (Exception hata)
            {
                //Tr.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        /// <summary>
        /// Girddeki satırlarda tutulan, iskonto oranlarından dolu olanların "Iskontolar" tabındaki textlere aktarılıyor.
        /// </summary>
        private void IskontoBilgileriniTextlereAktar()
        {
            //#region İSKONTO BİLGİLERİ GRİDDEN OKUNUP TEXTLERE YAZILIYOR.
            //if (gvIrsaliyeHareket.GetFocusedRowCellValue("StokIskonto1").ToString() != "")
            //{
            //  txtStokIskonto1.Enabled = true;
            //  ceStokIskonto1.Checked = true;
            //  txtStokIskonto1.Text = gvIrsaliyeHareket.GetFocusedRowCellValue("StokIskonto1").ToString();
            //}
            //if (gvIrsaliyeHareket.GetFocusedRowCellValue("StokIskonto2").ToString() != "")
            //{
            //  txtStokIskonto2.Enabled = true;
            //  ceStokIskonto2.Checked = true;
            //  txtStokIskonto2.Text = gvIrsaliyeHareket.GetFocusedRowCellValue("StokIskonto2").ToString();
            //}
            //if (gvIrsaliyeHareket.GetFocusedRowCellValue("StokIskonto3").ToString() != "")
            //{
            //  txtStokIskonto3.Enabled = true;
            //  ceStokIskonto3.Checked = true;
            //  txtStokIskonto3.Text = gvIrsaliyeHareket.GetFocusedRowCellValue("StokIskonto3").ToString();
            //}

            //if (gvIrsaliyeHareket.GetFocusedRowCellValue("CariIskonto1").ToString() != "")
            //{
            //  txtCariIskonto1.Enabled = true;
            //  ceCariIskonto1.Checked = true;
            //  txtCariIskonto1.Text = gvIrsaliyeHareket.GetFocusedRowCellValue("CariIskonto1").ToString();
            //}
            //if (gvIrsaliyeHareket.GetFocusedRowCellValue("CariIskonto2").ToString() != "")
            //{
            //  txtCariIskonto2.Enabled = true;
            //  ceCariIskonto2.Checked = true;
            //  txtCariIskonto2.Text = gvIrsaliyeHareket.GetFocusedRowCellValue("CariIskonto2").ToString();
            //}
            //if (gvIrsaliyeHareket.GetFocusedRowCellValue("CariIskonto3").ToString() != "")
            //{
            //  txtCariIskonto3.Enabled = true;
            //  ceCariIskonto3.Checked = true;
            //  txtCariIskonto3.Text = gvIrsaliyeHareket.GetFocusedRowCellValue("CariIskonto3").ToString();
            //}
            //#endregion
        }
        void altToplamlariHesapla()
        {
            try
            {
                decimal SatirToplamIndirim = 0, SatirToplamIndirimToplam = 0,
                  SatirIndirimliKDVTutar = 0, SatirIndirimliKDVTutarToplam = 0,
                  SatirToplamTutar = 0, SatirToplamTutarToplam = 0,
                  SatirIndirimliBirimFiyat = 0, SatirIndirimliBirimFiyatToplam = 0;

                //IrsaliyeHareket.dt_IrsaliyeHareketleri.AsEnumerable().Sum(t => decimal.TryParse(Convert.ToString(t["SatirToplamIndirim"]), out SatirToplamIndirim) ? SatirToplamIndirim : 0);
                //IrsaliyeHareket.dt_IrsaliyeHareketleri.AsEnumerable().Sum(t1 => decimal.TryParse(Convert.ToString(t1["SatirIndirimliKDVTutar"]), out SatirIndirimliKDVTutar) ? SatirIndirimliKDVTutar : 0);
                foreach (DataRow row in IrsaliyeHareket.dt_IrsaliyeHareketleri.AsEnumerable())
                {
                    if (decimal.TryParse(row["SatirToplamIndirim"].ToString(), out SatirToplamIndirim) &&
                        decimal.TryParse(row["SatirIndirimliKDVTutar"].ToString(), out SatirIndirimliKDVTutar) &&
                        decimal.TryParse(row["SatirToplamTutar"].ToString(), out SatirToplamTutar) &&
                        decimal.TryParse(row["SatirIndirimliBirimFiyat"].ToString(), out SatirIndirimliBirimFiyat))
                    {
                        SatirToplamIndirimToplam += SatirToplamIndirim;
                        SatirIndirimliKDVTutarToplam += SatirIndirimliKDVTutar;
                        SatirToplamTutarToplam += SatirToplamTutar;
                        SatirIndirimliBirimFiyatToplam += SatirIndirimliBirimFiyat;
                    }
                }

                Irsaliye.ToplamIndirim = SatirToplamIndirimToplam;
                Irsaliye.ToplamKdv = SatirIndirimliKDVTutarToplam;
                Irsaliye.Toplam = SatirIndirimliBirimFiyatToplam;
                Irsaliye.NetToplam = SatirToplamTutarToplam;

                txtToplamIndirim.DataBindings.Clear();
                txtToplamKDV.DataBindings.Clear();
                txtToplam.DataBindings.Clear();
                txtNET.DataBindings.Clear();

                txtToplamIndirim.DataBindings.Add("EditValue", Irsaliye, "ToplamIndirim", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplamKDV.DataBindings.Add("EditValue", Irsaliye, "ToplamKdv", true, DataSourceUpdateMode.OnPropertyChanged);
                txtToplam.DataBindings.Add("EditValue", Irsaliye, "Toplam", true, DataSourceUpdateMode.OnPropertyChanged);
                txtNET.DataBindings.Add("EditValue", Irsaliye, "NetToplam", true, DataSourceUpdateMode.OnPropertyChanged);
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtBirim2_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //frmBirim2Secim frmFKB2Secim = new frmBirim2Secim(gvIrsaliyeHareket.GetFocusedRowCellValue("StokID").ToString());
            //if (frmFKB2Secim.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //  gvIrsaliyeHareket.SetFocusedRowCellValue("Birim2ID", frmBirim2Secim.BirimID);
            //  gvIrsaliyeHareket.SetFocusedRowCellValue("BirimAdi", frmBirim2Secim.BirimAdi);
            //}
        }
        private void ceStokIskonto1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtStokIskonto1.Enabled = ceStokIskonto1.Checked;
                if (ceStokIskonto1.Checked == false)
                {
                    txtStokIskonto1.Text = "0";
                    if (gvIrsaliyeHareket.RowCount > 0)
                    {
                        for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                        {
                            IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["StokIskonto1"] = 0;
                            gvIrsaliyeHareket.SetRowCellValue(i, "StokIskonto1", 0);
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void ceStokIskonto2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtStokIskonto2.Enabled = ceStokIskonto2.Checked;
                if (ceStokIskonto2.Checked == false)
                {
                    txtStokIskonto2.Text = "0";
                    if (gvIrsaliyeHareket.RowCount > 0)
                    {
                        for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                        {
                            IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["StokIskonto2"] = 0;
                            gvIrsaliyeHareket.SetRowCellValue(i, "StokIskonto2", 0);
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void ceStokIskonto3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtStokIskonto3.Enabled = ceStokIskonto3.Checked;
                if (ceStokIskonto3.Checked == false)
                {
                    txtStokIskonto3.Text = "0";
                    if (gvIrsaliyeHareket.RowCount > 0)
                    {
                        for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                        {
                            IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["StokIskonto3"] = 0;
                            gvIrsaliyeHareket.SetRowCellValue(i, "StokIskonto3", 0);
                        }
                    }
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtStokIskonto1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.RowCount > 0)
                {
                    if (txtStokIskonto1.Text == "") return;
                    decimal StokIskonto1 = 0;
                    if (decimal.TryParse(txtStokIskonto1.Text, out StokIskonto1) == false)
                    {
                        XtraMessageBox.Show("Stok İskonto 1 Alanına geçersiz karakter girdiniz.", "Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtStokIskonto1.Focus();
                        return;
                    }

                    for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                    {
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["StokIskonto1"] = StokIskonto1;
                        gvIrsaliyeHareket.SetRowCellValue(i, "StokIskonto1", StokIskonto1);
                    }
                    gvIrsaliyeHareket.FocusedColumn = colStokIskonto1;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtStokIskonto2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.RowCount > 0)
                {
                    if (txtStokIskonto2.Text == "") return;
                    decimal StokIskonto2 = 0;
                    if (decimal.TryParse(txtStokIskonto2.Text, out StokIskonto2) == false)
                    {
                        XtraMessageBox.Show("Stok İskonto 2 Alanına geçersiz karakter girdiniz.", "Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtStokIskonto2.Focus();
                        return;
                    }
                    for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                    {
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["StokIskonto2"] = StokIskonto2;
                        gvIrsaliyeHareket.SetRowCellValue(i, "StokIskonto2", StokIskonto2);
                    }
                    gvIrsaliyeHareket.FocusedColumn = colStokIskonto2;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtStokIskonto3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.RowCount > 0)
                {
                    if (txtStokIskonto3.Text == "") return;
                    decimal StokIskonto3 = 0;
                    if (decimal.TryParse(txtStokIskonto3.Text, out StokIskonto3) == false)
                    {
                        XtraMessageBox.Show("Stok İskonto 3 Alanına geçersiz karakter girdiniz.", "Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtStokIskonto3.Focus();
                        return;
                    }
                    for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                    {
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["StokIskonto3"] = StokIskonto3;
                        gvIrsaliyeHareket.SetRowCellValue(i, "StokIskonto3", StokIskonto3);
                    }
                    gvIrsaliyeHareket.FocusedColumn = colStokIskonto3;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void ceCariIskonto1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtCariIskonto1.Enabled = ceCariIskonto1.Checked;
                if (ceCariIskonto1.Checked == false)
                    if (gvIrsaliyeHareket.RowCount > 0)
                    {
                        for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                        {
                            IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["CariIskonto1"] = 0;
                            gvIrsaliyeHareket.SetRowCellValue(i, "CariIskonto1", 0);
                        }
                    }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void ceCariIskonto2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtCariIskonto2.Enabled = ceCariIskonto2.Checked;
                if (ceCariIskonto2.Checked == false)
                    if (gvIrsaliyeHareket.RowCount > 0)
                    {
                        for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                        {
                            IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["CariIskonto2"] = 0;
                            gvIrsaliyeHareket.SetRowCellValue(i, "CariIskonto2", 0);
                        }
                    }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void ceCariIskonto3_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                txtCariIskonto3.Enabled = ceCariIskonto3.Checked;
                if (ceCariIskonto3.Checked == false)
                    if (gvIrsaliyeHareket.RowCount > 0)
                    {
                        for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                        {
                            IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["CariIskonto3"] = 0;
                            gvIrsaliyeHareket.SetRowCellValue(i, "CariIskonto3", 0);
                        }
                    }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtCariIskonto1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.RowCount > 0)
                {
                    if (txtCariIskonto1.Text == "") return;
                    decimal CariIskonto1 = 0;
                    if (decimal.TryParse(txtCariIskonto1.Text, out CariIskonto1) == false)
                    {
                        XtraMessageBox.Show("Cari İskonto 1 Alanına geçersiz karakter girdiniz.", "Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCariIskonto1.Focus();
                        return;
                    }
                    for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                    {
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["CariIskonto1"] = CariIskonto1;
                        gvIrsaliyeHareket.SetRowCellValue(i, "CariIskonto1", CariIskonto1);
                    }
                    gvIrsaliyeHareket.FocusedColumn = colCariIskonto1;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtCariIskonto2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.RowCount > 0)
                {
                    if (txtCariIskonto2.Text == "") return;
                    decimal CariIskonto2 = 0;
                    if (decimal.TryParse(txtCariIskonto2.Text, out CariIskonto2) == false)
                    {
                        XtraMessageBox.Show("Cari İskonto 2 Alanına geçersiz karakter girdiniz.", "Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCariIskonto2.Focus();
                        return;
                    }
                    for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                    {
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["CariIskonto2"] = CariIskonto2;
                        gvIrsaliyeHareket.SetRowCellValue(i, "CariIskonto2", CariIskonto2);
                    }
                    gvIrsaliyeHareket.FocusedColumn = colCariIskonto2;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }
        private void txtCariIskonto3_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (gvIrsaliyeHareket.RowCount > 0)
                {
                    if (txtCariIskonto3.Text == "") return;
                    decimal CariIskonto3 = 0;
                    if (decimal.TryParse(txtCariIskonto3.Text, out CariIskonto3) == false)
                    {
                        XtraMessageBox.Show("Cari İskonto 3 Alanına geçersiz karakter girdiniz.", "Alan Kontrolü", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtCariIskonto3.Focus();
                        return;
                    }
                    for (int i = 0; i < gvIrsaliyeHareket.RowCount; i++)
                    {
                        IrsaliyeHareket.dt_IrsaliyeHareketleri.Rows[i]["CariIskonto3"] = CariIskonto3;
                        gvIrsaliyeHareket.SetRowCellValue(i, "CariIskonto3", CariIskonto3);
                    }
                    gvIrsaliyeHareket.FocusedColumn = colCariIskonto3;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }

        private void frmIrsaliyeDetay_FormClosed(object sender, FormClosedEventArgs e)
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
        private void lkpDepo_EditValueChanged(object sender, EventArgs e)
        {
            if (lkpDepo.EditValue != null)
            {
                foreach (DataRow row in (gcIrsaliyeHareket.DataSource as DataTable).AsEnumerable()) row["DepoID"] = lkpDepo.EditValue.ToString();
            }
        }
        private void txtIrsaliyeNo_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            NumaraSablon.frmNumaraSablonListesi NumaraSablonListesi = new NumaraSablon.frmNumaraSablonListesi((int)Irsaliye.IrsaliyeTipi);
            if (NumaraSablonListesi.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // txtIrsaliyeNo.Text = NumaraSablon.frmNumaraSablonListesi.Numara;
                // NumaraVer = new csNumaraVer(SqlConnections.GetBaglanti(), trGenel, Irsaliye.IrsaliyeTipi);

                txtIrsaliyeNo.Text = NumaraSablonListesi._KullanilacakNumara;
                Irsaliye.IrsaliyeNo = NumaraSablonListesi._KullanilacakNumara;
            }
        }

    }
}