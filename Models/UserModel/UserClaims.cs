using System;
using System.Collections.Generic;

namespace Models
{
    public class UserClaims
    {
        public string sub { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string preferred_username { get; set; } //UserName
        public string access_token { get; set; }
        public string expires_at { get; set; }
        public string roles { get; set; }
        public string Ho_ten { get; set; }
        public string UserId { get; set; }
        public int ID_dv { get; set; }
        public string IP { get; set; }

    }

    public class HR_LyLichModel
    {
        public int ID { get; set; }

        public bool isAdmin { get; set; }

        public string ID_cb { get; set; }

        public string Ma_so { get; set; }

        public string Ma_cb { get; set; }

        public string Ho_ten { get; set; }

        public string Bi_danh { get; set; }

        public DateTime? Ngay_sinh { get; set; }

        public int STU_GioiTinh_ID { get; set; }

        public int DM_QUOCTICH_ID { get; set; }

        public int STU_DanToc_ID { get; set; }

        public int DM_TonGiao_ID { get; set; }

        public string Xuat_than { get; set; }

        public string Dien_thoai { get; set; }

        public string Email { get; set; }

        public string Dia_chi_NS { get; set; }

        public int HR_DM_Xa_NS_ID { get; set; }

        public int HR_DM_Huyen_NS_ID { get; set; }

        public int HR_DM_Tinh_NS_ID { get; set; }

        public string Dia_chi_TT { get; set; }

        public int HR_DM_Xa_TT_ID { get; set; }

        public int HR_DM_Huyen_TT_ID { get; set; }

        public int HR_DM_Tinh_TT_ID { get; set; }

        public string Dia_chi_QQ { get; set; }

        public int HR_DM_Xa_QQ_ID { get; set; }

        public int HR_DM_Huyen_QQ_ID { get; set; }

        public int HR_DM_Tinh_QQ_ID { get; set; }

        public string Dia_chi_NoiO { get; set; }

        public int HR_DM_Xa_NoiO_ID { get; set; }

        public int HR_DM_Huyen_NoiO_ID { get; set; }

        public int HR_DM_Tinh_NoiO_ID { get; set; }

        public string So_ho_chieu { get; set; }

        public string So_CMND { get; set; }

        public DateTime? Ngay_cap { get; set; }

        public string Noi_cap_text { get; set; }

        public int STU_Tinh_CMND_ID { get; set; }

        public bool isDoanVien { get; set; }

        public DateTime? Ngay_vao_doan { get; set; }

        public int DM_CHUCVU_DOAN_ID { get; set; }

        public bool isDangVien { get; set; }

        public DateTime? Ngay_vao_dang { get; set; }

        public DateTime? Ngay_vao_dang_chinh { get; set; }

        public int DM_CHUCVU_DANG_ID { get; set; }

        public string Nhan_xet { get; set; }

        public int ID_dv { get; set; }

        public string Mat_khau { get; set; }

        public bool isActive { get; set; }

        public int DM_CHUCVU_CONGDOAN_ID { get; set; }

        public int DM_NGANHANG_ID { get; set; }

        public string So_tai_khoan { get; set; }

        public bool isDuocNopBHXH { get; set; }

        public string So_so_BHXH { get; set; }

        public DateTime? Ngay_cap_so_BHXH { get; set; }

        public string Kinh_nghiem { get; set; }

        public string Co_quan_cong_tac_cu { get; set; }

        public string Nghe_nghiep_cong_tac_cu { get; set; }

        public DateTime? Ngay_tham_gia_TCCTXH { get; set; }

        public string To_chuc_CTXH { get; set; }

        public int DM_HOCVI_ID { get; set; }

        public string Khen_thuong { get; set; }

        public string Ky_luat { get; set; }

        public bool isCongChuc { get; set; }

        public bool isVienChuc { get; set; }

        public bool isHopDongLaoDong { get; set; }

        public int PLAN_GiaoVien_ID { get; set; }

        public string Nhom_mau { get; set; }

        public string Anh_Filename { get; set; }

        public string CV_FileName { get; set; }

        public int HR_DM_ChucVu_ID { get; set; }

        public int HR_DM_LOAICANBO_ID { get; set; }

        public string Chuc_vu_chinh_quyen { get; set; }

        public DateTime? Ngay_bo_nhiem_chuc_vu_chinh_quyen { get; set; }

        public DateTime? Ngay_tuyen_dung_vao_co_quan_NN { get; set; }

        public string Co_quan_tuyen_dung { get; set; }

        public string Hinh_thuc_tuyen_dung { get; set; }

        public DateTime? Ngay_chuyen_ve_truong { get; set; }

        public string Thuong_binh_loai { get; set; }

        public string Trinh_do_van_hoa { get; set; }

        public int Trinh_do_dao_tao { get; set; }

        public string Chuyen_nganh { get; set; }

        public int Ly_luan_chinh_tri { get; set; }

        public string Quan_ly_hanh_chinh_NN { get; set; }

        public int ID_trinh_do_ngoai_ngu { get; set; }

        public string Ngoai_ngu { get; set; }

        public string Tin_hoc { get; set; }

