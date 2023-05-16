using Models.CMS;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices.CMS.EmailLienHe
{
    public interface IEmailLienHeService
    {
        
        Task<Response> ThemMoi(tbl_EmailLienHe requestModel);
        Task<BaseRespone<tbl_EmailLienHe>> DanhSach(tbl_EmailLienHe requestModel);


    }
}
