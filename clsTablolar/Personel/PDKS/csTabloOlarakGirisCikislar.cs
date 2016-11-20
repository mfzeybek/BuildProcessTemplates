using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
    public class csTabloOlarakGirisCikislar : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public DateTime IlkZaman { get; set; }
        public DateTime IkinciZaman { get; set; }

        SqlDataAdapter da;
        public DataTable dt;

        public csTabloOlarakGirisCikislar()
        {
            IlkZaman = DateTime.MinValue;
            IkinciZaman = DateTime.MinValue;

        }


        public DataTable getir(SqlConnection Baglanti)
        {
            using (da = new SqlDataAdapter(@"
select GirisHareketleri.ID GirisID ,Personel.PersonelAdi
,
case 
when Yerler.YerAdi is null
then 'Mesai Başlangıcı'
else
Yerler.YerAdi
end as YerAdi,
case
when GirisHareketleri.Tur = 1 
then null
when GirisHareketleri.Tur = 2
then 
(select top 1 Zaman from Hareketler as CikisHareketi where zaman < GirisHareketleri.Zaman and CikisHareketi.PersonelID = Personel.PersonelID and CikisHareketi.Tur = 3 order by Zaman desc)
end as CikisZamani
, GirisHareketleri.Zaman as GirisZamani
,
case
when GirisHareketleri.Tur = 1 
then 0
when GirisHareketleri.Tur = 2
then 
Isnull(datediff(minute , (select top 1 Zaman from Hareketler as CikisHareketi where zaman < GirisHareketleri.Zaman and CikisHareketi.PersonelID = Personel.PersonelID and CikisHareketi.Tur = 3 order by Zaman desc)
,
GirisHareketleri.Zaman), 0 )
end as FarkDK
,(select top 1 CikisHareketi.ID from Hareketler as CikisHareketi where zaman < GirisHareketleri.Zaman and CikisHareketi.PersonelID = Personel.PersonelID and CikisHareketi.Tur = 3 order by Zaman desc) as CikisID
--, CikisHareketi.Zaman
from Hareketler as GirisHareketleri
inner join Personel on Personel.PersonelID = GirisHareketleri.PersonelID
Left join Yerler on Yerler.YerID = GirisHareketleri.YerID 
--inner join Hareketler as CikisHareketi on CikisHareketi.zaman < GirisHareketleri.Zaman and CikisHareketi.PersonelID = Personel.PersonelID and CikisHareketi.Tur = 3 --order by CikisHareketi.Zaman desc
where 
(GirisHareketleri.Tur = 2 or GirisHareketleri.Tur = 1)

", Baglanti))
            {
                if (IlkZaman != DateTime.MinValue)
                {
                    da.SelectCommand.CommandText += " and GirisHareketleri.zaman >= @IlkZaman ";
                    da.SelectCommand.Parameters.Add("@IlkZaman", SqlDbType.DateTime).Value = IlkZaman;
                }
                if (IkinciZaman != DateTime.MinValue)
                {
                    da.SelectCommand.CommandText += " and GirisHareketleri.zaman <= @IkinciZaman ";
                    da.SelectCommand.Parameters.Add("@IkinciZaman", SqlDbType.DateTime).Value = IkinciZaman;
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
