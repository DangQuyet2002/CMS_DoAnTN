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

namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        
        private readonly IGioHangAPIService gioHangAPIService;
        private readonly IColorAPIService ColorAPIService;
        private readonly ISizeAPIService SizeAPIService;
        public GioHangController()
        {
            gioHangAPIService = new GioHangAPIService();
            ColorAPIService = new ColorAPIService();
            SizeAPIService = new SizeAPIService();
        }
        // GET: GioHang

        public async Task<ActionResult> Index(GioHangRequest requestModel, ColorRequest Modelcolor, SizeRequest SizeModel)
        {
            var data = await gioHangAPIService.GetByUser(requestModel);
            ViewBag.DataGH = data.lst;

            var colorResult = await ColorAPIService.GetAll(Modelcolor);
            
            ViewBag.ColorList = colorResult;


            var sizeResult = await SizeAPIService.GetAll(SizeModel);
            ViewBag.SizeList = sizeResult;


            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Action(int Id)
        {
            var gioHangRequest = new GioHangRequest
            {
                Id = Id,
            };

            var data = await gioHangAPIService.GetByUser(gioHangRequest);
            Session["datagiohang"] = data;
            return PartialView();
        }

        [HttpPost]
        public async Task<ActionResult> Themmoi(GioHang requestModel, GioHangRequest request)
        {
            try
            {
                requestModel.Total = requestModel.Price * requestModel.Quantity;
                request.Id = requestModel.UserId;

                // Kiểm tra xem sản phẩm đã tồn tại trong giỏ hàng chưa
                var gioHangSession = Session["datagiohang"] as GioHangPaging;
                var datahg = await gioHangAPIService.GetByUser(request);

                if (datahg != null)
                {
                    var existingProduct = datahg.lst.FirstOrDefault(p =>
                        p.ProductId == requestModel.ProductId &&
                        p.ColorId == requestModel.ColorId &&
                        p.SizeId == requestModel.SizeId);

                    if (existingProduct != null)
                    {
                        existingProduct.Quantity += requestModel.Quantity;
                        existingProduct.Total = existingProduct.Price * existingProduct.Quantity;

                        requestModel.Id = existingProduct.Id;
                        requestModel.Quantity = existingProduct.Quantity;

                        await gioHangAPIService.UpdateQuantity(requestModel);

                        Session["datagiohang"] = gioHangSession;

                        return Json(new
                        {
                            type = CommonConstants.MSG_UPDATE_SUCCESS,
                            message = "Sản phẩm đã tồn tại trong giỏ hàng, số lượng đã được cập nhật"
                        });
                    }
                }
                else
                {
                    gioHangSession = new GioHangPaging();
                    gioHangSession.lst = new List<GioHang>();
                }

                await gioHangAPIService.Create(requestModel);
                gioHangSession.lst.Add(requestModel);
                gioHangSession.Count = gioHangSession.lst.Count;

                Session["datagiohang"] = gioHangSession;

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
                var gioHangSession = Session["datagiohang"] as GioHangPaging;

                if (gioHangSession != null)
                {
                    gioHangSession.lst.RemoveAll(item => item.Id == requestModel.Id);
                    var gioHangCount = gioHangSession.lst.Count;
                    var updatedGioHangSession = new GioHangPaging
                    {
                        lst = gioHangSession.lst,
                        Count = gioHangCount
                    };

                    // Lưu giỏ hàng mới vào session
                    Session["datagiohang"] = updatedGioHangSession;
                }

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
        [HttpPost]
        public async Task<ActionResult> Update(GioHang requestModel)
        {
            try
            {
                var data = await gioHangAPIService.Update(requestModel);
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

        public async Task<ActionResult> UpdateColor(GioHang requestModel)
        {
            try
            {
                var data = await gioHangAPIService.UpdateColor(requestModel);
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
        public async Task<ActionResult> UpdateQuantity(GioHang requestModel)
        {
            try
            {
                var data = await gioHangAPIService.UpdateQuantity(requestModel);
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