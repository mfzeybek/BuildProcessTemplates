using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok.StokHareket
{
    public class StokHrArama : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        private string _StokKodu;


        private string _StokAdi;
        // 2 çıkış 1 giriş
        private int _GirisCikis;
        private DateTime _IlkTarih;
        private DateTime _IkinciTarih;
        private int _StokGrupID;
        private int _StokAraGrupID;
        private int _StokAltGrupID;
        private clsTablolar.Stok.csStokGrubuField[] _SeciliGruplar;
        private bool _StokGrupHepsiniGetir;


        public string StokKodu
        {
            get { return _StokKodu; }
            set { _StokKodu = value; }
        }
        public string StokAdi
        {
            get { return _StokAdi; }
            set { _StokAdi = value; }
        }

        /// <summary>
        /// 2 çıkış 1 giriş
        /// </summary>
        public int GirisCikis
        {
            get { return _GirisCikis; }
            set { _GirisCikis = value; }
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

        public int StokGrupID
        {
            get
            {
                return _StokGrupID;
            }

            set
            {
                _StokGrupID = value;
            }
        }

        public int StokAraGrupID
        {
            get
            {
                return _StokAraGrupID;
            }

            set
            {
                _StokAraGrupID = value;
            }
        }

        public int StokAltGrupID
        {
            get
            {
                return _StokAltGrupID;
            }

            set
            {
                _StokAltGrupID = value;
            }
        }

        public csStokGrubuField[] SeciliGruplar { get => _SeciliGruplar; set => _SeciliGruplar = value; }
        public bool StokGrupHepsiniGetir { get => _StokGrupHepsiniGetir; set => _StokGrupHepsiniGetir = value; }

        SqlDataAdapter da;
        public DataTable dt;

        public StokHrArama()
        {
            _StokKodu = "";
            _StokAdi = "";
            _GirisCikis = 0;
            _IlkTarih = DateTime.MinValue;
            _IkinciTarih = DateTime.MinValue;
            _StokGrupID = -1;
            _StokAraGrupID = -1;
            _StokAltGrupID = -1;
        }

        public DataTable HareketleriGetir(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da = new SqlDataAdapter(@"
select Stok.StokID, Stok.StokAdi, Stok.StokKodu, StokHr.StokHrID, StokHr.Tarih
, ISNULL(StokHr.Miktar, 0) Miktar, StokHr.Entegrasyon, StokHr.EntegrasyonID, StokHr.EvrakNo, StokHr.Aciklama, StokHr.CariID
, StokHr.KaydedenID, StokHr.KayitTarihi, StokHr.DegistirenID, StokHr.DegistirmeTarihi, StokHr.GirisMiCikisMi, StokHr.SilindiMi, StokHr.Fiyat, Cari.CariTanim,
case
when GirisMiCikisMi = 1 then
'Giriş' 
when GirisMiCikisMi = 2 then 'Çıkış' 
end As 'HareketYonu' 
,
case
when GirisMiCikisMi = 1 then -- giriş
ISNULL(StokHr.Miktar, 0)
when GirisMiCikisMi = 2 then -- 'Çıkış' 
0
end As 'GirişMiktari' 
, case
when GirisMiCikisMi = 1 then -- Giriş
0
when GirisMiCikisMi = 2 then -- 'Çıkış' 
ISNULL(StokHr.Miktar, 0)
end As 'CikisMiktari' 
, [dbo].[StokMiktari](Stok.StokID) KalanMiktar
from stokhr  

inner join Stok on Stok.StokID = StokHr.StokID 
LEFT Join Cari on Cari.cariID = StokHr.CariID

where stokhr.SilindiMi = 0  ", Baglanti);
            da.SelectCommand.Transaction = Tr;


            if (_StokKodu != "")
            {
                da.SelectCommand.CommandText += "and StokKodu = @StokKodu ";
                da.SelectCommand.Parameters.Add("@StokKodu", SqlDbType.NVarChar).Value = _StokKodu;
            }
            if (_StokAdi != "")
            {
                da.SelectCommand.CommandText += "and StokAdi like @StokAdi ";
                da.SelectCommand.Parameters.Add("@StokAdi", SqlDbType.NVarChar).Value = _StokAdi;
            }
            if (_GirisCikis != 0)
            {
                da.SelectCommand.CommandText += " and GirisMiCikisMi = @GirisMiCikisMi ";
                da.SelectCommand.Parameters.Add("@GirisMiCikisMi", SqlDbType.TinyInt).Value = _GirisCikis;
            }

            if (_IlkTarih != DateTime.MinValue)
            {
                da.SelectCommand.CommandText += " and convert(date, StokHr.Tarih, 1) >= @Tarih1 ";
                da.SelectCommand.Parameters.Add("@Tarih1", SqlDbType.DateTime).Value = _IlkTarih.Date;
            }
            if (_IkinciTarih != DateTime.MinValue)
            {
                da.SelectCommand.CommandText += " and convert(date, StokHr.Tarih, 1) <= @Tarih2 ";
                da.SelectCommand.Parameters.Add("@Tarih2", SqlDbType.DateTime).Value = _IkinciTarih.Date;
            }
            if (_StokGrupID != -1)
            {
                da.SelectCommand.CommandText += " and Stok.StokGrupID =  @StokGrupID ";
                da.SelectCommand.Parameters.Add("@StokGrupID", SqlDbType.Int).Value = _StokGrupID;
            }
            if (_StokAraGrupID != -1)
            {
                da.SelectCommand.CommandText += " and Stok.StokAraGrupID =  @StokAraGrupID ";
                da.SelectCommand.Parameters.Add("@StokAraGrupID", SqlDbType.Int).Value = _StokAraGrupID;
            }
            if (_StokAltGrupID != -1)
            {
                da.SelectCommand.CommandText += " and Stok.StokAltGrupID =  @StokAltGrupID ";
                da.SelectCommand.Parameters.Add("@StokAltGrupID", SqlDbType.Int).Value = _StokAltGrupID;
            }
            if (_SeciliGruplar != null && _SeciliGruplar.Length != 0)
            {

                if (StokGrupHepsiniGetir)
                    da.SelectCommand.CommandText += " and ( 1 = 2 ";

                foreach (var item in _SeciliGruplar)
                {
                    if (StokGrupHepsiniGetir)
                        da.SelectCommand.CommandText += @" or ";
                    else
                        da.SelectCommand.CommandText += @" and ";
                    //da.SelectCommand.CommandText += " and s.StokID in (select StokID from StokGrupV2 where StokGrupID = " + item.StokGrupID +")";
                    da.SelectCommand.CommandText += @" Stok.StokID in (select StokID from[dbo].[StokAltGruplariniBul] (" + item.StokGrupID + ") as ahanda " +
" inner join StokGrupV2 on StokGrupV2.StokGrupID = ahanda.StokGrupID) ";
                }
                if (StokGrupHepsiniGetir)
                    da.SelectCommand.CommandText += " ) ";

            }


            dt = new DataTable();
            da.Fill(dt);


            return dt;
        }
    }
}
