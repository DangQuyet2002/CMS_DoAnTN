using Dapper;
using Models;
using Models.CMS.BillStatus;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BillStatusRepository : IBillStatusRepository
    {
        private readonly IBaseRepository _baseRepository;
        public BillStatusRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<BillStatusPaging> GetAll(BillStatusRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new BillStatusPaging();
                model.lst = await _baseRepository.GetList<BillStatus>("[dbo].[Status_GetAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }

 
    }
}
