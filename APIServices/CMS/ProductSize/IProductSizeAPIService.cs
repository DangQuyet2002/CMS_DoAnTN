using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IProductSizeAPIService
    {
        Task<ProductSizePaging> GetByPro( ProductSizeRequest requestModel);
        Task<int> Create(ProductSize requestModel);
    }
}
