using System;
using System.Configuration;

namespace Utilities
{
    public static class CommonConstants
    {
        public static string clientId = ConfigurationManager.AppSettings["is:ClientId"];
        public static string clientSecret = ConfigurationManager.AppSettings["is:ClientSecret"];
        public static string authenUrl = ConfigurationManager.AppSettings["is:AuthenUrl"];
        public static string redirectUri = ConfigurationManager.AppSettings["is:RedirectUri"];
        public static string MatKhauMacDinh = ConfigurationManager.AppSettings["MatKhauMacDinh"];
        public static string logoutRedirectUri = ConfigurationManager.AppSettings["is:LogoutRedirectUri"];
        public static string scope = ConfigurationManager.AppSettings["is:Scope"];
        public static string appdomain = ConfigurationManager.AppSettings["is:AppDomain"];
        public static string mainAppUrl = ConfigurationManager.AppSettings["is:MainAppUrl"];
        public static string Email = ConfigurationManager.AppSettings["Email"];
        public static string Password = ConfigurationManager.AppSettings["Password"];

        public static string TokenCache = "TokenCache" + clientId;
        public static string RoleCache = "RoleCache" + clientId;
        public static string MenuCache = "MenuCache" + clientId;
        public static string ButtonCache = "ButtonCache" + clientId;

        #region Messages
        public static string MSG_INFO_NOT_FOUND = "Không tìm thấy thông tin";
        public static string MSG_SAVE_SUCCESS = "Lưu thông tin thành công";
        public static string MSG_SAVE_FAILED = "Lưu thông tin thất bại";
        public static string MSG_CREATE_SUCCESS = "Thêm mới thành công";
        public static string MSG_CREATE_FAILED = "Thêm mới thất bại";
        public static string MSG_UPDATE_SUCCESS = "Cập nhật thành công";
        public static string MSG_UPDATE_FAILED = "Cập nhật thất bại";
        public static string MSG_DELETE_SUCCESS = "Xóa thành công";
        public static string MSG_DELETE_FAILED = "Xóa thất bại";
        public static string MSG_UPLOADFILE_SUCCESS = "Tải lên thành công";
        public static string MSG_UPLOADFILE_FAILED = "Tải lên thất bại";

        public static string MSG_LOGIN_SUCCESS = "Đăng nhập thành công";
        public static string MSG_LOGIN_FAILED = "Tài khoản hoặc mật khẩu đăng nhập không chính xác";
        public static string MSG_LOGIN_ERROR = "Đăng nhập thất bại";
        public static string MSG_LOGIN_EXITS = "Email đã được đăng ký";
        public static string MSG_LOGIN_CREATE = "Đăng ký thành công";
        public static string MSG_LOGIN_ACC_EXITS = "Tài khoản đã tồn tại";

        #endregion Messages

        #region Session Name
        public static string ERROR = "error";
        public static string SUCCESS = "success";
        #endregion Session Name


        public static string SessionAccountInfo = "SessionAccountInfo";
        public static string SessionAccountAdminInfo = "SessionAccountAdminInfo";
    }
}
