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
    public class CacCapHoiRepository : ICacCapHoiRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_CacCapHoi_CapNhat = "tbl_CacCapHoi_CapNhat";
        private readonly string _tbl_CacCapHoi_ChiTiet = "tbl_CacCapHoi_ChiTiet";
        private readonly string _tbl_CacCapHoi_DanhSach = "tbl_CacCapHoi_DanhSach";
        private readonly string _tbl_CacCapHoi_ThemMoi = "tbl_CacCapHoi_ThemMoi";
        private readonly string _tbl_CacCapHoi_Xoa = "tbl_CacCapHoi_Xoa";
        private readonly string _tbl_CacCapHoi_CapNhatSTT = "tbl_CacCapHoi_CapNhatSTT";

        #endregion

        public CacCapHoiRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_CacCapHoiModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Url", requestModel.Url);
                parameters.Add("STT", requestModel.STT);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_CacCapHoi_CapNhat, parameters);

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

        public async Task<Response> CapNhatSTT(tbl_CacCapHoiModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("STT", requestModel.STT);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_CacCapHoi_CapNhatSTT, parameters);

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

        public async Task<tbl_CacCapHoiModel> ChiTiet(tbl_CacCapHoiModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<tbl_CacCapHoiModel>(_tbl_CacCapHoi_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_CacCapHoiModel();
            }
        }

        public async Task<BaseRespone<tbl_CacCapHoiModel>> DanhSach(tbl_CacCapHoiModel requestModel)
        {
            try
            {
                BaseRespone<tbl_CacCapHoiModel> Respone = new BaseRespone<tbl_CacCapHoiModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("start", requestModel.start);
                parameters.Add("length", requestModel.length);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_CacCapHoi_DanhSach, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_CacCapHoiModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_CacCapHoiModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_CacCapHoiModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Url", requestModel.Url);
                parameters.Add("STT", requestModel.STT);
                var result = await _baseRepository.GetValue<int>(_tbl_CacCapHoi_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_CacCapHoiModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_CacCapHoi_Xoa, parameters);

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
