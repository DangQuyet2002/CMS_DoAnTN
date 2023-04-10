using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_LikePostModel : BaseModel
    {
        public int Id { get; set; }

        public int IdPost { get; set; }

        public int IdUser { get; set; }
    }
}
