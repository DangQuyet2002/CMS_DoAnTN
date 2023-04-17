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
    public class DanhMucCategoryAPIService : IDanhMucCategoryAPIService
    {
        public async Task<int> Create(DanhMucCategory requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/DMCategory/Create", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Delete(DanhMucCategoryRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/DMCategory/Delete", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<DanhMucCategoryPaging> GetAll(DanhMucCategoryRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/DMCategory/GetAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<DanhMucCategoryPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<DanhMucCategory> GetById(int Id)
        {
            var resultApi = await RestfulApi<Response>.GetAsync("api/DMCategory/GetById?Id="+ Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<DanhMucCategory>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(DanhMucCategory requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/DMCategory/Update", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
    }
}
