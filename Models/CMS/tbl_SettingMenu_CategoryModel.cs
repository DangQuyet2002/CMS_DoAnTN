using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_SettingMenu_CategoryModel : BaseModel
    {
        public int Id { get; set; }

        public int IdCategory { get; set; }

        public int IdSettingMenu { get; set; }

        public int STT { get; set; }
        public string Ten { get; set; }
        public string Name { get; set; }

        public int LoaiCategory_Khac { get; set; }
        public string Url { get; set; }

        public int ParentID { get; set; }
        public List<tbl_PostModel> DanhSachBaiViet { get; set; } = new List<tbl_PostModel>();
        public List<tbl_SettingMenu_CategoryModel> MenuSub { get; set; } = new List<tbl_SettingMenu_CategoryModel>();
    }
}
