using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Rapor
{
    public class csRaporVarsayilanYolu : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public int RaporDizaynID;
        public string RaporDizaynYolu;
        public string CiftTarafliMi;
        public string KagitKaynagi;
        public string KagitTipi;
        public string RenkliMi;
        public string YaziciAdi;
        public Int16 KagitKaynagiIndex;


        public string RaporVarsayilan(SqlConnection Baglanti, csRaporDizayn.RaporModul HangiModul)
        {
            using (SqlCommand com = new SqlCommand("select Top 1 RaporDizaynID, RaporDizaynYolu  from RaporDizayn where ModulNo = @ModulNo and VarsayilanMi = 'true'", Baglanti))
            {
                com.Parameters.Add("@ModulNo", SqlDbType.Int).Value = HangiModul;
                using (SqlDataReader dr = com.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        RaporDizaynYolu = dr["RaporDizaynYolu"].ToString();
                        RaporDizaynID = (int)dr["RaporDizaynID"];
                    }
                    Yazdirma.csYaziciBilgileri yaziciBilgileri = new Yazdirma.csYaziciBilgileri();
                    yaziciBilgileri.VarsayilanBilgileriGetir(RaporDizaynID);
                    YaziciAdi = yaziciBilgileri.VarsayilanYaziciAdi;
                    KagitKaynagiIndex = yaziciBilgileri.VarsayilanYaziciIndex;
                }
                return RaporDizaynYolu;
            }
        }
    }
}
