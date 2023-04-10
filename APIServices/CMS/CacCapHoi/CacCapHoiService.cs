using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS
{
    public class CacCapHoiService : ICacCapHoiService
    {
        #region API
        private readonly string _CapNhat = "api/CacCapHoi/CapNhat";
        private readonly string _ChiTiet = "api/CacCapHoi/ChiTiet";
        private readonly string _DanhSach = "api/CacCapHoi/DanhSach";
        private readonly string _ThemMoi = "api/CacCapHoi/ThemMoi";
        private readonly string _Xoa = "api/CacCapHoi/Xoa";
        private readonly string _CapNhatSTT = "api/CacCapHoi/CapNhatSTT";
        #endregion

        public async Task<Response> CapNhat(tbl_CacCapHoiModel requestModel)
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

        public async Task<Response> CapNhatSTT(tbl_CacCapHoiModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CapNhatSTT, requestModel);
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

        public async Task<tbl_CacCapHoiModel> ChiTiet(tbl_CacCapHoiModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_CacCapHoiModel>(resultAPI.result.ToString());
                }
                return new tbl_CacCapHoiModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_CacCapHoiModel();
            }
        }

        public async Task<BaseRespone<tbl_CacCapHoiModel>> DanhSach(tbl_CacCapHoiModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_CacCapHoiModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_CacCapHoiModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_CacCapHoiModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_CacCapHoiModel requestModel)
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

        public async Task<Response> Xoa(tbl_CacCapHoiModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_Xoa, requestModel);
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
    }
}
