using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Terazi
{
    /// <summary>
    /// hangi Terazide Hangi Stok Grup Butonları Gözükeceğini tutan tablo
    /// </summary>
    public class csTeraziStokGruplariIliskileri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;


        


        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            try
            {
                using (da = new SqlDataAdapter(@"select TeraziStokGruplariIliskileri.TeraziStokGruplariIliskiID, TeraziStokGruplariIliskileri.TeraziStokGrupTanimID, TeraziID, TeraziStokGrupTanimlari.TeraziStokButonGrupTanimAdi, TeraziStokGrupTanimlari.TeraziStokButonGrupTanimAciklama   from TeraziStokGruplariIliskileri
inner join TeraziStokGrupTanimlari on TeraziStokGrupTanimlari.TeraziStokGrupTanimID = TeraziStokGruplariIliskileri.TeraziStokGrupTanimID
where TeraziID = @TeraziID", Baglanti))
                {
                    da.SelectCommand.Transaction = Tr;

                    da.SelectCommand.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziID;

                    da.RowUpdated += da_RowUpdated;
                    using (dt = new DataTable())
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["TeraziStokGruplariIliskiID"] = e.Command.Parameters["@YeniID"].Value;
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int TeraziID)
        {
            da.InsertCommand = new SqlCommand("insert into TeraziStokGruplariIliskileri (TeraziID, TeraziStokGrupTanimID) values (@TeraziID, @TeraziStokGrupTanimID)  set @YeniID = SCOPE_IDENTITY() ", Baglanti);
            da.InsertCommand.Transaction = Tr;
            da.InsertCommand.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziID;
            da.InsertCommand.Parameters.Add("@TeraziStokGrupTanimID", SqlDbType.Int, 0, "TeraziStokGrupTanimID");
            da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

            da.UpdateCommand = new SqlCommand("update TeraziStokGruplariIliskileri set TeraziID = @TeraziID, TeraziStokGrupTanimID = @TeraziStokGrupTanimID where TeraziStokGruplariIliskiID = @TeraziStokGruplariIliskiID");
            da.UpdateCommand.Transaction = Tr;
            da.UpdateCommand.Parameters.Add("@TeraziID", SqlDbType.Int).Value = TeraziID;
            da.UpdateCommand.Parameters.Add("@TeraziStokButonGrupTanimID", SqlDbType.Int, 0, "TeraziStokButonGrupTanimID");

            da.UpdateCommand.Parameters.Add("@TeraziStokGrupID", SqlDbType.Int, 0, "TeraziStokGrupID"); // bune ne amk nerede kullanılıyor böyle bişi yok ki mnk

            da.DeleteCommand = new SqlCommand("delete from TeraziStokGruplariIliskileri where TeraziStokGruplariIliskiID = @TeraziStokGruplariIliskiID", Baglanti, Tr);
            da.DeleteCommand.Transaction = Tr;
            da.DeleteCommand.Parameters.Add("@TeraziStokGruplariIliskiID", SqlDbType.Int, 0, "TeraziStokGruplariIliskiID");

            da.Update(dt);
        }
    }
}
