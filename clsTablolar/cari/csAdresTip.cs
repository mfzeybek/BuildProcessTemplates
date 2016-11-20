using System;
using System.Data.SqlClient;
using System.Data;

namespace clsTablolar.cari
{
    public class csAdresTip : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private DataTable dt = new DataTable();
        private SqlDataAdapter da = new SqlDataAdapter();

        public csAdresTip()
        { }

        public void AdresTipGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da.UpdateCommand = new SqlCommand("update AdresTip set AdresTip = @AdresTip where AdresTipID = @AdresTipID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@AdresTip", SqlDbType.NVarChar, 50, "AdresTip");
            da.UpdateCommand.Parameters.Add("@AdresTipID", SqlDbType.Int, 10, "AdresTipID");

            da.InsertCommand = new SqlCommand("insert into AdresTip (AdresTip) values (@AdresTip)", Baglanti);
            da.InsertCommand.Parameters.Add("@AdresTip", SqlDbType.NVarChar, 50, "AdresTip");

            da.DeleteCommand = new SqlCommand("delete AdresTip where AdresTipID = @AdresTipID", Baglanti);
            da.DeleteCommand.Parameters.Add("@AdresTipID", SqlDbType.Int, 10, "AdresTipID");

            da.Update(dt);
        }

        public DataTable AdresTipleriniGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da.SelectCommand = new SqlCommand("select AdresTipID, AdresTip from AdresTip", Baglanti, Tr);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
