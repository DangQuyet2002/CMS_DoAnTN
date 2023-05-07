using Microsoft.AspNetCore.Mvc;
using Models;
using Models.CMS.Product;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [Route("GetAll")]
        [HttpPost]
        public async Task<object> GetAll(ProductRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.GetAll(requestModel);
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
        [Route("GetAllDisCount")]
        [HttpPost]
        public async Task<object> GetAllDisCount(ProductRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.GetAllDisCount(requestModel);
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
        [Route("GetByCate")]
        [HttpPost]
        public async Task<object> GetByCate(ProductRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.GetByCate(requestModel);
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
        [Route("Create")]
        [HttpPost]
        public async Task<object> Create(Product requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.Create(requestModel);
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
        [Route("UpdateView")]
        [HttpPost]
        public async Task<object> UpdateView(int Id )
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.UpdateView(Id);
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
        [Route("Update")]
        [HttpPost]
        public async Task<object> Update(Product requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.Update(requestModel);
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

        [Route("UpdateQuantity")]
        [HttpPost]
        public async Task<object> UpdateQuantity(Product requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.UpdateQuantity(requestModel);
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

        [Route("Delete")]
        [HttpPost]
        public async Task<object> Delete(ProductRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.Delete(requestModel);
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
        [Route("GetByView")]
        [HttpPost]
        public async Task<object> GetByView()
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.GetByView();
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
        [Route("GetById")]
        [HttpGet]
        public async Task<object> GetById(int Id)
        {
            Response res = new Response();
            try
            {
                var model = await _productRepository.GetById(Id);
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
