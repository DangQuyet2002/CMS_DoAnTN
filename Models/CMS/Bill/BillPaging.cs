using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BillPaging
    {
        public List<Bill> lst { get; set; }
        public int totalCount { get; set; }
    }
}
