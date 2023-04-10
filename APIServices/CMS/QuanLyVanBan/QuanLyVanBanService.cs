using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.QuanLyVanBan
{
    public class QuanLyVanBanService : IQuanLyVanBanService
    {
        #region API
        private readonly string _CapNhat = "api/QuanLyVanBan/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyVanBan/ChiTiet";
        private readonly string _DanhSach = "api/QuanLyVanBan/DanhSach";
        private readonly string _ThemMoi = "api/QuanLyVanBan/ThemMoi";
        private readonly string _Xoa = "api/QuanLyVanBan/Xoa";


        private readonly string _CapNhatLoaiVanBan = "api/QuanLyVanBan/CapNhatLoaiVanBan";
        private readonly string _ChiTietLoaiVanBan = "api/QuanLyVanBan/ChiTietLoaiVanBan";
        private readonly string _DanhSachLoaiVanBan = "api/QuanLyVanBan/DanhSachLoaiVanBan";
        private readonly string _ThemMoiLoaiVanBan = "api/QuanLyVanBan/ThemMoiLoaiVanBan";
        private readonly string _XoaLoaiVanBan = "api/QuanLyVanBan/XoaLoaiVanBan";

        public async Task<Response> CapNhat(tbl_VanBanModel requestModel)
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

        public async Task<Response> CapNhatLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CapNhatLoaiVanBan, requestModel);
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

        public async Task<tbl_VanBanModel> ChiTiet(tbl_VanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_VanBanModel>(resultAPI.result.ToString());
                }
                return new tbl_VanBanModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_VanBanModel();
            }
        }

        public async Task<tbl_LoaiVanBanModel> ChiTietLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {

            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTietLoaiVanBan, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_LoaiVanBanModel>(resultAPI.result.ToString());
                }
                return new tbl_LoaiVanBanModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_LoaiVanBanModel();
            }
        }

        public async Task<BaseRespone<tbl_VanBanModel>> DanhSach(tbl_VanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_VanBanModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_VanBanModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_VanBanModel>();
            }
        }

        public async Task<BaseRespone<tbl_LoaiVanBanModel>> DanhSachLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachLoaiVanBan, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_LoaiVanBanModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_LoaiVanBanModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_LoaiVanBanModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_VanBanModel requestModel)
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

        public async Task<Response> ThemMoiLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiLoaiVanBan, requestModel);
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

        public async Task<Response> Xoa(tbl_VanBanModel requestModel)
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

        public async Task<Response> XoaLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaLoaiVanBan, requestModel);
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
        #endregion

    }
}
