using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.BasitUretim
{
  public class csBasitUretimRecete : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    private int _BUReceteID;
    private string _OzelKod1;
    private string _OzelKod2;
    private string _Aciklama;
    private int _UretilenStokID;
    private decimal _UretimMiktari;
    private decimal _Ekmaliyet;

    public int BUReceteID
    {
      get { return _BUReceteID; }
      set { _BUReceteID = value; }
    }
    public string OzelKod1
    {
      get { return _OzelKod1; }
      set { _OzelKod1 = value; }
    }
    public string OzelKod2
    {
      get { return _OzelKod2; }
      set { _OzelKod2 = value; }
    }
    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }
    public int UretilenStokID
    {
      get { return _UretilenStokID; }
      set { _UretilenStokID = value; }
    }
    public decimal UretimMiktari
    {
      get { return _UretimMiktari; }
      set { _UretimMiktari = value; }
    }
    public decimal Ekmaliyet
    {
      get { return _Ekmaliyet; }
      set { _Ekmaliyet = value; }
    }

    SqlCommand cmd;
    SqlDataReader dr;

    public csBasitUretimRecete(SqlConnection Baglanti, SqlTransaction TrGenel, int BUReceteID)
    {
      if (BUReceteID == -1)
      {
        _BUReceteID = -1;
        _OzelKod1 = "";
        _OzelKod2 = "";
        _Aciklama = "";
        _UretilenStokID = -1;
        _UretimMiktari = 0;
        _Ekmaliyet = 0;
      }
      else
      {
        Getir(Baglanti, TrGenel, BUReceteID);
      }
    }

    public void Getir(SqlConnection Baglanti, SqlTransaction TrGenel, int BUReceteID)
    {
      using (cmd = new SqlCommand("select * from BasitUretimRecetesi where BUReceteID = @BUReceteID", Baglanti, TrGenel))
      {
        cmd.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = BUReceteID;
        using (dr = cmd.ExecuteReader())
        {
          if (dr.Read())
          {
            _BUReceteID = Convert.ToInt32(dr["BUReceteID"]);
            _OzelKod1 = dr["OzelKod1"].ToString();
            _OzelKod2 = dr["OzelKod2"].ToString();
            _Aciklama = dr["Aciklama"].ToString();
            _UretilenStokID = Convert.ToInt32(dr["UretilenStokID"]);
            _UretimMiktari = Convert.ToDecimal(dr["UretimMiktari"]);
            _Ekmaliyet = Convert.ToDecimal(dr["Ekmaliyet"]);
          }
        }
      }
    }

    public void Kaydet(SqlConnection Baglanti, SqlTransaction Tr)
    {
      if (BUReceteID == -1)
      {
        cmd = new SqlCommand(@"insert into BasitUretimRecetesi 
        (OzelKod1, OzelKod2, Aciklama, UretilenStokID, UretimMiktari, Ekmaliyet ) 
        values 
        (@OzelKod1, @OzelKod2, @Aciklama, @UretilenStokID, @UretimMiktari, @Ekmaliyet )  set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);

        cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      }
      else
      {
        cmd = new SqlCommand(@"update BasitUretimRecetesi set OzelKod1 = @OzelKod1, OzelKod2 = @OzelKod2, 
        Aciklama = @Aciklama, UretilenStokID = @UretilenStokID, UretimMiktari = @UretimMiktari, Ekmaliyet = @Ekmaliyet where BUReceteID = @BUReceteID", Baglanti, Tr);

        cmd.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = _BUReceteID;
      }

      cmd.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = _OzelKod1;
      cmd.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = _OzelKod2;
      cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
      cmd.Parameters.Add("@UretilenStokID", SqlDbType.Int).Value = _UretilenStokID;
      cmd.Parameters.Add("@UretimMiktari", SqlDbType.Decimal).Value = _UretimMiktari;
      cmd.Parameters.Add("@Ekmaliyet", SqlDbType.Decimal).Value = _Ekmaliyet;




      cmd.ExecuteNonQuery();
      if (_BUReceteID == -1)
        _BUReceteID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);
    }

    public void Sil(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (cmd = new SqlCommand("delete from BasitUretimRecetesi where BUReceteID = @BUReceteID", Baglanti, Tr))
      {
        cmd.Parameters.Add("@BUReceteID", SqlDbType.Int).Value = _BUReceteID;
        cmd.ExecuteNonQuery();
      }
    }
  }
}
