using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductSizeRepository
    {
        Task<int> Create(ProductSize requestModel);
        Task<ProductSizePaging> GetByPro(ProductSizeRequest requestModel);
    }
}
