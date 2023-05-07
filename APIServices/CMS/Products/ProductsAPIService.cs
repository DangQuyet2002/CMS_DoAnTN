using Models;
using Models.CMS.Product;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices
{
    public class ProductsAPIService : IProductsAPIService
    {
        public async Task<int> Create(Product requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/Create", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> Update(Product requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/Update", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> UpdateQuantity(Product requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/UpdateQuantity", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<Product> GetById(int Id)
        {
            var resultApi = await RestfulApi<Response>.GetAsync("api/Products/GetById?Id="+ Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<Product>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<int> Delete(ProductRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/Delete", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<ProductPaging> GetAll(ProductRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/GetAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ProductPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<ProductPaging> GetAllDisCount(ProductRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/GetAllDisCount", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ProductPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<ProductPaging> GetByCate(ProductRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/GetByCate", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ProductPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<int> UpdateView(int Id)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/UpdateView?Id="+ Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<ProductPaging> GetByView()
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Products/GetByView", null);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ProductPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
