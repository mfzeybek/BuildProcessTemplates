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

        string subtitle { get; set; } // Ürün sayfasında görünecek altbaşlık, en fazla 100 kaakter olmalıdır.
        Category category { get; set; }
        public string description { get; set; }
        decimal displayPrice { get; set; }
        ProductDiscount discount { get; set; }
        string preparingDay { get; set; }
        decimal price { get; set; }
        string approvalStatus { get; set; }
        ProductAttribute[] attributes { get; set; }
        string productSellerCode { get; set; }
        string shipmentTemplate { get; set; }
        string FotoUrl { get; set; }
        string saleStatus { get; set; }
        string productCondition { get; set; }




        ProductSkuList stockItems { get; set; }

        ProductImage[] Foto { get; set; }


        //product.saleStatus
        //1: Satış Öncesi(Before_Sale)
        //2: Satışta(On_Sale)
        //3: Stok yok(Out of_Stock)
        //4: Satışa kapalı(Sale_Closed)



        //product.approvalStatus Ürün onay durumu:
        //1: Aktif(Satışta)
        //2: Beklemede 
        //3: Yasaklı



        public void ProducktGetir(string SaticiUrunKodu) // yani stok kodu olarak ne verdiysen o işte
        {
            try
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
                this.description = response.product.description; // detay
                this.displayPrice = response.product.displayPrice; // Görüntülenen ürün fiyatı(Ürünün indirimler sonucu tanımlanan son fiyat hali)
                this.discount = response.product.discount; // indirim
                this.preparingDay = response.product.preparingDay; // hazırlama zamanı
                this.price = response.product.price; // Ürünün baz fiyatı
                this.approvalStatus = response.product.approvalStatus; // onay durumu
                this.attributes = response.product.attributes; // özellikleri biz değiştiremiyoruz n11 den kategoriye göre geliyor. attributes[0].name (bu hep marka)
                this.productSellerCode = response.product.productSellerCode; // bizdeki stok kodu
                this.shipmentTemplate = response.product.shipmentTemplate;
                this.Foto = response.product.images;
                //this.PreparingDay = Convert.ToInt32(response.product.preparingDay);

                productCondition = response.product.productCondition;

                stockItems = response.product.stockItems;

                //response.product.attributes = new ProductAttribute;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public enum KayitIslemi
        {
            Basarili,
            Basarisiz,
            AgabuNe
        }


        public void Kaydet()
        {
            ahandaaa();
        }
        public KayitIslemi ahandaaa()
        {
            try
            {
                //String strAppKey = "64155786-da91-4204-8735-443d17acf808";
                //String strAppSecret = "***";
                String strUrl = FotoUrl;
                String strSellerStockCode = productSellerCode;
                //String strSellerStockCode1 = "KırmızıKod-APIDeneme4321000000000";
                String strAttributeName = "Marka";
                String strAttributeValue = "Apple";
                String strSkuAttributeKey = "Renk";
                String strSkuAttributeValue = "Mavi";
                String strSkuAttributeValue1 = "Kırmızı";
                String strProductTitle = "Lorem ipsum";
                String strProductSubtitle = "Lorem ipsum dolor sit amet";
                String strProductSellerCode = productSellerCode;
                String strProductCondition = "1"; // 1 yeni, 2 ikinci el
                String strShipmentTemplate = "AGT";
                //String strProductDescription = this.description;
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

                //List<ProductAttributeRequest> skuAttributeRequestList = new List<ProductAttributeRequest>();
                //ProductAttributeRequest skuAttributeRequest = new ProductAttributeRequest();
                //skuAttributeRequest.name = strSkuAttributeKey;
                //skuAttributeRequest.value = strSkuAttributeValue;
                //skuAttributeRequestList.Add(skuAttributeRequest);

                //List<ProductAttributeRequest> skuAttributeRequestList1 = new List<ProductAttributeRequest>();
                //ProductAttributeRequest skuAttributeRequest1 = new ProductAttributeRequest();
                //skuAttributeRequest1.name = strSkuAttributeKey;
                //skuAttributeRequest1.value = strSkuAttributeValue1;
                //skuAttributeRequestList1.Add(skuAttributeRequest1);

                List<ProductSkuRequest> stockItems = new List<ProductSkuRequest>();

                foreach (ProductSku item in this.stockItems.stockItem)
                {
                    ProductSkuRequest sku1 = new ProductSkuRequest();
                    sku1.sellerStockCode = item.sellerStockCode;
                    foreach (var item2 in item.attributes)
                    {
                        List<ProductAttributeRequest> skuAttributeRequestList1 = new List<ProductAttributeRequest>();
                        ProductAttributeRequest skuAttributeRequest1 = new ProductAttributeRequest();
                        skuAttributeRequest1.name = item2.name;
                        skuAttributeRequest1.value = item2.value;
                        skuAttributeRequestList1.Add(skuAttributeRequest1);


                        //skuAttributeRequest1.name = strSkuAttributeKey;
                        //skuAttributeRequest1.value = strSkuAttributeValue1;
                        //skuAttributeRequestList1.Add(skuAttributeRequest1);

                        sku1.attributes = skuAttributeRequestList1.ToArray();
                    }


                    sku1.quantity = item.quantity;
                    sku1.optionPrice = item.optionPrice;
                    sku1.gtin = item.gtin;
                    stockItems.Add(sku1);
                }



                //ProductSkuRequest sku = new ProductSkuRequest();
                //sku = this.stockItems;
                //sku.sellerStockCode = strSellerStockCode;
                //sku.attributes = skuAttributeRequestList1.ToArray();// (skuAttributeRequestList);
                //sku.quantity = quantityValue.ToString();
                //sku.gtin = strGtin;

                //ProductSkuRequest sku1 = new ProductSkuRequest();
                ////sku1.sellerStockCode = strSellerStockCode1;
                //sku1.attributes = skuAttributeRequestList1.ToArray();
                //sku1.quantity = quantityValue1.ToString();
                //sku1.gtin = strGtin1;

                //stockItems.Add(sku);
                //stockItems.Add(sku1);

                CategoryRequest categoryRequest = new CategoryRequest();
                categoryRequest.id = category.id;

                //ProductAttributeRequest productAttribute = new ProductAttributeRequest();
                //productAttribute.name = strAttributeName;
                //productAttribute.value = strAttributeValue;
                //List<ProductAttributeRequest> productAttributeRequestList = new List<ProductAttributeRequest>();
                //productAttributeRequestList.Add(this.attributes[0]);
                //productAttributeRequestList.Add(productAttribute);

                ProductRequest productRequest = new ProductRequest();
                productRequest.title = this.title;
                productRequest.subtitle = this.subtitle;
                productRequest.description = this.description;
                productRequest.category = categoryRequest;
                productRequest.productSellerCode = this.productSellerCode;
                productRequest.price = this.price;
                productRequest.currencyType = "1";
                productRequest.images = this.Foto;
                productRequest.approvalStatus = this.approvalStatus;
                productRequest.preparingDay = this.preparingDay;

                productRequest.stockItems = stockItems.ToArray();
                //productRequest.stockItems = this.stostockItems.ToArray();

                productRequest.productCondition = strProductCondition;
                productRequest.shipmentTemplate = this.shipmentTemplate;
                //productRequest.attributes = this.proproductAttributeRequestList.ToArray();


                SaveProductRequest saveProductRequest = new SaveProductRequest();
                saveProductRequest.auth = authentication;
                saveProductRequest.product = productRequest;

                ProductServicePortService port = new ProductServicePortService();
                SaveProductResponse response = port.SaveProduct(saveProductRequest);
                //ResultInfo info = new ResultInfo();
                if (response.result.status == "failure")
                {
                    return KayitIslemi.Basarisiz;
                }
                else if (response.result.status == "failure")
                {
                    return KayitIslemi.Basarili;
                }
                else
                {
                    return KayitIslemi.AgabuNe;
                }
                //System.out.println("Saving product " + response.getProduct().getId() + " is " + response.getResult().getStatus().getValue());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
