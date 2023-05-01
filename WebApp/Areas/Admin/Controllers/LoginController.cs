using APIServices.CMS;
using APIServices.CMS.HomeAdmin;
using Models;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
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
        public ActionResult DanhSachUser()
        {
            return View();
        }
        public ActionResult DanhSachAdmin()
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
                Session[Constants.SSUserInforKH] = null;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }

        [HttpPost]
        public async Task<JsonResult>DanhSach(tbl_UserModel requestModel)
        {
            try
            {
                BaseRespone<tbl_UserModel> response = await _UserService.DanhSach(requestModel);
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

        [HttpPost]
        public async Task<JsonResult> DanhSachAdmin(tbl_UserModel requestModel)
        {
            try
            {
                BaseRespone<tbl_UserModel> response = await _UserService.DanhSachAdmin(requestModel);
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

        //[HttpPost]
        //public async Task<ActionResult> Update(tbl_UserModel requestModel, HttpPostedFileBase FileUpload)
        //{
        //    try
        //    {
        //        var Iduser = await _UserService.GetById(requestModel.ID);
        //        if (FileUpload == null)
        //        {
        //            requestModel.Image = Iduser.Image;
        //        }
        //        else if (FileUpload.ContentLength > 0 && FileUpload != null)
        //        {
        //            requestModel.Image = FileUpload.FileName;
        //            string ten = Path.GetFileNameWithoutExtension(FileUpload.FileName);
        //            string morong = Path.GetExtension(FileUpload.FileName);
        //            string tendaydu = ten + morong;
        //            FileUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), tendaydu));

        //        }
        //        await _UserService.(requestModel);
        //        return Json(new
        //        {
        //            type = CommonConstants.SUCCESS,
        //            massage = "Cập nhật thành công"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            type = CommonConstants.ERROR,
        //            massage = "Thất bại!"
        //        });
        //    }
        //}

    }
}