using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GioHang
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public int ColorId { get; set; }
        public int DisCount { get; set; }
        public int SizeId { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public string NameColor { get; set; }
        public string NameSize { get; set; }
        public int Status { get; set; }
    }
}
