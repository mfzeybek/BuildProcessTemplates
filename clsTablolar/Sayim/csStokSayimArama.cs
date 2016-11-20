using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Sayim
{
  public class csStokSayimArama : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    private DateTime? _SayimTarihiAraligi1;
    public DateTime? SayimTarihiAraligi1
    {
      get { return _SayimTarihiAraligi1; }
      set { _SayimTarihiAraligi1 = value; }
    }

    private DateTime? _SayimTarihiAraligi2;
    public DateTime? SayimTarihiAraligi2
    {
      get { return _SayimTarihiAraligi2; }
      set { _SayimTarihiAraligi2 = value; }
    }

    private string _SayimKodu;
    public string SayimKodu
    {
      get { return _SayimKodu; }
      set { _SayimKodu = value; }
    }

    private string _Aciklama;
    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }

    private int _SayimDepoID;
    public int SayimDepoID
    {
      get { return _SayimDepoID; }
      set { _SayimDepoID = value; }
    }






    public DataTable Dt_Sayimlar;
    SqlDataAdapter da;


    public csStokSayimArama()
    {
      _SayimTarihiAraligi1 = null;
      _SayimTarihiAraligi2 = null;

      _SayimKodu = "";
      _Aciklama = "";

      _SayimDepoID = -1;
    }

    
    

    public void SayimlariGetir(SqlConnection Baglanti, SqlTransaction TrGenel)
    {
      using (da = new SqlDataAdapter(@"
      select SayimID, SayimKodu, SayimTarihi, DepoID, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi, Aciklama from Sayim
      where 1 = 1 ", Baglanti))
      {
        da.SelectCommand.Transaction = TrGenel;

        if (SayimTarihiAraligi1 != null && SayimTarihiAraligi2 != null)
        {
          da.SelectCommand.CommandText += " and SayimTarihi between @SayimTarihiAraligi1 and @SayimTarihiAraligi2 ";
          da.SelectCommand.Parameters.Add("@SayimTarihiAraligi1", SqlDbType.DateTime).Value = SayimTarihiAraligi1;
          da.SelectCommand.Parameters.Add("@SayimTarihiAraligi2", SqlDbType.DateTime).Value = SayimTarihiAraligi2;
        }
        if (SayimKodu != "")
        {
          da.SelectCommand.CommandText += " and SayimKodu like @SayimKodu ";
          da.SelectCommand.Parameters.Add("@SayimKodu", SqlDbType.NVarChar).Value = SayimKodu;
        }
        if (Aciklama != "")
        {
          da.SelectCommand.CommandText += " and Aciklama like @Aciklama ";
          da.SelectCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = Aciklama;
        }

        if (SayimDepoID != -1)
        {
          da.SelectCommand.CommandText += " and DepoID = @DepoID ";
          da.SelectCommand.Parameters.Add("@DepoID", SqlDbType.Int).Value = SayimDepoID;
        }

        Dt_Sayimlar = new DataTable();
        da.Fill(Dt_Sayimlar);
      }
    }

  }
}
