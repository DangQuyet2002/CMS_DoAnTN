using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.TinTuc
{
    public class TinTucAPIService : ITinTucAPIService
    {
        public async Task<int> Create(TinTucModel requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/TinTuc/Create", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }
        public async Task<int> Update(TinTucModel requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/TinTuc/Update", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<int> Delete(TinTucRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/TinTuc/Delete", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<TinTucPaging> GetAll(TinTucRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/TinTuc/GetAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<TinTucPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<TinTucPaging> SelectAll()
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/TinTuc/SelectAll", null);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<TinTucPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
        public async Task<TinTucModel> GetById(int Id)
        {
            var resultApi = await RestfulApi<Response>.GetAsync("api/TinTuc/GetById?Id="+ Id);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<TinTucModel>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
