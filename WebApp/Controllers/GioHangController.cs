﻿using APIServices;
using Azure.Core;
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