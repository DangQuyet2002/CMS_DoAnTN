using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductColor
    {
        public int Id { get; set; }
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public int ProductId { get; set; }
        public string ListColorId { get; set; }
    }
}
