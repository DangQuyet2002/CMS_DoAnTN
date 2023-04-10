using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IQuanLyVideoRepository
    {
        Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSach(tbl_ThuVienVideoModel requestModel);
        Task<Response> ThemMoi(tbl_ThuVienVideoModel requestModel);
        Task<Response> CapNhat(tbl_ThuVienVideoModel requestModel);
        Task<Response> Xoa(tbl_ThuVienVideoModel requestModel);
        Task<tbl_ThuVienVideoModel> ChiTiet(tbl_ThuVienVideoModel requestModel);
    }
}
