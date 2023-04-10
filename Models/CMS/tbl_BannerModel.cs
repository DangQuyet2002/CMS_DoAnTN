using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_BannerModel : BaseModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdateBy { get; set; }

        public bool IsDelete { get; set; }

        public string Image { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }

        public int IdVT { get; set; }

        public string Ten { get; set; }
        public int IdViTri { get; set; }
        public int IdChuyenMuc { get; set; }
        public int Id_Banner { get; set; }
        public DateTime? NgayHienTai { get; set; }
        public int IsSilde { get; set; }
    }
}
