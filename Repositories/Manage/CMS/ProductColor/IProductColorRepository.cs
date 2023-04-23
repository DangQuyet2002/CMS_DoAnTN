using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductColorRepository
    {
        Task<int> Create(ProductColor requestModel);
        Task<ProductColorPaging> GetByPro(ProductColorRequest requestModel);
    }
}
