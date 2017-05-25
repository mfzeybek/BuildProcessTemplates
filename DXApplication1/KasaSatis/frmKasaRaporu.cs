using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KasaSatis
{
    public partial class frmKasaRaporu : Form
    {
        public frmKasaRaporu(int PersonelID)
        {
            _PersonelID = PersonelID;
            InitializeComponent();
        }

        clsTablolar.Kasa.csKasaHareket KasaHareketi = new clsTablolar.Kasa.csKasaHareket();


        clsTablolar.Kasa.csKasaRapor Rapor = new clsTablolar.Kasa.csKasaRapor();

        SqlTransaction TrGenel;
        int _KasaID = KasaSatis.Properties.Settings.Default.KasaID;
        int _PosID = 3;//şimdilik tek pos var Onun ID si 3
        int _PersonelID = -1;

        clsTablolar.Kasa.csKasaHareketArama GiderHareketi = new clsTablolar.Kasa.csKasaHareketArama();

        private void frmKasaRaporu_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();

            Rapor.YeniAlinacakRaporBilgileriniGetir(SqlConnections.GetBaglanti(), TrGenel, _KasaID, _PosID, _PersonelID);
            GiderHareketi.SonZRaporundanSonraMi = true;
            GiderHareketi.KasaID = KasaSatis.Properties.Settings.Default.KasaID;
            GiderHareketi.Yonu = clsTablolar.Kasa.csKasaHareketArama.hareketYonu.Borc;
            gridControl1.DataSource = GiderHareketi.KasaHareketListe(SqlConnections.GetBaglanti(), TrGenel, KasaSatis.Properties.Settings.Default.KasaID);

            TrGenel.Commit();

            txtKasaBakiyesi.EditValue = Rapor.NakitBakiye;
            txtNakit.EditValue = Rapor.NakitAlacak;
            txtGiderToplami.EditValue = Rapor.NakitBorc;
            txtKasiyer.EditValue = Rapor.KasaPersonelAdi;


            // posun çıkışı olabiliyor mu bilmiyorum??
            txtKredi.EditValue = Rapor.PosAlacak;

            //TrGenel.Commit();
        }



        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Ver()
        {
            KasaHareketi.Aciklama = "Kasa Z Raporu " + memoEdit1.Text;
            KasaHareketi.Alacak = 0;
            KasaHareketi.Borc = Convert.ToDecimal(txtKasaBakiyesi.EditValue);
            //KasaHareketi.KasaHrID 

            KasaHareketi.KasaID = _KasaID;
            KasaHareketi.KaydedenPersonelID = _PersonelID;
            KasaHareketi.SilindiMi = false;

            KasaHareketi.Tarih = DateTime.Now;

            Rapor.Aciklama = memoEdit1.Text;
            Rapor.NakitAlacak = Convert.ToDecimal(txtNakit.EditValue);
            Rapor.NakitBorc = Convert.ToDecimal(txtGiderToplami.EditValue);
            Rapor.PosAlacak = Convert.ToDecimal(txtKredi.EditValue);
            Rapor.KasaPersonelID = _PersonelID;



            //Rapor.GenelToplam = 
        }

        private void btnZRaporuAl_Click(object sender, EventArgs e)
        {
            Ver();
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            KasaHareketi.HarekeKaydet(SqlConnections.GetBaglanti(), TrGenel, -1, KasaSatis.Properties.Settings.Default.KasaID, 0, (decimal)txtNakit.EditValue - (decimal)txtGiderToplami.EditValue, memoEdit1.Text, DateTime.Now, clsTablolar.Kasa.csKasaHareket.HareketTipleri.ZRaporuAlindiktanSonraCikis, _PersonelID, false);
            Rapor.RaporKaydet(SqlConnections.GetBaglanti(), TrGenel, KasaHareketi.KasaHrID);
            TrGenel.Commit();
            Yazdir();
            Close();
        }


        #region Yazdırma


        void Yazdir()
        {
            using (clsTablolar.Yazdirma.csYazdir yazdirrr = new clsTablolar.Yazdirma.csYazdir())
            {
                yazdirrr.dt_ekle("Rapor");
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "Kasiyer", txtKasiyer.Text, System.Type.GetType("System.String"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "Tarih", DateTime.Now, System.Type.GetType("System.DateTime"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "KasaBakiyesi", Convert.ToDecimal(txtKasaBakiyesi.EditValue), System.Type.GetType("System.Decimal"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "GiderToplami", Convert.ToDecimal(txtGiderToplami.EditValue), System.Type.GetType("System.Decimal"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "NakitToplami", Convert.ToDecimal(txtNakit.EditValue), System.Type.GetType("System.Decimal"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "KrediToplami", Convert.ToDecimal(txtKredi.EditValue), System.Type.GetType("System.Decimal"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "GenelToplam", Convert.ToDecimal(txtToplam.EditValue), System.Type.GetType("System.Decimal"));
                yazdirrr.dtAlanEkleVeriEkle("Rapor", "Aciklama", memoEdit1.Text, System.Type.GetType("System.String"));

                yazdirrr.dt_ekle("Giderler");
                yazdirrr.dt_yeAlanEkle("Giderler", "Aciklama", System.Type.GetType("System.String"));
                yazdirrr.dt_yeAlanEkle("Giderler", "Tutar", System.Type.GetType("System.Decimal"));

                for (int i = 0; i < gridView1.RowCount; i++)
                {
                    yazdirrr.DtyaYeniSatirEkle_VeriEkle("Giderler", "Aciklama", gridView1.GetRowCellValue(i, colAciklama));
                    yazdirrr.DtyaYeniSatirEkle_VeriEkle("Giderler", "Tutar", gridView1.GetRowCellValue(i, colBorc));
                }

                yazdirrr.Yazdirr(Application.StartupPath + "\\Raporlar\\KasaRaporu.repx", clsTablolar.Yazdirma.csYazdir.Nasil.Yazdir, KasaSatis.Properties.Settings.Default.VarsayilanYaziciAdi);
            }
            this.BringToFront();
            this.Focus();
        }

        #endregion

        private void memoEdit1_Click(object sender, EventArgs e)
        {
            using (clsTablolar.TeraziSatisClaslari.frmYaziGirisi frm = new clsTablolar.TeraziSatisClaslari.frmYaziGirisi())
            {
                frm.labelControl1.Text = "Açıklama";
                frm.memoEdit1.EditValue = memoEdit1.EditValue;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    memoEdit1.EditValue = frm.memoEdit1.EditValue;
                }
            }
        }
    }
}
