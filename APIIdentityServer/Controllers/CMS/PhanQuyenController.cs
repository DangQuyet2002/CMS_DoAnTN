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
    public class PhanQuyenController : ControllerBase
    {
        private readonly IPhanQuyenRepository _PhanQuyenRepository;
        private readonly ILog log = LogManager.GetLogger(typeof(PhanQuyenController));

        public PhanQuyenController(IPhanQuyenRepository PhanQuyenRepository)
        {
            _PhanQuyenRepository = PhanQuyenRepository ?? throw new ArgumentNullException(nameof(PhanQuyenRepository));
        }

        [HttpPost]
        [Route("DanhSachRole")]
        public async Task<object> DanhSachRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.DanhSachRole(requestModel);
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
        [Route("ThemMoiRole")]
        public async Task<object> ThemMoiRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.ThemMoiRole(requestModel);
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
        [Route("CapNhatRole")]
        public async Task<object> CapNhatRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.CapNhatRole(requestModel);
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
        [Route("XoaRole")]
        public async Task<object> XoaRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.XoaRole(requestModel);
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
        [Route("ThemMoiUserRole")]
        public async Task<object> ThemMoiUserRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.ThemMoiUserRole(requestModel);
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
        [Route("XoaUserRole")]
        public async Task<object> XoaUserRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.XoaUserRole(requestModel);
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
        [Route("DanhSachRoleUser")]
        public async Task<object> DanhSachRoleUser(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.DanhSachRoleUser(requestModel);
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
        [Route("ThemMoiMenuRole")]
        public async Task<object> ThemMoiMenuRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.ThemMoiMenuRole(requestModel);
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
        [Route("XoaMenuRole")]
        public async Task<object> XoaMenuRole(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.XoaMenuRole(requestModel);
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
        [Route("DanhSachRoleMenu")]
        public async Task<object> DanhSachRoleMenu(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.DanhSachRoleMenu(requestModel);
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
        [Route("DanhSachMenu")]
        public async Task<object> DanhSachMenu(tbl_RoleModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _PhanQuyenRepository.DanhSachMenu(requestModel);
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
