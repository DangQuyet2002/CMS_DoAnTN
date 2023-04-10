using System.Collections.Generic;

namespace Models
{
    public class AspNetUsers : BaseModelPhanQuyen
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string FullName { get; set; }
    }

    public class AspNetUsersResult : BasePaging
    {
        public List<AspNetUsers> data { get; set; }
    }

    public class AspNetUsersRequest : BaseRequest
    {
        public string RoleName { get; set; }
    }
}