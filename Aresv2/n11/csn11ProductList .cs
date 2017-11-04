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
            dt.Columns.Add("approvalStatus2");

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

     
                dr["approvalStatus2"] = ((clsTablolar.n11.csN11ApprovalStatus.approvalStatus)(Convert.ToInt16(item.approvalStatus))).ToString();



                dr["currencyAmount"] = item.currencyAmount;
                dr["currencyType"] = item.currencyType;
                dr["oldPrice"] = item.oldPrice;
                dr["price"] = item.price;
                dr["productSellerCode"] = item.productSellerCode;
                dr["saleStatus"] = item.saleStatus;


                if (item.stockItems.stockItem.Count() == 0)
                {
                }
                if (item.productSellerCode == "ST02131")
                {
                }

                decimal SecenektenToplananStokMiktari = 0;


                foreach (var item2 in item.stockItems.stockItem)
                {
                    if (item2.attributes.Count() == 0)
                    {
                        //break;
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

                    if (item.productSellerCode == "ST02131")
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
            }
            //ds.Relations.Add("ahanda", dt.Columns["id"], dtStokSecenekleri.Columns["id"]);




        }
        public void UrunSatisiniBaaslat(string StokKodu)
        {
            try
            {
                //String strAppKey = "***";
                //String strAppSecret = "***";
                String strSellerCode = StokKodu;

                n11ProductSellingService.Authentication authentication = new n11ProductSellingService.Authentication();
                authentication.appKey = strAppKey;
                authentication.appSecret = strAppSecret;

                n11ProductSellingService.StartSellingProductBySellerCodeRequest request = new n11ProductSellingService.StartSellingProductBySellerCodeRequest();
                request.auth = authentication;
                request.productSellerCode = strSellerCode;

                n11ProductSellingService.ProductSellingServicePortService port = new n11ProductSellingService.ProductSellingServicePortService();
                //n11ProductSellingService.startSellingProductBySellerCodeResponse response = port.StartSellingProductBySellerCode(request);// startSellingProductBySellerCode(request);
                n11ProductSellingService.StartSellingProductBySellerCodeResponse response = port.StartSellingProductBySellerCode(request);
                n11ProductSellingService.ProductBasic sampleProduct = response.product;// getProduct();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UrunSatisiniDurdur(string StokKodu)
        {
            try
            {

                String strSellerCode = StokKodu;

                n11ProductSellingService.Authentication authentication = new n11ProductSellingService.Authentication();
                authentication.appKey = strAppKey;
                authentication.appSecret = strAppSecret;

                n11ProductSellingService.StopSellingProductBySellerCodeRequest request = new n11ProductSellingService.StopSellingProductBySellerCodeRequest();
                request.auth = authentication;
                request.productSellerCode = strSellerCode;

                n11ProductSellingService.ProductSellingServicePortService port = new n11ProductSellingService.ProductSellingServicePortService();
                n11ProductSellingService.StopSellingProductBySellerCodeResponse response = port.StopSellingProductBySellerCode(request);
                n11ProductSellingService.ProductBasic sampleProduct = response.product;

                //System.out.println(sampleProduct.getId() + " has been stopped.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public void StokMiktariGuncelle(string StokKodu, int StokMikari, int versiyon)
        {
            try
            {
                //String strAppKey = "***";
                //String strAppSecret = "***";
                String strSellerStockCode = StokKodu;
                int quantityValue = StokMikari;
                long versionValue = 6;

                n11ProductStockService.Authentication authentication = new n11ProductStockService.Authentication();
                authentication.appKey = strAppKey;
                authentication.appSecret = strAppSecret;
                List<n11ProductStockService.StockItemForUpdateStockWithSellerStockCode> stockItemList = new List<n11ProductStockService.StockItemForUpdateStockWithSellerStockCode>();
                //n11ProductStockService.StockItemForUpdateStockWithSellerStockCodeList stockItemList = new StockItemForUpdateStockWithSellerStockCodeList();
                n11ProductStockService.StockItemForUpdateStockWithSellerStockCode stockItem = new n11ProductStockService.StockItemForUpdateStockWithSellerStockCode();
                stockItem.version = versionValue;
                stockItem.sellerStockCode = strSellerStockCode;
                stockItem.quantity = quantityValue.ToString();

                //stockItemList.getStockItem().add(stockItem);
                stockItemList.Add(stockItem);
                //stockItemList.getStockItem().add(stockItem);

                n11ProductStockService.UpdateStockByStockSellerCodeRequest request = new n11ProductStockService.UpdateStockByStockSellerCodeRequest();
                request.auth = authentication;
                request.stockItems = stockItemList.ToArray();

                n11ProductStockService.ProductStockServicePortService port = new n11ProductStockService.ProductStockServicePortService();
                //ProductStockServicePort port = new ProductStockServicePortService().getProductStockServicePortSoap11();
                n11ProductStockService.UpdateStockByStockSellerCodeResponse response = port.UpdateStockByStockSellerCode(request);
                //System.out.println("Update status is " + response.getResult().getStatus().getValue());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public MagazaStokKoduIleStokMiktariArttir()
        //{
        //    //String strAppKey = "***";
        //    //String strAppSecret = "***";
        //    String strSellerStockCode = "StokKod1234567";
        //    int quantityIncreaseValue = 10;
        //    long versionValue = 9;

        //    Authentication authentication = new Authentication();
        //    authentication.appKey = strAppKey;
        //    authentication.appSecret = strAppSecret;

        //    n11ProductStockService.StockItemForAddStockWithSellerStockCodeList stockList = new StockItemForAddStockWithSellerStockCodeList();
        //    StockItemForAddStockWithSellerStockCode stockItem = new StockItemForAddStockWithSellerStockCode();
        //    stockItem.setVersion(versionValue);
        //    stockItem.setQuantityToIncrease(BigInteger.valueOf(quantityIncreaseValue));
        //    stockItem.setSellerStockCode(strSellerStockCode);
        //    stockList.getStockItem().add(stockItem);

        //    IncreaseStockByStockSellerCodeRequest request = new IncreaseStockByStockSellerCodeRequest();
        //    request.setAuth(authentication);
        //    request.setStockItems(stockList);

        //    ProductStockServicePort port = new ProductStockServicePortService().getProductStockServicePortSoap11();
        //    IncreaseStockByStockSellerCodeResponse response = port.increaseStockByStockSellerCode(request);

        //    System.out.println("Increasing status is " + response.getResult().getStatus().getValue());



        //}




        public void StokFiyatiGuncelle(string StokKoud, decimal Fiyati)
        {
            try
            {
                //String strAppKey = "***";
                //String strAppSecret = "***";
                String strSellerCode = StokKoud;
                String strSellerStockCode = StokKoud;
                int currencyTypeValue = 1;
                decimal optionalPriceValue = Fiyati;
                decimal priceValue = Fiyati;

                n11ProductService.Authentication authentication = new Authentication();
                authentication.appKey = strAppKey;
                authentication.appSecret = strAppSecret;

                List<n11ProductService.ProductSkuBasicRequest> productSkuBasicRequestItemList = new List<ProductSkuBasicRequest>();
                n11ProductService.ProductSkuRequest productSkuRequest = new ProductSkuRequest();
                productSkuRequest.sellerStockCode = strSellerStockCode;
                productSkuRequest.optionPrice = Convert.ToDecimal(optionalPriceValue);

                UpdateProductPriceBySellerCodeRequest request = new UpdateProductPriceBySellerCodeRequest();
                request.auth = authentication;
                request.currencyType = currencyTypeValue.ToString();

                request.stockItems = productSkuBasicRequestItemList.ToArray();


                request.price = Convert.ToDecimal(priceValue);
                request.productSellerCode = strSellerCode;

                //n11ProductService.ProductServicePortService  port = new ProductServicePortService().getProductServicePortSoap11();
                n11ProductService.ProductServicePortService port = new ProductServicePortService();

                UpdateProductPriceBySellerCodeResponse response = port.UpdateProductPriceBySellerCode(request);
                ProductBasic sampleProduct = response.product;



            }
            catch (Exception ex)
            {
                throw ex;
            }


            //authentication = new Authentication();


        }












    }
}