using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductSize
    {
        public int Id { get; set; }
        public int SizeId { get; set; }
        public string SizeName { get; set; }
        public int ProductId { get; set; }
        public string ListSizeId { get; set; }
    }
}
