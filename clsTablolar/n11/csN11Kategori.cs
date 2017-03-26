using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.n11
{
    public class csN11Kategori : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public DataTable KategoriListesi(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from n11Kategori ", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void KategorileriGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int KategoriID, int UstKategoriID, string KategoriAdi, string Aciklama)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @" insert into n11Kategori (n11KAtegoriID, n11UstKategoriID, KategoriAdi, Aciklama) values 
                    (@n11KAtegoriID, @n11UstKategoriID, @KategoriAdi, @Aciklama) ";
                cmd.Parameters.Add("@n11KAtegoriID", SqlDbType.Int).Value = KategoriID;
                cmd.Parameters.Add("@n11UstKategoriID", SqlDbType.Int).Value = UstKategoriID;
                cmd.Parameters.Add("@KategoriAdi", SqlDbType.NVarChar).Value = KategoriAdi;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;
                cmd.Connection = Baglanti;
                cmd.Transaction = Tr;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
