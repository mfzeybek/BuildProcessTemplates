using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid;

namespace Aresv2.Stok
{
  public partial class frmAmbarTransfer : DevExpress.XtraEditors.XtraForm
  {
    SqlConnection Baglanti = SqlConnections.GetBaglanti();
    SqlDataAdapter daMain = new SqlDataAdapter();
    DataTable dtMain = new DataTable();
    int StficheRef = 0;
    SqlTransaction trGenel;
    public enum FormOpenEnum { Edit, New }
    FormOpenEnum _FormOpenEnum = new FormOpenEnum();
    /// <summary>
    /// STOK FİŞLERİ
    /// Ambar fişi, giriş çıkış fişleri ve irsaliyele kayıtlarının başlık bilgileri StokFis tablosunda tutulmaktadır. 
    /// Stok hareketlerine ulaşmak için StokFisDetay tablosunun okunması gerekmektedir
    /// </summary>
    /// <param name="StokFisID"></param>
    /// <param name="formOpenEnum"></param>
    public frmAmbarTransfer(int StokFisID, FormOpenEnum formOpenEnum)
    {
      _FormOpenEnum = formOpenEnum;
      StficheRef = StokFisID;
      InitializeComponent();
    }
    private void frmAmbarTransfer_Load(object sender, EventArgs e)
    {
      try
      {
        InitData();
        GridArayuzIslemleri(enGridArayuzIslemleri.Get);
      }
      catch (Exception ex) { MessageBox.Show(ex.Message); }
    }
    private void satırEkleToolStripMenuItem_Click(object sender, EventArgs e)
    {
      //dtMain.Rows.Add(new object[] { DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value, DBNull.Value });

      frmStokListesi StokArama = new frmStokListesi(true);
      StokArama.Stok_Sec = StokEkle;
      StokArama.ShowDialog();
    }
    private void satırSilToolStripMenuItem_Click(object sender, EventArgs e)
    {
      if (gvMain.FocusedRowHandle < 0) return;
      int logicalref = 0;
      int.TryParse(gvMain.GetFocusedRowCellValue("StokFisDetayID").ToString(), out logicalref);
      if (logicalref != 0)
      {
        using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFisDetay where StokFisID=@StokFisID AND StokID=@StokID AND GirisCikis=@GirisCikis", Baglanti))
        {
          cmdDelete.Parameters.Add("@StokFisID", SqlDbType.Int).Value = gvMain.GetFocusedRowCellValue("StokFisID").ToString();
          cmdDelete.Parameters.Add("@StokID", SqlDbType.Int).Value = gvMain.GetFocusedRowCellValue("StokID").ToString();
          cmdDelete.Parameters.Add("@GirisCikis", SqlDbType.Int).Value = 1;
          cmdDelete.ExecuteNonQuery();
        }
        using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFisDetay where StokFisID=@StokFisID AND StokID=@StokID AND GirisCikis=@GirisCikis", Baglanti))
        {
          cmdDelete.Parameters.Add("@StokFisID", SqlDbType.Int).Value = gvMain.GetFocusedRowCellValue("StokFisID").ToString();
          cmdDelete.Parameters.Add("@StokID", SqlDbType.Int).Value = gvMain.GetFocusedRowCellValue("StokID").ToString();
          cmdDelete.Parameters.Add("@GirisCikis", SqlDbType.Int).Value = 0;
          cmdDelete.ExecuteNonQuery();
        }
      }
      gvMain.DeleteRow(gvMain.FocusedRowHandle);
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
      /* StokFis Tablosundaki
       * FisTuru = 25:Ambar Fişi, 
       * GirisCikis = 1 : Giriş,  2 : Ambar,  3 : Çıkış, 
       * ModulNo = 3: Ambar Transfer Fişi
       ***************************
       * FisTuru = 25 : Ambar fişi, 
       * ModulNo =
       * GirisCikis = 0 : Çıkış, 1 : Giriş
       */
      int SiraNo = 0;
      switch (_FormOpenEnum)
      {
        case FormOpenEnum.Edit:
          #region Stok Fiş
          using (SqlCommand cmdMaster = new SqlCommand("Update StokFis Set StokFisNo=@StokFisNo, FisTarihi=@FisTarihi, CikisAmbarID=@CikisAmbarID, GirisAmbarID=@GirisAmbarID Where StokFisID=@StokFisID", Baglanti))
          {
            cmdMaster.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
            cmdMaster.Parameters.Add("@StokFisNo", SqlDbType.NVarChar).Value = txtFicheNo.Text;
            cmdMaster.Parameters.Add("@FisTarihi", SqlDbType.DateTime).Value = deTarih.DateTime.ToShortDateString();
            cmdMaster.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpCikisAmbar.EditValue;
            cmdMaster.Parameters.Add("@GirisAmbarID", SqlDbType.Int).Value = lkpGirisAmbar.EditValue;
            cmdMaster.ExecuteNonQuery();
          }
          #endregion
          #region Stok Fiş Detay
          System.Collections.Generic.List<int> Details = new System.Collections.Generic.List<int>();
          using (SqlCommand cmdSelect = new SqlCommand("Select StokFisDetayID From StokFisDetay Where StokFisID=@StokFisID", Baglanti))
          {
            cmdSelect.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
            using (SqlDataReader dr = cmdSelect.ExecuteReader())
              while (dr.Read()) Details.Add(Convert.ToInt32(dr["StokFisDetayID"].ToString()));
          }
          foreach (Int32 row in Details)
          {
            using (SqlCommand cmdDelete = new SqlCommand("Delete From StokFisDetay where StokFisDetayID=@StokFisDetayID", Baglanti))
            {
              cmdDelete.Parameters.Add("@StokFisDetayID", SqlDbType.Int).Value = row;
              cmdDelete.ExecuteNonQuery();
            }
          }
          foreach (DataRow row in dtMain.AsEnumerable())
          {
            using (SqlCommand cmdDetail = new SqlCommand("INSERT INTO StokFisDetay VALUES(25,1,0,@StokID,@StokFisID,@SatirNo,@Miktar,@CikisAmbarID)", Baglanti))
            {
              SiraNo++;
              cmdDetail.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"].ToString();
              cmdDetail.Parameters.Add("@SatirNo", SqlDbType.Int).Value = SiraNo;
              cmdDetail.Parameters.Add("@Miktar", SqlDbType.Int).Value = row["Miktar"].ToString();
              cmdDetail.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpCikisAmbar.EditValue;
              cmdDetail.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
              cmdDetail.ExecuteNonQuery();
            }
            using (SqlCommand cmdDetail = new SqlCommand("INSERT INTO StokFisDetay VALUES(25,1,1,@StokID,@StokFisID,@SatirNo,@Miktar,@CikisAmbarID)  SET @ID = SCOPE_IDENTITY()", Baglanti))
            {
              SiraNo++;
              cmdDetail.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"].ToString();
              cmdDetail.Parameters.Add("@SatirNo", SqlDbType.Int).Value = SiraNo;
              cmdDetail.Parameters.Add("@Miktar", SqlDbType.Int).Value = row["Miktar"].ToString();
              cmdDetail.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpGirisAmbar.EditValue;
              cmdDetail.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
              cmdDetail.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
              cmdDetail.ExecuteNonQuery();
              row["StokFisDetayID"] = cmdDetail.Parameters["@ID"].Value.ToString();
            }
          }
          #endregion
          break;
        case FormOpenEnum.New:
          #region Stok Fiş
          using (SqlCommand cmdMaster = new SqlCommand(
@"INSERT INTO StokFis( StokFisNo, FisTarihi, FisTuru, GirisCikis, ModulNo, CikisAmbarID, GirisAmbarID) 
    VALUES(@StokFisNo,@FisTarihi,25,1,3,@CikisAmbarID,@GirisAmbarID) SET @ID = SCOPE_IDENTITY()", Baglanti))
          {
            cmdMaster.Parameters.Add("@StokFisNo", SqlDbType.NVarChar).Value = txtFicheNo.Text;
            cmdMaster.Parameters.Add("@FisTarihi", SqlDbType.DateTime).Value = deTarih.DateTime.ToShortDateString();
            cmdMaster.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpCikisAmbar.EditValue;
            cmdMaster.Parameters.Add("@GirisAmbarID", SqlDbType.Int).Value = lkpGirisAmbar.EditValue;
            cmdMaster.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmdMaster.ExecuteNonQuery();
            StficheRef = Convert.ToInt32(cmdMaster.Parameters["@ID"].Value.ToString());
            _FormOpenEnum = FormOpenEnum.Edit;
          }
          #endregion
          #region Stok Fiş Detay
          foreach (DataRow row in dtMain.AsEnumerable())
          {
            using (SqlCommand cmdDetail = new SqlCommand(
@"INSERT INTO StokFisDetay(FisTuru, ModulNo, GirisCikis, StokID, StokFisID, SatirNo, Miktar, CikisAmbarID)
VALUES(25,1,0,@StokID,@StokFisID,@SatirNo,@Miktar,@CikisAmbarID)", Baglanti))
            {
              SiraNo++;
              cmdDetail.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"].ToString();
              cmdDetail.Parameters.Add("@SatirNo", SqlDbType.Int).Value = SiraNo;
              cmdDetail.Parameters.Add("@Miktar", SqlDbType.Int).Value = row["Miktar"].ToString();
              cmdDetail.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpCikisAmbar.EditValue;
              cmdDetail.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
              cmdDetail.ExecuteNonQuery();
            }
            using (SqlCommand cmdDetail = new SqlCommand(
@"INSERT INTO StokFisDetay(FisTuru, ModulNo, GirisCikis, StokID, StokFisID, SatirNo, Miktar, CikisAmbarID)
VALUES(25,1,1,@StokID,@StokFisID,@SatirNo,@Miktar,@CikisAmbarID)  SET @ID = SCOPE_IDENTITY()", Baglanti))
            {
              SiraNo++;
              cmdDetail.Parameters.Add("@StokID", SqlDbType.Int).Value = row["StokID"].ToString();
              cmdDetail.Parameters.Add("@SatirNo", SqlDbType.Int).Value = SiraNo;
              cmdDetail.Parameters.Add("@Miktar", SqlDbType.Int).Value = row["Miktar"].ToString();
              cmdDetail.Parameters.Add("@CikisAmbarID", SqlDbType.Int).Value = lkpGirisAmbar.EditValue;
              cmdDetail.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
              cmdDetail.Parameters.Add("@ID", SqlDbType.Int).Direction = ParameterDirection.Output;
              cmdDetail.ExecuteNonQuery();
              row["StokFisDetayID"] = cmdDetail.Parameters["@ID"].Value.ToString();
            }
          }
          #endregion
          break;
        default:
          break;
      }
    }
    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private void btnStok_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {

    }
    private void InitData()
    {
      #region Ambarlar
      DataTable dtAmbar = new DataTable();
      using (SqlCommand cmdAmbar = new SqlCommand("Select DepoID,DepoAdi From Depo", Baglanti))
      {
        using (SqlDataReader drAmbar = cmdAmbar.ExecuteReader())
        {
          dtAmbar.Load(drAmbar);
        }
      }
      lkpGirisAmbar.Properties.DataSource = dtAmbar;
      lkpGirisAmbar.Properties.PopulateColumns();
      lkpGirisAmbar.Properties.Columns["DepoID"].Visible = false;
      lkpGirisAmbar.Properties.Columns["DepoAdi"].Caption = "Depo Adı";
      lkpGirisAmbar.Properties.ValueMember = "DepoID";
      lkpGirisAmbar.Properties.DisplayMember = "DepoAdi";
      lkpGirisAmbar.EditValue = 1;

      lkpCikisAmbar.Properties.DataSource = dtAmbar;
      lkpCikisAmbar.Properties.PopulateColumns();
      lkpCikisAmbar.Properties.Columns["DepoID"].Visible = false;
      lkpCikisAmbar.Properties.Columns["DepoAdi"].Caption = "Depo Adı";
      lkpCikisAmbar.Properties.ValueMember = "DepoID";
      lkpCikisAmbar.Properties.DisplayMember = "DepoAdi";
      lkpCikisAmbar.EditValue = 2;
      #endregion
      using (SqlCommand cmdStfiche = new SqlCommand("Select StokFisNo,FisTarihi,CikisAmbarID,GirisAmbarID From StokFis Where StokFisID=@StokFisID", Baglanti))
      {
        cmdStfiche.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
        using (SqlDataReader drStfiche = cmdStfiche.ExecuteReader())
        {
          if (drStfiche.Read())
          {
            txtFicheNo.Text = drStfiche["StokFisNo"].ToString();
            deTarih.DateTime = Convert.ToDateTime(drStfiche["FisTarihi"].ToString());
            lkpCikisAmbar.EditValue = Convert.ToInt32(drStfiche["CikisAmbarID"].ToString());
            lkpGirisAmbar.EditValue = Convert.ToInt32(drStfiche["GirisAmbarID"].ToString());
          }
        }
      }

      daMain.SelectCommand = new SqlCommand("Select STL.StokFisDetayID,STL.StokID,S.StokKodu,S.StokAdi,STL.Miktar From StokFisDetay AS STL INNER JOIN Stok AS S ON STL.StokID=S.StokID  Where STL.StokFisID=@StokFisID AND STL.GirisCikis=1 Order By STL.SatirNo", Baglanti);
      daMain.SelectCommand.Parameters.Add("@StokFisID", SqlDbType.Int).Value = StficheRef;
      daMain.Fill(dtMain);
      grdMain.DataSource = dtMain;
      gvMain.Columns["StokKodu"].ColumnEdit = btnStok;
      gvMain.Columns["StokAdi"].ColumnEdit = btnStok;
      gvMain.BestFitColumns();
    }
    clsTablolar.Stok.csStok YeniStok;
    private void StokEkle(int StokID, decimal Miktar)
    {
      try
      {
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
				YeniStok = new clsTablolar.Stok.csStok(SqlConnections.GetBaglanti(), trGenel, StokID);

        dtMain.Rows.Add(dtMain.NewRow());
        dtMain.Rows[dtMain.Rows.Count - 1]["StokID"] = YeniStok.StokID;
        dtMain.Rows[dtMain.Rows.Count - 1]["StokAdi"] = YeniStok.StokAdi;
        dtMain.Rows[dtMain.Rows.Count - 1]["Miktar"] = Miktar;
        trGenel.Commit();
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    private void frmAmbarTransfer_FormClosed(object sender, FormClosedEventArgs e)
    {
      try
      {
        GridArayuzIslemleri(enGridArayuzIslemleri.Set);
      }
      catch (Exception hata)
      {
        frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
        frmHataBildir.ShowDialog();
      }
    }
    #region Gird Arayüz İşlemleri
    enum enGridArayuzIslemleri { Set, Get };
    void GridArayuzIslemleri(enGridArayuzIslemleri islem)
    {
      try
      {
        trGenel = SqlConnections.GetBaglanti().BeginTransaction();
        FormdakiGridleriBul(this, islem);
        trGenel.Commit();
      }
      catch (Exception hata)
      {
        trGenel.Rollback();
        throw new Exception("Hata Kodu : " + hata.Message + "\n\nHata Detay : " + hata.StackTrace);
      }
    }
    private void FormdakiGridleriBul(Control nesne, enGridArayuzIslemleri islem)
    {
      if (nesne is DevExpress.XtraGrid.GridControl)
      {
        if (islem == enGridArayuzIslemleri.Set)
          GridArayuzleriKaydet(nesne);
        else
          GridArayuzleriYukle(nesne);
      }

      foreach (Control altnesne in nesne.Controls)
        FormdakiGridleriBul(altnesne, islem);
    }
    void GridArayuzleriKaydet(Control ctrl)
    {
      DevExpress.XtraGrid.GridControl gc = new GridControl();
      gc = ctrl as DevExpress.XtraGrid.GridControl;
      DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

      string Layout = "";
      using (var ms = new MemoryStream())
      {
        gv.SaveLayoutToStream(ms);
        ms.Position = 0;
        using (var reader = new StreamReader(ms))
          Layout = reader.ReadToEnd();
      }
      cs.csGridLayout.InsertLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, Layout, SqlConnections.GetBaglanti(), trGenel);
    }
    void GridArayuzleriYukle(Control ctrl)
    {
      DevExpress.XtraGrid.GridControl gc = new GridControl();
      gc = ctrl as DevExpress.XtraGrid.GridControl;
      DevExpress.XtraGrid.Views.Grid.GridView gv = (DevExpress.XtraGrid.Views.Grid.GridView)gc.Views[0];

      MemoryStream ms = cs.csGridLayout.GetLayout(Convert.ToInt32(frmKullaniciGiris.KullaniciID), this.Name, gv.Name, SqlConnections.GetBaglanti(), trGenel);
      if (ms.Length > 0)
        gv.RestoreLayoutFromStream(ms);
    }
    #endregion
  }
}