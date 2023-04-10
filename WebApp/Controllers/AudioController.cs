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
    public class AudioController : Controller
    {
        private readonly IQuanLyAudioService _QuanLyAudioService;
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;

        public AudioController(IQuanLyAudioService QuanLyAudioService, IQuanLyBaiDangService QuanLyBaiDangService)
        {
            _QuanLyAudioService = QuanLyAudioService;
            _QuanLyBaiDangService = QuanLyBaiDangService;
        }

        // GET: Audio
        public async Task<ActionResult> Index()
        {
            tbl_ThuVienAudioModel requestModel = new tbl_ThuVienAudioModel();
            requestModel.IsHienThi = 1;
            requestModel.IsCheckNgayPhatHanh = 1;
            requestModel.start = 0;
            requestModel.length = 5;
            BaseRespone<tbl_ThuVienAudioModel> response = await _QuanLyAudioService.DanhSach(requestModel);
            ViewBag.lstAudioDeXuat = response.Data;

            ViewBag.lstIdAudioMoi = "";
            if (response.Data != null)
            {
                ViewBag.lstIdAudioMoi = string.Join(",", response.Data.Select(e => e.Id).ToList());
            }

            ViewBag.Title = "Audio";
            requestModel.IsHienThi = null;
            requestModel.start = 0;
            requestModel.length = 8; 
            requestModel.IsCheckAudioMoi = 1;
            requestModel.lstIdAudioMoi = ViewBag.lstIdAudioMoi;
            requestModel.IsCheckNgayPhatHanh = 1;

            BaseRespone<tbl_ThuVienAudioModel> responseDsAudio = await _QuanLyAudioService.DanhSach(requestModel);
            ViewBag.responseDsAudio = responseDsAudio.Data;
            ViewBag.recordsTotal = responseDsAudio.recordsTotal;

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
        public async Task<JsonResult> DanhSach(tbl_ThuVienAudioModel requestModel)
        {
            try
            {
                requestModel.IsCheckNgayPhatHanh = 1;
                BaseRespone<tbl_ThuVienAudioModel> response = await _QuanLyAudioService.DanhSach(requestModel);
                if (response.Data.Count > 0)
                {
                    foreach (var item in response.Data)
                    {
                        item.Url = "/" + Utils.convertToUnSign2(item.MoTa).Replace(" ", "_") + "_au-" + item.Id + ".htm";
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

        public async Task<ActionResult> XemChiTietAudio(int Id = 0)
        {
            tbl_ThuVienAudioModel requestModelCT = new tbl_ThuVienAudioModel();
            requestModelCT.Id = Id;
            tbl_ThuVienAudioModel ChiTiet = await _QuanLyAudioService.ChiTiet(requestModelCT);
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
            BaseRespone<tbl_ThuVienAudioModel> responseDsAudio = await _QuanLyAudioService.DanhSach(requestModelCT);
            ViewBag.responseDsAudio = responseDsAudio.Data;
            ViewBag.recordsTotal = responseDsAudio.recordsTotal;


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


            return View();
        }
    }
}