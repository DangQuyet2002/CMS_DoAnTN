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
    public class LienKetGioiThieuService : ILienKetGioiThieuService
    {
        #region API
        private readonly string _CapNhat = "api/LienKetGioiThieu/CapNhat";
        private readonly string _ChiTiet = "api/LienKetGioiThieu/ChiTiet";
        private readonly string _DanhSach = "api/LienKetGioiThieu/DanhSach";
        private readonly string _ThemMoi = "api/LienKetGioiThieu/ThemMoi";
        private readonly string _Xoa = "api/LienKetGioiThieu/Xoa";
        private readonly string _CapNhatSTT = "api/LienKetGioiThieu/CapNhatSTT";
        #endregion

        public async Task<Response> CapNhat(tbl_LienKetGioiThieuModel requestModel)
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

        public async Task<Response> CapNhatSTT(tbl_LienKetGioiThieuModel requestModel)
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

        public async Task<tbl_LienKetGioiThieuModel> ChiTiet(tbl_LienKetGioiThieuModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_LienKetGioiThieuModel>(resultAPI.result.ToString());
                }
                return new tbl_LienKetGioiThieuModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_LienKetGioiThieuModel();
            }
        }

        public async Task<BaseRespone<tbl_LienKetGioiThieuModel>> DanhSach(tbl_LienKetGioiThieuModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_LienKetGioiThieuModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_LienKetGioiThieuModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_LienKetGioiThieuModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_LienKetGioiThieuModel requestModel)
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

        public async Task<Response> Xoa(tbl_LienKetGioiThieuModel requestModel)
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
