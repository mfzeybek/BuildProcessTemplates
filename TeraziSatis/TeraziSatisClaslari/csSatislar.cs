using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;

namespace TeraziSatis.cls
{
    public class csSatislar: IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        SqlDataAdapter da;
        //public DataTable dt;

        SqlDataReader dr;

        string SqlSelectCumlesi = @"select * from Fatura
inner join TeraziFaturaIliski on TeraziFaturaIliski.FaturaID = Fatura.FaturaID ";

        //Thread thSatislar; 





        // Fatura Tablosuna Kayıt işlemleri için hamısına (faturaHarekete değil dikkat hamısına)

        /// <summary>
        /// TeraziID yi vererek O terazide işlem yapmış tüm 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="TeraziID"></param>
        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            da = new SqlDataAdapter(SqlSelectCumlesi + @" where (Fatura.OdendiMi is null or fatura.OdendiMi = 0)  and fatura.SilindiMi = 0
and TeraziFaturaIliski.TeraziID = @TeraziID", Baglanti); //TODO: sql e eklenmesi gerekenlerden ödemesi yapılan fatura getirilmeyecek

            da.SelectCommand.Transaction = Tr;
            da.SelectCommand.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziSatis.Properties.Settings.Default.TeraziID;
            da.RowUpdated += da_RowUpdated;

            //thSatislar = new Thread(new ThreadStart(SatislariGetir));
            //thSatislar.Start();



            dt_satislar = new DataTable();
            da.Fill(dt_satislar);
            dt_satislar.TableNewRow += dt_satislar_TableNewRow;
            //thSatislar = new Thread(new ThreadStart(bunuyap));
            //thSatislar.Start();
        }

        public DataTable dt_satislar;

        //void bunuyap()
        //{
        //    //da.SelectCommand.Parameters.Add("@SonFaturaID", SqlDbType.Int).Value = SonFaturaID;
        //    try
        //    {
        //        System.Timers.Timer timerrr = new System.Timers.Timer(10000);
        //        timerrr.Elapsed += timerrr_Elapsed;
        //        timerrr.Start();
        //    }
        //    catch (Exception)
        //    {


        //    }
        //}

        //void timerrr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        //{
        //    da.Fill(dt_satislar);
        //}

        void dt_satislar_TableNewRow(object sender, DataTableNewRowEventArgs e)
        {
            e.Row["FaturaID"] = -1;
            e.Row["Toplam_Iskontosuz_Kdvsiz"] = 0;
            e.Row["CariIskontoToplami"] = 0;
            e.Row["StokIskontoToplami"] = 0;
            e.Row["ToplamIndirim"] = 0;
            e.Row["ToplamKdv"] = 0;
            e.Row["IskontoluToplam"] = 0;
            e.Row["FaturaTutari"] = 0;
            e.Row["Iptal"] = false;
            e.Row["SilindiMi"] = false;
            e.Row["Aciklama"] = "";
            e.Row["FaturaNo"] = "";
            e.Row["CariKod"] = "";
            e.Row["CariTanim"] = "";
            e.Row["VergiDairesi"] = "";
            e.Row["VergiNo"] = "";
            e.Row["Adres"] = "";
            e.Row["Il"] = "";
            e.Row["Ilce"] = "";
            e.Row["KaydedenID"] = -1;
            e.Row["KullanilanFiyatTanimID"] = clsTablolar.Ayarlar.csAyarlar.SatisFaturasiFiyatTanimID;
            e.Row["OdendiMi"] = 0;
        }


        /// <summary>
        /// Odemesi Yapılmayan satışların ID leri
        /// Bu Id lerle kendi tablonu karşılaştır, ödemesi yapılanları remove yap
        /// </summary>
        public void OdemesiYapilmayanSatislar(SqlConnection baglanti, SqlTransaction Tr, int TeraziID)
        {
            SqlCommand cmd = new SqlCommand(@"select Fatura.FaturaID from Fatura
inner join TeraziFaturaIliski on TeraziFaturaIliski.FaturaID = Fatura.FaturaID 
where (Fatura.OdendiMi is null or fatura.OdendiMi = 0) and fatura.SilindiMi = 0", baglanti, Tr);

            using (dr = cmd.ExecuteReader())
            {
                int[] IDler = new int[dr.RecordsAffected];

                for (int i = 0; i < IDler.Count(); i++)
                {
                    IDler[i] = (int)dr["FaturaID"];
                } // burada kaldın devam edersin
            }
        }


        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
            {
                e.Row["FaturaID"] = e.Command.Parameters["@YeniFaturaID"].Value;
                e.Row["FaturaBarkod"] = e.Command.Parameters["@Barkod"].Value;
                e.Row["FaturaTarihi"] = DateTime.Now;
            }
        }
        /// <summary>
        /// heee hamısına buraya ilk almasını istediğim değerleri yazabilirim.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        /// <summary>
        /// Terazilerin ana Ekranına (frmTerazi ekrandaki) sadece o terazide satış yapılan müşteriler listelenecek başka bir terazide yapılan işlemleri
        /// Ana ekrana (frmTerazi ekrandaki) eklenmesi için kullanılan fonksiyon
        /// </summary>
        public void FaturaIDdenTerazideIslemYapilanlaraEkle(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            // burada TeraziFaturaIliski Tablosuna verilen TeraziID yi Ekliyioruz csTeraziSatis taki dt yede Yeni Satır Açıp (ki bu tabloda) bu 



        }

