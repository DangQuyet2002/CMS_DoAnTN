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
    public class LienKetGioiThieuRepository : ILienKetGioiThieuRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_LienKetGioiThieu_CapNhat = "tbl_LienKetGioiThieu_CapNhat";
        private readonly string _tbl_LienKetGioiThieu_ChiTiet = "tbl_LienKetGioiThieu_ChiTiet";
        private readonly string _tbl_LienKetGioiThieu_DanhSach = "tbl_LienKetGioiThieu_DanhSach";
        private readonly string _tbl_LienKetGioiThieu_ThemMoi = "tbl_LienKetGioiThieu_ThemMoi";
        private readonly string _tbl_LienKetGioiThieu_Xoa = "tbl_LienKetGioiThieu_Xoa";
        private readonly string _tbl_LienKetGioiThieu_CapNhatSTT = "tbl_LienKetGioiThieu_CapNhatSTT";
        #endregion

        public LienKetGioiThieuRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_LienKetGioiThieuModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Url", requestModel.Url);
                parameters.Add("STT", requestModel.STT);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_LienKetGioiThieu_CapNhat, parameters);

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

        public async Task<Response> CapNhatSTT(tbl_LienKetGioiThieuModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("STT", requestModel.STT);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_LienKetGioiThieu_CapNhatSTT, parameters);

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

        public async Task<tbl_LienKetGioiThieuModel> ChiTiet(tbl_LienKetGioiThieuModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<tbl_LienKetGioiThieuModel>(_tbl_LienKetGioiThieu_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_LienKetGioiThieuModel();
            }
        }

        public async Task<BaseRespone<tbl_LienKetGioiThieuModel>> DanhSach(tbl_LienKetGioiThieuModel requestModel)
        {
            try
            {
                BaseRespone<tbl_LienKetGioiThieuModel> Respone = new BaseRespone<tbl_LienKetGioiThieuModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("start", requestModel.start);
                parameters.Add("length", requestModel.length);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_LienKetGioiThieu_DanhSach, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_LienKetGioiThieuModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_LienKetGioiThieuModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_LienKetGioiThieuModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("STT", requestModel.STT);
                parameters.Add("Url", requestModel.Url);
                var result = await _baseRepository.GetValue<int>(_tbl_LienKetGioiThieu_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_LienKetGioiThieuModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_LienKetGioiThieu_Xoa, parameters);

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
