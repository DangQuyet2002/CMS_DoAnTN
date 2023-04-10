using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IPhanQuyenService
    {
        Task<List<tbl_RoleModel>> DanhSachRole(tbl_RoleModel requestModel);
        Task<Response> ThemMoiRole(tbl_RoleModel requestModel);
        Task<Response> CapNhatRole(tbl_RoleModel requestModel);
        Task<Response> XoaRole(tbl_RoleModel requestModel);
        Task<Response> ThemMoiUserRole(tbl_RoleModel requestModel);
        Task<Response> XoaUserRole(tbl_RoleModel requestModel);
        Task<List<tbl_RoleModel>> DanhSachRoleUser(tbl_RoleModel requestModel);
        Task<Response> ThemMoiMenuRole(tbl_RoleModel requestModel);
        Task<Response> XoaMenuRole(tbl_RoleModel requestModel);
        Task<List<tbl_RoleModel>> DanhSachRoleMenu(tbl_RoleModel requestModel);
        Task<List<tbl_RoleModel>> DanhSachMenu(tbl_RoleModel requestModel);
    }
}
