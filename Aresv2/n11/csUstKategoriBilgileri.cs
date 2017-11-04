using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aresv2.n11CategoryService;

namespace Aresv2.n11
{
    public class csUstKategoriBilgileri : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public void Getir()
        {
            try
            {
                String strAppKey = "***";
                String strAppSecret = "***";

                Authentication authentication = new Authentication();
                authentication.appKey = strAppKey;
                authentication.appSecret = strAppSecret;

                GetTopLevelCategoriesRequest request = new GetTopLevelCategoriesRequest();
                request.auth = authentication;

                CategoryServicePortService port = new CategoryServicePortService();
                GetTopLevelCategoriesResponse topTopLevelCategoriesResponse = port.GetTopLevelCategories(request);
                List<SubCategory> categoryList = topTopLevelCategoriesResponse.categoryList.ToList<SubCategory>();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
