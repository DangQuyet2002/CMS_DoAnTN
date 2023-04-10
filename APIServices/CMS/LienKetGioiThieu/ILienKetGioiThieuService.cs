using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface ILienKetGioiThieuService
    {
        Task<BaseRespone<tbl_LienKetGioiThieuModel>> DanhSach(tbl_LienKetGioiThieuModel requestModel);
        Task<Response> ThemMoi(tbl_LienKetGioiThieuModel requestModel);
        Task<Response> CapNhat(tbl_LienKetGioiThieuModel requestModel);
        Task<Response> Xoa(tbl_LienKetGioiThieuModel requestModel);
        Task<tbl_LienKetGioiThieuModel> ChiTiet(tbl_LienKetGioiThieuModel requestModel);
        Task<Response> CapNhatSTT(tbl_LienKetGioiThieuModel requestModel);
    }
}
