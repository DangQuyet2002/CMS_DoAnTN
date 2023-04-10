using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IQuanLyChiHoiRepository
    {
        Task<List<tbl_ChiHoiTTModel>> DanhSach(tbl_ChiHoiTTModel requestModel);
        Task<Response> ThemMoi(tbl_ChiHoiTTModel requestModel);
        Task<Response> CapNhat(tbl_ChiHoiTTModel requestModel);
        Task<Response> Xoa(tbl_ChiHoiTTModel requestModel);
        Task<tbl_ChiHoiTTModel> ChiTiet(tbl_ChiHoiTTModel requestModel);
    }
}
