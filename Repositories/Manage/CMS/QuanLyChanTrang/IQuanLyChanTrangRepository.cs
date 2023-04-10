using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IQuanLyChanTrangRepository
    {
        Task<tbl_ChanTrangModel> ChiTiet();
        Task<Response> CapNhat(tbl_ChanTrangModel requestModel);

    }
}
