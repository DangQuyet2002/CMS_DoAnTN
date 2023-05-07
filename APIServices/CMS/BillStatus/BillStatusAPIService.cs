using Models;
using Models.CMS.BillStatus;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.BillStatus
{
    public class BillStatusAPIService : IBillStatusAPIService
    {
        public async Task<BillStatusPaging> GetAll(BillStatusRequest requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/BillStatus/DanhSach", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<BillStatusPaging>(data.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
