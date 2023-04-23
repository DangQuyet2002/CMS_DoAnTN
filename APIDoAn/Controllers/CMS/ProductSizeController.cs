using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/ProductSize")]
    [ApiController]
    public class ProductSizeController : Controller
    {
        private readonly IProductSizeRepository _productSizeRepository;
        public ProductSizeController(IProductSizeRepository productSizeRepository)
        {
            _productSizeRepository = productSizeRepository;
        }
        [Route("create")]
        [HttpPost]
        public async Task<object> Create(ProductSize requestModel)
        {
            Response res = new Response();
            try
            {
                var data = await _productSizeRepository.Create(requestModel);
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
        public async Task<object> GetByPro(ProductSizeRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var data = await _productSizeRepository.GetByPro(requestModel);
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
