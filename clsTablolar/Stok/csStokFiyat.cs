using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStokFiyat : IDisposable
    {
        public DataTable dt_SatisFiyati;
        private SqlDataAdapter da_SatisFiyati;

        private DataTable dt_AlisFiyati;
        private SqlDataAdapter da_AlisFiyati;

        /// <summary>
        /// bunu kullanma artık
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="StokID"></param>
        public void StokFiyatGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {

            #region Satis Fiyatini Günceller

            da_SatisFiyati.UpdateCommand = new SqlCommand("update  StokFiyat set FiyatTanimID = @FiyatTanimID, Fiyat = @Fiyat, StokID = @StokID, AlisMiSatisMi = @AlisMiSatisMi, KdvDahil = @KdvDahil where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_SatisFiyati.UpdateCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_SatisFiyati.UpdateCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_SatisFiyati.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_SatisFiyati.UpdateCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Satis";
            da_SatisFiyati.UpdateCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");
            da_SatisFiyati.UpdateCommand.Parameters.Add("@KdvDahil", SqlDbType.Bit, 0, "KdvDahil");

            da_SatisFiyati.InsertCommand = new SqlCommand("insert into StokFiyat (FiyatTanimID, Fiyat, StokID, AlisMiSatisMi, KdvDahil) values (@FiyatTanimID, @Fiyat, @StokID, @AlisMiSatisMi, @KdvDahil)", Baglanti, Tr);
            da_SatisFiyati.InsertCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_SatisFiyati.InsertCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_SatisFiyati.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_SatisFiyati.InsertCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Satis";
            da_SatisFiyati.InsertCommand.Parameters.Add("@KdvDahil", SqlDbType.Bit, 0, "KdvDahil");

            da_SatisFiyati.DeleteCommand = new SqlCommand("delete StokFiyat where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_SatisFiyati.DeleteCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");

            da_SatisFiyati.Update(dt_SatisFiyati);
            #endregion

            #region AlisFiyatı Güncelle
            da_AlisFiyati.UpdateCommand = new SqlCommand("update  StokFiyat set FiyatTanimID = @FiyatTanimID, Fiyat = @Fiyat, StokID = @StokID, AlisMiSatisMi = @AlisMiSatisMi, KdvDahil =@KdvDahil where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_AlisFiyati.UpdateCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_AlisFiyati.UpdateCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_AlisFiyati.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_AlisFiyati.UpdateCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Alis";
            da_AlisFiyati.UpdateCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");
            da_AlisFiyati.UpdateCommand.Parameters.Add("@KdvDahil", SqlDbType.Bit, 0, "KdvDahil");

            da_AlisFiyati.InsertCommand = new SqlCommand("insert into StokFiyat (FiyatTanimID, Fiyat, StokID, AlisMiSatisMi, KdvDahil) values (@FiyatTanimID, @Fiyat, @StokID, @AlisMiSatisMi, @KdvDahil )", Baglanti, Tr);
            da_AlisFiyati.InsertCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_AlisFiyati.InsertCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_AlisFiyati.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_AlisFiyati.InsertCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Alis";
            da_AlisFiyati.InsertCommand.Parameters.Add("@KdvDahil", SqlDbType.Bit, 0, "KdvDahil");

            da_AlisFiyati.DeleteCommand = new SqlCommand("delete StokFiyat where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_AlisFiyati.DeleteCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");

            da_AlisFiyati.Update(dt_AlisFiyati);
            #endregion
        }

        public void AlisFiyatiniGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            #region Satis Fiyatini Günceller

            da_SatisFiyati.UpdateCommand = new SqlCommand("update  StokFiyat set FiyatTanimID = @FiyatTanimID, Fiyat = @Fiyat, StokID = @StokID, AlisMiSatisMi = @AlisMiSatisMi where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_SatisFiyati.UpdateCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_SatisFiyati.UpdateCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_SatisFiyati.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_SatisFiyati.UpdateCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Satis";
            da_SatisFiyati.UpdateCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");

            da_SatisFiyati.InsertCommand = new SqlCommand("insert into StokFiyat (FiyatTanimID, Fiyat, StokID, AlisMiSatisMi) values (@FiyatTanimID, @Fiyat, @StokID, @AlisMiSatisMi)", Baglanti, Tr);
            da_SatisFiyati.InsertCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_SatisFiyati.InsertCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_SatisFiyati.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_SatisFiyati.InsertCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Satis";

            da_SatisFiyati.DeleteCommand = new SqlCommand("delete StokFiyat where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_SatisFiyati.DeleteCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");

            da_SatisFiyati.Update(dt_SatisFiyati);
            #endregion
        }

        public void SatisFiyatiniGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            #region AlisFiyatı Güncelle
            da_AlisFiyati.UpdateCommand = new SqlCommand("update  StokFiyat set FiyatTanimID = @FiyatTanimID, Fiyat = @Fiyat, StokID = @StokID, AlisMiSatisMi = @AlisMiSatisMi where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_AlisFiyati.UpdateCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_AlisFiyati.UpdateCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_AlisFiyati.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_AlisFiyati.UpdateCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Alis";
            da_AlisFiyati.UpdateCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");

            da_AlisFiyati.InsertCommand = new SqlCommand("insert into StokFiyat (FiyatTanimID, Fiyat, StokID, AlisMiSatisMi) values (@FiyatTanimID, @Fiyat, @StokID, @AlisMiSatisMi)", Baglanti, Tr);
            da_AlisFiyati.InsertCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int, 10, "FiyatTanimID");
            da_AlisFiyati.InsertCommand.Parameters.Add("@Fiyat", SqlDbType.Decimal, 20, "Fiyat");
            da_AlisFiyati.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
            da_AlisFiyati.InsertCommand.Parameters.Add("@AlisMiSatisMi", SqlDbType.NVarChar).Value = "Alis";

            da_AlisFiyati.DeleteCommand = new SqlCommand("delete StokFiyat where StokFiyatID = @StokFiyatID", Baglanti, Tr);
            da_AlisFiyati.DeleteCommand.Parameters.Add("@StokFiyatID", SqlDbType.Int, 10, "StokFiyatID");

            da_AlisFiyati.Update(dt_AlisFiyati);
            #endregion

        }

        public DataTable SatisFiyatiGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            da_SatisFiyati = new SqlDataAdapter();
            da_SatisFiyati.SelectCommand = new SqlCommand();
            da_SatisFiyati.SelectCommand.CommandText = "select StokFiyatID, FiyatTanimID, Fiyat, StokID, AlisMiSatisMi, KdvDahil from StokFiyat where StokID = @StokID and AlisMiSatisMi = 'Satis'";
            da_SatisFiyati.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

            da_SatisFiyati.SelectCommand.Connection = Baglanti;
            da_SatisFiyati.SelectCommand.Transaction = Tr;

            dt_SatisFiyati = new DataTable();
            da_SatisFiyati.Fill(dt_SatisFiyati);
            return dt_SatisFiyati;
        }

        public DataTable AlisFiyatiGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            da_AlisFiyati = new SqlDataAdapter();
            da_AlisFiyati.SelectCommand = new SqlCommand();
            da_AlisFiyati.SelectCommand.CommandText = "select StokFiyatID, FiyatTanimID, Fiyat, StokID, AlisMiSatisMi, KdvDahil from StokFiyat where StokID = @StokID and AlisMiSatisMi = 'Alis'";
            da_AlisFiyati.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;

            da_AlisFiyati.SelectCommand.Connection = Baglanti;
            da_AlisFiyati.SelectCommand.Transaction = Tr;

            dt_AlisFiyati = new DataTable();
            da_AlisFiyati.Fill(dt_AlisFiyati);
            return dt_AlisFiyati;
        }

        public decimal StokKartindakiVarsayilanAlisFiyatiniGetir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (SqlCommand cmd = new SqlCommand("select isnull((Select ISNULL(Fiyat, 0) from StokFiyat where AlisMiSatisMi = 'Alis' and StokID = @StokID),0)", Baglanti, Tr))
            {
                cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;


                return (decimal)cmd.ExecuteScalar();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
