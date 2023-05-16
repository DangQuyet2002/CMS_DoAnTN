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

        [Route("CreateProductLike")]
        [HttpPost]
        public async Task<object> CreateProductLike(GioHang requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.CreateProductLike(requestModel);
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
        [Route("GetByUserProductLike")]
        [HttpPost]
        public async Task<object> GetByUserProductLike(GioHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.GetByUserProductLike(requestModel);
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

        [Route("Update")]
        [HttpPost]
        public async Task<object> Update(GioHang requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.Update(requestModel);
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
        [Route("UpdateColor")]
        [HttpPost]
        public async Task<object> UpdateColor(GioHang requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.UpdateColor(requestModel);
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
        public async Task<object> UpdateQuantity(GioHang requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.UpdateQuantity(requestModel);
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
        [Route("DeleteProductLike")]
        [HttpPost]
        public async Task<object> DeleteProductLike(GioHangRequest requestModel)
        {
            Response res = new Response();
            try
            {
                var model = await _gioHangRepository.DeleteProductLike(requestModel);
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
