using Models;
using Models.CMS.BillStatus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS.BillStatus
{
    public interface IBillStatusAPIService
    {
        Task<BillStatusPaging> GetAll(BillStatusRequest requestModel);
    }
}
