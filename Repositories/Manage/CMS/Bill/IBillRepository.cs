using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBillRepository
    {
        Task<BillPaging> GetByUser(BillRequest requestModel);
        Task<BillPaging> GetAll(BillRequest requestModel);
        Task<int> Create(Bill requestModel);
        Task<int> Update(Bill requestModel);


    }
}
