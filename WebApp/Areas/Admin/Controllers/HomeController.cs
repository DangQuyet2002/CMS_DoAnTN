using APIServices;
using APIServices.CMS;
using APIServices.CMS.HomeAdmin;
using Models;
using Models.CMS.Product;
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
        private readonly IBillAPIService _billAPIService;
        private readonly IProductsAPIService _productsAPIService;
        private readonly IUserService _UserService;



        public HomeController(IHomeAdminService HomeAdminService)
        {
            _HomeAdminService = HomeAdminService;
            _billAPIService = new BillAPIService();
            _productsAPIService = new ProductsAPIService();
            _UserService = new UserService();


        }

        // GET: Admin/Home
        public async Task<ActionResult> Index(BillRequest requestModel,ProductRequest request , tbl_UserModel requestuser)
        {
            tbl_UserModel TTNguoiDung = (tbl_UserModel)Session[Constants.SSUserLogIn];
            Session[Constants.SSMenuAdmin] = await _HomeAdminService.DanhSachMenu(TTNguoiDung.ID);

            var data = await _billAPIService.GetAll(requestModel);
            ViewBag.Data = data;

            
            var sanpham = await _productsAPIService.GetAll(request);
            ViewBag.Datasp = sanpham;

            ViewBag.TongNguoiDung = (await _HomeAdminService.TongNguoiDung()).result;
            ViewBag.TongLuotXem = (await _HomeAdminService.TongLuotXem()).result;
            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.lstMenuNguoiDung = (List<tbl_RoleModel>)Session[Constants.SSMenuAdmin];
            return View();
        }
    }
}