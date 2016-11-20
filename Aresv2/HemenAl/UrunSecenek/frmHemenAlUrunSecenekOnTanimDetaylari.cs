using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2.HemenAl.UrunSecenek
{
  public partial class frmHemenAlUrunSecenekOnTanimDetaylari : DevExpress.XtraEditors.XtraForm
  {
    public frmHemenAlUrunSecenekOnTanimDetaylari(int _HemenAlUrunSecenekOnTanimID)
    {
      HemenAlUrunSecenekOnTanimID = _HemenAlUrunSecenekOnTanimID;
      InitializeComponent();
    }
    int HemenAlUrunSecenekOnTanimID = -1;


    clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanimlari Ontanimlar;
    clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanimDetaylari OnTanimDetaylari;

    SqlTransaction TrGenel;

    private void frmHemenAlUrunSecenekOnTanimDetaylari_Load(object sender, EventArgs e)
    {
      try
      {
        TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

        Ontanimlar = new clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanimlari(SqlConnections.GetBaglanti(), TrGenel, HemenAlUrunSecenekOnTanimID);


        OnTanimDetaylari = new clsTablolar.HemenAl.UrunSecenekleri.csHemenAlUrunSecenekOnTanimDetaylari();

        gcHemenAlSecenek.DataSource = OnTanimDetaylari.DetaylariGetir(SqlConnections.GetBaglanti(), TrGenel, HemenAlUrunSecenekOnTanimID);

        TrGenel.Commit();

        HemenAlUrunSecenekleriniDoldur();
        BinleHamisina();
      }
      catch (Exception)
      {
        
        throw;
      }

    }
    void BinleHamisina()
    {
      txtAdi.DataBindings.Add("EditValue", Ontanimlar, "Adi", false, DataSourceUpdateMode.OnPropertyChanged);
      txtAciklama.DataBindings.Add("EditValue", Ontanimlar, "Aciklama", false, DataSourceUpdateMode.OnPropertyChanged);
    }

        private void HemenAlUrunSecenekleriniDoldur() // bunu stoktan kopyaladım ama burada adını değiştirmen gerekiyor
    {
      //OnTanimDetaylari = new clsTablolar.HemenAl.HemenAlUrunSecenek();

      TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
      

      //gcHemenAlSecenek.DataSource = HemenAlUrunSecenekleri.dt_HemenAlUrunSecenekleri;

      repositoryItemLookUpEdit_GoruntulemeSekli.DataSource = OnTanimDetaylari.GoruntulemeSekli();
      repositoryItemLookUpEdit_GoruntulemeSekli.ValueMember = "GoruntulemeSekliKodu";
      repositoryItemLookUpEdit_GoruntulemeSekli.DisplayMember = "GoruntulemeSekliAdi";

      repositoryItemLookUpEdit_SecenekAktif.DataSource = OnTanimDetaylari.SecenekAktif();
      repositoryItemLookUpEdit_SecenekAktif.ValueMember = "SecenekAktifKodu";
      repositoryItemLookUpEdit_SecenekAktif.DisplayMember = "SecenekAktifAdi";

      repositoryItemLookUpEdit_SeciliGelsin.DataSource = OnTanimDetaylari.SeciliGelsin();
      repositoryItemLookUpEdit_SeciliGelsin.ValueMember = "SeciliGelsinKodu";
      repositoryItemLookUpEdit_SeciliGelsin.DisplayMember = "SeciliGelsinAdi";

      repositoryItemLookUpEdit_SecimZorunlu.DataSource = OnTanimDetaylari.SecimZorunlu();
      repositoryItemLookUpEdit_SecimZorunlu.ValueMember = "SecimZorunluKodu";
      repositoryItemLookUpEdit_SecimZorunlu.DisplayMember = "SecimZorunluAdi";

      repositoryItemLookUpEdit_StokKontrol.DataSource = OnTanimDetaylari.StokKontrol();
      repositoryItemLookUpEdit_StokKontrol.ValueMember = "StokKontrolKodu";
      repositoryItemLookUpEdit_StokKontrol.DisplayMember = "StokKontrolAdi";

      repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.DataSource = OnTanimDetaylari.UrunFiyatiYerineGecsin();
      repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.ValueMember = "UrunFiyatiYerineGecsinKodu";
      repositoryItemLookUpEdit_UrunFiyatiYerineGecsin.DisplayMember = "UrunFiyatiYerineGecsinAdi";

      repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.DataSource = OnTanimDetaylari.SatisFiyatiHesaplamaIslemi();
      repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.ValueMember = "SatisFiyatiHesaplamaIslemiKodu";
      repositoryItemLookUpEdit1_SatisFiyatiHesaplamaIslemi.DisplayMember = "SatisFiyatiHesaplamaIslemiAdi";


      TrGenel.Commit();
    }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
          TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
          
          Ontanimlar.Guncelle(SqlConnections.GetBaglanti(), TrGenel);

          OnTanimDetaylari.Guncelle(SqlConnections.GetBaglanti(), TrGenel, Ontanimlar.HemenAlUrunSecenekOnTanimID);
          TrGenel.Commit();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
          if (DialogResult.Yes == MessageBox.Show("Silerim haaa", gvHemenAlSecenek.GetFocusedRowCellValue(colHemenAlSecenekSatirSecenek).ToString() + "\nSilinecek ?", MessageBoxButtons.YesNo))
          {
            gvHemenAlSecenek.DeleteSelectedRows();
          }

        }
  }
}