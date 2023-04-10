using System;
using System.Collections.Generic;
using System.Configuration;

namespace Utilities.Constants.QuanLyDiem
{
    public static class QLDConstants
    {
        public static string _SessionAccountInfo = "_SessionAccountInfo";
        public static string _SessionLesson = "_SessionLesson";
        public static string _SessonMeetingModel = "_SessonMeetingModel";
        public static string _SessonListKhaoSat = "_SessonListKhaoSat";
        public static string SS_LIST_ACTION = "SS_LIST_ACTION";
        //Error Message
        public static string _CommonErrorMsg = "Lỗi hệ thống. Vui lòng thử lại sau.";
        //Role
        //public static int Quantri = 1;
        //public static int Sinhvien = 2;

        public static int Phong_DT_DH = 51;
        public static int Phong_DT_SDH = 49;
        public static int Phong_KT_DBCL = 47;

        public static int Admin = 0;
        public static int Khao_thi = 1;
        public static int Giao_vu_khoa = 2;
        public static int Giaovien = 3;
        public static int Phong_dao_tao = 4;
        public static int Thanh_tra = 5;

        public static int Thoi_gian_nhap_diem_tp = 7;
        public static int Thoi_gian_nhap_diem_thi = 14;
        public static int Thoi_gian_nhap_diem_tui_thi = 10;
        public static int Thoi_gian_nhap_in_phieu_diem = 14;
        public static string Ma_cb_khao_thi_admin = "1468";
        public static List<string> LIST_KY_HIEU_TU_DONG = new List<string>() { "I", "L", "K" };

        public static int IdDVNhapKyLuat = 35;
        //public static Workbook book = new Workbook();

        #region keyCaches
        public static string PLAN_ChuongTrinhDaoTaoChiTiet_KhauBai = "PLAN_ChuongTrinhDaoTaoChiTiet_KhauBai";
        public static string AllTaiLieuHocModel = "AllTaiLieuHocModel";
        public static string Get_BaiGiangTheoKhauBai = "Get_BaiGiangTheoKhauBai";
        public static string Get_BaiGiangbyID = "Get_BaiGiangbyID";
        public static string Get_Class = "Get_Class";
        public static string Get_BaiGiang_ForCheck = "Get_BaiGiang_ForCheck";
        public static string Get_STUList_byIDloptc = "Get_STUList_byIDloptc";
        public static string Get_LichHoc_byMacb = "Get_LichHoc_byMacb";
        public static string Get_TKB_byMacb = "Get_TKB_byMacb";
  
        #endregion
        public enum LoaiSuKien
        {
            Them = 0,
            Sua = 1,
            Xoa = 2,
        }

        public enum PhanHe
        {
            ESSPortal = 8
        }
        public enum LoaiDeXuatMoKhoaDiem
        {
            Mo_nhap_diem_thanh_phan = 1,
            Mo_nhap_diem_thi = 2,
            Mo_nhap_diem_tui_thi = 3,
            Mo_nhap_diem_phong_thi = 4
        }
        public enum LoaiKhaoSatDanhGia
        {
            DamBaoChatLuong = 4
        }
        public enum LoaiDanhGia306
        {
            DanhGiaDongNghiep = 3
        }
    }
}
