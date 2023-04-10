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
    public class UserService : IUserService
    {

        #region API
        private readonly string _DangNhap = "api/User/DangNhap";
        private readonly string _DangNhapGoole = "api/User/DangNhapGoole";
        private readonly string _DangKyTK = "api/User/DangKyTK";
        private readonly string _DangKyTKGoole = "api/User/DangKyTKGoole";
        private readonly string _DangNhapTK = "api/User/DangNhapTK";
        private readonly string _CapNhat = "api/User/CapNhat";
        private readonly string _CheckUser = "api/User/CheckUser";
        private readonly string _ChiTiet = "api/User/ChiTiet";
        private readonly string _DanhSach = "api/User/DanhSach";
        private readonly string _ThemMoi = "api/User/ThemMoi";
        private readonly string _CheckMail = "api/User/CheckMail";
        private readonly string _Xoa = "api/User/Xoa";
        public async Task<Response> CapNhat(tbl_UserModel requestModel)
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

        public async Task<List<tbl_UserModel>> CheckMail(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CheckMail, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_UserModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_UserModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_UserModel>();
            }
        }

        public async Task<List<tbl_UserModel>> CheckUser(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CheckUser, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_UserModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_UserModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_UserModel>();
            }
        }

        public async Task<tbl_UserModel> ChiTiet(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ChiTiet, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_UserModel>(resultAPI.result.ToString());
                }
                return new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_UserModel();
            }
        }

        public async Task<Response> DangKyTK(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DangKyTK, requestModel);
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

        public async Task<Response> DangKyTKGoole(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DangKyTKGoole, requestModel);
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
        public async Task<tbl_UserModel> DangNhap(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DangNhap, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_UserModel>(resultAPI.result.ToString());
                }
                return new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_UserModel();
            }
        }

        public async Task<tbl_UserModel> DangNhapGoole(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DangNhapGoole, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_UserModel>(resultAPI.result.ToString());
                }
                return new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_UserModel();
            }
        }

        public async Task<tbl_UserModel> DangNhapTK(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DangNhapTK, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<tbl_UserModel>(resultAPI.result.ToString());
                }
                return new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new tbl_UserModel();
            }
        }

        public async Task<BaseRespone<tbl_UserModel>> DanhSach(tbl_UserModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSach, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<BaseRespone<tbl_UserModel>>(resultAPI.result.ToString());
                }
                return new BaseRespone<tbl_UserModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new BaseRespone<tbl_UserModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_UserModel requestModel)
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

        public async Task<Response> Xoa(tbl_UserModel requestModel)
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
