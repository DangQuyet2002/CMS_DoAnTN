using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_PostModel : BaseModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public string Thumnail { get; set; }

        public string PostContent { get; set; }

        public bool IsDraft { get; set; }

        public int? IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public int CategoryID { get; set; }

        public bool IsHighlight { get; set; }

        public string AttachFile { get; set; }

        public int NumberViewer { get; set; }

        public string ShortThumnailContent { get; set; }

        public int? Status { get; set; }

        public int? IsBTVDuyet { get; set; }

        public int? IsTK_GDDuyet { get; set; } //0 Chua gui - 1 da gui - 2 da nhan - 3 tra lai

        public string TuKhoaSeo { get; set; }

        public string MoTaSeo { get; set; }

        public string LyDoTraLaiBTV { get; set; }

        public string LyDoTraLaiTK_GD { get; set; }

        public bool IsDelete { get; set; }

        public int? IsPVDuyet { get; set; }
        public DateTime? NgayPhatHanh { get; set; }
        public int? IsTinMoi { get; set; }
        public string lstIdCategory { get; set; }
        public List<int> lstIdChuyenMuc { get; set; }
        public int IdUserPVDuyet { get; set; }
        public int IdUserBTVDuyet { get; set; }
        public int IdUserTK_GDDuyet { get; set; }
        public DateTime? NgayPVDuyet { get; set; }
        public DateTime? NgayBTVDuyet { get; set; }
        public DateTime? NgayTK_GDDuyet { get; set; }
        public List<tbl_Post_CategoryModel> LstChuyenMuc { get; set; }
        public List<int> lstIdBaiViet { get; set; }
        public string TacGia { get; set; }
        public int IsCheckNgayPhatHanh { get; set; }
    }

    public class tbl_Post_CategoryModel
    {
        public int Id { get; set; }
        public int IdPost { get; set; }
        public int IdCategory { get; set; }
    }

}
