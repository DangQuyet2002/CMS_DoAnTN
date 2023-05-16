using APIServices.CMS.EmailLienHe;
using Models.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Utilities;

namespace WebApp.Controllers
{
    public class EmailLienHeController : Controller
    {
        private readonly IEmailLienHeService _EmailLienHeService;

        public EmailLienHeController(IEmailLienHeService EmailLienHeService)
        {
            _EmailLienHeService = EmailLienHeService;
        }
        [HttpPost]
        public async Task<ActionResult> ThemMoi(tbl_EmailLienHe requestModel)
        {

            try
            {
                await _EmailLienHeService.ThemMoi(requestModel);
                return Json(new
                {
                    type = "success",
                    message = "Thêm mới Email thành công"

                });
            }
            catch (Exception e)
            {
                return Json(new { type = CommonConstants.ERROR, message = e.Message });
            }
        }


    }
}