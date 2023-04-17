using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface ICategoryAPIService
    {
        Task<CategoryPaging> LoadDS();
        Task<CategoryPaging> GetAll(CategoryRequest requestModel); 
        Task<int> Create(Category requestModel);
        Task<int> Update(Category requestModel);
        Task<int> Delete(CategoryRequest requestModel);
        Task<Category> GetById(int Id );
    }
}
