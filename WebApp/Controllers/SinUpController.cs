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
    public class SinUpController : Controller
    {
        private readonly IUserService _UserService;

        public SinUpController(IUserService UserService)
        {
            _UserService = UserService;
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<JsonResult> DangKyTK(tbl_UserModel requestModel)
        {
            JsonResponse message = new JsonResponse();
            try
            {
                tbl_UserModel response = await _UserService.DangNhapGoole(requestModel);
                if (response.ID == 0)
                {
                    string password = requestModel.Password;
                    byte[] encodedPassword = new UTF8Encoding().GetBytes(password);
                    byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);
                    requestModel.Password = BitConverter.ToString(hash)
                       .Replace("-", string.Empty)
                       .ToLower().ToString();

                    Response responseTM = await _UserService.ThemMoi(requestModel);
                    requestModel.ID = int.Parse(responseTM.result.ToString());
                    response = requestModel;
                }
                else
                {
                    message.message = CommonConstants.MSG_LOGIN_EXITS;
                    message.icon = CommonConstants.ERROR;
                    return Json(message);
                }
                Session[Constants.SSUserInforKH] = response;
                message.message = CommonConstants.MSG_LOGIN_CREATE;
                message.icon = CommonConstants.SUCCESS;
                message.data = response;
                message.type = CommonConstants.SUCCESS;
                return Json(message);
            }
            catch (Exception e)
            {
                message.message = CommonConstants.MSG_LOGIN_ERROR;
                message.icon = CommonConstants.ERROR;
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }
    }
}