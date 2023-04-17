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
        public ProductsController()
        {
            _userService = new UserService();
            _productsAPIService = new ProductsAPIService();
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
        public async Task<ActionResult> Create(Product requestModel, HttpPostedFileBase FileUpload)
        {
            try
            {
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
                    else if (FileUpload.ContentLength > 0 && FileUpload != null)
                    {
                        requestModel.Image = FileUpload.FileName;
                        string ten = Path.GetFileNameWithoutExtension(FileUpload.FileName);
                        string morong = Path.GetExtension(FileUpload.FileName);
                        string tendaydu = ten + morong;
                        FileUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), tendaydu));
                    }
                    await _productsAPIService.Update(requestModel);
                }
                else if (FileUpload.ContentLength > 0 && FileUpload != null)
                {
                    requestModel.Image = FileUpload.FileName;
                    string ten = Path.GetFileNameWithoutExtension(FileUpload.FileName);
                    string morong = Path.GetExtension(FileUpload.FileName);
                    string tendaydu = ten + morong;
                    FileUpload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), tendaydu));

                    await _productsAPIService.Create(requestModel);
                }
                return Json(new
                {
                    type = CommonConstants.SUCCESS,
                    massage = "Lưu thành công",
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    type = CommonConstants.ERROR,
                    massage = "Có lỗi xảy ra!",
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

        public ActionResult ThemMoi()
        {
            return PartialView();
        }
        [HttpGet]
        public async Task<ActionResult> ChiTiet(int Id = 0)
        {
            var data = new Product();
            if (Id > 0)
            {
                data = await _productsAPIService.GetById(Id);

            }
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