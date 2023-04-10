using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public class QuanLyDanhMucRepository : IQuanLyDanhMucRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_Category_ThemMoi = "tbl_Category_ThemMoi";
        private readonly string _tbl_Category_CapNhat = "tbl_Category_CapNhat";
        private readonly string _tbl_Category_Xoa = "tbl_Category_Xoa";
        private readonly string _tbl_Category_ChiTiet = "tbl_Category_ChiTiet";
        private readonly string _tbl_Category_DanhSach = "tbl_Category_DanhSach";
        private readonly string _tbl_Category_AllDanhSach = "tbl_Category_AllDanhSach";
        private readonly string _tbl_Category_ChiTietChuyenMucBaiViet = "tbl_Category_ChiTietChuyenMucBaiViet";

        #endregion

        public QuanLyDanhMucRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }

        public async Task<Response> CapNhat(tbl_CategoryModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", requestModel.Name);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("ParentID", requestModel.ParentID);
                parameters.Add("Url", requestModel.IsDelete);
                parameters.Add("ID", requestModel.ID);
                parameters.Add("IsDelete", requestModel.IsDelete);
                var result = await _baseRepository.GetValue<int>(_tbl_Category_CapNhat, parameters);

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

        public async Task<tbl_CategoryModel> ChiTiet(tbl_CategoryModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", requestModel.ID);
                return (await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_ChiTiet, parameters)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_CategoryModel();
            }
        }

        public async Task<tbl_CategoryModel> ChiTietChuyenMucBaiViet(tbl_CategoryModel requestModel)
        {

            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdPost", requestModel.ID);
                return (await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_ChiTietChuyenMucBaiViet, parameters)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_CategoryModel();
            }
        }

        public async Task<List<tbl_CategoryModel>> DanhSach(tbl_CategoryModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_DanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_CategoryModel>();
            }
        }

        public async Task<List<tbl_CategoryModel>> DanhSachAll(tbl_CategoryModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_CategoryModel>(_tbl_Category_AllDanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_CategoryModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_CategoryModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", requestModel.Name);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("CreatedAt", requestModel.CreatedAt);
                parameters.Add("CreatedBy", requestModel.CreatedBy);
                parameters.Add("ParentID", requestModel.ParentID);
                parameters.Add("Url", requestModel.IsDelete);
                parameters.Add("IsDelete", requestModel.IsDelete);
                var result = await _baseRepository.GetValue<int>(_tbl_Category_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_CategoryModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Category_Xoa, parameters);

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
