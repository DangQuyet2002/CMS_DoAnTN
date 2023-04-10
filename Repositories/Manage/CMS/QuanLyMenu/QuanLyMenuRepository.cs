using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public class QuanLyMenuRepository : IQuanLyMenuRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_SettingMenu_Category_DanhSachTheo_IdSetting = "tbl_SettingMenu_Category_DanhSachTheo_IdSetting";
        private readonly string _tbl_SettingMenu_DanhSach = "tbl_SettingMenu_DanhSach";
        private readonly string _tbl_SettingMenu_Category_ThemMoi = "tbl_SettingMenu_Category_ThemMoi";
        private readonly string _tbl_SettingMenu_Category_CapNhatSTT = "tbl_SettingMenu_Category_CapNhatSTT";
        private readonly string _tbl_SettingMenu_Category_Xoa = "tbl_SettingMenu_Category_Xoa";
        #endregion
        public QuanLyMenuRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhatSTT(tbl_SettingMenu_CategoryModel requestModel)
        {

            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("STT ", requestModel.STT);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_SettingMenu_Category_CapNhatSTT, parameters);

                message.code = ResponseCode.SUCCESS;
                message.message = ResponseDetail.SUCCESSDETAIL;
                message.result = result;
                return message;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return message;
            }
        }

        public async Task<List<tbl_SettingMenu_CategoryModel>> DanhSachSettingMenu(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_SettingMenu_CategoryModel>(_tbl_SettingMenu_DanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_SettingMenu_CategoryModel>();
            }
        }

        public async Task<List<tbl_SettingMenu_CategoryModel>> DanhSachTheoIdSetting(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdSettingMenu", requestModel.IdSettingMenu);
                return await _baseRepository.GetList<tbl_SettingMenu_CategoryModel>(_tbl_SettingMenu_Category_DanhSachTheo_IdSetting, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_SettingMenu_CategoryModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_SettingMenu_CategoryModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdCategory", requestModel.IdCategory);
                parameters.Add("IdSettingMenu", requestModel.IdSettingMenu);
                var result = await _baseRepository.GetValue<int>(_tbl_SettingMenu_Category_ThemMoi, parameters);

                message.code = ResponseCode.SUCCESS;
                message.message = ResponseDetail.SUCCESSDETAIL;
                message.result = result;
                return message;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return message;
            }
        }

        public async Task<Response> Xoa(tbl_SettingMenu_CategoryModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_SettingMenu_Category_Xoa, parameters);

                message.code = ResponseCode.SUCCESS;
                message.message = ResponseDetail.SUCCESSDETAIL;
                message.result = result;
                return message;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return message;
            }
        }
    }
}
