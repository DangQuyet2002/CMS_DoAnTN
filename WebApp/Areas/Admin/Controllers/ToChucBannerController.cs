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
    public class ToChucBannerController : Controller
    {
        private readonly IQuanTriBannerService _QuanTriBannerService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public ToChucBannerController(IQuanTriBannerService QuanTriBannerService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanTriBannerService = QuanTriBannerService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }
        // GET: Admin/QuanTriBanner
        public async Task<ActionResult> Index()
        {
            tbl_BannerModel requestModel = new tbl_BannerModel();
            ViewBag.DanhSachViTri = await _QuanTriBannerService.DanhSachViTri(requestModel);
            ViewBag.DanhSachChuyenMuc = Constants.LstChuyenDe;
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSachBannerChuaGanViTri(tbl_BannerModel model)
        {
            try
            {
                BaseRespone<tbl_BannerModel> response = await _QuanTriBannerService.DanhSachBannerChuaGanViTri(model);
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


        [HttpPost]
        public async Task<JsonResult> DanhSachBannerDaGanViTri(tbl_BannerModel model)
        {
            try
            {
                BaseRespone<tbl_BannerModel> response = await _QuanTriBannerService.DanhSachBannerDaGanViTri(model);
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


        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoiViTri(tbl_BannerModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanTriBannerService.ThemMoiViTri(requestModel);
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
        public async Task<JsonResult> XoaViTri(tbl_BannerModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.UpdateDate = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdateBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanTriBannerService.XoaViTri(requestModel);
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

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> CheckHienThiSilde(tbl_BannerModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanTriBannerService.CheckHienThiSilde(requestModel);
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