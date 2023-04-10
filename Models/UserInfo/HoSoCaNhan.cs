using System.Collections.Generic;

namespace Models
{
    public class HoSoCaNhan : BaseModel
    {
        public int ID_user { get; set; }
        public string UserName { get; set; }
        public string Ho_ten { get; set; }
        public string Ngay_sinh { get; set; }
        public string Que_quan { get; set; }
        public string Dienthoai_canhan { get; set; }
        public string Email { get; set; }
        public string CMND { get; set; }
        public string Ngay_cap { get; set; }
        public string Noi_cap { get; set; }
        public int ID_gioi_tinh { get; set; }
        public string MaSVHoTen { get; set; }
    }

    public class HoSoCaNhanResult : BaseRequest
    {
        public List<HoSoCaNhan> data { get; set; }
    }
}