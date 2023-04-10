using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public class HomeAdminRepository : IHomeAdminRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_Post_TongBaiDang = "tbl_Post_TongBaiDang";
        private readonly string _tbl_User_TongNguoiDung = "tbl_User_TongNguoiDung";
        private readonly string _tbl_Comment_TongComment = "tbl_Comment_TongComment";
        private readonly string _tbl_Post_TongLuotXem = "tbl_Post_TongLuotXem";
        private readonly string _tbl_Category_topLuotXem = "tbl_Category_topLuotXem";
        private readonly string _tbl_Category_topLuotThich = "tbl_Category_topLuotThich";
        private readonly string _tbl_Category_topLuotBinhLuan = "tbl_Category_topLuotBinhLuan";
        private readonly string _tbl_DanhSachMenuUser = "tbl_DanhSachMenuUser";
        private readonly string _tbl_Role_User_QuyenNguoiDung = "tbl_Role_User_QuyenNguoiDung";

        #endregion

        public HomeAdminRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }

        public async Task<List<tbl_RoleModel>> DanhSachMenu(int IdUser)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdUser", IdUser);
                return await _baseRepository.GetList<tbl_RoleModel>(_tbl_DanhSachMenuUser, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<List<tbl_RoleModel>> DanhSachQuyenNguoiDung(int IdUser)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("IdUser", IdUser);
                return await _baseRepository.GetList<tbl_RoleModel>(_tbl_Role_User_QuyenNguoiDung, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_RoleModel>();
            }
        }

        public async Task<Response> TongBaiDang()
        {
            Response message = new Response();
            try
            {
                var parameters = new DynamicParameters();
                var result = await _baseRepository.GetValue<int>(_tbl_Post_TongBaiDang, parameters);

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

        public async Task<Response> TongComment()
        {
            Response message = new Response();
            try
            {
                var parameters = new DynamicParameters();
                var result = await _baseRepository.GetValue<int>(_tbl_Comment_TongComment, parameters);

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

        public async Task<Response> TongLuotXem()
        {
            Response message = new Response();
            try
            {
                var parameters = new DynamicParameters();
                var result = await _baseRepository.GetValue<int>(_tbl_Post_TongLuotXem, parameters);

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

        public async Task<Response> TongNguoiDung()
        {
            Response message = new Response();
            try
            {
                var parameters = new DynamicParameters();
                var result = await _baseRepository.GetValue<int>(_tbl_User_TongNguoiDung, parameters);

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

        public async Task<List<tbl_CategoryModel>> TopDanhMucBLMN()
        {
            try
            {
                var parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_topLuotBinhLuan, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_CategoryModel>();
            }
        }

        public async Task<List<tbl_CategoryModel>> TopDanhMucThichMN()
        {
            try
            {
                var parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_topLuotThich, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_CategoryModel>();
            }
        }

        public async Task<List<tbl_CategoryModel>> TopDanhMucXemMN()
        {
            try
            {
                var parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_topLuotXem, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_CategoryModel>();
            }
        }
    }
}
