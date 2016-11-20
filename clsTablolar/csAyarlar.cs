  using System;
using System.Data.SqlClient;

namespace clsTablolar
{
    public class csAyarlar : IDisposable
    {
        private static int _AyarID;
        private static int _SatisFaturasiIcinFiyatTanimID;
        private static int _SatisFaturasiDepoID;
        private static int _SatisFaturasiSatisElemaniID;
        private static int _StokAlisFiyatTanimID;


        public static int AyarID
        {
            get { return _AyarID; }
            set { _AyarID = value; }
        }
        public static int SatisFaturasiIcinFiyatTanimID
        {
            get { return _SatisFaturasiIcinFiyatTanimID; }
            set { _SatisFaturasiIcinFiyatTanimID = value; }
        }
        public static int SatisFaturasiDepoID
        {
            get { return csAyarlar._SatisFaturasiDepoID; }
            set { csAyarlar._SatisFaturasiDepoID = value; }
        }
        public static int SatisFaturasiSatisElemaniID
        {
            get { return csAyarlar._SatisFaturasiSatisElemaniID; }
            set { csAyarlar._SatisFaturasiSatisElemaniID = value; }
        }
        public static int StokAlisFiyatTanimID
        {
          get { return csAyarlar._StokAlisFiyatTanimID; }
          set { csAyarlar._StokAlisFiyatTanimID = value; }
        }


        SqlCommand cmdGenel;
        SqlDataReader drGenel;

        public csAyarlar(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmdGenel = new SqlCommand())
            {
                cmdGenel.Connection = Baglanti;
                cmdGenel.Transaction = Tr;
                cmdGenel.CommandText = @"SELECT AyarID, SatisFaturasiIcinFiyatTanimID, SatisFaturasiDepoID, SatisFaturasiSatisElemaniID, StokAlisFiyatTanimID from Ayarlar";

                using (drGenel = cmdGenel.ExecuteReader())
                {
                    drGenel.Read();
                    _AyarID = Convert.ToInt32(drGenel["AyarID"]);
                    _SatisFaturasiDepoID = Convert.ToInt32(drGenel["SatisFaturasiDepoID"]);
                    _SatisFaturasiIcinFiyatTanimID = Convert.ToInt32(drGenel["SatisFaturasiIcinFiyatTanimID"]);
                    _SatisFaturasiSatisElemaniID = Convert.ToInt32(drGenel["SatisFaturasiSatisElemaniID"]);
                    _StokAlisFiyatTanimID = Convert.ToInt32(drGenel["StokAlisFiyatTanimID"]);
                }
            }
        }

        public void AyarlariKaydet()
        {

        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

