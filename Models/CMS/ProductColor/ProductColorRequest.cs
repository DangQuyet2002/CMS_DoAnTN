﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ProductColorRequest : BaseRequest
    {
        public string ListId { get; set; }
        public int Id { get; set; }
    }
}