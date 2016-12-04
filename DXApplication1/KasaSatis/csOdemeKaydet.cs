using System;
using System.Data;
using System.Data.SqlClient;

namespace KasaSatis
{
    public class csOdemeKaydet : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void OdemeyiKaydet(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (SqlCommand cmd = new SqlCommand("OdemeyiKaydet", Baglanti, Tr))
            //using (SqlCommand cmd = new SqlCommand("update Fatura set OdendiMi = @OdendiMi, DegismeTarihi = GETDATE() where Fatura.SilindiMi = 0 and Fatura.OdendiMi = 0 and FaturaID = @FaturaID", Baglanti, Tr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                //cmd.Parameters.Add("@OdendiMi", SqlDbType.Bit).Value = 1;
                cmd.ExecuteNonQuery();
            }
        }

        public void FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID, string Aciklama)
        {
            using (SqlCommand cmd = new SqlCommand("FaturaninBakiyesininKalaniniNakitTahsilEt", Baglanti, Tr))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaSatis.Properties.Settings.Default.KasaID;
                cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;

                cmd.ExecuteNonQuery();
            }



        }
    }
}
