using Models;
using Models.CMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Manage.CMS.EmailLienHe
{
    public interface IEmailLienHeRepository
    {
        Task<Response> ThemMoi(tbl_EmailLienHe requestModel);
        Task<BaseRespone<tbl_EmailLienHe>> DanhSach(tbl_EmailLienHe requestModel);


    }
}
