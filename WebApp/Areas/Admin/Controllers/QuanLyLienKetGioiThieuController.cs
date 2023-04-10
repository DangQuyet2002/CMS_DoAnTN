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
    public class QuanLyLienKetGioiThieuController : Controller
    {
        private readonly ILienKetGioiThieuService _LienKetGioiThieuService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public QuanLyLienKetGioiThieuController(ILienKetGioiThieuService LienKetGioiThieuService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _LienKetGioiThieuService = LienKetGioiThieuService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }
        // GET: Admin/QuanLyLienKetGioiThieu
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_LienKetGioiThieuModel model)
        {
            try
            {
                BaseRespone<tbl_LienKetGioiThieuModel> response = await _LienKetGioiThieuService.DanhSach(model);
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

        public ActionResult _ThemMoi()
        {
            return View();
        }

        public async Task<ActionResult> _Sua(int Id)
        {
            tbl_LienKetGioiThieuModel requestModelCT = new tbl_LienKetGioiThieuModel();
            requestModelCT.Id = Id;
            tbl_LienKetGioiThieuModel ChiTiet = await _LienKetGioiThieuService.ChiTiet(requestModelCT);
            ViewBag.ChiTiet = ChiTiet;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoi(tbl_LienKetGioiThieuModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _LienKetGioiThieuService.ThemMoi(requestModel);
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
        public async Task<JsonResult> CapNhat(tbl_LienKetGioiThieuModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _LienKetGioiThieuService.CapNhat(requestModel);
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
        public async Task<JsonResult> Xoa(tbl_LienKetGioiThieuModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _LienKetGioiThieuService.Xoa(requestModel);
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
        public async Task<JsonResult> CapNhatSTT(tbl_LienKetGioiThieuModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _LienKetGioiThieuService.CapNhatSTT(requestModel);
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
    }
}