using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Controllers.DoAn
{
    [Route("api/DMCategory")]
    [ApiController]
    public class DanhMucCategoryController : Controller
    {
        private readonly IDanhMucDungChungRepository _categoryRepository;
        public DanhMucCategoryController(IDanhMucDungChungRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [Route("GetAll")]
        [HttpPost]
        public async Task<object> GetAll(DanhMucCategoryRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _categoryRepository.GetAll(requestModel);
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
        public async Task<object> Create(DanhMucCategory requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _categoryRepository.Create(requestModel);
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
        public async Task<object> Delete(DanhMucCategoryRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _categoryRepository.Delete(requestModel);
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
                var model = await _categoryRepository.GetById(Id);
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
        public async Task<object> Update(DanhMucCategory requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _categoryRepository.Update(requestModel);
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
