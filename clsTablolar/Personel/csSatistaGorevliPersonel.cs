using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel
{
  public class csSatistaGorevliPersonel:IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public DataTable SatistaGorevliPersonelListesi(SqlConnection Baglanti)
    {
      using (SqlDataAdapter da = new SqlDataAdapter(@"SELECT dbo.Cari.CariTanim, dbo.PersonelGorevTanim.SatistaGorevliMi, dbo.Personel.PersonelID
FROM  dbo.PersonelGorevTanim INNER JOIN
               dbo.PersonelGorevIliski ON dbo.PersonelGorevTanim.PersonelGorevID = dbo.PersonelGorevIliski.PersonelGorevID INNER JOIN
               dbo.Cari INNER JOIN
               dbo.Personel ON dbo.Cari.CariID = dbo.Personel.CariID ON dbo.PersonelGorevIliski.PersonelID = dbo.Personel.PersonelID
WHERE (dbo.PersonelGorevTanim.SatistaGorevliMi = 1)", Baglanti))
      {
        using (DataTable dt = new DataTable())
        {
          da.Fill(dt);
          return dt;
        }
      }
    }
    
  }
}
