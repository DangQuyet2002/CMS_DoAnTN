using APIServices;
using Azure.Core;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class DanhSachSPController : Controller
    {
        // GET: DanhSachSP
        private readonly IProductsAPIService _productsAPIService;
        public DanhSachSPController()
        {
            _productsAPIService = new ProductsAPIService();
        }
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> DoNu()
        {

            return View();
        }
        public async Task<ActionResult> _DSDoNu(ProductRequest requestModel)
        {
            requestModel.CategoryMinId = "7";
            requestModel.Start = requestModel.Start - 1;
            requestModel.Length = 20;
            var model = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 20, requestModel.Length, model.totalCount);
            ViewBag.Aothun = model.lst;

            requestModel.CategoryMinId = "8";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var somi = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.AoSoMiNu = somi.lst;

            requestModel.CategoryMinId = "9";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var chanvay = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.chanvay = chanvay.lst;

            requestModel.CategoryMinId = "19";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var Sweater = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.AoSweater = Sweater.lst;

            requestModel.CategoryMinId = "10";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var sort = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.Quansort = sort.lst;

            requestModel.CategoryMinId = "11";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var quandai = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.Quandai = quandai.lst;
            return View();
        }
        public async Task<ActionResult> DoNam(ProductRequest request)
        {
            return View();
        }
        public async Task<ActionResult> _DSDoNam(ProductRequest requestModel)
        {
            //All sp
            requestModel.CategoryMinId = "1";
            requestModel.Start = requestModel.Start - 1;
            requestModel.Length = 20;
            var model = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 20, requestModel.Length, model.totalCount);
            ViewBag.Aothun = model.lst;

            requestModel.CategoryMinId = "2";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var somi = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.AoSoMiNam = somi.lst;

            requestModel.CategoryMinId = "3";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var Sweater = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.AoSweater = Sweater.lst;

            requestModel.CategoryMinId = "4";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var jean = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.Quanjean = jean.lst;

            requestModel.CategoryMinId = "5";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var quanau = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.Quanau = quanau.lst;

            requestModel.CategoryMinId = "6";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var sort = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, model.totalCount);
            ViewBag.Quansort = sort.lst;
            return View();
        }
        public async Task<ActionResult> AoKhoac()
        {
            return View();
        }
        public async Task<ActionResult> _DSAoKhoac(ProductRequest requestModel)
        {
            requestModel.CategoryMinId = "16";
            requestModel.Start = requestModel.Start - 1;
            requestModel.Length = 20;
            var aokhoacnam = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 20, requestModel.Length, aokhoacnam.totalCount);
            ViewBag.AokhoacNam = aokhoacnam.lst;

            requestModel.CategoryMinId = "17";
            requestModel.Start = requestModel.Start - 1;
            requestModel.Length = 20;
            var aokhoacnu = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 20, requestModel.Length, aokhoacnu.totalCount);
            ViewBag.AokhoacNu = aokhoacnu.lst;

            requestModel.CategoryMinId = "18";
            requestModel.Start = requestModel.Start - 1;
            requestModel.Length = 20;
            var aokhoacdoi = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 20, requestModel.Length, aokhoacdoi.totalCount);
            ViewBag.AokhoacDoi = aokhoacdoi.lst;
            return View();
        }

        public async Task<ActionResult> PhuKien()
        {
            return View();
        }
        public async Task<ActionResult> _DSPhuKien(ProductRequest requestModel)
        {
            requestModel.CategoryMinId = "12";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var non = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, non.totalCount);
            ViewBag.non = non.lst;

            requestModel.CategoryMinId = "13";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var balo = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, balo.totalCount);
            ViewBag.balo = balo.lst;

            requestModel.CategoryMinId = "14";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var thatlung = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, thatlung.totalCount);
            ViewBag.thatlung = thatlung.lst;

            requestModel.CategoryMinId = "15";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var tuisach = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, tuisach.totalCount);
            ViewBag.TuiSach = tuisach.lst;

            requestModel.CategoryMinId = "20";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var Vongtay = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, Vongtay.totalCount);
            ViewBag.VongTay = Vongtay.lst;

            requestModel.CategoryMinId = "21";
            requestModel.Start = 0;
            requestModel.Length = 20;
            var dongho = await _productsAPIService.GetByCate(requestModel);
            ViewBag.HtmlPaging = Utils.HtmlPaging(requestModel.Start + 1, requestModel.Length, dongho.totalCount);
            ViewBag.Dongho = dongho.lst;
            return View();
        }


    }
}
    
