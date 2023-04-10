using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class tbl_ProductModel : BaseModel
    {
        public int Id { get; set; }
        public string NamePro { get; set; }
        public int Price { get; set; }
        public int PriceNew { get; set; }
        public string Image { get; set; }
        public string TenCate { get; set; }
        public string TenCateMin { get; set; }
        public string MoTa { get; set; }
        public int CategoryId { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public int View { get; set; }
        public int CategoryminId { get; set; }
    }


}
