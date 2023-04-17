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
    public class CategoryAPIService : ICategoryAPIService
    {
        public async Task<int> Create(Category requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Category/Create", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Delete(CategoryRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Category/Delete", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<CategoryPaging> GetAll(CategoryRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Category/GetAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<CategoryPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<Category> GetById(int Id)
        {
            var resultApi = await RestfulApi<Response>.GetAsync("api/Category/GetById?Id="+ Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<Category>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<CategoryPaging> LoadDS()
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Category/LoadDS", null);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<CategoryPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(Category requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Category/Update", requestModel);
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
