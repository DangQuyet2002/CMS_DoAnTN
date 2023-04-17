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

namespace APIDoAn.Controllers.CMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeAdminController : ControllerBase
    {
        private readonly IHomeAdminRepository _HomeAdminRepository;
        private readonly ILog log = LogManager.GetLogger(typeof(HomeAdminController));

        public HomeAdminController(IHomeAdminRepository HomeAdminRepository)
        {
            _HomeAdminRepository = HomeAdminRepository ?? throw new ArgumentNullException(nameof(HomeAdminRepository));
        }


        [HttpPost]
        [Route("TongBaiDang")]
        public async Task<object> TongBaiDang()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TongBaiDang();
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
        [Route("TongNguoiDung")]
        public async Task<object> TongNguoiDung()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TongNguoiDung();
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
        [Route("TongComment")]
        public async Task<object> TongComment()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TongComment();
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
        [Route("TongLuotXem")]
        public async Task<object> TongLuotXem()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TongLuotXem();
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
        [Route("TopDanhMucXemMN")]
        public async Task<object> TopDanhMucXemMN()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TopDanhMucXemMN();
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
        [Route("TopDanhMucThichMN")]
        public async Task<object> TopDanhMucThichMN()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TopDanhMucThichMN();
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
        [Route("TopDanhMucBLMN")]
        public async Task<object> TopDanhMucBLMN()
        {
            Response res = new Response();
            try
            {
                log.Info("Input: ");
                var model = await _HomeAdminRepository.TopDanhMucBLMN();
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

        [HttpGet]
        [Route("DanhSachMenu")]
        public async Task<object> DanhSachMenu(int IdUser)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + IdUser);
                var model = await _HomeAdminRepository.DanhSachMenu(IdUser);
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

        [HttpGet]
        [Route("DanhSachQuyenNguoiDung")]
        public async Task<object> DanhSachQuyenNguoiDung(int IdUser)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + IdUser);
                var model = await _HomeAdminRepository.DanhSachQuyenNguoiDung(IdUser);
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
