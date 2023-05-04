using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ColorPaging
    {
        public List<ColorModel> lst { get; set; }
        public int totalCount { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
