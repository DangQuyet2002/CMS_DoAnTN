using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public class QuanLyChanTrangRepository : IQuanLyChanTrangRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;
        public QuanLyChanTrangRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }
        #region Store Procedure Name
        private readonly string _tbl_ChanTrang_ChiTiet = "tbl_ChanTrang_ChiTiet";
        private readonly string _tbl_ChanTrang_CapNhat = "tbl_ChanTrang_CapNhat";
        #endregion

        public async Task<Response> CapNhat(tbl_ChanTrangModel requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                parameters.Add("ChanTrangBP", requestModel.ChanTrangBP);
                parameters.Add("ChanTrangBT", requestModel.ChanTrangBT);
                parameters.Add("ChanTrang", requestModel.ChanTrang);

                var result = await _baseRepository.GetValue<int>(_tbl_ChanTrang_CapNhat, parameters);

                message.code = ResponseCode.SUCCESS;
                message.message = ResponseDetail.SUCCESSDETAIL;
                message.result = result;
                return message;
            }
            catch (Exception ex)
            {
                message.code = ResponseCode.UNKNOWN_ERROR;
                message.message = ResponseDetail.UNKNOWN_ERRORDETAIL + " - " + ex.Message;
                message.result = null;
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return message;
            }
        }
        public async Task<tbl_ChanTrangModel> ChiTiet()
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                var respone = await _baseRepository.GetList<tbl_ChanTrangModel>(_tbl_ChanTrang_ChiTiet, parameters);
                return respone.Count > 0 ? respone.FirstOrDefault() : new tbl_ChanTrangModel();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return new tbl_ChanTrangModel();
            }
        }
    }
}
