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
    public class VideoController : Controller
    {
        private readonly IQuanLyVideoService _QuanLyVideoService;
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;
        public VideoController(IQuanLyVideoService QuanLyVideoService, IQuanLyBaiDangService QuanLyBaiDangService)
        {
            _QuanLyVideoService = QuanLyVideoService;
            _QuanLyBaiDangService = QuanLyBaiDangService;
        }

        // GET: Video
        public async Task<ActionResult> Index()
        {
            tbl_ThuVienVideoModel requestModel = new tbl_ThuVienVideoModel();
            requestModel.IsHienThi = 1;
            requestModel.IsCheckNgayPhatHanh = 1;
            requestModel.start = 0;
            requestModel.length = 5;
            BaseRespone<tbl_ThuVienVideoModel> response = await _QuanLyVideoService.DanhSach(requestModel);
            ViewBag.lstVideoDeXuat = response.Data;
            ViewBag.lstIdVideoMoi = "";
            if (response.Data != null)
            {
                ViewBag.lstIdVideoMoi =string.Join(",", response.Data.Select(e => e.Id).ToList());
            }

            ViewBag.Title = "Video";
            requestModel.IsHienThi = null;
            requestModel.start = 0;
            requestModel.length = 8;
            requestModel.IsCheckVideoMoi = 1;
            requestModel.lstIdVideoMoi = ViewBag.lstIdVideoMoi;
            requestModel.IsCheckNgayPhatHanh = 1;

            BaseRespone<tbl_ThuVienVideoModel> responseDsVideo = await _QuanLyVideoService.DanhSach(requestModel);
            ViewBag.responseDsVideo = responseDsVideo.Data;
            ViewBag.recordsTotal = responseDsVideo.recordsTotal;
            
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
        public async Task<JsonResult> DanhSach(tbl_ThuVienVideoModel requestModel)
        {
            try
            {
                requestModel.IsCheckNgayPhatHanh = 1;
                BaseRespone<tbl_ThuVienVideoModel> response = await _QuanLyVideoService.DanhSach(requestModel);
                if (response.Data.Count > 0)
                {
                    foreach (var item in response.Data)
                    {
                        item.UrlCT = "/" + Utils.convertToUnSign2(item.MoTa).Replace(" ", "_") + "_vd-" + item.Id + ".htm";
                    }
                }
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

        public async Task<ActionResult> XemChiTietVideo(int Id)
        {
            tbl_ThuVienVideoModel requestModelCT = new tbl_ThuVienVideoModel();
            requestModelCT.Id = Id;
            tbl_ThuVienVideoModel ChiTiet = await _QuanLyVideoService.ChiTiet(requestModelCT);
            ViewBag.IdYouTube = Utils.GetYouTubeVideoIdFromUrl(ChiTiet.Video);
            ViewBag.Title = ChiTiet.MoTa;
            ViewBag.ChiTiet = ChiTiet;

            //tbl_PostModel model = new tbl_PostModel();
            //model.start = 1;
            //model.length = 8;
            //model.CategoryID = ChiTiet.CategoryID;
            //BaseRespone<tbl_PostModel> responseBaiViet = await _QuanLyBaiDangService.DanhSachBaiDangPV(model);
            //ViewBag.LstBaiViet = responseBaiViet.Data;


            requestModelCT.IsHienThi = null;
            requestModelCT.start = 1;
            requestModelCT.IsCheckNgayPhatHanh = 1;
            requestModelCT.length = 8;
            requestModelCT.Id = 0;
            BaseRespone<tbl_ThuVienVideoModel> responseDsVideo = await _QuanLyVideoService.DanhSach(requestModelCT);
            ViewBag.responseDsVideo = responseDsVideo.Data;
            ViewBag.recordsTotal = responseDsVideo.recordsTotal;

            ////Bai viet cung chuyen muc
            tbl_PostModel requestModelBaiViet = new tbl_PostModel();
            //requestModelBaiViet.start = 0;
            //requestModelBaiViet.length = 8;
            //requestModelBaiViet.IsActive = 1;
            //requestModelBaiViet.CategoryID = ChiTiet.CategoryID;
            //requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            //var lstBaiVietCungChuyenMuc = await _QuanLyBaiDangService.DanhSachBaiDangCungChuyenMuc(requestModelBaiViet);
            //ViewBag.DanhSachBaiVietCungChuyenMuc = lstBaiVietCungChuyenMuc.Data;


            ///Tin tuc moi
            ///
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 8;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
            ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;
            //var UrlDomain = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);

            return View();
        }


    }
}