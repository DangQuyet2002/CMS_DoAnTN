using Models;
using Models.CMS.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IProductsAPIService
    {
        Task<ProductPaging> GetAll(ProductRequest requestModel);
        Task<ProductPaging> GetAllDisCount(ProductRequest requestModel);
        Task<ProductPaging> GetByCate(ProductRequest requestModel);
        Task<int> Delete(ProductRequest requestModel);
        Task<int> Create(Product requestModel);
        Task<int> UpdateView(int Id);
        Task<ProductPaging> GetByView();

        Task<int> Update(Product requestModel);
        Task<Product> GetById(int Id);
    }
}
