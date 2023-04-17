using APIServices;
using APIServices.CMS;

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
        

        public HomeController()
        {
            
            
        }

        //[AuthorTrangNguoiDung]
        // GET: Home
        public async Task<ActionResult> Index(string BackUrl = "")
        {
           
            ViewBag.Title = "Trang chủ";
            
            return View();
        }

        

        
    }
}