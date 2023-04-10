using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public static class GenerateString
    {
        public static string generateID(string key)
        {
            return string.Format("{0}_{1:N}", key, Guid.NewGuid());
        }
    }
}
