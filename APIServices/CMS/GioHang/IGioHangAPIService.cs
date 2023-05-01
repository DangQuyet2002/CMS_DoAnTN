using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IGioHangAPIService
    {
        Task<int> Create(GioHang requestModel);
        Task<int> Detele(GioHangRequest requestModel);
        Task<GioHangPaging> GetByUser(GioHangRequest requestModel);
        Task<GioHangPaging> GetListByUser(GioHangRequest requestModel);
        Task<int> DeleteAll(GioHangRequest requestModel);
        Task<GioHang> GetById(int Id);
        Task<GioHang> GetByIdBill(int Id);

    }
}
