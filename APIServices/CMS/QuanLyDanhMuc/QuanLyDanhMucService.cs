using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.QuanLyDanhMuc
{
    public class QuanLyDanhMucService : IQuanLyDanhMucService
    {

        #region API
        private readonly string _CapNhat = "api/QuanLyDanhMuc/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyDanhMuc/ChiTiet";
        private readonly string _DanhSach = "api/QuanLyDanhMuc/DanhSach";
        private readonly string _ThemMoi = "api/QuanLyDanhMuc/ThemMoi";
        private readonly string _Xoa = "api/QuanLyDanhMuc/Xoa";
        private readonly string _DanhSachAll = "api/QuanLyDanhMuc/DanhSachAll";
        private readonly string _ChiTietChuyenMucBaiViet = "api/QuanLyDanhMuc/ChiTietChuyenMucBaiViet";

        #endregion


        public async Task<Response> CapNhat(tbl_CategoryModel requestModel)
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

        public async Task<tbl_CategoryModel> ChiTiet(tbl_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_CategoryModel>(resultAPI.result.ToString());
                }
                return new tbl_CategoryModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_CategoryModel();
            }
        }

        public async Task<tbl_CategoryModel> ChiTietChuyenMucBaiViet(tbl_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTietChuyenMucBaiViet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_CategoryModel>(resultAPI.result.ToString());
                }
                return new tbl_CategoryModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_CategoryModel();
            }
        }

        public async Task<List<tbl_CategoryModel>> DanhSach(tbl_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_CategoryModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_CategoryModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_CategoryModel>();
            }
        }

        public async Task<List<tbl_CategoryModel>> DanhSachAll(tbl_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachAll, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_CategoryModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_CategoryModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_CategoryModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_CategoryModel requestModel)
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

        public async Task<Response> Xoa(tbl_CategoryModel requestModel)
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
