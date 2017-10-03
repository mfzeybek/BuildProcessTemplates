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
using System.Data.SqlClient;



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
            dt_Kategoriler = new DataTable();
            dt_Kategoriler.Columns.Add("ID");
            dt_Kategoriler.Columns.Add("UstKategoriID");
            dt_Kategoriler.Columns.Add("KategoriAdi");

            KategorileriGetir();
            //UrunGetir();
            //hamisina();

            //AltKategoriGetir(1);

            //KategorileriKaydet();
        }
        clsTablolar.n11.csN11Kategori kateg = new clsTablolar.n11.csN11Kategori();
        DataTable dt_Kategoriler;
        n11ProductService.ProductServicePortService porttur = new n11ProductService.ProductServicePortService();

        n11ProductService.Authentication ProductAuthentication = new n11ProductService.Authentication();
        n11CategoryService.Authentication KategoriAuthentication = new n11CategoryService.Authentication();

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
            sku1.optionPrice = 105; // Stok Fiyatı
            stockItems.Add(sku1);

            var categoryRequest = new CategoryRequest();
            categoryRequest.id = 1356;// Ürünü bağlayacağınız kategoriId

            ProductRequest productRequest = new ProductRequest();
            productRequest.productSellerCode = "1";
            productRequest.title = "MEHMET ALİ HASAN";
            productRequest.subtitle = "BUAYA AÇIKLAMA LAZIM";
            productRequest.description = "AçıklamaWEWQE";
            productRequest.category = categoryRequest;
            productRequest.price = 105;//Ürün Fiyatı
            productRequest.currencyType = "9999";//Döviztipi
            productRequest.images = productImageList.ToArray();
            productRequest.approvalStatus = "1";// 1: Onaylanmış ürün | 0: Beklemede
            productRequest.preparingDay = "3"; //Ürün Hazırlık Süresi;
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
            discount.type = "3"; //1: İndirim Tutarı Cinsinden | 2: İndirim Oranı Cinsinden | 3: İndirimli Fiyat Cinsinden
            discount.value = "80"; // % olarak indirim

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
            //var KategoriAuthentication = new n11CategoryService.Authentication();
            KategoriAuthentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            KategoriAuthentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz

            var proxy = new n11CategoryService.CategoryServicePortService();


            //var proxy = new n11CategoryService.categ;



            var request = new GetTopLevelCategoriesRequest();
            request.auth = KategoriAuthentication;

            //proxy.

            var categories = proxy.GetTopLevelCategories(request);

            foreach (var item in categories.categoryList)
            {
                dt_Kategoriler.Rows.Add(dt_Kategoriler.NewRow());
                dt_Kategoriler.Rows[dt_Kategoriler.Rows.Count - 1]["ID"] = item.id;
                dt_Kategoriler.Rows[dt_Kategoriler.Rows.Count - 1]["KategoriAdi"] = item.name;
                ahanadaAltKAteroriGetir(item.id);
            }
            gridControl1.DataSource = dt_Kategoriler;
            treeList1.DataSource = dt_Kategoriler;
        }


        //n11CategoryService.Authentication authentication;
        n11CategoryService.CategoryServicePortService proxy;
        GetCategoryAttributesRequest ALtKategoriOZelligi;
        void ahanadaAltKAteroriGetir(Int64 CategoriyID)
        {
            //authentication = new n11CategoryService.Authentication();
            KategoriAuthentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            KategoriAuthentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz

            proxy = new n11CategoryService.CategoryServicePortService();

            ALtKategoriOZelligi = new GetCategoryAttributesRequest();
            ALtKategoriOZelligi.auth = KategoriAuthentication;


            proxy.GetCategoryAttributes(ALtKategoriOZelligi);
            AltKategoriGetir(CategoriyID);
        }


        void AltKategoriGetir(Int64 CategoriyID)
        {
            //n11ProductService.get
            ALtKategoriOZelligi.categoryId = CategoriyID;

            var request = new GetSubCategoriesRequest();
            request.auth = KategoriAuthentication;

            request.categoryId = CategoriyID;

            //var categories = proxy.GetTopLevelCategories(request);

            var categories = proxy.GetSubCategories(request);


            //MessageBox.Show(categories.category.);
            if (categories.category[0].subCategoryList != null)
                foreach (var item in categories.category[0].subCategoryList)
                {
                    dt_Kategoriler.Rows.Add(dt_Kategoriler.NewRow());
                    dt_Kategoriler.Rows[dt_Kategoriler.Rows.Count - 1]["ID"] = item.id;
                    dt_Kategoriler.Rows[dt_Kategoriler.Rows.Count - 1]["KategoriAdi"] = item.name;
                    dt_Kategoriler.Rows[dt_Kategoriler.Rows.Count - 1]["UstKategoriID"] = CategoriyID;
                    AltKategoriGetir(item.id);
                }
        }

        void UrunGetir(int ProducktID)
        {


            n11ProductService.GetProductByProductIdRequest ress = new n11ProductService.GetProductByProductIdRequest();

            ProductAuthentication.appKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962"; //api anahtarınız
            ProductAuthentication.appSecret = "OiVekmVJRKC2wi0X";//api şifeniz

            ress.auth = ProductAuthentication;
            ress.productId = ProducktID;



            var ahandaURun = porttur.GetProductByProductId(ress);
            //porttur.GetProductList.
            //porttur.GetProductList
            GetProductListRequest getProductListRequest = new GetProductListRequest();
            getProductListRequest.auth = ProductAuthentication;

            n11ProductService.RequestPagingData requestPagingData = new n11ProductService.RequestPagingData();

            //requestPagingData.currentPage (currentPageValue);
            //requestPagingData.setPageSize(pageSizeValue);


            getProductListRequest.pagingData = requestPagingData;


            porttur.GetProductList(getProductListRequest);


            MessageBox.Show(ahandaURun.product.title);
        }

        void n11UrunleriGetir()
        {

            //porttur.GetProductList();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            UrunGetir(164046793);
        }

        SqlTransaction TrGenel;
        public void KategorileriKaydet()
        {
            //dt_Kategoriler
            foreach (var item in dt_Kategoriler.AsEnumerable())
            {
                int ID = Convert.ToInt32(item["ID"]);
                int UstKatID = -1;
                if (string.IsNullOrEmpty(item["UstKategoriID"].ToString()))
                    UstKatID = -1;
                else
                    UstKatID = Convert.ToInt32(item["UstKategoriID"]);

                string KatAdi = item["KategoriAdi"].ToString();

                TrGenel = SqlConnections.GetBaglanti().BeginTransaction();
                kateg.KategorileriGuncelle(SqlConnections.GetBaglanti(), TrGenel, ID, UstKatID, KatAdi, "");
                TrGenel.Commit();

            }
        }
    }
}
