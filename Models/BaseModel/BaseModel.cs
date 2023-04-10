using System;
using System.Collections.Generic;

namespace Models
{
    public class BaseGuidModel
    {
        public int Stt { get; set; }
        public Guid? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
    }

    public class BaseModel
    {
        public int start { get; set; }
        public int length { get; set; }
        public string FullName { get; set; }
        //public string IP { get; set; }
        //public int UserId { get; set; }

    }

    public class BasePaging
    {
        public int Total { get; set; }
    }

    public class BaseRequest
    {
        public string Keywords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public int? Status { get; set; }
        public string UpdateBy { get; set; }
    }

    public class BaseModelPhanQuyen
    {
        public int start { get; set; }
        public int length { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateByName { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int Status { get; set; }
        public string ModelContent { get; set; }
        public int STT { get; set; }
        public string CreatedDateString
        {
            get
            {
                if (CreatedDate != null)
                    return string.Format("{0:dd/MM/yyyy}", CreatedDate);
                else
                    return string.Empty;
            }
            set
            {
            }
        }

        public string UpdateDateString
        {
            get
            {
                if (UpdateDate != null)
                    return string.Format("{0:dd/MM/yyyy}", UpdateDate);
                else
                    return string.Empty;
            }
            set
            {
            }
        }
    }

    public class TreeModel
    {
        public string IdNode { get; set; }
    }

    public class HRLyLich : BaseModel
    {
        public HRLyLich()
        { }

        public HRLyLich(UserClaims claims)
        {
            this.ID_cb = claims.sub;
            this.Ho_ten = claims.name;
            this.Ma_cb = claims.preferred_username;
            this.RoleCode = Convert.ToInt32(claims.roles);
        }

        public bool isAdmin { get; set; }
        public string ID_cb { get; set; }
        public string Ma_so { get; set; }
        public string Ma_cb { get; set; }
        public string Ho_ten { get; set; }
        public string Bi_danh { get; set; }
        public DateTime Ngay_sinh { get; set; }
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
        public DateTime Ngay_cap { get; set; }
        public string Noi_cap_text { get; set; }
        public int STU_Tinh_CMND_ID { get; set; }
        public bool isDoanVien { get; set; }
        public DateTime Ngay_vao_doan { get; set; }
        public int DM_CHUCVU_DOAN_ID { get; set; }
        public bool isDangVien { get; set; }
        public DateTime Ngay_vao_dang { get; set; }
        public DateTime Ngay_vao_dang_chinh { get; set; }
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
        public DateTime Ngay_cap_so_BHXH { get; set; }
        public string Kinh_nghiem { get; set; }
        public string Co_quan_cong_tac_cu { get; set; }
        public string Nghe_nghiep_cong_tac_cu { get; set; }
        public DateTime Ngay_tham_gia_TCCTXH { get; set; }
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
        public DateTime Ngay_bo_nhiem_chuc_vu_chinh_quyen { get; set; }
        public DateTime Ngay_tuyen_dung_vao_co_quan_NN { get; set; }
        public string Co_quan_tuyen_dung { get; set; }
        public string Hinh_thuc_tuyen_dung { get; set; }
        public DateTime Ngay_chuyen_ve_truong { get; set; }
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
        public DateTime Huong_tu_ngay { get; set; }
        public DateTime Moc_tinh_nang_luong_lan_sau { get; set; }
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
        public DateTime Ngay_bat_dau_dong_BHXH { get; set; }
        public int So_thang_da_dong_BHXH { get; set; }
        public int Tinh_trang_hon_nhan { get; set; }
        public string Gia_dinh_thuoc_dien_uu_tien { get; set; }
        public DateTime Ngay_hop_dong { get; set; }
        public string Cong_viec_duoc_giao { get; set; }
        public string Cong_viec_hien_nay { get; set; }
        public bool Dang_nghi_bhxh { get; set; }
        public DateTime Ngay_vao_nganh_gd { get; set; }
        public double Hs_phu_cap_chuc_vu { get; set; }
        public DateTime Ngay_bo_nhiem_chuc_vu_hien_tai { get; set; }
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
        public DateTime Ngay_nhap_ngu { get; set; }
        public DateTime Ngay_xuat_ngu { get; set; }
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
        public DateTime Ngay_vao_co_quan_hien_tai { get; set; }
        public DateTime Ngay_tham_gia_cach_mang { get; set; }
        public string Cong_viec_da_lam_lau_nhat { get; set; }
        public bool isNgoaiTruong { get; set; }
        public string Co_quan_cong_tac_ngoai_truong { get; set; }
        public int HR_DM_TRANGTHAI_CANBO_ID { get; set; }
        public bool ischuyenmonyduoc { get; set; }
        public bool ischuyenmoncntt { get; set; }
        public bool ischuyenmonbacsi { get; set; }
        public bool ischuyenmonkinhteketoan { get; set; }
        public string date_thamgiacongtac { get; set; }
        public bool istruongphong { get; set; }
        public bool isphophong { get; set; }
        public bool islanhdao { get; set; }
        public bool isvitrilanhdaohet5nam { get; set; }
        public bool islanhdaogiaonhiemvu { get; set; }
        public string chucvunhiemvu { get; set; }
        public string Hang_vien_chuc { get; set; }
        public bool isGiangVienChinh { get; set; }
        public bool isGiangVienCaoCap { get; set; }
        public string thoigianbonhiem { get; set; }
        public string chucvudonvicongtac { get; set; }
        public string Noi_congnhan_cao_nhat { get; set; }
        public bool isNghiHuu { get; set; }
        public bool isNghiepVuSuPham { get; set; }
        public string Trinh_do_chuyen_mon_cao_nhat { get; set; }
        public bool ischuyenmonxetnghiem { get; set; }
        public bool isCanBoHopDong { get; set; }
        public DateTime Time_congtac_trong_nganhgiaoduc { get; set; }
        public DateTime Time_cong_tac_tai_truong { get; set; }
        public string Noi_sinh { get; set; }
        public DateTime Date_TrangThai_cb { get; set; }
        public string Chuyen_mon_dao_tao { get; set; }
        public string Ma_so_thue { get; set; }
        public DateTime Date_NghiHuu { get; set; }
        public int DM_LinhVuc_ID { get; set; }
        public int CoChungChiHanhNghe { get; set; }
        public string ThoiGianLamViec { get; set; }
        public int ID_ngan_hang { get; set; }
        public string Chi_nhanh_ngan_hang { get; set; }
        public string Phong_giao_dich_ngan_hang { get; set; }
        public DateTime Ngay_tuyen_dung { get; set; }
        public string So_the_dang { get; set; }
        public string So_BHYT { get; set; }
        public string Noi_cap_BHXH { get; set; }
        public DateTime Ngay_nghi_huu { get; set; }
        public DateTime Ngay_nghi_viec { get; set; }
        public DateTime Ngay_chuyen_cong_tac { get; set; }
        public DateTime Ngay_tu_tran { get; set; }
        public string Lich_su_ban_than { get; set; }
        public string Nhan_xet_danh_gia { get; set; }
        public int Status { get; set; }
        public int IDDonViKiemNhiem { get; set; }
        public bool isKiemNhiemNoiKhac { get; set; }
        public int ChucVuCongTacHienTaiID { get; set; }
        public int ChucVuKiemNhiemID { get; set; }
        public string TenVietTat
        {
            get; set;
        }

        #region extend properties
        public string TinhNoiO { get; set; }
        public string HuyenNoiO { get; set; }
        public string XaNoiO { get; set; }
        public string XaNS { get; set; }
        public string HuyenNS { get; set; }
        public string TinhNS { get; set; }
        public string XaQQ { get; set; }
        public string HuyenQQ { get; set; }
        public string TinhQQ { get; set; }
        public string XaTT { get; set; }
        public string HuyenTT { get; set; }
        public string TinhTT { get; set; }

        public string Gioi_tinh { get; set; }
        public string Ten_dv { get; set; }
        public string TenChucDanhHienTai { get; set; }
        public string TenChucDanhKiemNhiem { get; set; }
        public string Hoc_vi { get; set; }
        public string Hoc_ham { get; set; }
        public string Dan_toc { get; set; }
        public string Ton_giao { get; set; }
        public string TenChucVuHienTai { get; set; }
        public string TenChucVuKiemNhiem { get; set; }
        public string Bo_mon { get; set; }
        public string Ten_ngan_hang { get; set; }
        public int RoleCode { get; set; }
        public string RoleName { get; set; }

        #endregion extend properties
    }

    public class BaseRespone<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int recordsTotal { get; set; } = 0;
    }
    public class Response
    {
        public string code { get; set; }
        public string message { get; set; }
        public object result { get; set; }
        public int recordsTotal { get; set; }
        public string icon { get; set; }


    }

