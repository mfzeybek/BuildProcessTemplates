using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Xml;
using System.Text;


namespace AresUrunTanitim
{
  public partial class frmAnaFormParametre : DevExpress.XtraEditors.XtraForm
  {
    public frmAnaFormParametre()
    {
      InitializeComponent();
    }

    SqlConnections asd = new SqlConnections();
    SqlConnections Turettim = new SqlConnections();
    SqlConnection BaglantiAres = new SqlConnection();
    SqlConnection BaglantiAresUT = new SqlConnection();

    private void frmAnaFormParametre_Load(object sender, EventArgs e)
    {
      XmlOku();


      BaglantiAres = SqlConnections.GetAresSqlConnection();
      BaglantiAresUT = SqlConnections.GetAresUTSqlConnection();

      if (BaglantiAres.State == ConnectionState.Closed)
        BaglantiAres.Open();
      if (BaglantiAresUT.State == ConnectionState.Closed)
        BaglantiAresUT.Open();

      FiyatTanimlariniGetir();

    }

    private void XmlOku()
    {
      string strPath = Application.StartupPath + @"\AresUrunTanitim.exe.config";
      char tirnak = '"';
      if (File.Exists(strPath))
      {
        FileStream fsConfigFile = new FileStream(strPath, FileMode.Open, FileAccess.Read);
        XmlDocument xdConfigFile = new XmlDocument();
        xdConfigFile.Load(fsConfigFile);
        string strInnerXml = xdConfigFile.DocumentElement.ChildNodes.Item(1).InnerXml;
        string[] arItems = strInnerXml.Split(new string[] { "/>" }, StringSplitOptions.RemoveEmptyEntries);
        string strAresCon = "";
        string strAresUTCon = "";
        if (arItems[0].Contains("AresUrunTanitim.Properties.Settings.DBConStrAres"))
        {
          strAresUTCon = arItems[0];
          strAresCon = arItems[1];
        }
        else if (arItems[0].Contains("AresUrunTanitim.Properties.Settings.DBConStrAresUT"))
        {
          strAresUTCon = arItems[1];
          strAresCon = arItems[0];
        }

        string[] arDBConStrAres = strAresUTCon.Split(new char[] { tirnak }, StringSplitOptions.RemoveEmptyEntries);
        string[] arDegerlerAres = arDBConStrAres[3].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arDegerlerAres.Length; i++)
        {
          if (arDegerlerAres[i].Contains("Data Source"))
            txtAresServerNane.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
          else if (arDegerlerAres[i].Contains("Initial Catalog"))
            cmAresbDbName.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
          else if (arDegerlerAres[i].Contains("User ID"))
            txtAresUserName.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
          else if (arDegerlerAres[i].Contains("Password"))
            txtAresPassword.Text = (arDegerlerAres[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1];
        }

        string[] arDBConStrAresUT = strAresCon.Split(new char[] { tirnak }, StringSplitOptions.RemoveEmptyEntries);
        string[] arDegerlerAresUT = arDBConStrAresUT[3].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < arDegerlerAresUT.Length; i++)
        {
          if (arDegerlerAresUT[i].Contains("Data Source"))
            txtUrunTanitimServerName.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
          else if (arDegerlerAresUT[i].Contains("Initial Catalog"))
            cmUrunTanitimDbName.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
          else if (arDegerlerAresUT[i].Contains("User ID"))
            txtUrunTanitimUserName.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
          else if (arDegerlerAresUT[i].Contains("Password"))
            txtUrunTanitimPassword.Text = (arDegerlerAresUT[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries))[1].Trim();
        }

        fsConfigFile.Close();
        fsConfigFile.Dispose();
      }
    }
    private void DbYoluYaz(string ServerNameAres, string DbNameAres, string ConStrNameAres, string UserNameAres, string PasswordAres,
      string ServerNameAresUT, string DbNameAresUT, string ConStrNameAresUT, string UserNameAresUT, string PasswordAresUT)
    {
      if (ServerNameAres == "" || DbNameAres == "" || ServerNameAresUT == "" || DbNameAresUT == "") return;
      string strPath = Application.StartupPath + @"\AresUrunTanitim.exe.config";
      char tirnak = '"';

      System.Data.SqlClient.SqlConnectionStringBuilder ConnBuilderAres = new System.Data.SqlClient.SqlConnectionStringBuilder();
      System.Data.SqlClient.SqlConnectionStringBuilder ConnBuilderAresUT = new System.Data.SqlClient.SqlConnectionStringBuilder();

      ConnBuilderAres.DataSource = ServerNameAres;
      ConnBuilderAres.InitialCatalog = DbNameAres;
      if (UserNameAres == "" && PasswordAres == "")
      {
        ConnBuilderAres.IntegratedSecurity = true;
      }
      else if (UserNameAres != "" && PasswordAres != "")
      {
        ConnBuilderAres.UserID = UserNameAres;
        ConnBuilderAres.Password = PasswordAres;
        ConnBuilderAres.PersistSecurityInfo = true;
      }
      else if (UserNameAres != "" && PasswordAres == "")
      {
        ConnBuilderAres.UserID = UserNameAres;
      }

      ConnBuilderAresUT.DataSource = ServerNameAresUT;
      ConnBuilderAresUT.InitialCatalog = DbNameAresUT;
      if (UserNameAresUT == "" && PasswordAresUT == "")
      {
        ConnBuilderAresUT.IntegratedSecurity = true;
      }
      else if (UserNameAresUT != "" && PasswordAresUT != "")
      {
        ConnBuilderAresUT.UserID = UserNameAresUT;
        ConnBuilderAresUT.Password = PasswordAresUT;
        ConnBuilderAresUT.PersistSecurityInfo = true;
      }
      else if (UserNameAresUT != "" && PasswordAresUT == "")
      {
        ConnBuilderAresUT.UserID = UserNameAresUT;
      }

      string strText =
"<?xml version=" + tirnak + "1.0" + tirnak + " encoding=" + tirnak + "utf-8" + tirnak + " ?>" +
"<configuration>" +
    "<configSections>" +
    "</configSections>" +
    "<connectionStrings>" +
        "<add name=" + tirnak + "AresUrunTanitim.Properties.Settings.DBConStrAres" + tirnak + " connectionString=" + tirnak + ConnBuilderAres.ConnectionString + tirnak +
            " providerName=" + tirnak + "System.Data.SqlClient" + tirnak + " />" +
        "<add name=" + tirnak + "AresUrunTanitim.Properties.Settings.DBConStrAresUT" + tirnak + " connectionString=" + tirnak + ConnBuilderAresUT.ConnectionString + tirnak +
            " providerName=" + tirnak + "System.Data.SqlClient" + tirnak + " />" +
    "</connectionStrings>" +
"</configuration>";

      try
      {
        File.Delete(strPath);
        File.WriteAllText(strPath, strText, Encoding.UTF8);
        XtraMessageBox.Show("VERİTABANI DEĞİŞİKLİKLERİ KAYDEDİLDİ.", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      catch (Exception hata)
      {
        XtraMessageBox.Show("Hata Kodu : " + hata.Message + "\nHata Açıklama : " + hata.StackTrace, "    ", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    private void AresUTSil() // önceki vt yi siliyor
    {
      SqlTransaction Tr = SqlConnections.GetAresUTSqlConnection().BeginTransaction();

      SqlCommand cmd = new SqlCommand("USE AresUrunTanitim delete from Stok  delete from Resim", SqlConnections.GetAresUTSqlConnection(), Tr);
      cmd.ExecuteNonQuery();
      Tr.Commit();
    }

    private void btnAresStokListesiniCek_Click(object sender, EventArgs e)
    {

      if (MessageBox.Show("Seçilen Fiyat Tanımlı Stokların Aktarımı Başlayacak.\nOnaylıyor musunuz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
      if (lkpFiyatTanim.EditValue == null)
      {
        MessageBox.Show("Fiyat Tanım Seçiniz.");
        lkpFiyatTanim.Focus();
        return;
      }
      AresUTSil();

      SqlDataAdapter daAres = new SqlDataAdapter();
      DataTable dtAres = new DataTable();
      DataTable dtResim = new DataTable();


      using (daAres.SelectCommand = new SqlCommand(@"
SELECT     S.StokID, S.StokKodu, S.StokAdi, S.OzelKod1, S.OzelKod2, S.OzelKod3, S.StokGrupID, SF.Fiyat, 
dbo.StokGrup.StokGrupAdi, S.Barkod , s.Aciklama, S.RafYeriAciklama, 
isnull(Girisler.Girisler, 0) - ISNULL(Cikislar.Cikislar, 0) AS Miktar


FROM dbo.Stok AS S 
LEFT OUTER JOIN dbo.StokFiyat AS SF ON S.StokID = SF.StokID 
LEFT OUTER JOIN dbo.StokGrup ON S.StokGrupID = dbo.StokGrup.StokGrupID
  
left join
                      (select Stokhr.StokID, isnull(SUM(StokHr.Miktar),0) as Girisler from StokHr
					  where StokHr.Entegrasyon = 12 or StokHr.Entegrasyon = 2
					  group by StokHr.StokID) Girisler on  Girisler.StokID = s.StokID
					  left join
					  (select Stokhr.StokID, ISNULL(SUM(StokHr.Miktar), 0) as Cikislar from StokHr
				      where StokHr.Entegrasyon = 1
				      group by StokHr.StokID) Cikislar on Cikislar.StokID = s.StokID


  WHERE     SF.FiyatTanimID = 2 and s.UrunTanitimdaGoster = 'True'", BaglantiAres))
      {
        daAres.SelectCommand.Parameters.Add("@FiyatTanimID", SqlDbType.Int).Value = lkpFiyatTanim.EditValue.ToString();
        daAres.Fill(dtAres);
      }

      SqlTransaction trAresUT = BaglantiAresUT.BeginTransaction();
      try
      {

        foreach (DataRow row in dtAres.AsEnumerable())
        {

          using (SqlCommand cmd = new SqlCommand(@"Insert Into Stok(StokID, StokKodu, StokAdi,Aciklama, StokGrubu, OzelKod1, OzelKod2, OzelKod3, Barkod, Adet, SlayttaGosterilsin, RafYeriAciklama, Fiyati )
Values(@StokID, @StokKodu, @StokAdi,@Aciklama, @StokGrubu, @OzelKod1, @OzelKod2, @OzelKod3, @Barkod, @Adet, @SlayttaGosterilsin, @RafYeriAciklama, @Fiyati )", BaglantiAresUT, trAresUT))
          {
            cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"];
            cmd.Parameters.Add("@StokKodu", SqlDbType.NVarChar).Value = row["StokKodu"].ToString();
            cmd.Parameters.Add("@StokAdi", SqlDbType.NVarChar).Value = row["StokAdi"].ToString();
            cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = row["Aciklama"].ToString();
            cmd.Parameters.Add("@StokGrubu", SqlDbType.NVarChar).Value = row["StokGrupAdi"].ToString();
            cmd.Parameters.Add("@OzelKod1", SqlDbType.NVarChar).Value = row["OzelKod1"].ToString();
            cmd.Parameters.Add("@OzelKod2", SqlDbType.NVarChar).Value = row["OzelKod2"].ToString();
            cmd.Parameters.Add("@OzelKod3", SqlDbType.NVarChar).Value = row["OzelKod3"].ToString();
            cmd.Parameters.Add("@Barkod", SqlDbType.NVarChar).Value = row["Barkod"].ToString();
            cmd.Parameters.Add("@Adet", SqlDbType.NVarChar).Value =  row["Miktar"].ToString();
            cmd.Parameters.Add("@SlayttaGosterilsin", SqlDbType.NVarChar).Value = true;
            cmd.Parameters.Add("@RafYeriAciklama", SqlDbType.NVarChar).Value = row["RafYeriAciklama"];
            cmd.Parameters.Add("@Fiyati", SqlDbType.Decimal).Value = row["Fiyat"];

            cmd.ExecuteNonQuery();

          }
          using (SqlDataAdapter daResim = new SqlDataAdapter("Select StokResimID, StokID,Resim,ResimAciklama,Varsayilan From StokResim where StokID=@StokID", BaglantiAres))
          {
            daResim.SelectCommand.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"].ToString();
            dtResim = new DataTable();
            daResim.Fill(dtResim);
          }



          foreach (DataRow rowResim in dtResim.AsEnumerable())
          {
            using (SqlCommand cmd = new SqlCommand(@"Insert Into Resim(ResimID,StokID,Resim,Aciklama,Varsayilan) values(@ResimID,@StokID,@Resim,@Aciklama,@Varsayilan)", BaglantiAresUT, trAresUT))
            {
              cmd.Parameters.Add("@ResimID", SqlDbType.Int).Value = rowResim["StokResimID"];
              cmd.Parameters.Add("@StokID", SqlDbType.Int).Value = rowResim["StokID"];
              cmd.Parameters.Add("@Resim", SqlDbType.VarBinary).Value = rowResim["Resim"];
              cmd.Parameters.Add("@Aciklama", SqlDbType.NVarChar).Value = rowResim["ResimAciklama"];
              cmd.Parameters.Add("@Varsayilan", SqlDbType.Bit).Value = rowResim["Varsayilan"];

              cmd.ExecuteNonQuery();
            }
          }
        }
        trAresUT.Commit();
      }
      catch (Exception hata)
      {
        trAresUT.Rollback();
        MessageBox.Show(hata.Message);
      }
    }

    private void FiyatTanimlariniGetir()
    {
      #region FİYAT TANIMLARI GETİRİLİYOR.
      using (SqlDataAdapter daFiyatTanim = new SqlDataAdapter("use ARES SELECT FiyatTanimID, FiyatTanimAdi FROM dbo.FiyatTanim", BaglantiAres))
      {
        DataTable dt = new DataTable();
        if (BaglantiAres.State == ConnectionState.Closed || BaglantiAres.State == ConnectionState.Broken)
          BaglantiAres.Open();
        daFiyatTanim.Fill(dt);

        lkpFiyatTanim.Properties.DataSource = dt;

        lkpFiyatTanim.Properties.ValueMember = "FiyatTanimID";
        lkpFiyatTanim.Properties.DisplayMember = "FiyatTanimAdi";

        lkpFiyatTanim.Properties.PopulateColumns();
      }
      #endregion
    }

    private void frmAnaFormParametre_KeyDown(object sender, KeyEventArgs e)
    {
      switch (e.KeyData)
      {
        case Keys.Escape:
          this.Close();
          break;
        case Keys.Control | Keys.A:
          btnAresStokListesiniCek_Click(null, null);
          break;
        default:
          break;
      }
    }

    private void simpleButton1_Click(object sender, EventArgs e)
    {
      frmAnaForm frm = new frmAnaForm();
      frm.Show();
      this.Hide();
    }

    private void btnBaglantiAyarlariKaydet_Click(object sender, EventArgs e)
    {
      DbYoluYaz(txtAresServerNane.Text, cmAresbDbName.Text, "DBConStrAres", txtAresUserName.Text, txtAresPassword.Text, txtUrunTanitimServerName.Text, cmUrunTanitimDbName.Text, "DBConStrAresUT", txtUrunTanitimUserName.Text, txtUrunTanitimPassword.Text);
      frmAnaFormParametre_Load(null, null);
    }

    private void txtAresServerNane_Leave(object sender, EventArgs e)
    {
      if (txtAresServerNane.Text == "") return;
      try
      {
        System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        builder.DataSource = txtAresServerNane.Text;
        builder.InitialCatalog = "master";
        builder.IntegratedSecurity = true;
        System.Data.SqlClient.SqlConnection Baglanti = new System.Data.SqlClient.SqlConnection(builder.ConnectionString);
        Baglanti.Open();
        System.Data.SqlClient.SqlCommand cmdDbNames = new System.Data.SqlClient.SqlCommand("Select name From sys.databases", Baglanti);
        using (System.Data.SqlClient.SqlDataReader drDbNames = cmdDbNames.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
          while (drDbNames.Read()) cmAresbDbName.Properties.Items.Add(drDbNames["name"].ToString());
      }
      catch (Exception) { }

    }

    private void txtUrunTanitimServerName_Leave(object sender, EventArgs e)
    {
      if (txtUrunTanitimServerName.Text == "") return;
      try
      {
        System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder();
        builder.DataSource = txtUrunTanitimServerName.Text;
        builder.InitialCatalog = "master";
        builder.IntegratedSecurity = true;
        System.Data.SqlClient.SqlConnection Baglanti = new System.Data.SqlClient.SqlConnection(builder.ConnectionString);
        Baglanti.Open();
        System.Data.SqlClient.SqlCommand cmdDbNames = new System.Data.SqlClient.SqlCommand("Select name From sys.databases", Baglanti);
        using (System.Data.SqlClient.SqlDataReader drDbNames = cmdDbNames.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
          while (drDbNames.Read()) cmUrunTanitimDbName.Properties.Items.Add(drDbNames["name"].ToString());
      }
      catch (Exception) { }
    }

    private void groupControl3_Paint(object sender, PaintEventArgs e)
    {

    }
  }
}