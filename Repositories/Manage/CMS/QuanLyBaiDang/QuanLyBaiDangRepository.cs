using Dapper;
using Models;
using Repositories.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public class QuanLyBaiDangRepository : IQuanLyBaiDangRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_Post_DanhSach_Update = "tbl_Post_DanhSach_Update";
        private readonly string _tbl_Post_DanhSach_TKGD = "tbl_Post_DanhSach_TKGD";
        private readonly string _tbl_Post_DanhSach_ThemMoi = "tbl_Post_DanhSach_ThemMoi";
        private readonly string _tbl_Post_DanhSach_PV = "tbl_Post_DanhSach_PV";
        private readonly string _tbl_Post_DanhSach_IsXuatBan = "tbl_Post_DanhSach_IsXuatBan";
        private readonly string _tbl_Post_DanhSach_Delete = "tbl_Post_DanhSach_Delete";
        private readonly string _tbl_Post_DanhSach_ChiTiet = "tbl_Post_DanhSach_ChiTiet";
        private readonly string _tbl_Post_DanhSach_BTV = "tbl_Post_DanhSach_BTV";
        private readonly string _tbl_Post_DanhSach_DuyetHuyDuyet = "tbl_Post_DanhSach_DuyetHuyDuyet";
        private readonly string _tbl_Post_DanhSach_BTVDuyetHuyDuyet = "tbl_Post_DanhSach_BTVDuyetHuyDuyet";
        private readonly string _tbl_Post_DanhSach_TK_GDDuyetHuyDuyet = "tbl_Post_DanhSach_TK_GDDuyetHuyDuyet";
        private readonly string _tbl_Post_DanhSach_TK_GDTuChoi = "tbl_Post_DanhSach_TK_GDTuChoi";
        private readonly string _tbl_Post_DanhSach_TinMoi = "tbl_Post_DanhSach_TinMoi";
        private readonly string _tbl_Post_DanhSachTinMoi = "tbl_Post_DanhSachTinMoi";
        private readonly string _tbl_Post_ThemLuotChon = "tbl_Post_ThemLuotChon";
        private readonly string _tbl_Comment_DanhSach = "tbl_Comment_DanhSach";
        private readonly string _tbl_Comment_ThemMoi = "tbl_Comment_ThemMoi";
        private readonly string _tbl_LikePost_ThemMoi = "tbl_LikePost_ThemMoi";
        private readonly string _tbl_LikePost_ChiTiet = "tbl_LikePost_ChiTiet";
        private readonly string _tbl_LikePost_Xoa = "tbl_LikePost_Xoa";
        private readonly string _tbl_Post_Category_ThemMoi = "tbl_Post_Category_ThemMoi";
        private readonly string _tbl_Post_DanhSach_ThemMoi_Duyet = "tbl_Post_DanhSach_ThemMoi_Duyet";
        private readonly string _tbl_Post_DanhSach_ChiTiet_Category = "tbl_Post_DanhSach_ChiTiet_Category";
        private readonly string _tbl_Post_Category_Xoa = "tbl_Post_Category_Xoa";
        private readonly string _tbl_Post_DanhSach_TinTucCungCM = "tbl_Post_DanhSach_TinTucCungCM";
        private readonly string _tbl_post_DuyetAdmin = "tbl_post_DuyetAdmin";
        private readonly string _tbl_post_DanhSachCategory = "tbl_post_DanhSachCategory";

        #endregion

        public QuanLyBaiDangRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }
        public async Task<Response> CapNhat(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parametersXoaCT = new DynamicParameters();
                parametersXoaCT.Add("IdPost", requestModel.ID);
                var resultXoa = await _baseRepository.GetValue<int>(_tbl_Post_Category_Xoa, parametersXoaCT);

                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("ShortDescription", requestModel.ShortDescription);
                parameters.Add("Thumnail", requestModel.Thumnail);
                parameters.Add("PostContent ", requestModel.PostContent);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("TuKhoaSeo", requestModel.TuKhoaSeo);
                parameters.Add("MoTaSeo", requestModel.MoTaSeo);
                parameters.Add("Id", requestModel.ID);
                parameters.Add("NgayPhatHanh", requestModel.NgayPhatHanh);
                parameters.Add("ShortThumnailContent", requestModel.ShortThumnailContent);
                parameters.Add("TacGia", requestModel.TacGia);

                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_Update, parameters);

                if (requestModel.lstIdChuyenMuc.Count > 0)
                {
                    foreach (var item in requestModel.lstIdChuyenMuc)
                    {
                        DynamicParameters parametersCM = new DynamicParameters();
                        parametersCM.Add("IdPost", requestModel.ID);
                        parametersCM.Add("IdCategory", item);
                        var resultCM = await _baseRepository.GetValue<int>(_tbl_Post_Category_ThemMoi, parametersCM);
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

        public async Task<tbl_PostModel> ChiTiet(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.ID);
                var lstChiTiet = (await _baseRepository.GetList<tbl_PostModel>(_tbl_Post_DanhSach_ChiTiet, parameters)).FirstOrDefault();

                DynamicParameters parametersCT = new DynamicParameters();
                parametersCT.Add("IdPost", requestModel.ID);
                lstChiTiet.LstChuyenMuc = await _baseRepository.GetList<tbl_Post_CategoryModel>(_tbl_Post_DanhSach_ChiTiet_Category, parametersCT);
                return lstChiTiet;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_PostModel();
            }
        }

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangBTV(tbl_PostModel requestModel)
        {
            try
            {
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("IsBTVDuyet", requestModel.IsBTVDuyet);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Post_DanhSach_BTV, parameters, reader =>
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

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangPV(tbl_PostModel requestModel)
        {
            try
            {
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("CreatedBy", requestModel.CreatedBy);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("IsPVDuyet", requestModel.IsPVDuyet);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Post_DanhSach_PV, parameters, reader =>
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

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangTKGD(tbl_PostModel requestModel)
        {
            try
            {
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("IsTK_GDDuyet", requestModel.IsTK_GDDuyet);
                parameters.Add("lstIdCategory", requestModel.lstIdCategory);
                parameters.Add("IsTinMoi", requestModel.IsTinMoi);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Post_DanhSach_TKGD, parameters, reader =>
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

        public async Task<Response> IsPVDuyetHuyDuyet(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("IsPVDuyet", requestModel.IsPVDuyet);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_DuyetHuyDuyet, parameters);
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

        public async Task<Response> IsBTVDuyetHuyDuyet(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("IsBTVDuyet", requestModel.IsBTVDuyet);
                parameters.Add("Id", requestModel.ID);
                parameters.Add("LyDoTraLaiBTV", requestModel.LyDoTraLaiBTV);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_BTVDuyetHuyDuyet, parameters);
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

        public async Task<Response> IsTK_GDDuyetHuyDuyet(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("IsTK_GDDuyet", requestModel.IsTK_GDDuyet);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_TK_GDDuyetHuyDuyet, parameters);
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

        public async Task<Response> IsXuatBanBaiBao(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_IsXuatBan, parameters);
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

        public async Task<Response> ThemMoi(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                if (requestModel.Status == 0)
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Title", requestModel.Title);
                    parameters.Add("ShortDescription", requestModel.ShortDescription);
                    parameters.Add("Thumnail", requestModel.Thumnail);
                    parameters.Add("PostContent ", requestModel.PostContent);
                    parameters.Add("IsActive", requestModel.IsActive);
                    parameters.Add("CreatedAt", requestModel.CreatedAt);
                    parameters.Add("CreatedBy", requestModel.CreatedBy);
                    parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                    parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                    parameters.Add("TuKhoaSeo", requestModel.TuKhoaSeo);
                    parameters.Add("MoTaSeo", requestModel.MoTaSeo);
                    parameters.Add("NgayPhatHanh", requestModel.NgayPhatHanh);
                    parameters.Add("ShortThumnailContent", requestModel.ShortThumnailContent);
                    parameters.Add("TacGia", requestModel.TacGia);

                    var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_ThemMoi, parameters);


                    if (requestModel.lstIdChuyenMuc.Count > 0)
                    {
                        foreach (var item in requestModel.lstIdChuyenMuc)
                        {
                            DynamicParameters parametersCM = new DynamicParameters();
                            parametersCM.Add("IdPost", result);
                            parametersCM.Add("IdCategory", item);
                            var resultCM = await _baseRepository.GetValue<int>(_tbl_Post_Category_ThemMoi, parametersCM);
                        }
                    }
                    message.code = ResponseCode.SUCCESS;
                    message.message = ResponseDetail.SUCCESSDETAIL;
                    message.result = result;
                    return message;
                }
                else
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("Title", requestModel.Title);
                    parameters.Add("ShortDescription", requestModel.ShortDescription);
                    parameters.Add("Thumnail", requestModel.Thumnail);
                    parameters.Add("PostContent ", requestModel.PostContent);
                    parameters.Add("IsActive", requestModel.IsActive);
                    parameters.Add("CreatedAt", requestModel.CreatedAt);
                    parameters.Add("CreatedBy", requestModel.CreatedBy);
                    parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                    parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                    parameters.Add("TuKhoaSeo", requestModel.TuKhoaSeo);
                    parameters.Add("MoTaSeo", requestModel.MoTaSeo);
                    parameters.Add("NgayPhatHanh", requestModel.NgayPhatHanh);
                    parameters.Add("ShortThumnailContent", requestModel.ShortThumnailContent);
                    parameters.Add("IsPVDuyet", Contants.StDaGui);
                    parameters.Add("IdUserPVDuyet", requestModel.CreatedBy);
                    parameters.Add("NgayPVDuyet", DateTime.Now);
                    var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_ThemMoi_Duyet, parameters);


                    if (requestModel.lstIdChuyenMuc.Count > 0)
                    {
                        foreach (var item in requestModel.lstIdChuyenMuc)
                        {
                            DynamicParameters parametersCM = new DynamicParameters();
                            parametersCM.Add("IdPost", result);
                            parametersCM.Add("IdCategory", item);
                            var resultCM = await _baseRepository.GetValue<int>(_tbl_Post_Category_ThemMoi, parametersCM);
                        }
                    }
                    message.code = ResponseCode.SUCCESS;
                    message.message = ResponseDetail.SUCCESSDETAIL;
                    message.result = result;
                    return message;
                }

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

        public async Task<Response> Xoa(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_Delete, parameters);
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

        public async Task<Response> IsTK_GDTraLai(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("LyDoTraLaiTK_GD", requestModel.LyDoTraLaiTK_GD);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_TK_GDTuChoi, parameters);
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

        public async Task<Response> TinTucMoi(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("IsTinMoi", requestModel.IsTinMoi);
                parameters.Add("Id", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_DanhSach_TinMoi, parameters);
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

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangMoi(tbl_PostModel requestModel)
        {
            try
            {
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Post_DanhSachTinMoi, parameters, reader =>
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

        public async Task<Response> CapNhatLuotXem(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ID", requestModel.ID);
                var result = await _baseRepository.GetValue<int>(_tbl_Post_ThemLuotChon, parameters);
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

        public async Task<List<tbl_CommentModel>> DanhSachBinhLuan(tbl_CommentModel requestModel)
        {
            try
            {
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdPost", requestModel.IdPost);
                return await _baseRepository.GetList<tbl_CommentModel>(_tbl_Comment_DanhSach, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_CommentModel>();
            }
        }

        public async Task<Response> ThemMoiBinhLuan(tbl_CommentModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdPost", requestModel.IdPost);
                parameters.Add("IdUser", requestModel.IdUser);
                parameters.Add("CreatedDate", requestModel.CreatedDate);
                parameters.Add("NoiDung", requestModel.NoiDung);
                var result = await _baseRepository.GetValue<int>(_tbl_Comment_ThemMoi, parameters);
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

        public async Task<Response> ThemMoiLike(tbl_LikePostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdPost", requestModel.IdPost);
                parameters.Add("IdUser", requestModel.IdUser);
                var result = await _baseRepository.GetValue<int>(_tbl_LikePost_ThemMoi, parameters);
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

        public async Task<List<tbl_LikePostModel>> ChiTietLike(tbl_LikePostModel requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdPost", requestModel.IdPost);
                parameters.Add("IdUser", requestModel.IdUser);
                return await _baseRepository.GetList<tbl_LikePostModel>(_tbl_LikePost_ChiTiet, parameters);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new List<tbl_LikePostModel>();
            }
        }

        public async Task<Response> XoaLike(tbl_LikePostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("IdPost", requestModel.IdPost);
                parameters.Add("IdUser", requestModel.IdUser);
                var result = await _baseRepository.GetValue<int>(_tbl_LikePost_Xoa, parameters);
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

        public async Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangCungChuyenMuc(tbl_PostModel requestModel)
        {
            try
            {

                string lstID = null;
                if (requestModel.ID > 0)
                {
                    DynamicParameters parameterslstId = new DynamicParameters();
                    parameterslstId.Add("ID", requestModel.ID);
                    var resultCategory = await _baseRepository.GetList<int>(_tbl_post_DanhSachCategory, parameterslstId);

                    if(resultCategory!= null)
                    {
                        lstID=string.Join(",", resultCategory);
                    }
                }
                BaseRespone<tbl_PostModel> Respone = new BaseRespone<tbl_PostModel>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("lstID", lstID);
                parameters.Add("CategoryID", requestModel.CategoryID);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("IsCheckNgayPhatHanh", requestModel.IsCheckNgayPhatHanh);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList(_tbl_Post_DanhSach_TinTucCungCM, parameters, reader =>
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

        public async Task<Response> DuyetAdmin(tbl_PostModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Title", requestModel.Title);
                parameters.Add("ShortDescription", requestModel.ShortDescription);
                parameters.Add("Thumnail", requestModel.Thumnail);
                parameters.Add("PostContent ", requestModel.PostContent);
                parameters.Add("IsActive", requestModel.IsActive);
                parameters.Add("UpdatedAt", requestModel.UpdatedAt);
                parameters.Add("UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("TuKhoaSeo", requestModel.TuKhoaSeo);
                parameters.Add("MoTaSeo", requestModel.MoTaSeo);
                parameters.Add("Id", requestModel.ID);
                parameters.Add("NgayPhatHanh", requestModel.NgayPhatHanh);
                parameters.Add("ShortThumnailContent", requestModel.ShortThumnailContent);
                parameters.Add("TacGia", requestModel.TacGia);
                var result = await _baseRepository.GetValue<int>(_tbl_post_DuyetAdmin, parameters);
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
