using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DanhMucDungChungRepository : IDanhMucDungChungRepository
    {
        private readonly IBaseRepository _baseRepository;

        public DanhMucDungChungRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> Create(DanhMucCategory requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Name", requestModel.Name);
                return await _baseRepository.GetValue<int>("[dbo].[CategoryMin_Create]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<int> Delete(DanhMucCategoryRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ListIds", requestModel.ListId);
                return await _baseRepository.GetValue<int>("[dbo].[CategoryMin_Delete]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<DanhMucCategoryPaging> GetAll(DanhMucCategoryRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@Start", requestModel.Start);
                param.Add("@Length", requestModel.Length);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new DanhMucCategoryPaging();
                model.lst = await _baseRepository.GetList<DanhMucCategory>("[dbo].[CategoryMin_GetAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public async Task<DanhMucCategory> GetById(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                var model = await _baseRepository.GetList<DanhMucCategory>("[dbo].[CategoryMin_GetById]", param);
                return model.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public  async Task<int> Update(DanhMucCategory requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                param.Add("@Name", requestModel.Name);
                return await _baseRepository.GetValue<int>("[dbo].[CategoryMin_Update]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
    }
}
