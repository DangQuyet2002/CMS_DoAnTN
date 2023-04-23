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
    public class QuanLySizeController : Controller
    {
        private readonly ISizeAPIService _colorAPIService;
        public QuanLySizeController()
        {
            _colorAPIService = new SizeAPIService();
        }
        // GET: Admin/QuanLySize
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> DanhSach(SizeRequest requestModel)
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