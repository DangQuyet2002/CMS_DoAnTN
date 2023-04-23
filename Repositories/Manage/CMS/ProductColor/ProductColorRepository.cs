using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductColorRepository : IProductColorRepository
    {
        private readonly IBaseRepository _baseRepository;
        public ProductColorRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Create(ProductColor requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ProductId", requestModel.ProductId);
                param.Add("@ColorId", requestModel.ColorId);
                return await _baseRepository.GetValue<int>("[dbo].[ProductColor_Create]", param);
            }
            catch(Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return 0;
            }
        }

        public async Task<ProductColorPaging> GetByPro(ProductColorRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                var model = new ProductColorPaging();
                model.lst = await _baseRepository.GetList<ProductColor>("[dbo].[ProductColor_GetById]", param);
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }
    }
}