        public void TumMusterilerinSatislariniGoster(SqlConnection Baglanti, SqlTransaction Tr)
        {


        }

        //public void OdemesiYap

        public void SatisiKaydet(SqlConnection Baglanti, SqlTransaction Tr) // teraziden faturaa kaydeder yani hamısına
        {
            try
            {
                da.InsertCommand = new SqlCommand(@"
declare @InputUPC nvarchar(20)
DECLARE @Sum int
declare @Tekler int = 0
declare @Ciftler int = 0
DECLARE @ChkDgt nchar(1)
--declare @Barkod nvarchar(40)
set @InputUPC = (select CONVERT(nvarchar, BarkodAyar.OnEk) + CONVERT(nvarchar, GETDATE(), 12) +replicate('0', BarkodAyar.KacHaneKod - len(BarkodAyar.SiradakiKod)) +convert(nvarchar, BarkodAyar.SiradakiKod) from BarkodAyar
where BarkodAyar.BarkodunKullanildigiYer = 2)
SET @Sum = 0
declare @i int = 1

while len(@InputUPC) >= @i
begin
if (@i %2 = 0)
begin
set @Ciftler += SUBSTRING(@InputUPC, len(@InputUPC) - @i +1, 1)
end else
begin
set @tekler += SUBSTRING(@InputUPC, len(@InputUPC) - @i + 1, 1)
end
set @i += 1 
end
set @Sum = (3 * @Tekler) + @Ciftler
--set @ChkDgt = 10 - (@Sum % 10)
IF (@Sum % 10) = 0 BEGIN SET @ChkDgt = '0' END
ELSE IF (@Sum % 10) = 1 BEGIN SET @ChkDgt = '9' END
ELSE IF (@Sum % 10) = 2 BEGIN SET @ChkDgt = '8' END
ELSE IF (@Sum % 10) = 3 BEGIN SET @ChkDgt = '7' END
ELSE IF (@Sum % 10) = 4 BEGIN SET @ChkDgt = '6' END
ELSE IF (@Sum % 10) = 5 BEGIN SET @ChkDgt = '5' END
ELSE IF (@Sum % 10) = 6 BEGIN SET @ChkDgt = '4' END
ELSE IF (@Sum % 10) = 7 BEGIN SET @ChkDgt = '3' END
ELSE IF (@Sum % 10) = 8 BEGIN SET @ChkDgt = '2' END
ELSE IF (@Sum % 10) = 9 BEGIN SET @ChkDgt = '1' END

ELSE BEGIN SET @ChkDgt = 'Z' END

update BarkodAyar set BarkodAyar.SiradakiKod += 1 




insert into Fatura 
( FaturaTipi, FaturaTarihi, DuzenlemeTarihi, Vadesi,FaturaNo, CariID,
Iptal, SilindiMi, Aciklama, KaydedenID, KayitTarihi, DepoID, SatisElemaniID, Toplam_Iskontosuz_Kdvsiz,
CariIskontoToplami, StokIskontoToplami, ToplamIndirim, ToplamKdv, IskontoluToplam, FaturaTutari, KullanilanFiyatTanimID, FaturaGrupID , OdendiMi, FaturaBarkod )
values 
( @FaturaTipi, @Tarih, @Tarih, @Tarih, @FaturaNo, @CariID,
@Iptal, @SilindiMi, @Aciklama, @KaydedenID, @KayitTarihi, @DepoID, @SatisElemaniID,
@Toplam_Iskontosuz_Kdvsiz, @CariIskontoToplami, @StokIskontoToplami, @ToplamIndirim, @ToplamKdv, @IskontoluToplam, @FaturaTutari, @KullanilanFiyatTanimID, @FaturaGrupID, @OdendiMi, @InputUPC + @ChkDgt) 

set @YeniFaturaID = SCOPE_IDENTITY()
set @Barkod = @InputUPC + @ChkDgt
insert into TeraziFaturaIliski (TeraziID, FaturaID) values (@TeraziID ,@YeniFaturaID)



", Baglanti); // TeraziFaturaIliski tablosuna sadece burada ekleme yaptık falan filan

                da.InsertCommand.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziSatis.Properties.Settings.Default.TeraziID;

                da.InsertCommand.Transaction = Tr;

                da.InsertCommand.Parameters.Add("@KaydedenID", SqlDbType.Int, 0, "KaydedenID"); // Terazi ID yazmaya gerek yok teraziId nin yazıldığı talo var ama ilerde personelID yazılabilir
                da.InsertCommand.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                da.InsertCommand.Parameters.Add("@YeniFaturaID", SqlDbType.Int, 0).Direction = ParameterDirection.Output;
                da.InsertCommand.Parameters.Add("@FaturaTipi", SqlDbType.Int, 0).Value = clsTablolar.IslemTipi.SatisFaturasi; // 1 Satış faturası oluyor
                da.InsertCommand.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = DateTime.Now;
                da.InsertCommand.Parameters.Add("@FaturaNo", SqlDbType.NVarChar, 0, "FaturaNo");
                da.InsertCommand.Parameters.Add("@CariID", SqlDbType.Int, 0, "CariID");
                da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama"); // bu olabilir açıklama yazılması istenebilir
                da.InsertCommand.Parameters.Add("@DepoID", SqlDbType.Int).Value = -1; // bu önemli hangi depodan satışın olduğu veya TeraziID den Alsın program şimdilik -1 dedim
                da.InsertCommand.Parameters.Add("@SatisElemaniID", SqlDbType.Int).Value = -1;
                da.InsertCommand.Parameters.Add("@Toplam_Iskontosuz_Kdvsiz", SqlDbType.Decimal, 0, "Toplam_Iskontosuz_Kdvsiz"); // bu önemli hamısına
                da.InsertCommand.Parameters.Add("@CariIskontoToplami", SqlDbType.Decimal, 0, "CariIskontoToplami"); // Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                da.InsertCommand.Parameters.Add("@StokIskontoToplami", SqlDbType.Decimal, 0, "StokIskontoToplami");// Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                da.InsertCommand.Parameters.Add("@ToplamIndirim", SqlDbType.Decimal, 0, "ToplamIndirim");// Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                da.InsertCommand.Parameters.Add("@ToplamKdv", SqlDbType.Decimal, 0, "ToplamKdv");
                da.InsertCommand.Parameters.Add("@IskontoluToplam", SqlDbType.Decimal, 0, "IskontoluToplam");
                da.InsertCommand.Parameters.Add("@FaturaTutari", SqlDbType.Decimal, 0, "FaturaTutari");
                da.InsertCommand.Parameters.Add("@KullanilanFiyatTanimID", SqlDbType.Int, 0, "KullanilanFiyatTanimID");
                da.InsertCommand.Parameters.Add("@FaturaGrupID", SqlDbType.Decimal).Value = -1;
                da.InsertCommand.Parameters.Add("@Iptal", SqlDbType.Bit).Value = 0;
                da.InsertCommand.Parameters.Add("@SilindiMi", SqlDbType.Bit, 0, "SilindiMi");
                da.InsertCommand.Parameters.Add("@OdendiMi", SqlDbType.Bit, 0, "OdendiMi");
                da.InsertCommand.Parameters.Add("@Barkod", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;



                da.UpdateCommand = new SqlCommand(@"update Fatura set FaturaTipi = @FaturaTipi, FaturaNo = @FaturaNo, CariID = @CariID, 
Iptal = @Iptal, SilindiMi = @SilindiMi, Aciklama = @Aciklama, DepoID = @DepoID, SatisElemaniID = @SatisElemaniID, Toplam_Iskontosuz_Kdvsiz = @Toplam_Iskontosuz_Kdvsiz, 
CariIskontoToplami = @CariIskontoToplami, StokIskontoToplami = @StokIskontoToplami, ToplamIndirim = @ToplamIndirim, ToplamKdv = @ToplamKdv, IskontoluToplam = @IskontoluToplam, FaturaTutari = @FaturaTutari, KullanilanFiyatTanimID = @KullanilanFiyatTanimID, FaturaGrupID = @FaturaGrupID,
DegistirenID = @DegistirenID, DegismeTarihi = @DegismeTarihi, OdendiMi = @OdendiMi

where FaturaID = @FaturaID", Baglanti);
                da.UpdateCommand.Transaction = Tr;


                da.UpdateCommand.Parameters.Add("@KaydedenID", SqlDbType.Int, 0, "KaydedenID");
                da.UpdateCommand.Parameters.Add("@FaturaTipi", SqlDbType.Int, 0).Value = clsTablolar.IslemTipi.SatisFaturasi; // 1 Satış faturası oluyor
                da.UpdateCommand.Parameters.Add("@FaturaNo", SqlDbType.NVarChar, 0, "FaturaNo"); // bu nereden alıcak hamısına
                da.UpdateCommand.Parameters.Add("@CariID", SqlDbType.Int, 0, "CariID");
                da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama"); // bu olabilir açıklama yazılması istenebilir
                da.UpdateCommand.Parameters.Add("@DepoID", SqlDbType.Int).Value = -1; // bu önemli hangi depodan satışın olduğu veya TeraziID den Alsın program şimdilik -1 dedim
                da.UpdateCommand.Parameters.Add("@SatisElemaniID", SqlDbType.Int).Value = -1;
                da.UpdateCommand.Parameters.Add("@Toplam_Iskontosuz_Kdvsiz", SqlDbType.Decimal, 0, "Toplam_Iskontosuz_Kdvsiz"); // bu önemli hamısına
                da.UpdateCommand.Parameters.Add("@CariIskontoToplami", SqlDbType.Decimal, 0, "CariIskontoToplami"); // Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                da.UpdateCommand.Parameters.Add("@StokIskontoToplami", SqlDbType.Decimal, 0, "StokIskontoToplami");// Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                da.UpdateCommand.Parameters.Add("@ToplamIndirim", SqlDbType.Decimal, 0, "ToplamIndirim");// Iskonto yapılabilecekmi Bilmiyorum hamısına eğer yapılamayacaksa faturadan açtığımızda oradan da yapılamaması lazım
                da.UpdateCommand.Parameters.Add("@ToplamKdv", SqlDbType.Decimal, 0, "ToplamKdv");
                da.UpdateCommand.Parameters.Add("@IskontoluToplam", SqlDbType.Decimal, 0, "IskontoluToplam");
                da.UpdateCommand.Parameters.Add("@FaturaTutari", SqlDbType.Decimal, 0, "FaturaTutari");
                da.UpdateCommand.Parameters.Add("@KullanilanFiyatTanimID", SqlDbType.Int, 0, "KullanilanFiyatTanimID");
                da.UpdateCommand.Parameters.Add("@FaturaGrupID", SqlDbType.Decimal).Value = -1;
                da.UpdateCommand.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = -1;
                da.UpdateCommand.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                da.UpdateCommand.Parameters.Add("@FaturaID", SqlDbType.Int, 0, "FaturaID");
                da.UpdateCommand.Parameters.Add("@Iptal", SqlDbType.Bit, 0, "Iptal");
                da.UpdateCommand.Parameters.Add("@SilindiMi", SqlDbType.Bit, 0, "SilindiMi");
                da.UpdateCommand.Parameters.Add("@OdendiMi", SqlDbType.Bit).Value = false;


                da.Update(dt_satislar);
            }
            catch (Exception)
            {

            }
        }


        public void TeraziFaturaIliskiKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {


        }



        SqlDataAdapter da_BarkodundanArama;
        public int BarkodNumarasindanFaturaBul(SqlConnection Baglanti, SqlTransaction Tr, string FaturaBarkodu)
        {
            try
            {
                da_BarkodundanArama = new SqlDataAdapter(SqlSelectCumlesi + @" 
where (Fatura.OdendiMi is null or fatura.OdendiMi = 0)  and fatura.SilindiMi = 0 and FaturaBarkod = @FaturaBarkod ", Baglanti);

                da_BarkodundanArama.SelectCommand.Transaction = Tr;
                da_BarkodundanArama.SelectCommand.Parameters.Add("@FaturaBarkod", SqlDbType.NVarChar).Value = FaturaBarkodu;

                //da_BarkodundanArama.
                return da_BarkodundanArama.Fill(dt_satislar);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        //isert into TeraziFaturaIliski (TeraziID, FaturaID) values (@TeraziID, @YeniFaturaID)
    }
}
