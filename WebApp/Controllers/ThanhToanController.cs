using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly IGioHangAPIService gioHangAPIService;
        public ThanhToanController()
        {
            gioHangAPIService = new GioHangAPIService();
        }
        // GET: ThanhToan
        public async Task<ActionResult> Index(GioHangRequest request)
        {
            var listGioHang = await gioHangAPIService.GetByUser(request);
            ViewBag.listGioHang = listGioHang.lst;
            return View();
        }

    }
}