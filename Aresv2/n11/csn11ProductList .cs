using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Aresv2.n11CategoryService;
using Aresv2.n11ProductService;
using System.Data;
using System.ComponentModel;

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
        int pageSizeValue = 100; // en fazla 100 adet geliyor bir seferde

        public List<ProductBasic> productList;
        public List<ProductSku> productSku;



        public void UrunlistesiniGetir()
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
            if (productList == null)
                this.productList = response.products.ToList();
            else
                productList.AddRange(response.products);


            //productList[0].stockItems.stockItem.

            if (response.pagingData.currentPage != response.pagingData.pageCount - 1) //son sayfaya kadar gidiyoruz
            {
                currentPageValue = (int)response.pagingData.currentPage + 1;
                UrunlistesiniGetir();
            }
            //return productList;
        }

        public DataSet ds;

        public void DTolustir()
        {
            ds = new DataSet();
            DataTable dt = new DataTable();

            DataTable dt2 = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("title");
            dt.Columns.Add("subtitle");
            dt.Columns.Add("displayPrice");
            dt.Columns.Add("approvalStatus");
            dt.Columns.Add("currencyAmount");
            dt.Columns.Add("currencyType");
            dt.Columns.Add("oldPrice");
            dt.Columns.Add("price");
            dt.Columns.Add("productSellerCode");
            dt.Columns.Add("saleStatus");
            //dt.Columns.Add("stockItems");

            DataColumn optionPrice = new DataColumn();
            dt2.Columns.Add("optionPrice");
            dt2.Columns.Add("quantity");
            dt2.Columns.Add("sellerStockCode");
            dt2.Columns.Add("id");
            dt2.Columns.Add("id2");




            ds.Tables.Add(dt);
            ds.Tables.Add(dt2);


            //productSku = new List<ProductSku>();
            foreach (var item in productList)
            {
                DataRow dr = dt.NewRow();
                dr["id"] = item.id;
                dr["title"] = item.title;
                dr["subtitle"] = item.subtitle;
                dr["displayPrice"] = item.displayPrice;
                dr["approvalStatus"] = item.approvalStatus;
                dr["currencyAmount"] = item.currencyAmount;
                dr["currencyType"] = item.currencyType;
                dr["oldPrice"] = item.oldPrice;
                dr["price"] = item.price;
                dr["productSellerCode"] = item.productSellerCode;
                dr["saleStatus"] = item.saleStatus;


                dt.Rows.Add(dr);

                foreach (var item2 in item.stockItems.stockItem)
                {
                    DataRow dr2 = dt2.NewRow();
                    dr2["optionPrice"] = item2.optionPrice;
                    dr2["quantity"] = item2.quantity;
                    dr2["sellerStockCode"] = item2.sellerStockCode;
                    dr2["id"] = item.id;
                    dr2["id2"] = item.stockItems.id;
                    dt2.Rows.Add(dr2);
                }

                //productSku.AddRange(item.stockItems.stockItem);
            }
            ds.Relations.Add("ahanda", dt.Columns["id"], dt2.Columns["id"]);

        }
        //public DataTable ToDataTable<T>(this IList<T> data)
        //{
        //    PropertyDescriptorCollection props =
        //        TypeDescriptor.GetProperties(typeof(T));
        //    DataTable table = new DataTable();
        //    for (int i = 0; i < props.Count; i++)
        //    {
        //        PropertyDescriptor prop = props[i];
        //        table.Columns.Add(prop.Name, prop.PropertyType);
        //    }
        //    object[] values = new object[props.Count];
        //    foreach (T item in data)
        //    {
        //        for (int i = 0; i < values.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item);
        //        }
        //        table.Rows.Add(values);
        //    }
        //    return table;
        //}

    }
}