using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
  public class csPDKSTur : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    public DataTable dt;

    public csPDKSTur()
    {
      dt = new DataTable();
      dt.Columns.Add("TurID");
      dt.Columns.Add("TurAdi");


      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["TurID"] = 1;
      dt.Rows[0]["TurAdi"] = "Mesai Başlangıcı";

      dt.Rows[1]["TurID"] = 2;
      dt.Rows[1]["TurAdi"] = "Çıkış - Daha Gelmedi";

      dt.Rows[2]["TurID"] = 3;
      dt.Rows[2]["TurAdi"] = "Çıkış - Giriş";
    }
  }
}
