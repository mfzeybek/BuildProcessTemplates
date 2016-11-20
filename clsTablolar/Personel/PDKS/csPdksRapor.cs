using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
    public class csPdksRapor : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;


        private string _PersonelAdi;
        private DateTime _Zaman1;
        private DateTime _Zaman2;
        private int _AciklamaID;
        private Int32 _TurID;

        private DateTime _IlkZaman;

        private DateTime _IkinciZaman;


        public string PersonelAdi
        {
            get { return _PersonelAdi; }
            set { _PersonelAdi = value; }
        }
        public DateTime Zaman1
        {
            get { return _Zaman1; }
            set { _Zaman1 = value; }
        }
        public DateTime Zaman2
        {
            get { return _Zaman2; }
            set { _Zaman2 = value; }
        }
        public int AciklamaID
        {
            get { return _AciklamaID; }
            set { _AciklamaID = value; }
        }
        public Int32 TurID
        {
            get { return _TurID; }
            set { _TurID = value; }
        }
        public DateTime IlkZaman
        {
            get { return _IlkZaman; }
            set { _IlkZaman = value; }
        }
        public DateTime IkinciZaman
        {
            get { return _IkinciZaman; }
            set { _IkinciZaman = value; }
        }



        public csPdksRapor()
        {
            _PersonelAdi = "";
            _Zaman1 = DateTime.MinValue;
            _Zaman2 = DateTime.MinValue;
            _AciklamaID = -1;
            _TurID = -1;
        }

        public DataTable Listele(SqlConnection Baglanti, SqlTransaction Tr)
        {
            da = new SqlDataAdapter(@"select *,
case 
when tur = 1 then 'Mesai Başlangıcı'
when tur = 2 then 'Giriş'
when tur = 3 then 'Çıkış'
end as TurAdi
from Hareketler
inner join Personel on Personel.PersonelID = Hareketler.PersonelID
left join Yerler on Yerler.YerID = Hareketler.YerID
where 1 = 1 ", Baglanti);

            da.SelectCommand.Transaction = Tr;

            if (_IlkZaman != DateTime.MinValue)
            {
                da.SelectCommand.CommandText += " and Zaman > @IlkZaman ";
                da.SelectCommand.Parameters.Add("@IlkZaman", SqlDbType.DateTime).Value = _IlkZaman;
            }

            // Sadece Vt deki zaman 1 filtreleniyor zaman bir verilen 2 tarih arasında filtre görüyor
            if (_IkinciZaman != DateTime.MinValue)
            {
                da.SelectCommand.CommandText += " and Zaman < @IkinciZaman ";
                da.SelectCommand.Parameters.Add("@IkinciZaman", SqlDbType.DateTime).Value = _IkinciZaman;
            }
            if (_AciklamaID != -1)
            {
                da.SelectCommand.CommandText += " and AciklamaID = @AciklamaID ";
                da.SelectCommand.Parameters.Add("@AciklamaID", SqlDbType.Int).Value = _AciklamaID;
            }
            if (_TurID != -1)
            {
                da.SelectCommand.CommandText += " and TurID = @TurID ";
                da.SelectCommand.Parameters.Add("@TurID", SqlDbType.Int).Value = _TurID;
            }
            if (_PersonelAdi != "")
            {
                da.SelectCommand.CommandText += " and Personel.PersonelAdi like @PersonelAdi+'%' ";
                da.SelectCommand.Parameters.Add("@PersonelAdi", SqlDbType.NVarChar).Value = _PersonelAdi;
            }

            dt = new DataTable();
            da.Fill(dt);
            return dt;

        }



    }
}
