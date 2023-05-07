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
        Task<int> Update(Product requestModel);
        Task<int> UpdateQuantity(Product requestModel);

        Task<int> UpdateView(int Id);
        Task<int> Create(Product requestModel);
        Task<Product> GetById(int Id);
        Task<ProductPaging> GetByView();
    }
}
