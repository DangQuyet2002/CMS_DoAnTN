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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IBaseRepository _baseRepository;

        public CategoryRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> Create(Category requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Name", requestModel.Name);
                return await _baseRepository.GetValue<int>("[dbo].[Category_Create]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<int> Delete(CategoryRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ListIds", requestModel.ListId);
                return await _baseRepository.GetValue<int>("[dbo].[Category_Delete]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<CategoryPaging> GetAll(CategoryRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new CategoryPaging();
                model.lst = await _baseRepository.GetList<Category>("[dbo].[Category_GetAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public async Task<Category> GetById(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                var model = await _baseRepository.GetList<Category>("[dbo].[Category_GetById]", param);
                return model.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public async Task<CategoryPaging> LoadDs()
        {
            try
            {
                var param = new DynamicParameters();
                var model = new CategoryPaging();
                model.lst = await _baseRepository.GetList<Category>("Category_SelectAll", param);
                return model;
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR:" + ex.Message);
                return null;
            }
        }

        public async Task<int> Update(Category requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                param.Add("@Name", requestModel.Name);
                return await _baseRepository.GetValue<int>("[dbo].[Category_Update]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
    }
}
