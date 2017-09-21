using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStokGrup : IDisposable
    {
        public DataTable dt;
        private SqlDataAdapter da;

        #region Değişkenler
        private int _StokGrupID;
        private string _StokGrupAdi;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _DegistirenID;
        private DateTime _DegismeTarihi;
        #endregion

        #region Methodlar
        public int StokGrupID
        {
            get { return _StokGrupID; }
            set { _StokGrupID = value; }
        }
        public string StokGrupAdi
        {
            get { return _StokGrupAdi; }
            set { _StokGrupAdi = value; }
        }
        public int KaydedenID
        {
            get { return _KaydedenID; }
            set { _KaydedenID = value; }
        }
        public DateTime KayitTarihi
        {
            get { return _KayitTarihi; }
            set { _KayitTarihi = value; }
        }
        public int DegistirenID
        {
            get { return _DegistirenID; }
            set { _DegistirenID = value; }
        }
        public DateTime DegismeTarihi
        {
            get { return _DegismeTarihi; }
            set { _DegismeTarihi = value; }
        }
        #endregion

        #region Genel DeğişkEnler
        SqlCommand cmdGenel;
        SqlDataReader drGenel;
        #endregion

        public csStokGrup()
        { }

        public csStokGrup(SqlConnection Baglanti, SqlTransaction trGenel, int stokGrupID)
        {
            if (stokGrupID == -1)
            {
                _StokGrupID = -1;
                _StokGrupAdi = "";
                _KaydedenID = -1;
                _KayitTarihi = DateTime.Now;
                _DegistirenID = -1;
                _DegismeTarihi = DateTime.MinValue;
            }
            else
            {
                StokGrupGetir(Baglanti, trGenel, stokGrupID);
            }
        }
        private void StokGrupGetir(SqlConnection Baglanti, SqlTransaction trGenel, int stokGrupID)
        {
            //using (cmdGenel = new SqlCommand())
            //{
            //  cmdGenel.Connection = Baglanti;
            //  cmdGenel.Transaction = trGenel;
            //  cmdGenel.CommandText = @"SELECT StokGrupID, StokGrupAdi,KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi FROM dbo.StokGrup WHERE (StokGrupID = @StokGrupID)";
            //  cmdGenel.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = stokGrupID;
            //  using (drGenel = cmdGenel.ExecuteReader())
            //  {
            //    if (drGenel.Read())
            //    {
            //      _StokGrupID = Convert.ToInt32(drGenel["StokGrupID"].ToString());
            //      _StokGrupAdi = drGenel["StokGrupAdi"].ToString();
            //      _KaydedenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["KaydedenID"]));
            //      _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
            //      _DegistirenID = Convert.ToInt32(IDBossaEksiBirVer(drGenel["GuncelleyenID"]));
            //      _DegismeTarihi = TarihBossaMinTarihVer(drGenel["GuncellemeTarihi"]);
            //    }
            //  }
            //}
        }

        public void StokGrupKAydet(SqlConnection Baglanti, SqlTransaction trGenel)
        {
            if (_StokGrupID == -1)
            {
                bool KayitVar = false;
                cmdGenel = new SqlCommand(@" SELECT StokGrupID From StokGrup Where StokGrupAdi=@StokGrupAdi", Baglanti, trGenel);
                cmdGenel.Parameters.Add("@StokGrupAdi", SqlDbType.NVarChar).Value = _StokGrupAdi;

                using (SqlDataReader dr = cmdGenel.ExecuteReader(CommandBehavior.SingleResult))
                {
                    if (dr.Read())
                        KayitVar = true;
                }
                if (KayitVar)
                    return;
                cmdGenel.Dispose();
                cmdGenel = new SqlCommand(@"
insert into StokGrup(StokGrupAdi,KaydedenID,KayitTarihi)
Values(@StokGrupAdi,@KaydedenID,@KayitTarihi) set @YeniID = SCOPE_IDENTITY() ", Baglanti, trGenel);
                cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
                cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
            }
            else
            { // buralarda degistirenID ve Degisme Tarihinde hata var sql de farklı kaydedilmiş
                cmdGenel = new SqlCommand(@"update StokGrup set StokGrupAdi=@StokGrupAdi,DegistirenID=@DegistirenID, DegismeTarihi=@DegismeTarihi
where StokGrupID = @StokGrupID", Baglanti, trGenel);

                cmdGenel.Parameters.Add("@DegismeTarihi", SqlDbType.DateTime).Value = DateTime.Now;
                cmdGenel.Parameters.Add("@DegistirenID", SqlDbType.Int).Value = _DegistirenID;
                cmdGenel.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = _StokGrupID;
            }

            cmdGenel.Parameters.Add("@StokGrupAdi", SqlDbType.NVarChar).Value = _StokGrupAdi;
            try
            {
                cmdGenel.ExecuteNonQuery();
                if (_StokGrupID == -1)
                    _StokGrupID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }

        private DateTime TarihBossaMinTarihVer(Object Tarih)
        {
            DateTime Tarihh;
            if (DateTime.TryParse(Tarih.ToString(), out Tarihh) == false)
                Tarihh = DateTime.MinValue;

            return Tarihh;
        }

        private string IDBossaEksiBirVer(object ID)
        {
            string ID2 = "";
            if (ID == null || ID.ToString() == "" || ID == DBNull.Value)
            {
                ID2 = "-1";
            }
            else
            {
                ID2 = ID.ToString();
            }
            return ID2;
        }

        public void StokGrupGuncelle(SqlConnection Baglanti)
        {
            da.UpdateCommand = new SqlCommand("Update StokGrup set StokGrupAdi = @StokGrupAdi where StokGrupID = @StokGrupID", Baglanti);
            da.UpdateCommand.Parameters.Add("@StokGrupAdi", SqlDbType.Int, 10, "StokGrupAdi");
            da.UpdateCommand.Parameters.Add("@StokGrupID", SqlDbType.NVarChar, 10, "StokGrupID");

            da.InsertCommand = new SqlCommand("insert into StokGrup (StokGrupAdi) values (@StokGrupAdi)", Baglanti);
            da.InsertCommand.Parameters.Add("@StokGrupAdi", SqlDbType.NVarChar, 10, "StokGrupAdi");


            da.DeleteCommand = new SqlCommand("delete StokGrup where StokGrupID = @StokGrupID", Baglanti);
            da.DeleteCommand.Parameters.Add("@StokGrupID", SqlDbType.Int, 10, "StokGrupID");

            da.Update(dt);
        }

        public DataTable StokGrupDoldur(SqlConnection Baglanti, SqlTransaction tr)
        {
            try
            {
                using (da = new SqlDataAdapter())
                {
                    da.SelectCommand = new SqlCommand("SELECT StokGrupID, UstGrupID ,StokGrupAdi from StokGrup", Baglanti);
                    da.SelectCommand.Transaction = tr;
                    using (dt = new DataTable())
                    {
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
            catch (Exception hata)
            {
                throw new Exception(hata.Message);
            }
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
