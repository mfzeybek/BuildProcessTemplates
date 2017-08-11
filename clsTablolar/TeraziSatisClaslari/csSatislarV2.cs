using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Linq;



namespace clsTablolar.TeraziSatisClaslari
{
    public class csSatislarV2 : IDisposable
    {
        public void Dispose()
        {
            th1.Abort();
            GC.SuppressFinalize(this);
        }

        public SqlConnection _baglanti;
        public SqlTransaction _Tr;
        private int _TeraziID = -1;

        public DataTable dt_threadSatislar;

        public Thread th1;
        //SqlDataReader dr;

        public delegate void dlg_VeriTabaniBaglantiDurmu(VeriTabaniBaglantiDurumu BaglnatiDurmu);
        public dlg_VeriTabaniBaglantiDurmu BaglantiDurmu;

        public enum VeriTabaniBaglantiDurumu
        {
            Bagli,
            BaglantisiKoptu
        }

        //bool SurekliSatislariGetir = false;

        public void OdemesiAlinanSonKirkSatis(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.CommandText = @"select top 40 Fatura.FaturaID, FaturaTipi, FaturaTarihi, DuzenlemeTarihi, FaturaNo, CariID,CariKod ,CariTanim, VergiDairesi ,VergiNo, Adres, Il, Ilce, Vadesi, Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DegistirenID, DegismeTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz, CariIskontoToplami, StokIskontoToplami, ToplamIndirim, ToplamKdv, IskontoluToplam, FaturaTutari, KullanilanFiyatTanimID, SiparisID, FaturaGrupID, OdendiMi, FaturaBarkod, TeraziFaturaID, TeraziID,  
[dbo].[FaturaBakiyesiniGetir](Fatura.FaturaID) KalanBakiye, isnull([dbo].[FaturaninOdemeTutariniGetir](Fatura.FaturaID), 0) OdenenTutar from Fatura with(nolock)
inner join TeraziFaturaIliski with(nolock) on TeraziFaturaIliski.FaturaID = Fatura.FaturaID
where fatura.SilindiMi = 0 order by DegismeTarihi desc";
                da.Fill(dt_threadSatislar);
            }
        }

        //public object KilitHamisina = new object();
        public object SadeceSatislariGetirmeyiDurdurmakIstediginde_Kilitle = new object();

