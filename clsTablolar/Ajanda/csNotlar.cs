using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Ajanda
{
  public class csNotlar : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    private int _NotID;
    private string _Baslik;
    private DateTime _NotTarihi;
    private int _GrupID;
    private int _AltGrupID;
    private string _Aciklama;
    private int _KaydedenID;
    private DateTime _KayitTarihi;
    private int _DegisirenID;
    private DateTime _DegistirmeTarihi;



    public int NotID
    {
      get { return _NotID; }
      set { _NotID = value; }
    }
    public string Baslik
    {
      get { return _Baslik; }
      set { _Baslik = value; }
    }
    public DateTime NotTarihi
    {
      get { return _NotTarihi; }
      set { _NotTarihi = value; }
    }
    public int GrupID
    {
      get { return _GrupID; }
      set { _GrupID = value; }
    }
    public int AltGrupID
    {
      get { return _AltGrupID; }
      set { _AltGrupID = value; }
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
    public int DegisirenID
    {
      get { return _DegisirenID; }
      set { _DegisirenID = value; }
    }
    public DateTime DegistirmeTarihi
    {
      get { return _DegistirmeTarihi; }
      set { _DegistirmeTarihi = value; }
    }



    public csNotlar(SqlConnection Baglanti, SqlTransaction Tr, int NotID)
    {
      if (NotID == -1)
      {
        _NotID = -1;
        _Baslik = "";
        _NotTarihi = DateTime.Now;
        _GrupID = -1;
        _AltGrupID = -1;
        _Aciklama = "";
        _KaydedenID = -1;
        _KayitTarihi = DateTime.Now;
        _DegisirenID = -1;
        _DegistirmeTarihi = DateTime.Now;
      }
      else
      {
        GetirHamisina(Baglanti, Tr, NotID);
      }
    }

    SqlCommand cmd;
    SqlDataReader dr;

    private void GetirHamisina(SqlConnection Baglanti, SqlTransaction Tr, int NotID)
    {
      try
      {
        using (cmd = new SqlCommand("select * from Notlar where NotID = @NotID ", Baglanti, Tr))
        {
          cmd.Parameters.Add("@NotID", SqlDbType.Int).Value = NotID;
          using (dr = cmd.ExecuteReader())
          {
            if (dr.Read())
            {
              _NotID = Convert.ToInt32(dr["NotID"]);
              _Baslik = dr["Baslik"].ToString();
              _NotTarihi = Convert.ToDateTime(dr["NotTarihi"]);
              _GrupID = Convert.ToInt32(dr["GrupID"]);
              //_AltGrupID = Convert.ToInt32(dr[""]);
              _Aciklama = dr["Aciklama"].ToString();
              //_KaydedenID = conve (dr[""]);
              //_KayitTarihi = dr[""];
              //_DegisirenID = dr[""];
              //_DegistirmeTarihi = dr[""];
            }
          }
        }
      }
      catch (Exception)
      {
        throw;
      }
    }


    public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr, int NotID)
    {
      if (NotID == -1)
      {
        cmd = new SqlCommand(@"insert into Notlar 
          ( Baslik, NotTarihi, GrupID, AltGrupID, Aciklama) 
          values 
          ( @Baslik, @NotTarihi, @GrupID, @AltGrupID, @Aciklama) set @YeniID = SCOPE_IDENTITY() ", Baglanti, Tr);
        cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      }
      else
      {
        cmd = new SqlCommand(@"update Notlar set Baslik = @Baslik, NotTarihi = @NotTarihi, GrupID = @GrupID, 
        AltGrupID = @AltGrupID, Aciklama = @Aciklama where NotID = @NotID ", Baglanti, Tr);

        cmd.Parameters.Add("@NotID", SqlDbType.Int).Value = NotID;
      }

      cmd.Parameters.Add("@Baslik", SqlDbType.NVarChar).Value = _Baslik;
      cmd.Parameters.Add("@NotTarihi", SqlDbType.DateTime).Value = _NotTarihi;
      cmd.Parameters.Add("@GrupID", SqlDbType.Int).Value = _GrupID;
      cmd.Parameters.Add("@AltGrupID", SqlDbType.Int).Value = _AltGrupID;
      cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
      //cmd.Parameters.Add("@KaydedenID", SqlDbType, 0, "");
      //cmd.Parameters.Add("@Baslik", SqlDbType, 0, "");
      //cmd.Parameters.Add("@Baslik", SqlDbType, 0, "");
      //cmd.Parameters.Add("@Baslik", SqlDbType, 0, "");

      cmd.ExecuteNonQuery();

      if (NotID == -1)
      {
        _NotID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
      }
    }







  }
}
