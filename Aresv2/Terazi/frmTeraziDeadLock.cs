using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace Aresv2.Terazi
{
    public partial class frmTeraziDeadLock : DevExpress.XtraEditors.XtraForm
    {
        public frmTeraziDeadLock()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(@"SELECT SessionID ,LockedObjectName ,Duration ,Transaction_begin_time, Locks FROM WhatIsLocked", SqlConnections.GetBaglanti());
            dt = new DataTable();
            da.Fill(dt);

            gridControl1.DataSource = dt;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void frmTeraziDeadLock_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(@"alter database current set single_user with rollback immediate;
alter database current set multi_user;", SqlConnections.GetBaglanti());

                cmd.ExecuteNonQuery();
                simpleButton1_Click(null, null);
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}