    public static class ResponseCode
    {
        //Reponse code tu api tra ve
        public const string SUCCESS = "0000";//Thành Công

        public const string SYSTEM_ERROR = "0001";//Lỗi hệ thống
        public const string UNKNOWN_ERROR = "0999";//Lỗi không xác định
        public const string UPDATE_ERROR = "0666";//Cập nhật không thành công
        public const string DATA_NOTDELETE = "0667";//Dữ liệu không thể xóa
        public const string INPUTDATA_ERROR = "0668";//Dữ liệu đầu vào không chính xác
        public const string OLDPASSWORD_ERROR = "0669";//Mật khẩu cũ không chính xác
        public const string USER_DELETED = "0700";//Tài khoản đã bị xóa
        public const string LISTMODEL_NULL = "0701";//Danh sách rỗng
        public const string DATA_NULL = "0702";//Không có dữ liệu
        public const string DATA_DUPLICATE = "0703";//Trùng lặp dữ liệu
        public const string ENOUGH_QUANTITY = "0704";//Đủ số lượng
        public const string GETTOKEN_FALSE = "0705";//Xác thực tài khoản thất bại
    }

    public static class ResponseDetail
    {
        //Reponse noi dung tu api tra ve
        public const string SUCCESSDETAIL = "Thành Công";

