using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.TeraziSatisClaslari
{
    public class csSatislar : IDisposable
    {
        public void Dispose()
        {

            GC.SuppressFinalize(this);
        }

        public DataTable dt_satislar;

        // Fatura Tablosuna Kayıt işlemleri için hamısına (faturaHarekete değil dikkat hamısına)
        /// <summary>
        /// TeraziID yi vererek O terazide işlem yapmış tüm 
        /// </summary>
        /// <param name="Baglanti"></param>
        /// <param name="Tr"></param>
        /// <param name="TeraziID"></param>





    }
}
