﻿using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace PDKS
{
    public partial class frmKimNerede : DevExpress.XtraEditors.XtraForm
  {
    public frmKimNerede()
    {
      InitializeComponent();
    }
    clsTablolar.Personel.PDKS.csPdksKrt Hareketler = new clsTablolar.Personel.PDKS.csPdksKrt();
    SqlTransaction TrGEnel;
    private void frmKimNerede_Load(object sender, EventArgs e)
    {
      try
      {
        TrGEnel = SqlConnections.GetBaglanti().BeginTransaction();
        gridControl2.DataSource = Hareketler.HareketleriniGetir(SqlConnections.GetBaglanti(), TrGEnel);
        TrGEnel.Commit();
      }
      catch (Exception)
      {
        TrGEnel.Rollback();
      }
    }

    private void frmKimNerede_KeyDown(object sender, KeyEventArgs e)
    {
      this.Visible = false ;
      
    }

    private void frmKimNerede_FormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = true;
      this.Hide();
    }
  }
}