using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CMS.Product
{
    public class ProductPaging
    {
        public List<tbl_ProductModel> lst { get; set; }
        public int totalCount { get; set; }
    }
}
