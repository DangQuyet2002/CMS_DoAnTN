using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using static Dapper.SqlMapper;

namespace Utilities
{
    public class ParamsHelper
    {
        public static ICustomQueryParameter ThanhVienParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "CanBoID", "VaiTroID", "SoTrangViet", "PhuongThucQuyDoiID", "IsSangKienCoSo", "GioNCKH" };
            var dt = new DataTable();
            //Add column
            foreach(var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach(string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if(prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }
                       
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_ThanhVienNCKH");
        }
        
        public static ICustomQueryParameter GioNCKHParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "ThanhVienID", "NamHoc", "TyLeThamGia", "GioNCKH", "TrangThaiTinhGio",
                "PhanHoi", "KhenThuong", "TrangThaiKhenThuong", "PhanHoiKhenThuong", "GioDinhMuc"};
            var dt = new DataTable();
            //Add column
            foreach(var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach(string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if(prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }
                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_GioNCKH");
        }

        public static ICustomQueryParameter QLKHDiemCongTrinhKHParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "NamHanhChinh", "ThanhVienID", "SoDiemHDCD", "DiemCongTrinhKH" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_DiemCongTrinhKH");
        }

        public static ICustomQueryParameter QLKHKinhPhiDeTaiChiTietParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "DeTaiID", "KinhPhiCap", "KinhPhiDuToan", "KinhPhiTamUng", "KinhPhiQuyetToan", "KinhPhiChuyenKySau", "LanThu", "NamHanhChinh" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_KinhPhiDeTaiChiTiet");
        }

        public static ICustomQueryParameter QLKHHoTroBaiBaoParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "ThanhVienID", "NamHoc", "SoTienHoTro" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_HoTroBaiBao");
        }

        public static ICustomQueryParameter QLKHAttachedFileParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "FileGroupID", "ProductID", "FileKey", "FileName", "FilePath" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_AttachedFile");
        }

        public static ICustomQueryParameter QLTCAttachedFileParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "GroupCode", "ProductID", "FileKey", "FileName", "FilePath" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLTC_AttachedFile");
        }

        public static ICustomQueryParameter QLKHSVThanhVienNCKHParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "DeTaiSVID", "DeXuatDeTaiSVID", "SinhVienID", "DiemTBC", "DiemThiHocPhan" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_SV_ThanhVienNCKH");
        }

        public static ICustomQueryParameter ThanhVienHoiDongParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "Stt", "CanBoID", "HoTen", "TenDonVi", "VaiTro" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLKH_ThanhVienHoiDong");
        }

        public static ICustomQueryParameter QLTCNguoiPhanBienParams<T>(List<T> requestModel)
        {
            List<string> fields = new List<string>() { "Id", "BaiBaoID", "HoTen", "DonVi", "Email" };
            var dt = new DataTable();
            //Add column
            foreach (var item in fields)
            {
                dt.Columns.Add(item);
            }
            //Add row
            if (requestModel != null && requestModel.Count > 0)
            {
                foreach (T item in requestModel)
                {
                    var dr = dt.NewRow();
                    foreach (string field in fields)
                    {
                        PropertyInfo prop = item.GetType().GetProperty(field);
                        if (prop != null)
                        {
                            dr[prop.Name] = prop.GetValue(item, null);
                        }

                    }
                    dt.Rows.Add(dr);
                }
            }
            return dt.AsTableValuedParameter("t_QLTC_NguoiPhanBien");
        }
    }
}
