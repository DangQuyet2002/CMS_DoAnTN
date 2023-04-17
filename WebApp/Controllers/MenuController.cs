using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _MobileMenu()
        {
            //Mainmenu Location = 8
            //var menus = db.Menus.Where(m => m.LocationId == 8).ToList();
            return PartialView(/*menus*/);
        }
    }
}