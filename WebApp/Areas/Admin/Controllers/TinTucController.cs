using APIServices;
using APIServices.CMS.TinTuc;
using Models;
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
    public class TinTucController : Controller
    {
        private readonly ITinTucAPIService _tinTucAPIService;
        public TinTucController()
        {
            _tinTucAPIService = new TinTucAPIService();
        }
        // GET: Admin/TinTuc
        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> GetAll(TinTucRequest requestModel)
        {
            try
            {
                var data = await _tinTucAPIService.GetAll(requestModel);
                var count = data.totalCont;
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
        public string ProsessUpload(HttpPostedFileBase file)
        {
            file.SaveAs(Server.MapPath("~/FileUploaded/" + file.FileName));
            return "~/FileUploaded/" + file.FileName;

        }
        public async Task<ActionResult> Create(TinTucModel requestModel, HttpPostedFileBase FileUpload)
        {
            try
            {
                if (requestModel.Id > 0)
                {
                    var IdPro = await _tinTucAPIService.GetById(requestModel.Id);
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
                        FileUpload.SaveAs(Path.Combine(Server.MapPath("~/FileUploaded/"), tendaydu));
                    }
                    await _tinTucAPIService.Update(requestModel);
                }
                else if (FileUpload.ContentLength > 1)
                {
                    requestModel.Image = FileUpload.FileName;
                    string ten = Path.GetFileNameWithoutExtension(FileUpload.FileName);
                    string morong = Path.GetExtension(FileUpload.FileName);
                    string tendaydu = ten + morong;
                    FileUpload.SaveAs(Path.Combine(Server.MapPath("~/FileUploaded/"), tendaydu));

                    var data = await _tinTucAPIService.Create(requestModel);
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
        public ActionResult ThemMoi()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<ActionResult> Delete(TinTucRequest requestModel)
        {
            try
            {
                await _tinTucAPIService.Delete(requestModel);
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
                    massage = "Xóa thất bại"
                });
            }
        }
        [HttpGet]
        public async Task<ActionResult> ChiTiet(int Id)
        {
            var data = await _tinTucAPIService.GetById(Id);
            return PartialView(data);
        }
    }
}