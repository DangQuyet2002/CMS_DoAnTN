using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IQuanLyAudioRepository
    {
        Task<BaseRespone<tbl_ThuVienAudioModel>> DanhSach(tbl_ThuVienAudioModel requestModel);
        Task<Response> ThemMoi(tbl_ThuVienAudioModel requestModel);
        Task<Response> CapNhat(tbl_ThuVienAudioModel requestModel);
        Task<Response> Xoa(tbl_ThuVienAudioModel requestModel);
        Task<tbl_ThuVienAudioModel> ChiTiet(tbl_ThuVienAudioModel requestModel);
    }
}
