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
    public partial class frmGiderKarti : Form
    {
        public frmGiderKarti(int KasaHrID)
        {
            this.KasaHrID = KasaHrID;
            InitializeComponent();
        }

        int KasaHrID;
        SqlTransaction TrGenel;

        clsTablolar.Kasa.csKasaHareket hareket = new clsTablolar.Kasa.csKasaHareket();

        private void frmGiderKarti_Load(object sender, EventArgs e)
        {
            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            hareket.Getir(SqlConnections.GetBaglanti(), TrGenel, KasaHrID);
            TrGenel.Commit();

            textEdit1.EditValue = hareket.Borc;
            memoEdit1.EditValue = hareket.Aciklama;
        }



        private void simpleButton1_Click(object sender, EventArgs e)
        {
            hareket.Aciklama = memoEdit1.Text;
            hareket.Borc = Convert.ToDecimal(textEdit1.EditValue);
            hareket.KasaID = KasaSatis.Properties.Settings.Default.KasaID;
            //hareket.Alacak

            TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
            hareket.HarekeKaydet(SqlConnections.GetBaglanti(), TrGenel);
            TrGenel.Commit();

            this.DialogResult = DialogResult.Yes;
            this.Close();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void textEdit1_Click(object sender, EventArgs e)
        {
            using (clsTablolar.frmMiktarGir frm = new clsTablolar.frmMiktarGir(0, clsTablolar.frmMiktarGir.SayiCinsi.Ondalikli))
            {
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    textEdit1.EditValue = frm.textEdit1.EditValue;
                }
            }
        }

        private void memoEdit1_Click(object sender, EventArgs e)
        {
            using (clsTablolar.TeraziSatisClaslari.frmYaziGirisi frm = new clsTablolar.TeraziSatisClaslari.frmYaziGirisi())
            {
                frm.labelControl1.Text = "";
                frm.memoEdit1.EditValue = memoEdit1.EditValue;
                if (frm.ShowDialog() == DialogResult.Yes)
                {
                    memoEdit1.EditValue = frm.memoEdit1.EditValue;
                }
            }
        }
    }
}