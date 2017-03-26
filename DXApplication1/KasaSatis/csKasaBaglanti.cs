using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tremol;

namespace KasaSatis
{
    public class csKasaBaglanti : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public BmsDll4Delphi.BmsDllForDelphi dll = new BmsDll4Delphi.BmsDllForDelphi();

        DevExpress.XtraEditors.LabelControl BaglantiLabeli;
        

        public csKasaBaglanti(DevExpress.XtraEditors.LabelControl BaglantiLabeli)
        {
            //this.BaglantiLabeli = BaglantiLabeli;
            //DevExpress.XtraWaitForm.WaitForm frm = new DevExpress.XtraWaitForm.WaitForm();
            //frm.ShowDialog();
        }

        public void Baglan()
        {
            try
            {
                //cbFonts.DataSource = Enum.GetValues(typeof(FP.Font));
                //cbFontStyle.DataSource = Enum.GetValues(typeof(FP.FontStyle));


                //dll.getDemoSDKVersionCSharp();
                //dll.getDemoSDKVersion();
                //dll.getDemoSDKVersionCSharp();

                //dll.getStatusLastException();

                dll.setgmp(true);
                dll.setgmp_force(true);
                dll.connect();

                while (true)
                {
                    if (dll.checkConnectGMP3Coupling())
                    {
                        BaglantiLabeli.Text = "Baglandi";
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
