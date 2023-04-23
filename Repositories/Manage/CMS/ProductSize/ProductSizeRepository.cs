using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductSizeRepository : IProductSizeRepository
    {
        private readonly IBaseRepository _baseRepository;
        public ProductSizeRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Create(ProductSize requestModel)
        {

            try
            {
                var param = new DynamicParameters();
                param.Add("@ProductId", requestModel.ProductId);
                param.Add("@SizeId", requestModel.SizeId);
                return await _baseRepository.GetValue<int>("[dbo].[ProductSize_Create]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return 0;
            }
        }
        public async Task<ProductSizePaging> GetByPro(ProductSizeRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                var model = new ProductSizePaging();
                model.lst = await _baseRepository.GetList<ProductSize>("[dbo].[ProductSize_GetById]", param);
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
