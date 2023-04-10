using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_CategoryModel : BaseModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public int Position { get; set; }

        public int ParentID { get; set; }

        public bool Status { get; set; }

        public bool IsDelete { get; set; }
        public string Url { get; set; }
        public int IdSettingMenu { get; set; }
        public int SoLuong { get; set; }
        public int? LoaiCategory_Khac { get; set; }
    }
}
