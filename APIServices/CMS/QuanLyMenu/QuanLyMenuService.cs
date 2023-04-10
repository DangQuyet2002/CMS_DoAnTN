using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace APIServices.CMS.QuanLyMenu
{
    public class QuanLyMenuService : IQuanLyMenuService
    {
        #region API
        private readonly string _CapNhatSTT = "api/QuanLyMenu/CapNhatSTT";
        private readonly string _DanhSachSettingMenu = "api/QuanLyMenu/DanhSachSettingMenu";
        private readonly string _DanhSachTheoIdSetting = "api/QuanLyMenu/DanhSachTheoIdSetting";
        private readonly string _ThemMoi = "api/QuanLyMenu/ThemMoi";
        private readonly string _Xoa = "api/QuanLyMenu/Xoa";
        #endregion


        public async Task<Response> CapNhatSTT(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_CapNhatSTT, requestModel);
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

        public async Task<List<tbl_SettingMenu_CategoryModel>> DanhSachSettingMenu(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachSettingMenu, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_SettingMenu_CategoryModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_SettingMenu_CategoryModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_SettingMenu_CategoryModel>();
            }
        }

        public async Task<List<tbl_SettingMenu_CategoryModel>> DanhSachTheoIdSetting(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                var resultAPI = await RestfulApi<Response>.PostAsync(_DanhSachTheoIdSetting, requestModel);
                if (resultAPI.code == ResponseCode.SUCCESS)
                {
                    return JsonConvert.DeserializeObject<List<tbl_SettingMenu_CategoryModel>>(resultAPI.result.ToString());
                }
                return new List<tbl_SettingMenu_CategoryModel>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<tbl_SettingMenu_CategoryModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_SettingMenu_CategoryModel requestModel)
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

        public async Task<Response> Xoa(tbl_SettingMenu_CategoryModel requestModel)
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
