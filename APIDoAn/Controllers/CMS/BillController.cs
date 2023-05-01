using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/Bill")]
    [ApiController]
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;
        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<object> Create(Bill requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _billRepository.Create(requestModel);
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
        [Route("GetByUser")]
        [HttpPost]
        public async Task<object> GetByUser(BillRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _billRepository.GetByUser(requestModel);
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
        [Route("GetAll")]
        [HttpPost]
        public async Task<object> GetAll(BillRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _billRepository.GetAll(requestModel);
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
