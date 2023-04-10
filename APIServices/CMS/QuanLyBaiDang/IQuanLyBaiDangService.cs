using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IQuanLyBaiDangService
    {
        Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangPV(tbl_PostModel requestModel);
        Task<Response> ThemMoi(tbl_PostModel requestModel);
        Task<Response> CapNhat(tbl_PostModel requestModel);
        Task<Response> Xoa(tbl_PostModel requestModel);
        Task<tbl_PostModel> ChiTiet(tbl_PostModel requestModel);
        Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangBTV(tbl_PostModel requestModel);
        Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangTKGD(tbl_PostModel requestModel);
        Task<Response> IsXuatBanBaiBao(tbl_PostModel requestModel);

        Task<Response> IsPVDuyetHuyDuyet(tbl_PostModel requestModel);
        Task<Response> IsBTVDuyetHuyDuyet(tbl_PostModel requestModel);
        Task<Response> IsTK_GDDuyetHuyDuyet(tbl_PostModel requestModel);
        Task<Response> IsTK_GDTraLai(tbl_PostModel requestModel);
        Task<Response> TinTucMoi(tbl_PostModel requestModel);
        Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangMoi(tbl_PostModel requestModel);
        Task<Response> CapNhatLuotXem(tbl_PostModel requestModel);
        Task<List<tbl_CommentModel>> DanhSachBinhLuan(tbl_CommentModel requestModel);
        Task<Response> ThemMoiBinhLuan(tbl_CommentModel requestModel);
        Task<Response> ThemMoiLike(tbl_LikePostModel requestModel);
        Task<List<tbl_LikePostModel>> ChiTietLike(tbl_LikePostModel requestModel);
        Task<Response> XoaLike(tbl_LikePostModel requestModel);
        Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangCungChuyenMuc(tbl_PostModel requestModel);
        Task<Response> DuyetAdmin(tbl_PostModel requestModel);


    }
}
