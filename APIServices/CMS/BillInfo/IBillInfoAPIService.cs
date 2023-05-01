using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    
    public interface IBillInfoAPIService
    {
        Task<BillInfoPaging> GetAll(BillInfoRequest requestModel);
    }
}
