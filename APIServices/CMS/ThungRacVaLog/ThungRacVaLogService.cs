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
    public class ThungRacVaLogService : IThungRacVaLogService
    {

        #region API
        private readonly string _ChiTiet = "api/ThungRacVaLog/ChiTiet";
        private readonly string _DanhSachLog = "api/ThungRacVaLog/DanhSachLog";
        private readonly string _DanhSachAudioXoa = "api/ThungRacVaLog/DanhSachAudioXoa";
        private readonly string _DanhSachBaiDangXoa = "api/ThungRacVaLog/DanhSachBaiDangXoa";
        private readonly string _DanhSachThuVienAnhXoa = "api/ThungRacVaLog/DanhSachThuVienAnhXoa";
        private readonly string _DanhSachVanBanXoa = "api/ThungRacVaLog/DanhSachVanBanXoa";
        private readonly string _DanhSachVideoXoa = "api/ThungRacVaLog/DanhSachVideoXoa";
        private readonly string _KhoiPhucAnh = "api/ThungRacVaLog/KhoiPhucAnh";
        private readonly string _KhoiPhucAudio = "api/ThungRacVaLog/KhoiPhucAudio";
        private readonly string _KhoiPhucBaiDang = "api/ThungRacVaLog/KhoiPhucBaiDang";
        private readonly string _KhoiPhucVanBan = "api/ThungRacVaLog/KhoiPhucVanBan";
        private readonly string _KhoiPhucVideo = "api/ThungRacVaLog/KhoiPhucVideo";
        #endregion

        public async Task<Log4NetLogModel> ChiTiet(Log4NetLogModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<Log4NetLogModel>(resultAPI.result.ToString());
                }
                return new Log4NetLogModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new Log4NetLogModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienAudioModel>> DanhSachAudioXoa(tbl_ThuVienAudioModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachAudioXoa, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_ThuVienAudioModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_ThuVienAudioModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_ThuVienAudioModel>();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangXoa(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachBaiDangXoa, requestModel);
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

        public async Task<BaseRespone<Log4NetLogModel>> DanhSachLog(Log4NetLogModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachLog, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<Log4NetLogModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<Log4NetLogModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<Log4NetLogModel>();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienAnhModel>> DanhSachThuVienAnhXoa(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachThuVienAnhXoa, requestModel);
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

        public async Task<BaseRespone<tbl_VanBanModel>> DanhSachVanBanXoa(tbl_VanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachVanBanXoa, requestModel);
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

        public async Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSachVideoXoa(tbl_ThuVienVideoModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachVideoXoa, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_ThuVienVideoModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_ThuVienVideoModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_ThuVienVideoModel>();
            }
        }

        public async Task<Response> KhoiPhucAnh(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_KhoiPhucAnh, requestModel);
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

        public async Task<Response> KhoiPhucAudio(tbl_ThuVienAudioModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_KhoiPhucAudio, requestModel);
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

        public async Task<Response> KhoiPhucBaiDang(tbl_PostModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_KhoiPhucBaiDang, requestModel);
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

        public async Task<Response> KhoiPhucVanBan(tbl_VanBanModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_KhoiPhucVanBan, requestModel);
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

        public async Task<Response> KhoiPhucVideo(tbl_ThuVienVideoModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_KhoiPhucVideo, requestModel);
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
