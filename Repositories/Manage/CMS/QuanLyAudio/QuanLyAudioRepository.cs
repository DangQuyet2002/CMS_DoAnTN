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
    public class QuanLyAudioRepository : IQuanLyAudioRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_ThuVienAudio_CapNhat = "tbl_ThuVienAudio_CapNhat";
        private readonly string _tbl_ThuVienAudio_ChiTiet = "tbl_ThuVienAudio_ChiTiet";
        private readonly string _tbl_ThuVienAudio_DanhSach = "tbl_ThuVienAudio_DanhSach";
        private readonly string _tbl_ThuVienAudio_ThemMoi = "tbl_ThuVienAudio_ThemMoi";
        private readonly string _tbl_ThuVienAudio_Xoa = "tbl_ThuVienAudio_Xoa";

        #endregion

        public QuanLyAudioRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_ThuVienAudioModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Audio", requestModel.Audio);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("NgayDang", requestModel.NgayDang);
                parameters.Add("ChuThich", requestModel.ChuThich);

                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAudio_CapNhat, parameters);

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

        public async Task<tbl_ThuVienAudioModel> ChiTiet(tbl_ThuVienAudioModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<tbl_ThuVienAudioModel>(_tbl_ThuVienAudio_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_ThuVienAudioModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienAudioModel>> DanhSach(tbl_ThuVienAudioModel requestModel)
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
                parameters.Add("IsCheckAudioMoi", requestModel.IsCheckAudioMoi);
                parameters.Add("lstIdAudioMoi", requestModel.lstIdAudioMoi);
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);

                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_ThuVienAudio_DanhSach, parameters, reader =>
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

        public async Task<Response> ThemMoi(tbl_ThuVienAudioModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Audio", requestModel.Audio);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("CreatedBy ", requestModel.CreatedBy);
                parameters.Add("CreatedDate ", requestModel.CreatedDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("NgayDang", requestModel.NgayDang);
                parameters.Add("ChuThich", requestModel.ChuThich);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAudio_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_ThuVienAudioModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAudio_Xoa, parameters);

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
