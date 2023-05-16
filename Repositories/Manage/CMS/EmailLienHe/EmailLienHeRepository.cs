using Dapper;
using Models;
using Models.CMS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS.EmailLienHe
{
    public class EmailLienHeRepository : IEmailLienHeRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        private readonly IBaseRepository _baseRepository;

        #region Store Procedure Name
        private readonly string _tbl_EmailLienHe_ThemMoi = "tbl_EmailLienHe_ThemMoi";
        private readonly string _tbl_EmailLienHe_DanhSach = "tbl_EmailLienHe_DanhSach";

        #endregion

        public EmailLienHeRepository(IAppConfiguration appConfiguration, IBaseRepository baseRepository)
        {
            _appConfiguration = appConfiguration;
            _baseRepository = baseRepository;
        }

        public async Task<Response> ThemMoi(tbl_EmailLienHe requestModel)
        {
            Response message = new Response();
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", requestModel.Email);
                var result = await _baseRepository.GetValue<int>(_tbl_EmailLienHe_ThemMoi, parameters);
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
        public async Task<BaseRespone<tbl_EmailLienHe>> DanhSach(tbl_EmailLienHe requestModel)
        {
            try
            {
                BaseRespone<tbl_EmailLienHe> Respone = new BaseRespone<tbl_EmailLienHe>();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Email", requestModel.Email);
                parameters.Add("Start", requestModel.start);
                parameters.Add("Length", requestModel.length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var model = new List<tbl_EmailLienHe>();
                var result = await _baseRepository.GetMultipleList(_tbl_EmailLienHe_DanhSach, parameters, reader =>
                {
                    Respone.Data = reader.Read<tbl_EmailLienHe>().ToList();
                    Respone.recordsTotal = parameters.Get<int>("@Count");
                });

                return Respone;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("AspNetUsersRepository error: " + ex.Message);
                return null;
            }
        }


    }
}

