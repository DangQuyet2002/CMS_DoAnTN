using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IBillAPIService
    {
        Task<int> Create(Bill requestModel);
        Task<BillPaging> GetByUser(BillRequest requestModel);
        Task<BillPaging> GetAll(BillRequest requestModel);

    }
}
