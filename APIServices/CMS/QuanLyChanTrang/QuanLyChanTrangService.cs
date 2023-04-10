using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices
{
    public class QuanLyChanTrangService : IQuanLyChanTrangService
    {

        #region API
        private readonly string _CapNhat = "api/QuanLyChanTrang/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyChanTrang/ChiTiet";

        #endregion


        public async Task<Response> CapNhat(tbl_ChanTrangModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CapNhat, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<Response>(resultAPI.result.ToString());
                }
                return new Response();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new Response();
            }
        }

        public async Task<tbl_ChanTrangModel> ChiTiet()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, null);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_ChanTrangModel>(resultAPI.result.ToString());
                }
                return new tbl_ChanTrangModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_ChanTrangModel();
            }
        }
    }
}
