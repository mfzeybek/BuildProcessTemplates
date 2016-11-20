using System;
using System.Data.SqlClient;
using System.Data;

namespace clsTablolar.cari
{
  public class csCariBasit : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    private int _CariID;
    private string _CariKod;
    private string _CariTanim;


    public int CariID
    {
      get { return _CariID; }
      set { _CariID = value; }
    }
    public string CariKod
    {
      get { return _CariKod; }
      set { _CariKod = value; }
    }
    public string CariTanim
    {
      get { return _CariTanim; }
      set { _CariTanim = value; }
    }

    public csCariBasit(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
    {
      if (CariID == -1)
      {
        _CariID = -1;
        _CariKod = "";
        _CariTanim = "";
      }
      else
      {
        CariGetir(Baglanti, Tr, CariID);
      }

    }

    SqlCommand cmd;
    SqlDataReader dr;

    public void CariGetir(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
    {
      using (cmd = new SqlCommand("select Cari.CariID, CariKod, CariTanim from Cari where CariID = @CariID", Baglanti, Tr))
      {
        cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;

        using (dr = cmd.ExecuteReader())
        {
          if (dr.Read())
          {
            _CariID = Convert.ToInt32(dr["CariID"]);
            _CariKod = dr["CariKod"].ToString();
            _CariTanim = dr["CariTanim"].ToString();
          }
        }
      }
    }



  }
}
