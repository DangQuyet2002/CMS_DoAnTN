using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBillInfoRepository
    {
        Task<BillInfoPaging> GetAll(BillInfoRequest requestModel);
    }
}
