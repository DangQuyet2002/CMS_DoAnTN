using APIServices;
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
    public class BillInfoAPIService : IBillInfoAPIService
    {
        public async Task<BillInfoPaging> GetAll(BillInfoRequest requestModel)
        {
            var resultApi = await RestfulApi<Response>.PostAsync("api/BillInfo/GetAll", requestModel);
            if (resultApi.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<BillInfoPaging>(resultApi.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
