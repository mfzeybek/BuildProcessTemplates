using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Aresv2.n11CategoryService;
using Aresv2.n11ProductService;

namespace Aresv2.n11
{
    public class csN11ProductList : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        n11ProductService.Authentication authentication = new n11ProductService.Authentication();

        String strAppKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962";
        String strAppSecret = "OiVekmVJRKC2wi0X";
        int currentPageValue = 0; // bu ikinci sayfa filan 
        int pageSizeValue = 0; // en fazla 100 adet geliyor bir seferde

        public List<ProductBasic> UrunlistesiniGetir()
        {
            //Authentication authentication = new Authentication();
            authentication.appKey = strAppKey;

            authentication.appSecret = strAppSecret;

            RequestPagingData requestPagingData = new RequestPagingData();
            requestPagingData.currentPage = currentPageValue;
            requestPagingData.pageSize = pageSizeValue;

            GetProductListRequest getProductListRequest = new GetProductListRequest();
            getProductListRequest.auth = authentication;
            getProductListRequest.pagingData = requestPagingData;

            n11ProductService.ProductServicePortService port = new n11ProductService.ProductServicePortService();
            GetProductListResponse response = port.GetProductList(getProductListRequest);
            List<ProductBasic> productList = response.products.ToList();

            foreach (var item in productList)
            {
                string asdasd = item.title;
            }

            return productList;
        }


    }
}