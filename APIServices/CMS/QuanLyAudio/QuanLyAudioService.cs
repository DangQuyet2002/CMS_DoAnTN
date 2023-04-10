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
    public class QuanLyAudioService : IQuanLyAudioService
    {
        #region API
        private readonly string _CapNhat = "api/QuanLyAudio/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyAudio/ChiTiet";
        private readonly string _DanhSach = "api/QuanLyAudio/DanhSach";
        private readonly string _ThemMoi = "api/QuanLyAudio/ThemMoi";
        private readonly string _Xoa = "api/QuanLyAudio/Xoa";
        #endregion

        public async Task<Response> CapNhat(tbl_ThuVienAudioModel requestModel)
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

        public async Task<tbl_ThuVienAudioModel> ChiTiet(tbl_ThuVienAudioModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_ThuVienAudioModel>(resultAPI.result.ToString());
                }
                return new tbl_ThuVienAudioModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_ThuVienAudioModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienAudioModel>> DanhSach(tbl_ThuVienAudioModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
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

        public async Task<Response> ThemMoi(tbl_ThuVienAudioModel requestModel)
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

        public async Task<Response> Xoa(tbl_ThuVienAudioModel requestModel)
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
