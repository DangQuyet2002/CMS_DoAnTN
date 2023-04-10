using System;
using System.Configuration;

namespace Utilities.Constants.CongGiangVien
{
    public static class CGVConstants
    {
        public static string clientId = ConfigurationManager.AppSettings["is:ClientId"];
        public static string clientSecret = ConfigurationManager.AppSettings["is:ClientSecret"];
        public static string authenUrl = ConfigurationManager.AppSettings["is:AuthenUrl"];
        public static string redirectUri = ConfigurationManager.AppSettings["is:RedirectUri"];
        public static string logoutRedirectUri = ConfigurationManager.AppSettings["is:LogoutRedirectUri"];
        public static string scope = ConfigurationManager.AppSettings["is:Scope"];
        public static string success = "success";
        public static string error = "error";
    }
}
