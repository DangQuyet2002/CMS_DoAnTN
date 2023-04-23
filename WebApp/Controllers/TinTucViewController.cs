using APIServices.CMS.TinTuc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers

{
    public class TinTucViewController : Controller
    {
        private readonly TinTucAPIService _tinTucAPIService;
        public TinTucViewController(TinTucAPIService tinTucAPIService)
        {
            _tinTucAPIService = tinTucAPIService;
        }
        // GET: TinTucView
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoadTinTuc()
        {

            var data = await _tinTucAPIService.SelectAll();
            ViewBag.TinTucLoad = data.lst;
            return PartialView(data.lst);
        }
        public async Task<ActionResult> ChiTietTinTuc(int Id)
        {
            var data = await _tinTucAPIService.GetById(Id);
            return View(data);
        }
    }
}