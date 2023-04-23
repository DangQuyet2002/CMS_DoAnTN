using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/Size")]
    [ApiController]
    public class SizeController : Controller
    {
        private readonly ISizeRepository _sizeRepository;
        public SizeController(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }
        [Route("DanhSach")]
        [HttpPost]
        public async Task<object> DanhSach(SizeRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var data = await _sizeRepository.GetAll(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = data;

            }catch(Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL;
                res.result = null;
            }
            return res;
        }
    }
}
