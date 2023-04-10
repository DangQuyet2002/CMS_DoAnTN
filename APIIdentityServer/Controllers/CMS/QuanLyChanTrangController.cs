using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Repositories.Manage.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICMS.Controllers.CMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuanLyChanTrangController : ControllerBase
    {
        private readonly IQuanLyChanTrangRepository _QuanLyChanTrangRepository;
        private readonly ILog log = LogManager.GetLogger(typeof(QuanLyChanTrangController));

        public QuanLyChanTrangController(IQuanLyChanTrangRepository QuanLyChanTrangRepository)
        {
            _QuanLyChanTrangRepository = QuanLyChanTrangRepository ?? throw new ArgumentNullException(nameof(QuanLyChanTrangRepository));
        }

        [HttpPost]
        [Route("ChiTiet")]
        public async Task<object> ChiTiet()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _QuanLyChanTrangRepository.ChiTiet();
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }

        [HttpPost]
        [Route("CapNhat")]
        public async Task<object> CapNhat(tbl_ChanTrangModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _QuanLyChanTrangRepository.CapNhat(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }
    }
}
