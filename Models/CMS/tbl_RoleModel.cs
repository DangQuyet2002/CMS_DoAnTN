using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_RoleModel : BaseModel
    {
        public int Id { get; set; }

        public string Ten { get; set; }
        public int IdUser { get; set; }

        public int IdRole { get; set; }
        public string Menu { get; set; }
        public int IdMenu { get; set; }
        public string Ma { get; set; }

    }
}
