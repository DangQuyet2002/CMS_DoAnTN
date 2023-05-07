using APIServices.CMS.TinTuc;
using APIServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.CMS.Product;
using Models;
using System.Threading.Tasks;
using Utilities;

namespace WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly ITinTucAPIService _tinTucAPIService;
        private readonly IProductsAPIService productsAPIService;
        private readonly IGioHangAPIService gioHangAPIService;

        //private readonly IGioHangAPIService gioHangAPIService;
        public SearchController()
        {
            _tinTucAPIService = new TinTucAPIService();
            gioHangAPIService = new GioHangAPIService();
            productsAPIService = new ProductsAPIService();
        }
        // GET: Search
        public async Task<ActionResult> Index(string txtTuKhoa, ProductRequest request)
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