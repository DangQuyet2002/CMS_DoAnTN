using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/BillInfo")]
    [ApiController]
    public class BillInfoController : Controller
    {
        private readonly IBillInfoRepository _billInfoRepository;
        public BillInfoController(IBillInfoRepository billInfoRepository)
        {
            _billInfoRepository = billInfoRepository;
        }

        [Route("GetAll")]
        [HttpPost]
        public async Task<object> GetAll(BillInfoRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _billInfoRepository.GetAll(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL;
                res.result = null;
            }
            return res;
        }
    }
}
