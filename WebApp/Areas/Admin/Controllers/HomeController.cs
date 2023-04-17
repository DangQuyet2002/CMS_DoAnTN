using APIServices.CMS.HomeAdmin;
using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [AuthorizationAttribute]
    public class HomeController : Controller
    {

        private readonly IHomeAdminService _HomeAdminService;
        public HomeController(IHomeAdminService HomeAdminService)
        {
            _HomeAdminService = HomeAdminService;
        }

        // GET: Admin/Home
        public async Task<ActionResult> Index()
        {
            tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
            Session[Constants.SSMenuAdmin] = await _HomeAdminService.DanhSachMenu(TTNguoiDung.ID);
            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.lstMenuNguoiDung = (List<tbl_RoleModel>)Session[Constants.SSMenuAdmin];
            return View();
        }
    }
}