using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_ThuVienAnhModel : BaseModel
    {
        public int Id { get; set; }

        public int? IsHienThi { get; set; }

        public string Image { get; set; }

        public string MoTa { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? NgayPhatHanh { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdateBy { get; set; }

        public int CategoryID { get; set; }
        public int IsCheckNgayPhatHanh { get; set; }
        public string UserName { get; set; }
        public List<tbl_ThuVienAnh_AlbumModel> DanhSachAnh { get; set; } = new List<tbl_ThuVienAnh_AlbumModel>();
    }

    public class tbl_ThuVienAnh_AlbumModel
    {
        public int Id { get; set; }

        public string FileImage { get; set; }

        public int IdThuVienImage { get; set; }

        public string MoTa { get; set; }
        public string GuildId { get; set; }
    }
}
