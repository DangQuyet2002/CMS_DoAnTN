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
    public class QuanLyColorController : Controller
    {
        private readonly IColorAPIService _colorAPIService;
        public QuanLyColorController()
        {
            _colorAPIService = new ColorAPIService();
        }
        // GET: Admin/QuanLyColor
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> DanhSach(ColorRequest requestModel)
        {
            try
            {
                var data = await _colorAPIService.GetAll(requestModel);
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
    }
}