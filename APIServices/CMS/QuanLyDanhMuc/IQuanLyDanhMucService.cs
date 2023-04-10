using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IQuanLyDanhMucService
    {
        Task<List<tbl_CategoryModel>> DanhSach(tbl_CategoryModel requestModel);
        Task<Response> ThemMoi(tbl_CategoryModel requestModel);
        Task<Response> CapNhat(tbl_CategoryModel requestModel);
        Task<Response> Xoa(tbl_CategoryModel requestModel);
        Task<tbl_CategoryModel> ChiTiet(tbl_CategoryModel requestModel);
        Task<List<tbl_CategoryModel>> DanhSachAll(tbl_CategoryModel requestModel);
        Task<tbl_CategoryModel> ChiTietChuyenMucBaiViet(tbl_CategoryModel requestModel);

    }
}
