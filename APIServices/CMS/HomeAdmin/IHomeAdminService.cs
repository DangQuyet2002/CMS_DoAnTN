using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS.HomeAdmin
{
    public interface IHomeAdminService
    {
        Task<Response> TongBaiDang();
        Task<Response> TongNguoiDung();
        Task<Response> TongComment();
        Task<Response> TongLuotXem();
        Task<List<tbl_CategoryModel>> TopDanhMucXemMN();
        Task<List<tbl_CategoryModel>> TopDanhMucThichMN();
        Task<List<tbl_CategoryModel>> TopDanhMucBLMN();
        Task<List<tbl_RoleModel>> DanhSachMenu(int IdUser);
        Task<List<tbl_RoleModel>> DanhSachQuyenNguoiDung(int IdUser);

    }
}
