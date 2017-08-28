using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari.CariHr
{
    public class csCariHrArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        private string _CariAdi;
        private string _Carikodu;
        private string _HareketTipleri;
        private int _CariGrupID;
        private DateTime _IlkTarih;
        private DateTime _IkinciTarih;
        private int _KasaID;





        public string HareketTipleri
        {
            get { return _HareketTipleri; }
            set { _HareketTipleri = value; }
        }
        public string CariAdi
        {
            get { return _CariAdi; }
            set { _CariAdi = value; }
        }
        public string Carikodu
        {
            get { return _Carikodu; }
            set { _Carikodu = value; }
        }
        public int CariGrupID
        {
            get { return _CariGrupID; }
            set { _CariGrupID = value; }
        }
        public DateTime IlkTarih
        {
            get { return _IlkTarih; }
            set { _IlkTarih = value; }
        }
        public DateTime IkinciTarih
        {
            get { return _IkinciTarih; }
            set { _IkinciTarih = value; }
        }

        public int KasaID { get => _KasaID; set => _KasaID = value; }

        public csCariHrArama()
        {
            _CariAdi = string.Empty;
            _Carikodu = string.Empty;
            _HareketTipleri = string.Empty;
            _CariGrupID = -1;
            _IlkTarih = DateTime.MinValue;
            _IkinciTarih = DateTime.MinValue;
            _KasaID = -1;
        }

        SqlDataAdapter da;
        DataTable dt;


        public DataTable HareketleriGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter(@"CariHareketArama", Baglanti))
            {
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Transaction = Tr;

                if (!string.IsNullOrEmpty(_CariAdi))
                {
                    da.SelectCommand.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariAdi;
                }
                if (!string.IsNullOrEmpty(_Carikodu))
                {
                    //da.SelectCommand.CommandText += " and CariKod like @CariKod ";
                    da.SelectCommand.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _Carikodu;
                }
                if (!string.IsNullOrEmpty(_HareketTipleri))
                {
                    //da.SelectCommand.CommandText += " and Entegrasyon in (" + _HareketTipleri + ")";
                    //da.SelectCommand.Parameters.Add("@Entegrasyon", SqlDbType.NVarChar).Value = _HareketTipi;
                }
                if (_CariGrupID != -1)
                {
                    //da.SelectCommand.CommandText += " and CariGrupID = @CariGrupID ";
                    da.SelectCommand.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
                }
                if (_IlkTarih != DateTime.MinValue)
                {
                    //da.SelectCommand.CommandText += " and Tarih >= @IlkTarih ";
                    da.SelectCommand.Parameters.Add("@IlkTarih", SqlDbType.DateTime).Value = _IlkTarih;
                }
                if (_IkinciTarih != DateTime.MinValue)
                {
                    //da.SelectCommand.CommandText += " and Tarih <= @IkinciTarih ";
                    da.SelectCommand.Parameters.Add("@IkinciTarih", SqlDbType.DateTime).Value = _IkinciTarih;
                }

                if (_KasaID != -1)
                {
                    da.SelectCommand.Parameters.Add("@KasaID", SqlDbType.Int).Value = _KasaID;
                }

                if (!string.IsNullOrEmpty(HareketTipleri))
                {
                    da.SelectCommand.Parameters.Add("@HareketTipleri", SqlDbType.NVarChar).Value = HareketTipleri;
                }

                //da.SelectCommand.CommandText += " order by CariHr.Tarih asc ";
                using (dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
