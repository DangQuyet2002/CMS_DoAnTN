using APIServices.CMS;
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
        public async Task<ActionResult> ChiTiet(int Id)
        {
            var data = await actionAPIService.GetById(Id);
           
            return View(data);
        }

    }
}