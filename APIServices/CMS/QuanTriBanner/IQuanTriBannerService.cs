using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS
{
    public interface IQuanTriBannerService
    {
        Task<BaseRespone<tbl_BannerModel>> DanhSach(tbl_BannerModel requestModel);
        Task<Response> ThemMoi(tbl_BannerModel requestModel);
        Task<Response> CapNhat(tbl_BannerModel requestModel);
        Task<Response> Xoa(tbl_BannerModel requestModel);
        Task<tbl_BannerModel> ChiTiet(tbl_BannerModel requestModel);

        Task<List<tbl_BannerModel>> DanhSachViTri(tbl_BannerModel requestModel);
        Task<BaseRespone<tbl_BannerModel>> DanhSachBannerDaGanViTri(tbl_BannerModel requestModel);
        Task<BaseRespone<tbl_BannerModel>> DanhSachBannerChuaGanViTri(tbl_BannerModel requestModel);
        Task<Response> ThemMoiViTri(tbl_BannerModel requestModel);
        Task<Response> XoaViTri(tbl_BannerModel requestModel);
        Task<Response> ThemLuotXem(tbl_BannerModel requestModel);
        Task<Response> CheckHienThiSilde(tbl_BannerModel requestModel);

    }
}
