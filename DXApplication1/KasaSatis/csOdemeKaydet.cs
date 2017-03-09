﻿using System;
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

        public enum OdemeDonenBilgisi
        {
            OdemesiTamamlandi = 1,
            OncedenOdemesiTamamlanmis = 0
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="FaturaID"></param>
        /// <param name="Aciklama"></param>
        /// <param name="OdemeTutari">eğer 0 verilirse kalan fatura bakiyesini öder</param>
        /// <returns></returns>
        public OdemeDonenBilgisi FaturaninBakiyesininKalaniniNakitTahsilEt(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID, int KasaID, string Aciklama, decimal OdemeTutari, int KasaPersoneliID)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("FaturaninBakiyesininKalaniniNakitTahsilEt", Baglanti, Tr))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@FaturaID", SqlDbType.Int).Value = FaturaID;
                    cmd.Parameters.Add("@KasaID", SqlDbType.Int).Value = KasaID;
                    cmd.Parameters.Add("@OdemeTutari", SqlDbType.Decimal).Value = OdemeTutari;
                    cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;
                    cmd.Parameters.Add("@KasaPersoneliID", SqlDbType.Int).Value = KasaPersoneliID;

                    cmd.Parameters.Add("@RETURN_VALUE", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    cmd.ExecuteNonQuery();

                    int DonenDeger = (int)cmd.Parameters["@RETURN_VALUE"].Value;

                    return (OdemeDonenBilgisi)DonenDeger;
                    //string value = cmd.Parameters["@return_value"].Value.ToString();
                }
            }
            catch (Exception hata)
            {
                throw hata;
            }

        }
    }
}
