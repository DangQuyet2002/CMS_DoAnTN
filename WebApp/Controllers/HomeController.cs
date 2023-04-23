using APIServices;
using APIServices.CMS;
using APIServices.CMS.TinTuc;
using Models;
using Models.CMS.Product;
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
        private readonly ITinTucAPIService _tinTucAPIService;
        private readonly IProductsAPIService productsAPIService;
        //private readonly IGioHangAPIService gioHangAPIService;
        public HomeController()
        {
            _tinTucAPIService = new TinTucAPIService();
            //gioHangAPIService = new GioHangAPIService();
            productsAPIService = new ProductsAPIService();
        }

        //[AuthorTrangNguoiDung]
        // GET: Home
        public async Task<ActionResult> Index(ProductRequest request)
        {
           
            ViewBag.Title = "Trang chủ";
            request.Length = 4;
            request.Start = 1;
            var sanpham = await productsAPIService.GetAll(request);
            ViewBag.SanPhamNew = sanpham.lst;

            var dataTT = await _tinTucAPIService.SelectAll();
            ViewBag.TinTucLoad = dataTT.lst;
            return View();
        }

        

        public async Task<ActionResult> DSSanPham(ProductRequest request)
        {
            request.Length = 20;
            request.Start = request.Start - 1;
            var sanpham = await productsAPIService.GetAll(request);
            ViewBag.SanPham = sanpham.lst;
            ViewBag.HtmlPaging = Utils.HtmlPaging(request.Start + 20, request.Length, sanpham.totalCount);
            return View();
        }

        public async Task<ActionResult> DoNam()
        {
            return View();
        }

    }
}