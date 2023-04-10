using APIServices;
using APIServices.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ThongTinChiHoiController : Controller
    {
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;
        private readonly IQuanLyVanBanService _QuanLyVanBanService;
        private readonly ILienKetGioiThieuService _LienKetGioiThieuService;
        private readonly ICacCapHoiService _CacCapHoiService;
        private readonly IQuanTriBannerService _QuanTriBannerService;
        private readonly IQuanLyMenuService _QuanLyMenuService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;
        private readonly IQuanLyChiHoiService _QuanLyChiHoiService;

        public ThongTinChiHoiController(IQuanLyBaiDangService QuanLyBaiDangService, IQuanLyVanBanService QuanLyVanBanService, ILienKetGioiThieuService LienKetGioiThieuService, ICacCapHoiService CacCapHoiService,
            IQuanTriBannerService QuanTriBannerService, IQuanLyMenuService QuanLyMenuService, IQuanLyDanhMucService QuanLyDanhMucService, IQuanLyChiHoiService QuanLyChiHoiService)
        {
            _QuanLyBaiDangService = QuanLyBaiDangService;
            _QuanLyVanBanService = QuanLyVanBanService;
            _LienKetGioiThieuService = LienKetGioiThieuService;
            _CacCapHoiService = CacCapHoiService;
            _QuanTriBannerService = QuanTriBannerService;
            _QuanLyMenuService = QuanLyMenuService;
            _QuanLyDanhMucService = QuanLyDanhMucService;
            _QuanLyChiHoiService = QuanLyChiHoiService;
        }

        // GET: ThongTinChiHoi
        public async Task<ActionResult> Index()
        {
            tbl_LikePostModel requestModelLike = new tbl_LikePostModel();
            tbl_ChiHoiTTModel requestModelChiHoi = new tbl_ChiHoiTTModel();
            List<tbl_ChiHoiTTModel> DanhSachChiHoi = await _QuanLyChiHoiService.DanhSach(requestModelChiHoi);
            ViewBag.DanhSachChiHoi = DanhSachChiHoi;

            ///Tin tuc moi
            ///
            tbl_PostModel requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 4;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
            ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;


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
            ViewBag.ThongTinND = (tbl_UserModel)Session[Constants.SSUserInforKH];

            return View();
        }
    }
}