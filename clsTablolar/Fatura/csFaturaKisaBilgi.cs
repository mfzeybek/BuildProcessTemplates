using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Fatura
{
    public class csFaturaKisaBilgi : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private int _FaturaID;
        private int _FaturaCariID;
        private decimal _FaturaTutari;
        private clsTablolar.IslemTipi _FaturaTipi;
        private decimal _FaturaBakiyesi;


        public int FaturaID
        {
            get { return _FaturaID; }
            set { _FaturaID = value; }
        }
        public int FaturaCariID
        {
            get { return _FaturaCariID; }
            set { _FaturaCariID = value; }
        }
        public decimal FaturaTutari
        {
            get { return _FaturaTutari; }
            set { _FaturaTutari = value; }
        }
        public clsTablolar.IslemTipi FaturaTipi
        {
            get { return _FaturaTipi; }
            set { _FaturaTipi = value; }
        }
        public decimal FaturaBakiyesi
        {
            get { return _FaturaBakiyesi; }
            set { _FaturaBakiyesi = value; }
        }

        public void Getir(SqlConnection Baglanti, SqlTransaction Tr, int FaturaID)
        {
            using (SqlCommand cmd = new SqlCommand("", Baglanti, Tr))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        //_FaturaID = dr["FaturaID"];
                        //_FaturaCariID = dr[""];
                        //_FaturaTutari = dr[""];
                        //_FaturaTipi = dr[""];
                        //_FaturaBakiyesi = dr[""];
                    }
                }
            }
        }
    }
}
