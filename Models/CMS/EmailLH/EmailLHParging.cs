﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class EmailLHPaging : BasePaging
    {
		public List<EmailLH> lst { get; set; }
		public int totalCount { get; set; }
	}
}
