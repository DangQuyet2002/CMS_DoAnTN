using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IDanhMucDungChungRepository
    {
        Task<DanhMucCategoryPaging> GetAll(DanhMucCategoryRequest requestModel);
        Task<int> Delete(DanhMucCategoryRequest requestModel);
        Task<int> Create(DanhMucCategory requestModel);
        Task<int> Update(DanhMucCategory requestModel);
        Task<DanhMucCategory> GetById(int Id);
    }
}
