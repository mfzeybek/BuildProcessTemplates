using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
    public class csRaporDizayn : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public DataTable dt_Raporlar;
        public DataSet ds11;
        SqlDataAdapter da;
        public DataTable dtYaziciAyarlari;


        clsTablolar.Yazdirma.csYaziciBilgileri yaziciBilgileri = new Yazdirma.csYaziciBilgileri();

        /// <summary>
        /// Rarpor Dizayn ekranında kullanılacak sabit değer taşıyan RaporModul değişkeni
        /// </summary>
        public enum RaporModul
        {
            AlisFatura = IslemTipi.AlisFaturasi,
            SatisFatura = IslemTipi.SatisFaturasi,
            CariKarti = IslemTipi.CariKart,
            Stok = IslemTipi.StokKarti,
            StokSayim = IslemTipi.StokSayim,
            StokEtiket = IslemTipi.StokEtiket,
            CarliListe = IslemTipi.CariListe,
            CariHareket = IslemTipi.CariHareket,
            SiparisVerme = IslemTipi.SiparisVerme,
            BasitUretimRecetesi = IslemTipi.BasitUretimRecetesi
        };

        public void RaporDizaynYukle(SqlConnection Baglanti, RaporModul HangiModul)
        {
            using (da = new SqlDataAdapter(@"select RaporDizaynID, ModulNo, RaporDizaynYolu, Aciklama, VarsayilanMi
                --, CiftTarafliMi, KagitKaynagi, KagitTipi, RenkliMi, YaziciAdi, KagitKaynagiIndex 
                from RaporDizayn where ModulNo = @ModulNo ", Baglanti))
            {
                da.SelectCommand.Parameters.Add("@ModulNo", SqlDbType.Int).Value = HangiModul;

                using (dt_Raporlar = new DataTable())
                {
                    da.Fill(dt_Raporlar);
                    yaziciBilgileri.csYaziciBilgileriniGetir(Convert.ToInt32(HangiModul));

                    dt_Raporlar.Columns.Add("YaziciAdi");
                    dt_Raporlar.Columns.Add("KagitKaynagi");
                    dt_Raporlar.Columns.Add("KagitKaynagiIndex");
                    //dt_Raporlar.Columns.Add("Aciklama");



                    for (int i = 0; i < dt_Raporlar.Rows.Count; i++)
                    {
                        if (yaziciBilgileri.dt.Select("RaporDizaynID = " + dt_Raporlar.Rows[i]["RaporDizaynID"]).Length > 0)
                        {
                            dt_Raporlar.Rows[i]["YaziciAdi"] = yaziciBilgileri.dt.Select("RaporDizaynID = " + dt_Raporlar.Rows[i]["RaporDizaynID"])[0]["YaziciAdi"];
                            dt_Raporlar.Rows[i]["KagitKaynagi"] = yaziciBilgileri.dt.Select("RaporDizaynID = " + dt_Raporlar.Rows[i]["RaporDizaynID"])[0]["KagitKaynagi"];
                            dt_Raporlar.Rows[i]["KagitKaynagiIndex"] = yaziciBilgileri.dt.Select("RaporDizaynID = " + dt_Raporlar.Rows[i]["RaporDizaynID"])[0]["KagitKaynagiIndex"];
                            //dtYaziciAyarlari.Rows[i]["Aciklama"] = yaziciBilgileri.dt.Select("RaporDizaynID = " + dt_Raporlar.Rows[i]["RaporDizaynID"])[0]["Aciklama"];

                            //dt_Raporlar.Select("RaporDizaynID = " + yaziciBilgileri.dt.Rows[i]["RaporDizaynID"])[0][""] = yaziciBilgileri.dt.Select("RaporDizaynID = " + yaziciBilgileri.dt.Rows[i]["RaporDizaynID"])[0][""];
                        }
                        else
                        {
                            DataRow dr = yaziciBilgileri.dt.NewRow();
                            dr["RaporDizaynID"] = dt_Raporlar.Rows[i]["RaporDizaynID"];
                            yaziciBilgileri.dt.Rows.Add(dr);
                            yaziciBilgileri.YaziciBilgileriniKaydet(Convert.ToInt32(dt_Raporlar.Rows[i]["ModulNo"]), yaziciBilgileri.dt);
                            //yaziciBilgileri.dt.Rows.
                        }
                    }



                    //var customerNames = from customers in dt_Raporlar.AsEnumerable()
                    //                    join aliases in yaziciBilgileri.dt.AsEnumerable on customers.Field<int>("CustomerID") equals aliases.Field<int>("CustomerID")
                    //                    where aliases.Field<string>("Alias").Contains(iString)
                    //                    select customers.Field<string>("Name");

                    //var customerNames2 = from customers in dt_Raporlar.AsEnumerable()
                    //                     join aliases in yaziciBilgileri.dt.AsEnumerable() on customers.Field<int>("CustomerID") equals aliases.Field<int>("CustomerID")
                    //                     where aliases.Field<string>("Alias").Contains(iString)
                    //                     select customers.Field<string>("Name")









                }
            }
        }

        public void RaporGuncelle(SqlConnection Baglanti, SqlTransaction Tr, RaporModul ModulNo)
        {
            using (da = new SqlDataAdapter())
            {
                try
                {
                    da.InsertCommand = new SqlCommand(@"insert into RaporDizayn (ModulNo, RaporDizaynYolu, Aciklama, VarsayilanMi
--,CiftTarafliMi, KagitKaynagi, KagitTipi, RenkliMi, YaziciAdi, KagitKaynagiIndex
) values 
(@ModulNo, @RaporDizaynYolu, @Aciklama, @VarsayilanMi
--, @CiftTarafliMi, @KagitKaynagi, @KagitTipi, @RenkliMi, @YaziciAdi, @KagitKaynagiIndex
)", Baglanti, Tr);
                    da.InsertCommand.Parameters.Add("@ModulNo", SqlDbType.Int).Value = ModulNo;
                    da.InsertCommand.Parameters.Add("@RaporDizaynYolu", SqlDbType.NVarChar, 500, "RaporDizaynYolu");
                    da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 100, "Aciklama");
                    da.InsertCommand.Parameters.Add("@VarsayilanMi", SqlDbType.Bit, 0, "VarsayilanMi");
                    //da.InsertCommand.Parameters.Add("@CiftTarafliMi", SqlDbType.Bit, 0, "CiftTarafliMi");
                    //da.InsertCommand.Parameters.Add("@KagitKaynagi", SqlDbType.NVarChar, 0, "KagitKaynagi");
                    //da.InsertCommand.Parameters.Add("@KagitTipi", SqlDbType.NVarChar, 0, "KagitTipi");
                    //da.InsertCommand.Parameters.Add("@RenkliMi", SqlDbType.Bit, 0, "RenkliMi");
                    //da.InsertCommand.Parameters.Add("@YaziciAdi", SqlDbType.NVarChar, 0, "YaziciAdi");
                    //da.InsertCommand.Parameters.Add("@KagitKaynagiIndex", SqlDbType.Int, 0, "KagitKaynagiIndex");

                    da.UpdateCommand = new SqlCommand(@"update RaporDizayn set ModulNo = @ModulNo, RaporDizaynYolu = @RaporDizaynYolu, Aciklama = @Aciklama, VarsayilanMi = @VarsayilanMi 
--, CiftTarafliMi = @CiftTarafliMi, KagitKaynagi = @KagitKaynagi, KagitTipi = @KagitTipi, RenkliMi = @RenkliMi, YaziciAdi = @YaziciAdi, KagitKaynagiIndex = @KagitKaynagiIndex
where RaporDizaynID = @RaporDizaynID", Baglanti, Tr);
                    da.UpdateCommand.Parameters.Add("@ModulNo", SqlDbType.Int).Value = ModulNo;
                    da.UpdateCommand.Parameters.Add("@RaporDizaynYolu", SqlDbType.NVarChar, 500, "RaporDizaynYolu");
                    da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 250, "Aciklama");
                    da.UpdateCommand.Parameters.Add("@RaporDizaynID", SqlDbType.Int, 0, "RaporDizaynID");
                    da.UpdateCommand.Parameters.Add("@VarsayilanMi", SqlDbType.Bit, 0, "VarsayilanMi");
                    //da.UpdateCommand.Parameters.Add("@CiftTarafliMi", SqlDbType.Bit, 0, "CiftTarafliMi");
                    //da.UpdateCommand.Parameters.Add("@KagitKaynagi", SqlDbType.NVarChar, 0, "KagitKaynagi");
                    //da.UpdateCommand.Parameters.Add("@KagitTipi", SqlDbType.NVarChar, 0, "KagitTipi");
                    //da.UpdateCommand.Parameters.Add("@RenkliMi", SqlDbType.Bit, 0, "RenkliMi");
                    //da.UpdateCommand.Parameters.Add("@YaziciAdi", SqlDbType.NVarChar, 0, "YaziciAdi");
                    //da.UpdateCommand.Parameters.Add("@KagitKaynagiIndex", SqlDbType.Int, 0, "KagitKaynagiIndex");


                    da.DeleteCommand = new SqlCommand("delete from RaporDizayn where RaporDizaynID = @RaporDizaynID", Baglanti, Tr);
                    da.DeleteCommand.Parameters.Add("@RaporDizaynID", SqlDbType.Int, 0, "RaporDizaynID");


                    using (DataTable dt = dt_Raporlar.Copy())
                        yaziciBilgileri.YaziciBilgileriniKaydet(Convert.ToInt32(ModulNo), dt);

                    da.Update(dt_Raporlar);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
