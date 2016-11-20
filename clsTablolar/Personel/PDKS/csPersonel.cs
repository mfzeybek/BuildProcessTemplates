using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Personel.PDKS
{
  public class csPersonel : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }


    private int _PersonelID;
    private int _CariID;
    private decimal _Maasi;
    private string _PDKSsifre;
    private string _PersonelAdi;


    public int PersonelID
    {
      get { return _PersonelID; }
      set { _PersonelID = value; }
    }
    public int CariID
    {
      get { return _CariID; }
      set { _CariID = value; }
    }
    public decimal Maasi
    {
      get { return _Maasi; }
      set { _Maasi = value; }
    }
    public string PDKSsifre
    {
      get { return _PDKSsifre; }
      set { _PDKSsifre = value; }
    }
    public string PersonelAdi
    {
      get { return _PersonelAdi; }
      set { _PersonelAdi = value; }
    }


    SqlCommand cmd;
    SqlDataReader dr;



    public csPersonel(SqlConnection Baglanti, SqlTransaction Tr, int PersonelID)
    {
      using (cmd = new SqlCommand("select * from Personel where PersonelID = @PersonelID", Baglanti, Tr))
      {
        cmd.Parameters.Add("@PersonelID", SqlDbType.Int).Value = PersonelID;

        using (dr = cmd.ExecuteReader())
        {
          if (dr.Read())
          {
            _PersonelID = Convert.ToInt32(dr["PersonelID"]);
            //_CariID = Convert.ToInt32(dr["CariID"]);
            _PDKSsifre = dr["PersonelSifre"].ToString();
            _PersonelAdi = dr["PersonelAdi"].ToString();
          }
        }
      }
    }



  }
}
