using APIServices.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    [AuthorizationAttribute]
    public class SoanBaiVietController : Controller
    {
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public SoanBaiVietController(IQuanLyBaiDangService QuanLyBaiDangService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyBaiDangService = QuanLyBaiDangService;
            _QuanLyDanhMucService = QuanLyDanhMucService;
        }
        // GET: Admin/QuanLyBaiDang
        public async Task<ActionResult> Index()
        {
            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    StrDanhMuc += "<option value=\"" + item.ID + "\">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, new List<tbl_Post_CategoryModel>());
                }
            }
            ViewBag.optionSelected = StrDanhMuc;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSachBaiViet(tbl_PostModel model)
        {
            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                model.CreatedBy = TTNguoiDung.ID;
                BaseRespone<tbl_PostModel> response = await _QuanLyBaiDangService.DanhSachBaiDangPV(model);
                return Json(new
                {
                    data = response.Data.ToList(),
                    recordsTotal = response.recordsTotal,
                    recordsFiltered = response.recordsTotal,
                    draw = 0,
                    type = CommonConstants.SUCCESS
                });
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }

        public string DataSelect(List<tbl_CategoryModel> DanhSachChuyenMuc, int IdCha, int Stt, string StrDanhMuc, List<tbl_Post_CategoryModel> LstChuyenMuc)
        {
            if (DanhSachChuyenMuc.Count > 0)
            {
                Stt = Stt + 1;
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == IdCha))
                {
                    var kc = "";
                    for (int idx = 0; idx < Stt; idx++)
                    {
                        kc += "-- ";
                    }

                    StrDanhMuc += "<option value=" + item.ID + ">" + kc + item.Name + "</option>";
                    var checkCon = DanhSachChuyenMuc.Where(e => e.ParentID == item.ID).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataSelect(DanhSachChuyenMuc, item.ID, Stt, StrDanhMucChildren, LstChuyenMuc);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoi(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;
                requestModel.Thumnail = "/FileUploaded/Upload/Images/" + requestModel.Thumnail;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.ThemMoi(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_CREATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_CREATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }
        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> CapNhat(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;
                requestModel.Thumnail = "/FileUploaded/Upload/Images/" + requestModel.Thumnail;
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.CapNhat(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_UPDATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_UPDATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<JsonResult> Xoa(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.Xoa(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_DELETE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_DELETE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_DELETE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<JsonResult> DuyetHuyDuyet(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.IsPVDuyetHuyDuyet(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_UPDATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_UPDATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<ActionResult> _ThemMoiBaiViet()
        {
            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    StrDanhMuc += "<option value=\"" + item.ID + "\">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, new List<tbl_Post_CategoryModel>());
                }
            }
            ViewBag.optionSelected = StrDanhMuc;
            return View();
        }


        public async Task<ActionResult> _SuaBaiViet(int Id, string Url)
        {
            tbl_PostModel requestModelCT = new tbl_PostModel();
            requestModelCT.ID = Id;
            var ChiTiet = await _QuanLyBaiDangService.ChiTiet(requestModelCT);
            ViewBag.ChiTiet = ChiTiet;

            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    string StrCheck = "";
                    if (ChiTiet.LstChuyenMuc.Where(e => e.IdCategory == item.ID).Count() > 0) StrCheck = "selected";
                    StrDanhMuc += "<option " + StrCheck + " value=" + item.ID + ">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, ChiTiet.LstChuyenMuc);
                }
            }
            ViewBag.optionSelected = StrDanhMuc;
            ViewBag.Url = Url;

            tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
            var checkAdmin = TTNguoiDung.lstQuyen.Where(e => e.IdRole == Constants.QuyenAdmin).FirstOrDefault();
            ViewBag.IsAdmin = 0;
            if (checkAdmin != null)
            {
                ViewBag.IsAdmin = 1;
            }
            return View();
        }

        public async Task<JsonResult> DuyetHuyDuyetMulti(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                if (requestModel.lstIdBaiViet.Count > 0)
                {
                    foreach (var item in requestModel.lstIdBaiViet)
                    {
                        requestModel.ID = item;
                        Response check = await _QuanLyBaiDangService.IsPVDuyetHuyDuyet(requestModel);
                    }
                }
                message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                message.icon = CommonConstants.SUCCESS;
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_DELETE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }


        public async Task<JsonResult> DuyetAdmin(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.DuyetAdmin(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_UPDATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_UPDATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }


        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> CapNhatAdmin(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;
                requestModel.Thumnail = "/FileUploaded/Upload/Images/" + requestModel.Thumnail;
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.CapNhat(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_UPDATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_UPDATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

    }
}