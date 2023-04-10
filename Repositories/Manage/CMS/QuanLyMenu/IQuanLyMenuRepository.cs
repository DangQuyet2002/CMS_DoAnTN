using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IQuanLyMenuRepository
    {
        Task<List<tbl_SettingMenu_CategoryModel>> DanhSachTheoIdSetting(tbl_SettingMenu_CategoryModel requestModel);
        Task<List<tbl_SettingMenu_CategoryModel>> DanhSachSettingMenu(tbl_SettingMenu_CategoryModel requestModel);
        Task<Response> ThemMoi(tbl_SettingMenu_CategoryModel requestModel);
        Task<Response> CapNhatSTT(tbl_SettingMenu_CategoryModel requestModel);
        Task<Response> Xoa(tbl_SettingMenu_CategoryModel requestModel);
    }
}
