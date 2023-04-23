using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IProductColorAPIService
    {
        Task<int> Create(ProductColor requestModel);
        Task<ProductColorPaging> GetByPro( ProductColorRequest requestModel);
    }
}
