using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.CMS.Product
{
    public class ProductRequest : BaseRequest
    {
        public string ListId { get; set; }
        public string CategoryId { get; set; }
        public string CategoryMinId { get; set; }
    }
}
