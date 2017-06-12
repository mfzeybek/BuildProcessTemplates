using System;
using System.Data.SqlClient;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDKS
{
    public partial class Form1 : Form
  {
    clsTablolar.Personel.PDKS.csPdksKrt Hareketler;
    SqlTransaction TrGEnel;
    public Form1()
    {  
      InitializeComponent();
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode == Keys.Enter)
      {
        simpleButton1_Click(null, null);
      }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        Hareketler = new clsTablolar.Personel.PDKS.csPdksKrt();

        TrGEnel = SqlConnections.GetBaglanti().BeginTransaction();
        gridControl2.DataSource = Hareketler.Nerede(SqlConnections.GetBaglanti(), TrGEnel);
        TrGEnel.Commit();
        Zaman = 15;
        timer1.Start();
      }
      catch (Exception)
      {
        TrGEnel.Rollback();
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      try
      {
        TrGEnel = SqlConnections.GetBaglanti().BeginTransaction();
        gridControl1.DataSource = Hareketler.HareketleriniGetir(SqlConnections.GetBaglanti(), TrGEnel, textBox1.Text);
        TrGEnel.Commit();
      }
      catch (Exception)
      {
        TrGEnel.Rollback();
      } 
    }

    int Zaman = 0;

    private void timer1_Tick(object sender, EventArgs e)
    {
      Zaman -= 1;
      label1.Text = Zaman.ToString();
      if (Zaman == 0)
      {
        timer1.Stop();
        Close();
      }
    }



  }
}
