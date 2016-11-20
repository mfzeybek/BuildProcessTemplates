using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok.Paket
{
    public class csPaketDetay : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;

        public DataTable Getir(SqlConnection Baglanti, SqlTransaction Tr, int PaketID)
        {
            using (da = new SqlDataAdapter(@"select PaketDetay.*, Stok.StokAdi from PaketDetay with(nolock)
inner join Stok with(nolock) on Stok.StokID = PaketDetay.StokID
where PaketID = @PaketID", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@PaketID", SqlDbType.Int).Value = PaketID;

                using (dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int PaketID)
        {
            da.InsertCommand = new SqlCommand(@"insert into PaketDetay (PaketID, StokID, AltBirimID, AltBirimMiktar, KatSayi, Aciklama, Miktar, AnaBirimID) values 
                (@PaketID, @StokID, @AltBirimID, @AltBirimMiktar, @KatSayi, @Aciklama, @Miktar, @AnaBirimID) set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);

            da.RowUpdated += da_RowUpdated;

            da.InsertCommand.Parameters.Add("@PaketID", SqlDbType.Int).Value = PaketID;
            da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.InsertCommand.Parameters.Add("@AltBirimID", SqlDbType.Int, 0, "AltBirimID");
            da.InsertCommand.Parameters.Add("@AltBirimMiktar", SqlDbType.Decimal, 0, "AltBirimMiktar");
            da.InsertCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
            da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 0, "Aciklama");
            da.InsertCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
            da.InsertCommand.Parameters.Add("@AnaBirimID", SqlDbType.Int, 0, "AnaBirimID");

            da.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

            da.UpdateCommand = new SqlCommand(@"Update PaketDetay set PaketID = @PaketID, StokID = @StokID, AltBirimID = @AltBirimID, AltBirimMiktar = @AltBirimMiktar, 
            KatSayi = @KatSayi, Aciklama = @Aciklama, Miktar = @Miktar, AnaBirimID = @AnaBirimID where PaketDetayID = @PaketDetayID", Baglanti, Tr);


            da.UpdateCommand.Parameters.Add("@PaketDetayID", SqlDbType.Int, 0, "PaketDetayID");
            da.UpdateCommand.Parameters.Add("@PaketID", SqlDbType.Int).Value = PaketID;
            da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.UpdateCommand.Parameters.Add("@AltBirimID", SqlDbType.Int, 0, "AltBirimID");
            da.UpdateCommand.Parameters.Add("@AltBirimMiktar", SqlDbType.Decimal, 0, "AltBirimMiktar");
            da.UpdateCommand.Parameters.Add("@KatSayi", SqlDbType.Decimal, 0, "KatSayi");
            da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 0, "Aciklama");
            da.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Decimal, 0, "Miktar");
            da.UpdateCommand.Parameters.Add("@AnaBirimID", SqlDbType.Int, 0, "AnaBirimID");

            da.DeleteCommand = new SqlCommand("delete from PaketDetay where PaketDetayID = @PaketDetayID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@PaketDetayID", SqlDbType.Int, 0, "PaketDetayID");



            da.Update(dt);
        }

        void da_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
        {
            if (e.StatementType == StatementType.Insert)
                e.Row["PaketDetayID"] = e.Command.Parameters["@YeniID"].Value;
        }
    }
}
