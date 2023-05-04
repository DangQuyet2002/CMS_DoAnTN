using APIServices.CMS;
using Azure.Core;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ChiTietNguoiDungController : Controller
    {
        private readonly IUserService actionAPIService;
        public ChiTietNguoiDungController()
        {
            actionAPIService = new UserService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> ChiTiet(tbl_UserModel requestModel)
        {
            var data = await actionAPIService.ChiTiet(requestModel);
           
            return PartialView(data);
        }

    }
}