using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public class PhanQuyenRepository : IPhanQuyenRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_Role_DanhSach = "tbl_Role_DanhSach";
        private readonly string _tbl_Role_ThemMoi = "tbl_Role_ThemMoi";
        private readonly string _tbl_Role_CapNhat = "tbl_Role_CapNhat";
        private readonly string _tbl_Role_Xoa = "tbl_Role_Xoa";
        private readonly string _tbl_Role_User_ThemMoi = "tbl_Role_User_ThemMoi";
        private readonly string _tbl_Role_User_Xoa = "tbl_Role_User_Xoa";
        private readonly string _tbl_Role_User_TheoUser = "tbl_Role_User_TheoUser";
        private readonly string _tbl_Menu_Role_ThemMoi = "tbl_Menu_Role_ThemMoi";
        private readonly string _tbl_Menu_Role_Xoa = "tbl_Menu_Role_Xoa";
        private readonly string _tbl_Menu_Role_TheoRole = "tbl_Menu_Role_TheoRole";
        private readonly string _tbl_Menu_DanhSach = "tbl_Menu_DanhSach";

        #endregion

        public PhanQuyenRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }

        public async Task<Response> CapNhatRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Ten", requestModel.Ten);
                parameters.Add("ID", requestModel.Id);

                var result = await _baseRepository.GetValue<int>(_tbl_Role_CapNhat, parameters);

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

        public async Task<List<tbl_RoleModel>> DanhSachMenu(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_RoleModel>(_tbl_Menu_DanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<List<tbl_RoleModel>> DanhSachRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_RoleModel>(_tbl_Role_DanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<List<tbl_RoleModel>> DanhSachRoleMenu(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdRole ", requestModel.IdRole);

                return await _baseRepository.GetList<tbl_RoleModel>(_tbl_Menu_Role_TheoRole, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<List<tbl_RoleModel>> DanhSachRoleUser(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdUser", requestModel.IdUser);
                return await _baseRepository.GetList<tbl_RoleModel>(_tbl_Role_User_TheoUser, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<Response> ThemMoiMenuRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdMenu", requestModel.IdMenu);
                parameters.Add("IdRole", requestModel.IdRole);
                var result = await _baseRepository.GetValue<int>(_tbl_Menu_Role_ThemMoi, parameters);

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

        public async Task<Response> ThemMoiRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Ten", requestModel.Ten);
                var result = await _baseRepository.GetValue<int>(_tbl_Role_ThemMoi, parameters);

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

        public async Task<Response> ThemMoiUserRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdUser", requestModel.IdUser);
                parameters.Add("IdRole", requestModel.IdRole);
                var result = await _baseRepository.GetValue<int>(_tbl_Role_User_ThemMoi, parameters);

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

        public async Task<Response> XoaMenuRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdMenu", requestModel.IdMenu);
                parameters.Add("IdRole", requestModel.IdRole);
                var result = await _baseRepository.GetValue<int>(_tbl_Menu_Role_Xoa, parameters);

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

        public async Task<Response> XoaRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", requestModel.Id);

                var result = await _baseRepository.GetValue<int>(_tbl_Role_Xoa, parameters);

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

        public async Task<Response> XoaUserRole(tbl_RoleModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdUser", requestModel.IdUser);
                parameters.Add("IdRole", requestModel.IdRole);
                var result = await _baseRepository.GetValue<int>(_tbl_Role_User_Xoa, parameters);

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
