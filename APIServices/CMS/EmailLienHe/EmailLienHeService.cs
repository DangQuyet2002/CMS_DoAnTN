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

        public async Task<EmailLHPaging> DanhSach(EmailLHRequest requestModel)
        {
            var data = await RestfulApi<Response>.PostAsync("api/EmailLienHe/DanhSach", requestModel);
            if (data.code == ResponseCode.SUCCESS)
            {
                return JsonConvert.DeserializeObject<EmailLHPaging>(data.result.ToString());
            }
            else
            {
                return null;
            }
        }
    }
}
