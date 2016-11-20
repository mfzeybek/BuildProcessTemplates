using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.HemenAl.UrunSecenekleri
{
  public class csHemenAlUrunSecenekOnTanimlari : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }



    private int _HemenAlUrunSecenekOnTanimID;
    private string _Adi;
    private string _Aciklama;


    public int HemenAlUrunSecenekOnTanimID
    {
      get { return _HemenAlUrunSecenekOnTanimID; }
      set { _HemenAlUrunSecenekOnTanimID = value; }
    }
    public string Adi
    {
      get { return _Adi; }
      set { _Adi = value; }
    }
    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }


    SqlCommand com;

    public csHemenAlUrunSecenekOnTanimlari()
    {
    }

    public csHemenAlUrunSecenekOnTanimlari(SqlConnection baglanti, SqlTransaction Tr, int HemenAlUrunSecenekOnTanimID)
    {
      if (HemenAlUrunSecenekOnTanimID == -1)
      {
        _HemenAlUrunSecenekOnTanimID = -1;
        _Adi = "";
        _Aciklama = "";
      }
      else
      {
        Getir(baglanti, Tr, HemenAlUrunSecenekOnTanimID);
      }
    }

    private void Getir(SqlConnection baglanti, SqlTransaction Tr, int HemenAlUrunSecenekOnTanimID)
    {
      using (com = new SqlCommand("select HemenAlUrunSecenekOnTanimID, Adi, Aciklama from HemenAlUrunSecenekOnTanimlari where HemenAlUrunSecenekOnTanimID = @HemenAlUrunSecenekOnTanimID", baglanti, Tr))
      {
        com.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int).Value = HemenAlUrunSecenekOnTanimID;

        using (SqlDataReader dr = com.ExecuteReader())
        {
          if (dr.Read())
          {
            _HemenAlUrunSecenekOnTanimID = Convert.ToInt32(dr["HemenAlUrunSecenekOnTanimID"]);
            _Adi = dr["Adi"].ToString();
            _Aciklama = dr["Aciklama"].ToString();
          }
        }
      }
    }

    public DataTable Tanimlar(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (SqlDataAdapter da = new SqlDataAdapter("select HemenAlUrunSecenekOnTanimID, Adi, Aciklama from HemenAlUrunSecenekOnTanimlari", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        using (DataTable dt_Tanimlar = new DataTable())
        {
          da.Fill(dt_Tanimlar);
          return dt_Tanimlar;
        }
      }
    }

    public void Guncelle(SqlConnection Baglanti, SqlTransaction Tr)
    {

      if (_HemenAlUrunSecenekOnTanimID == -1)
      {
        com = new SqlCommand(@"insert into HemenAlUrunSecenekOnTanimlari
(  Adi, Aciklama ) 
      values
( @Adi, @Aciklama ) set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);

        com.Parameters.Add("@Adi", SqlDbType.NVarChar).Value = _Adi;
        com.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
        com.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

        com.ExecuteNonQuery();

        _HemenAlUrunSecenekOnTanimID = Convert.ToInt32(com.Parameters["@YeniID"].Value.ToString());
      }
      else
      {

        com = new SqlCommand(@"update HemenAlUrunSecenekOnTanimlari set 
 Adi = @Adi, Aciklama = @Aciklama where HemenAlUrunSecenekOnTanimID = @HemenAlUrunSecenekOnTanimID", Baglanti, Tr);

        com.Parameters.Add("@Adi", SqlDbType.NVarChar).Value = _Adi;
        com.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;
        com.Parameters.Add("@HemenAlUrunSecenekOnTanimID", SqlDbType.Int).Value = _HemenAlUrunSecenekOnTanimID;

        com.ExecuteNonQuery();
      }




    }



  }
}
