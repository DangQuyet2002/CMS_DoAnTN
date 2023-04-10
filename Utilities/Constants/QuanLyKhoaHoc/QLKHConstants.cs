using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class QLKHConstants
    {
        public static string clientId = ConfigurationManager.AppSettings["is:ClientId"];
        public static string clientSecret = ConfigurationManager.AppSettings["is:ClientSecret"];
        public static string authenUrl = ConfigurationManager.AppSettings["is:AuthenUrl"];
        public static string redirectUri = ConfigurationManager.AppSettings["is:RedirectUri"];
        public static string logoutRedirectUri = ConfigurationManager.AppSettings["is:LogoutRedirectUri"];
        public static string scope = ConfigurationManager.AppSettings["is:Scope"];

        #region Session Name
        public static string ERROR = "error";
        public static string SUCCESS = "success";
        #endregion Session Name

        #region Session Name
        public static string USER_INFO = "USER_INFO";
        #endregion Session Name

        #region Messages
        public static string MSG_ERR_INFO_NOT_FOUND = "Không tìm thấy thông tin";
        public static string MSG_ERR_SAVE_SUCCESS = "Lưu thông tin thành công";
        public static string MSG_ERR_SAVE_FAILED = "Lưu thông tin thất bại";
        public static string MSG_ERR_CREATE_SUCCESS = "Thêm mới thành công";
        public static string MSG_ERR_CREATE_FAILED = "Thêm mới thất bại";
        public static string MSG_ERR_UPDATE_SUCCESS = "Cập nhật thành công";
        public static string MSG_ERR_UPDATE_FAILED = "Cập nhật thất bại";
        public static string MSG_ERR_DELETE_SUCCESS = "Xóa thành công";
        public static string MSG_ERR_DELETE_FAILED = "Xóa thất bại";

        public static string MSG_LOGIN_SUCCESS = "Đăng nhập thành công";
        public static string MSG_LOGIN_FAILED = "Tài khoản hoặc mật khẩu đăng nhập không chính xác";
        #endregion Messages
        
        #region Path
        public static string UPLOAD_DIR = "~/FileUploaded/";
        public static string AVATAR_DIR = "~/FileUploaded/Avatar/";
        public static string TEMPLATE_DIR = "~/ExportTemplate/";
        #endregion Path

        #region Common
        public static string ROMAN_NUMERALS = "I,II,III,IV,V,VI,VII,VIII,IX,X";
        #endregion Common

        #region Templates
        public static string TEMP_LYLICHKHOAHOC = $"{TEMPLATE_DIR}LyLichKhoaHoc.docx";
        public static string TEMP_THONGKEBAIBAO = $"{TEMPLATE_DIR}TempThongKeBaiBao.xlsx";
        public static string TEMP_THONGKEBAOCAOHNHT = $"{TEMPLATE_DIR}TempThongKeBaoCaoHNHT.xlsx";
        public static string TEMP_THONGKESACHTAILIEU = $"{TEMPLATE_DIR}TempThongKeSachTaiLieu.xlsx";
        public static string TEMP_THONGKEDETAI = $"{TEMPLATE_DIR}TempThongKeDeTai.xlsx";
        public static string TEMP_THONGKEDETAISINHVIEN = $"{TEMPLATE_DIR}TempThongKeDeTaiSinhVien.xlsx";
        public static string TEMP_THONGKEDEXUATDETAISINHVIEN = $"{TEMPLATE_DIR}TempThongKeDeXuatDeTaiSinhVien.xlsx";
        public static string TEMP_DANHSACHGIAITHUONGCANBO = $"{TEMPLATE_DIR}TempDSGiaiThuongCanBo.xlsx";
        public static string TEMP_TONGHOPDEXUATDETAI = $"{TEMPLATE_DIR}TempTongHopDeXuatDeTai.xlsx";
        public static string TEMP_TONGHOPTHUYETMINH = $"{TEMPLATE_DIR}TempTongHopThuyetMinh.xlsx";
        public static string TEMP_TONGHOPNHIEMVUKHCN = $"{TEMPLATE_DIR}TempTongHopNhiemVuKHCN.xlsx";
        public static string TEMP_TONGHOPNHIEMVUKHCNQUYETTOAN = $"{TEMPLATE_DIR}TempTongHopNhiemVuKHCNQuyetToan.xlsx";
        public static string TEMP_TONGHOPNHIEMVUKHCNTAMUNG = $"{TEMPLATE_DIR}TempTongHopNhiemVuKHCNTamUng.xlsx";
        public static string TEMP_BAOCAOTIENDODETAI = $"{TEMPLATE_DIR}TempBaoCaoTienDoDeTai.xlsx";
        public static string TEMP_GIONCKHCANHAN = $"{TEMPLATE_DIR}TempGioNCKHCaNhan.xlsx";
        public static string TEMP_GIONCKHDONVI = $"{TEMPLATE_DIR}TempGioNCKHDonVi.xlsx";
        public static string TEMP_THONGKESOHUUTRITUE = $"{TEMPLATE_DIR}TempThongKeSoHuuTriTue.xlsx";
        public static string TEMP_TONGHOPDANGKYSANGKIENCOSODV = $"{TEMPLATE_DIR}TempTongHopDangKySangKienCoSoDonVi.xlsx";
        #endregion Templates

        #region Log Action
        public static string LOG_CREATE = "create";
        public static string LOG_UPDATE = "update";
        public static string LOG_DELETE = "delete";
        #endregion Log Action
    }
}
