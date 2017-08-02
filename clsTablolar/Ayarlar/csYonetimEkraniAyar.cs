using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace clsTablolar.Ayarlar
{
    public class csYonetimEkraniAyar : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        SqlDataAdapter da;
        DataTable dt;

        void getir()
        {
            //da = new SqlDataAdapter("select * from ")
            //da.SelectCommand


        }



    }


}
