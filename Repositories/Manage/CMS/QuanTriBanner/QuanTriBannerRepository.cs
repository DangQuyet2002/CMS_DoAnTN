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
    public class QuanTriBannerRepository : IQuanTriBannerRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_Banner_CapNhat = "tbl_Banner_CapNhat";
        private readonly string _tbl_Banner_ChiTiet = "tbl_Banner_ChiTiet";
        private readonly string _tbl_Banner_DanhSach = "tbl_Banner_DanhSach";
        private readonly string _tbl_Banner_ThemMoi = "tbl_Banner_ThemMoi";
        private readonly string _tbl_Banner_Xoa = "tbl_Banner_Xoa";
        private readonly string _tbl_ViTri_Banner_DanhSach = "tbl_ViTri_Banner_DanhSach";
        private readonly string _tbl_Banner_DanhSachBannerDaGanViTri = "tbl_Banner_DanhSachBannerDaGanViTri";
        private readonly string _tbl_Banner_DanhSachBannerChuaGanViTri = "tbl_Banner_DanhSachBannerChuaGanViTri";
        private readonly string _tbl_Banner_ThemMoiViTri = "tbl_Banner_ThemMoiViTri";
        private readonly string _tbl_Banner_XoaViTri = "tbl_Banner_XoaViTri";
        private readonly string _tbl_Banner_ThemLuotChon = "tbl_Banner_ThemLuotChon";
        private readonly string _tbl_Banner_HienThisilde = "tbl_Banner_HienThisilde";
        #endregion

        public QuanTriBannerRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }


        public async Task<Response> CapNhat(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", requestModel.Name);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("StartDate", requestModel.StartDate);
                parameters.Add("EndDate", requestModel.EndDate);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("Id", requestModel.ID);
                parameters.Add("Url", requestModel.Url);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_CapNhat, parameters);

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

        public async Task<Response> CheckHienThiSilde(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IsSilde", requestModel.IsSilde);
                parameters.Add("Id", requestModel.IdVT);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_HienThisilde, parameters);

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

        public async Task<tbl_BannerModel> ChiTiet(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.ID);
                var respone = (await _baseRepository.GetList<tbl_BannerModel>(_tbl_Banner_ChiTiet, parameters)).FirstOrDefault();

                return respone;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_BannerModel();
            }
        }

        public async Task<BaseRespone<tbl_BannerModel>> DanhSach(tbl_BannerModel requestModel)
        {
            try
            {
                BaseRespone<tbl_BannerModel> Respone = new BaseRespone<tbl_BannerModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", requestModel.Name);
                parameters.Add("StartDate", requestModel.StartDate);
                parameters.Add("EndDate", requestModel.EndDate);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Banner_DanhSach, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_BannerModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_BannerModel>();
            }
        }

        public async Task<BaseRespone<tbl_BannerModel>> DanhSachBannerChuaGanViTri(tbl_BannerModel requestModel)
        {
            try
            {
                BaseRespone<tbl_BannerModel> Respone = new BaseRespone<tbl_BannerModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdViTri", requestModel.IdViTri);
                parameters.Add("IdChuyenMuc", requestModel.IdChuyenMuc);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Banner_DanhSachBannerChuaGanViTri, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_BannerModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_BannerModel>();
            }
        }

        public async Task<BaseRespone<tbl_BannerModel>> DanhSachBannerDaGanViTri(tbl_BannerModel requestModel)
        {
            try
            {
                BaseRespone<tbl_BannerModel> Respone = new BaseRespone<tbl_BannerModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdViTri", requestModel.IdViTri);
                parameters.Add("IdChuyenMuc", requestModel.IdChuyenMuc);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("NgayHienTai", requestModel.NgayHienTai);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Banner_DanhSachBannerDaGanViTri, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_BannerModel>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new BaseRespone<tbl_BannerModel>();
            }
        }

        public async Task<List<tbl_BannerModel>> DanhSachViTri(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                var result = await _baseRepository.GetList<tbl_BannerModel>(_tbl_ViTri_Banner_DanhSach, parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_BannerModel>();
            }
        }

        public async Task<Response> ThemLuotXem(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_ThemLuotChon, parameters);

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

        public async Task<Response> ThemMoi(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Name", requestModel.Name);
                parameters.Add("Image", requestModel.Image);
                parameters.Add("Url", requestModel.Url);
                parameters.Add("CreatedBy ", requestModel.CreatedBy);
                parameters.Add("CreatedDate ", requestModel.CreatedDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("EndDate", requestModel.EndDate);
                parameters.Add("StartDate", requestModel.StartDate);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_ThemMoi, parameters);

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

        public async Task<Response> ThemMoiViTri(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id_Banner", requestModel.Id_Banner);
                parameters.Add("IdViTri", requestModel.IdViTri);
                parameters.Add("IdChuyenMuc", requestModel.IdChuyenMuc);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_ThemMoiViTri, parameters);

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

        public async Task<Response> Xoa(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.ID);
                parameters.Add("UpdateBy", requestModel.UpdateBy);
                parameters.Add("UpdateDate ", requestModel.UpdateDate);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_Xoa, parameters);

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

        public async Task<Response> XoaViTri(tbl_BannerModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Banner_XoaViTri, parameters);

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
