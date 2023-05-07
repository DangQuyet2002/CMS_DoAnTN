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
        private readonly IGioHangAPIService gioHangAPIService;

        //private readonly IGioHangAPIService gioHangAPIService;
        public HomeController()
        {
            _tinTucAPIService = new TinTucAPIService();
            gioHangAPIService = new GioHangAPIService();
            productsAPIService = new ProductsAPIService();
        }

        //[AuthorTrangNguoiDung]
        // GET: Home
        public async Task<ActionResult> Index(ProductRequest request)
        {

            if (Session[CommonConstants.SessionAccountInfo] != null)
            {
                GioHangRequest requestModel = new GioHangRequest();
                var data = await gioHangAPIService.GetByUser(requestModel);
                Session["totalCart"] = data.totalCount;
            }

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

        public async Task<ActionResult> _DanhSachTimKiem(string txtTuKhoa, ProductRequest request)
        {
            try
            {
                Product requestModel = new Product();
                requestModel.start = 0;
                requestModel.length = 6;
                requestModel.NamePro = txtTuKhoa;
                var sanpham = await productsAPIService.GetAll(request);
                ViewBag.sanpham = sanpham.lst;
                return View();
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }

    }
}