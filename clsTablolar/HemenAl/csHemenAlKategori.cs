using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.HemenAl
{
  public class csHemenAlKategori : IDisposable
  {
    public void Dispose()
    {
      GC.SuppressFinalize(this);
    }

    private int _HemanAlKategoriID;
    private string _KategoriAdi;
    private bool _Aktif;
    private bool _Aktif_Bayi;
    private int _UstKategoriID;
    private int _Sira;

    public int HemanAlKategoriID
    {
      get { return _HemanAlKategoriID; }
      set { _HemanAlKategoriID = value; }
    }
    public string KategoriAdi
    {
      get { return _KategoriAdi; }
      set { _KategoriAdi = value; }
    }
    public bool Aktif
    {
      get { return _Aktif; }
      set { _Aktif = value; }
    }
    public bool Aktif_Bayi
    {
      get { return _Aktif_Bayi; }
      set { _Aktif_Bayi = value; }
    }
    public int UstKategoriID
    {
      get { return _UstKategoriID; }
      set { _UstKategoriID = value; }
    }
    public int Sira
    {
      get { return _Sira; }
      set { _Sira = value; }
    }

    public DataTable dt_Kategoriler;
    SqlDataAdapter da_Kategoriler;

    public void KategoriGetir(SqlConnection baglanti, SqlTransaction tr)
    {
      using (da_Kategoriler = new SqlDataAdapter(@"select HemenAlKategori.HemanAlKategoriID, HemenAlKategori.KategoriAdi, HemenAlKategori.Aktif, HemenAlKategori.Aktif_Bayi, 
isnull(HemenAlKategori.UstKategoriID, 0) as 'UstKategoriID', HemenAlKategori.Sira, ISNULL(UstKategoriAdi.KategoriAdi, 0) as 'UstKategoriAdi' from HemenAlKategori
left join
HemenAlKategori as UstKategoriAdi on UstKategoriAdi.HemanAlKategoriID = HemenAlKategori.UstKategoriID", baglanti))
      {
        da_Kategoriler.SelectCommand.Transaction = tr;

        using (dt_Kategoriler = new DataTable())
        {
          da_Kategoriler.Fill(dt_Kategoriler);
        }
      }
    }




    public void KategoriGuncelle(SqlConnection baglanti, SqlTransaction Tr)
    {
      using (da_Kategoriler = new SqlDataAdapter("", baglanti))
      {
        da_Kategoriler.InsertCommand = new SqlCommand(@"insert into HemenAlKategori
(KategoriAdi, Aktif, Aktif_Bayi, UstKategoriID, Sira ) 
values 
(@KategoriAdi, @Aktif, @Aktif_Bayi, @UstKategoriID, @Sira )  set @YeniID = SCOPE_IDENTITY() ", baglanti, Tr);

        da_Kategoriler.InsertCommand.Parameters.Add("@YeniID", SqlDbType.Int).Direction = ParameterDirection.Output;

        da_Kategoriler.InsertCommand.Parameters.Add("@KategoriAdi", SqlDbType.NVarChar, 50, "KategoriAdi");
        da_Kategoriler.InsertCommand.Parameters.Add("@Aktif", SqlDbType.Bit, 0, "Aktif");
        da_Kategoriler.InsertCommand.Parameters.Add("@Aktif_Bayi", SqlDbType.Bit, 0, "Aktif_Bayi");
        da_Kategoriler.InsertCommand.Parameters.Add("@UstKategoriID", SqlDbType.Int, 0, "UstKategoriID");
        da_Kategoriler.InsertCommand.Parameters.Add("@Sira", SqlDbType.Int, 0, "Sira");

        da_Kategoriler.UpdateCommand = new SqlCommand(@"update HemenAlKategori set KategoriAdi = @KategoriAdi, Aktif = @Aktif, 
Aktif_Bayi = @Aktif_Bayi, UstKategoriID = @UstKategoriID, Sira = @Sira where HemanAlKategoriID  = @HemanAlKategoriID", baglanti, Tr);
        da_Kategoriler.UpdateCommand.Parameters.Add("@KategoriAdi", SqlDbType.NVarChar, 50, "KategoriAdi");
        da_Kategoriler.UpdateCommand.Parameters.Add("@Aktif", SqlDbType.Bit, 0, "Aktif");
        da_Kategoriler.UpdateCommand.Parameters.Add("@Aktif_Bayi", SqlDbType.Bit, 0, "Aktif_Bayi");
        da_Kategoriler.UpdateCommand.Parameters.Add("@UstKategoriID", SqlDbType.Int, 0, "UstKategoriID");
        da_Kategoriler.UpdateCommand.Parameters.Add("@Sira", SqlDbType.Int, 0, "Sira");
        da_Kategoriler.UpdateCommand.Parameters.Add("@HemanAlKategoriID", SqlDbType.Int, 0, "HemanAlKategoriID");

        da_Kategoriler.DeleteCommand = new SqlCommand(@"delete from HemenAlKategori where HemanAlKategoriID  = @HemanAlKategoriID", baglanti, Tr);
        da_Kategoriler.DeleteCommand.Parameters.Add("@HemanAlKategoriID", SqlDbType.Int, 0, "HemanAlKategoriID");

        da_Kategoriler.RowUpdated += da_Kategoriler_RowUpdated;

        da_Kategoriler.Update(dt_Kategoriler);

      }
    }

    void da_Kategoriler_RowUpdated(object sender, SqlRowUpdatedEventArgs e)
    {
      if (e.StatementType == StatementType.Insert)
      {
        e.Row["FaturaHareketID"] = e.Command.Parameters["@YeniID"].Value;
      }
    }
  }
}