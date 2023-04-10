using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS
{
    public interface IThungRacVaLogRepository
    {
        Task<BaseRespone<Log4NetLogModel>> DanhSachLog(Log4NetLogModel requestModel);
        Task<Log4NetLogModel> ChiTiet(Log4NetLogModel requestModel);
        Task<BaseRespone<tbl_PostModel>> DanhSachBaiDangXoa(tbl_PostModel requestModel);
        Task<Response> KhoiPhucBaiDang(tbl_PostModel requestModel);
        Task<BaseRespone<tbl_ThuVienAnhModel>> DanhSachThuVienAnhXoa(tbl_ThuVienAnhModel requestModel);
        Task<Response> KhoiPhucAnh(tbl_ThuVienAnhModel requestModel);
        Task<BaseRespone<tbl_ThuVienAudioModel>> DanhSachAudioXoa(tbl_ThuVienAudioModel requestModel);
        Task<Response> KhoiPhucAudio(tbl_ThuVienAudioModel requestModel);
        Task<BaseRespone<tbl_ThuVienVideoModel>> DanhSachVideoXoa(tbl_ThuVienVideoModel requestModel);
        Task<Response> KhoiPhucVideo(tbl_ThuVienVideoModel requestModel);
        Task<BaseRespone<tbl_VanBanModel>> DanhSachVanBanXoa(tbl_VanBanModel requestModel);
        Task<Response> KhoiPhucVanBan(tbl_VanBanModel requestModel);

    }
}
