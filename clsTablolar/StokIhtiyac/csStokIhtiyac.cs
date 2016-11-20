using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
    public class csStokIhtiyac : IDisposable
    {

        private SqlDataAdapter da;
        public DataTable dt_StokIhtiyac;

        public csStokIhtiyac(SqlConnection Baglanti, SqlTransaction Tr)
        {
          da = new SqlDataAdapter(@"select * from StokIhtiyac
 inner join
 Stok on Stok.StokID = StokIhtiyac.StokID
 left join StokBirim on StokBirim.BirimID = Stok.StokBirimID
 left join StokGrup on StokGrup.StokGrupID = Stok.StokGrupID
 left join StokIhtiyacDurumTanimlari on StokIhtiyacDurumTanimlari.StokIhtiyacDurumTanimlariID = StokIhtiyac.DrumID", Baglanti);
          da.SelectCommand.Transaction = Tr;
            dt_StokIhtiyac = new DataTable();
            da.Fill(dt_StokIhtiyac);
        }

        public string StokIhtiyacGuncele(SqlConnection Baglanti, SqlTransaction Tr)
        {
          da.UpdateCommand = new SqlCommand(@"Update StokIhtiyac set  StokID = @StokID, StokIhtiyacMiktari=@StokIhtiyacMiktari, DrumID = @DrumID, Aciklama=@Aciklama, EklemeTarihi = @EklemeTarihi 
where StokIhtiyacID =@StokIhtiyacID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.UpdateCommand.Parameters.Add("@StokIhtiyacMiktari", SqlDbType.Decimal, 0, "StokIhtiyacMiktari");
            da.UpdateCommand.Parameters.Add("@DrumID", SqlDbType.Int, 0, "DrumID");
            da.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 200, "Aciklama");
            da.UpdateCommand.Parameters.Add("@StokIhtiyacID", SqlDbType.NVarChar, 200, "StokIhtiyacID");
            da.UpdateCommand.Parameters.Add("@EklemeTarihi", SqlDbType.DateTime, 0, "EklemeTarihi");



            da.InsertCommand = new SqlCommand(@"insert into StokIhtiyac
(StokID, StokIhtiyacMiktari, DrumID, Aciklama, EklemeTarihi)
values 
(@StokID, @StokIhtiyacMiktari, @DrumID, @Aciklama, @EklemeTarihi)", Baglanti, Tr);
            da.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "StokID");
            da.InsertCommand.Parameters.Add("@StokIhtiyacMiktari", SqlDbType.Int, 0, "StokIhtiyacMiktari");
            da.InsertCommand.Parameters.Add("@DrumID", SqlDbType.Int, 0, "DrumID");
            da.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.Int, 0, "Aciklama");
            da.InsertCommand.Parameters.Add("@EklemeTarihi", SqlDbType.DateTime, 0, "EklemeTarihi");

            da.DeleteCommand = new SqlCommand("delete from StokIhtiyac where StokIhtiyacID = @StokIhtiyacID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@StokIhtiyacID", SqlDbType.Int, 0, "StokIhtiyacID");

            try
            {
                da.Update(dt_StokIhtiyac);
                return "OlduHamisina";
            }
            catch (Exception)
            {
                return "OlmadiHamisina";
            }
        }






        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
