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
    public class ColorAPIService : IColorAPIService
    {
        public async Task<ColorPaging> GetAll(ColorRequest requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/Color/DanhSach", requestModel);
            if(data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<ColorPaging>(data.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
