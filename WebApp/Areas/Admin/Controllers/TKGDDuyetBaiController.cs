﻿using APIServices.CMS;
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
    public class TKGDDuyetBaiController : Controller
    {
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public TKGDDuyetBaiController(IQuanLyBaiDangService QuanLyBaiDangService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyBaiDangService = QuanLyBaiDangService;
            _QuanLyDanhMucService = QuanLyDanhMucService;
        }


        // GET: Admin/TKGDDuyetBai
        public async Task<ActionResult> Index()
        {
            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    StrDanhMuc += "<option value=\"" + item.ID + "\">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, new List<tbl_Post_CategoryModel>());
                }
            }
            ViewBag.optionSelected = StrDanhMuc;
            return View();
        }
        public string DataSelect(List<tbl_CategoryModel> DanhSachChuyenMuc, int IdCha, int Stt, string StrDanhMuc, List<tbl_Post_CategoryModel> LstChuyenMuc)
        {
            if (DanhSachChuyenMuc.Count > 0)
            {
                Stt = Stt + 1;

                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == IdCha))
                {
                    var kc = "";
                    for (int idx = 0; idx < Stt; idx++)
                    {
                        kc += "-- ";
                    }

                    StrDanhMuc += "<option value=" + item.ID + ">" + kc + item.Name + "</option>";
                    var checkCon = DanhSachChuyenMuc.Where(e => e.ParentID == item.ID).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataSelect(DanhSachChuyenMuc, item.ID, Stt, StrDanhMucChildren, LstChuyenMuc);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }

        [HttpPost]
        public async Task<JsonResult> DanhSachBaiViet(tbl_PostModel model)
        {
            try
            {
                BaseRespone<tbl_PostModel> response = await _QuanLyBaiDangService.DanhSachBaiDangTKGD(model);
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


        public async Task<JsonResult> DuyetHuyDuyet(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.IsTK_GDDuyetHuyDuyet(requestModel);
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

        public async Task<JsonResult> DangBaiBao(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.IsXuatBanBaiBao(requestModel);
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

        public async Task<JsonResult> TuChoiBaiViet(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.IsTK_GDTraLai(requestModel);
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

        public async Task<JsonResult> DangBaiBaoMulti(tbl_PostModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                if (requestModel.lstIdBaiViet.Count > 0)
                {
                    foreach (var item in requestModel.lstIdBaiViet)
                    {
                        requestModel.ID = item;
                        Response check = await _QuanLyBaiDangService.IsXuatBanBaiBao(requestModel);
                    }
                }
                message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                message.icon = CommonConstants.SUCCESS;
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