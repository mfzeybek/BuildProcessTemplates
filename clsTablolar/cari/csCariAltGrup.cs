using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csCariAltGrup : IDisposable
  {
    #region Alanlar
    private int _CariAltGrupID;
    private int _CariGrupID;
    private string _CariAltGrup;
    private int _KaydedenID;
    private DateTime _KayitTarihi;
    private int _GuncelleyenID;
    private DateTime _GuncellemeTarihi;
    #endregion

    #region Property ler
    public int CariAltGrupID
    {
      get { return _CariAltGrupID; }
      set { _CariAltGrupID = value; }
    }
    public int CariGrupID
    {
      get { return _CariGrupID; }
      set { _CariGrupID = value; }
    }
    public string CariAltGrup_
    {
      get { return _CariAltGrup; }
      set { _CariAltGrup = value; }
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
    public int GuncelleyenID
    {
      get { return _GuncelleyenID; }
      set { _GuncelleyenID = value; }
    }
    public DateTime GuncellemeTarihi
    {
      get { return _GuncellemeTarihi; }
      set { _GuncellemeTarihi = value; }
    }
    #endregion

    #region Genel Değişkenler
    SqlCommand cmdGenel;
    SqlDataReader drGenel;
    #endregion

    public csCariAltGrup(SqlConnection baglanti, SqlTransaction trGenel, int CariAltGrupID)
    {
      if (CariAltGrupID == -1)
      {
        _CariAltGrupID = -1;
        _CariGrupID = -1;
        _CariAltGrup = "";
        _KaydedenID = -1;
        _KayitTarihi = Convert.ToDateTime("01.01.1888");
        _GuncelleyenID = -1;
        _GuncellemeTarihi = Convert.ToDateTime("01.01.1888");
      }
      else
      {
        CariAltGrupGetir(baglanti, trGenel, CariAltGrupID);
      }
    }
    private void CariAltGrupGetir(SqlConnection baglanti, SqlTransaction trGenel, int CariAltGrupID)
    {
      try
      {
        using (cmdGenel = new SqlCommand(
  @" SELECT  CariAltGrup, CariGrupID, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi
FROM  dbo.CariAltGrup WHERE     (dbo.CariAltGrup.CariAltGrupID = @CariAltGrupID) ", baglanti))
        {
          cmdGenel.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = CariAltGrupID;
          cmdGenel.Transaction = trGenel;
          using (drGenel = cmdGenel.ExecuteReader())
          {
            if (drGenel.Read())
            {
              _CariAltGrup = drGenel["CariID"].ToString();
              _CariGrupID = Convert.ToInt32(drGenel["CariGrupID"].ToString());
              _KaydedenID = Convert.ToInt32(drGenel["KaydedenID"].ToString());
              _KayitTarihi = Convert.ToDateTime(drGenel["KayitTarihi"].ToString());
              _GuncelleyenID = Convert.ToInt32(drGenel["GuncelleyenID"].ToString());
              _GuncellemeTarihi = Convert.ToDateTime(drGenel["GuncellemeTarihi"].ToString());
            }
          }
        }
      }
      catch (Exception hata)
      {
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    public static DataTable CariAltGrupListesi(SqlConnection baglanti)
    {
      SqlDataAdapter da = new SqlDataAdapter(@"SELECT CariAltGrupID, CariGrupID, CariAltGrup, KaydedenID, KayitTarihi, GuncelleyenID, GuncellemeTarihi From CariAltGrup", baglanti);

      DataTable dt = new DataTable();
      da.Fill(dt);
      return dt;
    }
    public static DataTable CariAltGrupDoldur(SqlConnection Baglanti, string CariGrupID)
    {
      SqlDataAdapter da = new SqlDataAdapter(@"Select CariAltGrupID, CariAltGrup 
From CariAltGrup where CariGrupID = @CariGrupID", Baglanti);
      if (CariGrupID == null || CariGrupID == "")
        CariGrupID = "-1";
      da.SelectCommand.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = CariGrupID;
      DataTable Dt = new DataTable();
      da.Fill(Dt);
      return Dt;
    }
    public string AdresInsert(SqlConnection baglanti, SqlTransaction trGenel)
    {
      try
      {
        cmdGenel = new SqlCommand(@"Insert Into CariAltGrup(CariGrupID, CariAltGrup, KaydedenID, KayitTarihi)
Values (@CariGrupID, @CariAltGrup, @KaydedenID, @KayitTarihi) SET @SonID=SCOPE_IDENTITY()
", baglanti);
        cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
        cmdGenel.Parameters.Add("@CariAltGrup", SqlDbType.NVarChar).Value = _CariAltGrup;
        cmdGenel.Parameters.Add("@KaydedenID", SqlDbType.Int).Value = _KaydedenID;
        cmdGenel.Parameters.Add("@KayitTarihi", SqlDbType.DateTime).Value = _KayitTarihi;

        cmdGenel.Parameters.Add("@SonID", SqlDbType.Int).Direction = ParameterDirection.Output;

        cmdGenel.Transaction = trGenel;
        cmdGenel.ExecuteNonQuery();

        return cmdGenel.Parameters["@SonID"].Value.ToString();
      }
      catch (Exception hata)
      {
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    public void AdresUpdate(SqlConnection baglanti, SqlTransaction tr)
    {
      try
      {
        cmdGenel = new SqlCommand(@"Update CariAltGrup SET 
CariGrupID=@CariGrupID, CariAltGrup=@CariAltGrup, GuncelleyenID=@GuncelleyenID, GuncellemeTarihi=@GuncellemeTarihi Where CariAltGrupID=@CariAltGrupID ", baglanti);
        cmdGenel.Parameters.Add("@CariGrupID", SqlDbType.Int).Value = _CariGrupID;
        cmdGenel.Parameters.Add("@CariID", SqlDbType.NVarChar).Value = _CariAltGrup;
        cmdGenel.Parameters.Add("@GuncelleyenID", SqlDbType.Int).Value = _GuncelleyenID;
        cmdGenel.Parameters.Add("@GuncellemeTarihi", SqlDbType.DateTime).Value = _GuncellemeTarihi;

        cmdGenel.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = _CariAltGrupID;
        cmdGenel.Transaction = tr;
        cmdGenel.ExecuteNonQuery();
      }
      catch (Exception hata)
      {
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    public static void AdresDelete(SqlConnection baglanti, SqlTransaction trGenel, int CariAltGrupID)
    {
      try
      {
        SqlCommand cmd = new SqlCommand("Delete From CariAltGrup Where CariAltGrupID=@CariAltGrupID", baglanti, trGenel);
        cmd.Parameters.Add("@CariAltGrupID", SqlDbType.Int).Value = CariAltGrupID;
        cmd.ExecuteNonQuery();
      }
      catch (Exception hata)
      {
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
