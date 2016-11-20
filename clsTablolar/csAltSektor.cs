using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar
{
  public class csAltSektor : IDisposable
  {
    private int _CariAltSektorID;
    private string _CariAltSektor;
    private int _CariSektorID;

    public int CariAltSektorID
    {
      get { return _CariAltSektorID; }
      set { _CariAltSektorID = value; }
    }
    public string CariAltSektor
    {
      get { return _CariAltSektor; }
      set { _CariAltSektor = value; }
    }
    public int CariSektorID
    {
      get { return _CariSektorID; }
      set { _CariSektorID = value; }
    }

    #region Genel DeğişkEnler
    SqlCommand cmdGenel;
    SqlDataReader drGenel;
    #endregion

    public csAltSektor(SqlConnection Baglanti, SqlTransaction Tr, int CariAltSektorID) // sektörü çağırdığımızda ilk çalışacak kod muydu neydi amk.
    {
      if (CariAltSektorID == -1)
      {
        _CariAltSektorID = CariAltSektorID;
        _CariAltSektor = "";
        _CariSektorID = -1;
      }
      else
        CariAltSektorGetir(Baglanti, Tr, CariAltSektorID);
    }
    private void CariAltSektorGetir(SqlConnection Baglanti, SqlTransaction Tr, int CariAltSektorID)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.Transaction = Tr;
      cmdGenel.CommandText = @"select CariAltSektorID,CariAltSektor,CariSektorID 
from CariAltSektor where CariAltSektorID = @CariAltSektorID";
      cmdGenel.Parameters.Add("@CariAltSektorID", SqlDbType.Int).Value = CariAltSektorID;
      drGenel = cmdGenel.ExecuteReader();
      drGenel.Read();
      _CariAltSektorID = Convert.ToInt32(drGenel["CariAltSektorID"].ToString());
      _CariAltSektor = drGenel["CariAltSektor"].ToString();

      drGenel.Close();
      drGenel.Dispose();
    }
    public string CariAltSektorInsert(SqlConnection Baglanti, SqlTransaction Tr)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.Transaction = Tr;
      cmdGenel.CommandText = @"insert into CariAltSektor (CariAltSektor, CariSektorID) values (@CariAltSektor, @CariSektorID) set @YeniID = SCOPE_IDENTITY()";
      cmdGenel.Parameters.Add("CariAltSektor", SqlDbType.NVarChar).Value = _CariAltSektor;
      cmdGenel.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      cmdGenel.Parameters.Add("@CariSektorID", SqlDbType.Int).Value = _CariSektorID;
      try
      {
        cmdGenel.ExecuteNonQuery();
        _CariAltSektorID = Convert.ToInt32(cmdGenel.Parameters["@YeniID"].Value.ToString());
      }
      catch (Exception e)
      {
        if (e is SqlException && ((SqlException)e).Number == 2601)
          return ((SqlException)e).Number.ToString();
        else
          return e.Message;
      }
      finally
      {
        cmdGenel.Dispose();
      }
      return "OK" + _CariAltSektorID.ToString();
    }
    public string CariAltSEktorUpdate(SqlConnection Baglanti, SqlTransaction Tr)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.Transaction = Tr;
      cmdGenel.CommandText = @"Update CariAltSektor Set CariAltSektor = @CariAltSektor where CariAltSektorID = @CariAltSektorID";
      cmdGenel.Parameters.Add("@CariAltSektor", SqlDbType.NVarChar).Value = _CariAltSektor;
      cmdGenel.Parameters.Add("@CariAltSektorID", SqlDbType.Int).Value = _CariAltSektorID;

      try
      {
        cmdGenel.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        if (e is SqlException && ((SqlException)e).Number == 2601)
          return ((SqlException)e).Number.ToString();
        else
          return e.Message;
      }
      finally
      {
        cmdGenel.Dispose();
      }
      return "OK ," + _CariAltSektorID.ToString();
    }
    public string CariAltSektorSil(SqlConnection Baglanti, SqlTransaction Tr, string CariAltSektorID)
    {
      cmdGenel = new SqlCommand();
      cmdGenel.Connection = Baglanti;
      cmdGenel.Transaction = Tr;
      cmdGenel.CommandText = @"Delete CariAltSektor where CariAltSektorID = @CariAltSektorID";
      cmdGenel.Parameters.Add("@CariAltSektorID", SqlDbType.Int).Value = CariAltSektorID;
      try
      {
        cmdGenel.ExecuteNonQuery();
      }
      catch (Exception e)
      {
        if (e is SqlException && ((SqlException)e).Number == 2661) // Kayıt başka bir tabloya bağlıysa (kullanılıyorsa)
          return "Bu kayıt başka tabloda kullanılıyor nerde kullanılıyorsa önce sil";
      }
      finally
      {
        cmdGenel.Dispose();
      }
      return "Silindi";
    }
    public static DataTable CariAltsektorDoldur(SqlConnection Baglanti)
    {
      SqlDataAdapter da = new SqlDataAdapter("Select CariAltSektorID, CariAltSektor, CariSektorID From CariSektor", Baglanti);
      DataTable Dt = new DataTable();
      da.Fill(Dt);
      return Dt;
    }
    public static DataTable CariAltsektorDoldur(SqlConnection Baglanti, string CariSektorID) 
    {
      SqlDataAdapter da = new SqlDataAdapter(@"Select CariAltSektorID, CariAltSektor 
From CariAltSektor where CariSektorID = @CariSektorID", Baglanti);
      if (CariSektorID == null || CariSektorID == "")
        CariSektorID = "-1";
      da.SelectCommand.Parameters.Add("@CariSektorID", SqlDbType.Int).Value = CariSektorID;
      DataTable Dt = new DataTable();
      da.Fill(Dt);
      return Dt;
    }
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }
  }
}
