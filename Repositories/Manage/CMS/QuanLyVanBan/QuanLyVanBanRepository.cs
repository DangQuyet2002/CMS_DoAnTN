using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS.QuanLyVanBan
{
    public class QuanLyVanBanRepository : IQuanLyVanBanRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_VanBan_Update = "tbl_VanBan_Update";
        private readonly string _tbl_VanBan_ChiTiet = "tbl_VanBan_ChiTiet";
        private readonly string _tbl_VanBan_DanhSach = "tbl_VanBan_DanhSach";
        private readonly string _tbl_VanBan_ThemMoi = "tbl_VanBan_ThemMoi";
        private readonly string _tbl_VanBan_Delete = "tbl_VanBan_Delete";



        private readonly string _tbl_LoaiVanBan_DanhSach = "tbl_LoaiVanBan_DanhSach";
        private readonly string _tbl_LoaiVanBan_ThemMoi = "tbl_LoaiVanBan_ThemMoi";
        private readonly string _tbl_LoaiVanBan_CapNhat = "tbl_LoaiVanBan_CapNhat";
        private readonly string _tbl_LoaiVanBan_Xoa = "tbl_LoaiVanBan_Xoa";
        private readonly string _tbl_LoaiVanBan_ChiTiet = "tbl_LoaiVanBan_ChiTiet";
        #endregion
        public QuanLyVanBanRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_VanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("Content", requestModel.Content);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.ID);
                parameters.Add("Image ", requestModel.Image);
                parameters.Add("File ", requestModel.File);
                parameters.Add("NgayPhatHanh ", requestModel.NgayPhatHanh);
                parameters.Add("IdCategory ", requestModel.IdCategory);

                var result = await _baseRepository.GetValue<int>(_tbl_VanBan_Update, parameters);

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

        public async Task<Response> CapNhatLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                parameters.Add("Ten ", requestModel.Ten);

                var result = await _baseRepository.GetValue<int>(_tbl_LoaiVanBan_CapNhat, parameters);

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

        public async Task<tbl_VanBanModel> ChiTiet(tbl_VanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.ID);
                var respone = (await _baseRepository.GetList<tbl_VanBanModel>(_tbl_VanBan_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_VanBanModel();
            }
        }

        public async Task<tbl_LoaiVanBanModel> ChiTietLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var respone = (await _baseRepository.GetList<tbl_LoaiVanBanModel>(_tbl_LoaiVanBan_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_LoaiVanBanModel();
            }
        }

        public async Task<BaseRespone<tbl_VanBanModel>> DanhSach(tbl_VanBanModel requestModel)
        {
            try
            {
                BaseRespone<tbl_VanBanModel> Respone = new BaseRespone<tbl_VanBanModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("IdCategory", requestModel.IdCategory);
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_VanBan_DanhSach, parameters, reader =>
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

        public async Task<BaseRespone<tbl_LoaiVanBanModel>> DanhSachLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            try
            {
                BaseRespone<tbl_LoaiVanBanModel> Respone = new BaseRespone<tbl_LoaiVanBanModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Ten", requestModel.Ten);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_LoaiVanBan_DanhSach, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_LoaiVanBanModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_LoaiVanBanModel>();
            }
        }

        public async Task<Response> ThemMoi(tbl_VanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("Content", requestModel.Content);
                parameters.Add("File", requestModel.File);
                parameters.Add("CreatedBy ", requestModel.CreatedBy);
                parameters.Add("CreatedDate ", requestModel.CreatedDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Image ", requestModel.Image);
                parameters.Add("NgayPhatHanh ", requestModel.NgayPhatHanh);
                parameters.Add("IdCategory ", requestModel.IdCategory);

                var result = await _baseRepository.GetValue<int>(_tbl_VanBan_ThemMoi, parameters);

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

        public async Task<Response> ThemMoiLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Ten", requestModel.Ten);
                var result = await _baseRepository.GetValue<int>(_tbl_LoaiVanBan_ThemMoi, parameters);

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

        public async Task<Response> Xoa(tbl_VanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.ID);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                var result = await _baseRepository.GetValue<int>(_tbl_VanBan_Delete, parameters);

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

        public async Task<Response> XoaLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                var result = await _baseRepository.GetValue<int>(_tbl_LoaiVanBan_Xoa, parameters);

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
