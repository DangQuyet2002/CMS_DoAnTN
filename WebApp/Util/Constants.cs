using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Models;

namespace WebApp
{
    public class Constants
    {
        /// <summary>
        /// Vị trí xuất hiện banner
        /// </summary>
        public static int BSo1TrangChu = 1;
        public static int BSo2TrangChuBT = 2;
        public static int BSo2TrangChuBP = 7;
        public static int BSo1BenPhai = 3;
        public static int BSo2BenPhai = 4;
        public static int BSo1BenPhaiTC = 5;
        public static int BSo2BenTraiTC = 6;

        /// <summary>
        /// Vị trí xuất hiện của chuyên mục
        /// </summary>
        public static int M_TopMenu = 1;
        public static int M_CMDuoiTinTucMoi = 2;
        public static int M_CM1BenPhai = 3;
        public static int M_CM2BenPhai = 4;
        public static int M_CMBenPhai_CT = 5;
        public static int M_CMBannerMedia = 6;
        public static int M_CMDuoiBannerMedia = 7;
        /// <summary>
        /// Chuyên de banner 1- Trang chủ, 2- Chuyên đề
        /// </summary>
        public static List<tbl_CategoryModel> LstChuyenDe = new List<tbl_CategoryModel>()
        {
            new tbl_CategoryModel(){ ID = 1, Name="Trang chủ"},
            new tbl_CategoryModel(){ ID = 2, Name="Trang chuyên đề"}
        };


        /// <summary>
        /// Tên session
        /// </summary>
        public static string SSUserLogIn = "UserLogIn";
        public static string SSMenu = "SSMenu";
        public static string SSMenuAdmin = "SSMenuAdmin";

        public static string SSUserInforKH = "SSUserInforKH";

        /// <summary>
        /// Loai chuyen muc
        /// </summary>
        public static int LoaiChuyenMucKhac = 5;
        public static int LoaiChuyenVanBan = 6;
        /// <summary>
        /// Quyen Admin
        /// </summary>
        public static int QuyenAdmin = 1;
    }
}