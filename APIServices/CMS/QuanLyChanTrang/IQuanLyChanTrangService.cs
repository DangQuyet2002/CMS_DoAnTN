using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IQuanLyChanTrangService
    {
        Task<tbl_ChanTrangModel> ChiTiet();
        Task<Response> CapNhat(tbl_ChanTrangModel requestModel);
    }
}
