using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CMS.BillStatus
{
    public class BillStatusPaging
    {
        public List<BillStatus> lst { get; set; }
        public int totalCount { get; set; }
    }
}
