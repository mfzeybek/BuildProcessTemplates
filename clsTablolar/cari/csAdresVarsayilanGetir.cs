using System;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.cari
{
  public class csAdresVarsayilanGetir : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    private int _AdresID;
    private int _CariID;
    private string _Adres;
    private string _PostaKodu;
    private string _UlkeAdi;
    private string _SehirAdi;
    private string _IlceAdi;
    private string _Aciklama;


    public int AdresID
    {
      get { return _AdresID; }
      set { _AdresID = value; }
    }
    public int CariID
    {
      get { return _CariID; }
      set { _CariID = value; }
    }
    public string Adres
    {
      get { return _Adres; }
      set { _Adres = value; }
    }
    public string PostaKodu
    {
      get { return _PostaKodu; }
      set { _PostaKodu = value; }
    }
    public string UlkeAdi
    {
      get { return _UlkeAdi; }
      set { _UlkeAdi = value; }
    }
    public string SehirAdi
    {
      get { return _SehirAdi; }
      set { _SehirAdi = value; }
    }
    public string IlceAdi
    {
      get { return _IlceAdi; }
      set { _IlceAdi = value; }
    }
    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }



    SqlCommand cmd;
    SqlDataReader dr;
    public csAdresVarsayilanGetir(SqlConnection Baglanti, SqlTransaction Tr, int CariID)
    {
      using (cmd = new SqlCommand(@"select Adres.Adres, Adres.Aciklama, Adres.CariID, Adres.AdresID, Ulke.UlkeAdi, Ilce.IlceAdi, Sehir.SehirAdi, Adres.PostaKodu from Adres
                             left join
                             Ilce on Ilce.IlceID = Adres.IlceID
                             left join 
                             Sehir on Sehir.SehirID = Adres.SehirID
                             left join
                             Ulke on Ulke.UlkeID = Adres.UlkeID
                             where Adres.Varsayilan = 'True' and CariID = @CariID", Baglanti, Tr))
      {
        cmd.Parameters.Add("@CariID", SqlDbType.Int).Value = CariID;

        using (dr = cmd.ExecuteReader())
        {
          if (dr.Read())
          {
            AdresID = Convert.ToInt32(dr["AdresID"]);
            CariID = Convert.ToInt32(dr["CariID"]);
            Adres = dr["Adres"].ToString();
            PostaKodu = dr["PostaKodu"].ToString();
            UlkeAdi = dr["UlkeAdi"].ToString();
            SehirAdi = dr["SehirAdi"].ToString();
            IlceAdi = dr["IlceAdi"].ToString();
            Aciklama = dr["Aciklama"].ToString();
          }
        }
      }
    }
  }
}
