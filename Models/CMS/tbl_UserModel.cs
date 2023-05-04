using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_UserModel : BaseModel
    {
        public int ID { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Gender { get; set; }

        public bool IsActive { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApprover { get; set; }

        public DateTime? CreatedAt { get; set; }

        public int CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public int UpdatedBy { get; set; }

        public string TypeUser { get; set; }

        public string Image { get; set; }
        public string Address { get; set; }

        public List<tbl_RoleModel> lstQuyen { get; set; } = new List<tbl_RoleModel>();
        public List<tbl_UserModel> lst { get; set; }
    }
}
