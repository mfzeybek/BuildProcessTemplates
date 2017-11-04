using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aresv2.n11CategoryService;

namespace Aresv2.n11
{
    public class csKategoriOzellikGosterme : IDisposable
    {
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        int? currentPageVal { get; set; }
        int? pageSizeVal { get; set; }
        public void main(long _categoryIdVal)
        {
            String strAppKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962";
            String strAppSecret = "OiVekmVJRKC2wi0X";
            long categoryIdVal = _categoryIdVal;
            GetCategoryAttributesIdRequest request = new GetCategoryAttributesIdRequest();

            GetCategoryAttributesRequest remk = new GetCategoryAttributesRequest();
            Authentication authentication = new Authentication();
            authentication.appKey = strAppKey;
            authentication.appSecret = strAppSecret;

            RequestPagingData pagingData = new RequestPagingData();
            pagingData.currentPage = currentPageVal;
            pagingData.pageSize = pageSizeVal;
            //request.pagingData = pagingData;

            request.auth = authentication;
            request.categoryId = categoryIdVal;

            CategoryServicePortService port = new CategoryServicePortService();
            GetCategoryAttributesIdResponse response = port.GetCategoryAttributesId(request);
            List<CategoryProductAttributeData> valueList = response.categoryProductAttributeList.ToList<CategoryProductAttributeData>();




            foreach (CategoryProductAttributeData item in valueList) // buradan kategorilerin ozellikleri geliyor sanırım
            {

            }

            //for (CategoryProductAttributeData sampleValue:valueList)
            //{
            //    System.out.println("Özellik ID : " + sampleValue.getId() + " Özellik Adı: " + sampleValue.getName());
            //}
        }


        public void KategoriOzellikVeDegerGosterme(int _categoryIdValue)
        {
            String strAppKey = "66e296ef-ba12-4c7a-8d3f-67027f1e1962";
            String strAppSecret = "OiVekmVJRKC2wi0X";
            int currentPageVal = 0;
            int pageSizeVal = 100;

            int categoryIdValue = _categoryIdValue;

            Authentication authentication = new Authentication();
            authentication.appKey = strAppKey;
            authentication.appSecret = strAppSecret;

            GetCategoryAttributesRequest request = new GetCategoryAttributesRequest();
            request.auth = authentication;
            request.categoryId = categoryIdValue;
            RequestPagingData pagingData = new RequestPagingData();
            pagingData.currentPage = currentPageVal;
            pagingData.pageSize = pageSizeVal;
            request.pagingData = pagingData;


            CategoryServicePortService port = new CategoryServicePortService();
            GetCategoryAttributesResponse response = port.GetCategoryAttributes(request);



            //response.category






            List<CategoryAttributeData> categoryAttributes = response.category.attributeList.ToList<CategoryAttributeData>();

            List<CategoryAttributeData> attributeData = categoryAttributes.ToList<CategoryAttributeData>();

            foreach (CategoryAttributeData item in attributeData)
            {
                foreach (var item2 in item.valueList)
                {

                }
            }

            //for (CategoryAttributeData sampleAttributeData : attributeData
            //        )
            //{
            //    List<CategoryAttributeValueData> sampleAttValueDataList = sampleAttributeData.getValueList().getValue();
            //    for (CategoryAttributeValueData sampleAttValueData : sampleAttValueDataList
            //            )
            //    {
            //        System.out.println(sampleAttributeData.getId() + " " + sampleAttributeData.getName() + " " + sampleAttValueData.getName() + " (" + sampleAttValueData.getId() + ", " + sampleAttValueData.getDependedName() + ")");
            //    }

            //}
        }


    }


}
