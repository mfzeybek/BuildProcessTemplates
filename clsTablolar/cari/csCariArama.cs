using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
    public class csCariArama : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        private int _CariID;

        /// <summary>
        /// 0 hepsi - 1 aktif - 2 pasif
        /// </summary>
        private int _Aktif;
        private string _CariKod;
        private string _CariTanim;
        private string _OzelKod1;
        private string _OzelKod2;
        private string _OzelKod3;
        private string _VergiDairesi;
        private string _VergiNumarasi;
        private int _CariGrupID;
        private int _CariAltGrupID;
        private string _WebSayfasi;
        private string _Aciklama;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private DateTime _DegismeTarihi;
        private int _CariFiyatTanimID;


        // buradan sonrası için property oluşturmadın
        private decimal _iskOrani1;
        private decimal _iskOrani2;
        private decimal _iskOrani3;
        private int _SilindiMi;
        private string _BankaAdi;
        private string _BankaSubeAdi;
        private string _BankaSubeKodu;
        private string _BankaHesapNo;
        private string _BankaIbanNo;
        private string _BankaAciklama;
        private DateTime _BuTariheKadarOlanBakiyeBilgisi;

        public DateTime BuTariheKadarOlanBakiyeBilgisi
        {
            get { return _BuTariheKadarOlanBakiyeBilgisi; }
            set { _BuTariheKadarOlanBakiyeBilgisi = value; }
        }



        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
        }
        public int Aktif
        {
            get { return _Aktif; }
            set { _Aktif = value; }
        }
        public string CariKod
        {
            get { return _CariKod; }
            set { _CariKod = value; }
        }
        public string CariTanim
        {
            get { return _CariTanim; }
            set { _CariTanim = value; }
        }
        public string OzelKod1
        {
            get { return _OzelKod1; }
            set { _OzelKod1 = value; }
        }
        public string OzelKod2
        {
            get { return _OzelKod2; }
            set { _OzelKod2 = value; }
        }
        public string OzelKod3
        {
            get { return _OzelKod3; }
            set { _OzelKod3 = value; }
        }
        public string VergiDairesi
        {
            get { return _VergiDairesi; }
            set { _VergiDairesi = value; }
        }
        public string VergiNumarasi
        {
            get { return _VergiNumarasi; }
            set { _VergiNumarasi = value; }
        }
        public int CariGrupID
        {
            get { return _CariGrupID; }
            set { _CariGrupID = value; }
        }
        public int CariAltGrupID
        {
            get { return _CariAltGrupID; }
            set { _CariAltGrupID = value; }
        }
        public string WebSayfasi
        {
            get { return _WebSayfasi; }
            set { _WebSayfasi = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
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
        private int _DegistirenID;
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
        public int CariFiyatTanimID
        {
            get { return _CariFiyatTanimID; }
            set { _CariFiyatTanimID = value; }
        }


        public csCariArama()
        {
            _Aktif = 0;
            _CariKod = string.Empty;
            _CariTanim = string.Empty;
            _OzelKod1 = string.Empty;
            _OzelKod2 = string.Empty;
            _OzelKod3 = string.Empty;
            _VergiDairesi = string.Empty;
            _VergiNumarasi = string.Empty;
            _CariGrupID = -1;
            _CariAltGrupID = -1;
            _WebSayfasi = string.Empty;
            _Aciklama = string.Empty;
            _BuTariheKadarOlanBakiyeBilgisi = DateTime.MaxValue;
            //_KaydedenID = ;
            //_KayitTarihi = ;
            //_DegismeTarihi = ;
            //_CariFiyatTanimID = ;
        }
        SqlDataAdapter da;
        public DataTable dt;
        public DataTable CariListesi(SqlConnection Baglanti, SqlTransaction Tr)
        {
            using (da = new SqlDataAdapter(@"
select Cari.CariID, Aktif, CariKod, CariTanim, OzelKod1,OzelKod2, OzelKod3, VergiDairesi, VergiNumarasi, Cari.CariGrupID, CariAltGrupID, WebSayfasi, Cari.Aciklama, Cari.KaydedenID, Cari.KayitTarihi, DegistirenID,  DegistirenID, CariFiyatTanimID, iskOrani1, iskOrani2, iskOrani3, SilindiMi ,BankaAdi 
,BankaSubeAdi, BankaSubeKodu, BankaHesapNo, BankaIbanNo, BankaAciklama,  isnull(AlaakBakiyesi.AlacakTutari,0) 'AlacakBakiye', isnull(BorcBakiyesi.BorcTutari,0) 'BorcBakiye', isnull(
case 
when isnull(AlaakBakiyesi.AlacakTutari, 0) > isnull(BorcBakiyesi.BorcTutari, 0 ) 
then isnull(AlaakBakiyesi.AlacakTutari, 0) - isnull(BorcBakiyesi.BorcTutari, 0 )
when isnull(BorcBakiyesi.BorcTutari, 0 ) > isnull(AlaakBakiyesi.AlacakTutari, 0)
then isnull(BorcBakiyesi.BorcTutari, 0 ) - isnull(AlaakBakiyesi.AlacakTutari, 0)
end, 0)
 as BakiyeTutari,
 case 
when isnull(AlaakBakiyesi.AlacakTutari, 0) > isnull(BorcBakiyesi.BorcTutari, 0 ) 
then 'Alacak Bakiye'
when isnull(BorcBakiyesi.BorcTutari, 0 ) > isnull(AlaakBakiyesi.AlacakTutari, 0)
then 'Borç Bakiye'
else 'Sıfır'
end  as BakiyeTuru,
Adres.*, Telefon.Numara, Telefon.Aciklama as TelefonAciklama
from cari 
left join CariGrup on CariGrup.CariGrupID = Cari.CariGrupID
left join (select isnull(SUM(Tutar), 0) AlacakTutari, CariHr.CariID from CariHr where AlacakMiBorcMu = 2 and SilindiMi = 0 and convert(date, Tarih, 1) <= @Tarih group by CariID) AlaakBakiyesi on AlaakBakiyesi.CariID = Cari.CariID
left join (select isnull(SUM(Tutar), 0) BorcTutari, CariHr.CariID from CariHr where AlacakMiBorcMu = 3 and SilindiMi = 0 and convert(date, Tarih, 1) <=  @Tarih group by CariID) BorcBakiyesi on BorcBakiyesi.CariID = Cari.CariID

left join 
(	select Adres.Adres, Adres.Aciklama, SehirAdi, IlceAdi, UlkeAdi, CariID from Adres
	left join Ulke on Ulke.UlkeID = Adres.UlkeID
	left join Sehir on Sehir.SehirID = Adres.SehirID
	left join Ilce on Ilce.IlceID = Adres.IlceID
	where Varsayilan = 1
) Adres on Adres.CariID = Cari.CariID

left join Telefon on Telefon.CariID = Cari.CariID and Telefon.Varsayilan = 1

where 1 = 1 ", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _BuTariheKadarOlanBakiyeBilgisi;

                if (!string.IsNullOrEmpty(_CariKod))
                {
                    da.SelectCommand.CommandText += " and CariKod like '%'+@CariKod+'%'";
                    da.SelectCommand.Parameters.Add("@CariKod", SqlDbType.NVarChar).Value = _CariKod;
                }
                if (!string.IsNullOrEmpty(_CariTanim))
                {
                    da.SelectCommand.CommandText += " and CariTanim like '%'+@CariTanim+'%'";
                    da.SelectCommand.Parameters.Add("@CariTanim", SqlDbType.NVarChar).Value = _CariTanim;
                }
                if (_CariGrupID != -1)
                {
                    da.SelectCommand.CommandText += " and Cari.CariGrupID = @CariGrupID ";
                    da.SelectCommand.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
                }
                if (_CariAltGrupID != -1)
                {
                    da.SelectCommand.CommandText += " and CariAltGrupID = @CariAltGrupID ";
                    da.SelectCommand.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = _CariAltGrupID;
                }

                using (dt = new DataTable())
                {
                    da.Fill(dt);
                    return dt;
                }
            }
        }
    }
}
