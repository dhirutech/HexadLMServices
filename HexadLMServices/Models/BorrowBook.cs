﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexadLMServices.Models
{
    public class BorrowBook
    {
        public int UserId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
