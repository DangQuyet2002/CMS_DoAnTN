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
    public class QuanTriBannerService : IQuanTriBannerService
    {

        #region API
        private readonly string _CapNhat = "api/QuanTriBanner/CapNhat";
        private readonly string _ChiTiet = "api/QuanTriBanner/ChiTiet";
        private readonly string _DanhSach = "api/QuanTriBanner/DanhSach";
        private readonly string _ThemMoi = "api/QuanTriBanner/ThemMoi";
        private readonly string _Xoa = "api/QuanTriBanner/Xoa";

        private readonly string _DanhSachBannerChuaGanViTri = "api/QuanTriBanner/DanhSachBannerChuaGanViTri";
        private readonly string _DanhSachBannerDaGanViTri = "api/QuanTriBanner/DanhSachBannerDaGanViTri";
        private readonly string _DanhSachViTri = "api/QuanTriBanner/DanhSachViTri";
        private readonly string _ThemMoiViTri = "api/QuanTriBanner/ThemMoiViTri";
        private readonly string _XoaViTri = "api/QuanTriBanner/XoaViTri";
        private readonly string _ThemLuotXem = "api/QuanTriBanner/ThemLuotXem";
        private readonly string _CheckHienThiSilde = "api/QuanTriBanner/CheckHienThiSilde";

        #endregion

        public async Task<Response> CapNhat(tbl_BannerModel requestModel)
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

        public async Task<Response> CheckHienThiSilde(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CheckHienThiSilde, requestModel);
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

        public async Task<tbl_BannerModel> ChiTiet(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_BannerModel>(resultAPI.result.ToString());
                }
                return new tbl_BannerModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_BannerModel();
            }
        }

        public async Task<BaseRespone<tbl_BannerModel>> DanhSach(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_BannerModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_BannerModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_BannerModel>();
            }
        }

        public async Task<BaseRespone<tbl_BannerModel>> DanhSachBannerChuaGanViTri(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBannerChuaGanViTri, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_BannerModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_BannerModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_BannerModel>();
            }
        }

        public async Task<BaseRespone<tbl_BannerModel>> DanhSachBannerDaGanViTri(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBannerDaGanViTri, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_BannerModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_BannerModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_BannerModel>();
            }
        }

        public async Task<List<tbl_BannerModel>> DanhSachViTri(tbl_BannerModel requestModel)
        {

            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachViTri, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_BannerModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_BannerModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_BannerModel>();
            }
        }

        public async Task<Response> ThemLuotXem(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemLuotXem, requestModel);
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

        public async Task<Response> ThemMoi(tbl_BannerModel requestModel)
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

        public async Task<Response> ThemMoiViTri(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiViTri, requestModel);
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

        public async Task<Response> Xoa(tbl_BannerModel requestModel)
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

        public async Task<Response> XoaViTri(tbl_BannerModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaViTri, requestModel);
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
