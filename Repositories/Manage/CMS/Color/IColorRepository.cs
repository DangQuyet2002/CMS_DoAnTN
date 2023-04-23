using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IColorRepository
    {
         Task<ColorPaging> GetAll(ColorRequest requestModel);
    }
}