        public csSatislarV2(SqlConnection Baglanti, SqlTransaction Tr, int _TeraziID)
        {
            using (SqlDataAdapter da_Thread = new SqlDataAdapter(@"select fatura.FaturaID, FaturaTipi, FaturaTarihi, fatura.DuzenlemeTarihi, FaturaNo, CariID, CariKod, CariTanim, VergiDairesi, VergiNo, Adres, Il, Ilce, 
Vadesi, Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DegistirenID, DegismeTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz, 
CariIskontoToplami , StokIskontoToplami, ToplamIndirim, ToplamKdv, IskontoluToplam, isnull(FaturaTutari, 0) as FaturaTutari, KullanilanFiyatTanimID, SiparisID, FaturaGrupID, OdendiMi, '' as OdemeSekli,
FaturaBarkod
---, TeraziFaturaID, TeraziID
, isnull([dbo].[FaturaBakiyesiniGetir](Fatura.FaturaID), 0) KalanBakiye
,isnull([dbo].[FaturaninOdemeTutariniGetir](Fatura.FaturaID), 0) OdenenTutar
from Fatura  with(nolock, index = IX_Fatura_2)
--inner join TeraziFaturaIliski with(nolock) on TeraziFaturaIliski.FaturaID = Fatura.FaturaID 
where fatura.OdendiMi = 0 and fatura.SilindiMi = 0 and 1 = 0", Baglanti))
            {
                if (_TeraziID != -1)
                {// artık teraziye göre getirmiyoruz
                    //da_Thread.SelectCommand.CommandText = da_Thread.SelectCommand.CommandText + " and TeraziFaturaIliski.TeraziID = @TeraziID ";
                    //da_Thread.SelectCommand.Parameters.Add("@TeraziID", SqlDbType.Int, 0).Value = _TeraziID;

                    this._TeraziID = _TeraziID;
                }
                da_Thread.SelectCommand.Transaction = Tr;
                dt_threadSatislar = new DataTable();

                da_Thread.Fill(dt_threadSatislar);
                System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                DevExpress.Data.CurrencyDataController.DisableThreadingProblemsDetection = true;
            }
        }

        public void YeniEklenenVeDegisenSatislariGetirV2_OdemesiTamamlananVeyaSilinenSatislariCikar(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            //if (_baglanti.State != ConnectionState.Open)
            //    _baglanti.Open();
            //_Tr = _baglanti.BeginTransaction();
            ////OdemesiTamamlananVeyaSilinenSatislariCikar(_baglanti, _Tr);
            //_Tr.Commit();
            //_Tr = _baglanti.BeginTransaction();
            YeniEklenenVeDegisenSatislariGetirSilinenleriCikarV4(Baglanti, Tr, TeraziID);
            KaydedilmeyenSatirlariSil();
            //_Tr.Commit();
            //_baglanti.Close();
            //Monitor.
        }

        public void YeniKayitAc(clsTablolar.cari.csCariv2 CariKart)
        {
            DataRow droww = dt_threadSatislar.NewRow();

            droww["FaturaID"] = -1;
            droww["FaturaTarihi"] = DateTime.Now;
            droww["DuzenlemeTarihi"] = DateTime.Now;
            droww["FaturaNo"] = string.Empty;
            droww["CariID"] = CariKart.CariID;
            droww["CariKod"] = CariKart.CariKod;
            droww["CariTanim"] = CariKart.CariTanim;
            droww["VergiDairesi"] = CariKart.VergiDairesi;
            droww["VergiNo"] = CariKart.VergiNumarasi;
            droww["Adres"] = string.Empty;
            droww["Il"] = string.Empty;
            droww["Ilce"] = string.Empty;
            droww["Vadesi"] = DateTime.Now;
            droww["Iptal"] = 0;
            droww["SilindiMi"] = 0;
            droww["Aciklama"] = string.Empty;
            droww["KaydedenID"] = -1;
            droww["KayitTarihi"] = DateTime.Now;
            droww["DegistirenID"] = -1;
            droww["DegismeTarihi"] = DateTime.Now;
            droww["DepoID"] = -1;
            droww["SatisElemaniID"] = -1;
            droww["Toplam_Iskontosuz_Kdvsiz"] = 0;
            droww["CariIskontoToplami"] = 0;
            droww["StokIskontoToplami"] = 0;
            droww["ToplamIndirim"] = 0;
            droww["ToplamKdv"] = 0;
            droww["IskontoluToplam"] = 0;
            droww["FaturaTutari"] = 0;
            droww["KullanilanFiyatTanimID"] = CariKart.CariFiyatTanimID;
            droww["SiparisID"] = -1;
            droww["FaturaGrupID"] = -1;
            droww["OdendiMi"] = 0;
            droww["FaturaBarkod"] = string.Empty;
            droww["KalanBakiye"] = 0;
            droww["OdenenTutar"] = 0;

            dt_threadSatislar.Rows.Add(droww);
        }
        int _BeklemeSurasi = 0;

        private void YeniEklenenVeDegisenSatislariGetirSilinenleriCikarV4(SqlConnection Baglanti, SqlTransaction Tr, int _TeraziID)
        {

            using (SqlCommand cmmd = new SqlCommand("EklenenVeyaDegisenSatislariGetirV4", Baglanti, Tr))
            {
                cmmd.CommandType = CommandType.StoredProcedure;

                //cmmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = _TeraziID;
                int g = 1;
                foreach (var item in dt_threadSatislar.AsEnumerable().Where(s => s.RowState != DataRowState.Deleted)) // .Where( k => k.Field<int>("RowNo") == KacinciSatirdanGuncellemeyeBaslasin))
                {
                    if (g > 100) //101n ci parametre yok parametreler 100 kadar
                    {
                        Exception e = new Exception("Bu aslında hata değil");
                        break;
                    }
                    cmmd.Parameters.Add("@FaturaID" + g.ToString(), SqlDbType.Int).Value = item["FaturaID"];
                    cmmd.Parameters.Add("@FaturaDegismeTarihi" + g.ToString(), SqlDbType.DateTime).Value = item["DegismeTarihi"];
                    g++;
                }

                //cmmd.Parameters.Add("@TeraziID", SqlDbType.Int).Value = _TeraziID;

                #region
                //cmmd.Parameters.Add("@FaturaID1", SqlDbType.Int).Value = dt_threadSatislar.Rows[0]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi1", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[0]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID2", SqlDbType.Int).Value = dt_threadSatislar.Rows[1]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi2", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[1]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID3", SqlDbType.Int).Value = dt_threadSatislar.Rows[2]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi3", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[2]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID4", SqlDbType.Int).Value = dt_threadSatislar.Rows[3]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi4", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[3]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID5", SqlDbType.Int).Value = dt_threadSatislar.Rows[4]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi5", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[4]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID6", SqlDbType.Int).Value = dt_threadSatislar.Rows[5]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi6", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[5]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID7", SqlDbType.Int).Value = dt_threadSatislar.Rows[6]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi7", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[6]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID8", SqlDbType.Int).Value = dt_threadSatislar.Rows[7]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi8", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[7]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID8", SqlDbType.Int).Value = dt_threadSatislar.Rows[7]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi8", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[7]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID9", SqlDbType.Int).Value = dt_threadSatislar.Rows[8]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi9", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[8]["DegismeTarihi"];

                //cmmd.Parameters.Add("@FaturaID10", SqlDbType.Int).Value = dt_threadSatislar.Rows[9]["FaturaID"];
                //cmmd.Parameters.Add("@FaturaDegismeTarihi10", SqlDbType.DateTime).Value = dt_threadSatislar.Rows[9]["DegismeTarihi"];
                #endregion

                try
                {
                    using (SqlDataReader dr = cmmd.ExecuteReader())
                    {
                        SatisGetir(dr, true);
                    }
                }
                catch (Exception hata)
                {
                    throw hata;
                }
                finally
                {
                    //_Tr.Commit();
                    //_baglanti.Close();
                }
            }
        }

        public void FaturaninButunTutariniNakitOde(SqlConnection Baglanti, SqlTransaction Tr, int _FaturaID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {



            }
        }
        private void KaydedilmeyenSatirlariSil()
        {
            foreach (DataRow item in dt_threadSatislar.Select("FaturaID = '-1' OR FaturaID is null").AsEnumerable())
            {
                if (item.RowState != DataRowState.Deleted)
                    item.Delete();
            }
        }


        //private string SatisGetir(DataRow Dr)
        //{

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="OdemesiYapilmissaCikartilacakMi_Vb"></param>
        /// Eğer ödemesi yapılmışsa, silinmişse veya iptal edilmişse True değeri verildiğinde satış listesinden çaıkartılır
        /// <returns></returns>
        private string SatisGetir(SqlDataReader dr, bool OdemesiYapilmissaCikartilacakMi_Vb)
        {
            string Barkod = string.Empty;
            while (dr.Read())
            {
                if (dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'").Length != 0)
                {
                    if ((bool)dr["Iptal"] || (bool)dr["SilindiMi"])// || (bool)dr["OdendiMi"]) // eğer gelen satır silinmişse, Iptal edilmişse veya Ödenmişse çıkartıyoruz
                    {
                        foreach (var item in dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'").AsEnumerable())
                        {
                            if (OdemesiYapilmissaCikartilacakMi_Vb)
                                item.Delete();
                        }
                        if (dt_threadSatislar.Rows.Count == 0)
                        {
                            dt_threadSatislar.Rows.Clear();
                            return Barkod;
                        }
                    }
                    else
                    {
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["FaturaID"] = dr["FaturaID"];

                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["FaturaTarihi"] = dr["FaturaTarihi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["DuzenlemeTarihi"] = dr["DuzenlemeTarihi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["FaturaNo"] = dr["FaturaNo"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["CariID"] = dr["CariID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["CariKod"] = dr["CariKod"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["CariTanim"] = dr["CariTanim"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["VergiDairesi"] = dr["VergiDairesi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["VergiNo"] = dr["VergiNo"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Adres"] = dr["Adres"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Il"] = dr["Il"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Ilce"] = dr["Ilce"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Vadesi"] = dr["Vadesi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Iptal"] = dr["Iptal"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["SilindiMi"] = dr["SilindiMi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Aciklama"] = dr["Aciklama"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["KaydedenID"] = dr["KaydedenID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["KayitTarihi"] = dr["KayitTarihi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["DegistirenID"] = dr["DegistirenID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["DegismeTarihi"] = dr["DegismeTarihi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["DepoID"] = dr["DepoID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["SatisElemaniID"] = dr["SatisElemaniID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["Toplam_Iskontosuz_Kdvsiz"] = dr["Toplam_Iskontosuz_Kdvsiz"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["CariIskontoToplami"] = dr["CariIskontoToplami"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["StokIskontoToplami"] = dr["StokIskontoToplami"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["ToplamIndirim"] = dr["ToplamIndirim"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["ToplamKdv"] = dr["ToplamKdv"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["IskontoluToplam"] = dr["IskontoluToplam"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["FaturaTutari"] = dr["FaturaTutari"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["KullanilanFiyatTanimID"] = dr["KullanilanFiyatTanimID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["SiparisID"] = dr["SiparisID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["FaturaGrupID"] = dr["FaturaGrupID"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["OdendiMi"] = dr["OdendiMi"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["FaturaBarkod"] = dr["FaturaBarkod"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["KalanBakiye"] = dr["KalanBakiye"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["OdenenTutar"] = dr["OdenenTutar"];
                        dt_threadSatislar.Select("FaturaID = '" + dr["FaturaID"].ToString() + "'")[0]["OdemeSekli"] = dr["OdemeSekli"];


                        //return dr["FaturaBarkod"].ToString();
                        Barkod = dr["FaturaBarkod"].ToString();
                    }
                }
                else
                {


                    //dt_threadSatislar.Load(dr, LoadOption.Upsert);

                    DataRow droww = dt_threadSatislar.NewRow();

                    droww["FaturaID"] = dr["FaturaID"];
                    droww["FaturaTarihi"] = dr["FaturaTarihi"];
                    droww["DuzenlemeTarihi"] = dr["DuzenlemeTarihi"];
                    droww["FaturaNo"] = dr["FaturaNo"];
                    droww["CariID"] = dr["CariID"];
                    droww["CariKod"] = dr["CariKod"];
                    droww["CariTanim"] = dr["CariTanim"];
                    droww["VergiDairesi"] = dr["VergiDairesi"];
                    droww["VergiNo"] = dr["VergiNo"];
                    droww["Adres"] = dr["Adres"];
                    droww["Il"] = dr["Il"];
                    droww["Ilce"] = dr["Ilce"];
                    droww["Vadesi"] = dr["Vadesi"];
                    droww["Iptal"] = dr["Iptal"];
                    droww["SilindiMi"] = dr["SilindiMi"];
                    droww["Aciklama"] = dr["Aciklama"];
                    droww["KaydedenID"] = dr["KaydedenID"];
                    droww["KayitTarihi"] = dr["KayitTarihi"];
                    droww["DegistirenID"] = dr["DegistirenID"];
                    droww["DegismeTarihi"] = dr["DegismeTarihi"];
                    droww["DepoID"] = dr["DepoID"];
                    droww["SatisElemaniID"] = dr["SatisElemaniID"];
                    droww["Toplam_Iskontosuz_Kdvsiz"] = dr["Toplam_Iskontosuz_Kdvsiz"];
                    droww["CariIskontoToplami"] = dr["CariIskontoToplami"];
                    droww["StokIskontoToplami"] = dr["StokIskontoToplami"];
                    droww["ToplamIndirim"] = dr["ToplamIndirim"];
                    droww["ToplamKdv"] = dr["ToplamKdv"];
                    droww["IskontoluToplam"] = dr["IskontoluToplam"];
                    droww["FaturaTutari"] = dr["FaturaTutari"];
                    droww["KullanilanFiyatTanimID"] = dr["KullanilanFiyatTanimID"];
                    droww["SiparisID"] = dr["SiparisID"];
                    droww["FaturaGrupID"] = dr["FaturaGrupID"];
                    droww["OdendiMi"] = dr["OdendiMi"];
                    droww["FaturaBarkod"] = dr["FaturaBarkod"];
                    droww["KalanBakiye"] = dr["KalanBakiye"];
                    droww["OdenenTutar"] = dr["OdenenTutar"];
                    droww["OdemeSekli"] = dr["OdemeSekli"];

                    dt_threadSatislar.Rows.Add(droww);

                    Barkod = dr["FaturaBarkod"].ToString();
                    //return dr["FaturaBarkod"].ToString(); // barkod dönüşünü nerde kullanıyorduk; ve aynı zamanda bu dönüş yüzünden sadece 1 adet
                }
            }
            return Barkod;
        }

        public void SatisiSil(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            // Eğer silinmek istenen satışta hareket varsa silmez ama buraya acaba with(nolock) koymak gerekir mi??
            using (SqlCommand cmdd = new SqlCommand(@"update fatura set SilindiMi = 1 where FaturaID = @faturaID 
and 
((select count(1) from FaturaHareket where FaturaHareket.FaturaID = @faturaID ) = 0)", Baglanti, Tr))
            {
                cmdd.Parameters.Add("@faturaID", SqlDbType.Int).Value = FaturaID;
                cmdd.ExecuteNonQuery();
            }
        }

        SqlCommand cmdKayit;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="DROW"></param>
        /// <param name="TeraziID"></param>
        /// <returns>FaturaID</returns>
        public int SatisiKaydet(SqlConnection Baglanti, SqlTransaction Tr, DataRow DROW, int TeraziID)
        {
            try
            {
                cmdKayit = new SqlCommand()
                {
                    Connection = Baglanti,
                    Transaction = Tr
                };
                int _FaturaID = -1;
                if ((int)DROW["FaturaID"] == -1)
                {
                    cmdKayit.CommandText = "HizliSatisIcinSatisKaydet_Insert";
                    cmdKayit.CommandType = CommandType.StoredProcedure;
                    cmdKayit.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziID;


                    cmdKayit.Parameters.Add("@KaydedenID", SqlDbType.Int, 0).Value = DROW["KaydedenID"]; // Terazi ID yazmaya gerek yok teraziId nin yazıldığı talo var ama ilerde personelID yazılabilir
                    cmdKayit.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                    cmdKayit.Parameters.Add("@FaturaID", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                    //cmdKayit.Parameters.Add("@FaturaTipi", SqlDbType.Int, 0).Value = clsTablolar.IslemTipi.SatisFaturasi; // 1 Satış faturası oluyor
                    cmdKayit.Parameters.Add("@Tarih", SqlDbType.DateTime);
                    cmdKayit.Parameters["@Tarih"].Direction = ParameterDirection.Output;
                    cmdKayit.Parameters.Add("@CariID", SqlDbType.Int, 0).Value = DROW["CariID"];


                    cmdKayit.Parameters.Add("@HesaplananFaturaNo", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                    cmdKayit.Parameters.Add("@Barkod", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
                    cmdKayit.Parameters.Add("@FaturaCariTanim", SqlDbType.NVarChar, 250).Value = DROW["CariTanim"];
                    cmdKayit.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = DROW["CariKod"];
                }
                else if ((int)DROW["FaturaID"] > 0)
                {
                    cmdKayit.CommandText = @"HizliSatisIcinSatisKaydet_Update";
                    cmdKayit.CommandType = CommandType.StoredProcedure;

                    cmdKayit.Parameters.Add("@FaturaID", SqlDbType.Int, 0).Value = DROW["FaturaID"];
                    _FaturaID = (int)DROW["FaturaID"];
                }
                //cmdKayit.Parameters.Add("@FaturaNo", SqlDbType.NVarChar, 0).Value = DROW["FaturaNo"]; // bu artık otomatik sqldeki storeprocedurden geliyor tabi insert ederken sadece

                cmdKayit.Parameters.Add("@Iptal", SqlDbType.Bit).Value = 0;
                cmdKayit.Parameters.Add("@SilindiMi", SqlDbType.Bit, 0).Value = DROW["SilindiMi"];
                cmdKayit.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250).Value = DROW["Aciklama"]; // bu olabilir açıklama yazılması istenebilir
                cmdKayit.Parameters.Add("@DepoID", SqlDbType.Int).Value = 1; // bu önemli hangi depodan satışın olduğu veya TeraziID den Alsın program şimdilik -1 dedim
                cmdKayit.Parameters.Add("@SatisElemaniID", SqlDbType.Int).Value = -1;
                cmdKayit.Parameters.Add("@Toplam_Iskontosuz_Kdvsiz", SqlDbType.Decimal, 0).Value = DROW["Toplam_Iskontosuz_Kdvsiz"]; // bu önemli hamısına
                cmdKayit.Parameters.Add("@CariIskontoToplami", SqlDbType.Decimal, 0).Value = DROW["CariIskontoToplami"]; // Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                cmdKayit.Parameters.Add("@StokIskontoToplami", SqlDbType.Decimal, 0).Value = DROW["StokIskontoToplami"];// Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                cmdKayit.Parameters.Add("@ToplamIndirim", SqlDbType.Decimal, 0).Value = DROW["ToplamIndirim"];// Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                cmdKayit.Parameters.Add("@ToplamKdv", SqlDbType.Decimal, 0).Value = DROW["ToplamKdv"];
                cmdKayit.Parameters.Add("@IskontoluToplam", SqlDbType.Decimal, 0).Value = DROW["IskontoluToplam"];
                cmdKayit.Parameters.Add("@FaturaTutari", SqlDbType.Decimal, 0).Value = DROW["FaturaTutari"];
                cmdKayit.Parameters.Add("@KullanilanFiyatTanimID", SqlDbType.Int, 0).Value = DROW["KullanilanFiyatTanimID"];
                cmdKayit.Parameters.Add("@FaturaGrupID", SqlDbType.Decimal).Value = -1;

                cmdKayit.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime);
                cmdKayit.Parameters["@DegismeTarihi"].Direction = ParameterDirection.Output;

                cmdKayit.Parameters.Add("@DegistirenID", SqlDbType.Int, 0).Value = -1;
                cmdKayit.Parameters.Add("@OdendiMi", SqlDbType.Bit, 0).Value = DROW["OdendiMi"];

                cmdKayit.Parameters.Add("@FaturaTipi", SqlDbType.Int, 0).Value = clsTablolar.IslemTipi.SatisFaturasi; // 1 Satış faturası oluyor
                //cmdKayit.Parameters.Add("@Tarih", SqlDbType.DateTime);

                int EtkilenenSatirSayisi = cmdKayit.ExecuteNonQuery();


                if (EtkilenenSatirSayisi == 0 || EtkilenenSatirSayisi == -1) // etkilenen satır sayısı 0 ise kayıt gerçekleşmememiş
                // ve büyük ihtimalle ödemesi tamamlandığı için etkilenen satır sayısı 0 olmuştur.
                { // burada kaldın hamısına ahahah
                    return -5;
                    //throw new Exception(); // burası böyle olmaz bunu düzelt
                }
                if ((int)DROW["FaturaID"] == -1)
                {
                    DROW["FaturaID"] = cmdKayit.Parameters["@FaturaID"].Value;
                    _FaturaID = (int)cmdKayit.Parameters["@FaturaID"].Value;
                    DROW["FaturaBarkod"] = cmdKayit.Parameters["@Barkod"].Value;
                    DROW["FaturaTarihi"] = cmdKayit.Parameters["@Tarih"].Value;
                    DROW["FaturaNo"] = cmdKayit.Parameters["@HesaplananFaturaNo"].Value;

                    DROW.AcceptChanges(); // ahanda bu çok önemli bunu kaldıracağın zaman yeni müşteriden sonra tek bir hareket ekle yenileye bas bakalım doğrumu diye de kontrol et
                }
                DROW["DegismeTarihi"] = cmdKayit.Parameters["@DegismeTarihi"].Value;


                //SatisGetir(DROW, false);




                return _FaturaID;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                cmdKayit.Dispose();
            }
        }

        public void SatisinAltToplamHesaplamalariniServerdanHesaplaveKaydet(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (SqlCommand cmddd = new SqlCommand("FaturaAltHesaplamalariniYenidenHesaplaKaydet", Baglanti, Tr))
            {
                cmddd.CommandType = CommandType.StoredProcedure;
                cmddd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;

                cmddd.ExecuteNonQuery(); // aslında burada bişi geri döndürsen ve farklılık varsa hareket detayını getirebilir.
            }
        }

        public string OdemesiYapilanSatisiGeriGetir(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            if (FaturaID != -1)
                using (SqlCommand cmd = new SqlCommand(@"update CariHr set SilindiMi = 1 where FaturaID = @FaturaID and silindiMi = 0
update KasaHareket set SilindiMi = 1 
where KasaHrID = 
(select KasaHrID from CariHr where FaturaID = @FaturaID and SilindiMi = 0)", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;

                    cmd.ExecuteNonQuery();
                    //using (SqlDataReader dr = cmd.ExecuteReader())
                    //{
                    //    return SatisGetir(dr, false);
                    //}
                }
            return string.Empty;
        }

        public int FaturaBarkodtanSatisiGetir(SqlConnection baglanti, SqlTransaction Tr, string _FaturaBarkod)
        {
            if (string.IsNullOrEmpty(_FaturaBarkod))
                return -1;

            using (SqlCommand cmd = new SqlCommand("FaturaBarkodtanSatisiGetir", baglanti))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Transaction = Tr;

                cmd.Parameters.Add("@FaturaBarkod", SqlDbType.NVarChar).Value = _FaturaBarkod;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    //lock (csthreadsafe.ThreadKilit)
                    {
                        string barkodno = SatisGetir(dr, true);
                        if (string.IsNullOrEmpty(barkodno)) // -1 dönmüşse demektir ki bu satış yok veya ödemesi alınmış ama burasını baya bi değiştir
                            return -1;
                        else
                            return 1;
                    }
                }
            }
        }

        public void FaturaIDdenFaturayiYenile(SqlConnection baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (SqlCommand commd = new SqlCommand(@"select fatura.FaturaID, FaturaTipi, FaturaTarihi, fatura.DuzenlemeTarihi, FaturaNo, CariID, CariKod, CariTanim, VergiDairesi, VergiNo, Adres, Il, Ilce, 
Vadesi, Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DegistirenID, DegismeTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz, 
CariIskontoToplami , StokIskontoToplami,    ToplamIndirim, ToplamKdv, IskontoluToplam, FaturaTutari, KullanilanFiyatTanimID, SiparisID, FaturaGrupID, OdendiMi, FaturaBarkod
from Fatura  with(nolock, index = IX_Fatura_2)
where fatura.OdendiMi = 0 and fatura.SilindiMi = 0 and Fatura.FaturaID = @FaturaID", baglanti, Tr))
            {
                commd.Parameters.Add("@FaturaID", SqlDbType.Int, 0).Value = FaturaID;
                using (SqlDataReader dr = commd.ExecuteReader())
                {
                    SatisGetir(dr, false);
                }
            }
        }

        public int SatislariBirlestir(SqlConnection Baglanti, SqlTransaction Tr, string BarkodNuBir, string BarkodNuIki)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("FaturaBirlestirBarkodlarindan", Baglanti, Tr);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@FaturaBarkodBir", SqlDbType.NVarChar).Value = BarkodNuBir;
                cmd.Parameters.Add("@FaturaBarkodIki", SqlDbType.NVarChar).Value = BarkodNuIki;

                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return -1;
                throw;
            }
        }

        public void OdemesiYapilanSatislar(SqlConnection Baglanti, SqlTransaction Tr)
        {
            //using (SqlCommand cmdKasaOdenenler = new SqlCommand())
            //{




            //}
        }

        public void OkcFisBilgileriniKaydet(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID, int ZNo, int FisNo)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = " update Fatura set OkcZNo = @OkcZNo, OkcFisNo = @OkcFisNo where FaturaID = @FaturaID ";
            cmd.Parameters.Add("@OkcZNo", SqlDbType.Int).Value = ZNo;
            cmd.Parameters.Add("@OkcFisNo", SqlDbType.Int).Value = FisNo;
            cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;

            cmd.ExecuteNonQuery();
        }

        EvrakIliski.csEvrakIliski evrakIliski;

        public enum SiparisDonenBilgi
        {
            IslemTamam = 1,
            SiparisDahaOnceSatisaAktarilmis = 2,
            Hata = 3
        }


        public delegate bool dlg_StokSec(int StokID);
        public dlg_StokSec StokEkle;

        //    public SiparisDonenBilgi SiparisiSatisaAktarma(int SiparisID, SqlConnection Baglanti, SqlTransaction Tr, cari.csCariv2 CariBilgi, clsTablolar.Fatura.csFaturaHareket hareket)
        //    {
        //        try
        //        {
        //            evrakIliski = new clsTablolar.EvrakIliski.csEvrakIliski();

        //            //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        //            if (evrakIliski.SiparisFaturayaAktarilmisMi(Baglanti, Tr, SiparisID) == clsTablolar.EvrakIliski.csEvrakIliski.SiparisinFaturayaAktarilmaDurumu.Faturalandi)
        //            {
        //                //TrGenel.Commit();
        //                //MesajGoster("Daha Önce Satışa Aktarılmış");
        //                return SiparisDonenBilgi.SiparisDahaOnceSatisaAktarilmis;
        //            }

        //            //lock (clsTablolar.TeraziSatisClaslari.csthreadsafe.ThreadKilit)
        //            //{
        //            //    using (clsTablolar.Siparis.csSiparis Siparis = new clsTablolar.Siparis.csSiparis(Baglanti, Tr, SiparisID))
        //            //    {

        //            //        //CariGetir(Siparis.CariID);
        //            //        YeniKayitAc(CariBilgi);

        //            //        //gvSatislar.MoveLast();
        //            //        //gvSatislar.FocusedRowHandle = gvSatislar.RowCount - 1;

        //            //        int SonIndexNo = dt_threadSatislar.Rows.Count - 1;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["CariID"] = Siparis.CariID;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["CariKod"] = Siparis.CariKod;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["CariTanim"] = Siparis.CariTanim;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["VergiDairesi"] = Siparis.VergiDairesi;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["VergiNo"] = Siparis.VergiNo;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["Adres"] = Siparis.Adres;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["Il"] = Siparis.Il;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["Ilce"] = Siparis.Ilce;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["Aciklama"] = Siparis.Aciklama;


        //            //        dt_threadSatislar.Rows[SonIndexNo]["Aciklama"] = Siparis.Aciklama;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["SatisElemaniID"] = Siparis.SatisElemaniID;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["Toplam_Iskontosuz_Kdvsiz"] = Siparis.Toplam_Iskontosuz_Kdvsiz;

        //            //        dt_threadSatislar.Rows[SonIndexNo]["CariIskontoToplami"] = Siparis.CariIskontoToplami;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["StokIskontoToplami"] = Siparis.StokIskontoToplami;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["ToplamIndirim"] = Siparis.ToplamIndirim;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["ToplamKdv"] = Siparis.ToplamKdv;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["IskontoluToplam"] = Siparis.IskontoluToplam;
        //            //        dt_threadSatislar.Rows[SonIndexNo]["FaturaTutari"] = Siparis.SiparisTutari;

        //            //        clsTablolar.Siparis.csSiparisHareket SiparisHareketi = new clsTablolar.Siparis.csSiparisHareket(Baglanti, Tr, SiparisID);
        //            //        for (int i = 0; i < SiparisHareketi.dt_SiparisHareketleri.Rows.Count; i++)
        //            //        {

        //            //            if (StokEkle((int)SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokID"]))
        //            //            {
        //            //                int HareketSonIndexNo = hareket.dt_FaturaHareketleri.Rows.Count - 1;
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["FaturaHareketStokAdi"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["SiparisHareketStokAdi"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Miktar"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Miktar"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokAnaBirimID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokAnaBirimID"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["AnaBirimFiyat"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["AnaBirimFiyat"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Birim2ID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Birim2ID"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["KatSayi"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["KatSayi"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Birim2Fiyat"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Birim2Fiyat"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Kdv"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Kdv"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["Toplam"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["Toplam"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokIskonto1"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokIskonto1"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokIskonto2"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokIskonto2"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokIskonto3"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokIskonto3"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariIskonto1"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariIskonto1"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariIskonto2"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariIskonto2"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariIskonto3"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariIskonto3"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["IskontoluFiyat"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["IskontoluFiyat"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["SatirIndirimliToplam"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["SatirIndirimliToplam"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["SatirAciklama"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["SatirAciklama"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["DepoID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["DepoID"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["CariToplamIskonto"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["CariToplamIskonto"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["StokToplamIskonto"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["StokToplamIskonto"];


        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["ToplamIskonto"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["ToplamIskonto"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["KdvTutari"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["KdvTutari"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["AltBirimMiktar"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["AltBirimMiktar"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["FireMiktari"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["FireMiktari"];
        //            //                hareket.dt_FaturaHareketleri.Rows[HareketSonIndexNo]["BirlesikUrunHareketID"] = SiparisHareketi.dt_SiparisHareketleri.Rows[i]["BirlesikUrunHareketID"];
        //            //            }
        //            //        }

        //            //        //Hesapla.AltToplamlariHesapla();

        //            //        evrakIliski.FaturaEvrakIlıski_BosSatirEkle();
        //            //        //evrakIliski.dt.Rows[0][""] = 
        //            //        //evrakIliski.FaturadanEvrakIliskiGetir(SqlConnections.GetBaglanti(), TrGenel, (int)Satislarv2.dt_threadSatislar.Rows[SonIndexNo]["FaturaID"]);
        //            //        evrakIliski.dt.Rows[0]["SiparisID"] = SiparisID;
        //            //        evrakIliski.FaturaIcinEvrakIliskiKaydet(Baglanti, Tr, (int)dt_threadSatislar.Rows[SonIndexNo]["FaturaID"]);
        //                //}

        //                // ahanda bunu frm terazide olacak
        //                //cbtnTerazidekiSabitMiktariStokaAktar.Checked = false;

        //                return SiparisDonenBilgi.IslemTamam;
        //        //    }
        //        //}
        //        //catch (Exception ex)
        //        //{
        //        //    return SiparisDonenBilgi.Hata;
        //        //}
        //    }






    }
}


