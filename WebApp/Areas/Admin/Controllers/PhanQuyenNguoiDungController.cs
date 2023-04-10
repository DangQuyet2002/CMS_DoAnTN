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
    public class PhanQuyenNguoiDungController : Controller
    {
        private readonly IPhanQuyenService _PhanQuyenService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;
        private readonly IUserService _UserService;

        public PhanQuyenNguoiDungController(IPhanQuyenService PhanQuyenService, IQuanLyDanhMucService QuanLyDanhMucService, IUserService UserService)
        {
            _PhanQuyenService = PhanQuyenService;
            _QuanLyDanhMucService = QuanLyDanhMucService;
            _UserService = UserService;

        }

        // GET: Admin/PhanQuyenNguoiDung
        public async Task<ActionResult> Index()
        {
            tbl_UserModel model = new tbl_UserModel();
            model.length = 0;
            model.start = 0;
            BaseRespone<tbl_UserModel> response = await _UserService.DanhSach(model);
            ViewBag.lstNguoiDung = response.Data;
            return View();
        }

        public async Task<ActionResult> _DanhSachQuyenTheoNguoiDung(int IdUser)
        {
            tbl_RoleModel requestModel = new tbl_RoleModel();
            requestModel.IdUser = IdUser;
            ViewBag.lstRoleUser = await _PhanQuyenService.DanhSachRoleUser(requestModel);
            ViewBag.lstRole = await _PhanQuyenService.DanhSachRole(requestModel);
            return View();
        }

        public async Task<ActionResult> _DanhSachMenuTheoQuyen(int IdRole)
        {
            tbl_RoleModel requestModel = new tbl_RoleModel();
            requestModel.IdRole = IdRole;
            ViewBag.lstRoleMenu = await _PhanQuyenService.DanhSachRoleMenu(requestModel);
            ViewBag.lstMenu = await _PhanQuyenService.DanhSachMenu(requestModel);
            return View();
        }

        public async Task<ActionResult> _ThemMoi(int Id = 0)
        {
            tbl_RoleModel requestModel = new tbl_RoleModel();
            var lstRoleMenu = await _PhanQuyenService.DanhSachRole(requestModel);
            ViewBag.ChiTietRole = new tbl_RoleModel(); ;
            if (Id > 0)
            {
                ViewBag.ChiTietRole = lstRoleMenu.Where(e => e.Id == Id).FirstOrDefault();
            }

            return View();
        }

        public async Task<ActionResult> ThemMoi(tbl_RoleModel requestModel)
        {
            JsonResponse message = new JsonResponse();
            if (requestModel.Id > 0)
            {
                Response check = await _PhanQuyenService.CapNhatRole(requestModel);
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
            }
            else
            {

                Response check = await _PhanQuyenService.ThemMoiRole(requestModel);
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
            }
            return Json(message);
        }

        public async Task<JsonResult> Xoa(tbl_RoleModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _PhanQuyenService.XoaRole(requestModel);
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
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<JsonResult> ThemMoiUserRole(tbl_RoleModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _PhanQuyenService.ThemMoiUserRole(requestModel);
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
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<JsonResult> XoaUserRole(tbl_RoleModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _PhanQuyenService.XoaUserRole(requestModel);
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
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }


        public async Task<JsonResult> ThemMoiMenuRole(tbl_RoleModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _PhanQuyenService.ThemMoiMenuRole(requestModel);
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
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }

        public async Task<JsonResult> XoaMenuRole(tbl_RoleModel requestModel)
        {

            try
            {
                JsonResponse message = new JsonResponse();
                Response check = await _PhanQuyenService.XoaMenuRole(requestModel);
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
                message.message = CommonConstants.MSG_CREATE_FAILED;
                message.icon = CommonConstants.ERROR;

                return Json(message);
            }
        }
    }
}