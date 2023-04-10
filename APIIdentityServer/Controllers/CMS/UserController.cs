using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Newtonsoft.Json;
using Repositories.Manage.CMS;
using System;
using System.Threading.Tasks;

namespace APICMS.Controllers.CMS
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        private readonly ILog log = LogManager.GetLogger(typeof(UserController));

        public UserController(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository ?? throw new ArgumentNullException(nameof(UserRepository));
        }
        [HttpPost]
        [Route("DangNhap")]
        public async Task<object> DangNhap(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.DangNhap(requestModel);
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
        [Route("DangNhapGoole")]
        public async Task<object> DangNhapGoole(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.DangNhapGoole(requestModel);
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
        [Route("DangKyTKGoole")]
        public async Task<object> DangKyTKGoole(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.DangKyTKGoole(requestModel);
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
        [Route("DangKyTK")]
        public async Task<object> DangKyTK(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.DangKyTK(requestModel);
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
        [Route("DangNhapTK")]
        public async Task<object> DangNhapTK(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.DangNhapTK(requestModel);
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
        [Route("DanhSach")]
        public async Task<object> DanhSach(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.DanhSach(requestModel);
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
        public async Task<object> CapNhat(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.CapNhat(requestModel);
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
        [Route("CheckUser")]
        public async Task<object> CheckUser(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.CheckUser(requestModel);
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
        public async Task<object> ChiTiet(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.ChiTiet(requestModel);
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
        public async Task<object> ThemMoi(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.ThemMoi(requestModel);
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
        [Route("CheckMail")]
        public async Task<object> CheckMail(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.CheckMail(requestModel);
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
        public async Task<object> Xoa(tbl_UserModel requestModel)
        {
            Response res = new Response();
            try
            {
                log.Info("Input: " + JsonConvert.SerializeObject(requestModel));
                var model = await _UserRepository.Xoa(requestModel);
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
