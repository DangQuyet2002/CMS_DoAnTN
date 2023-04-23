using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface ISizeRepository
    {
        public Task<SizePaging> GetAll(SizeRequest requestModel);

    }
}
