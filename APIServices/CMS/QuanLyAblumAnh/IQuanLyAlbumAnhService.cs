using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IQuanLyAlbumAnhService
    {
        Task<BaseRespone<tbl_ThuVienAnhModel>> DanhSach(tbl_ThuVienAnhModel requestModel);
        Task<Response> ThemMoi(tbl_ThuVienAnhModel requestModel);
        Task<Response> CapNhat(tbl_ThuVienAnhModel requestModel);
        Task<Response> Xoa(tbl_ThuVienAnhModel requestModel);
        Task<Response> XoaChiTiet(tbl_ThuVienAnhModel requestModel);
        Task<tbl_ThuVienAnhModel> ChiTiet(tbl_ThuVienAnhModel requestModel);
    }
}
