using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
    public class csPDKSdenVeriAktar : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        DataTable dt_PDKShareketler;
        DataTable dt_AresPDKSHareketler;

        /// <summary>
        /// Ares in veri tabanında olmayan pdks hareketlerini getirir.
        /// </summary>
        public void PDKSHareketleriGetir(SqlConnection PDKS_Baglanti, SqlTransaction Tr, DateTime date)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from Hareketler", PDKS_Baglanti))
            {
                da.SelectCommand.Transaction = Tr;

                using (dt_PDKShareketler = new DataTable())
                {
                    da.Fill(dt_PDKShareketler);
                }
            }
        }


        public void PdksdekiHareketleriAreseKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {


        }
    }
}
