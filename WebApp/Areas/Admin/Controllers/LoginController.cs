using APIServices.CMS;
using APIServices.CMS.HomeAdmin;
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
    public class LoginController : Controller
    {
        private readonly IUserService _UserService;
        private readonly IHomeAdminService _HomeAdminService;

        public LoginController(IUserService UserService, IHomeAdminService HomeAdminService)
        {
            _UserService = UserService;
            _HomeAdminService = HomeAdminService;
        }


        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<JsonResult> DangNhap(tbl_UserModel requestModel)
        {
            try
            {
                string password = requestModel.Password;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                requestModel.Password = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower().ToString();


                tbl_UserModel response = await _UserService.DangNhap(requestModel);
                if (response != null)
                {
                    response.lstQuyen = await _HomeAdminService.DanhSachMenu(response.ID);
                    Session[Constants.SSUserLogIn] = response;
                }
                return Json(new
                {
                    data = response,
                    type = CommonConstants.SUCCESS
                });
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
        public ActionResult DangXuat()
        {
            try
            {
                Session[Constants.SSUserLogIn] = null;
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
    }
}