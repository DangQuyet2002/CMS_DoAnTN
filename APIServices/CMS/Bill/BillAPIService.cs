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
    public class BillAPIService : IBillAPIService
    {
        public async Task<int> Create(Bill requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Bill/Create", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<int>(resultApi.result.ToString());
            }
            else
            {
                return 0;
            }
        }

        public async Task<BillPaging> GetAll(BillRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Bill/GetAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<BillPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<BillPaging> GetByUser(BillRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Bill/GetByUser", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<BillPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }

        public async Task<int> Update(Bill requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/Bill/Update", requestModel);
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
