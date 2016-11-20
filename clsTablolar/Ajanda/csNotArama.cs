using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Ajanda
{
  public class csNotArama : IDisposable
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


    public csNotArama()
    {

      _GrupID = -1;
    }
    SqlDataAdapter da;
    DataTable Dt;


    public DataTable Listele(SqlConnection Baglanti, SqlTransaction Tr)
    {
      da = new SqlDataAdapter(@"select NotID, NotTarihi, Baslik,NotGuruplari.GrupAdi, Notlar.Aciklama from Notlar 
                left join NotGuruplari on NotGuruplari.NotGurupID = Notlar.GrupID
                where 1 = 1", Baglanti);
      da.SelectCommand.Transaction = Tr;


      if (_GrupID != -1)
      {
        da.SelectCommand.CommandText += " and GrupID = @GrupID";
        da.SelectCommand.Parameters.Add("@GrupID", SqlDbType.Int).Value = _GrupID;
      }


      Dt = new DataTable();

      da.Fill(Dt);

      return (Dt);
    }

  }
}
