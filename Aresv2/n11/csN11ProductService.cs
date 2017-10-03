using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aresv2.n11ProductService;
//using Aresv2.n11ProductStockService;
//using Aresv2.n11CategoryService;




namespace Aresv2.n11
{
    public class csN11ProductService : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        String strAppKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962";
        String strAppSecret = "OiVekmVJRKC2wi0X";


        string title { get; set; }

        string subtitle { get; set; }
        Category category { get; set; }
        string description { get; set; }
        decimal displayPrice { get; set; }
        ProductDiscount discount { get; set; }
        string preparingDay { get; set; }
        decimal price { get; set; }
        string approvalStatus { get; set; }
        ProductAttribute[] attributes { get; set; }
        string productSellerCode { get; set; }
        string shipmentTemplate { get; set; }


        public void ProducktGetir(string SaticiUrunKodu) // yani stok kodu olarak ne verdiysen o işte
        {
            String strSellerCode = SaticiUrunKodu;
            Authentication authentication = new Authentication();
            authentication.appKey = strAppKey;
            authentication.appSecret = strAppSecret;

            GetProductBySellerCodeRequest request = new GetProductBySellerCodeRequest();
            request.auth = authentication;
            request.sellerCode = strSellerCode;

            n11ProductService.ProductServicePortService port = new n11ProductService.ProductServicePortService();
            //ProductServicePort port = new ProductServicePortService().getProductServicePortSoap11();
            GetProductBySellerCodeResponse response = port.GetProductBySellerCode(request);

            this.title = response.product.title;
            this.subtitle = response.product.subtitle;
            this.category = response.product.category;
            this.description = response.product.description;
            this.displayPrice = response.product.displayPrice;
            this.discount = response.product.discount;
            this.preparingDay = response.product.preparingDay;
            this.price = response.product.price;
            this.approvalStatus = response.product.approvalStatus;
            this.attributes = response.product.attributes;
            this.productSellerCode = response.product.productSellerCode;
            this.shipmentTemplate = response.product.shipmentTemplate;
        }

        public void Kaydet()
        {

        }
        public void main(String[] args)
        {
            String strAppKey = "64155786-da91-4204-8735-443d17acf808";
            String strAppSecret = "***";
            String strUrl = "https://www.google.com/logos/doodles/2016/bahrain-national-day-2016-6221988579246080-hp2x.jpg";
            String strSellerStockCode = "MaviKod-APIDeneme432100000000";
            String strSellerStockCode1 = "KırmızıKod-APIDeneme4321000000000";
            String strAttributeName = "Marka";
            String strAttributeValue = "Apple";
            String strSkuAttributeKey = "Renk";
            String strSkuAttributeValue = "Mavi";
            String strSkuAttributeValue1 = "Kırmızı";
            String strProductTitle = "Lorem ipsum";
            String strProductSubtitle = "Lorem ipsum dolor sit amet";
            String strProductSellerCode = "APIDeneme432101000000000";
            String strProductCondition = "1";
            String strShipmentTemplate = "AGT";
            String strProductDescription = "Hello World!";
            String strGtin = "0190198066473";
            String strGtin1 = "0190198066474";
            int setOrderValue = 1;
            int quantityValue = 10;
            int quantityValue1 = 20;
            int categoryIdValue = 592;
            int priceValue = 50;
            int currencyTypeValue = 1;
            int approvalStatusValue = 1;
            int preparingDayValue = 3;

            Authentication authentication = new Authentication();
            authentication.appKey = strAppKey;
            authentication.appSecret = strAppSecret;

            ProductImage productImage = new ProductImage();
            List<ProductImage> productImageList = new List<ProductImage>();
            productImage.url = strUrl;
            productImage.order = "1"; // foto sırası bu
            productImageList.Add(productImage);

            List<ProductAttributeRequest> skuAttributeRequestList = new List<ProductAttributeRequest>();
            ProductAttributeRequest skuAttributeRequest = new ProductAttributeRequest();
            skuAttributeRequest.name = strSkuAttributeKey;
            skuAttributeRequest.value = strSkuAttributeValue;
            skuAttributeRequestList.Add(skuAttributeRequest);

            List<ProductAttributeRequest> skuAttributeRequestList1 = new List<ProductAttributeRequest>();
            ProductAttributeRequest skuAttributeRequest1 = new ProductAttributeRequest();
            skuAttributeRequest1.name = strSkuAttributeKey;
            skuAttributeRequest1.value = strSkuAttributeValue1;
            skuAttributeRequestList1.Add(skuAttributeRequest1);

            List<ProductSkuRequest> stockItems = new List<ProductSkuRequest>();

            ProductSkuRequest sku = new ProductSkuRequest();
            sku.sellerStockCode = strSellerStockCode;
            sku.attributes = skuAttributeRequestList1.ToArray();// (skuAttributeRequestList);
            sku.quantity = quantityValue.ToString();
            sku.gtin = strGtin;

            ProductSkuRequest sku1 = new ProductSkuRequest();
            sku1.sellerStockCode = strSellerStockCode1;
            sku1.attributes = skuAttributeRequestList1.ToArray();
            sku1.quantity = quantityValue1.ToString();
            sku1.gtin = strGtin1;

            stockItems.Add(sku);
            stockItems.Add(sku1);

            CategoryRequest categoryRequest = new CategoryRequest();
            categoryRequest.id = categoryIdValue;

            ProductAttributeRequest productAttribute = new ProductAttributeRequest();
            productAttribute.name = strAttributeName;
            productAttribute.value = strAttributeValue;
            List<ProductAttributeRequest> productAttributeRequestList = new List<ProductAttributeRequest>();
            productAttributeRequestList.Add(productAttribute);

            ProductRequest productRequest = new ProductRequest();
            productRequest.title = strProductTitle;
            productRequest.subtitle = strProductSubtitle;
            productRequest.description = strProductDescription;
            productRequest.category = categoryRequest;
            productRequest.productSellerCode = strProductSellerCode;
            productRequest.price = priceValue;
            productRequest.currencyType = currencyTypeValue.ToString();
            productRequest.images = productImageList.ToArray();
            productRequest.approvalStatus = approvalStatusValue.ToString();
            productRequest.preparingDay = preparingDayValue.ToString();
            productRequest.stockItems = stockItems.ToArray();
            productRequest.productCondition = strProductCondition;
            productRequest.shipmentTemplate = strShipmentTemplate;
            productRequest.attributes = productAttributeRequestList.ToArray();


            SaveProductRequest saveProductRequest = new SaveProductRequest();
            saveProductRequest.auth = authentication;
            saveProductRequest.product = productRequest;

            ProductServicePortService port = new ProductServicePortService();
            SaveProductResponse response = port.SaveProduct(saveProductRequest);

            //System.out.println("Saving product " + response.getProduct().getId() + " is " + response.getResult().getStatus().getValue());
        }


    }
}
