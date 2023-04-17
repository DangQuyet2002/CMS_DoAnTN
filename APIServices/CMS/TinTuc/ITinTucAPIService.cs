using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface ITinTucAPIService
    {
        Task<TinTucPaging> GetAll(TinTucRequest requestModel);
        Task<TinTucPaging> SelectAll();
        Task<TinTucModel> GetById(int Id);
        Task<int> Create(TinTucModel requestModel);
        Task<int> Update(TinTucModel requestModel);
        Task<int> Delete(TinTucRequest requestModel);
    }
}
