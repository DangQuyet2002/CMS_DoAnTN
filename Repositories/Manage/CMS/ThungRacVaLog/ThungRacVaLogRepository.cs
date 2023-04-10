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
    public class ThungRacVaLogRepository : IThungRacVaLogRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        public ThungRacVaLogRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        #region Store Procedure Name
        private readonly string _Log4NetLog_DanhSachLog = "Log4NetLog_DanhSachLog";
        private readonly string _Log4NetLog_ChiTiet = "Log4NetLog_ChiTiet";
        private readonly string _tbl_Post_DanhSach_Xoa = "tbl_Post_DanhSach_Xoa";
        private readonly string _tbl_Post_KhoiPhucBaiDang = "tbl_Post_KhoiPhucBaiDang";
        private readonly string _tbl_ThuVienAnh_DanhSachXoa = "tbl_ThuVienAnh_DanhSachXoa";
        private readonly string _tbl_ThuVienAnh_KhoiPhuc = "tbl_ThuVienAnh_KhoiPhuc";
        private readonly string _tbl_ThuVienAudio_DanhSachXoa = "tbl_ThuVienAudio_DanhSachXoa";
        private readonly string _tbl_ThuVienAudio_KhoiPhuc = "tbl_ThuVienAudio_KhoiPhuc";
        private readonly string _tbl_ThuVienVideo_DanhSachXoa = "tbl_ThuVienVideo_DanhSachXoa";
        private readonly string _tbl_ThuVienVideo_KhoiPhuc = "tbl_ThuVienVideo_KhoiPhuc";
        private readonly string _tbl_VanBan_DanhSachXoa = "tbl_VanBan_DanhSachXoa";
        private readonly string _tbl_VanBan_KhoiPhuc = "tbl_VanBan_KhoiPhuc";

        #endregion

        public async Task<BaseRespone<Log4NetLogModel>> DanhSachLog(Log4NetLogModel requestModel)
        {
            try
            {
                BaseRespone<Log4NetLogModel> Respone = new BaseRespone<Log4NetLogModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("txtKey", requestModel.txtKey);
                parameters.Add("StartDate", requestModel.StartDate);
                parameters.Add("EndDate", requestModel.EndDate);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_Log4NetLog_DanhSachLog, parameters, reader =>
                {
                    Respone.Data = reader.Read<Log4NetLogModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<Log4NetLogModel>();
            }
        }

        public async Task<Log4NetLogModel> ChiTiet(Log4NetLogModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<Log4NetLogModel>(_Log4NetLog_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new Log4NetLogModel();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangXoa(tbl_PostModel requestModel)
        {
            try
            {
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("lstIdCategory", requestModel.lstIdCategory);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Post_DanhSach_Xoa, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_PostModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_PostModel>();
            }
        }

        public async Task<Response> KhoiPhucBaiDang(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_KhoiPhucBaiDang, parameters);

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

        public async Task<BaseRespone<tbl_ThuVienAnhModel>> DanhSachThuVienAnhXoa(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                BaseRespone<tbl_ThuVienAnhModel> Respone = new BaseRespone<tbl_ThuVienAnhModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_ThuVienAnh_DanhSachXoa, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_ThuVienAnhModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_ThuVienAnhModel>();
            }
        }

        public async Task<Response> KhoiPhucAnh(tbl_ThuVienAnhModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdateDate", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_KhoiPhuc, parameters);

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

        public async Task<BaseRespone<tbl_ThuVienAudioModel>> DanhSachAudioXoa(tbl_ThuVienAudioModel requestModel)
        {
            try
            {
                BaseRespone<tbl_ThuVienAudioModel> Respone = new BaseRespone<tbl_ThuVienAudioModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_ThuVienAudio_DanhSachXoa, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_ThuVienAudioModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_ThuVienAudioModel>();
            }
        }

        public async Task<Response> KhoiPhucAudio(tbl_ThuVienAudioModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdateDate", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAudio_KhoiPhuc, parameters);

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

        public async Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSachVideoXoa(tbl_ThuVienVideoModel requestModel)
        {
            try
            {
                BaseRespone<tbl_ThuVienVideoModel> Respone = new BaseRespone<tbl_ThuVienVideoModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_ThuVienVideo_DanhSachXoa, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_ThuVienVideoModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_ThuVienVideoModel>();
            }
        }

        public async Task<Response> KhoiPhucVideo(tbl_ThuVienVideoModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdateDate", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienVideo_KhoiPhuc, parameters);

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

        public async Task<BaseRespone<tbl_VanBanModel>> DanhSachVanBanXoa(tbl_VanBanModel requestModel)
        {
            try
            {
                BaseRespone<tbl_VanBanModel> Respone = new BaseRespone<tbl_VanBanModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_VanBan_DanhSachXoa, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_VanBanModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_VanBanModel>();
            }
        }

        public async Task<Response> KhoiPhucVanBan(tbl_VanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdateDate", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_VanBan_KhoiPhuc, parameters);

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
