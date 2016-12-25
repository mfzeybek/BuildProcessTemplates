using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Stok
{
    public class csStokHr : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }



        private int _StokHrID;
        private int _StokID;
        private DateTime _Tarih;
        private decimal _Miktar;
        private int _Entegrasyon;
        private string _EvrakNo;
        private string _Aciklama;
        private int _CariID;
        private int _KaydedenID;
        private DateTime _KayitTarihi;
        private int _DegistirenID;
        private DateTime _DegistirmeTarihi;
        private int _GirisMiCikisMi;
        private decimal _Fiyat;

        public int StokHrID
        {
            get { return _StokHrID; }
            set { _StokHrID = value; }
        }
        public int StokID
        {
            get { return _StokID; }
            set { _StokID = value; }
        }
        public DateTime Tarih
        {
            get { return _Tarih; }
            set { _Tarih = value; }
        }
        public decimal Miktar
        {
            get { return _Miktar; }
            set { _Miktar = value; }
        }
        public int Entegrasyon
        {
            get { return _Entegrasyon; }
            set { _Entegrasyon = value; }
        }
        public string EvrakNo
        {
            get { return _EvrakNo; }
            set { _EvrakNo = value; }
        }
        public string Aciklama
        {
            get { return _Aciklama; }
            set { _Aciklama = value; }
        }
        public int CariID
        {
            get { return _CariID; }
            set { _CariID = value; }
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
        public DateTime DegistirmeTarihi
        {
            get { return _DegistirmeTarihi; }
            set { _DegistirmeTarihi = value; }
        }

        public int GirisMiCikisMi
        {
            get
            {
                return _GirisMiCikisMi;
            }

            set
            {
                _GirisMiCikisMi = value;
            }
        }

        public decimal Fiyat
        {
            get
            {
                return _Fiyat;
            }

            set
            {
                _Fiyat = value;
            }
        }

        SqlCommand cmd;
        SqlDataReader dr;


        //  ENTEGRASYON

        //1 Devir Girişi
        //2 Stok girişi
        //3 Stok çıkışı
        //4 Alış faturası
        //5 Satış faturası
        //6 Alıştan iade
        //7 Satıştan iade


        public csStokHr(SqlConnection Baglanti, SqlTransaction Tr, int StokHrID)
        {
            if (StokHrID == -1)
            {
                _StokHrID = -1;
                _StokID = -1;
                _Tarih = DateTime.Now;
                _Miktar = 0;
                _Entegrasyon = -1;
                _EvrakNo = "";
                _Aciklama = "";
                _CariID = -1;
                _KaydedenID = -1;
                _KayitTarihi = DateTime.Now;
                _DegistirenID = -1;
                _DegistirmeTarihi = DateTime.Now;
            }
            else
            {
                using (cmd = new SqlCommand("select * from StokHr where StokHrID = @StokHrID", Baglanti, Tr))
                {
                    cmd.Parameters.Add("@StokHrID", SqlDbType.Int).Value = StokHrID;

                    dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        _StokHrID = Convert.ToInt32(dr["StokHrID"]);
                        _StokID = Convert.ToInt32(dr["StokID "]);
                        _Tarih = Convert.ToDateTime(dr["Tarih"]);
                        _Miktar = Convert.ToDecimal(dr["Miktar"]);
                        _Entegrasyon = Convert.ToInt16(dr["Entegrasyon"]);
                        _EvrakNo = dr["EvrakNo"].ToString();
                        _Aciklama = dr["Aciklama"].ToString();
                        _CariID = Convert.ToInt32(dr["CariID"]);
                    }
                }
            }




        }
        public csStokHr() { }
        public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int StokHrID)
        {
            using (cmd = new SqlCommand())
            {
                if (StokHrID == -1)
                {
                    cmd.CommandText = @"insert into StokHr 
        (StokID, Tarih, Miktar, Entegrasyon, EvrakNo, Aciklama, CariID, KaydedenID, KayitTarihi, DegistirenID, DegistirmeTarihi)
        values(@StokID, @Tarih, @Miktar, @Entegrasyon, @EvrakNo, @Aciklama, @CariID)
        set @YeniID = SCOPE_IDENTITY()";
                    cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                }
                else
                {
                    cmd.CommandText = @"update StokHr set StokHrID = @StokHrID, StokID = @StokID, Tarih = @Tarih, Miktar = @Miktar, 
Entegrasyon = @Entegrasyon, EvrakNo = @EvrakNo, Aciklama = @Aciklama, CariID = @CariID where StokHrID = @StokHrID ";
                    cmd.Parameters.Add("@StokHrID", SqlDbType.Int).Value = _StokHrID;
                }

                cmd.Transaction = Tr;
                cmd.Connection = Baglanti;


                cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = _StokID;
                cmd.Parameters.Add("@Tarih", SqlDbType.DateTime).Value = _Tarih;
                cmd.Parameters.Add("@Miktar", SqlDbType.Decimal).Value = _Miktar;
                cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = _Entegrasyon;
                cmd.Parameters.Add("@EvrakNo", SqlDbType.TinyInt).Value = _EvrakNo;

                cmd.Parameters.Add("@Aciklama", SqlDbType.TinyInt).Value = _Aciklama;
                cmd.Parameters.Add("@CariID", SqlDbType.TinyInt).Value = _CariID;
                cmd.Parameters.Add("@Entegrasyon", SqlDbType.TinyInt).Value = _Entegrasyon;
                cmd.Parameters.Add("@EvrakNo", SqlDbType.TinyInt).Value = _EvrakNo;

                cmd.ExecuteNonQuery();
                if (_StokHrID == -1)
                    _StokHrID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
            }
        }


        public void Sil(SqlConnection Baglanti, SqlTransaction Tr, int StokHrID)
        {
            using (cmd = new SqlCommand("delete from  StokHr where StokHrID = @StokHrID ", Baglanti, Tr))
            {
                cmd.Parameters.Add("@StokHrID", SqlDbType.Int).Value = StokHrID;

                cmd.ExecuteNonQuery();
            }
        }

        public csStokHr(SqlConnection Baglanti, SqlTransaction Tr, IslemTipi Entegrasyon, int EntegrasyonID)
        {
            SqlCommand cmd = new SqlCommand("select * from stokhr where Entegrasyon = @Entegrasyon and EntegrasyonID = @EntegrasyonID");
            cmd.Parameters.Add("@Entegrasyon", SqlDbType.Int).Value = Entegrasyon;
            cmd.Parameters.Add("@EntegrasyonID", SqlDbType.Int).Value = EntegrasyonID;
        }

        public csStokHr(SqlConnection Baglanti, SqlTransaction Tr, IslemTipi Entegrasyon, int EntegrasyonID, DataTable Dt)
        {
            using (SqlDataAdapter da = new SqlDataAdapter("select * from stokhr where Entegrasyon = @Entegrasyon and EntegrasyonID = @EntegrasyonID", Baglanti))
            {
                da.SelectCommand.Transaction = Tr;
                da.SelectCommand.Parameters.Add("@Entegrasyon", SqlDbType.Int).Value = (int)Entegrasyon;
                da.SelectCommand.Parameters.Add("@EntegrasyonID", SqlDbType.Int).Value = EntegrasyonID;

                da.InsertCommand = new SqlCommand(@"insert into StokHr 
        (StokID, Tarih, Miktar, Entegrasyon, EvrakNo, Aciklama, CariID, KaydedenID, KayitTarihi, DegistirenID, DegistirmeTarihi)
        values(@StokID, @Tarih, @Miktar, @Entegrasyon, @EvrakNo, @Aciklama, @CariID)
        set @YeniID = SCOPE_IDENTITY()");

                da.Fill(Dt);
                da.Update(Dt);
            }
        }

        public void UretimdetayiniStokHareketlerineEkle(SqlConnection Baglanti, SqlTransaction Tr, int BasitUretimID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @"update StokHr set StokHrID = @StokHrID, StokID = @StokID, Tarih = @Tarih, Miktar = @Miktar, 
Entegrasyon = @Entegrasyon, EvrakNo = @EvrakNo, Aciklama = @Aciklama, CariID = @CariID where StokHrID = @StokHrID ";


                //IslemTipi.ente
            }
        }


        // bu stok Harekete bişiler eklemek için
        public void StokHrUpdate(SqlConnection Bagianti, SqlTransaction Tr, DataTable dt, int Entegrasyon)
        {
            using (SqlDataAdapter daa = new SqlDataAdapter())
            {
                daa.UpdateCommand = new SqlCommand(@"update StokHr set StokHrID = @StokHrID, StokID = @StokID, Tarih = @Tarih, Miktar = @Miktar
, CariID = @CariID,  GirisMiCikisMi = @GirisMiCikisMi, Fiyat= @Fiyat where Entegrasyon = @Entegrasyon, EntegrasyonID = @EntegrasyonID ");

                daa.UpdateCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "MalzemeStokID");
                daa.UpdateCommand.Parameters.Add("@Tarih", SqlDbType.Int, 0, "UretimTarihi");
                daa.UpdateCommand.Parameters.Add("@Miktar", SqlDbType.Int, 0, "GerekliMiktar");
                daa.UpdateCommand.Parameters.Add("@CariID", SqlDbType.Int, 0, "CariID");
                //daa.UpdateCommand.Parameters.Add("@EvrakNo", SqlDbType.Int, 0, "MalzemeStokID");
                //daa.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.Int, 0, "MalzemeStokID");
                daa.UpdateCommand.Parameters.Add("@GirisMiCikisMi", SqlDbType.Int).Value = 2;
                daa.UpdateCommand.Parameters.Add("@Fiyat", SqlDbType.Int, 0, "Maliyet");

                daa.UpdateCommand.Parameters.Add("@Entegrasyon", SqlDbType.Int).Value = Entegrasyon;
                daa.UpdateCommand.Parameters.Add("@EntegrasyonID", SqlDbType.Int, 0, "BasitUreDetID");


                daa.InsertCommand = new SqlCommand(@"
insert into StokHr (StokHrID, StokID, Tarih, Miktar, CariID, GirisMiCikisMi, Fiyat ,Entegrasyon , EntegrasyonID )
values
(@StokID, @Tarih, @Miktar, @CariID, @GirisMiCikisMi, @Fiyat, @Entegrasyon, @EntegrasyonID )
set @YeniID = SCOPE_IDENTITY() ");

                daa.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
                daa.InsertCommand.Parameters.Add("@StokID", SqlDbType.Int, 0, "MalzemeStokID");


            }
        }


        public void AhandaKolaycaBasitUretimdetaydanStokHrEEkledik(SqlConnection Baglanti, SqlTransaction Tr, int BasitUretimID)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = @" 
if (select top 1 1 from StokHr where Entegrasyon = 27 and EntegrasyonID = @BasitUretimID) = 1
begin
UPDATE StokHr
SET StokHr.StokID = UretilenStokID,
StokHr.Tarih = BasitUretim.UretimTarihi, 
StokHr.Miktar = UretimMiktari,
StokHr.Entegrasyon = 27,
StokHr.EntegrasyonID = BasitUretimID,
StokHr.CariID = BasitUretim.CariID,
GirisMiCikisMi = 2,
SilindiMi = 0,
Fiyat = UretimMaliyeti
FROM BasitUretim
WHERE StokHr.Entegrasyon = 27
and StokHr.EntegrasyonID = BasitUretimID
end else
begin

 insert into StokHr 
(StokID, Tarih, Miktar, Entegrasyon, EntegrasyonID, EvrakNo, Aciklama, CariID, GirisMiCikisMi, SilindiMi, Fiyat)
select  UretilenStokID, UretimTarihi,UretimMiktari ,27, BasitUretim.BasitUretimID, '', 'Üretildi', CariID, 1, 0, BasitUretim.UretimMaliyeti from BasitUretim
where
BasitUretimID = @BasitUretimID
end





UPDATE StokHr
SET StokHr.StokID = BasitUretimDetay.MalzemeStokID,
StokHr.Tarih = BasitUretim.UretimTarihi, 
StokHr.Miktar = BasitUretimDetay.GerekliMiktar,
StokHr.Entegrasyon = 28,
StokHr.EntegrasyonID = BasitUretimDetay.BasitUreDetID,
StokHr.CariID = BasitUretim.CariID,
GirisMiCikisMi = 2,
SilindiMi = 0,
Fiyat = Maliyet
FROM StokHr, BasitUretimDetay
inner join BasitUretim on BasitUretim.BasitUretimID = BasitUretimDetay.BasitUretimID and BasitUretimDetay.BasitUretimID = @BasitUretimID
WHERE StokHr.Entegrasyon = 28 -- Bu entegrasyon ISlem Numarası
and StokHr.EntegrasyonID = BasitUretimDetay.BasitUreDetID
and BasitUretimDetay.BasitUretimID = @BasitUretimID 

                insert into StokHr
(StokID, Tarih, Miktar, Entegrasyon, EntegrasyonID, EvrakNo, Aciklama, CariID, GirisMiCikisMi, SilindiMi, Fiyat)
select MalzemeStokID, BasitUretim.UretimTarihi,GerekliMiktar ,28, BasitUreDetID, '', 'Üretimde Hammadde Olarak Kullanıldı', BasitUretim.CariID, 2, 0, Maliyet from BasitUretimDetay
inner join BasitUretim on BasitUretim.BasitUretimID = BasitUretimDetay.BasitUretimID
where
BasitUretimDetay.BasitUretimID = @BasitUretimID
and
BasitUreDetID not in
--NOT EXISTS
 (
                 SELECT EntegrasyonID
                 FROM StokHr
                 WHERE Entegrasyon = 28 and EntegrasyonID = BasitUreDetID
)";
                cmd.Transaction = Tr;
                cmd.Connection = Baglanti;
                cmd.Parameters.Add("@BasitUretimID", SqlDbType.Int).Value = BasitUretimID;
                cmd.ExecuteNonQuery();
            }
        }




        // burası düzeltilecek
        public decimal StokIDver_MiktarAl(SqlConnection Baglanti, SqlTransaction Tr, int StokID)
        {
            using (cmd = new SqlCommand(@"declare @ArtiMiktar decimal(18,0), @EksiMiktar decimal(18,0)

set @ArtiMiktar = (select sum (StokHr.Miktar) from StokHr where StokHr.Entegrasyon = 1 and StokHr.StokID = @StokID)
set @EksiMiktar = (select sum (StokHr.Miktar) from StokHr where StokHr.Entegrasyon = 3 and StokHr.StokID = @StokID)

select isnull(@ArtiMiktar, 0) - isnull(@EksiMiktar ,0) as Miktar", Baglanti, Tr))
            {

                cmd.Parameters.Add("StokID", SqlDbType.Int).Value = StokID;
                return Convert.ToDecimal(cmd.ExecuteScalar());
            }
        }


    }
}
