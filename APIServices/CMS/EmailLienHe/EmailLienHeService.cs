using Models;
using Models.CMS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.EmailLienHe
{
    public class EmailLienHeService : IEmailLienHeService
    {
        #region API
        
        private readonly string _ThemMoi = "api/EmailLienHe/ThemMoi";
        private readonly string _DanhSach = "api/EmailLienHe/DanhSach";

        #endregion

        public async Task<Response> ThemMoi(tbl_EmailLienHe requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoi, requestModel);
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

        public async Task<BaseRespone<tbl_EmailLienHe>> DanhSach(tbl_EmailLienHe requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_EmailLienHe>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_EmailLienHe>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_EmailLienHe>();
            }
        }
    }
}
