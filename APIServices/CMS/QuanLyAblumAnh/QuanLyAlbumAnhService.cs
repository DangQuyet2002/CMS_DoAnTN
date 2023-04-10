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
    public class QuanLyAlbumAnhService : IQuanLyAlbumAnhService
    {
        #region API
        private readonly string _CapNhat = "api/QuanLyAlbumAnh/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyAlbumAnh/ChiTiet";
        private readonly string _DanhSach = "api/QuanLyAlbumAnh/DanhSach";
        private readonly string _ThemMoi = "api/QuanLyAlbumAnh/ThemMoi";
        private readonly string _Xoa = "api/QuanLyAlbumAnh/Xoa";
        private readonly string _XoaChiTiet = "api/QuanLyAlbumAnh/XoaChiTiet";
        #endregion

        public async Task<Response> CapNhat(tbl_ThuVienAnhModel requestModel)
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

        public async Task<tbl_ThuVienAnhModel> ChiTiet(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_ThuVienAnhModel>(resultAPI.result.ToString());
                }
                return new tbl_ThuVienAnhModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_ThuVienAnhModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienAnhModel>> DanhSach(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_ThuVienAnhModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_ThuVienAnhModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_ThuVienAnhModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_ThuVienAnhModel requestModel)
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

        public async Task<Response> Xoa(tbl_ThuVienAnhModel requestModel)
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

        public async Task<Response> XoaChiTiet(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaChiTiet, requestModel);
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
