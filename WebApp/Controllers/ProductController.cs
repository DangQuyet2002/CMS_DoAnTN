using APIServices;
using APIServices.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    
    public class ProductController : Controller
    {
        private readonly IProductsAPIService _productsAPIService;
        public ProductController()
        {
            _productsAPIService = new ProductsAPIService();
        }
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult _HeaderSearchForm()
        {
            return PartialView();
        }

        public async Task<ActionResult> UpdateView(int Id)
        {
            try
            {
                var data = await _productsAPIService.UpdateView(Id);
                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    massage = "Thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    massage = "Thất bại"

                });
            }
        }
    }
}