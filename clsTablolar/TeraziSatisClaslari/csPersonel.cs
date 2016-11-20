using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.TeraziSatisClaslari
{
    public class csPersonel : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int PersonelID { get; set; }
        public int PersonelCariID { get; set; }
        public string PersonelAdi { get; set; }

        public void BardoktanPersonelGetir(SqlConnection Baglanti, SqlTransaction Tr, string Barkod)
        {
            using (SqlCommand cmd = new SqlCommand(@"
select PersonelID, Personel.CariID, CariTanim  from Personel
inner join Cari on Cari.CariID = Personel.CariID
where Personel.PDKSsifre = @PDKSsifre", Baglanti, Tr))
            {
                cmd.Parameters.Add("@PDKSsifre", SqlDbType.NVarChar).Value = Barkod;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        PersonelID = (int)dr["PersonelID"];
                        PersonelCariID = (int)dr["CariID"];
                        PersonelAdi = dr["CariTanim"].ToString();
                    }
                    else
                    {
                        PersonelID = -1;
                        PersonelCariID = -1;
                        PersonelAdi = string.Empty;
                    }
                }
            }
        }
    }
}
