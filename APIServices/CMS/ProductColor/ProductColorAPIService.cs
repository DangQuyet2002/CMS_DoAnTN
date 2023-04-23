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
    public class ProductColorAPIService : IProductColorAPIService
    {
        public async Task<int> Create(ProductColor requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/ProductColor/create", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(data.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<ProductColorPaging> GetByPro(ProductColorRequest requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/ProductColor/GetByPro", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ProductColorPaging>(data.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
    }

