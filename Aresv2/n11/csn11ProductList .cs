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

            DataTable dtStokSecenekleri = new DataTable();

            dt.Columns.Add("id");
            dt.Columns.Add("title");
            dt.Columns.Add("subtitle");
            dt.Columns.Add("displayPrice");
            dt.Columns.Add("approvalStatus"); // bunu biz değiştiriyoruz

            //approvalStatus Ürünün onay durumu 
            //              1:  “Active”: satışda olan ürünler (aktif)
            //              2:  “Suspended”: Beklemede olan ürünler (beklemede)
            //              3:  “Prohibited”: Yasaklı olan ürünler () bu daha gelmdi
            //              4:  (Limit dışı)

            dt.Columns.Add("currencyAmount");
            dt.Columns.Add("currencyType");
            dt.Columns.Add("oldPrice");
            dt.Columns.Add("price");
            dt.Columns.Add("productSellerCode");
            dt.Columns.Add("saleStatus"); // Bu sanırım stok miktarına göre değişiyor

            //saleStatus  
            //            1: Satış Öncesi(Before_Sale)
            //            2: Satışta(On_Sale)
            //            3: Stok yok(Out of_Stock)
            //            4: Satışa kapalı(Sale_Closed)


            dt.Columns.Add("StokMiktari"); // Seçeneklerden Topluyor

            DataColumn optionPrice = new DataColumn();
            dtStokSecenekleri.Columns.Add("optionPrice");
            dtStokSecenekleri.Columns.Add("quantity");
            dtStokSecenekleri.Columns.Add("sellerStockCode");
            dtStokSecenekleri.Columns.Add("id");
            dtStokSecenekleri.Columns.Add("id2");
            dtStokSecenekleri.Columns.Add("bundle");
            dtStokSecenekleri.Columns.Add("sellerStockCode2");
            dtStokSecenekleri.Columns.Add("attributes_name");
            dtStokSecenekleri.Columns.Add("attributes_value");
            dtStokSecenekleri.Columns.Add("version");



            ds.Tables.Add(dt);
            ds.Tables.Add(dtStokSecenekleri);


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




                decimal SecenektenToplananStokMiktari = 0;


                foreach (var item2 in item.stockItems.stockItem)
                {
                    if (item2.attributes.Count() == 0)
                    {
                        break;
                    }

                    DataRow drStokSecenekleri = dtStokSecenekleri.NewRow();
                    drStokSecenekleri["optionPrice"] = item2.optionPrice;
                    drStokSecenekleri["quantity"] = item2.quantity;

                    SecenektenToplananStokMiktari += Convert.ToDecimal(item2.quantity);

                    drStokSecenekleri["sellerStockCode"] = item2.sellerStockCode;
                    drStokSecenekleri["sellerStockCode2"] = item.stockItems.productSellerCode;
                    drStokSecenekleri["id"] = item.id;
                    drStokSecenekleri["id2"] = item.stockItems.id;
                    drStokSecenekleri["bundle"] = item2.bundle;

                    if (item.productSellerCode == "S04390S")
                    {
                    }
                    if (item2.attributes.Count() == 0)
                    {
                        drStokSecenekleri["attributes_name"] = "Seçeneği Yok";
                        drStokSecenekleri["attributes_value"] = "Seçeneği Yok";
                    }
                    else
                    {

                        drStokSecenekleri["attributes_name"] = item2.attributes[0].name;
                        drStokSecenekleri["attributes_value"] = item2.attributes[0].value;
                    }
                    drStokSecenekleri["version"] = item2.version;


                    dtStokSecenekleri.Rows.Add(drStokSecenekleri);
                }

                dr["StokMiktari"] = SecenektenToplananStokMiktari;
                dt.Rows.Add(dr);


                //productSku.AddRange(item.stockItems.stockItem);
            }
            ds.Relations.Add("ahanda", dt.Columns["id"], dtStokSecenekleri.Columns["id"]);

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