using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.HemenAl
{
  public partial class HemenAlUrunSecenekOnTanimlari : Form
  {
    public HemenAlUrunSecenekOnTanimlari(NasinAcsin _AcmaSekli)
    {
      AcmaSekli = _AcmaSekli;
      InitializeComponent();
    }

    public enum NasinAcsin {StokaEklemekIcin, OnTanimDuzenlemekIcin }

    public NasinAcsin AcmaSekli;
    

    clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanimlari OnTanimlar;


    SqlTransaction TrGenel;

    private void HemenAlUrunSecenekOnTanimlari_Load(object sender, EventArgs e)
    {
      if (AcmaSekli == NasinAcsin.StokaEklemekIcin)
      {
        this.Text = "On Tanimlardan Seç Hamisina";
        simpleButton1.Visible = false;
        simpleButton2.Visible = false;
        simpleButton3.Visible = false;
        simpleButton4.Visible = true;
      }
      else
      {
        this.Text = "On Tanim Ayarlari";
        simpleButton1.Visible = true;
        simpleButton2.Visible = true;
        simpleButton3.Visible = true;
        simpleButton4.Visible = false;
      }
      
      OnTanimlar = new clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanimlari();
      
      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

      gridControl1.DataSource = OnTanimlar.Tanimlar(SqlConnections.GetBaglanti(), TrGenel);

      TrGenel.Commit();
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      HemenAl.UrunSecenek.frmHemenAlUrunSecenekOnTanimDetaylari frm = new UrunSecenek.frmHemenAlUrunSecenekOnTanimDetaylari(-1);
      frm.Show();
    }

    private void simpleButton3_Click(object sender, EventArgs e)
    {
      HemenAl.UrunSecenek.frmHemenAlUrunSecenekOnTanimDetaylari frm = new UrunSecenek.frmHemenAlUrunSecenekOnTanimDetaylari(Convert.ToInt32(gridView1.GetFocusedRowCellValue("HemenAlUrunSecenekOnTanimID")));
      frm.MdiParent = this.MdiParent;
      frm.Show();
    }

    private void simpleButton4_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Yes;
      Close();
    }




  }
}
