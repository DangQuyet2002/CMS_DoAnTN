using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IProductLikeRepository
    {
        Task<int> Create(GioHang requestModel);
        Task<int> Delete(GioHangRequest requestModel);
        Task<int> DeleteAll(GioHangRequest requestModel);
        Task<GioHangPaging> GetByUser(GioHangRequest requestModel);
        Task<GioHangPaging> GetListByUser(GioHangRequest requestModel);
        Task<GioHang> GetById(int Id);
        Task<GioHang> GetByIdBill(int Id);
        Task<int> Update(GioHang requestModel);
        Task<int> UpdateColor(GioHang requestModel);
        Task<int> UpdateQuantity(GioHang requestModel);



    }
}
