using APIServices.CMS.EmailLienHe;
using Models.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    public class QuanLyEmailLienHeController : Controller
    {
        private readonly IEmailLienHeService _QuanLyEmailService;

        public QuanLyEmailLienHeController(IEmailLienHeService QuanLyEmailService)
        {
            _QuanLyEmailService = QuanLyEmailService;

        }
        // GET: Admin/QuanLyThongBao
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> DanhSach(tbl_EmailLienHe model)
        {
            try
            {
                BaseRespone<tbl_EmailLienHe> response = await _QuanLyEmailService.DanhSach(model);
                return Json(new
                {
                    data = response,
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


        private void SendActivationEmail(tbl_UserModel user)
        {
            string email = "namviet.e02@gmail.com";
            string password = "dodicftbktwfdngh";

            var loginInfo = new NetworkCredential(email, password);
            var msg = new MailMessage();
            var smtpClient = new SmtpClient("smtp.gmail.com", 587);

            msg.From = new MailAddress(email);
            msg.To.Add(new MailAddress(user.Email));
            msg.Subject = "Mật khẩu đăng nhập lần đầu";
            string body = "Xin chào " + user.UserName + ",";
            body += "<br /><br />Vui lòng kích vào link dưới đây đăng nhập tài khoản";
            body += "<br /><br />Mật khẩu đăng nhập lần đầu là: 123@123Aa";
            body += "<br /><br />Cảm ơn bạn!";
            msg.Body = body;
            msg.IsBodyHtml = true;

            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = loginInfo;
            smtpClient.Send(msg);

        }
    }

}