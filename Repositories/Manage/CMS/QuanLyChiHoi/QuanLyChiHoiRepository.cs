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
    public class QuanLyChiHoiRepository : IQuanLyChiHoiRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_ChiHoiTT_DanhSach = "tbl_ChiHoiTT_DanhSach";
        private readonly string _tbl_ChiHoiTT_ThemMoi = "tbl_ChiHoiTT_ThemMoi";
        private readonly string _tbl_ChiHoiTT_Update = "tbl_ChiHoiTT_Update";
        private readonly string _tbl_ChiHoiTT_Xoa = "tbl_ChiHoiTT_Xoa";
        private readonly string _tbl_ChiHoiTT_ChiTiet = "tbl_ChiHoiTT_ChiTiet";

        #endregion

        public QuanLyChiHoiRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }

        public async Task<Response> CapNhat(tbl_ChiHoiTTModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Ten", requestModel.Ten);
                parameters.Add("Url", requestModel.Url);
                parameters.Add("ParentId", requestModel.ParentId);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ChiHoiTT_Update, parameters);

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

        public async Task<tbl_ChiHoiTTModel> ChiTiet(tbl_ChiHoiTTModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                return (await _baseRepository.GetList<tbl_ChiHoiTTModel>(_tbl_ChiHoiTT_ChiTiet, parameters)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_ChiHoiTTModel();
            }
        }

        public async Task<List<tbl_ChiHoiTTModel>> DanhSach(tbl_ChiHoiTTModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                return await _baseRepository.GetList<tbl_ChiHoiTTModel>(_tbl_ChiHoiTT_DanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_ChiHoiTTModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_ChiHoiTTModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Ten", requestModel.Ten);
                parameters.Add("Url", requestModel.Url);
                parameters.Add("ParentId", requestModel.ParentId);
                var result = await _baseRepository.GetValue<int>(_tbl_ChiHoiTT_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_ChiHoiTTModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ChiHoiTT_Xoa, parameters);

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
