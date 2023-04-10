using APIServices;
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
    public class QuanLyChanTrangController : Controller
    {
        private readonly IQuanLyChanTrangService _QuanLyChanTrangService;
        public QuanLyChanTrangController(IQuanLyChanTrangService QuanLyChanTrangService)
        {
            _QuanLyChanTrangService = QuanLyChanTrangService;
        }

        // GET: Admin/QuanLyChanTrang
        public async Task<ActionResult> Index()
        {
            tbl_ChanTrangModel response = await _QuanLyChanTrangService.ChiTiet();
            ViewBag.ChiTiet = response;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> CapNhat(tbl_ChanTrangModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyChanTrangService.CapNhat(requestModel);
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