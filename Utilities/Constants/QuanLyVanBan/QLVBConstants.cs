using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Constants.QuanLyVanBan
{
    public static class QLVBConstants
    {
        public const string SuperAdminUsername = "admax";
        public const string SuperAdminPassword = "123";
        public const string SuperAdminFullName = "Super Admin";
        public static string SessionAccountInfo = "SessionAccountInfo";

        public static string FolderFileTemp = @"FileUpload\tmp";
        public static string FolderTrinhKyFile = @"FileUpload\TrinhKy";
        public static string FolderVanBanFile = @"FileUpload\VanBan";
        public static string FolderCongViecFile = @"FileUpload\CongViec";
        public static string FolderCongViecXuLyFile = @"FileUpload\CongViecXuLy";
        public static string TypeSuccess = "success";
        public static string TypeError = "error";

        public static int TrangThaiTrinhKyTaoMoi = 0;
        public static int TrangThaiLichTaoMoi = 0;

        public static int TrangThaiChoDuyet = 0;
        public static int TrangThaiDaDuyet = 1;
        public static int TrangThaiTuChoi = 2;

        public static int GroupChuyenVien = 1;
        public static int GroupTruongPhong = 2;
        public static int GroupVanPhong = 3;
        public static int GroupChanhVanPhong = 4;
        public static int GroupGiamHieu = 5;
        public static int GroupVanThu = 6;
        public static int GroupAdmin = 7;

        #region Trạng thái văn bản
        public const int VanBanChoTiepNhan = 1;
        public const int VanBanTuChoi = 2;
        public const int VanBanLuuTru = 3;
        public const int VanBanChoButPhe = 4;
        public const int VanBanDangXuLy = 5;
        public const int VanBanDaXuLy = 6;
        public const int VanBanPhatHanh = 7;
        public const int VanBanDaGui = 8;
        #endregion

        #region Trạng thái trình kí
        public const int TrinhKi = 1;
        public const int TrinhKiTruongPhongDuyet = 2;
        public const int TrinhKiTruongPhongTuChoi = 3;
        public const int TrinhKiChanhVanPhongDuyet = 4;
        public const int TrinhKiChanhVanPhongTuChoi = 5;
        public const int TrinhKiLanhDaoDuyet = 6;
        public const int TrinhKiLanhDaoTuChoi = 7;
        public const int TrinhKiVanThuPhatHanh = 8;
        #endregion

        #region Loại văn bản
        public const int VanBan_Loai_Den = 0;
        public const int VanBan_Loai_Di = 1;
        public const int VanBan_HienThi = 1;
        public const int VanBan_KoHienThi = 0;
        #endregion

        #region Trình ký file
        public const int TrinhKyFile_FileDinhKem = 0;
        public const int TrinhKyFile_FileTuChoi = 1;
        public const int TrinhKyFile_FileKy = 2;
        #endregion

        #region Trạng thái văn bản phân phối, gửi
        public const int VanBan_DaPhanPhoi = 1;
        public const int VanBan_ChưaPhanPhoi = 0;
        public const int VanBan_DaGui = 1;
        public const int VanBan_ChuaGui = 0;
        #endregion

        #region Trạng thái văn bản phân phối
        public const int VanBan_PhanPhoiUser = 1;
        public const int VanBan_PhanPhoiPhongBan = 2;
        #endregion

        #region Phân loại công viêc
        public const int PhanLoaiCV_ButPhe = 1;
        public const int PhanLoaiCV_ViecPhatSinh = 2;
        public const int PhanLoaiCV_ChuyenTiep = 3;
        #endregion

        #region Trạng thái công việc
        public const int CongViec_ChuaXuLy = 1;
        public const int CongViec_DangXuLy = 2;
        public const int CôngViec_DaXuLy = 3;
        public const int CongViec_KhongXuLy = 4;
        public const int CongViec_DaHuy = 5;
        #endregion
        #region Trạng thái lịch
        public const int Lich_TruongPhongDuyet = 2;
        public const int Lich_TruongPhongTuChoi = 3;
        public const int Lich_VanPhongDuyet = 4;
        public const int Lich_VanPhongTuChoi = 5;
        public const int Lich_ChanhVanPhongDuyet = 6;
        public const int Lich_ChanhVanPhongTuChoi = 7;
        public const int Lich_LanhDaoDuyet = 8;
        public const int Lich_LanhDaoTuChoi = 9;
        public const int Lich_VanThuPhatHanh = 10;
        public const int Lich_VanThuTuChoi = 10;
        #endregion

    }
}
