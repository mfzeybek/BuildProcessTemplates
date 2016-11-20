using System;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.ServiceModel.Channels;
using System.ServiceModel;


namespace Aresv2  // burasının mantığını olduğu gibi açıklaman lazım
{
    public class csHemenAlGetSet : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DataTable dt_Gelen = new DataTable();

        public HemenAlServis.hemenalserviceSoapClient Get_Set_Fonksiyonlari;


        public csHemenAlGetSet() // önce bu çalışır hemenal da bağlantı kurulur hamısına
        {
            try
            {
                CustomBinding binding = (CustomBinding)CreateDefaultBinding();
                binding.SendTimeout = new TimeSpan(10,10,10);
                Get_Set_Fonksiyonlari = new HemenAlServis.hemenalserviceSoapClient(binding, new EndpointAddress("http://www.cikolatacerez.com/service/hemenal.asmx"));

                if (Get_Set_Fonksiyonlari.Auth(frmKullaniciGiris.HemenAl_Auth_Code, frmKullaniciGiris.HemenAl_username, frmKullaniciGiris.HemenAl_password) == "False")
                {
                    XtraMessageBox.Show("HemenAl Entegrasyon Bilgileri Doğrulanamadı.\n İşlem İptal Edilecek.", "Ares", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        /// <summary>
        /// hemen al ın fonksiyonlarının burada kullanabilriz ilerde belki bunu private yaparım
        /// </summary>
        /// <param name="Get_Set_Fonksiyonlariii"></param>
        /// <returns></returns>
        public DataTable csHemenAlStringToDatatablesds(string HemenaldanGelen)
        {
            //Get_Set_Fonksiyonlari.ClientCredentials.w
            try
            {
                XmlDocument GelenTumveri = new XmlDocument();

                GelenTumveri.LoadXml(HemenaldanGelen.ToString());

                XmlReader xmlReader = new XmlNodeReader(GelenTumveri);
                DataSet dsGelen = new DataSet();
                dt_Gelen.Clear();
                dsGelen.ReadXml(xmlReader);
                if (dsGelen.Tables.Count == 0)
                {
                    XtraMessageBox.Show("Siteden bilgiler okunamadı.");
                    //this.Close();
                }
                else
                {
                    dt_Gelen = dsGelen.Tables[0];
                    //gridControl1.DataSource = dt_Gelen;
                }
                return dt_Gelen;
            }
            catch (Exception hata)
            {
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
                throw new Exception(hata.Message);
            }
        }

        public string HememAl_SetUrun(SqlConnection Baglanti, SqlTransaction trGenel, int StokID)
        {
            try
            {
                string cevap = "";
                using (SqlCommand cmd = new SqlCommand(@"
SELECT DISTINCT 
                      dbo.Stok.StokKodu, dbo.Stok.StokAdi, dbo.Stok.Garanti, dbo.StokMarka.StokMarka,stok.HemenAlKategoriID  , 
                      dbo.Stok.KisaAciklama, dbo.Stok.DetayliUrunBilgisi,stok.HemenAlAnahtarKelime ,(SonkullanicFiyati.Fiyat /((100 + Stok.SatisKdv) / 100)) AS SonKullanici, BayiFiyati.Fiyat AS BayiFiyati, OzelFiyati.Fiyat AS OzelFiyati, 
                      PiyasaFiyati.Fiyat AS PiyasaFiyati, dbo.Stok.SatisKdv, Stok.HemenAlDrum, StokResim.Ftp, EticaretStoktaVarsaDurumTanimi.EticaretStokDurumTanimID as StokdaVarDurumID, EticaretStoktaYoksaDurumTanimi.EticaretStokDurumTanimID as StoktaYokDurumID, Stok.HemenAlSira
FROM         dbo.Stok LEFT OUTER JOIN
                      dbo.StokAraGrup ON dbo.Stok.StokAraGrupID = dbo.StokAraGrup.StokAraGrupID LEFT OUTER JOIN
                      dbo.StokGrup ON dbo.Stok.StokGrupID = dbo.StokGrup.StokGrupID LEFT OUTER JOIN
                      dbo.StokMarka ON dbo.Stok.StokMarkaID = dbo.StokMarka.StokMarkaID CROSS JOIN
                      dbo.HemenAlEntegrasyon LEFT OUTER JOIN
                      dbo.StokFiyat AS SonkullanicFiyati ON dbo.HemenAlEntegrasyon.SKFiyatTanimID = SonkullanicFiyati.FiyatTanimID AND 
                      SonkullanicFiyati.StokID = dbo.Stok.StokID LEFT OUTER JOIN
                      dbo.StokFiyat AS BayiFiyati ON dbo.HemenAlEntegrasyon.BayiFiyatTanimID = BayiFiyati.FiyatTanimID AND BayiFiyati.StokID = dbo.Stok.StokID LEFT OUTER JOIN
                      dbo.StokFiyat AS PiyasaFiyati ON dbo.HemenAlEntegrasyon.PiyasaFiyatTanimID = PiyasaFiyati.FiyatTanimID AND 
                      PiyasaFiyati.StokID = dbo.Stok.StokID LEFT OUTER JOIN
                      dbo.StokFiyat AS OzelFiyati ON dbo.HemenAlEntegrasyon.OzelFiyatTanimID = OzelFiyati.FiyatTanimID AND OzelFiyati.StokID = dbo.Stok.StokID
					  left outer join StokResim on StokResim.StokID = Stok.StokID and StokResim.Varsayilan = 1
					  left join EticaretStokDurumTanimlari as EticaretStoktaVarsaDurumTanimi on EticaretStoktaVarsaDurumTanimi.ID = stok.EticaretStokDurumID_StoktaVarsa
					  left join EticaretStokDurumTanimlari as EticaretStoktaYoksaDurumTanimi on EticaretStoktaYoksaDurumTanimi.ID = stok.EticaretStokDurumID_StoktaVarsa
where Stok.StokID = @StokID
", SqlConnections.GetBaglanti(), trGenel))
                {
                    cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult)) //SQL SELECT İFADESİNDEN GELEN BİLGİLERİN SADECE KOLON BAŞLIKLARINI VE İÇERİK DEĞERLERİNİ GETİR DEMEK.
                    {
                        if (dr.Read())
                        {
                            //cevap = Get_Set_Fonksiyonlari.SetUrun1("Ares", "", dr["StokKodu"].ToString(), dr["StokKodu"].ToString(),
                            //  dr["StokMarka"].ToString(), dr["HemenAlKategoriID"].ToString(), dr["StokAdi"].ToString(), dr["KisaAciklama"].ToString(),
                            //  dr["DetayliUrunBilgisi"].ToString(), dr["Ftp"].ToString(), dr["SonKullanici"].ToString(), dr["BayiFiyati"].ToString(), dr["OzelFiyati"].ToString(),
                            //  dr["PiyasaFiyati"].ToString(), "TL", dr["SatisKdv"].ToString(), "", "1", dr["StokdaVarDurumID"].ToString(), dr["StoktaYokDurumID"].ToString(), dr["Garanti"].ToString(), "", dr["HemenAlDrum"].ToString(), "", dr["HemenAlSira"].ToString(), "", dr["HemenAlAnahtarKelime"].ToString(), "", "", "", "");
                            Get_Set_Fonksiyonlari.SetUrun1Async("Ares", "", dr["StokKodu"].ToString(), dr["StokKodu"].ToString(),
                              dr["StokMarka"].ToString(), dr["HemenAlKategoriID"].ToString(), dr["StokAdi"].ToString(), dr["KisaAciklama"].ToString(),
                              dr["DetayliUrunBilgisi"].ToString(), dr["Ftp"].ToString(), dr["SonKullanici"].ToString(), dr["BayiFiyati"].ToString(), dr["OzelFiyati"].ToString(),
                              dr["PiyasaFiyati"].ToString(), "TL", dr["SatisKdv"].ToString(), "", "1", dr["StokdaVarDurumID"].ToString(), dr["StoktaYokDurumID"].ToString(), dr["Garanti"].ToString(), "", dr["HemenAlDrum"].ToString(), "", dr["HemenAlSira"].ToString(), "", dr["HemenAlAnahtarKelime"].ToString(), "", "", "", "");
                            //cevap = Get_Set_Fonksiyonlari.SetUrun("Ares", "", dr["StokKodu"].ToString(), dr["StokKodu"].ToString(),
                            //  dr["StokMarka"].ToString(), dr["StokGrupAdi"].ToString(), dr["StokAdi"].ToString(), dr["KisaAciklama"].ToString(), dr["DetayliUrunBilgisi"].ToString(), "", dr["SonKullanici"].ToString(), dr["BayiFiyati"].ToString(), dr["OzelFiyati"].ToString(),
                            //  dr["PiyasaFiyati"].ToString(), "TL", dr["SatisKdv"].ToString(), "", "1", "", "", "0", "", "");
                        }
                    }
                    if (cevap.Split('|')[0].ToString() == "True" && cevap.Split('|').Length == 2)
                    { // hemenaldaki stokID dönüyor ve stok detay da kayıt ediyor
                        StokHemenAlIDGuncelle(Baglanti, trGenel, StokID, Convert.ToInt32(cevap.Split('|')[1].ToString()));
                        return cevap.Split('|')[1].ToString();
                    }
                    else
                    {
                        return cevap;
                    }
                }


            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }


        public string HemenAl_SetSecenek(SqlConnection Baglanti, SqlTransaction TrGenel, int StokID)
        {
            try
            {
                string cevap = "";

                // union la 2 tablo birliştirildi hem hamısına buraya adam gibi bir açıklama lazım
                using (SqlCommand cmd = new SqlCommand(@"
select stok.StokKodu,SecenekID ,SecenekGrubu , SatirSecenek, SutunSecenek, Kavala, Sira, (SatisFiyat /((100 + Stok.SatisKdv) / 100)) as SatisFiyat, null as StokMiktar, 
GoruntulemeSekli, StokKontrol, UrunFiyatiYerineGecsin, SeciliGelsin, SecimZorunlu, SecenekAktif from HemenAlUrunSecenek
inner join Stok ON Stok.StokID = HemenAlUrunSecenek.StokID
WHERE     (HemenAlUrunSecenek.StokID = @StokID)

union

select Stok.StokKodu, null ,SecenekGrubu, SatirSecenek, SutunSecenek, Kavala, Sira, 
'dsadsad' = case SatisFiyatiHesaplamaIslemi
when 1 then  ((SonkullanicFiyati.Fiyat + SatisFiyatiHesaplamaSayisi)/((100 + Stok.SatisKdv) / 100))
when 2 then  ((SonkullanicFiyati.Fiyat - SatisFiyatiHesaplamaSayisi) /((100 + Stok.SatisKdv) / 100))
when 3 then  ((SonkullanicFiyati.Fiyat * SatisFiyatiHesaplamaSayisi) /((100 + Stok.SatisKdv) / 100))
when 4 then  ((SonkullanicFiyati.Fiyat / SatisFiyatiHesaplamaSayisi) /((100 + Stok.SatisKdv) / 100))
end , null,
GoruntulemeSekli, StokKontrol, UrunFiyatiYerineGecsin, SeciliGelsin, SecimZorunlu, SecenekAktif
SatisFiyatiHesaplamaIslemi from HemenAlUrunSecenekOnTanimDetaylari
inner join dbo.HemenAlUrunSecenekOnTanım_Stok on dbo.HemenAlUrunSecenekOnTanım_Stok.HemenAlUrunSecenekOnTanimID = HemenAlUrunSecenekOnTanimDetaylari.HemenAlUrunSecenekOnTanimID
inner join Stok ON Stok.StokID = HemenAlUrunSecenekOnTanım_Stok.StokID
CROSS JOIN HemenAlEntegrasyon
left join
dbo.StokFiyat AS SonkullanicFiyati ON dbo.HemenAlEntegrasyon.SKFiyatTanimID = SonkullanicFiyati.FiyatTanimID
 AND SonkullanicFiyati.StokID = Stok.StokID
 WHERE     (HemenAlUrunSecenekOnTanım_Stok.StokID = @StokID)
 ", SqlConnections.GetBaglanti(), TrGenel))
                {
                    cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        { // saçma birşekilde miktar kısmı dolu ise hata veriyor acaba neden belki stok miktarından fazla miktar yazıldığında vb olabilir
                            cevap = Get_Set_Fonksiyonlari.SetSecenek("Ares", dr["StokKodu"].ToString(), dr["SecenekGrubu"].ToString(), "", "", dr["SatirSecenek"].ToString(),
                              dr["SutunSecenek"].ToString(), dr["Kavala"].ToString(), dr["Sira"].ToString(), dr["SatisFiyat"].ToString(),
                              dr["StokMiktar"].ToString(), dr["GoruntulemeSekli"].ToString(), dr["StokKontrol"].ToString(), dr["UrunFiyatiYerineGecsin"].ToString(), dr["SeciliGelsin"].ToString(),
                              dr["SecimZorunlu"].ToString(), dr["SecenekAktif"].ToString());

                            //cevap = Get_Set_Fonksiyonlari.SetUrun("Ares", "", dr["StokKodu"].ToString(), dr["StokKodu"].ToString(),
                            //  dr["StokMarka"].ToString(), dr["StokGrupAdi"].ToString(), dr["StokAdi"].ToString(), dr["KisaAciklama"].ToString(), dr["DetayliUrunBilgisi"].ToString(), "", dr["SonKullanici"].ToString(), dr["BayiFiyati"].ToString(), dr["OzelFiyati"].ToString(),
                            //  dr["PiyasaFiyati"].ToString(), "TL", dr["SatisKdv"].ToString(), "", "1", "", "", "0", "", "");
                        }
                    }
                    if (cevap.Split('|')[0].ToString() == "True" && cevap.Split('|').Length == 2)
                    {
                        //StokHemenAlIDGuncelle(Baglanti, TrGenel, StokID, Convert.ToInt32(cevap.Split('|')[1].ToString())); 
                        return cevap.Split('|')[1].ToString();
                    }
                    else
                    {
                        return cevap;
                    }
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }

        public void HemenAl_SetFoto(string url, string StokKodu)
        {
            Get_Set_Fonksiyonlari.SetUrun("Ares", "", StokKodu, StokKodu, "", "", "", "", "", url, "", "", "", "", "", "", "", "99", "", "", "", "", "");
        }

        private void StokHemenAlSecenek_SecenekIDGuncelle(SqlConnection Baglanti, SqlTransaction Trgenel, int SecenekID)
        {


        }

        private static System.ServiceModel.Channels.Binding CreateDefaultBinding()
        {
            System.ServiceModel.Channels.CustomBinding binding = new System.ServiceModel.Channels.CustomBinding();
            binding.Elements.Add(new System.ServiceModel.Channels.TextMessageEncodingBindingElement(System.ServiceModel.Channels.MessageVersion.Soap11, System.Text.Encoding.UTF8));
            System.ServiceModel.Channels.HttpTransportBindingElement http = new System.ServiceModel.Channels.HttpTransportBindingElement();
            http.MaxBufferPoolSize = Int32.MaxValue;
            http.MaxBufferSize = Int32.MaxValue;
            http.MaxReceivedMessageSize = Int32.MaxValue;
            http.TransferMode = System.ServiceModel.TransferMode.Buffered;
            binding.Elements.Add(http);
            return binding;
        }

        private void StokHemenAlIDGuncelle(SqlConnection Baglanti, SqlTransaction TrGenel, int StokID, int HemenAlID)
        {
            using (SqlCommand cmd2 = new SqlCommand("update Stok set HemenAlID = @HemenAlID where StokID = @StokID", Baglanti, TrGenel)) // buraya hemen aldan gelen hemenAl ID yi yazıcaz
            {
                cmd2.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                cmd2.Parameters.Add("@HemenAlID", SqlDbType.Int).Value = HemenAlID;
                cmd2.ExecuteNonQuery();
            }
        }

    }
}
