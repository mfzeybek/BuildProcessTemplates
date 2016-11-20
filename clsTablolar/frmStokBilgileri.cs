using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace clsTablolar
{
    public partial class frmStokBilgileri : DevExpress.XtraEditors.XtraForm
    {// aha  bu gitmesin
        public frmStokBilgileri(SqlConnection Baglanti)
        {
            _Baglanti = Baglanti;
            InitializeComponent();
        }

        public delegate void dlg_StokKartiAc(int StokID);
        public dlg_StokKartiAc StokKartiAc;

        clsTablolar.TeraziSatisClaslari.csStok Stok = new clsTablolar.TeraziSatisClaslari.csStok();

        clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama BarkodtanAra = new clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama();
        SqlConnection _Baglanti;
        SqlTransaction TrGenel;

        public int StokID = -1;

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }


        clsTablolar.Stok.csStokMiktar StokMiktari = new clsTablolar.Stok.csStokMiktar();
        clsTablolar.csStokResim Foto;
        private void btnAra_Click(object sender, EventArgs e)
        {
            if (txtAramaBarkodu.Text.ToString() == "")
                return;
            try
            {
                TrGenel = _Baglanti.BeginTransaction();
                clsTablolar.TeraziSatisClaslari.csBarkodtanStokArama.StokIDMiktarBirim IdveMiktar = BarkodtanAra.StokBarkodundanStokIDVer(_Baglanti, TrGenel, txtAramaBarkodu.EditValue.ToString());
                TrGenel.Commit();
                if (IdveMiktar.StokID == -1)
                {
                    txtStokAdi.EditValue = "Ürün bulunamadı";
                    txtAramaBarkodu.EditValue = string.Empty;
                    txtBarkodu.EditValue = string.Empty;
                    txtKdvDahilFiyat.EditValue = string.Empty;
                    StokID = -1;
                    txtBarkodunMiktari.EditValue = string.Empty;
                    memoAciklama.EditValue = string.Empty;
                    txtStokMiktari.EditValue = string.Empty;
                    peStokFotografi.EditValue = DBNull.Value;
                    txtRafyeriAciklama.EditValue = string.Empty;
                }
                else
                {
                    txtBarkodu.EditValue = txtAramaBarkodu.EditValue;
                    StokGetirIDden(IdveMiktar.Miktar, IdveMiktar.StokID);
                    StokID = IdveMiktar.StokID;
                    txtAramaBarkodu.Focus();
                }
            }
            catch (Exception)
            {
                TrGenel.Rollback();
            }
        }

        public void StokGetirIDden(decimal Miktar, int StokID)
        {
            TrGenel = _Baglanti.BeginTransaction();
            Stok.GetirHamisinaAyrintili(_Baglanti, TrGenel, StokID);
            TrGenel.Commit();
            txtKdvDahilFiyat.EditValue = Stok.KdvDahilFiyat;
            txtStokAdi.EditValue = Stok.StokAdi;
            //txtStokEtiketAdi.EditValue = Stok.
            this.StokID = Stok.StokID;
            txtBarkodunMiktari.EditValue = Miktar;
            txtAramaBarkodu.EditValue = string.Empty;
            memoAciklama.EditValue = Stok.Aciklama;
            TrGenel = _Baglanti.BeginTransaction();

            txtStokMiktari.EditValue = StokMiktari.StokMiktariGetir(_Baglanti, TrGenel, StokID);
            TrGenel.Commit();
            txtRafyeriAciklama.EditValue = Stok.RafYeriAciklama;
            if (checkEdit1.Checked == true)
            {
                btnFotoğrafiniGetir_Click(null, null);
            }
            else
            {
                peStokFotografi.EditValue = DBNull.Value;
            }
        }




        private void frmStokBilgileri_Load(object sender, EventArgs e)
        {
            txtAramaBarkodu.Focus();
            txtAramaBarkodu.SelectAll();
            //Stok.GosterilecekAlanEkle(clsTablolar.TeraziSatisClaslari.csStok.StokAlanTanimlari.Aciklama);
            //Stok.GosterilecekAlanEkle(clsTablolar.TeraziSatisClaslari.csStok.StokAlanTanimlari.EtiketAdi);
            Stok.GosterilecekAlanEkle(clsTablolar.TeraziSatisClaslari.csStok.StokAlanTanimlari.Fotografi);

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmStokBilgileri_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.F3)
            {
                txtAramaBarkodu.Focus();
                txtAramaBarkodu.SelectAll();
            }
            else if (txtAramaBarkodu.ContainsFocus == false)
                if ((e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9) ||
        (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9) ||
        e.KeyCode == Keys.Decimal)
                {
                    txtAramaBarkodu.Focus();
                    txtAramaBarkodu.Select(txtAramaBarkodu.Text.Length, 0);
                    switch (e.KeyCode)
                    {
                        case Keys.NumPad0:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "0";
                            break;
                        case Keys.NumPad1:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "1";
                            break;
                        case Keys.NumPad2:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "2";
                            break;
                        case Keys.NumPad3:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "3";
                            break;
                        case Keys.NumPad4:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "4";
                            break;
                        case Keys.NumPad5:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "5";
                            break;
                        case Keys.NumPad6:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "6";
                            break;
                        case Keys.NumPad7:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "7";
                            break;
                        case Keys.NumPad8:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "8";
                            break;
                        case Keys.NumPad9:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + "9";
                            break;
                        default:
                            txtAramaBarkodu.Text = txtAramaBarkodu.Text + Convert.ToChar((int)e.KeyValue).ToString();
                            break;
                    }
                    txtAramaBarkodu.Select(txtAramaBarkodu.Text.Length, 0);

                }
        }

        private void txtBarkodu_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                btnAra_Click(null, null);
            }
        }

        private void btnFotoğrafiniGetir_Click(object sender, EventArgs e)
        {
            Foto = new clsTablolar.csStokResim(_Baglanti, TrGenel, StokID);
            peStokFotografi.EditValue = Foto.VarsayilanFoto;
        }

        private void peStokFotografi_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtKdvDahilFiyat_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (StokKartiAc != null)
                StokKartiAc(Stok.StokID);
        }
    }
}