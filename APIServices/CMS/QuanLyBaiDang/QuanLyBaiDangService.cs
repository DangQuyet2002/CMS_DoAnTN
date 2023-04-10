using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.QuanLyBaiDang
{
    public class QuanLyBaiDangService : IQuanLyBaiDangService
    {
        #region API
        private readonly string _CapNhat = "api/QuanLyBaiDang/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyBaiDang/ChiTiet";
        private readonly string _DanhSachBaiDangBTV = "api/QuanLyBaiDang/DanhSachBaiDangBTV";
        private readonly string _DanhSachBaiDangPV = "api/QuanLyBaiDang/DanhSachBaiDangPV";
        private readonly string _DanhSachBaiDangTKGD = "api/QuanLyBaiDang/DanhSachBaiDangTKGD";
        private readonly string _IsXuatBanBaiBao = "api/QuanLyBaiDang/IsXuatBanBaiBao";
        private readonly string _ThemMoi = "api/QuanLyBaiDang/ThemMoi";
        private readonly string _Xoa = "api/QuanLyBaiDang/Xoa";


        private readonly string _IsBTVDuyetHuyDuyet = "api/QuanLyBaiDang/IsBTVDuyetHuyDuyet";
        private readonly string _IsPVDuyetHuyDuyet = "api/QuanLyBaiDang/IsPVDuyetHuyDuyet";
        private readonly string _IsTK_GDDuyetHuyDuyet = "api/QuanLyBaiDang/IsTK_GDDuyetHuyDuyet";
        private readonly string _IsTK_GDTraLai = "api/QuanLyBaiDang/IsTK_GDTraLai";
        private readonly string _TinTucMoi = "api/QuanLyBaiDang/TinTucMoi";
        private readonly string _DanhSachBaiDangMoi = "api/QuanLyBaiDang/DanhSachBaiDangMoi";
        private readonly string _CapNhatLuotXem = "api/QuanLyBaiDang/CapNhatLuotXem";
        private readonly string _DanhSachBinhLuan = "api/QuanLyBaiDang/DanhSachBinhLuan";
        private readonly string _ThemMoiBinhLuan = "api/QuanLyBaiDang/ThemMoiBinhLuan";
        private readonly string _ChiTietLike = "api/QuanLyBaiDang/ChiTietLike";
        private readonly string _XoaLike = "api/QuanLyBaiDang/XoaLike";
        private readonly string _ThemMoiLike = "api/QuanLyBaiDang/ThemMoiLike";
        private readonly string _DanhSachBaiDangCungChuyenMuc = "api/QuanLyBaiDang/DanhSachBaiDangCungChuyenMuc";
        private readonly string _DuyetAdmin = "api/QuanLyBaiDang/DuyetAdmin";
        #endregion


        public async Task<Response> CapNhat(tbl_PostModel requestModel)
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

        public async Task<Response> CapNhatLuotXem(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CapNhatLuotXem, requestModel);
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

        public async Task<tbl_PostModel> ChiTiet(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_PostModel>(resultAPI.result.ToString());
                }
                return new tbl_PostModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_PostModel();
            }
        }

        public async Task<List<tbl_LikePostModel>> ChiTietLike(tbl_LikePostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTietLike, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_LikePostModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_LikePostModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_LikePostModel>();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangBTV(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBaiDangBTV, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_PostModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_PostModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_PostModel>();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangCungChuyenMuc(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBaiDangCungChuyenMuc, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_PostModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_PostModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_PostModel>();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangMoi(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBaiDangMoi, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_PostModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_PostModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_PostModel>();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangPV(tbl_PostModel requestModel)
        {

            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBaiDangPV, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_PostModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_PostModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_PostModel>();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangTKGD(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBaiDangTKGD, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_PostModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_PostModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_PostModel>();
            }
        }

        public async Task<List<tbl_CommentModel>> DanhSachBinhLuan(tbl_CommentModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBinhLuan, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_CommentModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_CommentModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_CommentModel>();
            }
        }

        public async Task<Response> DuyetAdmin(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DuyetAdmin, requestModel);
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

        public async Task<Response> IsBTVDuyetHuyDuyet(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_IsBTVDuyetHuyDuyet, requestModel);
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

        public async Task<Response> IsPVDuyetHuyDuyet(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_IsPVDuyetHuyDuyet, requestModel);
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

        public async Task<Response> IsTK_GDDuyetHuyDuyet(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_IsTK_GDDuyetHuyDuyet, requestModel);
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

        public async Task<Response> IsTK_GDTraLai(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_IsTK_GDTraLai, requestModel);
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

        public async Task<Response> IsXuatBanBaiBao(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_IsXuatBanBaiBao, requestModel);
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

        public async Task<Response> ThemMoi(tbl_PostModel requestModel)
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

        public async Task<Response> ThemMoiBinhLuan(tbl_CommentModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiBinhLuan, requestModel);
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

        public async Task<Response> ThemMoiLike(tbl_LikePostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiLike, requestModel);
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

        public async Task<Response> TinTucMoi(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TinTucMoi, requestModel);
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

        public async Task<Response> Xoa(tbl_PostModel requestModel)
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

        public async Task<Response> XoaLike(tbl_LikePostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaLike, requestModel);
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
