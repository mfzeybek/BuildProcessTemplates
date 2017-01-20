using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aresv2.n11CategoryService;
using Aresv2.n11ProductService;



namespace Aresv2.n11
{
    public partial class frmN11 : Form
    {
        public frmN11()
        {
            InitializeComponent();
        }

        //n11CategoryService.Authentication aut = new n11CategoryService.Authentication();
        //n11CategoryService.CategoryData kategoridatasi = new n11CategoryService.CategoryData();
        private void frmN11_Load(object sender, EventArgs e)
        {
            //hamisina();
            //UrunGetir();

            KategorileriGetir();
            //UrunGetir();

            AltKategoriGetir();

        }



        void hamisina()
        {

            var authentication = new n11ProductService.Authentication();
            authentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            authentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz


            var productImageList = new List<ProductImage>();

            var productImage = new ProductImage();
            productImage.url = "http://www.cikolatacerez.com/images/products/00/02/70/270_buyuk_zoom.jpg";

            productImage.order = "1"; //sıra;

            productImageList.Add(productImage);

            var stockItems = new List<ProductSkuRequest>();

            var sku1 = new ProductSkuRequest();
            sku1.sellerStockCode = "1"; //stokkodu;
            sku1.quantity = "1"; //Stokmiktar;
            sku1.optionPrice = 10; // Stok Fiyatı
            stockItems.Add(sku1);

            var categoryRequest = new CategoryRequest();
            categoryRequest.id = 1356;// Ürünü bağlayacağınız kategoriId

            ProductRequest productRequest = new ProductRequest();
            productRequest.productSellerCode = "1";
            productRequest.title = "Ürün Adı";
            productRequest.subtitle = "Küçük Açıklama";
            productRequest.description = "Açıklama";
            productRequest.category = categoryRequest;
            productRequest.price = 10;//Ürün Fiyatı
            productRequest.currencyType = "1";//Döviztipi
            productRequest.images = productImageList.ToArray();
            productRequest.approvalStatus = "1";// 1: Onaylanmış ürün | 0: Beklemede
            productRequest.preparingDay = "1"; //Ürün Hazırlık Süresi;
            productRequest.stockItems = stockItems.ToArray();
            productRequest.productCondition = "1"; // 1 Yeni Ürün | 2 İkinci El
            productRequest.shipmentTemplate = "AKİDE";//Kargo Şablon adı;



            var attr = new ProductAttributeRequest();
            attr.name = "Marka";
            attr.value = "Ahs";

            var attList = new List<ProductAttributeRequest>();
            attList.Add(attr);
            productRequest.attributes = attList.ToArray();

            var discount = new ProductDiscountRequest();
            discount.type = "1"; //1: İndirim Tutarı Cinsinden | 2: İndirim Oranı Cinsinden | 3: İndirimli Fiyat Cinsinden
            discount.value = "5"; // % olarak indirim

            productRequest.discount = discount;

            var saveProductRequest = new SaveProductRequest();
            saveProductRequest.auth = authentication;
            saveProductRequest.product = productRequest;
            // ProductServicePort port = new ProductServicePortService().getProductServicePortSoap11();
            var port = new n11ProductService.ProductServicePortService();
            SaveProductResponse saveProductResponse = port.SaveProduct(saveProductRequest);

            MessageBox.Show(saveProductResponse.result.errorMessage);

        }


        void KategorileriGetir()
        {
            var authentication = new n11CategoryService.Authentication();
            authentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            authentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz

            var proxy = new n11CategoryService.CategoryServicePortService();


            //var proxy = new n11CategoryService.categ;



            var request = new GetTopLevelCategoriesRequest();
            request.auth = authentication;

            //proxy.

            var categories = proxy.GetTopLevelCategories(request);


            foreach (var item in categories.categoryList)
            {
                listBoxControl1.Items.Add(item.id + "-" + item.name);
            }
        }

        void AltKategoriGetir()
        {
            var authentication = new n11CategoryService.Authentication();
            authentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            authentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz

            var proxy = new n11CategoryService.CategoryServicePortService();


            var ALtKategoriOZelligi = new GetCategoryAttributesRequest();
            ALtKategoriOZelligi.auth = authentication;
            ALtKategoriOZelligi.categoryId = 1000210;

            proxy.GetCategoryAttributes(ALtKategoriOZelligi);




            //n11ProductService.get

            var request = new GetSubCategoriesRequest();
            request.auth = authentication;

            request.categoryId = 1000210;


            //var categories = proxy.GetTopLevelCategories(request);

            var categories = proxy.GetSubCategories(request);



            //MessageBox.Show(categories.category.);

            foreach (var item in categories.category[0].subCategoryList)
            {
                listBoxControl2.Items.Add(item.id + "-" + item.name);
            }
        }

        void UrunGetir(int ProducktID)
        {
            var authentication = new n11ProductService.Authentication();
            authentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            authentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz

            n11ProductService.GetProductByProductIdRequest ress = new n11ProductService.GetProductByProductIdRequest();


            ress.auth = authentication;
            ress.productId = ProducktID;

            var porttur = new n11ProductService.ProductServicePortService();

            var ahandaURun = porttur.GetProductByProductId(ress);

            MessageBox.Show(ahandaURun.product.title);
        }
    }
}
