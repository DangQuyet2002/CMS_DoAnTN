using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_ThuVienAudioModel : BaseModel
    {
        public int Id { get; set; }

        public string Image { get; set; }
        public string UserName { get; set; }

        public string Audio { get; set; }

        public string MoTa { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdateBy { get; set; }

        public int CategoryID { get; set; }

        public string ChuThich { get; set; }

        public bool IsDelete { get; set; }

        public int? IsHienThi { get; set; }

        public DateTime? NgayDang { get; set; }
        public string Url { get; set; }

        public int IsCheckAudioMoi { get; set; }
        public string lstIdAudioMoi { get; set; }
        public int IsCheckNgayPhatHanh { get; set; }
    }
}
