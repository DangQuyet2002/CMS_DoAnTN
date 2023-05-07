using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CMS.BillStatus;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/BillStatus")]
    [ApiController]
    public class BillStatusController : Controller
    {
        private readonly IBillStatusRepository _billstatusRepository;
        public BillStatusController(IBillStatusRepository billstatusRepository)
        {
            _billstatusRepository = billstatusRepository;
        }
        [Route("DanhSach")]
        [HttpPost]
        public async Task<object> DanhSach(BillStatusRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var data = await _billstatusRepository.GetAll(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = data;

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
