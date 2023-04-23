using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ColorRepository : IColorRepository
    {
        private readonly IBaseRepository _baseRepository;
        public ColorRepository (IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<ColorPaging> GetAll(ColorRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new ColorPaging();
                model.lst = await _baseRepository.GetList<ColorModel>("[dbo].[Color_GetAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }
    }
}
