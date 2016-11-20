using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.HemenAl
{
  public class csHemenAlUrunDurum:IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }
    public DataTable Dt_UrunDurumlari;

    public csHemenAlUrunDurum()
    {
      Dt_UrunDurumlari = new DataTable();
      Dt_UrunDurumlari.Columns.Add("DurumKodu");
      Dt_UrunDurumlari.Columns.Add("DurumAdi");
      Dt_UrunDurumlari.Rows.Add(Dt_UrunDurumlari.NewRow());
      Dt_UrunDurumlari.Rows.Add(Dt_UrunDurumlari.NewRow());
      Dt_UrunDurumlari.Rows.Add(Dt_UrunDurumlari.NewRow());
      Dt_UrunDurumlari.Rows.Add(Dt_UrunDurumlari.NewRow());
      Dt_UrunDurumlari.Rows.Add(Dt_UrunDurumlari.NewRow());
      Dt_UrunDurumlari.Rows.Add(Dt_UrunDurumlari.NewRow());

      Dt_UrunDurumlari.Rows[0]["DurumKodu"] = "";
      Dt_UrunDurumlari.Rows[0]["DurumAdi"] = "Varsa Ekle Yoksa Güncelle";

      Dt_UrunDurumlari.Rows[1]["DurumKodu"] = "P";
      Dt_UrunDurumlari.Rows[1]["DurumAdi"] = "Pasif Yap";

      Dt_UrunDurumlari.Rows[2]["DurumKodu"] = "A";
      Dt_UrunDurumlari.Rows[2]["DurumAdi"] = "Aktif Yap";

      Dt_UrunDurumlari.Rows[3]["DurumKodu"] = "D";
      Dt_UrunDurumlari.Rows[3]["DurumAdi"] = "Sil";

      Dt_UrunDurumlari.Rows[4]["DurumKodu"] = "S";
      Dt_UrunDurumlari.Rows[4]["DurumAdi"] = "Stok Güncelle";

      Dt_UrunDurumlari.Rows[5]["DurumKodu"] = "F";
      Dt_UrunDurumlari.Rows[5]["DurumAdi"] = "Fiyat Güncelle";
    }
  }
}
