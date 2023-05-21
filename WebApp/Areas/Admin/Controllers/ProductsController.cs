using APIServices;
using APIServices.CMS;
using Models;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductsAPIService _productsAPIService;
        private readonly ICategoryAPIService _categoryAPIService;
        private readonly IDanhMucCategoryAPIService _danhMucCategoryAPIService;


        public ProductsController()
        {
            _userService = new UserService();
            _productsAPIService = new ProductsAPIService();
            _categoryAPIService = new CategoryAPIService();
            _danhMucCategoryAPIService = new DanhMucCategoryAPIService();
        }
        // GET: Admin/AdminProducts
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSSanPham()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> _DSSanPham(ProductRequest requestModel)
        {
            try
            {
                var data = await _productsAPIService.GetAll(requestModel);
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
                    type = CommonConstants.ERROR,

                });
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Product requestModel, HttpPostedFileBase FileUpload, HttpPostedFileBase FileUpload1)
        {
            try
            {
                if (FileUpload != null && FileUpload.ContentLength > 0)
                {
                    requestModel.Image = FileUpload.FileName;
                    string ten = Path.GetFileNameWithoutExtension(FileUpload.FileName);
                    string morong = Path.GetExtension(FileUpload.FileName);
                    string tendaydu = ten + morong;
                    FileUpload.SaveAs(Path.Combine(Server.MapPath("~/FileUploaded/"), tendaydu));
                }

                if (FileUpload1 != null && FileUpload1.ContentLength > 0)
                {
                    requestModel.Image1 = FileUpload1.FileName;
                    string name = Path.GetFileNameWithoutExtension(FileUpload1.FileName);
                    string duoi = Path.GetExtension(FileUpload1.FileName);
                    string full = name + duoi;
                    FileUpload1.SaveAs(Path.Combine(Server.MapPath("~/FileUploaded/"), full));
                }

                if (requestModel.Id > 0)
                {
                    var IdPro = await _productsAPIService.GetById(requestModel.Id);

                    if (requestModel.CategoryId == 0)
                    {
                        requestModel.CategoryId = IdPro.CategoryId;
                    }

                    if (requestModel.CategoryminId == 0)
                    {
                        requestModel.CategoryminId = IdPro.CategoryminId;
                    }

                    if (FileUpload == null)
                    {
                        requestModel.Image = IdPro.Image;
                    }

                    if (FileUpload1 == null)
                    {
                        requestModel.Image1 = IdPro.Image1;
                    }

                    await _productsAPIService.Update(requestModel);
                }
                else
                {
                    await _productsAPIService.Create(requestModel);
                }

                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    message = "Lưu thành công",
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    message = "Có lỗi xảy ra!",
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(ProductRequest requestModel)
        {
            try
            {
                var data = await _productsAPIService.Delete(requestModel);
                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    massage = "Xóa thành công"
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
        [HttpPost]
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

        public async Task<ActionResult> ThemMoi(DanhMucCategoryRequest requestModel)
        {
            var result = await _categoryAPIService.LoadDS();
            ViewBag.DanhSachCategory = result;

            var resultDM = await _danhMucCategoryAPIService.GetAll(requestModel);
            ViewBag.DanhSachDMCategory = resultDM;
            return PartialView();
        }
        [HttpGet]
        public async Task<ActionResult> ChiTiet(DanhMucCategoryRequest requestModel , int Id = 0)
        {
            var data = new Product();
            if (Id > 0)
            {
                data = await _productsAPIService.GetById(Id);

            }

            ViewBag.DanhSach = data;
            var result = await _categoryAPIService.LoadDS();
            ViewBag.DanhSachCategory = result;

            var resultDM = await _danhMucCategoryAPIService.GetAll(requestModel);
            ViewBag.DanhSachDMCategory = resultDM;
            return PartialView(data);
        }
        [HttpGet]
        public async Task<ActionResult> ThuocTinh(int Id = 0)
        {
            var data = new Product();
            if (Id > 0)
            {
                data = await _productsAPIService.GetById(Id);

            }
            return PartialView(data);
        }

    }
}