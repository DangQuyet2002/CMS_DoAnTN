using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GiangVien : BaseModel
    {
        public string Ma_cb { get; set; }
        public string TenGiangVien { get; set; }
        public string MaGiangVienHoTen { get; set; }
    }
    public class GiangVienResuult : BaseRequest
    {
        public List<GiangVien> data { get; set; }
    }
}
