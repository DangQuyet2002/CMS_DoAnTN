using APIServices.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class VanBanController : Controller
    {
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;
        private readonly IQuanLyVanBanService _QuanLyVanBanService;
        private readonly ILienKetGioiThieuService _LienKetGioiThieuService;
        private readonly ICacCapHoiService _CacCapHoiService;
        private readonly IQuanTriBannerService _QuanTriBannerService;
        private readonly IQuanLyMenuService _QuanLyMenuService;

        public char[] StrTenFile { get; private set; }

        public VanBanController(IQuanLyBaiDangService QuanLyBaiDangService, IQuanLyVanBanService QuanLyVanBanService, ILienKetGioiThieuService LienKetGioiThieuService, ICacCapHoiService CacCapHoiService,
            IQuanTriBannerService QuanTriBannerService, IQuanLyMenuService QuanLyMenuService)
        {
            _QuanLyBaiDangService = QuanLyBaiDangService;
            _QuanLyVanBanService = QuanLyVanBanService;
            _LienKetGioiThieuService = LienKetGioiThieuService;
            _CacCapHoiService = CacCapHoiService;
            _QuanTriBannerService = QuanTriBannerService;
            _QuanLyMenuService = QuanLyMenuService;
        }
        // GET: ChuyenMuc
        public async Task<ActionResult> Index(int ID = 0)
        {


            // Liên kết giơi thiệu
            tbl_LienKetGioiThieuModel requestModelLienKetGT = new tbl_LienKetGioiThieuModel();
            requestModelLienKetGT.start = 0;
            requestModelLienKetGT.length = 0;
            BaseRespone<tbl_LienKetGioiThieuModel> responseLKGT = await _LienKetGioiThieuService.DanhSach(requestModelLienKetGT);
            ViewBag.LienKetGioiThieu = responseLKGT.Data.OrderBy(e => e.STT).ToList();
            ViewBag.Title = "Văn bản";

            // Các cấp hội
            tbl_CacCapHoiModel requestModelCapHoi = new tbl_CacCapHoiModel();
            requestModelCapHoi.start = 0;
            requestModelCapHoi.length = 0;
            BaseRespone<tbl_CacCapHoiModel> responseCacCapHoi = await _CacCapHoiService.DanhSach(requestModelCapHoi);
            ViewBag.CacCapHoi = responseCacCapHoi.Data.OrderBy(e => e.STT).ToList();

            //Banner vị trí 1 ben phải
            tbl_BannerModel requestModelBannerVT1 = new tbl_BannerModel();
            requestModelBannerVT1.NgayHienTai = DateTime.Now;
            requestModelBannerVT1.start = 0;
            requestModelBannerVT1.length = 0;
            requestModelBannerVT1.IdViTri = Constants.BSo1BenPhai;
            requestModelBannerVT1.IdChuyenMuc = Constants.LstChuyenDe[1].ID;
            BaseRespone<tbl_BannerModel> responseBannerVT1 = await _QuanTriBannerService.DanhSachBannerDaGanViTri(requestModelBannerVT1);
            ViewBag.BannerTrangChuVT1 = responseBannerVT1.Data;

            requestModelBannerVT1.IdViTri = Constants.BSo2BenPhai;
            BaseRespone<tbl_BannerModel> responseBannerVT2 = await _QuanTriBannerService.DanhSachBannerDaGanViTri(requestModelBannerVT1);
            ViewBag.BannerTrangChuVT2 = responseBannerVT2.Data;

            tbl_SettingMenu_CategoryModel requestModel = new tbl_SettingMenu_CategoryModel();
            requestModel.IdSettingMenu = Constants.M_CMBenPhai_CT;
            List<tbl_SettingMenu_CategoryModel> DanhSachChuyenMucBenPhaiCT = await _QuanLyMenuService.DanhSachTheoIdSetting(requestModel);
            if (DanhSachChuyenMucBenPhaiCT.Count > 0)
            {
                foreach (var item in DanhSachChuyenMucBenPhaiCT)
                {
                    tbl_PostModel requestModelBaiViet = new tbl_PostModel();
                    requestModelBaiViet.start = 0;
                    requestModelBaiViet.length = 5;
                    requestModelBaiViet.IsActive = 1;
                    requestModelBaiViet.CategoryID = item.IdCategory;
                    requestModelBaiViet.IsCheckNgayPhatHanh = 1;
                    item.DanhSachBaiViet = (await _QuanLyBaiDangService.DanhSachBaiDangTKGD(requestModelBaiViet)).Data;
                }
            }
            ViewBag.IdCategory = ID;
            ViewBag.DanhSachChuyenMucBenPhaiCT = DanhSachChuyenMucBenPhaiCT;

            tbl_LoaiVanBanModel model = new tbl_LoaiVanBanModel();
            model.start = 0;
            model.length = 0;
            BaseRespone<tbl_LoaiVanBanModel> response = await _QuanLyVanBanService.DanhSachLoaiVanBan(model);
            ViewBag.LoaiVanBan = response.Data;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> _DanhSach(tbl_VanBanModel requestModelVanBan)
        {
            try
            {
                //Danh Sach Van Ban
                
                requestModelVanBan.length = 8;
                requestModelVanBan.IsCheckNgayPhatHanh = 1;
                int CurentPage = requestModelVanBan.start;
                requestModelVanBan.start = (requestModelVanBan.start - 1) * 8;
                requestModelVanBan.IdCategory = requestModelVanBan.IdCategory;
                BaseRespone<tbl_VanBanModel> responseVanBan = await _QuanLyVanBanService.DanhSach(requestModelVanBan);

                if (responseVanBan.Data.Count > 0)
                {
                    foreach (var item in responseVanBan.Data)
                    {
                        if (!string.IsNullOrEmpty(item.File))
                        {
                            string StrTenFile = "";
                            var lstFile = item.File.Split('/').ToList();
                            StrTenFile = lstFile[lstFile.Count - 1];
                            byte[] bytes = Encoding.Default.GetBytes(StrTenFile);
                            StrTenFile = Encoding.UTF8.GetString(bytes);
                            item.TenFile = System.Web.HttpUtility.UrlDecode(StrTenFile);
                        }
                    }
                }
                //Danh sách loại văn bản
                tbl_LoaiVanBanModel model = new tbl_LoaiVanBanModel();
                model.start = 0;
                model.length = 0;
                BaseRespone<tbl_LoaiVanBanModel> response = await _QuanLyVanBanService.DanhSachLoaiVanBan(model);
                ViewBag.DanhSachLoaiVanBan = response.Data;

                ViewBag.responseVanBan = responseVanBan.Data;
                ViewBag.HtmlPaging = Utils.HtmlPaging(CurentPage, requestModelVanBan.length, responseVanBan.recordsTotal);
                return View();
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
        public async Task<ActionResult> ChiTietVanBan(int ID = 0)
        {

            //Danh Sach Van Ban
            tbl_VanBanModel RquestModelVanBan = new tbl_VanBanModel();
            RquestModelVanBan.ID = ID;
            tbl_VanBanModel responseCTVanBan = await _QuanLyVanBanService.ChiTiet(RquestModelVanBan);

            string StrTenFile = "";
            var lstFile = responseCTVanBan.File.Split('/').ToList();
            StrTenFile = lstFile[lstFile.Count - 1];
            byte[] bytes = Encoding.Default.GetBytes(StrTenFile);
            StrTenFile = Encoding.UTF8.GetString(bytes);
            responseCTVanBan.TenFile = System.Web.HttpUtility.UrlDecode(StrTenFile);

            ViewBag.Title = responseCTVanBan.Title;
            ViewBag.responseCTVanBan = responseCTVanBan;

            // Liên kết giơi thiệu
            tbl_LienKetGioiThieuModel requestModelLienKetGT = new tbl_LienKetGioiThieuModel();
            requestModelLienKetGT.start = 0;
            requestModelLienKetGT.length = 0;
            BaseRespone<tbl_LienKetGioiThieuModel> responseLKGT = await _LienKetGioiThieuService.DanhSach(requestModelLienKetGT);
            ViewBag.LienKetGioiThieu = responseLKGT.Data.OrderBy(e => e.STT).ToList();


            // Các cấp hội
            tbl_CacCapHoiModel requestModelCapHoi = new tbl_CacCapHoiModel();
            requestModelCapHoi.start = 0;
            requestModelCapHoi.length = 0;
            BaseRespone<tbl_CacCapHoiModel> responseCacCapHoi = await _CacCapHoiService.DanhSach(requestModelCapHoi);
            ViewBag.CacCapHoi = responseCacCapHoi.Data.OrderBy(e => e.STT).ToList();

            //Banner vị trí 1 ben phải
            tbl_BannerModel requestModelBannerVT1 = new tbl_BannerModel();
            requestModelBannerVT1.NgayHienTai = DateTime.Now;
            requestModelBannerVT1.start = 0;
            requestModelBannerVT1.length = 0;
            requestModelBannerVT1.IdViTri = Constants.BSo1BenPhai;
            requestModelBannerVT1.IdChuyenMuc = Constants.LstChuyenDe[1].ID;
            BaseRespone<tbl_BannerModel> responseBannerVT1 = await _QuanTriBannerService.DanhSachBannerDaGanViTri(requestModelBannerVT1);
            ViewBag.BannerTrangChuVT1 = responseBannerVT1.Data;

            requestModelBannerVT1.IdViTri = Constants.BSo2BenPhai;
            BaseRespone<tbl_BannerModel> responseBannerVT2 = await _QuanTriBannerService.DanhSachBannerDaGanViTri(requestModelBannerVT1);
            ViewBag.BannerTrangChuVT2 = responseBannerVT2.Data;

            tbl_SettingMenu_CategoryModel requestModel = new tbl_SettingMenu_CategoryModel();
            requestModel.IdSettingMenu = Constants.M_CMBenPhai_CT;
            List<tbl_SettingMenu_CategoryModel> DanhSachChuyenMucBenPhaiCT = await _QuanLyMenuService.DanhSachTheoIdSetting(requestModel);
            tbl_PostModel requestModelBaiViet = new tbl_PostModel();
            if (DanhSachChuyenMucBenPhaiCT.Count > 0)
            {
                foreach (var item in DanhSachChuyenMucBenPhaiCT)
                {
                    requestModelBaiViet = new tbl_PostModel();
                    requestModelBaiViet.start = 0;
                    requestModelBaiViet.length = 5;
                    requestModelBaiViet.IsActive = 1;
                    requestModelBaiViet.CategoryID = item.IdCategory;
                    requestModelBaiViet.IsCheckNgayPhatHanh = 1;
                    item.DanhSachBaiViet = (await _QuanLyBaiDangService.DanhSachBaiDangTKGD(requestModelBaiViet)).Data;
                }
            }

            ViewBag.DanhSachChuyenMucBenPhaiCT = DanhSachChuyenMucBenPhaiCT;


            ////Bai viet cung chuyen muc
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 8;
            requestModelBaiViet.IsActive = 1;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            requestModelBaiViet.CategoryID = responseCTVanBan.IdCategory != null ? (int)responseCTVanBan.IdCategory : 0;
            var lstBaiVietCungChuyenMuc = await _QuanLyBaiDangService.DanhSachBaiDangCungChuyenMuc(requestModelBaiViet);
            ViewBag.DanhSachBaiVietCungChuyenMuc = lstBaiVietCungChuyenMuc.Data;


            ///Tin tuc moi
            ///
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 4;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
            ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;

            return View();
        }




    }
}