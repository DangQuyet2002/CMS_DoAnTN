using APIServices;
using Models;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Controllers
{
    public class ChiTietSanPhamController : Controller
    {
        // GET: ChiTietSanPham
        private readonly IProductsAPIService _productsAPIService;
        private readonly IProductSizeAPIService _productSizeAPIService;
        private readonly IProductColorAPIService _productColorAPIService;
        //private readonly IPhanHoiAPIService _phanHoiAPIService;
        public ChiTietSanPhamController()
        {
            _productsAPIService = new ProductsAPIService();
            _productSizeAPIService = new ProductSizeAPIService();
            _productColorAPIService = new ProductColorAPIService();
            //_phanHoiAPIService = new PhanHoiAPIService();
        }
        // GET: ChiTietSanPham
        public async Task<ActionResult> Index(int Id)
        {
            ProductSizeRequest request = new ProductSizeRequest();
            request.Id = Id;
            var listSize = await _productSizeAPIService.GetByPro(request);
            ProductColorRequest requestColor = new ProductColorRequest();
            requestColor.Id = Id;
            
            var listColor = await _productColorAPIService.GetByPro(requestColor);
            var data = await _productsAPIService.GetById(Id);
            //var result = await _phanHoiAPIService.DanhSachById(Id);
            //ViewBag.ListComment = result.lst;
            ViewBag.ListSize = listSize.lst;
            ViewBag.ListColor = listColor.lst;
            return View(data);
        }
        //[HttpPost]
        //public async Task<ActionResult> ThemMoiPhanHoi(tbl_PhanHoiModel requestModel)
        //{
        //    try
        //    {
        //        await _phanHoiAPIService.ThemMoi(requestModel);
        //        return Json(new
        //        {
        //            type = "success",
        //            message = "Thêm mới thành công"
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new
        //        {
        //            type = "error",
        //            message = ex.Message
        //        });
        //    }
        //}

    }
}