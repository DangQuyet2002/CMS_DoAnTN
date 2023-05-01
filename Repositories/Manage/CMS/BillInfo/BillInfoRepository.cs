using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BillInfoRepository : IBillInfoRepository
    {
        private readonly IBaseRepository _baseRepository;
        public BillInfoRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
       
        public async Task<BillInfoPaging> GetAll(BillInfoRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new BillInfoPaging();
                model.lst = await _baseRepository.GetList<BillInfo>("[dbo].[BillInfo_getAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR" + ex.Message);
                return null;
            }
        }
    }
}
