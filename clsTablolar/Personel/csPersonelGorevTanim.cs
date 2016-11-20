using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace clsTablolar.Personel
{
    public class csPersonelGorevTanim : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private SqlDataAdapter da;
        public DataTable dt_PersonelGorev;

        public csPersonelGorevTanim(SqlConnection Baglanti, SqlTransaction Tr)
        {
          da = new SqlDataAdapter("select PersonelGorevID, GorevAdi, SatistaGorevliMi from PersonelGorevTanim", Baglanti);
            da.SelectCommand.Transaction = Tr;
            dt_PersonelGorev = new DataTable();
            da.Fill(dt_PersonelGorev);
        }
        public void GorevKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
          da.InsertCommand = new SqlCommand("insert into PersonelGorevTanim (GorevAdi, SatistaGorevliMi) values (@GorevAdi, @SatistaGorevliMi)", Baglanti, Tr);
            da.InsertCommand.Parameters.Add("@GorevAdi", SqlDbType.NVarChar, 75, "GorevAdi");
            da.InsertCommand.Parameters.Add("@SatistaGorevliMi", SqlDbType.Bit, 0, "SatistaGorevliMi");


            da.UpdateCommand = new SqlCommand("update PersonelGorevTanim set GorevAdi = @GorevAdi, SatistaGorevliMi = @SatistaGorevliMi  where PersonelGorevID = @PersonelGorevID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@GorevAdi", SqlDbType.NVarChar, 75, "GorevAdi");
            da.UpdateCommand.Parameters.Add("@PersonelGorevID", SqlDbType.Int, 0, "PersonelGorevID");
            da.UpdateCommand.Parameters.Add("@SatistaGorevliMi", SqlDbType.Bit, 0, "SatistaGorevliMi");

            da.DeleteCommand = new SqlCommand("delete from  PersonelGorevTanim where PersonelGorevID = @PersonelGorevID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@PersonelGorevID", SqlDbType.Int, 0, "PersonelGorevID");
            
            da.Update(dt_PersonelGorev);
        }
    }
}
