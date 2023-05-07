using Models;
using Models.CMS.BillStatus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBillStatusRepository
    {
        Task<BillStatusPaging> GetAll(BillStatusRequest requestModel);
    }
}