        public const string SYSTEM_ERRORDETAIL = "Lỗi hệ thống";
        public const string UNKNOWN_ERRORDETAIL = "Lỗi không xác định";
        public const string UPDATE_ERRORDETAIL = "Cập nhật không thành công";
        public const string DATA_NOTDELETEDETAIL = "Dữ liệu không thể xóa";
        public const string INPUTDATA_ERRORDETAIL = "Dữ liệu đầu vào không chính xác";
        public const string OLDPASSWORD_ERRORDETAIL = "Mật khẩu cũ không chính xác";
        public const string USER_DELETEDDETAIL = "Tài khoản đã bị xóa";
        public const string LISTMODEL_NULLDETAIL = "Danh sách rỗng";
        public const string DATA_NULLDETAIL = "Không có dữ liệu";
        public const string DATA_DUPLICATEDETAIL = "Trùng lặp dữ liệu";
        public const string ENOUGH_QUANTITYDETAIL = "Đủ số lượng";
        public const string GETTOKEN_FALSEDETAIL = "Xác thực tài khoản không thành công";//Xác thực tài khoản thất bại
    }

    public class JsonResponse
    {
        public string type { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public int draw { get; set; }
        public string error { get; set; }
        public string icon { get; set; }
    }
    public class TreeNodeModel
    {
        public string id { get; set; }
        public string text { get; set; }
        public string type { get; set; }
        public lstState state { get; set; }
        public List<TreeNodeModel> children { get; set; } = new List<TreeNodeModel>();
        public bool IsLazyLoading { get; set; }
    }

    public class lstState
    {
        public bool selected { get; set; } = false;
    }
}