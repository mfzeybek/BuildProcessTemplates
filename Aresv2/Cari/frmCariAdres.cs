using System;
using System.Data;
using System.Data.SqlClient;

namespace Aresv2.Cari
{
  public partial class frmCariAdres : DevExpress.XtraEditors.XtraForm
  {
    public frmCariAdres()
    {
      InitializeComponent();

  
    }



    private void btnAdresKaydet_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Yes;
      Close();
    }

    private void btnAdresVazgec_Click(object sender, EventArgs e)
    {
      Close();
    }

    DataTable dtCity = new DataTable();
    DataTable dtCounty = new DataTable();

    private void frmCariAdres_Load(object sender, EventArgs e)
    {
      #region Get AddressType
      SqlDataAdapter daAddressType = new SqlDataAdapter(@"SELECT AdresTipID, AdresTip FROM dbo.AdresTip", SqlConnections.GetBaglanti());
      DataTable dtAddressType = new DataTable();
      daAddressType.Fill(dtAddressType);

      lkpAdresTip.Properties.DataSource = dtAddressType;

      lkpAdresTip.Properties.ValueMember = "AdresTipID";
      lkpAdresTip.Properties.DisplayMember = "AdresTip";

      lkpAdresTip.Properties.PopulateColumns();
      lkpAdresTip.Properties.Columns["AdresTipID"].Visible = false;
      lkpAdresTip.Properties.Columns["AdresTipID"].Caption = "Fiziksel Adres";
      lkpAdresTip.Properties.Columns["AdresTip"].Caption = "Adres Türü";
      #endregion
      #region Get Country (Ülke)
      SqlDataAdapter daCountry = new SqlDataAdapter(@"SELECT     UlkeID, UlkeAdi FROM         dbo.Ulke", SqlConnections.GetBaglanti());
      DataTable dtCountry = new DataTable();
      daCountry.Fill(dtCountry);

      lkpUlke.Properties.DataSource = dtCountry;
      lkpUlke.Properties.ValueMember = "UlkeID";
      lkpUlke.Properties.DisplayMember = "UlkeAdi";

      lkpUlke.Properties.PopulateColumns();
      lkpUlke.Properties.Columns["UlkeID"].Visible = false;
      lkpUlke.Properties.Columns["UlkeID"].Caption = "Fiziksel Adres";
      lkpUlke.Properties.Columns["UlkeAdi"].Caption = "Ülke";
      #endregion
      #region Get City (Şehir)
      SqlDataAdapter daCity = new SqlDataAdapter(@"SELECT SehirID, SehirAdi, UlkeID FROM dbo.Sehir", SqlConnections.GetBaglanti());
      DataTable dtCityTemp = new DataTable();
      daCity.Fill(dtCity);
      dtCityTemp = dtCity.Copy();

      lkpSehir.Properties.DataSource = dtCityTemp;
      lkpSehir.Properties.ValueMember = "SehirID";
      lkpSehir.Properties.DisplayMember = "SehirAdi";

      lkpSehir.Properties.PopulateColumns();
      lkpSehir.Properties.Columns["SehirID"].Visible = false;
      lkpSehir.Properties.Columns["UlkeID"].Visible = false;
      lkpSehir.Properties.Columns["SehirID"].Caption = "Fiziksel Adres";
      lkpSehir.Properties.Columns["SehirAdi"].Caption = "Şehir";
      #endregion
      #region Get County (İlçe)
      SqlDataAdapter daCounty = new SqlDataAdapter(@"SELECT   IlceID, IlceAdi, SehirID FROM dbo.Ilce", SqlConnections.GetBaglanti());
      daCounty.Fill(dtCounty);
      DataTable dtCountyTemp = dtCounty.Copy();
      lkpIlce.Properties.DataSource = dtCountyTemp;

      lkpIlce.Properties.ValueMember = "IlceID";
      lkpIlce.Properties.DisplayMember = "IlceAdi";

      lkpIlce.Properties.PopulateColumns();
      lkpIlce.Properties.Columns["IlceID"].Visible = false;
      lkpIlce.Properties.Columns["SehirID"].Visible = false;
      lkpIlce.Properties.Columns["IlceID"].Caption = "Fiziksel Adres";
      lkpIlce.Properties.Columns["IlceAdi"].Caption = "İlçe";
      #endregion
    }

    private void lkpUlke_EditValueChanged(object sender, EventArgs e)
    {

      //if (lkpUlke.EditValue.ToString() == "")
      //{
      //  (lkpSehir.Properties.DataSource as DataTable).Clear();
      //  (lkpIlce.Properties.DataSource as DataTable).Clear();
      //  return;
      //}
      //if ((dtCity.Select("[UlkeID] = " + lkpUlke.EditValue.ToString())).Length != 0)
      //  lkpSehir.Properties.DataSource = dtCity.Select("[UlkeID] = " + lkpUlke.EditValue.ToString()).CopyToDataTable();
      //else
      //{
      //  (lkpSehir.Properties.DataSource as DataTable).Clear();
      //  (lkpIlce.Properties.DataSource as DataTable).Clear();
      //}
    }

    private void lkpSehir_EditValueChanged(object sender, EventArgs e)
    {
      //if (lkpSehir.EditValue.ToString() == "")
      //{
      //  (lkpIlce.Properties.DataSource as DataTable).Clear();
      //  return;
      //}
      //if ((dtCounty.Select("[SehirID] = " + lkpSehir.EditValue.ToString())).Length != 0)
      //  lkpIlce.Properties.DataSource = dtCounty.Select("[SehirID] = " + lkpSehir.EditValue.ToString()).CopyToDataTable();
      //else
      //  (lkpIlce.Properties.DataSource as DataTable).Clear();
    }

  }
}