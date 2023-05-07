using APIServices;
using APIServices.CMS.BillStatus;
using Models;
using Models.CMS.BillStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    public class AdminQuanLyHoaDonController : Controller
    {
        private readonly IBillAPIService _billAPIService;
        private readonly IBillStatusAPIService _billstatusAPIService;


        public AdminQuanLyHoaDonController()
        {
            _billstatusAPIService = new BillStatusAPIService();
            _billAPIService = new BillAPIService();

        }
        // GET: Admin/AdminQuanLyHoaDon
        public async Task<ActionResult> Index(BillRequest requestModel , BillStatusRequest request)
        {
            var data = await _billAPIService.GetAll(requestModel);
            ViewBag.Data = data;

            var billstatus = await _billstatusAPIService.GetAll(request);
            ViewBag.StatusList = billstatus.lst;
            return View();
        }

        public async Task<ActionResult> ChiTietBill(BillRequest requestModel)
        {
            var data = await _billAPIService.GetByUser(requestModel);
            ViewBag.Datain4Bill = data;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(Bill requestModel)
        {
            try
            {
                var data = await _billAPIService.Update(requestModel);
                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    massage = "Thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    massage = "Thất bại"

                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> GetAll(BillRequest requestModel)
        {
            try
            {
                var data = await _billAPIService.GetAll(requestModel);
                var count = data.totalCount;
                return Json(new
                {
                    data = data.lst,
                    recordsTotal = count,
                    recordsFiltered = count,
                    type = CommonConstants.SUCCESS,
                    draw = 0,
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,

                });
            }
        }
    }
}