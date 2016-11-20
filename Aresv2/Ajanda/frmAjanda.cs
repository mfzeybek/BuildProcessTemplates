using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace Aresv2.Ajanda
{
    public partial class frmAjanda : DevExpress.XtraEditors.XtraForm
    {
        public frmAjanda()
        {
            InitializeComponent();
        }

        clsTablolar.Ajanda.csAjanda ajandaa;

        SqlTransaction Trgenel;


        private void frmAjanda_Load(object sender, EventArgs e)
        {
            try
            {
                Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                ajandaa = new clsTablolar.Ajanda.csAjanda();
                ajandaa.dt_getir(SqlConnections.GetBaglanti(), Trgenel);



                schedulerStorage1.Appointments.DataSource = ajandaa.dt_Takvim;

                schedulerStorage1.Appointments.Mappings.Description = "Aciklama";
                schedulerStorage1.Appointments.Mappings.End = "EndTime";
                schedulerStorage1.Appointments.Mappings.Location = "Yer";
                schedulerStorage1.Appointments.Mappings.Start = "StartTime";
                schedulerStorage1.Appointments.Mappings.Subject = "Baslik";
                schedulerStorage1.Appointments.Mappings.Label = "Grup";
                schedulerStorage1.Appointments.Mappings.AllDay = "ButunGun";
                schedulerStorage1.Appointments.Mappings.PercentComplete = "AjandaID";

                schedulerStorage1.Appointments.Mappings.ResourceId = "";  // bu önemli sanırım Örnekte CarID olarak gözüküyor
                schedulerStorage1.Appointments.Mappings.Status = "Status";
                schedulerStorage1.Appointments.Mappings.Type = "EventType";
                schedulerStorage1.Appointments.Mappings.AppointmentId = "AjandaID";

                schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
                schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
                //schedulerStorage1.Appointments.Mappings

                ajandaa.getir_resourcesBS(SqlConnections.GetBaglanti(), Trgenel);

                this.schedulerStorage1.Resources.DataSource = ajandaa.dt_resources;
                this.schedulerStorage1.Resources.Mappings.Id = "ResourceID";
                this.schedulerStorage1.Resources.Mappings.Caption = "ResourceName";



                schedulerStorage1.Resources.DataSource = ajandaa.dt_Takvim;
                schedulerStorage1.Resources.Mappings.Id = "AjandaID";

                schedulerStorage1.AppointmentDependencies.DataSource = ajandaa.dt_Takvim;
                schedulerStorage1.AppointmentDependencies.Mappings.DependentId = "KullaniciID";
                schedulerStorage1.AppointmentDependencies.Mappings.ParentId = "Baslik";

                //dateNavigator1.TodayButton.Text = "Bugün";

                schedulerBarController1.Control.MonthView.DisplayName = "Aylık Görünüm hamısına";

                schedulerBarController1.Control.Start = DateTime.Today;
                //schedulerBarController1.Control.st = DateTime.Today.AddDays(-10);

                //schedulerStorage1.


                Trgenel.Commit();

                ajandaa.dt_Takvim.RowChanged += new DataRowChangeEventHandler(dt_Takvim_RowChanged);
                ajandaa.dt_Takvim.RowDeleting += dt_Takvim_RowDeleting;
                //dateNavigator1.TodayButton.PerformClick();
            }
            catch (Exception)
            {

                throw;
            }
        }

        void dt_Takvim_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
            ajandaa.Sil(SqlConnections.GetBaglanti(), Trgenel, e.Row);
            Trgenel.Commit();
        }
        /* Ajanda ile ilgili neler gerekli Butun işlemler için ayrı renklendirme  
      
      
         */





        void dt_Takvim_RowChanged(object sender, DataRowChangeEventArgs e)
        {
            try
            {
                Trgenel = SqlConnections.GetBaglanti().BeginTransaction();
                DataRow dr = e.Row;

                ajandaa.dt_Takvim.RowChanged -= new DataRowChangeEventHandler(dt_Takvim_RowChanged);
                e.Row["AjandaID"] = ajandaa.dt_Guncelle(SqlConnections.GetBaglanti(), Trgenel, e.Row);

                Trgenel.Commit();
                ajandaa.dt_Takvim.RowChanged += new DataRowChangeEventHandler(dt_Takvim_RowChanged);
            }
            catch (Exception hata)
            {
                Trgenel.Rollback();
                frmHataBildir frmHataBildir = new frmHataBildir(hata.Message, hata.StackTrace);
                frmHataBildir.ShowDialog();
            }
        }


        private void schedulerStorage1_AppointmentDeleting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Silinsin mi??", "Emin Misin", MessageBoxButtons.YesNo, MessageBoxIcon.Stop))
            {
                if (DialogResult.No == MessageBox.Show("Sileerimmm haaa??", "Dikkat et", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    e.Cancel = true;
            }
            else
            { e.Cancel = true; }
        }

        private void schedulerControl2_EditRecurrentAppointmentFormShowing(object sender, DevExpress.XtraScheduler.EditRecurrentAppointmentFormEventArgs e)
        {
            if (Convert.ToInt32(e.Appointment.Id) == -1)
            {
                if (e.Appointment.LabelId == 1)
                {
                    MessageBox.Show("");
                    e.Appointment.CancelUpdate();
                }
            }
        }

        private void schedulerControl2_EditAppointmentFormShowing(object sender, DevExpress.XtraScheduler.AppointmentFormEventArgs e)
        {
            if (e.Appointment.LabelId == 22) // Grubu Mülakat ise
            {
                //MessageBox.Show("");
                e.Handled = true;
                InsanKaynaklari.frmBasvuruKarti frm = new InsanKaynaklari.frmBasvuruKarti(Convert.ToInt32(e.Appointment.Id));
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }

        private void schedulerControl2_EditAppointmentDependencyFormShowing(object sender, DevExpress.XtraScheduler.AppointmentDependencyFormEventArgs e)
        {
            if (Convert.ToInt32(e.AppointmentDependency.DependentId) == -1)
            {
                //if (e..LabelId == 1)
                //{
                //  MessageBox.Show("");
                //schedulerControl2.
            }
        }

        private void schedulerControl2_Click(object sender, EventArgs e)
        {

        }

        private void schedulerStorage1_AppointmentDependenciesInserted(object sender, DevExpress.XtraScheduler.PersistentObjectsEventArgs e)
        {

        }

        private void schedulerStorage1_AppointmentDependencyInserting(object sender, DevExpress.XtraScheduler.PersistentObjectCancelEventArgs e)
        {

        }
    }

}


