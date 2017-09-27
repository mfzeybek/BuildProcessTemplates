using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Aresv2
{
    public partial class ucStokGruplari : UserControl
    {
        public ucStokGruplari()
        {
            InitializeComponent();
        }


        public clsTablolar.Stok.csStokGrupV2 YeniGruplama { get; set; }
        public event EventHandler VeriDegisti;
        SqlTransaction trgenel;
        public List<clsTablolar.Stok.csStokGrubuField> AhandaBuradakiler { get; set; }


        protected void VerilerDegisti(object sender, EventArgs e)
        {
            //bubble the event up to the parent
            if (this.VeriDegisti != null)
                this.VeriDegisti(this, e);
        }
        private void btnGrupSec_Click(object sender, EventArgs e)
        {
            try
            {
                using (Stok.frmStokGruplari frm = new Stok.frmStokGruplari(Stok.frmStokGruplari.NasilAcsin.AramaIcin))
                {
                    if (YeniGruplama == null)
                    {
                        YeniGruplama = new clsTablolar.Stok.csStokGrupV2();
                        trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                        YeniGruplama.Getir(SqlConnections.GetBaglanti(), trgenel, -1);
                        trgenel.Commit();
                        listBoxControl1.DataSource = YeniGruplama.dt;
                    }

                    if (YeniGruplama.dt.Rows.Count != 0)
                    {
                        frm.SeciliStokGruplari = new List<clsTablolar.Stok.csStokGrubuField>();

                        foreach (var item in YeniGruplama.dt.AsEnumerable()) // bu listedekileri veriyorum diğer tarafta işaretliyor
                        {
                            if (item.RowState != DataRowState.Deleted)
                                frm.SeciliStokGruplari.Add(new clsTablolar.Stok.csStokGrubuField() { StokGrupID = (int)item["StokGrupID"] });
                        }
                    }

                    if (frm.ShowDialog() == DialogResult.Yes)

                    //if (YeniGruplama == null)
                    //    listBoxControl1.DataSource = frm.SeciliStokGruplari;
                    {
                        foreach (var item in frm.SeciliStokGruplari)
                        {
                            if (YeniGruplama.dt.Rows.Find(item.StokGrupID) == null)
                            {
                                DataRow dr = YeniGruplama.dt.NewRow();

                                dr["ID"] = -1;
                                dr["StokGrupID"] = item.StokGrupID;
                                dr["StokGrupAdi"] = item.StokGrupAdi;
                                YeniGruplama.dt.Rows.Add(dr);
                                VerilerDegisti(null, null);
                                //ButonlariAktifPasifYap(true);
                            }
                        }
                        AhandaBuradakiler = frm.SeciliStokGruplari;
                    }
                }
            }
            catch (Exception EX)
            {
                throw EX;
            }

        }
        private void btnGrupSil_Click(object sender, EventArgs e)
        {
            try
            {
                if (listBoxControl1.ItemCount != 0)
                {
                    AhandaBuradakiler.RemoveAt(listBoxControl1.SelectedIndex); // bu daha önce olması lazzım
                    YeniGruplama.dt.Rows.Find(listBoxControl1.SelectedValue).Delete();
                    listBoxControl1.GetDisplayItemValue(listBoxControl1.SelectedIndex);
                    VerilerDegisti(null, null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void ucStokGruplari_Paint(object sender, PaintEventArgs e)
        {
            //YeniGruplama = (clsTablolar.Stok.csStokGrupV2)listBoxControl1.DataSource;
        }
    }
}
