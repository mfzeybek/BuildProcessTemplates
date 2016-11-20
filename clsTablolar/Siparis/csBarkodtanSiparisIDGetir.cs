using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Siparis
{
    public class csBarkodtanSiparisIDGetir : IDisposable
    {
        public void Dispose()
        {

        }

        public class SiparisOdeme
        {
            public int SipariID { get; set; }
            public int FaturaID { get; set; }

            public bool OdemesiTamamlandiMi { get; set; }

            public string FaturaBarkod { get; set; }
        }

        public SiparisOdeme BarkodtaSiparisIDGetir(SqlConnection Baglanti, SqlTransaction Tr, string BarkodNu)
        {
            using (SqlCommand cmd = new SqlCommand(@"select Siparis.SiparisID, isnull(fatura.FaturaID, -1) FaturaID, ISNULL(OdendiMi, CONVERT(bit, 'false', 0)) OdendiMi , FaturaBarkod from Siparis 
left join EvrakIsliski on Siparis.SiparisID = EvrakIsliski.SiparisID
left join fatura on Fatura.FaturaID = EvrakIsliski.FaturaID and Fatura.SilindiMi = 0
where SiparisBarkodNu = @SiparisBarkodNu", Baglanti, Tr))
            {
                cmd.Parameters.Add("@SiparisBarkodNu", SqlDbType.NVarChar).Value = BarkodNu;
                try
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        SiparisOdeme Sip = new SiparisOdeme();
                        if (dr.Read())
                        {

                            Sip.SipariID = (int)dr["SiparisID"];
                            Sip.FaturaID = (int)dr["FaturaID"];
                            Sip.OdemesiTamamlandiMi = Convert.ToBoolean(dr["OdendiMi"]);
                            Sip.FaturaBarkod = dr["FaturaBarkod"].ToString();

                            return Sip;
                        }
                        else
                        {
                            Sip.SipariID = -1;
                            Sip.FaturaID = -1;
                            Sip.OdemesiTamamlandiMi = false;
                            Sip.FaturaBarkod = string.Empty;

                            return Sip;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
