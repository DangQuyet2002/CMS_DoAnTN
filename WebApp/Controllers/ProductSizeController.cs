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
    public class ProductSizeController : Controller
    {
        private readonly IProductSizeAPIService productSizeAPIService;
        public ProductSizeController()
        {
            productSizeAPIService = new ProductSizeAPIService();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ThemMoi(ProductSize requestModel)
        {
            try
            {
                foreach (var item in requestModel.ListSizeId.Split(','))
                {
                    requestModel.SizeId = Int32.Parse(item);
                    await productSizeAPIService.Create(requestModel);
                }
                return Json(new
                {
                    type = "success",
                    message = "Thêm mới thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = "error",
                    message = "Thêm mới thất bại"
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> LoadProductSize(ProductSizeRequest requestModel)
        {
            var result = await productSizeAPIService.GetByPro(requestModel);
            var model = new List<Object>();
            if (result != null)
            {
                foreach (var item in result.lst)
                {
                    model.Add(new { id = item.Id, text = item.SizeName });
                }
            }
            return Json(new { result = "success", data = model }, JsonRequestBehavior.AllowGet);
        }
    }
}