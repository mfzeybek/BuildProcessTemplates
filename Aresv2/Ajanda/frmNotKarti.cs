using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Ajanda
{
  public partial class frmNotKarti : DevExpress.XtraEditors.XtraForm
  {
    public frmNotKarti(int NotID)
    {
      _NotID = NotID;
      InitializeComponent();
    }

    int _NotID = -1;

    private void textEdit1_EditValueChanged(object sender, EventArgs e)
    {

    }
    clsTablolar.Ajanda.csNotlar Not;
    clsTablolar.Ajanda.csNotGuruplari Grup;

    SqlTransaction TrGenel;
    private void frmNotKarti_Load(object sender, EventArgs e)
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
        Not = new clsTablolar.Ajanda.csNotlar(SqlConnections.GetBaglanti(), TrGenel, _NotID);

        Grup = new clsTablolar.Ajanda.csNotGuruplari();
        Grup.GruplariDoldur(SqlConnections.GetBaglanti(), TrGenel);

        GrubDoldur();

        TrGenel.Commit();

        BinleHamisina();

        KaydetmedenCikilmasin(false);
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    public void GrubDoldur()
    {
      //TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      Grup.GruplariDoldur(SqlConnections.GetBaglanti(), TrGenel);
      //TrGenel.Commit();

      treeList1.DataSource = Grup.dt_NotGruplari;

      treeList1.KeyFieldName = "NotGurupID";
      treeList1.ParentFieldName = "UstGurupID";

      lookUpEdit1.Properties.DataSource = Grup.dt_NotGruplari;

      lookUpEdit1.Properties.DisplayMember = "GrupAdi";
      lookUpEdit1.Properties.ValueMember = "NotGurupID";



    }

    void BinleHamisina()
    {
      txtBaslik.DataBindings.Add("EditValue", Not, "Baslik", false, DataSourceUpdateMode.OnPropertyChanged);
      memoEdit_Aciklama.DataBindings.Add("EditValue", Not, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
      dateEdit1.DataBindings.Add("EditValue", Not, "NotTarihi", false, DataSourceUpdateMode.OnPropertyChanged);
      lookUpEdit1.DataBindings.Add("EditValue", Not, "GrupID", false, DataSourceUpdateMode.OnPropertyChanged);
      //treeList1.DataBindings.Add("EditValue", Not, "GrupID", false, DataSourceUpdateMode.OnPropertyChanged);
    }

    /// <summary>
    /// btnKaydet.Enabled = true_false;
    /// </summary>
    /// <param name="true_false"></param>
    void KaydetmedenCikilmasin(bool true_false)
    {
      btnKaydet.Enabled = true_false;
      btnVazgec.Enabled = true_false;
      btnSil.Enabled = !true_false;
    }

    private void btnKaydet_Click(object sender, EventArgs e)
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

        Not.Kaydet(SqlConnections.GetBaglanti(), TrGenel, Not.NotID);

        TrGenel.Commit();

        KaydetmedenCikilmasin(false);
      }
      catch (Exception hata)
      {
        TrGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }

    private void btnSil_Click(object sender, EventArgs e)
    {

    }

    private void butunTextler_EditValueChanged(object sender, EventArgs e)
    {
      KaydetmedenCikilmasin(true);
    }
  }
}