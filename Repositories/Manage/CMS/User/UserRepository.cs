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
    public class UserRepository : IUserRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_user_DangNhap = "tbl_user_DangNhap";
        private readonly string _tbl_User_CheckEmail = "tbl_User_CheckEmail";
        private readonly string _tbl_User_ThemMoiKHGoole = "tbl_User_ThemMoiKHGoole";
        private readonly string _tbl_User_ThemMoiKH = "tbl_User_ThemMoiKH";
        private readonly string _tbl_user_DangNhapTK = "tbl_user_DangNhapTK";
        private readonly string _tbl_User_CapNhat = "tbl_User_CapNhat";
        private readonly string _tbl_User_CheckUser = "tbl_User_CheckUser";
        private readonly string _tbl_User_ChiTiet = "tbl_User_ChiTiet";
        private readonly string _tbl_User_ThemMoi = "tbl_User_ThemMoi";
        private readonly string _tbl_User_DanhSach = "tbl_User_DanhSach";
        private readonly string _tbl_User_Xoa = "tbl_User_Xoa";
        #endregion

        public UserRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }

        public async Task<Response> CapNhat(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", requestModel.UserName);
                parameters.Add("Email", requestModel.Email);
                parameters.Add("Phone", requestModel.Phone);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("ID ", requestModel.ID);

                var result = await _baseRepository.GetValue<int>(_tbl_User_CapNhat, parameters);

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

        public async Task<List<tbl_UserModel>> CheckMail(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", requestModel.UserName);
                return await _baseRepository.GetList<tbl_UserModel>(_tbl_User_CheckEmail, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_UserModel>();
            }
        }

        public async Task<List<tbl_UserModel>> CheckUser(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", requestModel.UserName);
                return await _baseRepository.GetList<tbl_UserModel>(_tbl_User_CheckUser, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_UserModel>();
            }
        }

        public async Task<tbl_UserModel> ChiTiet(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", requestModel.ID);
                var TTNguoiDung = await _baseRepository.GetList<tbl_UserModel>(_tbl_User_ChiTiet, parameters);
                return TTNguoiDung.Count() > 0 ? TTNguoiDung.FirstOrDefault() : new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_UserModel();
            }
        }

        public async Task<Response> DangKyTK(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", requestModel.Email);
                parameters.Add("UserName", requestModel.UserName);
                parameters.Add("Password", requestModel.Password);
                var result = await _baseRepository.GetValue<int>(_tbl_User_ThemMoiKH, parameters);

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

        public async Task<Response> DangKyTKGoole(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", requestModel.Email);
                parameters.Add("UserName", requestModel.UserName);
                parameters.Add("Image", requestModel.Image);
                var result = await _baseRepository.GetValue<int>(_tbl_User_ThemMoiKHGoole, parameters);

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

        public async Task<tbl_UserModel> DangNhap(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", requestModel.UserName);
                parameters.Add("Password", requestModel.Password);
                var TTNguoiDung = await _baseRepository.GetList<tbl_UserModel>(_tbl_user_DangNhap, parameters);
                return TTNguoiDung.Count() > 0 ? TTNguoiDung.FirstOrDefault() : new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_UserModel();
            }
        }

        public async Task<tbl_UserModel> DangNhapGoole(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", requestModel.Email);
                var TTNguoiDung = await _baseRepository.GetList<tbl_UserModel>(_tbl_User_CheckEmail, parameters);
                return TTNguoiDung.Count() > 0 ? TTNguoiDung.FirstOrDefault() : new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_UserModel();
            }
        }

        public async Task<tbl_UserModel> DangNhapTK(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", requestModel.UserName);
                parameters.Add("Password", requestModel.Password);
                var TTNguoiDung = await _baseRepository.GetList<tbl_UserModel>(_tbl_user_DangNhapTK, parameters);
                return TTNguoiDung.Count() > 0 ? TTNguoiDung.FirstOrDefault() : new tbl_UserModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_UserModel();
            }
        }

        public async Task<BaseRespone<tbl_UserModel>> DanhSach(tbl_UserModel requestModel)
        {
            try
            {
                BaseRespone<tbl_UserModel> Respone = new BaseRespone<tbl_UserModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("FullName", requestModel.FullName);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_User_DanhSach, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_UserModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_UserModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UserName", requestModel.UserName);

                parameters.Add("Password", requestModel.Password);
                parameters.Add("FullName", requestModel.FullName);
                parameters.Add("Email", requestModel.Email);
                parameters.Add("Phone", requestModel.Phone);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("CreatedAt", requestModel.CreatedAt);
                parameters.Add("CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>(_tbl_User_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_UserModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("ID", requestModel.ID);

                var result = await _baseRepository.GetValue<int>(_tbl_User_Xoa, parameters);

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
