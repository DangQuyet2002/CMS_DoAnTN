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
    public class ChuyenMucController : Controller
    {
        private readonly IQuanLyBaiDangService _QuanLyBaiDangService;
        private readonly IQuanLyVanBanService _QuanLyVanBanService;
        private readonly ILienKetGioiThieuService _LienKetGioiThieuService;
        private readonly ICacCapHoiService _CacCapHoiService;
        private readonly IQuanTriBannerService _QuanTriBannerService;
        private readonly IQuanLyMenuService _QuanLyMenuService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public ChuyenMucController(IQuanLyBaiDangService QuanLyBaiDangService, IQuanLyVanBanService QuanLyVanBanService, ILienKetGioiThieuService LienKetGioiThieuService, ICacCapHoiService CacCapHoiService,
            IQuanTriBannerService QuanTriBannerService, IQuanLyMenuService QuanLyMenuService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyBaiDangService = QuanLyBaiDangService;
            _QuanLyVanBanService = QuanLyVanBanService;
            _LienKetGioiThieuService = LienKetGioiThieuService;
            _CacCapHoiService = CacCapHoiService;
            _QuanTriBannerService = QuanTriBannerService;
            _QuanLyMenuService = QuanLyMenuService;
            _QuanLyDanhMucService = QuanLyDanhMucService;
        }

        // GET: BaiViet
        public async Task<ActionResult> Index(int ID)
        {
            //Thong tin chi tiet chuyen muc
            tbl_CategoryModel requestModelCM = new tbl_CategoryModel();
            requestModelCM.ID = ID;
            tbl_CategoryModel ChiTiet = await _QuanLyDanhMucService.ChiTiet(requestModelCM);
            ViewBag.Title = ChiTiet.Name;
            ViewBag.ChiTietDM = ChiTiet;


            //Bai viet trong chuyen muc
            tbl_PostModel requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 5;
            requestModelBaiViet.IsActive = 1;
            requestModelBaiViet.CategoryID = ID;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            var lstBaiViet = await _QuanLyBaiDangService.DanhSachBaiDangTKGD(requestModelBaiViet);
            ViewBag.DanhSachBaiViet = lstBaiViet.Data;
            ViewBag.CategoryID = ID;

            ///Tin tuc moi
            ///
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 4;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
            ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;
            ViewBag.recordsTotalTinTucMoi = DanhSachBaiVietMoi.recordsTotal;

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
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> _DanhSach(tbl_PostModel requestModel)
        {
            try
            {
                int CurentPage = requestModel.start+1;
                tbl_PostModel requestModelBaiViet = new tbl_PostModel();
                requestModelBaiViet.start = requestModel.start * 6;
                requestModelBaiViet.length = 6;
                requestModelBaiViet.IsActive = 1;
                requestModelBaiViet.CategoryID = requestModel.CategoryID;
                requestModelBaiViet.IsCheckNgayPhatHanh = 1;
                var lstBaiViet = await _QuanLyBaiDangService.DanhSachBaiDangTKGD(requestModelBaiViet);
                ViewBag.DanhSachBaiViet = lstBaiViet.Data;
                ViewBag.TongBanGhi = lstBaiViet.recordsTotal;
                ViewBag.HtmlPaging = Utils.HtmlPaging(CurentPage, requestModelBaiViet.length, lstBaiViet.recordsTotal - 6);
                ////Danh Sach Van Ban
                //requestModelVanBan.length = 8;
                //int CurentPage = requestModelVanBan.start;
                //requestModelVanBan.start = (requestModelVanBan.start - 1) * 8;
                //BaseRespone<tbl_VanBanModel> responseVanBan = await _QuanLyVanBanService.DanhSach(requestModelVanBan);
                //ViewBag.responseVanBan = responseVanBan.Data;
                //ViewBag.HtmlPaging = Utils.HtmlPaging(CurentPage, requestModelVanBan.length, responseVanBan.recordsTotal);
                return View();
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
        public async Task<ActionResult> ChiTietBaiViet(int ID, int IsView = 0)
        {

            tbl_LikePostModel requestModelLike = new tbl_LikePostModel();
            tbl_UserModel User = (tbl_UserModel)Session[Constants.SSUserInforKH];
            requestModelLike.IdUser = User != null ? User.ID : -1;
            requestModelLike.IdPost = ID;
            ViewBag.ResponeLike = await _QuanLyBaiDangService.ChiTietLike(requestModelLike);


            ViewBag.IdBaiViet = ID;
            tbl_PostModel requestModelCT = new tbl_PostModel();
            requestModelCT.ID = ID;
            //Them so luot xem
            if (IsView == 0)
            {
                var CapNhatLuotXem = await _QuanLyBaiDangService.CapNhatLuotXem(requestModelCT);
            }

            //Thong tin chi tiet bai viet
            var ChiTietBaiViet = await _QuanLyBaiDangService.ChiTiet(requestModelCT);
            ViewBag.Title = ChiTietBaiViet.Title;
            ViewBag.ChiTietBaiViet = ChiTietBaiViet;

            //Thong tin chi tiet chuyen muc
            tbl_CategoryModel requestModelCM = new tbl_CategoryModel();
            requestModelCM.ID = ChiTietBaiViet.ID;
            tbl_CategoryModel ChiTiet = await _QuanLyDanhMucService.ChiTietChuyenMucBaiViet(requestModelCM);
            ViewBag.ChiTietDM = ChiTiet;

            //Bai viet cung chuyen muc
            tbl_PostModel requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 8;
            requestModelBaiViet.IsActive = 1;
            requestModelBaiViet.ID = ChiTietBaiViet.ID;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            var lstBaiVietCungChuyenMuc = await _QuanLyBaiDangService.DanhSachBaiDangCungChuyenMuc(requestModelBaiViet);
            ViewBag.DanhSachBaiVietCungChuyenMuc = lstBaiVietCungChuyenMuc.Data;



            ////Bai viet trong chuyen muc
            //requestModelBaiViet = new tbl_PostModel();
            //requestModelBaiViet.start = 0;
            //requestModelBaiViet.length = 5;
            //requestModelBaiViet.IsActive = 1;
            //requestModelBaiViet.CategoryID = ID;
            //var lstBaiViet = await _QuanLyBaiDangService.DanhSachBaiDangTKGD(requestModelBaiViet);
            //ViewBag.DanhSachBaiViet = lstBaiViet.Data;

            ///Tin tuc moi
            ///
            requestModelBaiViet = new tbl_PostModel();
            requestModelBaiViet.start = 0;
            requestModelBaiViet.length = 4;
            requestModelBaiViet.IsCheckNgayPhatHanh = 1;
            BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
            ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;
            ViewBag.recordsTotalTinTucMoi = DanhSachBaiVietMoi.recordsTotal;


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

        public async Task<ActionResult> _DanhSachBL(int IdBaiViet)
        {
            tbl_CommentModel requestModelCT = new tbl_CommentModel();
            requestModelCT.IdPost = IdBaiViet;
            //Them so luot xem
            ViewBag.DanhSachBinhLuan = (await _QuanLyBaiDangService.DanhSachBinhLuan(requestModelCT)).OrderByDescending(e => e.CreatedDate).ToList();
            return View();
        }

        public async Task<JsonResult> ThemMoiBinhLuan(tbl_CommentModel requestModel)
        {

            try
            {
                tbl_UserModel User = (tbl_UserModel)Session[Constants.SSUserInforKH];
                requestModel.CreatedDate = DateTime.Now;
                requestModel.IdUser = User.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.ThemMoiBinhLuan(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_CREATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_CREATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<JsonResult> ThemMoiLike(tbl_LikePostModel requestModel)
        {

            try
            {
                tbl_UserModel User = (tbl_UserModel)Session[Constants.SSUserInforKH];
                requestModel.IdUser = User.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.ThemMoiLike(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_CREATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                    message.type = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_CREATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                    message.type = CommonConstants.SUCCESS;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;
                message.type = CommonConstants.ERROR;
                return Json(message);
            }
        }
         
        public async Task<JsonResult> XoaLike(tbl_LikePostModel requestModel)
        {

            try
            {
                tbl_UserModel User = (tbl_UserModel)Session[Constants.SSUserInforKH];
                requestModel.IdUser = User.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyBaiDangService.XoaLike(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_CREATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                    message.type = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_CREATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                    message.type = CommonConstants.SUCCESS;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;
                message.type = CommonConstants.ERROR;
                return Json(message);
            }
        }


        public async Task<ActionResult> _DanhSachTinMoi(tbl_PostModel requestModelBaiViet)
        {
            try
            {
                requestModelBaiViet.length = 5;
                requestModelBaiViet.start = requestModelBaiViet.start - 1;
                requestModelBaiViet.IsCheckNgayPhatHanh = 1;
                BaseRespone<tbl_PostModel> DanhSachBaiVietMoi = await _QuanLyBaiDangService.DanhSachBaiDangMoi(requestModelBaiViet);
                ViewBag.TinTucMoi = DanhSachBaiVietMoi.Data;

                
                ViewBag.HtmlPaging = Utils.HtmlPaging(requestModelBaiViet.start+1, requestModelBaiViet.length, DanhSachBaiVietMoi.recordsTotal);
                return View();
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }

    }
}