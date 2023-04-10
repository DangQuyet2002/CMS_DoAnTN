using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_LienKetGioiThieuModel:BaseModel
    {
        public int Id { get; set; }

        public string MoTa { get; set; }

        public string Url { get; set; }
        public int STT { get; set; }
    }
}
