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
    public class ProductColorController : Controller
    {
        private readonly IProductColorAPIService productColorAPIService;
        public ProductColorController()
        {
            productColorAPIService = new ProductColorAPIService();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ThemMoi(ProductColor requestModel)
        {
            try
            {
                foreach (var item in requestModel.ListColorId.Split(','))
                {
                    requestModel.ColorId = Int32.Parse(item);
                    await productColorAPIService.Create(requestModel);
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
        public async Task<ActionResult> LoadProductColor(ProductColorRequest requestModel)
        {
            var result = await productColorAPIService.GetByPro(requestModel);
            var model = new List<Object>();
            if (result != null)
            {
                foreach (var item in result.lst)
                {
                    model.Add(new { id = item.Id, text = item.ColorName });
                }
            }
            return Json(new { result = "success", data = model }, JsonRequestBehavior.AllowGet);
        }
    }
}