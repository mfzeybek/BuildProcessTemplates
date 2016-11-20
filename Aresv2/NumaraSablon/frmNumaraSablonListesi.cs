using System;
using System.Data;
using System.Data.SqlClient;

namespace Aresv2.NumaraSablon
{
  public partial class frmNumaraSablonListesi : DevExpress.XtraEditors.XtraForm
  {
    SqlConnections Baglanti = new SqlConnections(); // bunu türetir türetmez SqlConnections class ında falan filan işte

    public frmNumaraSablonListesi(int ModulID)
    {
      InitializeComponent();
      _ModulID = ModulID;
    }
    int _ModulID = -1;
    public string _KullanilacakNumara = "";
    public int _NumaraSablonID = -1;

    string _IlkKarakter = "", _Numara = "";
    int _KarakterSayisi = 0;

    private void frmNumaraSablonListesi_Load(object sender, EventArgs e)
    {
      try
      {
        if (SqlConnections.GetBaglanti().State == ConnectionState.Closed)
          SqlConnections.GetBaglanti().Open();

        using (SqlDataAdapter da = new SqlDataAdapter(
@" SELECT  NumaraSablonID, ModulID, IlkKarakter, KarakterSayisi, Numara, Varsayilan FROM dbo.NumaraSablon AS NS WHERE (ModulID = @ModulID)", SqlConnections.GetBaglanti()))
        {
          da.SelectCommand.Parameters.Add("@ModulID", SqlDbType.Int).Value = _ModulID;
          DataTable dt = new DataTable();
          da.Fill(dt);
          gcNumaraSablon.DataSource = dt;
          gvNumaraSablon.PopulateColumns();
        }
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void gvNumaraSablon_DoubleClick(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.OK;
      string _NumaraTemp = "";
      _Numara = gvNumaraSablon.GetFocusedRowCellDisplayText("Numara");
      _IlkKarakter = gvNumaraSablon.GetFocusedRowCellDisplayText("IlkKarakter");
      _KarakterSayisi = Convert.ToInt32(gvNumaraSablon.GetFocusedRowCellDisplayText("KarakterSayisi"));
      _NumaraSablonID = Convert.ToInt32(gvNumaraSablon.GetFocusedRowCellValue("NumaraSablonID"));
      // Numara = gvNumaraSablon.GetFocusedRowCellDisplayText("IlkKarakter") + gvNumaraSablon.GetFocusedRowCellDisplayText("Numara");
      int ArtanKisim = Convert.ToInt32(_Numara) + 1;
      _NumaraTemp = ArtanKisim.ToString();
      while (_NumaraTemp.Length < _KarakterSayisi)
      {
        _NumaraTemp = "0" + _NumaraTemp;
      }
      _KullanilacakNumara = _IlkKarakter+_NumaraTemp;

      this.Close();
    }
  }
}