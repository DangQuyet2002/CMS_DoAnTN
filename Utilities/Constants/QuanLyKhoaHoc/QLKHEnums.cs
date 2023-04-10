using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class QLKHEnums
    {
        public enum Role
        {
            [Display(Name = "Quản trị")]
            QuanTri = 1,
            [Display(Name = "Cán bộ")]
            CanBo = 2,
            [Display(Name = "Trợ lý")]
            TroLy = 3
        }
        public enum LoaiBaiBao
        {
            ISI = 1,
            Scopus = 2,
            QuocTeKhac = 3,
            TrongNuoc = 4
        }

        public enum LoaiSach
        {
            GiaoTrinh = 1,
            SachChuyenKhao = 2,
            SachThamKhao = 3,
            SachHuongDan = 4
        }

        public enum LoaiGiaiThuong
        {
            XuatSac = 1,
            Nhat = 2,
            Nhi = 3,
            Ba = 4,
            KhuyenKhich = 5
        }

        public enum LoaiSoHuuTriTue
        {
            DocQuyenSangChe = 1,
            DocQuyenSangCheVN = 2,
            GiaiPhapHuuIch = 3,
            QuyenTacGia = 4
        }

        public enum PhamViBaiBao
        {
            QuocTe = 1,
            TrongNuoc = 2
        }

        public enum LoaiHoiDong
        {
            ThamDinhNoiDung = 1,
            ThamDinhKinhPhi = 2,
            NghiemThuCoSo = 3,
            NghiemThuQuanLy = 4
        }

        public enum LoaiSanPhamNCKH
        {
            BaiBao = 1,
            HoiNghi = 2,
            Sach = 3,
            HoSoThau = 4,
            DeTai = 5,
            HuongDanSinhVien = 6,
            GiaiThuong = 7,
            HoiDongDaoDuc = 8,
            SoHuuTriTue = 9,
            BaoCaoChuyenDe = 10,
            SangKienCoSo = 13
        }

        public enum VaiTroDeTai
        {
            ChuNhiem = 1,
            ThuKyNhiemVu = 2,
            ThanhVienChinh = 3,
            ThanhVien = 4,
            KyThuatVien = 5,
            ChuyenGia = 6,
            TacGiaChinh = 7,
            DongTacGia = 8
        }

        public enum CapDeTai
        {
            CapNhaNuoc = 1,
            CapBo = 2,
            CapTinhTP = 3,
            HopTacQuocTe = 4,
            CapCoSo = 5,
            QuyNafosted = 6
        }

        public enum VaiTroBaiBao
        {
            TacGiaChinh = 1,
            DongTacGia = 2,
            TacGiaLienHe = 3
        }

        public enum VaiTroSach
        {
            ChuBien = 1,
            DongChuBien = 2,
            DongTacGia = 3,
            ThuKyBienTap = 4
        }

        public enum NhomGiaiThuong
        {
            NghienCuuKhoaHoc = 1,
            ThanhTichTheThao = 2
        }

        public enum AttachFileGroup
        {
            BaiBao = 1,
            BaoCaoHoiNghi = 2,
            SachTaiLieu = 3,
            DeTai = 4,
            DeTaiSinhVien = 5,
            GiaiThuong = 6,
            SoHuuTriTue = 7,
            KinhPhiDeTai = 8,
            QuaTrinhThanhToan = 9,
            DeXuatDeTai = 10,
            ThuyetMinh = 11,
            DeXuatDeTaiSinhVien = 12,
            ThuyetMinhSinhVien = 13,
            HoiDongDeTai = 14,
            HoiDongDeXuatDeTai = 15,
            HoiDongThuyetMinh = 16,
            HoiDongDeTaiSinhVien = 17,
            HoiDongDeXuatDeTaiSinhVien = 18,
            HoiDongThuyetMinhSinhVien = 19,
            BaoCaoTienDoNhiemVuKHCN = 20,
            HoiThao = 21,
            HopDongChuyenGiao = 22,
            HoSoThanhToan = 23,
            DangKyThucHienDeTai = 24,
            DangKyNghiemThuDeTai = 25,
            SanPham = 26,
            HoiDongSangKien = 27
        }

        public enum LoaiChiPhi
        {
            CongLaoDong = 1,
            CongTac = 2,
            DichVuNgoai = 3,
            GianTiep = 4,
            NguyenVatLieu = 5
        }
    }
}
