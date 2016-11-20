using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStokSayimGrubu : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        DataTable dt;

        public DataTable SayimGrubuGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da)
            {
                da = new SqlDataAdapter("select StokSayimGrubuID, SayimAdi from StokSayimGrubu", Baglanti);
                da.SelectCommand.Transaction = Tr;

                using (dt = new DataTable())
                {
                    da.Fill(dt);

                    return dt;
                }
            }
        }

        public void SayimGrubuGuncelle(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da.UpdateCommand = new SqlCommand("update StokSayimGrubu set SayimAdi = @SayimAdi where StokSayimGrubuID = @StokSayimGrubuID", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@StokSayimGrubuID", SqlDbType.Int, 0, "StokSayimGrubuID");
            da.UpdateCommand.Parameters.Add("@SayimAdi", SqlDbType.Int, 0, "SayimAdi");

            da.UpdateCommand = new SqlCommand(@"insert into StokSayimGrubu 
        ( SayimAdi ) 
        values 
        ( @SayimAdi )", Baglanti, Tr);
            da.UpdateCommand.Parameters.Add("@SayimAdi", SqlDbType.Int, 0, "SayimAdi");

            da.DeleteCommand = new SqlCommand("delete from StokSayimGrubu where StokSayimGrubuID = @StokSayimGrubuID", Baglanti, Tr);
            da.DeleteCommand.Parameters.Add("@StokSayimGrubuID", SqlDbType.Int, 0, "StokSayimGrubuID");

            da.Update(dt);
        }
    }
}
