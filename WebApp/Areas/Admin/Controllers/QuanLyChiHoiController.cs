using APIServices;
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
    public class QuanLyChiHoiController : Controller
    {
        private readonly IQuanLyChiHoiService _QuanLyChiHoiService;
        public QuanLyChiHoiController(IQuanLyChiHoiService QuanLyChiHoiService)
        {
            _QuanLyChiHoiService = QuanLyChiHoiService;
        }

        // GET: Admin/QuanLyChiHoi
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Tree(tbl_ChiHoiTTModel requestModel)
        {
            try
            {
                List<tbl_ChiHoiTTModel> DanhSachChiHoi = await _QuanLyChiHoiService.DanhSach(requestModel);
                string StrDanhMuc = "";
                StrDanhMuc = DataStrDanhMuc(DanhSachChiHoi, 0, 0, StrDanhMuc);

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

        public string DataStrDanhMuc(List<tbl_ChiHoiTTModel> DanhSachDonVi, int IdCha, int Stt, string StrDanhMuc)
        {
            if (DanhSachDonVi.Count > 0)
            {
                foreach (var item in DanhSachDonVi.Where(e => e.ParentId == IdCha))
                {
                    Stt = Stt + 1;
                    if (IdCha == 0)
                    {
                        StrDanhMuc += "<tr class=\"treegrid-" + item.Id + "\"><td>" + item.Ten + "</td><td class=\" text-center\" style=\"word-break: break-all; width: 60%!important;\">" + item.Url + "</td><td class=\" text-center\">"
                            + "<div class=\"dropdown\">"
                                + "<a href=\"#\" role=\"button\" id=\"dropdownMenuLink5\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\" class=\"\">"
                                + "<i class=\"ri-more-2-fill\"></i></a>"
                                + "<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink5\" style=\"\">"
                                      + "<li><a class=\"dropdown-item\" href=\"#\" onclick=\"ThemMoi(" + 0 + "," + item.Id + ")\"><i class=\"ri-add-line\"></i>Thêm mới</a></li>"
                                      + "<li><a class=\"dropdown-item\" href=\"#\" onclick=\"ThemMoi(" + item.Id + "," + item.ParentId + ")\"><i class=\"ri-edit-2-line\"></i>Sửa</a></li>"
                                       + "<li><a class=\"dropdown-item link-danger\" href=\"#\" onclick=\"Xoa(" + item.Id + ")\"><i class=\"ri-delete-bin-line\"></i>Xóa</a></li>"
                                + "</ul></div>"
                            + "</td></tr>";
                    }
                    else
                    {
                        StrDanhMuc += "<tr class=\"treegrid-" + item.Id + " treegrid-parent-" + IdCha + "\"><td>" + item.Ten + "</td><td class=\" text-center\" style=\"word-break: break-all; width: 60%!important;\">" + item.Url + "</td><td class=\" text-center\">"
                           + "<div class=\"dropdown\">"
                               + "<a href=\"#\" role=\"button\" id=\"dropdownMenuLink5\" data-bs-toggle=\"dropdown\" aria-expanded=\"false\" class=\"\">"
                               + "<i class=\"ri-more-2-fill\"></i></a>"
                               + "<ul class=\"dropdown-menu\" aria-labelledby=\"dropdownMenuLink5\" style=\"\">"
                                      + "<li><a class=\"dropdown-item\" href=\"#\" onclick=\"ThemMoi(" + item.Id + "," + item.ParentId + ")\"><i class=\"ri-edit-2-line\"></i>Sửa</a></li>"
                                       + "<li><a class=\"dropdown-item link-danger\" href=\"#\" onclick=\"Xoa(" + item.Id + ")\"><i class=\"ri-delete-bin-line\"></i>Xóa</a></li>"
                               + "</ul></div>"
                           + "</td></tr>";
                    }
                    var checkCon = DanhSachDonVi.Where(e => e.ParentId == item.Id).ToList();
                    if (checkCon.Count > 0)
                    {
                        string StrDanhMucChildren = "";
                        StrDanhMucChildren += DataStrDanhMuc(DanhSachDonVi, item.Id, Stt, StrDanhMucChildren);
                        StrDanhMuc += StrDanhMucChildren;
                    }
                }
            }
            return StrDanhMuc;
        }

        public async Task<ActionResult> _ThemMoi(int Id = 0, int ParentId = 0)
        {
            var chiTiet = new tbl_ChiHoiTTModel();
            chiTiet.ParentId = ParentId;
            ViewBag.ChiTiet = chiTiet;
            if (Id > 0)
            {
                tbl_ChiHoiTTModel requestModel = new tbl_ChiHoiTTModel();
                requestModel.Id = Id;
                tbl_ChiHoiTTModel ChiTietChiHoi = await _QuanLyChiHoiService.ChiTiet(requestModel);
                ViewBag.ChiTiet = ChiTietChiHoi;
            }
            return View();
        }

        public async Task<ActionResult> Luu(tbl_ChiHoiTTModel requestModel)
        {

            if (requestModel.Id > 0)
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyChiHoiService.CapNhat(requestModel);
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
            else
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyChiHoiService.ThemMoi(requestModel);
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
        }


        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> Xoa(tbl_ChiHoiTTModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _QuanLyChiHoiService.Xoa(requestModel);
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