using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Fatura
{
    public class csFaturaHareket : IDisposable
    {
        public DataTable dt_FaturaHareketleri = new DataTable();
        private SqlDataAdapter da_faturaHareketleri = new SqlDataAdapter();


        public csFaturaHareket()
        {
            da_faturaHareketleri.RowUpdated += da_faturaHareketleri_RowUpdated;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
        }

        void da_faturaHareketleri_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["FaturaHareketID"] = e.Command.Parameters["@YeniID"].Value;
        }

        public void FaturaHareketleriniKaydet(SqlConnection Baglanti, SqlTransaction trGenel, int FaturaID)
        {
            HareketleriKAydet(Baglanti, trGenel, FaturaID, null);
        }

        public void FaturaHareketleriniKaydet(SqlConnection Baglanti, SqlTransaction trGenel, int FaturaID, DataTable HareketTablosu)
        {
            HareketleriKAydet(Baglanti, trGenel, FaturaID, HareketTablosu);
        }
        public void FaturaHareketleriniGetir(SqlConnection Baglanti, SqlTransaction trGenel, int FaturaID)
        {
            try
            {
                using (da_faturaHareketleri.SelectCommand = new SqlCommand(@"FaturaHareketleriniGetir", Baglanti, trGenel))
                {
                    da_faturaHareketleri.SelectCommand.CommandType = CommandType.StoredProcedure;

                    da_faturaHareketleri.SelectCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;


                    dt_FaturaHareketleri.Rows.Clear();
                    da_faturaHareketleri.Fill(dt_FaturaHareketleri);


                    if (dt_FaturaHareketleri.Columns[dt_FaturaHareketleri.Columns.Count - 1].ColumnName != "KdvDahilToplam") // şimdilik bu eğeri yazdım (çünkü aynı kolonları birer defa daha eklemesin diye) sonra 
                    {
                        dt_FaturaHareketleri.Columns.Add("KdvDahilFiyat", Type.GetType("System.Decimal")).Expression = "IskontoluFiyat + ((Kdv * IskontoluFiyat)/ 100)";


                        dt_FaturaHareketleri.Columns.Add("AltBirimKdvDahilFiyat", Type.GetType("System.Decimal")).Expression = "(IskontoluFiyat * KatSayi) + ((Kdv * (IskontoluFiyat * KatSayi))/ 100)";
                        dt_FaturaHareketleri.Columns.Add("AltBirimKdvDahilIndirimHaricFiyat", Type.GetType("System.Decimal")).Expression = "(AnaBirimFiyat * KatSayi) + ((Kdv * (AnaBirimFiyat * KatSayi))/ 100)";


                        dt_FaturaHareketleri.Columns.Add("KdvDahilStokIskonto1IndirimMiktari", Type.GetType("System.Decimal")).Expression = "(AltBirimKdvDahilIndirimHaricFiyat * AltBirimMiktar) - SatirIndirimliToplam - KdvTutari ";

                        dt_FaturaHareketleri.Columns.Add("AltBirimKdvDahilToplam", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";

                        dt_FaturaHareketleri.Columns.Add("KdvDahilToplam", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";

                        //dt_FaturaHareketleri.Columns.Add("KdvDahilToplamIndirim", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";
                        //dt_FaturaHareketleri.Columns.Add("KdvDahilToplamIndirim", Type.GetType("System.Decimal")).Expression = "SatirIndirimliToplam + KdvTutari";

                    }
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private void HareketleriKAydet(SqlConnection Baglanti, SqlTransaction trGenel, int FaturaID, DataTable dt)
        {
            try
            {
                da_faturaHareketleri.InsertCommand = new SqlCommand("FaturaHareketInsert", Baglanti, trGenel);

                da_faturaHareketleri.InsertCommand.CommandType = CommandType.StoredProcedure;
                #region İNSERT PARAMETRELERİ
                //da_faturaHareketleri.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Value = 0;
                da_faturaHareketleri.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;



                da_faturaHareketleri.InsertCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                da_faturaHareketleri.InsertCommand.Parameters.Add("@SatirNo", SqlDbType.Int, 0, "SatirNo");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@FaturaHareketStokAdi", SqlDbType.NVarChar, 250, "FaturaHareketStokAdi");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokAnaBirimID", SqlDbType.Int, 0, "StokAnaBirimID");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@AnaBirimFiyat", SqlDbType.Decimal, 0, "AnaBirimFiyat");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@AltBirimMiktar", SqlDbType.Decimal, 0, "AltBirimMiktar");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@Birim2Fiyat", SqlDbType.Decimal, 0, "Birim2Fiyat");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@Kdv", SqlDbType.Decimal, 0, "Kdv");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@Toplam", SqlDbType.Decimal, 0, "Toplam");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto1", SqlDbType.Decimal, 0, "StokIskonto1");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto1Tutari", SqlDbType.Decimal, 0, "StokIskonto1Tutari");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto1SonrasiTutar");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto2", SqlDbType.Decimal, 0, "StokIskonto2");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto2Tutari", SqlDbType.Decimal, 0, "StokIskonto2Tutari");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto2SonrasiTutar");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto3", SqlDbType.Decimal, 0, "StokIskonto3");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto3Tutari", SqlDbType.Decimal, 0, "StokIskonto3Tutari");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto3SonrasiTutar");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto1", SqlDbType.Decimal, 0, "CariIskonto1");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto1Tutari", SqlDbType.Decimal, 0, "CariIskonto1Tutari");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto1SonrasiTutar");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto2", SqlDbType.Decimal, 0, "CariIskonto2");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto2Tutari", SqlDbType.Decimal, 0, "CariIskonto2Tutari");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto2SonrasiTutar");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto3", SqlDbType.Decimal, 0, "CariIskonto3");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto3Tutari", SqlDbType.Decimal, 0, "CariIskonto3Tutari");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto3SonrasiTutar");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@IskontoluFiyat", SqlDbType.Decimal, 0, "IskontoluFiyat");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@SatirIndirimliToplam", SqlDbType.Decimal, 0, "SatirIndirimliToplam");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 250, "SatirAciklama");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@DepoID", SqlDbType.Int, 0, "DepoID");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@CariToplamIskonto", SqlDbType.Decimal, 0, "CariToplamIskonto");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@StokToplamIskonto", SqlDbType.Decimal, 0, "StokToplamIskonto");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@ToplamIskonto", SqlDbType.Decimal, 0, "ToplamIskonto");
                da_faturaHareketleri.InsertCommand.Parameters.Add("@KdvTutari", SqlDbType.Decimal, 0, "KdvTutari");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@FireMiktari", SqlDbType.Decimal, 0, "FireMiktari");

                da_faturaHareketleri.InsertCommand.Parameters.Add("@BirlesikUrunHareketID", SqlDbType.Int, 0, "BirlesikUrunHareketID");
                #endregion

                da_faturaHareketleri.UpdateCommand = new SqlCommand(@"FaturaHareketUpdate", Baglanti, trGenel);
                da_faturaHareketleri.UpdateCommand.CommandType = CommandType.StoredProcedure;
                #region UPDATE PARAMETRELERİ
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@FaturaHareketID", SqlDbType.Int, 0, "FaturaHareketID");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@SatirNo", SqlDbType.Int, 0, "SatirNo");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@FaturaHareketStokAdi", SqlDbType.NVarChar, 200, "FaturaHareketStokAdi");



                da_faturaHareketleri.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
                //da_faturaHareketleri.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar").Scale = 10;

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokAnaBirimID", SqlDbType.Int, 0, "StokAnaBirimID");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@AnaBirimFiyat", SqlDbType.Decimal, 0, "AnaBirimFiyat");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@Birim2ID", SqlDbType.Int, 0, "Birim2ID");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@Birim2Fiyat", SqlDbType.Decimal, 0, "Birim2Fiyat");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@AltBirimMiktar", SqlDbType.Decimal, 0, "AltBirimMiktar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@Kdv", SqlDbType.Decimal, 0, "Kdv");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@Toplam", SqlDbType.Decimal, 0, "Toplam");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1", SqlDbType.Decimal, 0, "StokIskonto1");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1Tutari", SqlDbType.Decimal, 0, "StokIskonto1Tutari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto1SonrasiTutar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2", SqlDbType.Decimal, 0, "StokIskonto2");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2Tutari", SqlDbType.Decimal, 0, "StokIskonto2Tutari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto2SonrasiTutar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3", SqlDbType.Decimal, 0, "StokIskonto3");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3Tutari", SqlDbType.Decimal, 0, "StokIskonto3Tutari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "StokIskonto3SonrasiTutar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1", SqlDbType.Decimal, 0, "CariIskonto1");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1Tutari", SqlDbType.Decimal, 0, "CariIskonto1Tutari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto1SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto1SonrasiTutar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2", SqlDbType.Decimal, 0, "CariIskonto2");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2Tutari", SqlDbType.Decimal, 0, "CariIskonto2Tutari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto2SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto2SonrasiTutar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3", SqlDbType.Decimal, 0, "CariIskonto3");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3Tutari", SqlDbType.Decimal, 0, "CariIskonto3Tutari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariIskonto3SonrasiTutar", SqlDbType.Decimal, 0, "CariIskonto3SonrasiTutar");

                da_faturaHareketleri.UpdateCommand.Parameters.Add("@IskontoluFiyat", SqlDbType.Decimal, 0, "IskontoluFiyat");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@SatirIndirimliToplam", SqlDbType.Decimal, 0, "SatirIndirimliToplam");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@SatirAciklama", SqlDbType.NVarChar, 250, "SatirAciklama");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@DepoID", SqlDbType.Int, 0, "DepoID");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@CariToplamIskonto", SqlDbType.Decimal, 0, "CariToplamIskonto");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@StokToplamIskonto", SqlDbType.Decimal, 0, "StokToplamIskonto");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@ToplamIskonto", SqlDbType.Decimal, 0, "ToplamIskonto");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@KdvTutari", SqlDbType.Decimal, 0, "KdvTutari");


                da_faturaHareketleri.UpdateCommand.Parameters.Add("@FireMiktari", SqlDbType.Decimal, 0, "FireMiktari");
                da_faturaHareketleri.UpdateCommand.Parameters.Add("@BirlesikUrunHareketID", SqlDbType.Int, 0, "BirlesikUrunHareketID");
                #endregion

                da_faturaHareketleri.DeleteCommand = new SqlCommand("delete FaturaHareket where FaturaHareketID = @FaturaHareketID", Baglanti, trGenel);
                da_faturaHareketleri.DeleteCommand.Parameters.Add("@FaturaHareketID", SqlDbType.Int, 20, "FaturaHareketID");

                da_faturaHareketleri.InsertCommand.Transaction = trGenel;
                da_faturaHareketleri.UpdateCommand.Transaction = trGenel;
                da_faturaHareketleri.DeleteCommand.Transaction = trGenel;

                if (dt == null)
                {
                    // TODO : Doktor bu ne??
                    da_faturaHareketleri.Update(dt_FaturaHareketleri);
                }
                else
                    da_faturaHareketleri.Update(dt);
                //Stok.csStokHr Hareket = new Stok.csStokHr(Baglanti, trGenel, -1 )
                //Hareket.Entegrasyon = 1;
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }
    }
}
