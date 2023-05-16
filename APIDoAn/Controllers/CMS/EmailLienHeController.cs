using log4net;
using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CMS;
using Newtonsoft.Json;
using Repositories.Manage.CMS;
using Repositories.Manage.CMS.EmailLienHe;
using System;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailLienHeController : ControllerBase
    {
        private readonly IEmailLienHeRepository _EmailLienHeRepository;

        public EmailLienHeController(IEmailLienHeRepository EmailLienHeRepository)
        {
            _EmailLienHeRepository = EmailLienHeRepository ?? throw new ArgumentNullException(nameof(EmailLienHeRepository));
        }
        [HttpPost]
        [Route("ThemMoi")]
        public async Task<object> ThemMoi(tbl_EmailLienHe requestModel)
        {
            Response res = new Response();
            try
            {
                
                var model = await _EmailLienHeRepository.ThemMoi(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;

            }
            return res;
        }
        [HttpPost]
        [Route("DanhSach")]
        public async Task<object> DanhSach(tbl_EmailLienHe requestModel)
        {
            Response res = new Response();
            try
            {
                
                var model = await _EmailLienHeRepository.DanhSach(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
  
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
            }
            return res;
        }
        //[HttpPost]
        //[Route("CapNhat")]
        //public async Task<object> CapNhat(tbl_EmailLienHe requestModel)
        //{
        //    Response res = new Response();
        //    try
        //    {
        //        log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
        //        var model = await _EmailLienHeRepository.CapNhat(requestModel);
        //        res.code = ResponseCode.SUCCESS;
        //        res.message = ResponseDetail.SUCCESSDETAIL;
        //        res.result = model;
        //        log.Info("Output: " + JsonConvert.SerializeObject(res));
        //    }
        //    catch (Exception ex)
        //    {
        //        res.code = ResponseCode.UNKNOWN_ERROR;
        //        res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
        //        res.result = null;
        //        log.Error("Error: " + JsonConvert.SerializeObject(res));
        //    }
        //    return res;
        //}

        //[HttpPost]
        //[Route("Xoa")]
        //public async Task<object> Xoa(tbl_EmailLienHe requestModel)
        //{
        //    Response res = new Response();
        //    try
        //    {
        //        log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
        //        var model = await _EmailLienHeRepository.Xoa(requestModel);
        //        res.code = ResponseCode.SUCCESS;
        //        res.message = ResponseDetail.SUCCESSDETAIL;
        //        res.result = model;
        //        log.Info("Output: " + JsonConvert.SerializeObject(res));
        //    }
        //    catch (Exception ex)
        //    {
        //        res.code = ResponseCode.UNKNOWN_ERROR;
        //        res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
        //        res.result = null;
        //        log.Error("Error: " + JsonConvert.SerializeObject(res));
        //    }
        //    return res;
        //}
    }
}
