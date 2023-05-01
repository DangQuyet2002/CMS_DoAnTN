using APIServices;
using Microsoft.Graph;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class DatHangController : Controller
    {
        private readonly IBillAPIService _billAPIService;
        private readonly IGioHangAPIService _giohangAPIService;
        public DatHangController()
        {
            _billAPIService = new BillAPIService();
            _giohangAPIService = new GioHangAPIService();
        }
        // GET: DatHang
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> DSDonHang(BillRequest requestModel)
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
                    message = "Thêm mới thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = "error",
                    message = "Thêm mới thất bại!" + ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> DSDonHangTheoUser(BillRequest requestModel)
        {
            try
            {
                var data = await _billAPIService.GetByUser(requestModel);
                var count = data.totalCount;
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
                    type = "error",
                    message = "Thêm mới thất bại!" + ex.Message
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Themmoi(Bill requestModel)
        {
            try
            {
                foreach (var item in requestModel.ListIdCart.Split(','))
                {
                    var idGioHang = Int32.Parse(item);
                    var data = await _giohangAPIService.GetByIdBill(idGioHang);
                    if (data != null)
                    {

                        requestModel.IdPro = data.ProductId;
                        requestModel.Product = data.ProductName;
                        requestModel.ColorId = data.ColorId;
                        requestModel.SizeId = data.SizeId;
                        requestModel.Quantity = data.Quantity;
                        requestModel.Price = data.Price;
                        requestModel.Total = data.Total;
                        await _billAPIService.Create(requestModel);
                    }
                    
                }
                return Json(new
                {
                    type = "success",
                    message = "Thêm mới thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = "error",
                    message = "Thêm mới thất bại!" + ex.Message
                });
            }
        }

    }
}