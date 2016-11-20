using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel
{
    public class csPersonelGorevIliski : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        SqlDataAdapter da;
        public DataTable dt_PersonelGorevIliski;

        public csPersonelGorevIliski(SqlConnection Baglanti,SqlTransaction Tr, int PersonelID)
        {
            da = new SqlDataAdapter("select PersonelGorevIliskiID, PersonelID, PersonelGorevID from PersonelGorevIliski where PersonelID = @PersonelID", Baglanti);
            da.SelectCommand.Transaction = Tr;
            da.SelectCommand.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
            dt_PersonelGorevIliski = new DataTable();
            da.Fill(dt_PersonelGorevIliski);
        }
        public void DegisiklikleriKaydet(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
        {
            da.InsertCommand = new SqlCommand("insert into PersonelGorevIliski (PersonelID, PersonelGorevID) values (@PersonelID, @PersonelGorevID)", Baglanti, Tr);
            da.InsertCommand.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
            da.InsertCommand.Parameters.Add("@PersonelGorevID", SqlDbType.Int, 0, "PersonelGorevID");

            da.UpdateCommand = new SqlCommand("update PersonelGorevIliski set PersonelID = @PersonelID, PersonelGorevID = @PersonelGorevID where PersonelGorevIliskiID = @PersonelGorevIliskiID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;
            da.UpdateCommand.Parameters.Add("@PersonelGorevID", SqlDbType.Int, 0, "PersonelGorevID");
            da.UpdateCommand.Parameters.Add("@PersonelGorevIliskiID", SqlDbType.Int, 0, "PersonelGorevIliskiID");

            da.DeleteCommand = new SqlCommand("delete from PersonelGorevIliski where PersonelGorevIliskiID = @PersonelGorevIliskiID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@PersonelGorevIliskiID", SqlDbType.Int, 0, "PersonelGorevIliskiID");

            da.Update(dt_PersonelGorevIliski);
        }
    }

}
