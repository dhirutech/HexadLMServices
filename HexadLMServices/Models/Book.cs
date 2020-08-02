using System;

namespace HexadLMServices.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public string Publication { get; set; }
        public DateTime? Yearofpub { get; set; }
        public bool IsActive { get; set; }
        public int StockCount { get; set; } = 0;
    }
}
