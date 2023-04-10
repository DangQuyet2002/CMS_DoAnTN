using APIServices.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    public class LogHTController : Controller
    {
        

        public LogHTController()
        {
            

        }
        // GET: Admin/LogHT
        public ActionResult Index()
        {
            return View();
        }

       
    }
}