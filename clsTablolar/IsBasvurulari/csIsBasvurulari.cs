using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.IsBasvurulari
{
  public class csIsBasvurulari : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
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


    private bool _MulakatYapilacakmi;

    public bool MulakatYapilacakmi
    {
      get { return _MulakatYapilacakmi; }
      set { _MulakatYapilacakmi = value; }
    }


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


    SqlCommand cmd;
    SqlDataReader dr;

    public csIsBasvurulari(SqlConnection Baglanti, SqlTransaction Tr, int IsBasvuruID)
    {
      if (IsBasvuruID == -1)
      {
        _IsBasvuruID = -1;
        _FormTarihi = DateTime.Now;
        _Adi = "";
        _Soyadi = "";
        _DogumYeri = "";
        _DogumTarihi = DateTime.Now;
        _Cinsiyeti = 0;
        _SigaraIciyormu = false;
        _MedeniHali = 0;
        _AskerlikDurumu = 0;
        _EvTelefonu = "";
        _CepTelefonu = "";
        _EvAdresi = "";
        _EPosta = "";
        _OgrenimDurumu = "";
        _IsTecrubeleri = "";
        _EklemekIstedikleri = "";
        _Aciklama = "";
        _MulakatTarihi = DateTime.MinValue;
        _MulakatNotlari = "";
        _MulakatYapilacakmi = false;
        _IsBasvurulariGrupID = -1;

        //private Byte _Foto; bu bakılacak
      }
      else
      {
        using (cmd = new SqlCommand("select * from IsBasvurulari where IsBasvuruID = @IsBasvuruID ", Baglanti, Tr))
        {
          cmd.Parameters.Add("@IsBasvuruID", SqlDbType.Int).Value = IsBasvuruID;

          using (dr = cmd.ExecuteReader())
          {

            if (dr.Read())
            {
              _IsBasvuruID = Convert.ToInt32(dr["IsBasvuruID"]);
              _FormTarihi = Convert.ToDateTime(dr["FormTarihi"]);
              _Adi = dr["Adi"].ToString();
              _Soyadi = dr["Soyadi"].ToString();
              _DogumYeri = dr["DogumYeri"].ToString();
              _DogumTarihi = Convert.ToDateTime(dr["DogumTarihi"]);

              _Cinsiyeti = Convert.ToInt32(dr["Cinsiyeti"]);

              _SigaraIciyormu = Convert.ToBoolean(dr["SigaraIciyormu"]);

              _MedeniHali = Convert.ToInt16(dr["MedeniHali"]);

              _AskerlikDurumu = Convert.ToInt16(dr["AskerlikDurumu"]);

              _EvTelefonu = dr["EvTelefonu"].ToString();
              _CepTelefonu = dr["CepTelefonu"].ToString();
              _EvAdresi = dr["EvAdresi"].ToString();
              _EPosta = dr["EPosta"].ToString();
              _OgrenimDurumu = dr["OgrenimDurumu"].ToString();
              _IsTecrubeleri = dr["IsTecrubeleri"].ToString();
              _EklemekIstedikleri = dr["EklemekIstedikleri"].ToString();
              _Aciklama = dr["Aciklama"].ToString();

              if (dr["MulakatTarihi"] == DBNull.Value)
                _MulakatTarihi = DateTime.MinValue;
              else
                _MulakatTarihi = Convert.ToDateTime(dr["MulakatTarihi"]);

              if (_MulakatTarihi == DateTime.MinValue)
                _MulakatYapilacakmi = false;
              else
                _MulakatYapilacakmi = true;

              _MulakatNotlari = dr["MulakatNotlari"].ToString();
              _IsBasvurulariGrupID = Convert.ToInt32(dr["IsBasvurulariGrupID"]);
            }
          }
        }

      }
      IsbasvurulariDosya(Baglanti, Tr, IsBasvuruID);
    }

    public void Guncelle(SqlConnection Baglanti, SqlTransaction Tr, int IsBasvuruID)
    {
      if (IsBasvuruID == -1)
      {
        cmd = new SqlCommand(@"insert into IsBasvurulari 
      ( FormTarihi, Adi, Soyadi, DogumYeri, DogumTarihi, Cinsiyeti, SigaraIciyormu, MedeniHali, AskerlikDurumu, EvTelefonu, 
      CepTelefonu, EvAdresi, EPosta, OgrenimDurumu, IsTecrubeleri, EklemekIstedikleri, Aciklama, MulakatTarihi, MulakatNotlari, IsBasvurulariGrupID ) 
      values 
      ( @FormTarihi, @Adi, @Soyadi, @DogumYeri, @DogumTarihi, @Cinsiyeti, @SigaraIciyormu, @MedeniHali, @AskerlikDurumu, @EvTelefonu, 
      @CepTelefonu, @EvAdresi, @EPosta, @OgrenimDurumu, @IsTecrubeleri, @EklemekIstedikleri, @Aciklama, @MulakatTarihi, @MulakatNotlari, @IsBasvurulariGrupID ) 
      set @YeniID = SCOPE_IDENTITY()", Baglanti, Tr);


        cmd.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;
      }
      else
      {
        cmd = new SqlCommand(@"update IsBasvurulari set  FormTarihi = @FormTarihi, Adi = @Adi, Soyadi = @Soyadi, 
        DogumYeri = @DogumYeri, DogumTarihi = @DogumTarihi, Cinsiyeti = @Cinsiyeti, SigaraIciyormu = @SigaraIciyormu, MedeniHali = @MedeniHali, 
        AskerlikDurumu = @AskerlikDurumu, EvTelefonu = @EvTelefonu, CepTelefonu = @CepTelefonu, EvAdresi = @EvAdresi, EPosta = @EPosta, 
        OgrenimDurumu = @OgrenimDurumu, IsTecrubeleri = @IsTecrubeleri, EklemekIstedikleri = @EklemekIstedikleri, Aciklama = @Aciklama, 
        MulakatTarihi = @MulakatTarihi, MulakatNotlari = @MulakatNotlari , IsBasvurulariGrupID = @IsBasvurulariGrupID  where IsBasvuruID = @IsBasvuruID", Baglanti, Tr);

        cmd.Parameters.Add("@IsBasvuruID", SqlDbType.NVarChar).Value = IsBasvuruID;

      }
      cmd.Parameters.Add("@FormTarihi", SqlDbType.DateTime).Value = _FormTarihi;
      cmd.Parameters.Add("@Adi", SqlDbType.NVarChar).Value = _Adi;
      cmd.Parameters.Add("@Soyadi", SqlDbType.NVarChar).Value = _Soyadi;
      cmd.Parameters.Add("@DogumYeri", SqlDbType.NVarChar).Value = _DogumYeri;
      cmd.Parameters.Add("@DogumTarihi", SqlDbType.DateTime).Value = _DogumTarihi;
      cmd.Parameters.Add("@Cinsiyeti", SqlDbType.TinyInt).Value = _Cinsiyeti;
      cmd.Parameters.Add("@SigaraIciyormu", SqlDbType.Bit).Value = _SigaraIciyormu;
      cmd.Parameters.Add("@MedeniHali", SqlDbType.TinyInt).Value = _MedeniHali;
      cmd.Parameters.Add("@AskerlikDurumu", SqlDbType.TinyInt).Value = _AskerlikDurumu;
      cmd.Parameters.Add("@EvTelefonu", SqlDbType.NVarChar).Value = _EvTelefonu;
      cmd.Parameters.Add("@CepTelefonu", SqlDbType.NVarChar).Value = _CepTelefonu;
      cmd.Parameters.Add("@EvAdresi", SqlDbType.NVarChar).Value = _EvAdresi;
      cmd.Parameters.Add("@EPosta", SqlDbType.NVarChar).Value = _EPosta;
      cmd.Parameters.Add("@OgrenimDurumu", SqlDbType.NVarChar).Value = _OgrenimDurumu;
      cmd.Parameters.Add("@IsTecrubeleri", SqlDbType.NVarChar).Value = _IsTecrubeleri;
      cmd.Parameters.Add("@EklemekIstedikleri", SqlDbType.NVarChar).Value = _EklemekIstedikleri;
      cmd.Parameters.Add("@IsBasvurulariGrupID", SqlDbType.Int).Value = _IsBasvurulariGrupID;



      //cmd.Parameters.Add("@Foto", SqlDbType.

      cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = _Aciklama;

      if (_MulakatTarihi == DateTime.MinValue)
        cmd.Parameters.Add("@MulakatTarihi", SqlDbType.DateTime).Value = DBNull.Value;
      else
        cmd.Parameters.Add("@MulakatTarihi", SqlDbType.DateTime).Value = _MulakatTarihi;


      cmd.Parameters.Add("@MulakatNotlari", SqlDbType.NVarChar).Value = _MulakatNotlari;

      cmd.ExecuteNonQuery();

      if (_IsBasvuruID == -1)
        _IsBasvuruID = Convert.ToInt32(cmd.Parameters["@YeniID"].Value);

      IsBasvuruDosyaGuncelle(Baglanti, Tr, _IsBasvuruID);
    }

    public void Sil(SqlConnection Baglanti, SqlTransaction Tr, int IsBasvuruID)
    {
      using (cmd = new SqlCommand("delete from IsBasvurulari where IsBasvuruID = @IsBasvuruID", Baglanti, Tr))
      {
        cmd.Parameters.Add("@IsBasvuruID", SqlDbType.Int).Value = IsBasvuruID;

        cmd.ExecuteNonQuery();
      }
    }

    public DataTable dt_AskerlikDurumuYukle()
    {
      DataTable dt = new DataTable();
      dt.Columns.Add("AskerlikDurumuKodu");
      dt.Columns[0].AutoIncrement = true;
      dt.Columns.Add("AskerlikDurumuAdi");
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["AskerlikDurumuKodu"] = "1";
      dt.Rows[0]["AskerlikDurumuAdi"] = "Yaptı";

      dt.Rows[1]["AskerlikDurumuKodu"] = "2";
      dt.Rows[1]["AskerlikDurumuAdi"] = "Yapmadı";

      dt.Rows[2]["AskerlikDurumuKodu"] = "3";
      dt.Rows[2]["AskerlikDurumuAdi"] = "Tecilli";

      dt.Rows[3]["AskerlikDurumuKodu"] = "4";
      dt.Rows[3]["AskerlikDurumuAdi"] = "Muaf";

      return dt;
    }

    public DataTable dt_MedeniHali()
    {
      DataTable dt = new DataTable();
      dt.Columns.Add("MedeniHaliKodu");
      dt.Columns[0].AutoIncrement = true;
      dt.Columns.Add("MedeniHaliAdi");

      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["MedeniHaliKodu"] = "1";
      dt.Rows[0]["MedeniHaliAdi"] = "Bekar";

      dt.Rows[1]["MedeniHaliKodu"] = "2";
      dt.Rows[1]["MedeniHaliAdi"] = "Evli";

      dt.Rows[2]["MedeniHaliKodu"] = "3";
      dt.Rows[2]["MedeniHaliAdi"] = "Boşanmış";

      return dt;
    }

    public DataTable dt_Cinsiyeti()
    {
      DataTable dt = new DataTable();
      dt.Columns.Add("CinsiyetiKodu");
      dt.Columns[0].AutoIncrement = true;
      dt.Columns.Add("CinsiyetiAdi");

      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());
      dt.Rows.Add(dt.NewRow());

      dt.Rows[0]["CinsiyetiKodu"] = "1";
      dt.Rows[0]["CinsiyetiAdi"] = "Bay";

      dt.Rows[1]["CinsiyetiKodu"] = "2";
      dt.Rows[1]["CinsiyetiAdi"] = "Bayan";

      dt.Rows[2]["CinsiyetiKodu"] = "3";
      dt.Rows[2]["CinsiyetiAdi"] = "Hermafrodit";

      return dt;

    }


    SqlDataAdapter da_IsbasvuruDosya;
    public DataTable dt_IsbasvuruDosya;

    private void IsbasvurulariDosya(SqlConnection Baglanti, SqlTransaction Tr, int IsBasvuruID)
    {
      da_IsbasvuruDosya = new SqlDataAdapter("select IsBasvuruDosyaID, IsBasvuruID, Aciklama, VarsayilanMi, Dosya from IsBasvuruDosya where IsBasvuruID = @IsBasvuruID", Baglanti);
      da_IsbasvuruDosya.SelectCommand.Transaction = Tr;

      da_IsbasvuruDosya.SelectCommand.Parameters.Add("@IsBasvuruID", SqlDbType.Int).Value = IsBasvuruID;

      dt_IsbasvuruDosya = new DataTable();

      da_IsbasvuruDosya.Fill(dt_IsbasvuruDosya);
    }



    private void IsBasvuruDosyaGuncelle(SqlConnection Baglanti, SqlTransaction Tr, int IsBasvuruID)
    {
      da_IsbasvuruDosya.UpdateCommand = new SqlCommand("update IsBasvuruDosya set IsBasvuruID = @IsBasvuruID   , Aciklama = @Aciklama, VarsayilanMi = @VarsayilanMi, Dosya = @Dosya where IsBasvuruDosyaID = @IsBasvuruDosyaID ", Baglanti, Tr);

      da_IsbasvuruDosya.UpdateCommand.Parameters.Add("@IsBasvuruDosyaID", SqlDbType.Int, 0, "IsBasvuruDosyaID");
      da_IsbasvuruDosya.UpdateCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 150, "Aciklama");
      da_IsbasvuruDosya.UpdateCommand.Parameters.Add("@VarsayilanMi", SqlDbType.Bit, 0, "VarsayilanMi");
      da_IsbasvuruDosya.UpdateCommand.Parameters.Add("@Dosya", SqlDbType.VarBinary, 0, "Dosya");
      da_IsbasvuruDosya.UpdateCommand.Parameters.Add("@IsBasvuruID", SqlDbType.Int).Value = IsBasvuruID;

      da_IsbasvuruDosya.InsertCommand = new SqlCommand(@"insert into IsBasvuruDosya 
        ( IsBasvuruID, Aciklama, VarsayilanMi, Dosya )
        values 
        ( @IsBasvuruID, @Aciklama, @VarsayilanMi, @Dosya ) ", Baglanti, Tr);

      da_IsbasvuruDosya.InsertCommand.Parameters.Add("@IsBasvuruID", SqlDbType.Int).Value = IsBasvuruID;
      da_IsbasvuruDosya.InsertCommand.Parameters.Add("@Aciklama", SqlDbType.NVarChar, 150, "Aciklama");
      da_IsbasvuruDosya.InsertCommand.Parameters.Add("@VarsayilanMi", SqlDbType.Bit, 0, "VarsayilanMi");
      da_IsbasvuruDosya.InsertCommand.Parameters.Add("@Dosya", SqlDbType.VarBinary, 0, "Dosya");


      da_IsbasvuruDosya.DeleteCommand = new SqlCommand("delete from IsBasvuruDosya where IsBasvuruDosyaID = @IsBasvuruDosyaID ", Baglanti, Tr);
      da_IsbasvuruDosya.DeleteCommand.Parameters.Add("@IsBasvuruDosyaID", SqlDbType.Int, 0, "IsBasvuruDosyaID");



      da_IsbasvuruDosya.Update(dt_IsbasvuruDosya);


    }


  }
}
