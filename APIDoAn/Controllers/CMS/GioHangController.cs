using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIDoAn.Controllers.CMS
{
    [Route("api/GioHang")]
    [ApiController]
    public class GioHangController : Controller
    {
        private readonly IGioHangRepository _gioHangRepository;
        public GioHangController(IGioHangRepository gioHangRepository)
        {
            _gioHangRepository = gioHangRepository;
        }
        [Route("Create")]
        [HttpPost]
        public async Task<object> Create(GioHang requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.Create(requestModel);
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
        public async Task<object> GetByUser(GioHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.GetByUser(requestModel);
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
                var model = await _gioHangRepository.GetById(Id);
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

        [Route("GetByIdBill")]
        [HttpGet]
        public async Task<object> GetByIdBill(int Id)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.GetByIdBill(Id);
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
        [Route("GetListByUser")]
        [HttpPost]
        public async Task<object> GetListByUser(GioHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.GetListByUser(requestModel);
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
        public async Task<object> Delete(GioHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.Delete(requestModel);
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
        [Route("DeleteAll")]
        [HttpPost]
        public async Task<object> DeleteAll(GioHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.DeleteAll(requestModel);
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
