using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Terazi
{
    /// <summary>
    /// Hangi StokGrubunun Hangi Stoklari Tutacağını tanımlayan tablo (Terazi için tabiki hamısına)
    /// </summary>
    public class csTeraziStokGruplari : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        SqlDataAdapter da;

        public DataTable dt;

        public void TeraziStokGruplari_Getir(SqlConnection Baglanti, SqlTransaction Tr, int TeraziStokGrupTanimID)
        { // bunun benzirini aslında store procedur den çağırıyor
            using (da = new SqlDataAdapter(@"select TeraziStokGruplari.*, stok.StokAdi, Stok.TeraziKisayolTusu from TeraziStokGruplari
inner join Stok on stok.stokID = TeraziStokGruplari.stokID
where TeraziStokGruplari.TeraziStokGrupTanimID = @TeraziStokGrupTanimID", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@TeraziStokGrupTanimID", SqlDbType.Int).Value = TeraziStokGrupTanimID;
                da.RowUpdated += da_RowUpdated;
                using (dt = new DataTable())
                {

                    da.Fill(dt);
                }
            }
        }

        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["TeraziStokGrupID"] = e.Command.Parameters["@YeniID"].Value;
        }

        public void StoklariGruplaraKaydetHamisina(SqlConnection Baglanti, SqlTransaction Tr, int TeraziStokGrupTanimID)
        {
            da.InsertCommand = new SqlCommand(@"insert into TeraziStokGruplari (StokID, TeraziStokGrupTanimID, SiraNu, ButonTipi, Aktif) values (@StokID, @TeraziStokGrupTanimID, @SiraNu, @ButonTipi, @Aktif) 
             set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);

            da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.InsertCommand.Parameters.Add("@TeraziStokGrupTanimID", SqlDbType.Int).Value = TeraziStokGrupTanimID;
            da.InsertCommand.Parameters.Add("@SiraNu", SqlDbType.Int, 0, "SiraNu");
            da.InsertCommand.Parameters.Add("@ButonTipi", SqlDbType.Int, 0, "ButonTipi");
            da.InsertCommand.Parameters.Add("@Aktif", SqlDbType.Int, 0, "Aktif");



            da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;




            da.UpdateCommand = new SqlCommand(@"update TeraziStokGruplari set StokID = @StokID, TeraziStokGrupTanimID = @TeraziStokGrupTanimID, SiraNu = @SiraNu, ButonTipi = @ButonTipi, Aktif = @Aktif
            where TeraziStokGrupID = @TeraziStokGrupID", Baglanti, Tr);


            da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.UpdateCommand.Parameters.Add("@TeraziStokGrupTanimID", SqlDbType.Int).Value = TeraziStokGrupTanimID;
            da.UpdateCommand.Parameters.Add("@SiraNu", SqlDbType.Int, 0, "SiraNu");
            da.UpdateCommand.Parameters.Add("@ButonTipi", SqlDbType.Int, 0, "ButonTipi");
            da.UpdateCommand.Parameters.Add("@Aktif", SqlDbType.Int, 0, "Aktif");

            da.UpdateCommand.Parameters.Add("@TeraziStokGrupID", SqlDbType.Int, 0, "TeraziStokGrupID");


            da.DeleteCommand = new SqlCommand("delete TeraziStokGruplari where TeraziStokGrupID = @TeraziStokGrupID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@TeraziStokGrupID", SqlDbType.Int, 0, "TeraziStokGrupID");

            da.Update(dt);

            da.InsertCommand.Dispose();
            da.UpdateCommand.Dispose();
            da.DeleteCommand.Dispose();
        }
    }
}
