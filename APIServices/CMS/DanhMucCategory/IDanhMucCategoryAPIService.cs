using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IDanhMucCategoryAPIService
    {
        Task<DanhMucCategoryPaging> GetAll(DanhMucCategoryRequest requestModel);
        Task<int> Create(DanhMucCategory requestModel);
        Task<int> Update(DanhMucCategory requestModel);
        Task<int> Delete(DanhMucCategoryRequest requestModel);
        Task<DanhMucCategory> GetById(int Id);
    }
}
