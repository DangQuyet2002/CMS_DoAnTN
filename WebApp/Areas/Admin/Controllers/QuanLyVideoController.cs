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
    public class QuanLyVideoController : Controller
    {
        private readonly IQuanLyVideoService _QuanLyVideoService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public QuanLyVideoController(IQuanLyVideoService QuanLyVideoService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyVideoService = QuanLyVideoService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }

        // GET: Admin/QuanLyVideo
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_ThuVienVideoModel model)
        {
            try
            {
                BaseRespone<tbl_ThuVienVideoModel> response = await _QuanLyVideoService.DanhSach(model);
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

        public async Task<ActionResult> _ThemMoi()
        {
            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    StrDanhMuc += "<option value=\"" + item.ID + "\">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, 0);
                }
            }
            ViewBag.optionSelected = StrDanhMuc;
            return View();
        }

        public async Task<ActionResult> _Sua(int Id)
        {
            tbl_ThuVienVideoModel requestModelCT = new tbl_ThuVienVideoModel();
            requestModelCT.Id = Id;
            tbl_ThuVienVideoModel ChiTiet = await _QuanLyVideoService.ChiTiet(requestModelCT);
            ViewBag.ChiTiet = ChiTiet;

            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    StrDanhMuc += "<option value=\"" + item.ID + "\">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, ChiTiet.CategoryID);
                }
            }
            ViewBag.optionSelected = StrDanhMuc;

            return View();
        }


        public string DataSelect(List<tbl_CategoryModel> DanhSachDonVi, int IdCha, int Stt, string StrDanhMuc, int IdDanhMuc = 0)
        {
            if (DanhSachDonVi.Count > 0)
            {
                Stt = Stt + 1;

                foreach (var item in DanhSachDonVi.Where(e => e.ParentID == IdCha))
                {
                    var kc = "";
                    for (int idx = 0; idx < Stt; idx++)
                    {
                        kc += "-- ";
                    }
                    var check = (item.ID == IdDanhMuc ? "selected" : "");
                    StrDanhMuc += "<option " + check + " value=" + item.ID + ">" + kc + item.Name + "</option>";
                    var checkCon = DanhSachDonVi.Where(e => e.ParentID == item.ID).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataSelect(DanhSachDonVi, item.ID, Stt, StrDanhMucChildren, IdDanhMuc);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }


        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoi(tbl_ThuVienVideoModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVideoService.ThemMoi(requestModel);
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
        public async Task<JsonResult> CapNhat(tbl_ThuVienVideoModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVideoService.CapNhat(requestModel);
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
        public async Task<JsonResult> Xoa(tbl_ThuVienVideoModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVideoService.Xoa(requestModel);
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
    }
}