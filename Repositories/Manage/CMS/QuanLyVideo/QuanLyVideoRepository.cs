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
    public class QuanLyVideoRepository : IQuanLyVideoRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_ThuVienVideo_CapNhat = "tbl_ThuVienVideo_CapNhat";
        private readonly string _tbl_ThuVienVideo_ChiTiet = "tbl_ThuVienVideo_ChiTiet";
        private readonly string _tbl_ThuVienVideo_DanhSach = "tbl_ThuVienVideo_DanhSach";
        private readonly string _tbl_ThuVienVideo_ThemMoi = "tbl_ThuVienVideo_ThemMoi";
        private readonly string _tbl_ThuVienVideo_Xoa = "tbl_ThuVienVideo_Xoa";

        #endregion

        public QuanLyVideoRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_ThuVienVideoModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Video", requestModel.Video);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("IsYouTube", requestModel.IsYouTube);
                parameters.Add("ChuThich", requestModel.ChuThich);
                parameters.Add("NgayDang ", requestModel.NgayDang);

                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienVideo_CapNhat, parameters);

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

        public async Task<tbl_ThuVienVideoModel> ChiTiet(tbl_ThuVienVideoModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<tbl_ThuVienVideoModel>(_tbl_ThuVienVideo_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_ThuVienVideoModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSach(tbl_ThuVienVideoModel requestModel)
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
                parameters.Add("IsCheckVideoMoi", requestModel.IsCheckVideoMoi);
                parameters.Add("lstIdVideoMoi", requestModel.lstIdVideoMoi);
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);

                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_ThuVienVideo_DanhSach, parameters, reader =>
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

        public async Task<Response> ThemMoi(tbl_ThuVienVideoModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("Video", requestModel.Video);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("CreatedBy ", requestModel.CreatedBy);
                parameters.Add("CreatedDate ", requestModel.CreatedDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("IsYouTube", requestModel.IsYouTube);
                parameters.Add("ChuThich", requestModel.ChuThich);
                parameters.Add("NgayDang ", requestModel.NgayDang);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienVideo_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_ThuVienVideoModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienVideo_Xoa, parameters);

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
