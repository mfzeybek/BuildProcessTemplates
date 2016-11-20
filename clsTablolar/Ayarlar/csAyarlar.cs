using System;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.Ayarlar
{
    public class csAyarlar : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        // Standart Sürekli Ulaşmak isteyeceğimiz Ayarları Burada topluyoruz



        #region Satış Faturası
        private static int _SatisFaturasiFiyatTanimID;
        public static int SatisFaturasiFiyatTanimID
        {
            get { return csAyarlar._SatisFaturasiFiyatTanimID; }
            set { csAyarlar._SatisFaturasiFiyatTanimID = value; }
        }

        private static int _SatisFaturasiDepoID;
        public static int SatisFaturasiDepoID
        {
            get { return csAyarlar._SatisFaturasiDepoID; }
            set { csAyarlar._SatisFaturasiDepoID = value; }
        }

        private static int _SatisFaturasiSatisElemaniID;

        public static int SatisFaturasiSatisElemaniID
        {
            get { return csAyarlar._SatisFaturasiSatisElemaniID; }
            set { csAyarlar._SatisFaturasiSatisElemaniID = value; }
        }

        #endregion


        #region Alış Faturası
        private static int _AlisFaturasiFiyatTanimID;
        public static int AlisFaturasiFiyatTanimID
        {
            get { return csAyarlar._AlisFaturasiFiyatTanimID; }
            set { csAyarlar._AlisFaturasiFiyatTanimID = value; }
        }

        private static int _AlisFaturasiDepoID;
        public static int AlisFaturasiDepoID
        {
            get { return csAyarlar._AlisFaturasiDepoID; }
            set { csAyarlar._AlisFaturasiDepoID = value; }
        }

        #endregion


        private static int _StokAlisFiyatTanimID;

        public static int StokAlisFiyatTanimID
        {
            get { return csAyarlar._StokAlisFiyatTanimID; }
            set { csAyarlar._StokAlisFiyatTanimID = value; }
        }

        #region Sipariş
        private static int _AlinanSiparisDepoID;
        public static int AlinanSiparisDepoID
        {
            get { return csAyarlar._AlinanSiparisDepoID; }
            set { csAyarlar._AlinanSiparisDepoID = value; }
        }

        private static int _VerilenSiparisDepoID;
        public static int VerilenSiparisDepoID
        {
            get { return csAyarlar._VerilenSiparisDepoID; }
            set { csAyarlar._VerilenSiparisDepoID = value; }
        }

        private static int _AlinanSiparisIcinFiyatTanimID;
        public static int AlinanSiparisIcinFiyatTanimID
        {
            get { return csAyarlar._AlinanSiparisIcinFiyatTanimID; }
            set { csAyarlar._AlinanSiparisIcinFiyatTanimID = value; }
        }

        private static string _StokListeFiyatTanimlari;
        public static string StokListeFiyatTanimlari
        {
            get { return csAyarlar._StokListeFiyatTanimlari; }
            set { csAyarlar._StokListeFiyatTanimlari = value; }
        }


        #endregion

        #region BarkodAyarlari
        private static DataTable _BarkodAyarlari;
        public static DataTable BarkodAyarlari
        {
            get { return csAyarlar._BarkodAyarlari; }
            set { csAyarlar._BarkodAyarlari = value; }
        }
        #endregion

        public static int TeraziVarsayilanCariID {get; set;}


        SqlCommand cmd;
        SqlDataReader dr;

        // daha sonra bu kısmı ayırabilirsin

        //program tek bir ayar kaydedecek şekilde ayarlı şimdilik

        public csAyarlar(SqlConnection Baglanti, SqlTransaction TR)
        {
            Getir(Baglanti, TR);
            BarkodAyarlariniGetir(Baglanti, TR);
        }

        public void AyarlariKaydet(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmd = new SqlCommand(@"update Ayarlar set SatisFaturasiIcinFiyatTanimID = @SatisFaturasiIcinFiyatTanimID, 
        SatisFaturasiDepoID = @SatisFaturasiDepoID, SatisFaturasiSatisElemaniID = @SatisFaturasiSatisElemaniID,  
        StokAlisFiyatTanimID = @StokAlisFiyatTanimID, AlisFaturasiDepoID = @AlisFaturasiDepoID, TeraziVarsayilanCariID = @TeraziVarsayilanCariID", Baglanti, Tr))
            {
                cmd.Parameters.Add("@SatisFaturasiIcinFiyatTanimID", SqlDbType.Int).Value = _SatisFaturasiFiyatTanimID;
                cmd.Parameters.Add("@SatisFaturasiDepoID", SqlDbType.Int).Value = _SatisFaturasiDepoID;
                cmd.Parameters.Add("@SatisFaturasiSatisElemaniID", SqlDbType.Int).Value = _SatisFaturasiSatisElemaniID;
                cmd.Parameters.Add("@StokAlisFiyatTanimID", SqlDbType.Int).Value = _AlisFaturasiFiyatTanimID;
                cmd.Parameters.Add("@AlisFaturasiDepoID", SqlDbType.Int).Value = _AlisFaturasiDepoID;
                cmd.Parameters.Add("@TeraziVarsayilanCariID", SqlDbType.Int).Value = TeraziVarsayilanCariID;

                cmd.ExecuteNonQuery();
            }
        }


        // burada program ilk defa kurulduğunda ilk değerleri almasını sağlayacak bişi olması lazım
        public void Getir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (cmd = new SqlCommand(@"select AyarID, SatisFaturasiIcinFiyatTanimID, SatisFaturasiDepoID, SatisFaturasiSatisElemaniID, StokAlisFiyatTanimID, 
          AlisFaturasiDepoID, AlinanSiparisDepoID, VerilenSiparisDepoID, AlinanSiparisIcinFiyatTanimID, StokListeFiyatTanimlari, TeraziVarsayilanCariID from Ayarlar", Baglanti, Tr))
            {
                using (dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {

                        // TODO: belirtilen atama geçerli değil diye hata vermemesi için bütün alanlar dolu olması lazım dolu değilse -1 verdirt
                        _SatisFaturasiFiyatTanimID = (int)dr["SatisFaturasiIcinFiyatTanimID"];
                        _SatisFaturasiDepoID = (int)dr["SatisFaturasiDepoID"];
                        _SatisFaturasiSatisElemaniID = (int)dr["SatisFaturasiSatisElemaniID"];

                        _AlisFaturasiFiyatTanimID = (int)dr["StokAlisFiyatTanimID"]; // bunu hem faturada hem siparişte aslında heryerde kullandığın için adını değiştir.
                        _StokAlisFiyatTanimID = (int)dr["StokAlisFiyatTanimID"];
                        _AlisFaturasiDepoID = (int)dr["AlisFaturasiDepoID"];


                        _AlinanSiparisDepoID = (int)dr["AlinanSiparisDepoID"];
                        _VerilenSiparisDepoID = (int)dr["VerilenSiparisDepoID"];
                        _AlinanSiparisIcinFiyatTanimID = (int)dr["AlinanSiparisIcinFiyatTanimID"];
                        _StokListeFiyatTanimlari = dr["StokListeFiyatTanimlari"].ToString();
                        TeraziVarsayilanCariID = (int)dr["TeraziVarsayilanCariID"];
                    }
                }
            }
        }

        public void BarkodAyarlariniGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (Ayarlar.csBarkodAyar Bayar = new csBarkodAyar())
            {
                Bayar.Getir(Baglanti, Tr);
                _BarkodAyarlari = Bayar.dt;
            }
        }

    }
}
