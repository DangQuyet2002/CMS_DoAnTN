using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BillInfo
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public float Total { get; set; }
        public string FullName { get; set; }
        public int Status { get; set; }
        public DateTime? CreateDate { get; set; }


    }
}

