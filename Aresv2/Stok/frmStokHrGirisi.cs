using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Aresv2.Stok
{
    public partial class frmStokHrGirisi : Form
  {
    public frmStokHrGirisi(int StokHrID)
    {
      _StokHrID = StokHrID;
      InitializeComponent();
    }
    int _StokHrID = -1;

    clsTablolar.Stok.csStokHr Hareket;
    SqlTransaction TrGenel;

    private void frmStokHrGirisi_Load(object sender, EventArgs e)
    {
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      
      Hareket = new clsTablolar.Stok.csStokHr(SqlConnections.GetBaglanti(), TrGenel, _StokHrID); 

    }

    void binle()
    {
      deTarih.DataBindings.Add("EditValue", Hareket, "Tarih", false, DataSourceUpdateMode.OnPropertyChanged);
      txtAciklama.DataBindings.Add("EditValue", Hareket, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);





    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {

    }

  }
}
