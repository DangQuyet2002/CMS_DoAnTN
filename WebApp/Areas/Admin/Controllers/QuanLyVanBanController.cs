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
    public class QuanLyVanBanController : Controller
    {
        private readonly IQuanLyVanBanService _QuanLyVanBanService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public QuanLyVanBanController(IQuanLyVanBanService QuanLyVanBanService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyVanBanService = QuanLyVanBanService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }
        // GET: Admin/QuanLyVanBan
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_VanBanModel model)
        {
            try
            {
                BaseRespone<tbl_VanBanModel> response = await _QuanLyVanBanService.DanhSach(model);
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

            tbl_LoaiVanBanModel model = new tbl_LoaiVanBanModel();
            model.start = 0;
            model.length = 0;
            BaseRespone<tbl_LoaiVanBanModel> response = await _QuanLyVanBanService.DanhSachLoaiVanBan(model);
            ViewBag.DanhSachLoaiVanBan = response.Data;

            return View();
        }

        public async Task<ActionResult> _Sua(int Id)
        {
            tbl_VanBanModel requestModelCT = new tbl_VanBanModel();
            requestModelCT.ID = Id;
            tbl_VanBanModel ChiTiet = await _QuanLyVanBanService.ChiTiet(requestModelCT);

            tbl_LoaiVanBanModel model = new tbl_LoaiVanBanModel();
            model.start = 0;
            model.length = 0;
            BaseRespone<tbl_LoaiVanBanModel> response = await _QuanLyVanBanService.DanhSachLoaiVanBan(model);
            ViewBag.DanhSachLoaiVanBan = response.Data;

            ViewBag.ChiTiet = ChiTiet;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoi(tbl_VanBanModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVanBanService.ThemMoi(requestModel);
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
        public async Task<JsonResult> CapNhat(tbl_VanBanModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVanBanService.CapNhat(requestModel);
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
        public async Task<JsonResult> Xoa(tbl_VanBanModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVanBanService.Xoa(requestModel);
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


        public ActionResult _DanhSachLoaiVanBan()
        {

            return View();
        }


        [HttpPost]
        public async Task<JsonResult> DanhSachLoaiVanBan(tbl_LoaiVanBanModel model)
        {
            try
            {
                BaseRespone<tbl_LoaiVanBanModel> response = await _QuanLyVanBanService.DanhSachLoaiVanBan(model);
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
        public async Task<ActionResult> _ThemSuaLoaiVanBan(int Id = 0)
        {
            ViewBag.ChiTietLoaiVanBan = new tbl_LoaiVanBanModel();
            if (Id > 0)
            {
                tbl_LoaiVanBanModel requestModel = new tbl_LoaiVanBanModel();
                requestModel.Id = Id;
                ViewBag.ChiTietLoaiVanBan = await _QuanLyVanBanService.ChiTietLoaiVanBan(requestModel);
            }
            return View();
        }


        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> Luu(tbl_LoaiVanBanModel requestModel)
        {

            try
            {

                if (requestModel.Id == 0)
                {
                    JsonResponse message = new JsonResponse();
                    Response check = await _QuanLyVanBanService.ThemMoiLoaiVanBan(requestModel);
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
                else
                {

                    JsonResponse message = new JsonResponse();
                    Response check = await _QuanLyVanBanService.CapNhatLoaiVanBan(requestModel);
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
        public async Task<JsonResult> XoaLoaiVanBan(tbl_LoaiVanBanModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyVanBanService.XoaLoaiVanBan(requestModel);
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