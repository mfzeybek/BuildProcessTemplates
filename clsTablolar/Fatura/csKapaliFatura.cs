using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Fatura
{
    public class csKapaliFatura : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        SqlDataAdapter da;
        public DataTable dt;

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (da = new SqlDataAdapter(@"select KapaliFatura.*, CariHr.Aciklama, CariHr.Tarih, CariHr.Tutar from KapaliFatura
inner join CariHr on CariHr.CariHrID = KapaliFatura.EntegrasyonID and EntegrasyonNu = 24 -- (13 birkaç yere yanlışlıkla 13 yazmış olabilirsin) carihr in entegrasyon numarası
where KapaliFatura.FaturaID = @FaturaID", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@FaturaID", SqlDbType.Int, 0).Value = FaturaID;
                using (dt = new DataTable())
                {
                    da.Fill(dt);
                }
            }
        }

        public void GetirEntegrasyonNumarasindan(SqlConnection Baglanti, SqlTransaction Tr, clsTablolar.IslemTipi EntegrasyonNu, int EntegrasyonID)
        {
            using (da = new SqlDataAdapter(@"select KapaliFatura.*, CariHr.Aciklama, CariHr.Tarih, CariHr.Tutar from KapaliFatura
inner join CariHr on CariHr.CariHrID = KapaliFatura.EntegrasyonID and EntegrasyonNu = 13 -- 13 carihr in entegrasyon numarası
where KapaliFatura.EntegrasyonID = @EntegrasyonID and EntegrasyonNu = @EntegrasyonNu", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@EntegrasyonID", SqlDbType.Int, 0).Value = EntegrasyonID;
                da.SelectCommand.Parameters.Add("@EntegrasyonNu", SqlDbType.Int, 0).Value = (int)EntegrasyonNu;
                using (dt = new DataTable())
                {
                    da.Fill(dt);
                }
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            da.UpdateCommand = new SqlCommand(@"update KapaliFatura set FaturaID = @FaturaID, 
EntegrasyonNu = @EntegrasyonNu, EntegrasyonID = @EntegrasyonID where KapaliFaturaID = @KapaliFaturaID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
            da.UpdateCommand.Parameters.Add("@EntegrasyonNu", SqlDbType.TinyInt, 0, "EntegrasyonNu");
            da.UpdateCommand.Parameters.Add("@EntegrasyonID", SqlDbType.Int, 0).Value = -1;

            da.UpdateCommand.Parameters.Add("@KapaliFaturaID", SqlDbType.Int, 0, "KapaliFaturaID");

            da.InsertCommand = new SqlCommand(@"insert into KapaliFatura (FaturaID, EntegrasyonNu, EntegrasyonID)
             values (@FaturaID, @EntegrasyonNu, @EntegrasyonID)
             set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);

            da.InsertCommand.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
            da.InsertCommand.Parameters.Add("@EntegrasyonNu", SqlDbType.TinyInt, 0, "EntegrasyonNu");
            da.InsertCommand.Parameters.Add("@EntegrasyonID", SqlDbType.Int, 0).Value = -1; // bu bir cari hareket olduğu için entegrasyon ID si yok mk

            da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

            da.DeleteCommand = new SqlCommand("delete from KapaliFatura where KapaliFaturaID = @KapaliFaturaID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@KapaliFaturaID", SqlDbType.Int, 0, "KapaliFaturaID");

            da.RowUpdated += da_RowUpdated;

            da.Update(dt);
        }


        public decimal FaturaninKAlanBakiyesi { get; set; }
        public decimal FaturaninToplamTutari { get; set; }



        public decimal FaturaninKalanBakiyesiniGetir(SqlConnection Baglanti, SqlTransaction TR, int FaturaID) // Ne bakiyesi Kalmışsa onu getirir
        {
            using (SqlCommand cmd = new SqlCommand(@"FaturaninKalanBakiyesiniveToplamTutariniGetir", Baglanti, TR))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                decimal KalanBakiye = 0;
                cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        KalanBakiye = Convert.ToDecimal(dr["KalanBorc"]);
                    }
                    return KalanBakiye;
                }
            }
        }

        public int KapaliFaturaID { get; set; }
        public int FaturaID { get; set; }
        public int EntegrasyonNumarasi { get; set; }
        public int EntegrasyonID { get; set; }
        public string Aciklama { get; set; }

        public void Kaydet()
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                //if KapaliFaturaID




            }
        }


        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["KapaliFaturaID"] = e.Command.Parameters["@YeniID"].Value;
        }

        public void YeniOdeme(int FaturaID, int EntegrasyonID, IslemTipi EntegrasyonNu)
        {
            dt.Rows.Add(dt.NewRow());
            dt.Rows[dt.Rows.Count - 1]["FaturaID"] = FaturaID;
            dt.Rows[dt.Rows.Count - 1]["EntegrasyonID"] = EntegrasyonID;
            dt.Rows[dt.Rows.Count - 1]["EntegrasyonNu"] = (int)EntegrasyonNu;
        }
    }
}