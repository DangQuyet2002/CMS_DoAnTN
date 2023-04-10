using APIServices.CMS;
using APIServices.CMS.QuanLyDanhMuc;
using Models;
using Newtonsoft.Json;
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
    public class QuanLyDanhMucController : Controller
    {
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;


        public QuanLyDanhMucController(IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _QuanLyDanhMucService = QuanLyDanhMucService;
        }
        // GET: Admin/QuanLyDanhMuc
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> TreeTableDanhMuc(tbl_CategoryModel requestModel)
        {
            try
            {
                List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
                string StrDanhMuc = "";
                StrDanhMuc = DataStrDanhMuc(DanhSachChuyenMuc, 0, 0, StrDanhMuc);

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


        public string DataStrDanhMuc(List<tbl_CategoryModel> DanhSachDonVi, int IdCha, int Stt, string StrDanhMuc)
        {
            if (DanhSachDonVi.Count > 0)
            {
                foreach (var item in DanhSachDonVi.Where(e => e.ParentID == IdCha))
                {
                    Stt = Stt + 1;
                    if (IdCha == 0)
                    {
                        var TThai = (item.IsActive == true ? "<span class=\"badge bg-primary\">Hoạt động</span>" : "<span class=\"badge bg-danger\">Không hoạt động</span>");
                        StrDanhMuc += "<tr class=\"treegrid-" + item.ID + "\"><td>" + item.Name + "</td><td class=\" text-center\">" + TThai + "</td><td class=\" text-center\">"
                            + "<div class=\"dropdown\">"
                                + "<a href=\"#\" role=\"button\" id=\"dropdownMenuLink5\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\" class=\"\">"
                                + "<i class=\"ri-more-2-fill\"></i></a>"
                                + "<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink5\" style=\"\">"
                                    + "<li><a class=\"dropdown-item\" href=\"#\" onclick=\"Sua(" + item.ID + ")\"><i class=\"ri-edit-2-line\"></i>Sửa</a></li>"
                                    + "<li><a class=\"dropdown-item link-danger\" href=\"#\" onclick=\"Xoa(" + item.ID + ")\"><i class=\"ri-delete-bin-line\"></i>Xóa</a></li>"
                                + "</ul></div>"
                            + "</td></tr>";
                    }
                    else
                    {
                        var TThai = (item.IsActive == true ? "<span class=\"badge bg-primary\">Hoạt động</span>" : "<span class=\"badge bg-danger\">Không hoạt động</span>");
                        StrDanhMuc += "<tr class=\"treegrid-" + item.ID + " treegrid-parent-" + IdCha + "\"><td>" + item.Name + "</td><td class=\" text-center\">" + TThai + "</td><td class=\" text-center\">"
                           + "<div class=\"dropdown\">"
                               + "<a href=\"#\" role=\"button\" id=\"dropdownMenuLink5\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\" class=\"\">"
                               + "<i class=\"ri-more-2-fill\"></i></a>"
                               + "<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink5\" style=\"\">"
                                    + "<li><a class=\"dropdown-item\" href=\"#\" onclick=\"Sua(" + item.ID + ")\"><i class=\"ri-edit-2-line\"></i>Sửa</a></li>"
                                    + "<li><a class=\"dropdown-item link-danger\" href=\"#\" onclick=\"Xoa(" + item.ID + ")\"><i class=\"ri-delete-bin-line\"></i>Xóa</a></li>"
                               + "</ul></div>"
                           + "</td></tr>";
                    }
                    var checkCon = DanhSachDonVi.Where(e => e.ParentID == item.ID).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataStrDanhMuc(DanhSachDonVi, item.ID, Stt, StrDanhMucChildren);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }

        public async Task<ActionResult> _ThemMoi()
        {
            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    StrDanhMuc += "<option value=" + item.ID + ">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc);
                }
            }
            ViewBag.optionSelected = StrDanhMuc;
            return View();
        }
        public async Task<ActionResult> _Sua(int Id)
        {
            tbl_CategoryModel requestModel = new tbl_CategoryModel();
            requestModel.ID = Id;
            tbl_CategoryModel ChiTiet = await _QuanLyDanhMucService.ChiTiet(requestModel);
            ViewBag.ChiTiet = ChiTiet;
            List<tbl_CategoryModel> DanhSachChuyenMuc = await _QuanLyDanhMucService.DanhSach(requestModel);
            var StrDanhMuc = "";
            if (DanhSachChuyenMuc.Count > 0)
            {
                foreach (var item in DanhSachChuyenMuc.Where(e => e.ParentID == 0))
                {
                    var check = (item.ID == ChiTiet.ParentID ? "selected" : "");
                    StrDanhMuc += "<option  " + check + " value=" + item.ID + ">" + item.Name + "</option>";
                    StrDanhMuc = DataSelect(DanhSachChuyenMuc, item.ID, 0, StrDanhMuc, ChiTiet.ParentID);
                }
            }
            ViewBag.optionSelected = StrDanhMuc;


            return View();
        }

        public string DataSelect(List<tbl_CategoryModel> DanhSachDonVi, int IdCha, int Stt, string StrDanhMuc, int IdDanhMuc = 0)
        {
            if (DanhSachDonVi.Count > 0)
            {
                Stt = Stt + 1;

                foreach (var item in DanhSachDonVi.Where(e => e.ParentID == IdCha))
                {
                    var kc = "";
                    for (int idx = 0; idx < Stt; idx++)
                    {
                        kc += "-- ";
                    }
                    var check = (item.ID == IdDanhMuc ? "selected" : "");
                    StrDanhMuc += "<option " + check + " value=" + item.ID + ">" + kc + item.Name + "</option>";
                    var checkCon = DanhSachDonVi.Where(e => e.ParentID == item.ID).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataSelect(DanhSachDonVi, item.ID, Stt, StrDanhMucChildren, IdDanhMuc);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }

        public async Task<JsonResult> ThemMoi(tbl_CategoryModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyDanhMucService.ThemMoi(requestModel);
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

        public async Task<JsonResult> CapNhat(tbl_CategoryModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyDanhMucService.CapNhat(requestModel);
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

        public async Task<JsonResult> Xoa(tbl_CategoryModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyDanhMucService.Xoa(requestModel);
                if (check.code == ResponseCode.SUCCESS)
                {
                    message.message = CommonConstants.MSG_DELETE_SUCCESS;
                    message.icon = CommonConstants.SUCCESS;
                }
                else
                {
                    message.message = CommonConstants.MSG_DELETE_FAILED;
                    message.icon = CommonConstants.ERROR;
                }
                return Json(message);
            }
            catch (Exception e)
            {
                JsonResponse message = new JsonResponse();
                message.message = CommonConstants.MSG_DELETE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }
    }
}