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
    public class QuanLyAlbumAnhRepository : IQuanLyAlbumAnhRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_ThuVienAnh_CapNhat = "tbl_ThuVienAnh_CapNhat";
        private readonly string _tbl_ThuVienAnh_Album_ThemMoi = "tbl_ThuVienAnh_Album_ThemMoi";
        private readonly string _tbl_ThuVienAnh_Album_CapNhat = "tbl_ThuVienAnh_Album_CapNhat";
        private readonly string _tbl_ThuVienAnh_ChiTiet = "tbl_ThuVienAnh_ChiTiet";
        private readonly string _tbl_ThuVienAnh_Album_DanhSachTheo_IdThuVien = "tbl_ThuVienAnh_Album_DanhSachTheo_IdThuVien";
        private readonly string _tbl_ThuVienAnh_DanhSach = "tbl_ThuVienAnh_DanhSach";
        private readonly string _tbl_ThuVienAnh_ThemMoi = "tbl_ThuVienAnh_ThemMoi";
        private readonly string _tbl_ThuVienAnh_Xoa = "tbl_ThuVienAnh_Xoa";
        private readonly string _tbl_ThuVienAnh_Album_Xoa = "tbl_ThuVienAnh_Album_Xoa";
        #endregion

        public QuanLyAlbumAnhRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_ThuVienAnhModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("NgayPhatHanh", requestModel.NgayPhatHanh);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_CapNhat, parameters);
                if (requestModel.DanhSachAnh.Count > 0)
                {
                    foreach (var item in requestModel.DanhSachAnh)
                    {
                        if (item.Id == 0)
                        {
                            DynamicParameters parametersThemMoi = new DynamicParameters();
                            parametersThemMoi.Add("FileImage", item.FileImage);
                            parametersThemMoi.Add("IdThuVienImage", requestModel.Id);
                            parametersThemMoi.Add("MoTa", item.MoTa);
                            var resultThemMoi = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_Album_ThemMoi, parametersThemMoi);
                        }
                        else
                        {
                            DynamicParameters parametersCapNhat = new DynamicParameters();
                            parametersCapNhat.Add("FileImage", item.FileImage);
                            parametersCapNhat.Add("IdThuVienImage", requestModel.Id);
                            parametersCapNhat.Add("MoTa", item.MoTa);
                            parametersCapNhat.Add("Id", item.Id);
                            var resultThemMoi = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_Album_CapNhat, parametersCapNhat);
                        }
                    }
                }
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

        public async Task<tbl_ThuVienAnhModel> ChiTiet(tbl_ThuVienAnhModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<tbl_ThuVienAnhModel>(_tbl_ThuVienAnh_ChiTiet, parameters)).FirstOrDefault();


                DynamicParameters parametersCT = new DynamicParameters();
                parametersCT.Add("Id", requestModel.Id);
                respone.DanhSachAnh = await _baseRepository.GetList<tbl_ThuVienAnh_AlbumModel>(_tbl_ThuVienAnh_Album_DanhSachTheo_IdThuVien, parametersCT);

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_ThuVienAnhModel();
            }
        }

        public async Task<BaseRespone<tbl_ThuVienAnhModel>> DanhSach(tbl_ThuVienAnhModel requestModel)
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
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_ThuVienAnh_DanhSach, parameters, reader =>
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

        public async Task<Response> ThemMoi(tbl_ThuVienAnhModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("MoTa", requestModel.MoTa);
                parameters.Add("IsHienThi", requestModel.IsHienThi);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("CreatedBy ", requestModel.CreatedBy);
                parameters.Add("CreatedDate ", requestModel.CreatedDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("NgayPhatHanh", requestModel.NgayPhatHanh);

                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_ThemMoi, parameters);
                if (requestModel.DanhSachAnh.Count > 0)
                {
                    foreach (var item in requestModel.DanhSachAnh)
                    {
                        DynamicParameters parametersThemMoi = new DynamicParameters();
                        parametersThemMoi.Add("FileImage", item.FileImage);
                        parametersThemMoi.Add("IdThuVienImage", result);
                        parametersThemMoi.Add("MoTa", item.MoTa);
                        var resultThemMoi = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_Album_ThemMoi, parametersThemMoi);
                    }
                }
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

        public async Task<Response> Xoa(tbl_ThuVienAnhModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_Xoa, parameters);

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

        public async Task<Response> XoaChiTiet(tbl_ThuVienAnhModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_ThuVienAnh_Album_Xoa, parameters);

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
