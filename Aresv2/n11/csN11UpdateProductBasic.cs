using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aresv2.n11ProductService;

namespace Aresv2.n11
{
    /// <summary>
    /// Temel Ürün Özellikleri Güncelleme
    /// </summary>
    public class csN11UpdateProductBasic : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        string auth { get; set; }//Bkz: Yetkilendirme

        string productId { get; set; }  //Ürün N11 ID bilgisi 
        string productSellerCode { get; set; }//Ürün mağaza kodu
        string price { get; set; }  //Ürünün baz fiyatı
        string /*productDiscount.*/discountType { get; set; }//Bkz: DiscountType

        string discountValue { get; set; }  //İndirim Miktarı (indirim tipinde verilen parametreye göre)
        string /*productDiscount.*/discountStartDate { get; set; }  //Mağaza indirimi başlama tarihi
        string /*productDiscount.*/discountEndDate { get; set; }    //Mağaza indirimi bitiş tarihi
        string /*stockItems.stockItem.*/sellerStockCode { get; set; }   //Ürün stok mağaza kodu
        string /*stockItems.stockItem.*/id { get; set; }    //Ürün stok N11 ID si
        string /*stockItems.stockItem.*/optionPrice { get; set; }   //Ürün stok biriminin liste fiyatı
        string /*stockItems.stockItem.*/quantity { get; set; }	//Ürün stok miktarı


        public void TemelOzellikleriGuncelle()
        {

            String strAppKey = "***";
            String strAppSecret = "***";
            String strProdSellerCode = "";
            String strDiscountStartDate = "";
            String strDiscountEndDate = "";
            String strSellerStockCode = "";
            double priceDec = 125.00;
            long productIdVal = 258491025;
            int discountTypeVal = 2;
            int discountValueVal = 25;
            int stockQuantityVal = 0;
            int stockIdVal = 0;
            double stockOptionPriceVal = 0;

            Authentication authentication = new Authentication();
            authentication.appKey = strAppKey;
            authentication.appSecret = strAppSecret;

            SellerProductDiscount sellerProductDiscount = new SellerProductDiscount();
            sellerProductDiscount.discountType = discountTypeVal.ToString();
            sellerProductDiscount.discountValue = discountValueVal;
            sellerProductDiscount.discountStartDate = strDiscountStartDate;
            sellerProductDiscount.discountEndDate = strDiscountEndDate;

            ProductUpdateSkuBasicRequest productUpdateSkuBasicRequest = new ProductUpdateSkuBasicRequest();
            productUpdateSkuBasicRequest.sellerStockCode = strSellerStockCode;
            productUpdateSkuBasicRequest.optionPrice = (decimal)stockOptionPriceVal;
            productUpdateSkuBasicRequest.id = stockIdVal;


            List<ProductUpdateSkuBasicRequest> productUpdateSkuBasicRequestItemList = new List<ProductUpdateSkuBasicRequest>();
            productUpdateSkuBasicRequestItemList.Add(productUpdateSkuBasicRequest);

            UpdateProductBasicRequest request = new UpdateProductBasicRequest();
            request.productSellerCode = strProdSellerCode;
            request.price = (decimal)priceDec;
            request.auth = authentication;
            request.productId = productIdVal;
            request.productDiscount = sellerProductDiscount;
            request.stockItems = productUpdateSkuBasicRequestItemList.ToArray();

            ProductServicePortService port = new ProductServicePortService();
            UpdateProductBasicResponse response = port.UpdateProductBasic(request);



            //System.out.println(response.getProduct().getId() + " Display price:"
            //        + response.getProduct().getDisplayPrice() + " Price:" + response.getProduct().getPrice());


        }

    }
}
