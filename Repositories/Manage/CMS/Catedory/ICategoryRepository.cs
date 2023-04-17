using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{ 
    public interface ICategoryRepository
    {
        Task<CategoryPaging> LoadDs();
        Task<CategoryPaging> GetAll( CategoryRequest requestModel);
        Task<int> Create( Category requestModel);
        Task<int> Update( Category requestModel);
        Task<int> Delete( CategoryRequest requestModel);
        Task<Category> GetById( int Id);
    }
}
