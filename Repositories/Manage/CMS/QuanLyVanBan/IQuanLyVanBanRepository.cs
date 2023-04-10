using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IQuanLyVanBanRepository
    {
        Task<BaseRespone<tbl_VanBanModel>> DanhSach(tbl_VanBanModel requestModel);
        Task<Response> ThemMoi(tbl_VanBanModel requestModel);
        Task<Response> CapNhat(tbl_VanBanModel requestModel);
        Task<Response> Xoa(tbl_VanBanModel requestModel);
        Task<tbl_VanBanModel> ChiTiet(tbl_VanBanModel requestModel);




        Task<BaseRespone<tbl_LoaiVanBanModel>> DanhSachLoaiVanBan(tbl_LoaiVanBanModel requestModel);
        Task<Response> ThemMoiLoaiVanBan(tbl_LoaiVanBanModel requestModel);
        Task<Response> CapNhatLoaiVanBan(tbl_LoaiVanBanModel requestModel);
        Task<Response> XoaLoaiVanBan(tbl_LoaiVanBanModel requestModel);
        Task<tbl_LoaiVanBanModel> ChiTietLoaiVanBan(tbl_LoaiVanBanModel requestModel);
    }
}
