﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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



        private void frmKasaRaporu_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();


            Rapor.YeniAlinacakRaporBilgileriniGetir(SqlConnections.GetBaglanti(), TrGenel, _KasaID, _PosID, _PersonelID);

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

        private void btnZRaporuAl_Click(object sender, EventArgs e)
        {

        }

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
