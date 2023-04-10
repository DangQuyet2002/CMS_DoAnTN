using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Log4NetLogModel : BaseModel
    {
        public int Id { get; set; }

        public DateTime? Date { get; set; }

        public string Thread { get; set; }

        public string Level { get; set; }

        public string Logger { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }

        public string IP { get; set; }

        public string UserId { get; set; }
        public string UserName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
        public string txtKey { get; set; }

    }
}
