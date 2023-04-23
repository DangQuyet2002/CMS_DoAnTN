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
    public class SizeAPIService : ISizeAPIService
    {
        public async Task<SizePaging> GetAll(SizeRequest requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/Size/DanhSach", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<SizePaging>(data.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
