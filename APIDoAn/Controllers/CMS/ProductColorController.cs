using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/ProductColor")]
    [ApiController]
    public class ProductColorController : Controller
    {

        private readonly IProductColorRepository _productColorRepository;
        public ProductColorController(IProductColorRepository productColorRepository)
        {
            _productColorRepository = productColorRepository;
        }
        [Route("create")]
        [HttpPost]
        public async Task<object> Create(ProductColor requestModel)
        {
            Response res = new Response();
            try
            {
                var data = await _productColorRepository.Create(requestModel);
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
        [Route("GetByPro")]
        [HttpPost]
        public async Task<object> GetByPro(ProductColorRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var data = await _productColorRepository.GetByPro(requestModel);
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
