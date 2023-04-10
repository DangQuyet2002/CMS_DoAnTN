using System;

namespace Models
{
    public class IdentityAccount : BaseModel
    {
        public string Sub { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }

        [System.ComponentModel.DefaultValue(false)]
        public bool ChangeFirstPassword { get; set; }

        public string NewPasswordHash { get; set; } // New Password

        [System.ComponentModel.DefaultValue(false)]
        public bool IsPasswordAutoGen { get; set; } = false; //Auto generate new password

        [System.ComponentModel.DefaultValue(false)]
        public bool IsAdmin { get; set; }

        //Addmin create account add claims
        public string nameClaims { get; set; }

        public string given_name { get; set; }
        public string family_name { get; set; }
        public string RoleId { get; set; }

        public string Ma_cb { get; set; }
        public string Ho_ten { get; set; }
        public DateTime? Ngay_sinh { get; set; }
        public int GioiTinh { get; set; }
        public int IdDV { get; set; }
        public string SDT { get; set; }
        public string Id_cb { get; set; }
        public bool IsLocked { get; set; } // 1 Khóa - 0 không khóa

    }
}