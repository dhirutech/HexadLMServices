using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HexadLMServices.Models
{
    public class MyBooks
    {
        public int UserId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
