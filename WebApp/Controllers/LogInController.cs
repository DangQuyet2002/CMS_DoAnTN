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

namespace WebApp.Controllers
{
    public class LogInController : Controller
    {
        private readonly IUserService _UserService;

        public LogInController(IUserService UserService)
        {
            _UserService = UserService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }

        // GET: LogIn
        [HttpPost]
        public async Task<JsonResult> DangNhapGoole(tbl_UserModel requestModel)
        {
            JsonResponse message = new JsonResponse();
            try
            {
                tbl_UserModel response = await _UserService.DangNhapGoole(requestModel);
                if (response.ID == 0)
                {
                    Response responseTM = await _UserService.DangKyTKGoole(requestModel);
                    requestModel.ID = int.Parse(responseTM.result.ToString());
                    response = requestModel;
                }
                Session[Constants.SSUserInforKH] = response;
                message.message = CommonConstants.MSG_LOGIN_SUCCESS;
                message.icon = CommonConstants.SUCCESS;
                message.data = response;
                message.type = CommonConstants.SUCCESS;
                return Json(message);
            }
            catch (Exception e)
            {
                message.message = CommonConstants.MSG_LOGIN_ERROR;
                message.icon = CommonConstants.SUCCESS;
                message.type = CommonConstants.SUCCESS;
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }


        // GET: LogIn
        


        // GET: LogIn
        [HttpPost]
        public async Task<JsonResult> DangNhapTK(tbl_UserModel requestModel)
        {
            JsonResponse message = new JsonResponse();
            try
            {
                string password = requestModel.Password;
                byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                requestModel.Password = BitConverter.ToString(hash)
                   .Replace("-", string.Empty)
                   .ToLower().ToString();
                tbl_UserModel response = await _UserService.DangNhapTK(requestModel);
                Session[Constants.SSUserInforKH] = await _UserService.DangNhapTK(requestModel);
                if (response.ID == 0)
                {
                    message.message = CommonConstants.MSG_LOGIN_FAILED;
                    message.icon = CommonConstants.ERROR;
                    return Json(message);
                }
                message.message = CommonConstants.MSG_LOGIN_SUCCESS;
                message.icon = CommonConstants.SUCCESS;
                message.data = response;
                message.type = CommonConstants.SUCCESS;
                Session[Constants.SSUserInforKH] = response;
                return Json(message);
            }
            catch (Exception e)
            {
                message.message = CommonConstants.MSG_LOGIN_ERROR;
                message.icon = CommonConstants.ERROR;
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }

        public ActionResult DangXuat()
        {
            try
            {
                Session[Constants.SSUserInforKH] = null;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
        
        
    }
}