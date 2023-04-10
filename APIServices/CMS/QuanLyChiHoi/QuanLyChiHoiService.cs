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
    public class QuanLyChiHoiService : IQuanLyChiHoiService
    {

        #region API
        private readonly string _CapNhat = "api/QuanLyChiHoi/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyChiHoi/ChiTiet";
        private readonly string _DanhSach = "api/QuanLyChiHoi/DanhSach";
        private readonly string _ThemMoi = "api/QuanLyChiHoi/ThemMoi";
        private readonly string _Xoa = "api/QuanLyChiHoi/Xoa";

        #endregion
        public async Task<Response> CapNhat(tbl_ChiHoiTTModel requestModel)
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

        public async Task<tbl_ChiHoiTTModel> ChiTiet(tbl_ChiHoiTTModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_ChiHoiTTModel>(resultAPI.result.ToString());
                }
                return new tbl_ChiHoiTTModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_ChiHoiTTModel();
            }
        }

        public async Task<List<tbl_ChiHoiTTModel>> DanhSach(tbl_ChiHoiTTModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_ChiHoiTTModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_ChiHoiTTModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_ChiHoiTTModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_ChiHoiTTModel requestModel)
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

        public async Task<Response> Xoa(tbl_ChiHoiTTModel requestModel)
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