        public string Boi_duong_khac { get; set; }

        public string Suc_khoe { get; set; }

        public string Chieu_cao { get; set; }

        public string Can_nang { get; set; }

        public int ID_chuc_danh { get; set; }

        public int ID_trinh_do { get; set; }

        public string Ngach_cong_chuc { get; set; }

        public string Loai_cong_chuc { get; set; }

        public string Bac_luong { get; set; }

        public double He_so_luong { get; set; }

        public DateTime? Huong_tu_ngay { get; set; }

        public DateTime? Moc_tinh_nang_luong_lan_sau { get; set; }

        public int PT_PC_thamnien_vuotkhung { get; set; }

        public int PT_PC_kiemnghiem { get; set; }

        public double HSPC_vuotkhung { get; set; }

        public int PT_PC_dacbiet { get; set; }

        public int PT_PC_thuhut { get; set; }

        public double HSPC_luudong { get; set; }

        public double HSPC_dochai { get; set; }

        public int PT_PC_dacthu { get; set; }

        public int PT_PC_uudai { get; set; }

        public double HSPC_trachnhiem { get; set; }

        public double HSPC_khac { get; set; }

        public DateTime? Ngay_bat_dau_dong_BHXH { get; set; }

        public int So_thang_da_dong_BHXH { get; set; }

        public int Tinh_trang_hon_nhan { get; set; }

        public string Gia_dinh_thuoc_dien_uu_tien { get; set; }

        public DateTime? Ngay_hop_dong { get; set; }

        public string Cong_viec_duoc_giao { get; set; }

        public string Cong_viec_hien_nay { get; set; }

        public bool Dang_nghi_bhxh { get; set; }

        public DateTime? Ngay_vao_nganh_gd { get; set; }

        public double Hs_phu_cap_chuc_vu { get; set; }

        public DateTime? Ngay_bo_nhiem_chuc_vu_hien_tai { get; set; }

        public string Chuc_vu_chinh_quyen_kiem_nhiem { get; set; }

        public string Chuc_vu_chinh_quyen_cao_nhat_da_qua { get; set; }

        public string Dang_theo_hoc { get; set; }

        public string Dien_uu_tien_ban_than { get; set; }

        public bool Tot_nghiep_THPT { get; set; }

        public bool Tot_nghiep_THCS { get; set; }

        public int Hoc_het_lop { get; set; }

        public int So_nam_he { get; set; }

        public string Noi_dao_tao { get; set; }

        public string Hinh_thuc_dao_tao { get; set; }

        public int Nam_tot_nghiep { get; set; }

        public string TD_QLGD { get; set; }

        public int Nam_cong_nhan { get; set; }

        public string Danh_hieu_duong_phong_cao_nhat { get; set; }

        public string Nghe_nghiep_tuyen_dung { get; set; }

        public int ID_chuc_danh_hien_tai { get; set; }

        public int ID_chuc_danh_kiem_nghiem { get; set; }

        public int ID_chuc_danh_nghe_nghiep { get; set; }

        public int ID_trinh_do_nghiep_vu { get; set; }

        public DateTime? Ngay_nhap_ngu { get; set; }

        public DateTime? Ngay_xuat_ngu { get; set; }

        public int DM_QUANHAM_ID { get; set; }

        public int DM_HOCHAM_ID { get; set; }

        public string So_truong_cong_tac { get; set; }

        public string Khai_ro_bi_bat_bi_tu { get; set; }

        public string Co_lam_viec_trong_che_do_cu { get; set; }

        public string Tham_gia_to_chuc_nuoc_ngoai { get; set; }

        public string Co_than_nhan_nuoc_ngoai { get; set; }

        public string Nguon_thu_luong { get; set; }

        public string Nguon_thu_nhap_khac { get; set; }

        public string Loai_nha_o_duoc_cap { get; set; }

        public string Dien_tich_nha_o_duoc_cap { get; set; }

        public string Loai_nha_o_tu_mua { get; set; }

        public string Dien_tich_nha_o_tu_mua { get; set; }

        public string Dien_tich_dat_duoc_cap { get; set; }

        public string Dien_tich_dat_tu_mua { get; set; }

        public string Dat_sx_kinh_doanh { get; set; }

        public string Cap_uy_hien_tai { get; set; }

        public string Cap_uy_kiem { get; set; }

        public string Dia_chi_co_quan_tuyen_dung { get; set; }

        public DateTime? Ngay_vao_co_quan_hien_tai { get; set; }

        public DateTime? Ngay_tham_gia_cach_mang { get; set; }

        public string Cong_viec_da_lam_lau_nhat { get; set; }

        public bool isNgoaiTruong { get; set; }

        public string Co_quan_cong_tac_ngoai_truong { get; set; }
        public string NormalizedUserName { get; set; }
        public bool IsLocked { get; set; }
    }

    public class TreeNguoiDungModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string TaiKhoan { get; set; }
        public string type { get; set; }
        public lstState state { get; set; }
        public List<TreeNguoiDungModel> children { get; set; } = new List<TreeNguoiDungModel>();
        public bool IsLazyLoading { get; set; }
    }
}