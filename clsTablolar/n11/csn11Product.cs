using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.n11
{
    public class csN11Product : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        public int n11ProductID { get; set; }
        public int KategoriID { get; set; }
        public int StokID { get; set; }
        public string DetayliUrunBilgisi { get; set; }


        SqlDataReader dr;
        SqlCommand cmd;



        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmd = new SqlCommand())
            {
                cmd.CommandText = " select * from n11Product where StokID = @StokID ";
                cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = StokID;
                cmd.Connection = Baglanti;
                cmd.Transaction = Tr;
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        n11ProductID = (int)dr["n11ProductID"];
                        KategoriID = (int)dr["KategoriID"];
                        StokID = (int)dr["StokID"];
                        DetayliUrunBilgisi = dr["DetayliUrunBilgisi"].ToString();
                    }
                }
            }
        }
    }
}
