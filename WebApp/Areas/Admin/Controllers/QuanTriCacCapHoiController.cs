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
    public class QuanTriCacCapHoiController : Controller
    {
        private readonly ICacCapHoiService _CacCapHoiService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public QuanTriCacCapHoiController(ICacCapHoiService CacCapHoiService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _CacCapHoiService = CacCapHoiService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }
        // GET: Admin/QuanLyCacCapHoi
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_CacCapHoiModel model)
        {
            try
            {
                BaseRespone<tbl_CacCapHoiModel> response = await _CacCapHoiService.DanhSach(model);
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
            tbl_CacCapHoiModel requestModelCT = new tbl_CacCapHoiModel();
            requestModelCT.Id = Id;
            tbl_CacCapHoiModel ChiTiet = await _CacCapHoiService.ChiTiet(requestModelCT);
            ViewBag.ChiTiet = ChiTiet;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoi(tbl_CacCapHoiModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _CacCapHoiService.ThemMoi(requestModel);
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
        public async Task<JsonResult> CapNhat(tbl_CacCapHoiModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _CacCapHoiService.CapNhat(requestModel);
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
        public async Task<JsonResult> Xoa(tbl_CacCapHoiModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _CacCapHoiService.Xoa(requestModel);
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
        public async Task<JsonResult> CapNhatSTT(tbl_CacCapHoiModel requestModel)
        {

            try
            {

                JsonResponse message = new JsonResponse();
                Response check = await _CacCapHoiService.CapNhatSTT(requestModel);
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