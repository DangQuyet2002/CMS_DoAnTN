using APIServices;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    public class LoaiSanPhamController : Controller
    {
        private readonly ICategoryAPIService _categoryAPIService;
        public LoaiSanPhamController()
        {
            _categoryAPIService = new CategoryAPIService();
        }
        // GET: Admin/LoaiSanPham
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoadCategory()
        {
            var result = await _categoryAPIService.LoadDS();
            var model = new List<Object>();
            if (result != null)
            {
                foreach (var item in result.lst)
                {
                    model.Add(new { id = item.Id, text = item.Name });
                }
            }
            return Json(new { result = "success", data = model }, JsonRequestBehavior.AllowGet);
            
        }
        [HttpPost]
        public async Task<ActionResult> DSLoaiSP(CategoryRequest requestModel)
        {
            try
            {
                var data = await _categoryAPIService.GetAll(requestModel);
                var count = data.totalCount;
                return Json(new
                {
                    data = data.lst,
                    recordsTotal = count,
                    recordsFiltered = count,
                    type = CommonConstants.SUCCESS,
                    draw = 0,
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Category requestModel)
        {
            try
            {
                if (requestModel.Id > 0)
                {
                    await _categoryAPIService.Update(requestModel);
                }
                else
                {

                    await _categoryAPIService.Create(requestModel);
                }

                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    masage = "Thêm mới thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    masage = "Thất bại"

                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Upadate(Category requestModel)
        {
            try
            {
                var data = await _categoryAPIService.Update(requestModel);

                return Json(new
                {

                    type = CommonConstants.SUCCESS,
                    masage = "Cập nhật thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    masage = "Thất bại"
                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Delete(CategoryRequest requestModel)
        {
            try
            {
                var data = await _categoryAPIService.Delete(requestModel);

                return Json(new
                {

                    type = CommonConstants.SUCCESS,
                    masage = "Xóa thành công"
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    masage = "Thất bại"
                });
            }
        }
        public ActionResult ThemMoi()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<ActionResult> ChiTiet(int Id = 0)
        {
            var data = new Category();
            if (Id > 0)
            {
                data = await _categoryAPIService.GetById(Id);

            }
            return PartialView(data);
        }
    }
}