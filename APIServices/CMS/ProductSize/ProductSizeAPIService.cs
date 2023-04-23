using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices
{
    public class ProductSizeAPIService : IProductSizeAPIService
    {
        public async Task<int> Create(ProductSize requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/ProductSize/create", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(data.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<ProductSizePaging> GetByPro(ProductSizeRequest requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/ProductSize/GetByPro", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ProductSizePaging>(data.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
