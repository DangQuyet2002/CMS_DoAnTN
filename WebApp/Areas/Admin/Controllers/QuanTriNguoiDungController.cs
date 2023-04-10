using APIServices.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    [AuthorizationAttribute]
    public class QuanTriNguoiDungController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IQuanLyDanhMucService _QuanLyDanhMucService;

        public QuanTriNguoiDungController(IUserService UserService, IQuanLyDanhMucService QuanLyDanhMucService)
        {
            _UserService = UserService;
            _QuanLyDanhMucService = QuanLyDanhMucService;

        }

        // GET: Admin/QuanTriNguoiDung
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_UserModel model)
        {
            try
            {
                BaseRespone<tbl_UserModel> response = await _UserService.DanhSach(model);
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
        public ActionResult _ThemMoi()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> ThemMoi(tbl_UserModel requestModel)
        {

            try
            {
                string password = requestModel.Password;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                requestModel.Password = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower().ToString();


                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();

                List<tbl_UserModel> checkUser = await _UserService.CheckUser(requestModel);
                if (checkUser.Count > 0)
                {
                    message.message = CommonConstants.MSG_LOGIN_ACC_EXITS;
                    message.icon = CommonConstants.ERROR;
                    return Json(message);
                }


                List<tbl_UserModel> checkMail = await _UserService.CheckMail(requestModel);
                if (checkMail.Count > 0)
                {
                    message.message = CommonConstants.MSG_LOGIN_EXITS;
                    message.icon = CommonConstants.ERROR;
                    return Json(message);
                }


                Response check = await _UserService.ThemMoi(requestModel);
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
        public async Task<ActionResult> _Sua(int Id)
        {
            tbl_UserModel requestModelCT = new tbl_UserModel();
            requestModelCT.ID = Id;
            tbl_UserModel ChiTiet = await _UserService.ChiTiet(requestModelCT);
            ViewBag.ChiTiet = ChiTiet;
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> Sua(tbl_UserModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();

                List<tbl_UserModel> checkMail = await _UserService.CheckMail(requestModel);
                if (checkMail.Where(e => e.ID != requestModel.ID).ToList().Count > 0)
                {
                    message.message = CommonConstants.MSG_LOGIN_EXITS;
                    message.icon = CommonConstants.ERROR;
                    return Json(message);
                }


                Response check = await _UserService.CapNhat(requestModel);
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

        [HttpPost, ValidateInput(false)]
        public async Task<JsonResult> Xoa(tbl_UserModel requestModel)
        {

            try
            {
                tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
                requestModel.CreatedAt = DateTime.Now;
                requestModel.UpdatedAt = DateTime.Now;
                requestModel.CreatedBy = TTNguoiDung.ID;
                requestModel.UpdatedBy = TTNguoiDung.ID;

                JsonResponse message = new JsonResponse();
                Response check = await _UserService.Xoa(requestModel);
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
    }
}