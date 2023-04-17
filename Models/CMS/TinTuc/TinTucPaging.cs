using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TinTucPaging
    {
        public TinTucPaging()
        {
            lst = new List<TinTucModel>();
        }
        public List<TinTucModel> lst { get; set; }
        public int totalCont { get; set; }
    }
}
