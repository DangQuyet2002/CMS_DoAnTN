using Dapper;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS
{
    public class PhanQuyenService : IPhanQuyenService
    {
        #region API
        private readonly string _CapNhatRole = "api/PhanQuyen/CapNhatRole";
        private readonly string _DanhSachMenu = "api/PhanQuyen/DanhSachMenu";
        private readonly string _DanhSachRole = "api/PhanQuyen/DanhSachRole";
        private readonly string _DanhSachRoleMenu = "api/PhanQuyen/DanhSachRoleMenu";
        private readonly string _DanhSachRoleUser = "api/PhanQuyen/DanhSachRoleUser";
        private readonly string _ThemMoiMenuRole = "api/PhanQuyen/ThemMoiMenuRole";
        private readonly string _ThemMoiRole = "api/PhanQuyen/ThemMoiRole";
        private readonly string _ThemMoiUserRole = "api/PhanQuyen/ThemMoiUserRole";
        private readonly string _XoaMenuRole = "api/PhanQuyen/XoaMenuRole";
        private readonly string _XoaRole = "api/PhanQuyen/XoaRole";
        private readonly string _XoaUserRole = "api/PhanQuyen/XoaUserRole";
        #endregion
        public async Task<Response> CapNhatRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CapNhatRole, requestModel);
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

        public async Task<List<tbl_RoleModel>> DanhSachMenu(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachMenu, requestModel);
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

        public async Task<List<tbl_RoleModel>> DanhSachRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachRole, requestModel);
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

        public async Task<List<tbl_RoleModel>> DanhSachRoleMenu(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachRoleMenu, requestModel);
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

        public async Task<List<tbl_RoleModel>> DanhSachRoleUser(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachRoleUser, requestModel);
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

        public async Task<Response> ThemMoiMenuRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiMenuRole, requestModel);
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

        public async Task<Response> ThemMoiRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiRole, requestModel);
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

        public async Task<Response> ThemMoiUserRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_ThemMoiUserRole, requestModel);
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

        public async Task<Response> XoaMenuRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaMenuRole, requestModel);
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

        public async Task<Response> XoaRole(tbl_RoleModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaRole, requestModel);
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

        public async Task<Response> XoaUserRole(tbl_RoleModel requestModel)
        {

            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_XoaUserRole, requestModel);
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
