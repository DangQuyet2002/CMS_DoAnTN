using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Repositories.Manage.CMS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICMS.Controllers.CMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class CacCapHoiController : ControllerBase
    {
        private readonly ICacCapHoiRepository _QuanLyDanhMucRepository;
        private readonly ILog log = LogManager.GetLogger(typeof(CacCapHoiController));

        public CacCapHoiController(ICacCapHoiRepository CacCapHoiRepository)
        {
            _QuanLyDanhMucRepository = CacCapHoiRepository ?? throw new ArgumentNullException(nameof(CacCapHoiRepository));
        }

        [HttpPost]
        [Route("DanhSach")]
        public async Task<object> DanhSach(tbl_CacCapHoiModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.DanhSach(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }

        [HttpPost]
        [Route("ThemMoi")]
        public async Task<object> ThemMoi(tbl_CacCapHoiModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.ThemMoi(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }

        [HttpPost]
        [Route("CapNhat")]
        public async Task<object> CapNhat(tbl_CacCapHoiModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.CapNhat(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }

        [HttpPost]
        [Route("Xoa")]
        public async Task<object> Xoa(tbl_CacCapHoiModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.Xoa(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }

        [HttpPost]
        [Route("ChiTiet")]
        public async Task<object> ChiTiet(tbl_CacCapHoiModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.ChiTiet(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }

        [HttpPost]
        [Route("CapNhatSTT")]
        public async Task<object> CapNhatSTT(tbl_CacCapHoiModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.CapNhatSTT(requestModel);
                res.code = ResponseCode.SUCCESS;
                res.message = ResponseDetail.SUCCESSDETAIL;
                res.result = model;
                log.Info("Output: " + JsonConvert.SerializeObject(res));
            }
            catch (Exception ex)
            {
                res.code = ResponseCode.UNKNOWN_ERROR;
                res.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                res.result = null;
                log.Error("Error: " + JsonConvert.SerializeObject(res));
            }
            return res;
        }
    }
}
