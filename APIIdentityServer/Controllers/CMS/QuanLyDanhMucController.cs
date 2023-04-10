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
    public class QuanLyDanhMucController : ControllerBase
    {
        private readonly IQuanLyDanhMucRepository _QuanLyDanhMucRepository;
        private readonly ILog log = LogManager.GetLogger(typeof(QuanLyDanhMucController));

        public QuanLyDanhMucController(IQuanLyDanhMucRepository QuanLyDanhMucRepository)
        {
            _QuanLyDanhMucRepository = QuanLyDanhMucRepository ?? throw new ArgumentNullException(nameof(QuanLyDanhMucRepository));
        }

        [HttpPost]
        [Route("DanhSach")]
        public async Task<object> DanhSachKeHoach(tbl_CategoryModel requestModel)
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
        public async Task<object> ThemMoi(tbl_CategoryModel requestModel)
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
        public async Task<object> CapNhat(tbl_CategoryModel requestModel)
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
        public async Task<object> Xoa(tbl_CategoryModel requestModel)
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
        public async Task<object> ChiTiet(tbl_CategoryModel requestModel)
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
        [Route("DanhSachAll")]
        public async Task<object> DanhSachAll(tbl_CategoryModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.DanhSachAll(requestModel);
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
        [Route("ChiTietChuyenMucBaiViet")]
        public async Task<object> ChiTietChuyenMucBaiViet(tbl_CategoryModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _QuanLyDanhMucRepository.ChiTietChuyenMucBaiViet(requestModel);
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
