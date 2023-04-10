using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface ICacCapHoiService
    {


        Task<BaseRespone<tbl_CacCapHoiModel>> DanhSach(tbl_CacCapHoiModel requestModel);
        Task<Response> ThemMoi(tbl_CacCapHoiModel requestModel);
        Task<Response> CapNhat(tbl_CacCapHoiModel requestModel);
        Task<Response> Xoa(tbl_CacCapHoiModel requestModel);
        Task<tbl_CacCapHoiModel> ChiTiet(tbl_CacCapHoiModel requestModel);
        Task<Response> CapNhatSTT(tbl_CacCapHoiModel requestModel);

    }
}
