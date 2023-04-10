using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_VanBanModel : BaseModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdateBy { get; set; }

        public bool IsDelete { get; set; }

        public string File { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public string TenFile { get; set; }
        public DateTime? NgayPhatHanh { get; set; }
        public int? IdCategory { get; set; }
        public int IsCheckNgayPhatHanh { get; set; }
    }

    public class tbl_LoaiVanBanModel : BaseModel
    {
        public int Id { get; set; }
        public string Ten { get; set; }
    }
}
