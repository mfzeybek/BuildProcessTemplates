using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace clsTablolar.IsBasvurulari
{
  public class csIsBasvurulariArama : IDisposable
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    private int _IsBasvuruID;
    private DateTime _FormTarihi;
    private string _Adi;
    private string _Soyadi;
    private string _DogumYeri;
    private DateTime _DogumTarihi;
    private int _Cinsiyeti;
    private bool _SigaraIciyormu;
    private int _MedeniHali;
    private int _AskerlikDurumu;
    private string _EvTelefonu;
    private string _CepTelefonu;
    private string _EvAdresi;
    private string _EPosta;
    private string _OgrenimDurumu;
    private string _IsTecrubeleri;
    private string _EklemekIstedikleri;
    private string _Aciklama;
    private DateTime _MulakatTarihi;
    private string _MulakatNotlari;
    private int _IsBasvurulariGrupID;



    public byte[] Foto;







    public int IsBasvuruID
    {
      get { return _IsBasvuruID; }
      set { _IsBasvuruID = value; }
    }
    public DateTime FormTarihi
    {
      get { return _FormTarihi; }
      set { _FormTarihi = value; }
    }
    public string Adi
    {
      get { return _Adi; }
      set { _Adi = value; }
    }
    public string Soyadi
    {
      get { return _Soyadi; }
      set { _Soyadi = value; }
    }
    public string DogumYeri
    {
      get { return _DogumYeri; }
      set { _DogumYeri = value; }
    }
    public DateTime DogumTarihi
    {
      get { return _DogumTarihi; }
      set { _DogumTarihi = value; }
    }
    public int Cinsiyeti
    {
      get { return _Cinsiyeti; }
      set { _Cinsiyeti = value; }
    }
    public bool SigaraIciyormu
    {
      get { return _SigaraIciyormu; }
      set { _SigaraIciyormu = value; }
    }
    public int MedeniHali
    {
      get { return _MedeniHali; }
      set { _MedeniHali = value; }
    }
    public int AskerlikDurumu
    {
      get { return _AskerlikDurumu; }
      set { _AskerlikDurumu = value; }
    }
    public string EvTelefonu
    {
      get { return _EvTelefonu; }
      set { _EvTelefonu = value; }
    }
    public string CepTelefonu
    {
      get { return _CepTelefonu; }
      set { _CepTelefonu = value; }
    }
    public string EvAdresi
    {
      get { return _EvAdresi; }
      set { _EvAdresi = value; }
    }
    public string EPosta
    {
      get { return _EPosta; }
      set { _EPosta = value; }
    }
    public string OgrenimDurumu
    {
      get { return _OgrenimDurumu; }
      set { _OgrenimDurumu = value; }
    }
    public string IsTecrubeleri
    {
      get { return _IsTecrubeleri; }
      set { _IsTecrubeleri = value; }
    }
    public string EklemekIstedikleri
    {
      get { return _EklemekIstedikleri; }
      set { _EklemekIstedikleri = value; }
    }

    public string Aciklama
    {
      get { return _Aciklama; }
      set { _Aciklama = value; }
    }
    public DateTime MulakatTarihi
    {
      get { return _MulakatTarihi; }
      set { _MulakatTarihi = value; }
    }
    public string MulakatNotlari
    {
      get { return _MulakatNotlari; }
      set { _MulakatNotlari = value; }
    }

    public int IsBasvurulariGrupID
    {
      get { return _IsBasvurulariGrupID; }
      set { _IsBasvurulariGrupID = value; }
    }


    public csIsBasvurulariArama()
    {
      _Adi = "";
      _Soyadi = "";
      _IsBasvurulariGrupID = -1;
    }

    public DataTable BasvuruListesi(SqlConnection Baglanti, SqlTransaction Tr)
    {
      using (SqlDataAdapter da = new SqlDataAdapter(@"select IsBasvuruID, FormTarihi, Adi, Soyadi, DogumYeri, DogumTarihi, 
                                                      case Cinsiyeti
                                                      when 1 then 'Bay'
                                                      when 2 then 'Bayan'
                                                      end as Cinsiyeti 
       , SigaraIciyormu, 
      MedeniHali, AskerlikDurumu, EvTelefonu, CepTelefonu, EvAdresi, EPosta, OgrenimDurumu, IsTecrubeleri, EklemekIstedikleri, Foto, Aciklama,
      MulakatTarihi, MulakatNotlari, IsBasvurulariGrup.GrupAdi from IsBasvurulari 
      left join IsBasvurulariGrup on IsBasvurulariGrup.IsBasvurulariGrupID = IsBasvurulari.IsBasvurulariGrupID
      where 1 = 1", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        if (_Adi != "")
        {
          da.SelectCommand.CommandText += " and Adi like '%'+@Adi+'%'";
          da.SelectCommand.Parameters.Add("@Adi", SqlDbType.NVarChar).Value = _Adi;
        }

        if (_Soyadi != "")
        {
          da.SelectCommand.CommandText += " and Soyadi like '%'+@Soyadi+'%'";
          da.SelectCommand.Parameters.Add("@Soyadi", SqlDbType.NVarChar).Value = _Soyadi;
        }

        if (_IsBasvurulariGrupID != -1)
        {
          da.SelectCommand.CommandText += " and IsBasvurulari.IsBasvurulariGrupID = @IsBasvurulariGrupID";
          da.SelectCommand.Parameters.Add("@IsBasvurulariGrupID", SqlDbType.Int).Value = _IsBasvurulariGrupID;
        }

        using (DataTable dt = new DataTable())
        {
          da.Fill(dt);
          return dt;
        }
      }
    }


    DataTable Dt_Fotolar;
    SqlDataAdapter da;
    public DataTable FotolariniGetir(SqlConnection Baglanti, SqlTransaction Tr, int IsBasvuruID)
    {
      using (da = new SqlDataAdapter(@"select Dosya from IsBasvuruDosya where IsBasvuruDosya.IsBasvuruID = @IsBasvuruID", Baglanti))
      {
        da.SelectCommand.Transaction = Tr;
        da.SelectCommand.Parameters.Add("@IsBasvuruID", SqlDbType.Int).Value = IsBasvuruID;
        using (Dt_Fotolar = new DataTable())
        {
          da.Fill(Dt_Fotolar);
        }
        return Dt_Fotolar;
      }
    }



  }
}
