using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Bill
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string NameReceiver { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string NameColor { get; set; }
        public string NameSize { get; set; }
        public int IdPro { get; set; }
        public string Product { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public string DateCreate { get; set; }
        public float Total { get; set; }
        public float TotalNew { get; set; }

        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int Payments { get; set; }
        public int Status { get; set; }
        public string NameStatus { get; set; }

        public string Describe { get; set; }
        public string ListIdCart { get; set; }
    }
}
