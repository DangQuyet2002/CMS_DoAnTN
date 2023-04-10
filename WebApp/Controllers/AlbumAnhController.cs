using APIServices.CMS;
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
    public class AlbumAnhController : Controller
    {
        private readonly IQuanLyAlbumAnhService _QuanTriAlbumAnhService;

        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;

        public AlbumAnhController(IQuanLyAlbumAnhService QuanTriAlbumAnhService, IQuanLyDanhMucService QuanLyDanhMucService, IQuanLyBaiDangService QuanLyBaiDangService)
        {
            _QuanTriAlbumAnhService = QuanTriAlbumAnhService;
            _QuanLyDanhMucService = QuanLyDanhMucService;
            _QuanLyBaiDangService = QuanLyBaiDangService;

        }

        // GET: AlbumAnh
        public async Task<ActionResult> Index()
        {
            tbl_ThuVienAnhModel requestModel = new tbl_ThuVienAnhModel();
            requestModel.IsCheckNgayPhatHanh = 1;
            requestModel.IsHienThi = 1;
            BaseRespone<tbl_ThuVienAnhModel> response = await _QuanTriAlbumAnhService.DanhSach(requestModel);
            ViewBag.lstAnhSlide = response.Data;
            ViewBag.Title = "Album ảnh";
            requestModel.IsHienThi = 0;
            requestModel.start = 0;
            requestModel.length = 8;
            BaseRespone<tbl_ThuVienAnhModel> responseDsAnh = await _QuanTriAlbumAnhService.DanhSach(requestModel);
            ViewBag.responseDsAnh = responseDsAnh.Data;
            ViewBag.recordsTotal = responseDsAnh.recordsTotal;

            ///Tin tuc moi
            ///
            tbl_PostModel requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 8;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
            ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;


            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                requestModel.IsHienThi = 1;
                BaseRespone<tbl_ThuVienAnhModel> response = await _QuanTriAlbumAnhService.DanhSach(requestModel);
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


        [HttpPost]
        public async Task<ActionResult> _ChiTiet(tbl_ThuVienAnhModel requestModel)
        {
            try
            {
                tbl_ThuVienAnhModel response = await _QuanTriAlbumAnhService.ChiTiet(requestModel);
                ViewBag.ChiTiet = response;
                ViewBag.Id = requestModel.Id;
                return View();
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }


        [HttpPost]
        public async Task<ActionResult> _ChiTietAnhAlbum(int IdAlbum, int IdAnh)
        {
            try
            {
                tbl_ThuVienAnhModel requestModel = new tbl_ThuVienAnhModel();
                requestModel.Id = IdAlbum;
                tbl_ThuVienAnhModel response = await _QuanTriAlbumAnhService.ChiTiet(requestModel);
                ViewBag.ChiTiet = response;
                ViewBag.IdAnh = IdAnh;
                return View();
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
    }
}