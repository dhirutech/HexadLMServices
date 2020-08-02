using System.Collections.Generic;

namespace HexadLMServices.Models
{
    public class MyBooks
    {
        public int UserId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
