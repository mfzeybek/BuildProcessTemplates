using System;
using System.Data.SqlClient;


namespace Aresv2.Ayarlar
{
    public class csYetkilendirmeyeGoreButonlariDuzenle : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        clsTablolar.Ayarlar.csYetkiler Yetkiler;



        SqlTransaction TrGEnel;

        public csYetkilendirmeyeGoreButonlariDuzenle()
        {
            Yetkiler = new clsTablolar.Ayarlar.csYetkiler(SqlConnections.GetBaglanti(), TrGEnel);
        }


        public csYetkilendirmeyeGoreButonlariDuzenle(DevExpress.XtraEditors.XtraForm Form)
        {

        }

        public void CariGostermeYetkisineGore(DevExpress.XtraEditors.SimpleButton Buton)
        {
            Buton.Visible = clsTablolar.Ayarlar.csYetkiler.CariKartGorme;
        }



    }
}
