using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsTablolar.n11
{
    public class csN11ApprovalStatus : IDisposable

    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        //approvalStatus Ürünün onay durumu 
        //              1:  “Active”: satışda olan ürünler (aktif)
        //              2:  “Suspended”: Beklemede olan ürünler (beklemede)
        //              3:  “Prohibited”: Yasaklı olan ürünler () bu daha gelmdi
        //              4:  (Limit dışı)

        public enum approvalStatus
        {
            Satisda = 1,
            Beklemede = 2,
            Yasakli = 3,
            LimitDisi = 4
            //              1:  “Active”: satışda olan ürünler (aktif)
            //              2:  “Suspended”: Beklemede olan ürünler (beklemede)
            //              3:  “Prohibited”: Yasaklı olan ürünler () bu daha gelmdi
            //              4:  (Limit dışı)
        }
    }
}
