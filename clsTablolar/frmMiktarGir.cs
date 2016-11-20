using System;
using System.Windows.Forms;

namespace clsTablolar
{
    public partial class frmMiktarGir : DevExpress.XtraEditors.XtraForm
    {
        public frmMiktarGir(decimal Miktar)
        {
            InitializeComponent();
            _Miktar = Miktar;
        }
        public frmMiktarGir(decimal Miktar, SayiCinsi SayiiCinsii)
        {
            IstenenRakamCinsi = SayiiCinsii;
            InitializeComponent();
            _Miktar = Miktar;
        }


        public enum SayiCinsi
        {
            TamSayi,
            Ondalikli,
            Yazi,
            Saat
        }


        SayiCinsi IstenenRakamCinsi;

        public decimal _Miktar = 1;

        private void XtraForm3_Load(object sender, EventArgs e)
        {
            textEdit1.EditValue = _Miktar;
            //this.DialogResult = System.Windows.Forms.DialogResult.No;
            //labelControl1.Text = string.Empty;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (IstenenRakamCinsi == SayiCinsi.Ondalikli)
            {
                try
                {
                    Convert.ToDecimal(textEdit1.EditValue);
                }
                catch (Exception)
                {
                    MessageBox.Show("Girilen Değer Rakam Olmak Zorunda");
                    return;
                }
            }
            else if (IstenenRakamCinsi == SayiCinsi.TamSayi)
            {
                try
                {
                    Convert.ToInt32(textEdit1.EditValue);
                }
                catch (Exception)
                {
                    MessageBox.Show("Girilen Değer Tam Sayı Olmak Zorunda");
                    return;
                }
            }
            else if (IstenenRakamCinsi == SayiCinsi.Saat)
            {
                try
                {
                    if ((0 > Convert.ToInt32(textEdit1.EditValue) || Convert.ToInt32(textEdit1.EditValue) > 24))
                    {
                        MessageBox.Show("Girilen Değer 0 ile 24 Arasında Olmak Zorunda");
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Girilen Değer Tam Sayı Olmak Zorunda");
                    return;
                }
            }

            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();
        }

        private void frmMiktarGir_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                simpleButton1_Click(null, null);
            }
        }


        private void RakamButonlari_Click(object sender, EventArgs e)
        {
            /*if (textEdit1.SelectedText == textEdit1.Text) */// Yani bütün text seçili ise
            //if (textEdit1.EditValue.ToString().StartsWith("0") && textEdit1.EditValue.ToString()[1].ToString() != ",") // sıfırla başlıyorsa ve sıfırdan sonra virgül yoksa 
            //{
            //    if 
            //        textEdit1.EditValue.ToString()[1].ToString() != ","
            if (((sender as DevExpress.XtraEditors.SimpleButton).Text.ToString() != "," && textEdit1.EditValue.ToString().StartsWith("0") && !textEdit1.EditValue.ToString().Contains(",")) || (textEdit1.SelectedText == textEdit1.Text))
                textEdit1.EditValue = (sender as DevExpress.XtraEditors.SimpleButton).Text;
            else
                textEdit1.EditValue = textEdit1.EditValue.ToString() + (sender as DevExpress.XtraEditors.SimpleButton).Text;
            //}

        }

        private void btnSondanSil_Click(object sender, EventArgs e)
        {
            if (textEdit1.EditValue.ToString().Length > 1)
                textEdit1.EditValue = textEdit1.EditValue.ToString().Remove(textEdit1.EditValue.ToString().Length - 1, 1);
            else if (textEdit1.EditValue.ToString().Length == 0 || textEdit1.EditValue.ToString().Length == 1)
                textEdit1.EditValue = "0";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            textEdit1.EditValue = "0";
        }

        private void textEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.OldValue != null) // bu ne için bunu ihtimali var mı?? hiç değer yokken sanırım null verir.
            {
                if (IstenenRakamCinsi == SayiCinsi.Ondalikli)
                {
                    if (e.OldValue.ToString().Length > e.NewValue.ToString().Length) // sondan silme işlemi yapılırken
                    {
                        return;
                    }
                    if (e.OldValue.ToString() == "0" && e.NewValue.ToString() == "00") // sadece sıfır varken gene sıfıra basılırsa
                    {
                        e.Cancel = true;
                    }
                    else if (e.OldValue.ToString().Contains(",")) //içinde virgül varsa
                    {
                        if (e.NewValue.ToString()[e.NewValue.ToString().Length - 1].ToString() == ",") // son girilen karaket virgül ise
                        {
                            e.Cancel = true;
                        }
                    }
                }
                else if (IstenenRakamCinsi == SayiCinsi.Yazi)
                {

                }
            }
        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            Close();
        }



    }
}