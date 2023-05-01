using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        private readonly IGioHangAPIService gioHangAPIService;
        public GioHangController()
        {
            gioHangAPIService = new GioHangAPIService();
        }
        // GET: GioHang
        public async Task<ActionResult> Index(GioHangRequest requestModel)
        {
            var data = await gioHangAPIService.GetByUser(requestModel);
            ViewBag.DataGH = data;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Themmoi(GioHang requestModel)
        {
            try
            {
                requestModel.Total = requestModel.Price * requestModel.Quantity;
                await gioHangAPIService.Create(requestModel);
                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    message = "Thêm mới thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {

                    type = CommonConstants.ERROR,
                    message = "Thêm mới thất bại"
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Xoa(GioHangRequest requestModel)
        {
            try
            {
                await gioHangAPIService.Detele(requestModel);
                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    message = "Xóa thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {

                    type = CommonConstants.ERROR,
                    message = "Xóa thất bại"
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> GetByUser(GioHangRequest requestModel)
        {
            try
            {
                var data = await gioHangAPIService.GetByUser(requestModel);
                var count = data.totalCount;
                ViewBag.Check = count;
                Session["totalCart"] = data.totalCount;
                return Json(new
                {
                    data = data.lst,
                    recordsTotal = count,
                    recordsFiltered = count,
                    type = CommonConstants.SUCCESS,
                    message = "Thêm mới thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    message = "Thêm mới thất bại"
                });
            }
        }
    }
}