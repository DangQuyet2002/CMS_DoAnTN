using Dapper;
using Models;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IBaseRepository _baseRepository;

        public ProductRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> Create(Product requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@NamePro", requestModel.NamePro);
                param.Add("@Price", requestModel.Price);
                param.Add("@Image", requestModel.Image);
                param.Add("@CategoryId", requestModel.CategoryId);
                param.Add("@CategoryIdMin", requestModel.CategoryminId);
                param.Add("@Discount", requestModel.Discount);
                param.Add("@Quantity", requestModel.Quantity);
                param.Add("@MoTa", requestModel.MoTa);
                return await _baseRepository.GetValue<int>("[dbo].[Product_Create]", param);         
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
        public async Task<int> Update(Product requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", requestModel.Id);
                param.Add("@NamePro", requestModel.NamePro);
                param.Add("@Price", requestModel.Price);
                param.Add("@Image", requestModel.Image);
                param.Add("@CategoryId", requestModel.CategoryId);
                param.Add("@CategoryIdMin", requestModel.CategoryminId);
                param.Add("@Discount", requestModel.Discount);
                param.Add("@Quantity", requestModel.Quantity);
                param.Add("@MoTa", requestModel.MoTa);
                return await _baseRepository.GetValue<int>("[dbo].[Product_Update]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }
        public async Task<int> Delete(ProductRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@ListIds", requestModel.ListId);
                return await _baseRepository.GetValue<int>("[dbo].[Product_Delete]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<ProductPaging> GetAll(ProductRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@Start", requestModel.Start);
                param.Add("@Length", requestModel.Length);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new ProductPaging();
                model.lst = await _baseRepository.GetList<Product>("[dbo].[Product_GetAll]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
        public async Task<ProductPaging> GetAllDisCount(ProductRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@KeyWord", requestModel.Keywords);
                param.Add("@pageIndex", requestModel.Page);
                param.Add("@pageSize", requestModel.PageSize);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new ProductPaging();
                model.lst = await _baseRepository.GetList<Product>("[dbo].[Product_GetAllDisCount]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
        public async Task<ProductPaging> GetByCate(ProductRequest requestModel)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@CategoryId", requestModel.CategoryId);
                param.Add("@CategoryIdMin", requestModel.CategoryMinId);
                param.Add("@Start", requestModel.Start);
                param.Add("@Length", requestModel.Length);
                param.Add("@totalCount", 0, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput);
                var model = new ProductPaging();
                model.lst = await _baseRepository.GetList<Product>("[dbo].[Product_GetByCate]", param);
                model.totalCount = param.Get<int>("@totalCount");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
        public async Task<Product> GetById(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                var model = await _baseRepository.GetList<Product>("[dbo].[Product_GetById]", param);
                return model.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }

        public async Task<int> UpdateView(int Id)
        {
            try
            {
                var param = new DynamicParameters();
                param.Add("@Id", Id);
                return await _baseRepository.GetValue<int>("[dbo].[Product_UpdateView]", param);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return 0;
            }
        }

        public async Task<ProductPaging> GetByView()
        {
            try
            {
                var param = new DynamicParameters();
                var model = new ProductPaging();
                model.lst = await _baseRepository.GetList<Product>("[dbo].[Product_GetByView]", param);
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error:" + ex.Message);
                return null;
            }
        }
    }
}
