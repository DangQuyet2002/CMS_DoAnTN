﻿using Models;
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
    public class QuanLyVideoService : IQuanLyVideoService
    {
        #region API
        private readonly string _CapNhat = "api/QuanLyVideo/CapNhat";
        private readonly string _ChiTiet = "api/QuanLyVideo/ChiTiet";
        private readonly string _DanhSach = "api/QuanLyVideo/DanhSach";
        private readonly string _ThemMoi = "api/QuanLyVideo/ThemMoi";
        private readonly string _Xoa = "api/QuanLyVideo/Xoa";
        #endregion

        public async Task<Response> CapNhat(tbl_ThuVienVideoModel requestModel)
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

        public async Task<tbl_ThuVienVideoModel> ChiTiet(tbl_ThuVienVideoModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_ThuVienVideoModel>(resultAPI.result.ToString());
                }
                return new tbl_ThuVienVideoModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_ThuVienVideoModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSach(tbl_ThuVienVideoModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
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

        public async Task<Response> ThemMoi(tbl_ThuVienVideoModel requestModel)
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

        public async Task<Response> Xoa(tbl_ThuVienVideoModel requestModel)
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
