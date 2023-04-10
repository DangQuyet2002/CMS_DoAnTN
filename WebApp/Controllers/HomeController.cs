using APIServices;
using APIServices.CMS;
using APIServices.CMS.QuanLyMenu;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{


    public class HomeController : Controller
    {
        private readonly IQuanLyMenuService _QuanLyMenuService;
        

        public HomeController(IQuanLyMenuService QuanLyMenuService)
        {
            _QuanLyMenuService = QuanLyMenuService;
            
        }

        //[AuthorTrangNguoiDung]
        // GET: Home
        public async Task<ActionResult> Index(string BackUrl = "")
        {
            //Menu
            tbl_SettingMenu_CategoryModel requestModel = new tbl_SettingMenu_CategoryModel();
            //requestModel.IdSettingMenu = Constants.M_TopMenu;
            //List<tbl_SettingMenu_CategoryModel> DanhSachChuyenMuc = await _QuanLyMenuService.DanhSachTheoIdSetting(requestModel);
            //Session[Constants.SSMenu] = DanhSachChuyenMuc.OrderBy(e => e.STT).ToList();
            ViewBag.Title = "Trang chủ";
            
            return View();
        }

        

        
    }
}