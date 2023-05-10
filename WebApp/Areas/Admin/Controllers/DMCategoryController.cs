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
    public class DMCategoryController : Controller
    {
        private readonly IDanhMucCategoryAPIService _danhMucCategoryAPIService;

        public DMCategoryController()
        {
            _danhMucCategoryAPIService = new DanhMucCategoryAPIService();
        }
        // GET: Admin/DMCategory
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> LoadDMCategory(DanhMucCategoryRequest requestModel)
        {
            var result = await _danhMucCategoryAPIService.GetAll(requestModel);
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
        public async Task<ActionResult> _DMCategory(DanhMucCategoryRequest requestModel)
        {
            try
            {

                var data = await _danhMucCategoryAPIService.GetAll(requestModel);
                var count = data.totalCount;
                return Json(new
                {
                    data = data.lst,
                    recordsTotal = count,
                    draw = requestModel.Draw == 0 ? 1 : requestModel.Draw,
                    recordsFiltered = count,
                    type = CommonConstants.SUCCESS,
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
        public async Task<ActionResult> Create(DanhMucCategory requestModel)
        {
            try
            {
                if (requestModel.Id > 0)
                {
                    var data = await _danhMucCategoryAPIService.Update(requestModel);
                }
                else
                {
                    var data = await _danhMucCategoryAPIService.Create(requestModel);
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
        public async Task<ActionResult> Upadate(DanhMucCategory requestModel)
        {
            try
            {
                var data = await _danhMucCategoryAPIService.Update(requestModel);

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
        public async Task<ActionResult> Delete(DanhMucCategoryRequest requestModel)
        {
            try
            {
                var data = await _danhMucCategoryAPIService.Delete(requestModel);

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
            var data = new DanhMucCategory();
            if (Id > 0)
            {
                data = await _danhMucCategoryAPIService.GetById(Id);

            }
            return PartialView(data);
        }
    }
}