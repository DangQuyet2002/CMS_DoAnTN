using APIServices;
using Azure.Core;
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
        private readonly IProductsAPIService _productAPIService;

        public DatHangController()
        {
            _billAPIService = new BillAPIService();
            _giohangAPIService = new GioHangAPIService();
            _productAPIService = new ProductsAPIService();
        }
        // GET: DatHang
        public async Task<ActionResult> Index(BillRequest request)
        {
            var data = await _billAPIService.GetByUser(request);
            ViewBag.Data = data.lst;
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
                    // Lấy thông tin sản phẩm trong giỏ hàng
                    var idGioHang = Int32.Parse(item);
                    var data = await _giohangAPIService.GetByIdBill(idGioHang);
                    if (data != null)
                    {
                        requestModel.IdUser = data.UserId;
                        requestModel.Address = requestModel.Address;
                        requestModel.NameReceiver = requestModel.NameReceiver;
                        requestModel.Phone = requestModel.Phone;
                        requestModel.Status = 1;
                        requestModel.IdPro = data.ProductId;
                        requestModel.Product = data.ProductName;
                        requestModel.ColorId = data.ColorId;
                        requestModel.SizeId = data.SizeId;
                        requestModel.Quantity = data.Quantity;
                        requestModel.Image = data.Image;
                        requestModel.TotalNew = requestModel.TotalNew;
                        requestModel.Price = data.Price;
                        requestModel.Total = data.Total;
                        await _billAPIService.Create(requestModel);

                        // Trừ số lượng sản phẩm trong product
                        var product = await _productAPIService.GetById(requestModel.IdPro);
                        if (product != null)
                        {
                            product.Quantity -= requestModel.Quantity;
                            await _productAPIService.UpdateQuantity(product);
                        }
                    }

                    // Xóa giỏ hàng
                    GioHangRequest requestGioHang = new GioHangRequest();
                    requestGioHang.ListId = item;
                    
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
        [HttpPost]
        public async Task<ActionResult> XoaDonHang(Bill requestModel)
        {
            try
            {
                requestModel.Status = 5;
                await _billAPIService.Update(requestModel);

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
    }
}