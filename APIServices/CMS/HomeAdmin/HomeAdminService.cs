using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.HomeAdmin
{
    public class HomeAdminService : IHomeAdminService
    {

        #region API
        private readonly string _TongBaiDang = "api/HomeAdmin/TongBaiDang";
        private readonly string _TongComment = "api/HomeAdmin/TongComment";
        private readonly string _TongLuotXem = "api/HomeAdmin/TongLuotXem";
        private readonly string _TongNguoiDung = "api/HomeAdmin/TongNguoiDung";
        private readonly string _TopDanhMucThichMN = "api/HomeAdmin/TopDanhMucThichMN";
        private readonly string _TopDanhMucXemMN = "api/HomeAdmin/TopDanhMucXemMN";
        private readonly string _TopDanhMucBLMN = "api/HomeAdmin/TopDanhMucBLMN";
        private readonly string _DanhSachMenu = "api/HomeAdmin/DanhSachMenu";
        private readonly string _DanhSachQuyenNguoiDung = "api/HomeAdmin/DanhSachQuyenNguoiDung";

        #endregion

        public async Task<List<tbl_RoleModel>> DanhSachMenu(int IdUser)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.GetAsync(_DanhSachMenu + "?IdUser=" + IdUser, null);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_RoleModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_RoleModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<List<tbl_RoleModel>> DanhSachQuyenNguoiDung(int IdUser)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.GetAsync(_DanhSachQuyenNguoiDung + "?IdUser=" + IdUser, null);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_RoleModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_RoleModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<Response> TongBaiDang()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TongBaiDang, null);
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

        public async Task<Response> TongComment()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TongComment, null);
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

        public async Task<Response> TongLuotXem()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TongLuotXem, null);
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

        public async Task<Response> TongNguoiDung()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TongNguoiDung, null);
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

        public async Task<List<tbl_CategoryModel>> TopDanhMucBLMN()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TopDanhMucBLMN, null);
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

        public async Task<List<tbl_CategoryModel>> TopDanhMucThichMN()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TopDanhMucThichMN, null);
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

        public async Task<List<tbl_CategoryModel>> TopDanhMucXemMN()
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_TopDanhMucXemMN, null);
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
    }
}
