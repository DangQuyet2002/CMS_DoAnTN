using Models;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
   public interface IProductRepository
    {
        Task<ProductPaging> GetAll(ProductRequest requestModel);
        Task<ProductPaging> GetAllDisCount(ProductRequest requestModel);
        Task<ProductPaging> GetByCate(ProductRequest requestModel);
        Task<int> Delete(ProductRequest requestModel);
        Task<int> Update(tbl_ProductModel requestModel);
        Task<int> UpdateView(int Id);
        Task<int> Create(tbl_ProductModel requestModel);
        Task<tbl_ProductModel> GetById(int Id);
        Task<ProductPaging> GetByView();
    }
}
