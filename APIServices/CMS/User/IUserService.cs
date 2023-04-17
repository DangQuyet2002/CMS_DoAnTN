using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IUserService
    {
        Task<tbl_UserModel> DangNhap(tbl_UserModel requestModel);
        Task<tbl_UserModel> DangNhapGoole(tbl_UserModel requestModel);
        Task<Response> DangKyTKGoole(tbl_UserModel requestModel);
        Task<Response> DangKyTK(tbl_UserModel requestModel);
        Task<tbl_UserModel> DangNhapTK(tbl_UserModel requestModel);

        Task<BaseRespone<tbl_UserModel>> DanhSach(tbl_UserModel requestModel);
        Task<BaseRespone<tbl_UserModel>> DanhSachAdmin(tbl_UserModel requestModel);

        Task<Response> CapNhat(tbl_UserModel requestModel);
        Task<List<tbl_UserModel>> CheckUser(tbl_UserModel requestModel);
        Task<tbl_UserModel> ChiTiet(tbl_UserModel requestModel);
        Task<Response> ThemMoi(tbl_UserModel requestModel);
        Task<List<tbl_UserModel>> CheckMail(tbl_UserModel requestModel);
        Task<Response> Xoa(tbl_UserModel requestModel);

    }
}
