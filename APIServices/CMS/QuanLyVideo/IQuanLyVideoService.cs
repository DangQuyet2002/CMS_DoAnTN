using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IQuanLyVideoService
    {
       

        Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSach(tbl_ThuVienVideoModel requestModel);
        Task<Response> ThemMoi(tbl_ThuVienVideoModel requestModel);
        Task<Response> CapNhat(tbl_ThuVienVideoModel requestModel);
        Task<Response> Xoa(tbl_ThuVienVideoModel requestModel);
        Task<tbl_ThuVienVideoModel> ChiTiet(tbl_ThuVienVideoModel requestModel);
    }
}
