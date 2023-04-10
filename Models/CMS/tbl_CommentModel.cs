using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_CommentModel : BaseModel
    {
        public int Id { get; set; }

        public int IdPost { get; set; }

        public int IdUser { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string NoiDung { get; set; }

        public int IdParent { get; set; }
        public string UserName { get; set; }
        public string Image { get; set; }
    }
}
