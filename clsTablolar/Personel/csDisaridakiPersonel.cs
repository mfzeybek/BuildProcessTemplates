using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel
{
    public class csDisaridakiPersonel : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        public DataTable dt;


        public void getir(SqlConnection Baglanti)
        {
            da = new SqlDataAdapter(@"select * 
, 
case
when 
(select top 1 Hareketler.Tur from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) = 3
then 'ÇIKIŞ'
when
(select top 1 Hareketler.Tur from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) = 2
then 'GİRİŞ'
when
(select top 1 Hareketler.Tur from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) = 1
then
'MESAİ BAŞLANGICI'
end as Turu
,
(select top 1 Hareketler.Zaman from hareketler where Hareketler.PersonelID = Personel.PersonelID  order by hareketler.Zaman desc)

as Zamani
,
(select top 1 Yerler.YerAdi  from hareketler 
inner join Yerler on Yerler.YerID = Hareketler.YerID
where Hareketler.PersonelID = Personel.PersonelID and
 zaman between DATEADD(day, 0,CONVERT(nvarchar(50),GETDATE(),106)) and DATEADD(day, 1,CONVERT(nvarchar(50),GETDATE(),106))
 order by hareketler.Zaman desc
) as Yer
from personel
where PersonelAktif = 1
and (select top 1 Hareketler.Zaman from hareketler where Hareketler.PersonelID = Personel.PersonelID order by hareketler.Zaman desc) > DATEADD(day, 0,CONVERT(nvarchar(50),GETDATE(),106))
order by Zamani desc", Baglanti);

            dt = new DataTable();
            da.Fill(dt);

            //gridControl1.DataSource = dt;
        }

    }
}
