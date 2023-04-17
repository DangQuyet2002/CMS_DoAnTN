using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/TinTuc")]
    [ApiController]
    public class TinTucController : Controller
    {
        private readonly ITinTucRepository _tinTucRepository;
        public TinTucController(ITinTucRepository tinTucRepository)
        {
            _tinTucRepository = tinTucRepository;
        }
        [Route("GetAll")]
        [HttpPost]
        public async Task<object> GetAll(TinTucRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _tinTucRepository.GetAll(requestModel);
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
        [Route("SelectAll")]
        [HttpPost]
        public async Task<object> SelectAll()
        {
            Response res = new Response();
            try
            {
                var model = await _tinTucRepository.SelectAll();
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
        public async Task<object> Create(TinTucModel requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _tinTucRepository.Create(requestModel);
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
        public async Task<object> Update(TinTucModel requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _tinTucRepository.Update(requestModel);
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
        public async Task<object> Delete(TinTucRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _tinTucRepository.Delete(requestModel);
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
                var model = await _tinTucRepository.GetById(Id);
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
