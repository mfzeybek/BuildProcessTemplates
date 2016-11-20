using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace clsTablolar
{
    public class csComPorttanBarkodOku : IDisposable
    {
        public void Dispose()
        {
            sp1.Close();
            GC.SuppressFinalize(this);
        }
        SerialPort sp1;
        public void BarkoduOku()
        {
            using (sp1 = new SerialPort())
            {
                sp1.PortName = "com";
                sp1.BaudRate = 9600;
                while (true)
                {
                    try
                    {
                        if (!sp1.IsOpen)
                        {
                            sp1.Open();
                        }

                        sp1.ReadTimeout = 9999;
                        string numara = sp1.ReadLine().ToString();
                        sp1.Close();
                    }
                    catch (Exception)
                    {
                        sp1.Close();
                        //throw;
                    }
                }
            }

        }
    }
}
