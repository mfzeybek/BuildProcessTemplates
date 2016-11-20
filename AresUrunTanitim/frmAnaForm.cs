using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace AresUrunTanitim
{
  public partial class frmAnaForm : Form
  {
    public frmAnaForm()
    {
      InitializeComponent();
    }

    SqlDataAdapter daUrunListesi = new SqlDataAdapter();

    SqlConnections Turettim = new SqlConnections();
    SqlConnection BaglantiAres = new SqlConnection();
    SqlConnection BaglantiAresUT = new SqlConnection();

    csStok StokListe;

    DataTable dtResim;

    private void Form1_Load(object sender, EventArgs e)
    {
      try
      {
        BaglantiAres = SqlConnections.GetAresSqlConnection();
        BaglantiAresUT = SqlConnections.GetAresUTSqlConnection();

        if (BaglantiAres.State == ConnectionState.Closed)
          BaglantiAres.Open();
        if (BaglantiAresUT.State == ConnectionState.Closed)
          BaglantiAresUT.Open();

        StokListe = new csStok(SqlConnections.GetAresUTSqlConnection());


        txtArama_TextChanged(null, null);
        gvResimYukle();



        txtArama.DataBindings.Add("EditValue", StokListe, "Arama", true, DataSourceUpdateMode.OnPropertyChanged);


        AlanlariYenidenBinle();

        timer1.Start();
      }
      catch (Exception hata)
      {
        MessageBox.Show(hata.Message);
      }
    }

    SqlDataAdapter da;

    private void AlanlariYenidenBinle()
    {
      try
      {
        lblFiyati.DataBindings.Clear();
        lblRafyeri.DataBindings.Clear();
        lblStokAdi.DataBindings.Clear();
        lblMiktari.DataBindings.Clear();

        lblFiyati.DataBindings.Add("Text", StokListe.dtStok, "Fiyati", true, DataSourceUpdateMode.OnPropertyChanged);
        lblStokAdi.DataBindings.Add("Text", StokListe.dtStok, "StokAdi", true, DataSourceUpdateMode.OnPropertyChanged);
        lblRafyeri.DataBindings.Add("Text", StokListe.dtStok, "RafYeriAciklama", true, DataSourceUpdateMode.OnPropertyChanged);
        lblMiktari.DataBindings.Add("Text", StokListe.dtStok, "Adet", false, DataSourceUpdateMode.OnPropertyChanged);
      }
      catch (Exception)
      {

      }

    }

    private void StokListeyiYukle()
    {
      //if (txtArama.Text == "") // bu olmayınca ufak bi sıkıntısı vardı geçti
      //{
      //    StokListe.Arama = "";
      //}
      try
      {
        //if (StokListe.dtStok.Rows.Count != 0)
        {
          gcUrunListesi.DataSource = StokListe.StokAra(SqlConnections.GetAresUTSqlConnection());
        }
        if (gvUrunListesi.SelectedRowsCount == 0)
        {
          pictureEdit1.EditValue = null;
          lblFiyati.Text = "";
          lblRafyeri.Text = "";
          lblStokAdi.Text = "";
          return;
        }
        AlanlariYenidenBinle();

        gvResimYukle();
      }
      catch (Exception)
      {

        throw;
      }

    }

    private void gvResimYukle()
    {
      if (gvUrunListesi.SelectedRowsCount > 0)
      {
        da = new SqlDataAdapter("select * from Resim where StokID = @StokID", SqlConnections.GetAresUTSqlConnection());
        da.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = gvUrunListesi.GetFocusedRowCellValue("StokID");
        dtResim = new DataTable();
        da.Fill(dtResim);
        gcResimler.DataSource = dtResim;

        if (dtResim.Rows.Count > 0)
        {
          pictureEdit1.DataBindings.Clear();
          pictureEdit1.DataBindings.Add("EditValue", dtResim, "Resim", true, DataSourceUpdateMode.OnPropertyChanged);
        }
        else
        {
          pictureEdit1.DataBindings.Clear();
          pictureEdit1.EditValue = null;
        }
      }
    }

    private void gvUrunListesi_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
    {
      gvResimYukle();
      AlanlariYenidenBinle();
    }

    private void frmAnaForm_KeyDown(object sender, KeyEventArgs e)
    {
      EkranaLogoGetir(false);
      timer1.Stop();
      timer1.Start();
      txtArama.Focus();
      //if (txtArama.IsEditorActive == false && e.KeyData.ToString().Count() == 1)
      // {
      //  txtArama.EditValue = txtArama.Text + e.KeyData.ToString();
      // }
      if (e.Control)
        switch (e.KeyCode)
        {
          case Keys.Down:
            gvResimler.MoveNext();
            break;
          case Keys.Up:
            gvResimler.MovePrev();
            break;
          case Keys.S:
            txtArama.Text = "";
            break;
        }
      else if (e.KeyCode == Keys.F3)
        txtArama.Text = "";
      else
      {
        switch (e.KeyCode)
        {
          case Keys.Down:
            e.Handled = true;
            gvUrunListesi.MoveNext();

            break;
          case Keys.Up:
            e.Handled = true;
            gvUrunListesi.MovePrev();
            break;
          //case Keys.Escape :

        }
      }
      // logo moduna geçtiğinde ilk yazılan karakteri txtArama kutusuna yazmıyor yazsın diye

    }

    private void btnAyarlar_Click(object sender, EventArgs e)
    {

    }

    private void frmAnaForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      ((frmAnaFormParametre)Application.OpenForms["frmAnaFormParametre"]).Close();
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      EkranaLogoGetir(true);
    }

    void EkranaLogoGetir(bool True_False)
    {
      pnlKisayolListesi.Visible = !True_False;
      splitContainerControl1.Panel1.Visible = !True_False;


      if (True_False == true)
        splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
      else
        splitContainerControl1.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;

      pictureEdit2.Visible = True_False;
      pictureEdit2.Dock = DockStyle.Fill;
    }

    private void txtArama_TextChanged(object sender, EventArgs e)
    {
      StokListeyiYukle();
    }

  }
}

