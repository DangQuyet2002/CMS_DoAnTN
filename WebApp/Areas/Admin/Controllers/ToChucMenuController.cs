using APIServices.CMS;
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
    public class ToChucMenuController : Controller
    {
        private readonly IQuanLyMenuService _QuanLyMenuService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public ToChucMenuController(IQuanLyMenuService QuanLyMenuService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyMenuService = QuanLyMenuService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }

        // GET: Admin/ToChucMenu
        public async Task<ActionResult> Index()
        {
            tbl_SettingMenu_CategoryModel requestModel = new tbl_SettingMenu_CategoryModel();
            ViewBag.lstSettingMenu = await _QuanLyMenuService.DanhSachSettingMenu(requestModel);
            return View();
        }

        public async Task<JsonResult> TreeTableDanhMuc(tbl_CategoryModel requestModel)
        {
            try
            {
                List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSachAll(requestModel);
                List<tbl_CategoryModel> Respone = new List<tbl_CategoryModel>();

                if(requestModel.IdSettingMenu!= Constants.M_TopMenu)
                {
                    DanhSachChuyenMuc = DanhSachChuyenMuc.Where(e => e.LoaiCategory_Khac == 0).ToList();
                }

                var lstChuyenMucHoatDong = DanhSachChuyenMuc.Where(e => e.IsActive == true).ToList();

                if (lstChuyenMucHoatDong.Count > 0)
                {
                    foreach (var item in lstChuyenMucHoatDong)
                    {
                        Respone = GetAllDanhMucHoatDong(DanhSachChuyenMuc, item, Respone);
                    }
                }
                tbl_SettingMenu_CategoryModel requestModelMenu = new tbl_SettingMenu_CategoryModel();
                requestModelMenu.IdSettingMenu = requestModel.IdSettingMenu;
                List<tbl_SettingMenu_CategoryModel> DanhSachChuyenMucMenu = await _QuanLyMenuService.DanhSachTheoIdSetting(requestModelMenu);

                string StrDanhMuc = "";
                StrDanhMuc = DataStrDanhMuc(Respone, 0, 0, StrDanhMuc, DanhSachChuyenMucMenu);

                return Json(new JsonResponse
                {
                    data = StrDanhMuc,
                    type = CommonConstants.SUCCESS
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new JsonResponse { type = CommonConstants.ERROR, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public string DataStrDanhMuc(List<tbl_CategoryModel> DanhSachChuyenMuc, int IdCha, int Stt, string StrDanhMuc, List<tbl_SettingMenu_CategoryModel> DanhSachChuyenMucMenu)
        {
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == IdCha))
                {
                    Stt = Stt + 1;
                    if (IdCha == 0)
                    {
                        var StrThaoTac = "";
                        if (item.IsActive && DanhSachChuyenMucMenu.Where(e => e.IdCategory == item.ID).Count() > 0)
                        {
                            StrThaoTac += "<td class=\"text-center\"><a class=\"btn btn-outline-primary waves-effect waves-light btn-xs\" href=\"#\" title=\"Đã thêm\"><i class=\" ri-check-line\"></i></a></td>";
                        }
                        else if (item.IsActive && DanhSachChuyenMucMenu.Where(e => e.IdCategory == item.ID).Count() == 0)
                        {
                            StrThaoTac += " <td class=\"text-center\"><a class=\"btn btn-outline-primary waves-effect waves-light btn-xs\" href=\"#\" onclick=\"ThemMoiMenu(" + item.ID + ")\" title=\"Thêm mới\"><i class=\"ri-add-line\"></i></a></td>";
                        }
                        else
                        {
                            StrThaoTac += "<td class=\"text-center\"></td>";
                        }
                        StrDanhMuc += "<tr class=\"treegrid-" + item.ID + "\"><td>" + item.Name + "</td>" + StrThaoTac + "</tr>";
                    }
                    else
                    {
                        var StrThaoTac = "";
                        if (item.IsActive && DanhSachChuyenMucMenu.Where(e => e.IdCategory == item.ID).Count() > 0)
                        {
                            StrThaoTac += "<td class=\"text-center\"><a class=\"btn btn-outline-primary waves-effect waves-light btn-xs\" href=\"#\" title=\"Đã thêm\"><i class=\" ri-check-line\"></i></a></td>";
                        }
                        else if (item.IsActive && DanhSachChuyenMucMenu.Where(e => e.IdCategory == item.ID).Count() == 0)
                        {
                            StrThaoTac += " <td class=\"text-center\"><a class=\"btn btn-outline-primary waves-effect waves-light btn-xs\" href=\"#\" onclick=\"ThemMoiMenu(" + item.ID + ")\" title=\"Thêm mới\"><i class=\"ri-add-line\"></i></a></td>";
                        }
                        else
                        {
                            StrThaoTac += "<td class=\"text-center\"></td>";
                        }
                        StrDanhMuc += "<tr class=\"treegrid-" + item.ID + " treegrid-parent-" + IdCha + "\"><td>" + item.Name + "</td>" + StrThaoTac + "</tr>";
                    }
                    var checkCon = DanhSachChuyenMuc.Where(e => e.ParentID == item.ID).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataStrDanhMuc(DanhSachChuyenMuc, item.ID, Stt, StrDanhMucChildren, DanhSachChuyenMucMenu);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }

        public List<tbl_CategoryModel> GetAllDanhMucHoatDong(List<tbl_CategoryModel> DanhSachChuyenMuc, tbl_CategoryModel ChuyenMucHoatDong, List<tbl_CategoryModel> KetQua)
        {
            var check = KetQua.Where(e => e.ID == ChuyenMucHoatDong.ID).FirstOrDefault();
            if (check == null) KetQua.Add(ChuyenMucHoatDong);

            var DanhSachChuyenMucCha = DanhSachChuyenMuc.Where(e => e.ID == ChuyenMucHoatDong.ParentID).ToList();
            if (DanhSachChuyenMucCha.Count > 0)
            {
                foreach (var item in DanhSachChuyenMucCha)
                {

                    var checkItem = KetQua.Where(e => e.ID == ChuyenMucHoatDong.ID).FirstOrDefault();
                    if (checkItem == null) KetQua.Add(item);

                    var CheckMain = DanhSachChuyenMuc.Where(e => e.ID == item.ParentID).FirstOrDefault();
                    if (CheckMain != null)
                    {
                        KetQua = GetAllDanhMucHoatDong(DanhSachChuyenMuc, CheckMain, KetQua);
                    }
                }
            }
            return KetQua;
        }

        public async Task<JsonResult> DanhSachChuyenMucMenu(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                List<tbl_SettingMenu_CategoryModel> DanhSachChuyenMuc = await _QuanLyMenuService.DanhSachTheoIdSetting(requestModel);
                return Json(new JsonResponse
                {
                    data = DanhSachChuyenMuc,
                    type = CommonConstants.SUCCESS
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new JsonResponse { type = CommonConstants.ERROR, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> CapNhatSTT(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyMenuService.CapNhatSTT(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_UPDATE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                    message.type = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_UPDATE_FAILED;
                    message.icon = CommonConstants.ERROR;
                    message.type = CommonConstants.SUCCESS;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                return Json(new JsonResponse { type = CommonConstants.ERROR, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> ThemMoi(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyMenuService.ThemMoi(requestModel);
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
                    message.type = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                return Json(new JsonResponse { type = CommonConstants.ERROR, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<JsonResult> Xoa(tbl_SettingMenu_CategoryModel requestModel)
        {
            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyMenuService.Xoa(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_DELETE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                    message.type = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_DELETE_FAILED;
                    message.icon = CommonConstants.ERROR;
                    message.type = CommonConstants.SUCCESS;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                return Json(new JsonResponse { type = CommonConstants.ERROR, message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}